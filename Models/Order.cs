using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TableauxApi.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("totalAmount")]
        public int totalAmount { get; set; }

        [BsonElement("currency")]
        public string currency { get; set; }

        [BsonElement("products")]
        public Tableau[] products { get; set; }

        [BsonElement("user")]
        public User user{ get; set; }

        [BsonElement("format")]
        public Format format { get; set; }   
    }
    public class Format
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name;
        public int price;
    }
    
}
