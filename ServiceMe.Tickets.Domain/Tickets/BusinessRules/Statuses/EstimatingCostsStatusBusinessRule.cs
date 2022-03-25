using PlaygroundShared.Domain.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;

public class EstimatingCostsStatusBusinessRule : IBusinessRule
{
    private readonly TicketStatus _status;

    public EstimatingCostsStatusBusinessRule(TicketStatus status)
    {
        _status = status;
    }

    public bool IsBroken()
        => _status != TicketStatus.EstimatingCosts;

    public string Message => "TicketStatusShouldBeEstimatingCosts";
}