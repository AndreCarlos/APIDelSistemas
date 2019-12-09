using MongoDB.Driver;

using System;
using System.Configuration;


namespace APIDelSistemas.DataAccess
{
    public sealed class Conexao
    {
        private static readonly string connectionStringMongo = ConfigurationManager.AppSettings["connectionString"];
        private static readonly string databaseNameMongo = ConfigurationManager.AppSettings["databaseName"];

        public Conexao() { }

        public void ConexaoMongoDB()
        {
            try
            {
                MongoClient client = new MongoClient(connectionStringMongo);
                var database = client.GetDatabase(databaseNameMongo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
