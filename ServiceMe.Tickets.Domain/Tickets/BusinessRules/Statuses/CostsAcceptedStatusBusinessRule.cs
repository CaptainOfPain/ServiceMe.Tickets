using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class CostsAcceptedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public CostsAcceptedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.CostsAccepted;

    public string Message => "TicketStatusShouldBeCostsAccepted";
}