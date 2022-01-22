using PlaygroundShared.Domain.Domain;
using ServiceMe.Tickets.Domain.Users.DataStructures;
using ServiceMe.Tickets.Domain.Users.Models;

namespace ServiceMe.Tickets.Domain.Users.Factories;

public interface IUserFactory : IDomainFactory
{
    User Create(UserDataStructure dataStructure);
}