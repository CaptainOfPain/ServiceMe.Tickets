using PlaygroundShared.Domain.BusinessRules;
using PlaygroundShared.Domain.Domain;
using ServiceMe.Tickets.Domain.Tickets.Models;

namespace ServiceMe.Tickets.Domain.Tickets.BusinessRules;

public interface ITicketBusinessRulesFactory
{
    IBusinessRuleValidatorBuilder PrepareSetTechnicianBusinessRules(TicketStatus status);
    IBusinessRuleValidatorBuilder PrepareSetInVerificationBusinessRules(TicketStatus status, AggregateId? technicianId);
    IBusinessRuleValidatorBuilder PrepareSetAcceptedBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetWaitingForDeliveryBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetDeliveredBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetEstimatingCostsBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetCostsEstimatedBusinessRules(TicketStatus status, decimal estimatedCost);
    public IBusinessRuleValidatorBuilder PrepareSetCostsAcceptanceBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetCostsAcceptedBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetCostsRejectedBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetInProgressBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetFixedBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetReadyForPickupBusinessRules(TicketStatus status);
    public IBusinessRuleValidatorBuilder PrepareSetReceivedBusinessRules(TicketStatus status);
}