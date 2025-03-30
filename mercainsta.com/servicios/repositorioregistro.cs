
using Dapper;
using mercainsta.com.Models;
using Microsoft.Data.SqlClient;

namespace mercainsta.com.servicios
{
    public interface Irepositorioregistro
    {
      
        Task<bool> contactanosmodel(contactanosmodel contacto);
        Task<bool> registromodel(registromodel guardar);
        Task<bool> validarusuario(loginmodel login);
        Task<bool> recuperar_contraseña(recuperarmodel recuperar);
        
    }

    public class repositorioregistro : Irepositorioregistro
    {

        private readonly string cnx;
        public repositorioregistro(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<bool> registromodel(registromodel registro)
        {
            using var connetion = new SqlConnection(cnx);
            try
            {

                bool isInserted = await connetion.ExecuteAsync(

                         @"INSERT INTO Registro_usuario (Id,nombre,apellido,fecha,sexo,correo,contraseña,Cconfirmar)
                    VALUES (@Id,@nombre,@apellido,@fecha,@sexo,@correo,@contraseña,@Cconfirmar)", registro) > 0;

            }
            catch (Exception ex)
            { }
                return true;

            

        }











        public async Task<bool> contactanosmodel(contactanosmodel contacto)
        {
            try
            {
                using var connetion = new SqlConnection(cnx);

                bool isInserted = await connetion.ExecuteAsync(

                         @"INSERT INTO contactanos (nombre,correo,mensaje)
                    VALUES (@nombre,@correo,@mensaje)", contacto) > 0;

            }
            catch (Exception exc)
            {

                throw;
            }
           


            return true;



        }

        public async Task<bool> validarusuario(loginmodel login)
        {
            using var connetion = new SqlConnection(cnx);
            string query = @"SELECT COUNT(1) FROM Registro_usuario WHERE correo=@correo AND contraseña=@contraseña";
            bool usuarioExistente = await connetion.ExecuteScalarAsync<int>(query, new {login.correo,login.contraseña})>0;


            return usuarioExistente;



        }




      public async Task<bool> recuperar_contraseña(recuperarmodel recuperar)
        {
         
            using var connetion=new SqlConnection(cnx);
            string query = @"UPDATE Registro_usuario SET contraseña=@contraseña WHERE correo=@correo";
            return true;
           
         
        }





    }







}








