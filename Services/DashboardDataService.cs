using System;
using MongoDB.Driver;
using LoginBC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoginBC.Services {
    public class DashboardDataService {
        private readonly IMongoCollection<Data> _dashboardData;

        public DashboardDataService() {
            var client = new MongoClient("mongodb://localhost:27016");
            var database = client.GetDatabase("teste");
            _dashboardData = database.GetCollection<Data>("Data");
        }

        public void Create(Data user) => _dashboardData.InsertOne(user);

        public Data Get() => _dashboardData.Find(u => true).FirstOrDefault();
    }
}
