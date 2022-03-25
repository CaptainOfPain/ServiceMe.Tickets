using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.Events;

public class TicketStatusChangedEvent : IDomainEvent
{
    public Guid CorrelationId { get; set; }
    public AggregateId Id { get; }
    public TicketStatus Status { get; }
    public TicketStatus OldStatus { get; }

    private TicketStatusChangedEvent(AggregateId id, TicketStatus status, TicketStatus oldStatus)
    {
        Id = id;
        Status = status;
        OldStatus = oldStatus;
    }

    public static TicketStatusChangedEvent Create(Ticket ticket, TicketStatus oldStatus) =>
        new(ticket.Id, ticket.Status, oldStatus);
}