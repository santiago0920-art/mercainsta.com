using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace mercainsta.com.servicios
{
    public interface IrepositoriopdfC
    {
        List<registromodel>pdfC(registromodel pdfc);


    }

    public class repositoriopdfC:IrepositoriopdfC
    {

        private readonly string cnx;
        private readonly IConfiguration configuration;

        public repositoriopdfC(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public List<registromodel>pdfC(registromodel pdfc)
        {



            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM Registro_usuario";
                var productov = db.Query<registromodel>(sqlQuery).ToList();
                return productov;




            }






        }



    }
}
