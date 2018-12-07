using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSampleApp.Core;
using AspNetCoreSampleApp.Service.Repositories;
using AspNetCoreSampleApp.Models;
using AspNetCoreSampleApp.Core.Entities;
using X.PagedList;

namespace AspNetCoreSampleApp.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly DataContext _context;
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(DataContext context, IEmployeeRepository employeeRepository)
        {
            this._context = context;
            this._employeeRepository = employeeRepository;
        }

        public IActionResult Create()
        {
            EmployeeModel model = new EmployeeModel();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee employee = new Employee()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        Email = model.Email,
                        DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd/MM/yyyy", null),
                        DateOfJoin = DateTime.ParseExact(model.DateOfJoin, "dd/MM/yyyy", null),
                        PhoneNumber = model.PhoneNumber,
                        //UploadImage = model.UploadImage
                    };
                    _employeeRepository.AddEmployee(employee);
                    TempData["Success"] = "Successfully Inserted.";
                    return View("Create");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Something goes wrong" + ex);
                }
                return View();
            }

            ModelState.AddModelError("", "Something goes wrong");
            return View();
        }
        public IActionResult List(int? page)
        {
            //var listdata = _employeeRepository.GetAllEmployes();
            //var totalcount = _context.Employee.Count();
            //var pageNumber = page ?? 1;

            //var onePageEmployee = listdata.ToPagedList(pageNumber, 10);

            page = Convert.ToInt32(page == null ? 1 : page);

            var listdata = _employeeRepository.GetAllEmployesByPageAndPageSize(page, 20);

            //var pageNumber = page ?? 1;
            int pageNumber = Convert.ToInt32(page == null ? 1 : page);


            pageNumber = 0;
            try
            {
                var onePageEmployee1 = listdata.ToPagedList(pageNumber, 10);

            }
            catch (Exception ex)
            {

                return View();
            }
            var onePageEmployee = listdata.ToPagedList(pageNumber, 10);

            IEnumerable<EmployeeModel> listmodel = onePageEmployee.Select(s => new EmployeeModel
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth.Date.ToString("dd/MM/yyyy"),
                DateOfJoin = s.DateOfJoin.Date.ToString("dd/MM/yyyy"),
                PhoneNumber = s.PhoneNumber,
                //UploadImage = s.UploadImage
            });

            ViewBag.OnePageOfProducts = listmodel;

            return View("List", listmodel);
        }

        public IActionResult EmployeeList(int? page)
        {
            //var listdata = _employeeRepository.GetAllEmployes();
            //var pageNumber = page ?? 1;

            //var onePageEmployee = listdata.ToPagedList(pageNumber, 10);
            page = page == null ? 0 : page;

            var listdata = _employeeRepository.GetAllEmployesByPageAndPageSize(page,20);

            var pageNumber = page ?? 1;

            var onePageEmployee = listdata.ToPagedList(pageNumber, 10);

            IEnumerable<EmployeeModel> listmodel = onePageEmployee.Select(s => new EmployeeModel
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth.Date.ToString("dd/MM/yyyy"),
                DateOfJoin = s.DateOfJoin.Date.ToString("dd/MM/yyyy"),
                PhoneNumber = s.PhoneNumber,
                //UploadImage = s.UploadImage
            });

            ViewBag.OnePageOfProducts = listmodel;

            return View("List", listmodel);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
                return RedirectToAction("List", "Employee");

            _employeeRepository.DeleteEmployee(id);

            return RedirectToAction("List", "Employee");
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        //[HttpPost]
        //public IActionResult Index(IFormFile file)
        //{
        //    string FileName = "";
        //    HttpFileCollectionBase files = Request.Files;
        //    for (int i = 0; i < files.Count; i++)
        //    {
        //        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";    
        //        //string filename = Path.GetFileName(Request.Files[i].FileName);    

        //        HttpPostedFileBase file = files[i];
        //        string fname;

        //        // Checking for Internet Explorer    
        //        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //        {
        //            string[] testfiles = file.FileName.Split(new char[] { '\\' });
        //            fname = testfiles[testfiles.Length - 1];
        //        }
        //        else
        //        {
        //            fname = file.FileName;
        //            FileName = file.FileName;
        //        }

        //        // Get the complete folder path and store the file inside it.    
        //        fname = Path.Combine(MapPath("~/Uploads/"), fname);
        //        file.SaveAs(fname);
        //    }
        //    return Json(FileName, JsonRequestBehavior.AllowGet);
        //}

    }
}