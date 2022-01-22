using PlaygroundShared.Application.CQRS;
using PlaygroundShared.IntercontextCommunication;
using ServiceMe.Tickets.Application.Users.Commands;
using ServiceMe.Tickets.IntercontextCommunication.Users.Messages;

namespace ServiceMe.Tickets.IntercontextCommunication.Users.Handlers;

public class UserRolesUpdatedEventHandler : IMessageHandler<UserRolesUpdatedEvent>
{
    private readonly ICommandQueryDispatcherDecorator _dispatcher;

    public UserRolesUpdatedEventHandler(ICommandQueryDispatcherDecorator dispatcher)
    {
        _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
    }

    public async Task HandleMessageAsync(UserRolesUpdatedEvent message, CancellationToken cancellationToken)
    {
        await _dispatcher.DispatchAsync(new UpdateUserRolesCommand(message.Id, message.UserRoles.Select(x => new UserRoleCommandData(x.Id, x.UserRole)).ToList()));
    }
}