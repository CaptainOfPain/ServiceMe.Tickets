using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class CostsEstimatedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public CostsEstimatedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.CostsEstimated;

    public string Message => "TicketStatusShouldBeCostsEstimated";
}