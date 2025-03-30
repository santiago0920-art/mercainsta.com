using System.ComponentModel.DataAnnotations;

namespace mercainsta.com.Models
{
    public class contactanosmodel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string nombre { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string correo { get; set; }



        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string mensaje  { get; set; }

        

    }
}
