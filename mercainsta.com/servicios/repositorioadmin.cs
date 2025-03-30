using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;


namespace mercainsta.com.servicios
{
    public interface IRepositorioadmin
    {
        Task<bool> productomodel(productomodel model);
        productoCmodel agregar(int productoId, int cantidad);

    }
    public class repositorioadmin : IRepositorioadmin
    {
        private readonly string cnx;

        public repositorioadmin(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool>productomodel(productomodel model)
        {
            bool IsInserted = false;
            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync
                    (@"INSERT INTO inventario (codigo,nombre,descripcion,preciov,unidad,estado,modelo,color,imagen) VALUES (@codigo,@nombre,@descripcion,@preciov,@unidad,@estado,@modelo,@color,@imagen)", model) > 0;
            }
            catch (Exception ex) { 
            
            string msg = ex.Message;
            
            }
            return IsInserted;


            
        }
        public productoCmodel agregar(int productoId, int cantidad)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {

                string sqlQuery = "SELECT * FROM inventario WHERE codigo=@productoId";
                productoCmodel ccc =
                    db.QuerySingleOrDefault<productoCmodel>(sqlQuery, new { productoId, cantidad });

                return ccc;

            }

            
        }

        public productoCmodel productomodel(int codigo)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM inventario WHERE codigo=@codigo";
                productoCmodel ccc=db.QuerySingleOrDefault<productoCmodel>(sqlQuery, new { codigo });

                return ccc;
            }

        }




    }

   
}
