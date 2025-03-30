
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using mercainsta.com.Models;
using mercainsta.com.servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace mercainsta.com.Controllers
{
    public class pdfcontactanosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly Irepositoriopdfcontactanos repositoriopdfcontactanos;
        public pdfcontactanosController(IConfiguration configuration, Irepositoriopdfcontactanos repositoriocontactanos)
        {
            this.configuration = configuration;
            this.repositoriopdfcontactanos =repositoriocontactanos ;

        }

        public IActionResult pdfcontactanos()
        {
            return View();
        }

        public IActionResult Listadopersonapdfcontactanos()
        {

            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            document.Add(new Paragraph("Listado de contactanos")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(3, true);
            table.AddHeaderCell("nombre");
            table.AddHeaderCell("correo");
            table.AddHeaderCell("mensaje");
            


            contactanosmodel contactanosmodel = new contactanosmodel();
            var personas = repositoriopdfcontactanos.pdfcontactanos(contactanosmodel);
            foreach (var person in personas)
            {
                table.AddCell(person.nombre);
                table.AddCell(person.correo);
                table.AddCell(person.mensaje);
           
            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();

            Response.Headers.Add("Content-Disposition", "inline; filename=Listadopersonaspdfcontactanos.pdf");
            return File(pdfBytes, "application/pdf");
        }





































        // GET: pdfcontactanosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: pdfcontactanosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: pdfcontactanosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pdfcontactanosController/Create
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

        // GET: pdfcontactanosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pdfcontactanosController/Edit/5
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

        // GET: pdfcontactanosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pdfcontactanosController/Delete/5
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
