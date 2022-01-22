using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace ServiceMe.Tickets.Application.Users.Commands;

public class UpdateUserCommand : ICommand
{
    public AggregateId Id { get; }
    public string UserName { get; }
    public string Email { get; }
    public string? FirstName { get; }
    public string? LastName { get; }

    public UpdateUserCommand(AggregateId id, string userName, string email, string? firstName, string? lastName)
    {
        Id = id;
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}