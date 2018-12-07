using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSampleApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace AspNetCoreSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        //public FileResult Index_Test()
        //{
        //    var document = GetDocumentStreamNew();
        //    return File(document.ToArray(), "application/pdf", "File Name.pdf");
        //}
        //public IActionResult Index()
        //{
        //    string path = @"E:\Arun\AspNetCoreSampleApp\AspNetCoreSampleApp\wwwroot\Content\192.xlsx";
        //    string outputpath = @"E:\Arun\AspNetCoreSampleApp\AspNetCoreSampleApp\wwwroot\Content\192pdf";

        //    bool check = ExportWorkbookToPdf(workbookPath: path, outputPath:outputpath);

        //    return View();
        //}


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [DisableRequestSizeLimit]
        public async Task<IActionResult> DisplayResult()
        {
            DisplayModel model = new DisplayModel();

            return View();
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> DisplayResult(List<IFormFile> files)
        {
            // Perform an initial check to catch FileUpload class attribute violations.

            if (files == null || files.Count == 0)
                return Content("files not selected");

            foreach (var file in files)
            {
                var filepath = System.IO.Path.Combine(
                    System.IO.Directory.GetCurrentDirectory(), "wwwroot",
                    file.FileName);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return RedirectToAction("DisplayResult");
        }

        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Upload()
        {
            var files = HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                var filepath = System.IO.Path.Combine(
                  System.IO.Directory.GetCurrentDirectory(), "wwwroot",
                  file.FileName);

                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    //var fileName = ContentDispositionHeaderValue.Parse
                    //    (file.ContentDisposition).FileName.Trim('"');
                    //System.Console.WriteLine(fileName);
                    //file.SaveAs(Path.Combine(uploads, fileName));
                }
            }
            return Ok();
        }





        //using (var fileStream = new FileStream(filePath, FileMode.Create))
        //{
        //    await DisplayModel.UploadPublicSchedule.CopyToAsync(fileStream);
        //}

        //    return RedirectToPage("./Index");
        //}



    }
}
