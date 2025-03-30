using Dapper;
using iText.Kernel.Pdf;
using iText.Layout;
using mercainsta.com.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using iText.Kernel.Events;
using mercainsta.com.servicios;
using iText.Layout.Element;
using iText.Layout.Properties;



namespace mercainsta.com.Controllers
{
    public class pdfController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly Irepositoriopdf repositoriopdf;
        public pdfController(IConfiguration configuration, Irepositoriopdf repositoriopdf)
        {
            this.configuration = configuration;
            this.repositoriopdf = repositoriopdf;

        }

        public IActionResult pdf()
        {
            return View();
        }

        public IActionResult Listadopersonapdf()
        {

            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            document.Add(new Paragraph("Listado de Personas")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(5, true);
            table.AddHeaderCell("idproducto");
            table.AddHeaderCell("idpersona");
            table.AddHeaderCell("NyA");
            table.AddHeaderCell("cantidad");
            table.AddHeaderCell("precio");

            provedormodel Provedormodel = new provedormodel();
            var personas = repositoriopdf.PDF(Provedormodel);
            foreach (var person in personas)
            {
                table.AddCell(person.idproducto);
                table.AddCell(person.idpersona);
                table.AddCell(person.NyA);
                table.AddCell(person.cantidad);
                table.AddHeaderCell(person.precio );

            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();

            Response.Headers.Add("Content-Disposition", "inline; filename=Listadopersonas.pdf");
            return File(pdfBytes, "application/pdf");
        }






























        // GET: pdfController
        public ActionResult Index()
        {
            return View();
        }

        // GET: pdfController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: pdfController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pdfController/Create
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

        // GET: pdfController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pdfController/Edit/5
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

        // GET: pdfController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pdfController/Delete/5
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
