namespace mercainsta.com.Models
{
    public class comprasmodel
    {
        public DateTime fecha { get; set; }
        public string idproducto { get; set; }
        public string provedor { get; set; }
        public provedor proveedor { get; set; }

    }
    public class provedor
    {
        public string idproducto { get; set; }

        public string idpersona { get; set; }

        public string NyA { get; set; }

        public string cantidad { get; set; }

        public string precio { get; set; }


    }
}
