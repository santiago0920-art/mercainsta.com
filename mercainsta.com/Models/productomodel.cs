using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace mercainsta.com.Models
{
    public class productomodel
    {



        public string codigo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string preciov { get; set; }

        public string unidad { get; set; }    

        public string estado { get; set; }

        public string modelo { get; set; }

        public string color { get; set; }


        [DataType(DataType.Upload)]
        public IFormFile urlimagen { get; set; }

      public string imagen { get; set; }




    

    }
  }

