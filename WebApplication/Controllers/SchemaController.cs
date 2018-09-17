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
    [RoutePrefix("api/schema")]
    public class SchemaController : ApiController
    {
        public ISchema _schema { get; set; }

        public SchemaController(ISchema schema)
        {
            _schema = schema;
        }

        [HttpGet]
        [Route("getalltable")]
        private Response GetAllTableFromDatabase()
        {
            return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = _schema.GetAllTablesDataBase() };
        }


        [HttpGet]
        [Route("getallcolumbytable")]
        private Response GetAllColumByTable(string table)
        {
            return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = _schema.GetAllColumDataBase(table) };
        }

        [HttpGet]
        [Route("getallcolumkeybytable")]
        private Response GetAllColumKeyByTable(string table)
        {
            return new Response() { CodHttp = HttpStatusCode.OK.GetHashCode(), ObjectResponse = _schema.GetAllColumKey(table) };
        }
    }
}
