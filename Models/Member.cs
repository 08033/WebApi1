using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi1.Models
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        [BsonElement("DOB")]
        public string DateOfBirth { get; set; } = null!;
        public string NationalId { get; set; } = null!;

        public string Spouse { get; set; } = null!;
        public string Parent { get; set; } = null!;
    }
}
