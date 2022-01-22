using PlaygroundShared.Domain.Domain;
using PlaygroundShared.IntercontextCommunication.Messages;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

public class UserRolesUpdatedEvent : IMessage
{
    public Guid CorrelationId { get; set; }
    public AggregateId Id { get; set; }
    public IEnumerable<UserRoleEventData> UserRoles { get; set; }
}