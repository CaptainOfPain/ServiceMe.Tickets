using MongoDB.Driver;
using PlaygroundShared.Configurations;
using PlaygroundShared.Infrastructure.MongoDb.Repositories;
using ServiceMe.Tickets.Infrastructure.Persistence.Users;

namespace ServiceMe.Tickets.Infrastructure.MongoDb.Users;

public class UserEventMongoRepository : GenericMongoEventRepository<UserEventEntity>
{
    public UserEventMongoRepository(IMongoClient mongoClient, IMongoDbConfiguration mongoDbConfiguration) : base(mongoClient, mongoDbConfiguration)
    {
    }
}