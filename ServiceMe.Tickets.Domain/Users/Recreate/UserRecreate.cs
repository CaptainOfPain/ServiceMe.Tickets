using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Domain.Users.Recreate;

public class UserRecreate : IAggregateRecreate<User>
{
    private readonly IDomainEventsManager _domainEventsManager;

    public UserRecreate(IDomainEventsManager domainEventsManager)
    {
        _domainEventsManager = domainEventsManager;
    }
    
    public void Init(User aggregate)
    {
        aggregate.SetDependencies(_domainEventsManager);
    }
}