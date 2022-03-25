using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class AcceptedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public AcceptedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Accepted;

    public string Message => "TicketStatusShouldBeAccepted";
}