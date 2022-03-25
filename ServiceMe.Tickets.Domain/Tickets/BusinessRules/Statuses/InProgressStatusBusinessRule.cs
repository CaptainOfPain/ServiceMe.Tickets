using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class InProgressStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public InProgressStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.InProgress;

    public string Message => "TicketStatusShouldBeInProgress";
}