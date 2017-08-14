using CodeFirstEg.Data;
using CodeFirstEg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstEg.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDbcontext dbContext = new EmployeeDbcontext();
            List<Employee> employess = dbContext.Employee.ToList();
            return View(employess);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDbcontext dbcontext = new EmployeeDbcontext();
                dbcontext.Employee.Add(employee);
                dbcontext.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
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
        public ActionResult Delete(int Id)
        {
            EmployeeDbcontext dbContext = new EmployeeDbcontext();
            Employee employee = dbContext.Employee.Where(c => c.Id == Id).FirstOrDefault();
            dbContext.Employee.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Select(int Id)
        {
            return View();
        }


    }
}