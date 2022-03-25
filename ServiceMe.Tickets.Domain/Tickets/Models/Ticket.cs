using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using PlaygroundShared.Domain.Exceptions;
using ServiceMe.Tickets.Domain.Tickets.BusinessRules;
using ServiceMe.Tickets.Domain.Tickets.DataStructures;
using ServiceMe.Tickets.Domain.Tickets.Events;

namespace ServiceMe.Tickets.Domain.Tickets.Models;

public class Ticket : BaseAggregateRoot
{
    private readonly ITicketBusinessRulesFactory _businessRulesFactory;
    public AggregateId CustomerId { get; private set; }
    public AggregateId? TechnicianId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<TicketPhoto> Photos { get; private set; }
    public TicketStatus Status { get; private set; }
    public string? DeviceName { get; private set; }
    public TicketType Type { get; private set; }
    public IEnumerable<TicketConversationItem> Conversation { get; private set; }
    public decimal? EstimatedCost { get; private set; }
    public decimal? Cost { get; private set; }
    public DateTime? EstimatedDate { get; private set; }
    public DateTime? ReadyForPickupDate { get; private set; }
    public DateTime? ReceivedDate { get; private set; }
    public DateTime? RejectedDate { get; private set; }
    
    private Ticket()
    {
        _businessRulesFactory = new TicketBusinessRulesFactory();
    }
    
    internal Ticket(AggregateId id, IDomainEventsManager domainEventsManager, TicketDataStructure ticketDataStructure) : base(id, domainEventsManager)
    {
        _businessRulesFactory = new TicketBusinessRulesFactory();
        ApplyFromDataStructure(ticketDataStructure);
        SetStatusNew();
        
        DomainEvent(TicketCreatedEvent.Create(this));
    }

    public void Update(TicketDataStructure ticketDataStructure)
    {
        ApplyFromDataStructure(ticketDataStructure);
        
        DomainEvent(TicketUpdatedEvent.Create(this));
    }

    public void SetTechnician(AggregateId technicianId)
    {
        var businessRule = _businessRulesFactory.PrepareSetTechnicianBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }
        
        TechnicianId = technicianId;
        
        DomainEvent(TicketTechnicianAddedEvent.Create(this));
    }

    public void SetInVerification()
    {
        var businessRule = _businessRulesFactory.PrepareSetInVerificationBusinessRules(Status, TechnicianId);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.Verification;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetAccepted()
    {
        var businessRule = _businessRulesFactory.PrepareSetAcceptedBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }
        
        var oldStatus = Status;
        Status = TicketStatus.Accepted;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetRejected()
    {
        var oldStatus = Status;
        Status = TicketStatus.Rejected;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetWaitingForDelivery()
    {
        var businessRule = _businessRulesFactory.PrepareSetWaitingForDeliveryBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }
        
        var oldStatus = Status;
        Status = TicketStatus.WaitingForDelivery;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }
    
    public void SetDelivered()
    {
        var businessRule = _businessRulesFactory.PrepareSetDeliveredBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.Delivered;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void StartEstimatingCosts()
    {
        var businessRule = _businessRulesFactory.PrepareSetEstimatingCostsBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.EstimatingCosts;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void Estimate(decimal estimatedCost, DateTime estimatedDate)
    {
        var businessRule = _businessRulesFactory.PrepareSetCostsEstimatedBusinessRules(Status, estimatedCost);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }
        
        SetStatusCostEstimated();
        EstimatedCost = estimatedCost;
        EstimatedDate = estimatedDate;
        
        DomainEvent(TicketEstimatedEvent.Create(this));
    }

    public void SetCostAcceptanceStatus()
    {
        var businessRule = _businessRulesFactory.PrepareSetCostsAcceptanceBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.CostsAcceptance;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void AcceptEstimatedCost()
    {
        var businessRule = _businessRulesFactory.PrepareSetCostsAcceptedBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.CostsAccepted;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void RejectEstimatedCost()
    {
        var businessRule = _businessRulesFactory.PrepareSetCostsRejectedBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.CostsRejected;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetInProgress()
    {
        var businessRule = _businessRulesFactory.PrepareSetInProgressBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.InProgress;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetFixed()
    {
        var businessRule = _businessRulesFactory.PrepareSetFixedBusinessRules(Status);
        var brokenResult = businessRule.IsBroken();

        if (brokenResult.Result)
        {
            throw new BusinessLogicException(String.Join(", ", brokenResult.Messages));
        }

        var oldStatus = Status;
        Status = TicketStatus.Fixed;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    public void SetReadyForPickup(decimal cost)
    {
        
    }

    private void SetStatusCostEstimated()
    {
        var oldStatus = Status;
        Status = TicketStatus.CostsEstimated;
        
        DomainEvent(TicketStatusChangedEvent.Create(this, oldStatus));
    }

    private void ApplyFromDataStructure(TicketDataStructure ticketDataStructure)
    {
        CustomerId = ticketDataStructure.CustomerId;
        Title = ticketDataStructure.Title;
        Description = ticketDataStructure.Description;
        DeviceName = ticketDataStructure.DeviceName;
        Type = ticketDataStructure.Type;
    }

    private void SetStatusNew()
    {
        Status = TicketStatus.New;
    }
}