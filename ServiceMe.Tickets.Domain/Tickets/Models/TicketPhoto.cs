namespace ServiceMe.Tickets.Domain.Tickets.Models;

public class TicketPhoto
{
    public Guid Id { get; private set; }
    public string Url { get; private set; }
    public string Name { get; private set; }

    internal TicketPhoto(Guid id, string url, string name)
    {
        Id = id;
        Url = url;
        Name = name;
    }

    private TicketPhoto()
    {
        
    }
}