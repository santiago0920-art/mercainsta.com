using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{
    public interface Irepositoriopdfv
    {
        List<productomodel> pdfv(productomodel pdfv);

    }

    public class Repositoriopdfv:Irepositoriopdfv
    {


        private readonly string cnx;
        private readonly IConfiguration configuration;

        public Repositoriopdfv(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }
        public List<productomodel> pdfv(productomodel pdf)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM inventario";
                var productov = db.Query<productomodel>(sqlQuery).ToList();
                return productov;


            }



        }





    }


    
}
