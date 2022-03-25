using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.Events;

public class TicketTechnicianAddedEvent : IDomainEvent
{
    public AggregateId Id { get; }
    public AggregateId? TechnicianId { get; }
    public Guid CorrelationId { get; set; }

    private TicketTechnicianAddedEvent(AggregateId id, AggregateId? technicianId)
    {
        Id = id;
        TechnicianId = technicianId;
    }

    public static TicketTechnicianAddedEvent Create(Ticket ticket)
        => new (ticket.Id, ticket.TechnicianId);
}