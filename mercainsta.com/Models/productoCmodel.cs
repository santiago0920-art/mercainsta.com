namespace mercainsta.com.Models
{
    public class productoCmodel
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public decimal preciov { get; set; }
        public string descripcion { get; set; }
        public int codigo {get; set; }
        
    }

    public class carroitem
    {
        public productoCmodel producto { get; set; }

        public int cantidad { get; set; }


    }
    public class productoselecionados 
    { 
    
    public List<carroitem> items { get; set;}=new List<carroitem>();
    public decimal Totalprecio=>items.Sum(items=>items.producto.preciov * items.cantidad);
    
    }






}