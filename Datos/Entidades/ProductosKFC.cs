using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class ProductosKFC
    {
        public int id_plato { get; set; }
        public string nombre_plato { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string imagen { get; set; }
        public int id_categoria { get; set; }
        public ProductosKFC() { }
        public ProductosKFC(string datoJson)
        {
            JObject data = JObject.Parse(datoJson);
            id_plato = (int)data["id_plato"];
            nombre_plato = (string)data["nombre_plato"];
            descripcion = (string)data["descripcion"];
            precio = (double)data["precio"];
            imagen = (string)data["imagen"];
            id_categoria = (int)data["id_categoria"];
        }
    }
}
