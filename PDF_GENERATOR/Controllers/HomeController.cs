using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDF_GENERATOR.Models;
using PDF_GENERATOR.Station;

namespace PDF_GENERATOR.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly HomeStation _homeStation = null;
       public HomeController(IWebHostEnvironment webHostEnvironment, HomeStation homeStation)
        {
            _webHostEnvironment = webHostEnvironment;
            _homeStation = homeStation;
        }

        [HttpGet]
        public IActionResult Index()
        {

          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Home model)
        {
            if (model.File != null)
            {
                string folder = "files/files";
                folder += Guid.NewGuid().ToString() + "_" + model.File.FileName;
                model.FileUrl = "/" + folder;

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await model.File.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }


            var id = await _homeStation.SendFile(model);

            if (id > 0)
            {
                return RedirectToAction(nameof(Success));
            }

            return View();


        }

        [Route("api/pdfcreator")]
        public ViewResult Success()
        {
            return View();
        }

        
    }
}
