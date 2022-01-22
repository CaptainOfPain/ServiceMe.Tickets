using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace ServiceMe.Tickets.Application.Users.Commands;

public class UpdateUserRolesCommand : ICommand
{
    public AggregateId Id { get; }
    public IEnumerable<UserRoleCommandData> UserRoles { get; }

    public UpdateUserRolesCommand(AggregateId id, IEnumerable<UserRoleCommandData> userRoles)
    {
        Id = id;
        UserRoles = userRoles;
    }
}