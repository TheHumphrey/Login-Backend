using LoginBC.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LoginBC.Services {
    public class UsuarioService {

        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioService() {
            var client = new MongoClient("mongodb://localhost:27016");
            var database = client.GetDatabase("teste");
            _usuario = database.GetCollection<Usuario>("usuarios");
        }

        public void Create(Usuario user) => _usuario.InsertOne(user);

        public List<Usuario> Get() => _usuario.Find(u => true).ToList();

        public Usuario Get(string email) {
            return _usuario.Find(u => u.Email == email).FirstOrDefault();
        }

        public TypeAuth ValidateLogin(string email, string senha) {
            var usuario = _usuario.Find(u => u.Email == email).FirstOrDefault();

            if(usuario != null) {
                if(usuario.Senha == senha) {
                    return TypeAuth.Ok;
                } else {
                    return TypeAuth.Unauthorized;
                }
            }else {
                return TypeAuth.NotFound;
            }
        }
    }
}
