using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class CostsRejectedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public CostsRejectedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.CostsRejected;

    public string Message => "TicketStatusShouldBeCostsRejected";
}