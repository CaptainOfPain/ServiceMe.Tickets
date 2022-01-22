using System.Reflection;
using Autofac;
using AutoMapper;
using PlaygroundShared.Application.IoC;
using PlaygroundShared.Configurations;
using PlaygroundShared.Domain.IoC;
using PlaygroundShared.Domain.Shared;
using PlaygroundShared.Infrastructure.Core.IoC;
using PlaygroundShared.Infrastructure.MongoDb.IoC;
using PlaygroundShared.IntercontextCommunication;
using PlaygroundShared.IntercontextCommunication.RabbitMq.IoC;
using ServiceMe.Tickets.Application.Users.Commands;
using ServiceMe.Tickets.Domain.Users.Models;
using ServiceMe.Tickets.Infrastructure.MongoDb.Users;
using ServiceMe.Tickets.Infrastructure.Persistence.Users;
using ServiceMe.Tickets.IntercontextCommunication.Users.Messages;
using Module = Autofac.Module;

namespace ServiceMe.Tickets.Api.IoC;

public class RootModule : Module
{
    private readonly IConfiguration _configuration;

    public RootModule(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.Register(ctx => _configuration.GetSection("JwtConfig").Get<JwtConfiguration>()).As<IJwtConfiguration>().SingleInstance();
        builder.RegisterModule(new MongoDbModule(_configuration, typeof(UserMongoRepository).Assembly));
        builder.RegisterModule(new RabbitMqModule("./busConfig.json"));
        builder.RegisterModule(new DomainModule(typeof(User).Assembly));
        builder.RegisterModule(new InfrastructureModule(new []{typeof(UserMongoRepository).Assembly,typeof(UserRepository).Assembly}));
        builder.RegisterModule(new ApplicationModule(typeof(CreateUserCommand).Assembly));
        builder.RegisterAssemblyTypes(typeof(UserCreatedEvent).Assembly).AsClosedTypesOf(typeof(IMessageHandler<>));
        builder.Register(ctx => new CorrelationContext()).As<ICorrelationContext>().InstancePerLifetimeScope();
        
        builder.Register(ctx =>
        {
            var assemblies = new List<Assembly>()
            {
                typeof(UserMappingProfile).Assembly
            };

            var profiles = assemblies.SelectMany(x => x.GetExportedTypes()).Where(x => x.IsAssignableTo<Profile>())
                .Select(x => (Profile) Activator.CreateInstance(x));

            var cfg = new MapperConfiguration(m =>
            {
                m.DisableConstructorMapping();
                m.AddProfiles(profiles);
            });

            return new Mapper(cfg);
        }).As<IMapper>().InstancePerLifetimeScope();
    }
}