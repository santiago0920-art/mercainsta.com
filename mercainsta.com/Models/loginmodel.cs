using System.ComponentModel.DataAnnotations;

namespace mercainsta.com.Models
{
    public class loginmodel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string contraseña { get; set; }




    }
}
