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
    public class pdfCController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly IrepositoriopdfC irepositoriopdfC;
      
        public pdfCController(IConfiguration configuration, IrepositoriopdfC irepositoriopdfC)
        {
            this.configuration = configuration;
            this.irepositoriopdfC = irepositoriopdfC;
        }

        public IActionResult pdfC()
        { return View(); }

        public IActionResult ListadoRegistro() 
        {

            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);



            document.Add(new Paragraph("Lista de Registro")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(7, true);
            table.AddHeaderCell("ID");
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Apellido");
            table.AddHeaderCell("Fecha de nacimiento");
            table.AddHeaderCell("Sexo");
            table.AddHeaderCell("Correo");
            table.AddHeaderCell("Contraseña");


            registromodel registromodel = new registromodel();
            var persona=irepositoriopdfC.pdfC(registromodel);
            foreach(var person in persona)
            {

                table.AddCell(person.Id);
                table.AddCell(person.nombre);
                table.AddCell(person.apellido);
                table.AddCell(person.fecha);
                table.AddCell(person.sexo);
                table.AddCell(person.correo);
                table.AddCell(person.contraseña);




            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();

            Response.Headers.Add("Content-Disposition", "inline; filename=ListadoRegistro.pdf");
            return File(pdfBytes, "application/pdf");













        }








































        // GET: pdfCController
        public ActionResult Index()
        {
            return View();
        }

        // GET: pdfCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: pdfCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pdfCController/Create
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

        // GET: pdfCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pdfCController/Edit/5
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

        // GET: pdfCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pdfCController/Delete/5
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
