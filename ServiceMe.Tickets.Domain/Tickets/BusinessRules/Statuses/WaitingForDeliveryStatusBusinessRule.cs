using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class WaitingForDeliveryStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public WaitingForDeliveryStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.WaitingForDelivery;

    public string Message => "TicketStatusShouldBeWaitingForDelivery";
}