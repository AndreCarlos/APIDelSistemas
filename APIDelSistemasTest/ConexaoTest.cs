using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using APIDelSistemas.DataAccess;
using APIDelSistemas.Entities;

namespace APIDelSistemasTest
{
    [TestClass]
    public class ConexaoTest
    {
        [TestMethod]
        public void Testar_Conexao_MongoDB()
        {
            var conexao = new Conexao();
            conexao.ConexaoMongoDB();
        }
    }
}