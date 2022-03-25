using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class ReadyForPickupStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public ReadyForPickupStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.ReadyForPickup;

    public string Message => "TicketStatusShouldBeReadyForPickup";
}