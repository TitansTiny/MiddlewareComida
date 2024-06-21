using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTO
{
    public class DTOProductos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Imagen { get; set; }
        public string Tienda { get; set; }
        public DTOProductos() { }
    }
}
