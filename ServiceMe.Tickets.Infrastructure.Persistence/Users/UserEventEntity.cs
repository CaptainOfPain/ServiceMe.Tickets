using PlaygroundShared.Infrastructure.MongoDb.Attribute;
using PlaygroundShared.Infrastructure.MongoDb.Entities;

namespace ServiceMe.Tickets.Infrastructure.Persistence.Users;

[MongoCollection("Users")]
public class UserEventEntity : BaseMongoEventEntity
{
    
}