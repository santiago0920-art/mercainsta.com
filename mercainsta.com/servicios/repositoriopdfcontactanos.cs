using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{
    public interface Irepositoriopdfcontactanos
    {
     List<contactanosmodel> pdfcontactanos(contactanosmodel pdfcontactanos);
    }


    public class repositoriopdfcontactanos:Irepositoriopdfcontactanos
    {

        private readonly string cnx;
        private readonly IConfiguration configuration;

        public repositoriopdfcontactanos(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }


        
        public List<contactanosmodel>pdfcontactanos(contactanosmodel pdf)
        {
            using(IDbConnection db=new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM contactanos";
                var productoc=db.Query<contactanosmodel>(sqlQuery).ToList();
                return productoc;




            }






        }












    }
}
