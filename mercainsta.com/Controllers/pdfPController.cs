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
    public class pdfPController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly    IRepositoriopdfP repositoriopdfP;
        public pdfPController(IConfiguration configuration, IRepositoriopdfP repositoriopdfp)
        {
            this.configuration = configuration;
            this.repositoriopdfP = repositoriopdfp;

        }


        public IActionResult pdfP()
            { return View(); }




        public IActionResult Listadoprovedor() 
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            document.Add(new Paragraph("Listado de Provedor")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(5, true);
            table.AddHeaderCell("Idproducto");
            table.AddHeaderCell("Idpersona");
            table.AddHeaderCell("NyA");
            table.AddHeaderCell("Cantidad");
            table.AddHeaderCell("Precio");

            provedormodel provedormodel = new provedormodel();
            var persona=repositoriopdfP.pdfP(provedormodel);
            foreach(var person in persona)
            {

                table.AddCell(person.idproducto);
                table.AddCell(person.idpersona);
                table.AddCell(person.NyA);
                table.AddCell(person.cantidad);
                table.AddCell(person.precio);



            }
            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();

            Response.Headers.Add("Content-Disposition", "inline; filename=Listadopersonas.pdf");
            return File(pdfBytes, "application/pdf");








        }








































        
    }
    
}
