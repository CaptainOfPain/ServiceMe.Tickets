using PlaygroundShared.Domain.Domain;
using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Domain.Users.Repositories;

public interface IUserRepository : IAggregateRepository<User>
{
    
}