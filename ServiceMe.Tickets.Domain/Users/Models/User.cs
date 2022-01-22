using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Users.DataStructures;

namespace ServiceMe.Tickets.Domain.Users.Models;

public class User : BaseAggregateRoot
{
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsArchived { get; private set; }
    private List<UserRole> _userRoles = new();
    public IEnumerable<UserRole> UserRoles 
    { 
        get => _userRoles;
        private set => _userRoles = value.ToList();
    }

    public User(IDomainEventsManager domainEventsManager, UserDataStructure dataStructure) : base(dataStructure.Id, domainEventsManager)
    {
        UserName = dataStructure.UserName;
        Email = dataStructure.Email;
        FirstName = dataStructure.FirstName;
        LastName = dataStructure.LastName;
        IsArchived = dataStructure.IsArchived;
    }

    private User()
    {
        
    }

    public void SetDependencies(IDomainEventsManager domainEventsManager)
    {
        base.SetDependencies(domainEventsManager);
    }

    public void Update(UserDataStructure dataStructure)
    {
        AssignFromDataStructure(dataStructure);         
    }

    public void ReplaceRoles(IEnumerable<UserRoleData> roles)
    {
        _userRoles = roles.Select(x => new UserRole(x.Id, x.Type)).ToList();
    }

    private void AssignFromDataStructure(UserDataStructure dataStructure)
    {
        UserName = dataStructure.UserName;
        Email = dataStructure.Email;
        FirstName = dataStructure.FirstName;
        LastName = dataStructure.LastName;
        IsArchived = dataStructure.IsArchived;
    }
}