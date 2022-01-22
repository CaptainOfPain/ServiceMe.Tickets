using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Exceptions;
using ServiceMe.Tickets.Application.Users.Mappings;
using ServiceMe.Tickets.Domain.Users.Factories;
using ServiceMe.Tickets.Domain.Users.Repositories;

namespace ServiceMe.Tickets.Application.Users.Commands.Handlers;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;

    public CreateUserCommandHandler(IUserRepository userRepository, IUserFactory userFactory)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _userFactory = userFactory ?? throw new ArgumentNullException(nameof(userFactory));
    }
    
    public async Task HandleAsync(CreateUserCommand command)
    {
        var user = await _userRepository.GetAsync(command.Id);
        if (user != null)
        {
            throw new BusinessLogicException("UserAlreadyExists");
        }

        user = _userFactory.Create(command.ToUserDataStructure());

        await _userRepository.PersistAsync(user);
    }
}