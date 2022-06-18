using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WpfAppMVVMMongoDB.Models
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}
