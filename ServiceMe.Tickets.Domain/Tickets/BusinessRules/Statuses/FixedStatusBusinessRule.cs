using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class FixedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public FixedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Fixed;

    public string Message => "TicketStatusShouldBeFixed";
}