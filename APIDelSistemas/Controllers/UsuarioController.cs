using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MongoDB.Bson;

using APIDelSistemas.Entities;
using APIDelSistemas.Entities.Repository;
using APIDelSistemas.DataAccess.Repository;

namespace APIDelSistemas.Controllers
{
    public class UsuarioController : ApiController
    {
        private static readonly IUsuarioRepository _usuarios = new UsuarioRepository();

        [HttpGet]
        [Route("usuarios/GetAll")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _usuarios.GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("usuario/{id:ObjectId}")]
        public HttpResponseMessage GetById(ObjectId _Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _usuarios.GetById(_Id));
            }
            catch (Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("usuario/{id:ObjectId}")]
        public HttpResponseMessage DeleteById(ObjectId _Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _usuarios.Remove(_Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("usuario")]
        public HttpResponseMessage Post(Usuario usuario)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _usuarios.Add(usuario));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("usuario/{id:ObjectId}")]
        public HttpResponseMessage Put(ObjectId _Id, Usuario usuario)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _usuarios.Modify(_Id, usuario));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
