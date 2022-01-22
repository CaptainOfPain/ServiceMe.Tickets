using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

public class UserRoleEventData
{
    public Guid Id { get; set; }
    public UserRoleType UserRole { get; set; }
}