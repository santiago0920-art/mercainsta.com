using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography;



namespace mercainsta.com.Controllers
{
    public class loginController : Controller
    {

        private readonly Irepositorioregistro repologin;
        public loginController(Irepositorioregistro Repologin)
        {


            this.repologin = Repologin;


        }



        public IActionResult login(loginmodel guardarL)
        {

            return View(guardarL);



        }



        [HttpPost]
        public async Task<IActionResult> inicio(loginmodel login) {



            ErrorViewModel errormodel = new ErrorViewModel();

            try 
            {
                encryptar clave = new encryptar();
                login.contraseña=clave.Encrypt(login.contraseña);
                bool rsp = await repologin.validarusuario(login);
                if (rsp)
                {
                    return View("~/views/producto/producto.cshtml");
                }
                return View("login");
            }
            catch (Exception Error)
            {
                errormodel.RequestId = Error.HResult.ToString();
                errormodel.message = Error.HResult.ToString();
            }
            return View("Error",errormodel);




    }



        // GET: loginController
       

        // GET: loginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }





        // GET: loginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginController/Create
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

        // GET: loginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: loginController/Edit/5
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

        // GET: loginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: loginController/Delete/5
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
