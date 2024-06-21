using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MidREST.Controllers
{
    public class ProductosController : ApiController
    {
        MiddlewareProductos midProductos = new MiddlewareProductos();
        // GET: Productos
        public IHttpActionResult Get()
        {
            return Ok(midProductos.ListaProductosREST());
        }
        public IHttpActionResult Get(string nombre)
        {
            return Ok(midProductos.FindByNombre(nombre));
        }
    }
}