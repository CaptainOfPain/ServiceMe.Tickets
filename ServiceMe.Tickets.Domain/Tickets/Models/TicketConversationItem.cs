namespace ServiceMe.Tickets.Domain.Tickets.Models;

public class TicketConversationItem
{
    public Guid Id { get; private set; }
    public bool FromCustomer { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedDate { get; private set; }
    

    internal TicketConversationItem(Guid id, bool fromCustomer, string message, DateTime createdDate)
    {
        Id = id;
        FromCustomer = fromCustomer;
        Message = message;
        CreatedDate = createdDate;
    }

    private TicketConversationItem()
    {
        
    }
}