using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace mercainsta.com.servicios
{



    public interface Icarritoservicio
    {
        void agregar(productoCmodel productoId, int cantidad);
        List<carroitem> ListarItemsCarro();
        void eliminarItemcarro(int productoId);
        void actualizarItemcarro(int productoId, int cantidad);
        

    }

    public class carritoservicio : Icarritoservicio
    {


        public readonly string cnx;
        public readonly productoselecionados _productoselecionados;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public carritoservicio(productoselecionados productoselecionados, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {

            _httpContextAccessor = httpContextAccessor;
            _productoselecionados = productoselecionados;

            cnx = configuration.GetConnectionString("Defaultconnection");
        }

        private productoselecionados obtenerItemsSesion()
        {

            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("carrito");
            return string.IsNullOrEmpty(cartJson)
                           ? new productoselecionados()
                           : JsonSerializer.Deserialize<productoselecionados>(cartJson);


        }
        private void guardarItemsSesion(productoselecionados cart)
        {

            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("carrito", JsonSerializer.Serialize(cart));
        }

        public void agregar(productoCmodel _producto, int cantidad)
        {
            var cart = obtenerItemsSesion();
            var existingItem = cart.items.FirstOrDefault(i => i.producto.codigo == _producto.codigo);

            if (existingItem != null)
            {
                existingItem.cantidad += cantidad;
            }
            else
            {

                cart.items.Add(new carroitem { producto = _producto, cantidad = cantidad });


            }

            guardarItemsSesion(cart);




        }

        public void eliminarItemcarro(int productoId)
        {
            var cart = obtenerItemsSesion();
            var item = cart.items.FirstOrDefault(i => i.producto.codigo == productoId);
            if (item != null)
            {
                cart.items.Remove(item);
                guardarItemsSesion(cart);



            }



        }



        public void actualizarItemcarro(int productoId, int cantidad)
        {
            var cart = obtenerItemsSesion();
            var existeitems = cart.items.FirstOrDefault(i => i.producto.codigo == productoId);
            if (existeitems != null)
            {
                existeitems.cantidad = cantidad;

            }
            guardarItemsSesion(cart);

        }

        public List<carroitem> ListarItemsCarro()
        {
            return obtenerItemsSesion().items;
        }


        public decimal obtenerTotal()
        {
            return _productoselecionados.Totalprecio;



        }

     




    }
}