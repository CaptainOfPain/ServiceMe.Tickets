using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Application.Users.Commands;

public class UserRoleCommandData
{
    public Guid Id { get; }
    public UserRoleType UserRoleType { get; }

    public UserRoleCommandData(Guid id, UserRoleType userRoleType)
    {
        Id = id;
        UserRoleType = userRoleType;
    }
}