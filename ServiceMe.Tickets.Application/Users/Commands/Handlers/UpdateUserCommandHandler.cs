using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Exceptions;
using ServiceMe.Tickets.Application.Users.Mappings;
using ServiceMe.Tickets.Domain.Users.Repositories;

namespace ServiceMe.Tickets.Application.Users.Commands.Handlers;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    public async Task HandleAsync(UpdateUserCommand command)
    {
        var user = await _userRepository.GetAsync(command.Id);
        if (user == null)
        {
            throw new BusinessLogicException("UserNotFound");
        }
        
        user.Update(command.ToUserDataStructure());

        await _userRepository.PersistAsync(user);
    }
}