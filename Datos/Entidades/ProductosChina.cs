using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class ProductosChina
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int id_categoria { get; set; }
        public string prod_img { get; set; }
        public ProductosChina() { }
        public ProductosChina(string datoJson)
        {
            JObject data = JObject.Parse(datoJson);
            id_producto = (int)data["id_producto"];
            nombre = (string)data["nombre"];
            descripcion = (string)data["descripcion"];
            precio = (double)data["precio"];
            id_categoria = (int)data["id_categoria"];
            prod_img = (string)data["prod_img"];
        }
    }
}
