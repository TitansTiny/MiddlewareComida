using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos.Entidades
{
    public class ProductosPizzeria
    {
        public int PizzaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public ProductosPizzeria() { }
        public ProductosPizzeria(string datoJson)
        {
            JObject data = JObject.Parse(datoJson);
            PizzaID = (int)data["PizzaID"];
            Nombre = (string)data["Nombre"];
            Descripcion = (string)data["Descripcion"];
            Imagen = (string)data["Imagen"];
        }
    }
}
