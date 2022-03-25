using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.Events;

public class TicketEstimatedEvent : IDomainEvent
{
    public Guid CorrelationId { get; set; }
    public AggregateId Id { get; }
    public decimal EstimatedCost { get; }
    public DateTime EstimatedDate { get; }
    
    private TicketEstimatedEvent(AggregateId id, decimal estimatedCost, DateTime estimatedDate)
    {
        Id = id;
        EstimatedCost = estimatedCost;
        EstimatedDate = estimatedDate;
    }

    public static TicketEstimatedEvent Create(Ticket ticket) =>
        new(ticket.Id, ticket.EstimatedCost.Value, ticket.EstimatedDate.Value);
}