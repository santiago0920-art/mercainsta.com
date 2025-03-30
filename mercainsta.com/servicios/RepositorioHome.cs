using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{
    public interface IRepositorioHome
    {
        productomodel detalleproducto(int codigo);
        IEnumerable<productomodel> ListarProducto();
    }

    public class RepositorioHome : IRepositorioHome
    {
        private readonly string cnx;
        public RepositorioHome(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public IEnumerable<productomodel> ListarProducto()

        {
            
                using (IDbConnection db = new SqlConnection(cnx))
                {
                    string sqlQuery = "SELECT * FROM inventario";
                    var productos = db.Query<productomodel>(sqlQuery).ToList();
                    return productos;
                }
            
        
        }


        public productomodel detalleproducto(int codigo)
        {

            using (IDbConnection db = new SqlConnection(cnx))
            {

                string sqlQuery = "SELECT  codigo,nombre,preciov,descripcion,imagen FROM inventario WHERE codigo=@codigo";
                productomodel producto = db.QuerySingleOrDefault<productomodel>(sqlQuery, new { codigo });
                return producto;

            }



            
        }






    }
}