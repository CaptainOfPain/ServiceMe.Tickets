using PlaygroundShared.Infrastructure.MongoDb.Attribute;
using PlaygroundShared.Infrastructure.MongoDb.Entities;

namespace ServiceMe.Tickets.Infrastructure.Persistence.Users;

[MongoCollection("Users")]
public class UserEntity : BaseMongoEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<UserRoleEntity> UserRoles { get; set; }
}