using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class DeliveredStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public DeliveredStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Delivered;

    public string Message => "TicketStatusShouldBeDelivered";
}