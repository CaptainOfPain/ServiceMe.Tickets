using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;

namespace ServiceMe.Tickets.Domain.Tickets.Models;

public class Ticket : BaseAggregateRoot
{
    public AggregateId CustomerId { get; private set; }
    public AggregateId? TechnicianId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<TicketPhoto> Photos { get; private set; }
    public TicketStatus Status { get; private set; }
    public string DeviceName { get; private set; }
    public TicketType Type { get; private set; }
    public IEnumerable<TicketConversationItem> Conversation { get; private set; }
    public decimal? EstimatedCost { get; set; }
    public decimal? Cost { get; set; }
    public DateTime? EstimatedDate { get; set; }
    
    
    public Ticket(AggregateId id, IDomainEventsManager domainEventsManager) : base(id, domainEventsManager)
    {
    }

    private Ticket()
    {
    }
}

public class TicketConversationItem
{
    public Guid Id { get; private set; }
    public bool FromCustomer { get; private set; }
    public string Message { get; private set; }
}