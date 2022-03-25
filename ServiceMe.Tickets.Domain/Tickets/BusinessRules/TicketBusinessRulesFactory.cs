using PlaygroundShared.Domain.BusinessRules;
using PlaygroundShared.Domain.Domain;
using ServiceMe.Tickets.Domain.Tickets.BusinessRules.Costs;
using ServiceMe.Tickets.Domain.Tickets.BusinessRules.Others;
using ServiceMe.Tickets.Domain.Tickets.BusinessRules.Statuses;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules;

public class TicketBusinessRulesFactory : ITicketBusinessRulesFactory
{
    public IBusinessRuleValidatorBuilder PrepareSetTechnicianBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new NewStatusBusinessRule(status))
            .Or(new VerificationStatusBusinessRule(status))
            .Or(new AcceptedStatusBusinessRule(status))
            .Or(new WaitingForDeliveryStatusBusinessRule(status))
            .Or(new DeliveredStatusBusinessRule(status))
            .Or(new EstimatingCostsStatusBusinessRule(status))
            .Or(new CostsEstimatedStatusBusinessRule(status))
            .Or(new CostsAcceptanceStatusBusinessRule(status))
            .Or(new CostsAcceptedStatusBusinessRule(status))
            .Or(new CostsRejectedStatusBusinessRule(status))
            .Or(new InProgressStatusBusinessRule(status))
            .Or(new FixedStatusBusinessRule(status))
            .Or(new ReadyForPickupStatusBusinessRule(status))
            .Or(new ReceivedStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetInVerificationBusinessRules(TicketStatus status, AggregateId? technicianId)
        => new BusinessRuleValidatorBuilder(new NewStatusBusinessRule(status))
            .And(new TechnicianNotNullBusinessRule(technicianId));

    public IBusinessRuleValidatorBuilder PrepareSetAcceptedBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new VerificationStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetWaitingForDeliveryBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new AcceptedStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetDeliveredBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new WaitingForDeliveryStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetEstimatingCostsBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new DeliveredStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetCostsEstimatedBusinessRules(TicketStatus status, decimal estimatedCost)
        => new BusinessRuleValidatorBuilder(new EstimatingCostsStatusBusinessRule(status))
            .And(new EstimatedCostsBusinessRule(estimatedCost));

    public IBusinessRuleValidatorBuilder PrepareSetCostsAcceptanceBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new CostsEstimatedStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetCostsAcceptedBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new CostsAcceptanceStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetCostsRejectedBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new CostsAcceptanceStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetInProgressBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new CostsAcceptedStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetFixedBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new InProgressStatusBusinessRule(status));
    
    public IBusinessRuleValidatorBuilder PrepareSetReadyForPickupBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new FixedStatusBusinessRule(status)).Or(new CostsRejectedStatusBusinessRule(status));

    public IBusinessRuleValidatorBuilder PrepareSetReceivedBusinessRules(TicketStatus status)
        => new BusinessRuleValidatorBuilder(new ReadyForPickupStatusBusinessRule(status));

}