using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class CostsAcceptanceStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public CostsAcceptanceStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.CostsAcceptance;

    public string Message => "TicketStatusShouldBeCostsAcceptance";
}