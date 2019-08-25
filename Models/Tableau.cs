using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TableauxApi.Models
{
    public class Tableau
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("titre")]
        public string titre { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("categorie")]
        public string categorie { get; set; }

        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }

        
    }

}
