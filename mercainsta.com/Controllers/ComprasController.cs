using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mercainsta.com.Controllers
{
    public class comprasController : Controller
    {
        private readonly Irepositoriocompras repocompras;
        public comprasController(Irepositoriocompras repocompras)
        {

            this.repocompras = repocompras;

        }





        [HttpGet]
        public JsonResult detalleprovedor(int idproducto)
        {
            provedormodel sexo = repocompras.detalleprovedor(idproducto);
            return Json(sexo.idproducto);


        }


        [HttpGet]
        public async Task<IActionResult> ObtenerProductoPorCodigo(string codigo)
        {
            var producto = await repocompras.ObtenerProductoPorCodigo(codigo);
            if (producto == null)
            {

                return NotFound();


            }
            return Json(producto);
        }

        public IActionResult compras()
        { return View(); }




    }
}





























