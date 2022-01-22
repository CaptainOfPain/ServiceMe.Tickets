namespace ServiceMe.Tickets.Domain.Tickets.Models;

public enum TicketStatus
{
    New = 0,
    Verification = 10,
    Accepted = 20,
    WaitingForDelivery = 30,
    Delivered = 40,
    EstimatingCosts = 50,
    CostsEstimated = 60,
    CostsAcceptance = 80,
    CostsAccepted = 90,
    CostsRejected = 100,
    InProgress = 110,
    Fixed = 120,
    ReadyForPickup = 130,
    Received = 140,
    Rejected = 150
}