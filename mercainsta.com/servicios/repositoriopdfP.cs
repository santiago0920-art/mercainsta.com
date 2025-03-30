using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{

    public interface IRepositoriopdfP
    {

        List<provedormodel> pdfP(provedormodel pdfv);



    }

    public class repositoriopdfP : IRepositoriopdfP
    {


        private readonly string cnx;
        private readonly IConfiguration configuration;

        public repositoriopdfP(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }
        public List<provedormodel> pdfP(provedormodel pdf)
        {


            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM provedor";
                var productov = db.Query<provedormodel>(sqlQuery).ToList();
                return productov;




            }



        }
    }
}
