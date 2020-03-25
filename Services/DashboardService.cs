using System;
using MongoDB.Driver;
using LoginBC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoginBC.Services {
    public class DashboardService {
        private readonly IMongoCollection<Dashboard> _dashboard;

        public DashboardService() {
            var client = new MongoClient("189.63.58.27:27016");
            var database = client.GetDatabase("teste");
            _dashboard = database.GetCollection<Dashboard>("dashboard");
        }

        public void Create(Dashboard data) => _dashboard.InsertOne(data);

        public Dashboard Get() => _dashboard.Find(u => true).FirstOrDefault();

        public Dashboard Get(string name) => _dashboard.Find(d => d.Email == name).FirstOrDefault();

        public void Update(string email, Dashboard user) {


            Expression<Func<Dashboard, bool>> filter = x => x.Email == email;

            _dashboard.ReplaceOneAsync(filter, user);
        }
    }
}