using APIDelSistemas.DataAccess.Repository;
using APIDelSistemas.Entities.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

using System;

namespace APIDelSistemasTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        [TestMethod]
        public void Testar_Metodo_Get()
        {
            //var usuarioRepository = new UsuarioRepository();

            IUsuarioRepository _usuarios = new UsuarioRepository();
            var retorno = _usuarios.GetAll();

            foreach (var item in retorno)
            {
                ObjectId _id = item._Id;
                string login = item.login;
                string senha = item.senha;
                string cpf = item.cpf;
                string nome = item.nome;
                DateTime data_nascimento = item.data_nascimento;
                string sexo = item.sexo;
                string cidade = item.cidade;
                string estado = item.estado;
                string pais = item.pais;
                string email = item.email;
                string tipo = item.tipo;
            }
        }
    }
}
