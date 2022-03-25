using PlaygroundShared.Domain.BusinessRules;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules.Costs;

public class CostsBusinessRule : IBusinessRule
{
    private readonly decimal _costs;

    public CostsBusinessRule(decimal costs)
    {
        _costs = costs;
    }

    public bool IsBroken()
        => _costs < 0;

    public string Message => "CostShouldBeGreaterThanZero";
}