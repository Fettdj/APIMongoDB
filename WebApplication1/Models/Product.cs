using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Product
    {
        internal int Description;

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime ExpotyDate { get; set; }
        public string Category { get; set; }
    }
}
