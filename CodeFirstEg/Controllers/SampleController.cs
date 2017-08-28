using CodeFirstEg.Data;
using CodeFirstEg.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstEg.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        EmployeeDbcontext dbContext = new EmployeeDbcontext();
        public ActionResult Index()
        {
            EmployeeDbcontext dbContext = new EmployeeDbcontext();
            List<Employee> employess = dbContext.Employee.ToList();
            return View(employess);
        }

        public ActionResult Create()
        {
            var dept = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text="CS",
                   Value= "1",
                },
                new SelectListItem
                {
                   Text="EC",
                   Value= "2",
                },
                new SelectListItem
                {
                   Text="MEC",
                   Value= "3",
                },
                new SelectListItem
                {
                   Text="EEE",
                   Value= "4",
                },
            };

            ViewBag.dept = dept;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sample sample)
        {
           // Sample sample = new Sample();
            UpdateModel(sample);
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResults(String name)
        {
            Employee employee = dbContext.Employee.Where(c => c.Name == name).FirstOrDefault();

            return PartialView(employee);
        }


        public ActionResult Edit(int Id)
        {
            EmployeeDbcontext dbContext = new EmployeeDbcontext();
            Employee employee = dbContext.Employee.Where(c => c.Id == Id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            EmployeeDbcontext dbContext = new EmployeeDbcontext();
            Employee employee = dbContext.Employee.Where(c => c.Id == emp.Id).FirstOrDefault();
            dbContext.Entry(employee).CurrentValues.SetValues(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}