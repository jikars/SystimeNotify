using BussinesLogic.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/config")]
    public class ConfigController : ApiController
    {
        public IConfig _config { get; set; }
        
        public ConfigController(IConfig config)
        {
            _config = config;
        }

        [HttpPost]
        public Response AddTableSupport(TableSupport tableSupport)
        {
            //TODO debe ir una validacion por modelos y una respuesta respectiva y se deben crear los mensajes
            if (_config.AddConfigTable(tableSupport))
            {
                return new Response() { CodHttp = HttpStatusCode.Created.GetHashCode(), ObjectResponse = tableSupport };
            }
            else
            {
                return new Response() { CodHttp = HttpStatusCode.BadRequest.GetHashCode(), ObjectResponse = null };
            }
        }

        [HttpDelete]
        public Response RemoveTableSupport(String Table)
        {
            //TODO debe ir una validacion por modelos y una respuesta respectiva y se deben crear los mensajes
            if (_config.RemoveConfigTableByName(Table))
            {
                return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = true };
            }
            else
            {
                return new Response() { CodHttp = HttpStatusCode.BadRequest.GetHashCode(), ObjectResponse = false };
            }
        }


        [HttpGet]
        public Response GetAllTablSupport()
        {
            //TODO debe ir una validacion por modelos y una respuesta respectiva y se deben crear los mensajes
            return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = _config.GetAllTeableSupport() };
        }
    }
}
