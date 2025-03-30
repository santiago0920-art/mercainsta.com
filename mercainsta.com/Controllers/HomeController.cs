using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Diagnostics;


namespace mercainsta.com.Controllers
{


    public class HomeController : Controller
    {
        private readonly Icarritoservicio _carritoservicio;
        private readonly IRepositorioHome _IRepositorioHome;
        private readonly IRepositorioHome repohome;
        public readonly IRepositorioadmin repoadmin;
        
        public HomeController(IRepositorioHome repositorioHome, Icarritoservicio carritoservicio, IRepositorioadmin IRepositorioadmin)
        {

            repohome = repositorioHome;
             repoadmin = IRepositorioadmin;
            _carritoservicio = carritoservicio;
            _IRepositorioHome = repositorioHome;

        }

        public IActionResult Index()
        {
            IEnumerable<productomodel> productos = repohome.ListarProducto();
            return View(productos);





        }




        public IActionResult contactanos()
        { return View(); }

        public IActionResult registro_usuario()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet]
        public string Mensaje()
        { return "Mensaje Back sino crees"; }


        [HttpGet]
        public JsonResult detalleproducto(int id)
        {
            productomodel detalle = repohome.detalleproducto(id);
            detalle.modelo = detalle.modelo == null ? "N/A" : detalle.modelo;
            detalle.color = detalle.color == null ? "N/A" : detalle.color;
            return Json(detalle);







        }

        private readonly Irepositorioregistro reporegistro;

        public IActionResult recuperar_contraseña(recuperarmodel recuperar)
        { return View("~/views/recuperar/recuperar_contraseña.cshtml"); 
          
           
        
        
        
        }





        public IActionResult agregar(productoCmodel productoId, int cantidad)
        {
            if (productoId != null)
            {
                _carritoservicio.agregar(productoId, cantidad);

            }
            var carritoItems = _carritoservicio.ListarItemsCarro();
            return View("carrito", carritoItems);

        }






        public IActionResult eliminar(int productoId)
        {
         _carritoservicio.eliminarItemcarro(productoId);
            var carritoitems = _carritoservicio.ListarItemsCarro();
                return View("~/views/carrito/carrito.cshtml", carritoitems);




        }


        public IActionResult actualizarItem(int productoId,int cantidad)
        {

            if(cantidad < 1)
            {
                return BadRequest("La cantidad debe ser al menos 1.");


            }
            _carritoservicio.actualizarItemcarro(productoId,cantidad);
            var carritoItems = _carritoservicio.ListarItemsCarro();
            return View("~/views/carrito/carrito.cshtml", carritoItems);


        }

        public IActionResult carrito(int productoId,int cantidad)
        {
            var conectar = repoadmin.agregar(productoId,cantidad);
                if(conectar !=null)
                {
                _carritoservicio.agregar(conectar,cantidad);

            
                }

            var carritoItems = _carritoservicio.ListarItemsCarro();


            return View("~/views/carrito/carrito.cshtml" ,carritoItems);



        }

      






    }

    }
