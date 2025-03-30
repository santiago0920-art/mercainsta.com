using System.ComponentModel.DataAnnotations;

namespace mercainsta.com.Models
{
    public class registromodel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(10)]
        public string Id { get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string apellido { get; set;}


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string fecha {get; set;}


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string  sexo { get; set;}


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string correo { get; set;}


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string contraseña { get; set;}


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Cconfirmar { get; set;}



    }
}
