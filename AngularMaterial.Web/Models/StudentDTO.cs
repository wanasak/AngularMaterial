﻿using AngularMaterial.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Web.Models
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            Courses = new List<int>();
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentID { get; set; }
        public List<int> Courses { get; set; }
    }
}
