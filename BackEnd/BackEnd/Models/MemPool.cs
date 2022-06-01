using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models
{
    public class MemPool
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("owner")]
        public string Owner { get; set; }

        [BsonElement("typeOfFile")]
        public string TypeOfFile { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("size")]
        public string Size { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("base64")]
        public string Base64 { get; set; }
    }

}
