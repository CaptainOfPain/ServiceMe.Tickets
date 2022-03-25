using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class NewStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public NewStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.New;

    public string Message => "TicketStatusShouldBeNew";
}