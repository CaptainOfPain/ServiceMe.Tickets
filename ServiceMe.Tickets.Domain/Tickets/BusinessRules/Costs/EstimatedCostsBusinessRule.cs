using PlaygroundShared.Domain.BusinessRules;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Costs;

public class EstimatedCostsBusinessRule : IBusinessRule
{
    private readonly decimal _estimatedCosts;

    public EstimatedCostsBusinessRule(decimal estimatedCosts)
    {
        _estimatedCosts = estimatedCosts;
    }

    public bool IsBroken()
        => _estimatedCosts < 0;

    public string Message => "EstimatedCostShouldBeGreaterThanZero";
}