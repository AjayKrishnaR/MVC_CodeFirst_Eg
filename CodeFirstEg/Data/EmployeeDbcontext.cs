using CodeFirstEg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstEg.Data
{
    public class EmployeeDbcontext : DbContext
    {
        public EmployeeDbcontext() : base("EmployeeDbcontext")
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}