using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{
    public interface Irepositoriocompras
    { provedormodel detalleprovedor(int codigo);
        Task<productomodel> ObtenerProductoPorCodigo(string idproducto);
    }
    public class repositoricompras : Irepositoriocompras
    {
        private readonly IConfiguration _configuration;
        private readonly string cnx;
        public repositoricompras(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }
        public provedormodel detalleprovedor(int idproducto)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM provedor WHERE codigo=@idproducto";
                provedormodel model = db.QuerySingleOrDefault<provedormodel>(sqlQuery, new { idproducto });
                return model;



            }



        }
        public async Task<productomodel> ObtenerProductoPorCodigo(string idproducto)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM inventario WHERE codigo=@idproducto";
                productomodel compra = db.QuerySingleOrDefault<productomodel>(sqlQuery, new { idproducto });
                return compra;



            }



        }








    }
}
