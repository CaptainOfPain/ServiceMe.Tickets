using AutoMapper;
using Newtonsoft.Json;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Infrastructure.Persistence.Users;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id.Id))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForMember(x => x.UserRoles, opt => opt.MapFrom(x => x.UserRoles));
        
        CreateMap<UserEntity, User>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => new AggregateId(x.Id)))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForMember(x => x.UserRoles, opt => opt.MapFrom(x => x.UserRoles));

        CreateMap<UserRole, UserRoleEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.UserRoleType, opt => opt.MapFrom(x => (int) x.Type));

        CreateMap<UserRoleEntity, UserRole>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Type, opt => opt.MapFrom(x => (UserRoleType) x.UserRoleType));
        
        CreateMap<IDomainEvent, UserEventEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
            .ForMember(x => x.AggregateId, opt => opt.MapFrom(x => x.Id.ToGuid()))
            .ForMember(x => x.Event, opt => opt.MapFrom(x => JsonConvert.SerializeObject(x)))
            .ForMember(x => x.CorrelationId, opt => opt.MapFrom(x => x.CorrelationId))
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.EventType, opt => opt.MapFrom(x => x.GetType().FullName));

            
    }
}