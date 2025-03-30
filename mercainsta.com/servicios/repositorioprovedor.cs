using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;

namespace mercainsta.com.servicios
{
   
        public interface Irepositorioprovedor
        {
            Task<bool> provedormodel(provedormodel provedor);

        }

        public class repositorioprovedor : Irepositorioprovedor
        {
     
        private readonly string cnx;
        public repositorioprovedor(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<bool> provedormodel(provedormodel provedor)
        {
            using var connetion = new SqlConnection(cnx);
            try
            {

                bool isInserted = await connetion.ExecuteAsync(

                         @"INSERT INTO provedor (idproducto,idpersona,NyA,cantidad,precio)
                    VALUES (@idproducto,@idpersona,@NyA,@cantidad,@precio)", provedor) > 0;

            }
            catch (Exception ex)
            { }
            return true;



        }







    }











    
}
