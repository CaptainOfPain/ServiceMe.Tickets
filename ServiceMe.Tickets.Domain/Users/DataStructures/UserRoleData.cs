using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Domain.Users.DataStructures;

public class UserRoleData
{
    public Guid Id { get; }
    public UserRoleType Type { get; }

    public UserRoleData(Guid id, UserRoleType type)
    {
        Id = id;
        Type = type;
    }
}