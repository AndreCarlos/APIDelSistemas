using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace APIDelSistemas.Entities
{
    public sealed class Usuario
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        [BsonElement("login")]
        public string login { get; set; }

        [BsonElement("senha")]
        public string senha { get; set; }

        [BsonElement("cpf")]
        public string cpf { get; set; }

        [BsonElement("nome")]
        public string nome { get; set; }

        [BsonElement("data_nascimento")]
        public DateTime data_nascimento { get; set; }

        [BsonElement("sexo")]
        public string sexo { get; set; }

        [BsonElement("cidade")]
        public string cidade { get; set; }

        [BsonElement("estado")]
        public string estado { get; set; }

        [BsonElement("pais")]
        public string pais { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("tipo")]
        public string tipo { get; set; }
    }
}
