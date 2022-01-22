using PlaygroundShared.Domain.Domain;

namespace ServiceMe.Tickets.Domain.Users.DataStructures;

public class UserDataStructure
{
    public AggregateId Id { get; }
    public string UserName { get; }
    public string Email { get; }
    public string? FirstName { get; }
    public string? LastName { get; }
    public bool IsArchived { get; }

    public UserDataStructure(AggregateId id, string userName, string email, string? firstName, string? lastName, bool isArchived)
    {
        Id = id;
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        IsArchived = isArchived;
    }
}