using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.Events;

public class TicketUpdatedEvent : IDomainEvent
{
    public Guid CorrelationId { get; set; }
    public AggregateId Id { get; }
    public AggregateId CustomerId { get; }
    public string Title { get; }
    public string Description { get; }
    public string? DeviceName { get; }
    public TicketType Type { get; }
    public TicketStatus Status { get; }

    private TicketUpdatedEvent(AggregateId id, AggregateId customerId, string title, string description, string? deviceName, TicketType type, TicketStatus status)
    {
        Id = id;
        CustomerId = customerId;
        Title = title;
        Description = description;
        DeviceName = deviceName;
        Type = type;
        Status = status;
    }

    public static TicketUpdatedEvent Create(Ticket ticket)
        => new (ticket.Id, ticket.CustomerId, ticket.Title, ticket.Description, ticket.DeviceName,
            ticket.Type, ticket.Status);
}