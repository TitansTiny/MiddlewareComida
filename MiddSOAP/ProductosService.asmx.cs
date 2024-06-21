using Datos.DTO;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MiddSOAP
{
    /// <summary>
    /// Summary description for ProductosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductosService : System.Web.Services.WebService
    {

        private MiddlewareProductos middleware = new MiddlewareProductos();

        [WebMethod]
        public List<DTOProductos> ListarProductos()
        {
            return middleware.ListaProductosREST();
        }

        [WebMethod]
        public string AgregarProducto(DTOProductos producto)
        {
            return middleware.AddProducto(producto);
        }

        [WebMethod]
        public string ActualizarProducto(DTOProductos producto)
        {
            return middleware.ActualizarProducto(producto);
        }

        [WebMethod]
        public string EliminarProducto(DTOProductos producto)
        {
            return middleware.EliminarProducto(producto);
        }

        [WebMethod]
        public List<DTOProductos> BuscarProductoPorNombre(string nombre)
        {
            return middleware.FindByNombre(nombre);
        }
    }
}
