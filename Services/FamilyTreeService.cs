using WebApi1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApi1.Services
{
    public class FamilyTreeService
    {
        private readonly IMongoCollection<Member> _membersCollection;

        public FamilyTreeService(IOptions<FamilyTreeDatabaseSettings> familyTreeDatabaseSettings)
        {
            var mongoClient = new MongoClient(familyTreeDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(familyTreeDatabaseSettings.Value.Database);
            _membersCollection = mongoDatabase.GetCollection<Member>(familyTreeDatabaseSettings.Value.MemberCollectionName);
        }

        public async Task<List<Member>> GetAsync() => await _membersCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Member _member)=>await _membersCollection.InsertOneAsync(_member);
    }
}
