using PlaygroundShared.Domain.Domain;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.DataStructures;

public class TicketDataStructure
{
    public AggregateId CustomerId { get;}
    public string Title { get; }
    public string Description { get; }
    public string? DeviceName { get; }
    public TicketType Type { get; }

    public TicketDataStructure(AggregateId customerId, string title, string description, string deviceName, TicketType type)
    {
        CustomerId = customerId;
        Title = title;
        Description = description;
        DeviceName = deviceName;
        Type = type;
    }
}