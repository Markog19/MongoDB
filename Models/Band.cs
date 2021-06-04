using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCwithMongoDBCRUD.Models
{
    public class Band 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BandId { get; set; }
        [BsonElement("Ime")]
        [Required]
        public string ime { get; set; }
        


    }
}