using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace mercainsta.com.Controllers
{
    public class UsuarioController : Controller
    {
        

        private readonly Irepositorioregistro repousuario;
        public UsuarioController(Irepositorioregistro Repousuario)
        {

           this.repousuario = Repousuario;

        }
       


        public IActionResult registro_usuario(registromodel guardar)
        {


                if (!ModelState.IsValid)
                {
                    return View(guardar);

                }
                encryptar encryptar = new encryptar();
                 guardar.contraseña=encryptar.Encrypt(guardar.contraseña);


                repousuario.registromodel(guardar);

            TempData["SuccessMessage"] = "El registro fue exitoso.";

            return View();

        }




































       

        public IActionResult privacy()
        {
            return View();
        }



public ActionResult Index()
        {
            return View();
        }


        

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }




     

        // POST: UsuarioController/Create
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
