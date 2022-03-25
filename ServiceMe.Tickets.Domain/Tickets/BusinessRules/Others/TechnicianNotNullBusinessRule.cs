using PlaygroundShared.Domain.BusinessRules;
using PlaygroundShared.Domain.Domain;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Others;

public class TechnicianNotNullBusinessRule : IBusinessRule
{
    private readonly AggregateId? _technicianId;

    public TechnicianNotNullBusinessRule(AggregateId? technicianId)
    {
        _technicianId = technicianId;
    }

    public bool IsBroken()
        => _technicianId == null || _technicianId == new AggregateId();

    public string Message => "TechnicianMustBeSelected";
}