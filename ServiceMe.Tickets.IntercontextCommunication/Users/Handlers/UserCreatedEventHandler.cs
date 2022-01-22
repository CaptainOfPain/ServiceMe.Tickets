using PlaygroundShared.Application.CQRS;
using PlaygroundShared.IntercontextCommunication;
using ServiceMe.Tickets.Application.Users.Commands;
using ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Handlers;

public class UserCreatedEventHandler : IMessageHandler<UserCreatedEvent>
{
    private readonly ICommandQueryDispatcherDecorator _dispatcher;

    public UserCreatedEventHandler(ICommandQueryDispatcherDecorator dispatcher)
    {
        _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
    }
    
    public async Task HandleMessageAsync(UserCreatedEvent message, CancellationToken cancellationToken)
    {
        await _dispatcher.DispatchAsync(new CreateUserCommand(message.Id, message.UserName, message.Email,
            message.FirstName, message.LastName));
    }
}