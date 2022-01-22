using PlaygroundShared.Domain.Domain;
using PlaygroundShared.IntercontextCommunication.Messages;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

public class UserUpdatedEvent : IMessage
{
    public AggregateId Id { get; set; }
    public string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid CorrelationId { get; set; }
}