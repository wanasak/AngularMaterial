﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Entity
{
    public class CourseInstructor : IEntityBase
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
    }
}
