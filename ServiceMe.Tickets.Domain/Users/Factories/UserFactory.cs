using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Users.DataStructures;
using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Domain.Users.Factories;

public class UserFactory : IUserFactory
{
    private readonly IDomainEventsManager _domainEventsManager;

    public UserFactory(IDomainEventsManager domainEventsManager)
    {
        _domainEventsManager = domainEventsManager ?? throw new ArgumentNullException(nameof(domainEventsManager));
    }

    public User Create(UserDataStructure dataStructure) => new(_domainEventsManager, dataStructure);
}