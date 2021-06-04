using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCwithMongoDBCRUD.Models
{
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId AlbumId { get; set; }

        [BsonElement("GodinaIzdavanja")]
        [Required]
        public string GodinaIzdavanja { get; set; }

        [BsonElement("Naziv")]
        public string Naziv { get; set; }
        [BsonElement("Band")]
        public string Band { get; set; }
        [BsonElement("Izdavacka Kuca")]
        public string Izdavacka { get; set; }

    }
}
