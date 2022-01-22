using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Exceptions;
using ServiceMe.Tickets.Application.Users.Mappings;
using ServiceMe.Tickets.Domain.Users.Repositories;

namespace ServiceMe.Tickets.Application.Users.Commands.Handlers;

public class UpdateUserRolesCommandHandler : ICommandHandler<UpdateUserRolesCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserRolesCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    public async Task HandleAsync(UpdateUserRolesCommand command)
    {
        var user = await _userRepository.GetAsync(command.Id);
        if (user == null)
        {
            throw new BusinessLogicException("UserNotFound");
        }
        
        user.ReplaceRoles(command.ToUserRolesData());

        await _userRepository.PersistAsync(user);
    }
}