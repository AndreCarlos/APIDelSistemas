using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using APIDelSistemas.DataAccess;
using APIDelSistemas.Entities;
using APIDelSistemas.DataAccess.Repository;
using System.Collections.Generic;

using MongoDB.Bson;

namespace APIDelSistemasTest
{
    [TestClass]
    public class UsuarioRepositoryTest
    {
        [TestMethod]
        public void Testar_Metodo_GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var retorno = usuarioRepository.GetAll();

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

        [TestMethod]
        public void Testar_Metodo_GetById()
        {
            var usuarioRepository = new UsuarioRepository();
            var retorno = usuarioRepository.GetById(ObjectId.Parse("5726696670be67d8f42da128"));

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

        [TestMethod]
        public void Testar_Metodo_Remove()
        {
            var usuarioRepository = new UsuarioRepository();
            var retorno = usuarioRepository.Remove(ObjectId.Parse("5726691370be67d8f42da127"));

            Console.WriteLine(retorno);
        }

        [TestMethod]
        public void Testar_Metodo_Add()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = new Usuario();

            usuario.login = "Luxa";
            usuario.senha = "777";
            usuario.cpf = "88888888888";
            usuario.nome = "Luxemburgo da Silva";
            usuario.data_nascimento =  DateTime.Now;
            usuario.sexo = "M";
            usuario.cidade = "Rio de Janeiro";
            usuario.estado = "RJ";
            usuario.pais = "Brasil";
            usuario.email = "luxa@globo.com";
            usuario.tipo = "cliente";

            usuarioRepository.Add(usuario);
        }

        [TestMethod]
        public void Testar_Metodo_Modify()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = new Usuario();

            usuario.login = "Bob";
            usuario.senha = "bob";
            usuario.cpf = "3290841598249";
            usuario.nome = "Roberto Sauro";
            usuario.data_nascimento = DateTime.Now;
            usuario.sexo = "M";
            usuario.cidade = "Rio de Janeiro";
            usuario.estado = "RJ";
            usuario.pais = "Brasil";
            usuario.email = "bob@yahoo.com";
            usuario.tipo = "cliente";

            usuarioRepository.Modify(ObjectId.Parse("57267f8eb1c66312d874f2bc"), usuario);
        }
    }
}