using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class ReceivedStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public ReceivedStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Received;

    public string Message => "TicketStatusShouldBeReceived";
}