using AutoMapper;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using PlaygroundShared.Infrastructure.Core.Repositories;
using ServiceMe.Tickets.Domain.Users.Models;
using ServiceMe.Tickets.Domain.Users.Repositories;

namespace ServiceMe.Tickets.Infrastructure.Persistence.Users;

public class UserRepository : BaseAggregateRootRepository<User, UserEntity, UserEventEntity>, IUserRepository
{
    public UserRepository(IGenericRepository<UserEntity> repository, IGenericEventRepository<UserEventEntity> eventRepository, IDomainEventsManager domainEventsManager, IMapper mapper, IAggregateRecreate<User> aggregateRecreate) : base(repository, eventRepository, domainEventsManager, mapper, aggregateRecreate)
    {
    }
}