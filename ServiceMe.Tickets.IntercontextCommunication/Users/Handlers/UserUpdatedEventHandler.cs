using PlaygroundShared.Application.CQRS;
using PlaygroundShared.IntercontextCommunication;
using ServiceMe.Tickets.Application.Users.Commands;
using ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Handlers;

public class UserUpdatedEventHandler : IMessageHandler<UserUpdatedEvent>
{
    private readonly ICommandQueryDispatcherDecorator _dispatcher;

    public UserUpdatedEventHandler(ICommandQueryDispatcherDecorator dispatcher)
    {
        _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
    }
    
    public async Task HandleMessageAsync(UserUpdatedEvent message, CancellationToken cancellationToken)
    {
        await _dispatcher.DispatchAsync(new UpdateUserCommand(message.Id, message.UserName, message.Email,
            message.FirstName, message.LastName));
    }
}