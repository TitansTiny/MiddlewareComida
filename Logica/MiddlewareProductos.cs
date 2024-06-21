using Datos.DTO;
using Datos.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MiddlewareProductos
    {
        // Listado de productos de la base de datos ventas REST
        public List<ProductosChina> ListarProductosChina()
        {
            string url = "http://localhost:60797/api/Productos";
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(url));
            List<ProductosChina> listaChina = JsonConvert.DeserializeObject<List<ProductosChina>>(get);
            return listaChina;
        }

        // Listado de productos de la base de datos servicios REST
        public List<ProductosPizzeria> ListarProductosPizzeria()
        {
            string url = "http://localhost:51985/api/Pizzas";
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(url));
            List<ProductosPizzeria> listaPizza = JsonConvert.DeserializeObject<List<ProductosPizzeria>>(get);
            return listaPizza;
        }

        public List<ProductosKFC> ListarProductosKFC()
        {
            string url = "http://127.0.0.1:5000/get_platos";
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(url));
            List<ProductosKFC> listaKFC = JsonConvert.DeserializeObject<List<ProductosKFC>>(get);
            return listaKFC;
        }

        public bool InsertarPizza(ProductosPizzeria producto)
        {
            string url = "http://localhost:51985/api/Pizzas";
            string verb = "POST";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool InsertarProductoChina(ProductosChina producto)
        {
            string url = "http://localhost:60797/api/Productos";
            string verb = "POST";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool InsertarProductoKFC(ProductosKFC producto)
        {
            string url = "http://127.0.0.1:5000/insert_platos";
            string verb = "POST";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool ActualizarProductoChina(int id, ProductosChina producto)
        {
            string url = $"http://localhost:60797/api/Productos/{id}";
            string verb = "PUT";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool EliminarProductoChina(int id)
        {
            string url = $"http://localhost:60797/api/Productos/{id}";
            string verb = "DELETE";
            WebClient respuesta = new WebClient();
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, new byte[0]) != null)
                return true;
            return false;
        }

        public bool ActualizarProductoPizzeria(int id, ProductosPizzeria producto)
        {
            string url = $"http://localhost:51985/api/Pizzas/{id}";
            string verb = "PUT";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool EliminarProductoPizzeria(int id)
        {
            string url = $"http://localhost:51985/api/Pizzas/{id}";
            string verb = "DELETE";
            WebClient respuesta = new WebClient();
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, new byte[0]) != null)
                return true;
            return false;
        }

        public bool ActualizarProductoKFC(int id, ProductosKFC producto)
        {
            string url = $"http://127.0.0.1:5000/actualizar_platos/{id}";
            string verb = "PUT";
            WebClient respuesta = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            Byte[] bytes = uTF8Encoding.GetBytes(JsonDatos);
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, bytes) != null)
                return true;
            return false;
        }

        public bool EliminarProductoKFC(int id)
        {
            string url = $"http://127.0.0.1:5000/delete_platos/{id}";
            string verb = "DELETE";
            WebClient respuesta = new WebClient();
            respuesta.Headers.Add("content-type", "application/json");
            if (respuesta.UploadData(url, verb, new byte[0]) != null)
                return true;
            return false;
        }

        // Método para listar todos los productos REST
        public List<DTOProductos> ListaProductosREST()
        {
            List<DTOProductos> listaproductos = new List<DTOProductos>();
            foreach (var item in ListarProductosChina())
            {
                DTOProductos producto = new DTOProductos();
                producto.Id = item.id_producto;
                producto.Name = item.nombre;
                producto.Desc = item.descripcion;
                producto.Imagen = item.prod_img;
                producto.Tienda = "Comida China";
                listaproductos.Add(producto);
            }
            foreach (var item in ListarProductosPizzeria())
            {
                DTOProductos producto = new DTOProductos();
                producto.Id = item.PizzaID;
                producto.Name = item.Nombre;
                producto.Desc = item.Descripcion;
                producto.Imagen = item.Imagen;
                producto.Tienda = "Pizzeria";
                listaproductos.Add(producto);
            }
            foreach (var item in ListarProductosKFC())
            {
                DTOProductos producto = new DTOProductos();
                producto.Id = item.id_plato;
                producto.Name = item.nombre_plato;
                producto.Desc = item.descripcion;
                producto.Imagen = item.imagen;
                producto.Tienda = "KFC";
                listaproductos.Add(producto);
            }
            return listaproductos;
        }

        // Método para agregar un producto
        public string AddProducto(DTOProductos producto)
        {
            if (producto != null)
            {
                if (producto.Tienda.CompareTo("Comida China") == 0)
                {
                    ProductosChina productoNuevo = new ProductosChina
                    {
                        id_producto = producto.Id,
                        nombre = producto.Name,
                        descripcion = producto.Desc,
                        prod_img = producto.Imagen
                    };
                    if (InsertarProductoChina(productoNuevo))
                        return "Insertado en Comida China";
                }
                else if (producto.Tienda.CompareTo("Pizzeria") == 0)
                {
                    ProductosPizzeria productoNuevo = new ProductosPizzeria
                    {
                        PizzaID = producto.Id,
                        Nombre = producto.Name,
                        Descripcion = producto.Desc,
                        Imagen = producto.Imagen
                    };
                    if (InsertarPizza(productoNuevo))
                        return "Insertado en Pizzeria";
                }
                else if (producto.Tienda.CompareTo("KFC") == 0)
                {
                    ProductosKFC productoNuevo = new ProductosKFC
                    {
                        id_plato = producto.Id,
                        nombre_plato = producto.Name,
                        descripcion = producto.Desc,
                        imagen = producto.Imagen
                    };
                    if (InsertarProductoKFC(productoNuevo))
                        return "Insertado en KFC";
                }
            }
            return "Error al insertar el producto";
        }

        // Método para actualizar un producto
        public string ActualizarProducto(DTOProductos producto)
        {
            if (producto != null)
            {
                if (producto.Tienda.CompareTo("Comida China") == 0)
                {
                    ProductosChina productoNuevo = new ProductosChina
                    {
                        id_producto = producto.Id,
                        nombre = producto.Name,
                        descripcion = producto.Desc,
                        prod_img = producto.Imagen
                    };
                    if (ActualizarProductoChina(productoNuevo.id_producto, productoNuevo))
                        return "Actualizado en Comida China";
                }
                else if (producto.Tienda.CompareTo("Pizzeria") == 0)
                {
                    ProductosPizzeria productoNuevo = new ProductosPizzeria
                    {
                        PizzaID = producto.Id,
                        Nombre = producto.Name,
                        Descripcion = producto.Desc,
                        Imagen = producto.Imagen
                    };
                    if (ActualizarProductoPizzeria(productoNuevo.PizzaID, productoNuevo))
                        return "Actualizado en Pizzeria";
                }
                else if (producto.Tienda.CompareTo("KFC") == 0)
                {
                    ProductosKFC productoNuevo = new ProductosKFC
                    {
                        id_plato = producto.Id,
                        nombre_plato = producto.Name,
                        descripcion = producto.Desc,
                        imagen = producto.Imagen
                    };
                    if (ActualizarProductoKFC(productoNuevo.id_plato, productoNuevo))
                        return "Actualizado en KFC";
                }
            }
            return "Error al actualizar el producto";
        }

        // Método para eliminar un producto
        public string EliminarProducto(DTOProductos producto)
        {
            if (producto != null)
            {
                if (producto.Tienda.CompareTo("Comida China") == 0)
                {
                    if (EliminarProductoChina(producto.Id))
                        return "Eliminado en Comida China";
                }
                else if (producto.Tienda.CompareTo("Pizzeria") == 0)
                {
                    if (EliminarProductoPizzeria(producto.Id))
                        return "Eliminado en Pizzeria";
                }
                else if (producto.Tienda.CompareTo("KFC") == 0)
                {
                    if (EliminarProductoKFC(producto.Id))
                        return "Eliminado en KFC";
                }
            }
            return "Error al eliminar el producto";
        }

        // Método para buscar productos por nombre
        public List<DTOProductos> FindByNombre(string nombre)
        {
            List<DTOProductos> lista = ListaProductosREST();
            var productosFiltrados = lista.Where(p => p.Name.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            return productosFiltrados;
        }
    }
}