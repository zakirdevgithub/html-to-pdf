using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDF_GENERATOR.Models;
using PDF_GENERATOR.Station;
using PDF_GENERATOR.Utility;
using System;
using System.IO;

namespace PDF_GENERATOR.Controllers
{
    [Route("api/pdfcreator")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
 

        private IConverter _converter;
        private readonly HomeStation _homeStation = null;
        public PdfCreatorController(IConverter converter, HomeStation homeStation)
        {
            _homeStation = homeStation;
            _converter = converter;
        }




        [HttpGet]
        public IActionResult CreatePDF()
        {

   
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                
            };

            var objectSettings = new ObjectSettings
            {
               
                PagesCount = true,
                //HtmlContent = TemplateGenerator.GetHTMLString(),
                Page = _homeStation.GetURL(), //USE THIS PROPERTY TO GENERATE PDF CONTENT FROM AN HTML PAGE
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf); IF WE USE Out PROPERTY IN THE GlobalSettings CLASS, THIS IS ENOUGH FOR CONVERSION

            var file =_converter.Convert(pdf);

            //return Ok("Successfully created PDF document.");
            return File(file, "application/pdf", "PDF.pdf");
            //return File(file, "application/pdf");
        }
    }
}