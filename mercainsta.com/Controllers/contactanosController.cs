using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mercainsta.com.Controllers
{
    public class contactanosController : Controller
    {

        private readonly Irepositorioregistro repocontactano;
        public contactanosController(Irepositorioregistro Repocontactano)
        {

            this.repocontactano = Repocontactano;

        }
       


        public IActionResult contactanos(contactanosmodel guardarC)

        {

            if (!ModelState.IsValid)
                return View(guardarC);

            repocontactano.contactanosmodel(guardarC);

            TempData["SuccessMessage"] = "El mensaje fue exitoso.";


            return View();

        }

















        // GET: contactanosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: contactanosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: contactanosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contactanosController/Create
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

        // GET: contactanosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: contactanosController/Edit/5
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

        // GET: contactanosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: contactanosController/Delete/5
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
