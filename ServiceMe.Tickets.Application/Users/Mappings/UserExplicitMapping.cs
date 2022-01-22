using ServiceMe.Tickets.Application.Users.Commands;
using ServiceMe.Tickets.Domain.Users.DataStructures;

namespace ServiceMe.Tickets.Application.Users.Mappings;

public static class UserExplicitMapping
{
    public static UserDataStructure ToUserDataStructure(this CreateUserCommand command)
        => new(command.Id, command.UserName, command.Email, command.FirstName, command.LastName, false);
    
    public static UserDataStructure ToUserDataStructure(this UpdateUserCommand command)
        => new(command.Id, command.UserName, command.Email, command.FirstName, command.LastName, false);

    public static IEnumerable<UserRoleData> ToUserRolesData(this UpdateUserRolesCommand command)
        => command.UserRoles.Select(x => new UserRoleData(x.Id, x.UserRoleType));
}