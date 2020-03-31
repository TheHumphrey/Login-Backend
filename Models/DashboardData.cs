using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBC.Models
{
    public class DashboardData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int LucroBruto { get; set; }
        public int LucroDesconto { get; set; }

        public int TempoEntrega { get; set; }
        public int TempoRota { get; set; }
        public int TempoSemanal { get; set; }

        public int KmDiario { get; set; }
        public int KmSemanal { get; set; }
        public int KmMensal { get; set; }

        public int CustoDiario { get; set; }
        public int CustoSemanal { get; set; }
        public int CustoMensal { get; set; }

        public int FrotaDisponivel { get; set; }
        public int FrotaManutencao { get; set; }
        public int FrotaIndisponivel { get; set; }

    }
}
