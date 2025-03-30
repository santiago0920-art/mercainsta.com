using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace mercainsta.com.Controllers
{
    public class productoController : Controller
    {

        public readonly IRepositorioadmin repoadmin;



        public productoController(IRepositorioadmin repoadmin)
        {

            this.repoadmin = repoadmin;

         }

        public async Task<IActionResult> producto(productomodel model)
        {
            if (model.urlimagen != null && model.urlimagen.Length>0)
            {
                var extension=Path.GetExtension(model.urlimagen.FileName);
                var nuevoNombre=Guid.NewGuid().ToString() + extension;
                var filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/imgproducto",nuevoNombre);
                using(var stream=new FileStream(filePath,FileMode.Create))
                {
                    await model.urlimagen.CopyToAsync(stream);

                }
                model.imagen = "./imgproducto/" + nuevoNombre; 

                repoadmin.productomodel(model);

                TempData["SuccessMessage"] = "El registro fue exitoso.";


            }


            
            return View(model);


            





        }






        








        // GET: productoController
     

        // GET: productoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: productoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: productoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: productoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
