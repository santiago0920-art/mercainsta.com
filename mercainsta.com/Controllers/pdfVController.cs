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
    public class pdfVController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly Irepositoriopdfv repositoriopdfv;
        public pdfVController(IConfiguration configuration, Irepositoriopdfv repositoriopdfv)
        {
            this.configuration = configuration;
            this.repositoriopdfv = repositoriopdfv;

        }

        public IActionResult pdfv()
        {
            return View();
        }

        public IActionResult Listadopersonapdfv()
        {

            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            document.Add(new Paragraph("Listado de productos")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(8, true);
            table.AddHeaderCell("codigo");
            table.AddHeaderCell("nombre");
            table.AddHeaderCell("descripcion");
            table.AddHeaderCell("preciov");
            table.AddHeaderCell("unidad");
            table.AddHeaderCell("estado");
            table.AddHeaderCell("modelo");
            table.AddHeaderCell("color");
            

            productomodel Productomodel = new productomodel();
            var personas =repositoriopdfv.pdfv(Productomodel);
            foreach (var person in personas)
            {
                table.AddCell(person.codigo);
                table.AddCell(person.nombre);
                table.AddCell(person.descripcion);
                table.AddCell(person.preciov);
                table.AddCell(person.unidad);
                table.AddCell(person.estado);
                table.AddCell(person.modelo);
                table.AddCell(person.color);

            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();

            Response.Headers.Add("Content-Disposition", "inline; filename=Listadopersonas.pdf");
            return File(pdfBytes, "application/pdf");
        }









































        // GET: pdfVController
        public ActionResult Index()
        {
            return View();
        }

        // GET: pdfVController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: pdfVController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pdfVController/Create
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

        // GET: pdfVController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pdfVController/Edit/5
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

        // GET: pdfVController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pdfVController/Delete/5
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
