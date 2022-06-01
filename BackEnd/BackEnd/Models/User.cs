using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BackEnd.Models
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("mail")]
        public string Mail { get; set; }

        [BsonElement("birthDay")]
        public string BirthDay { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }

}
