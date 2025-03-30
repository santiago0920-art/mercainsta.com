using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace mercainsta.com.Controllers
{
    public class provedorController : Controller
    {
        private readonly Irepositorioprovedor repoprove;


       public provedorController (Irepositorioprovedor repoprove)
        {

            this.repoprove = repoprove;



       }

        public IActionResult provedor(provedormodel provedor)
        {
            if (!ModelState.IsValid)
            {
                return View(provedor);

            }

            repoprove.provedormodel(provedor);
            TempData["SuccessMessage"] = "El registro fue exitoso.";
            return View();


        }
        


























        // GET: provedorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: provedorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: provedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: provedorController/Create
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

        // GET: provedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: provedorController/Edit/5
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

        // GET: provedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: provedorController/Delete/5
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
