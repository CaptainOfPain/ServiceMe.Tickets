using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class RejectedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public RejectedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Rejected;

    public string Message => "TicketStatusShouldBeRejected";
}