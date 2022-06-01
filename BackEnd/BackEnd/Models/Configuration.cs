using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BackEnd.Models
{
    public class Configuration
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("cantidadBloques")]
        public string CantidadBloques { get; set; }

        [BsonElement("variableSistema")]
        public string VariableSistema { get; set; }

        [BsonElement("tipoArchivo")]
        public string TipoArchivo { get; set; }

    }
}
