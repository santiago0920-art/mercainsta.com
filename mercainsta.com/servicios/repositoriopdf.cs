using Dapper;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Nodes;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;

namespace mercainsta.com.servicios
{
    public interface Irepositoriopdf
    {
        
        List<provedormodel>PDF(provedormodel pdf);


    }
    public class repositoriopdf: Irepositoriopdf
    {
        private readonly string cnx;
        private readonly IConfiguration configuration;

        public repositoriopdf(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }
        public List<provedormodel> PDF(provedormodel pdf)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT*FROM provedor";
                var producto = db.Query<provedormodel>(sqlQuery).ToList();
                    return producto;


            }



        }



    }




}
