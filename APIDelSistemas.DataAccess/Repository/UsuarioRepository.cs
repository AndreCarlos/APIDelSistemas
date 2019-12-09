using APIDelSistemas.Entities;
using APIDelSistemas.Entities.Repository;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using System;
using System.Collections.Generic;
using System.Configuration;

namespace APIDelSistemas.DataAccess.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly string connectionStringMongo = ConfigurationManager.AppSettings["connectionString"];
        private static readonly string databaseNameMongo = ConfigurationManager.AppSettings["databaseName"];
        private static readonly string collectionName = "usuario";

        protected static MongoClient client = new MongoClient(connectionStringMongo);
        protected static IMongoDatabase database = client.GetDatabase(databaseNameMongo);

        public bool Add(Usuario usuario)
        {
            var usuarioCollection = database.GetCollection<Usuario>(collectionName);

            try
            {
                var _usuario = new Usuario() {
                    _Id = ObjectId.GenerateNewId(),
                    login = usuario.login,
                    senha = usuario.senha,
                    cpf = usuario.cpf,
                    nome = usuario.nome,
                    data_nascimento = usuario.data_nascimento,
                    sexo = usuario.sexo,
                    cidade = usuario.cidade,
                    estado = usuario.estado,
                    pais = usuario.pais,
                    email = usuario.email,
                    tipo = usuario.tipo
                };

                usuarioCollection.InsertOneAsync(_usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

         public bool Modify(ObjectId _id, Usuario usuario)
        {
            try
            {
                var usuarioCollection = database.GetCollection<Usuario>(collectionName);

                var update = Builders<Usuario>.Update
                                              .Set(u => u.login, usuario.login)
                                              .Set(u => u.senha, usuario.senha)
                                              .Set(u => u.cpf, usuario.cpf)
                                              .Set(u => u.nome, usuario.nome)
                                              .Set(u => u.data_nascimento, usuario.data_nascimento)
                                              .Set(u => u.sexo, usuario.sexo)
                                              .Set(u => u.cidade, usuario.cidade)
                                              .Set(u => u.estado, usuario.estado)
                                              .Set(u => u.pais, usuario.pais)
                                              .Set(u => u.email, usuario.email)
                                              .Set(u => u.tipo, usuario.tipo);               

                var query = Builders<Usuario>.Filter.Eq(p => p._Id, _id); 
                usuarioCollection.UpdateOneAsync(query, update).Wait();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(ObjectId _id)
        {
            try
            {
                var usuario = database.GetCollection<Usuario>(collectionName);
                usuario.DeleteOne(user => user._Id == _id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable <Usuario> GetById(ObjectId _id)
        {
            var usuario = database.GetCollection<Usuario>(collectionName);
            var query = from user in usuario.AsQueryable<Usuario>()
                        where user._Id == _id
                        select user;
            return query;
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarioLista = database.GetCollection<Usuario>(collectionName);
            var query = from usuario in usuarioLista.AsQueryable<Usuario>()
                        select usuario;
            return query;
        }

        //public IEnumerable GetFiltered(Expression<Func<Usuario, bool>> filter)
        //{
        //    var name = User.Identity.Name;
        //    ParameterExpression param = Expression.Parameter(typeof(Usuario), "h");
        //    Expression boby = Expression.Equal(Expression.PropertyOrField(param, "Correo"),
        //          Expression.Constant(name, typeof(string)));
        //    Expression<Func<Usuario, bool>> filter = Expression.Lambda<Func<Usuario, bool>>(boby, param);

        //    var usuario = _utHojas.UsuariosRepository.Get(filter).FirstOrDefault();
        //}
    }
}
