using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class VerificationStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public VerificationStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.Verification;

    public string Message => "TicketStatusShouldBeVerification";
}