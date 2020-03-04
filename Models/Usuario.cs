using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace LoginBC.Models {
    public class Usuario {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
