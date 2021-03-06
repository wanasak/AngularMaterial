﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Web.Models
{
    public class CourseDTO
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<int> Instructors { get; set; }
    }
}
