using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBC.Models {
    public class Dashboard {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public int Entregues { get; set; }
        public int NaoEntregues { get; set; }
        public int Andamento { get; set; }
    }
}