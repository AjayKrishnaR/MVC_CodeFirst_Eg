﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstEg.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
       
        public string Name { get; set; }

        [Remote("IsValidName", "Employee", ErrorMessage = "Email Already Registered...")]
        [Required(ErrorMessage = "Email Address cannot be null")]
      [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        public int Phoneno { get; set; }
    }
}