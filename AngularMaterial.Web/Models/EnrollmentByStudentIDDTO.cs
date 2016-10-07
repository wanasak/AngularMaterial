using AngularMaterial.Entity;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Web.Models
{
    public class EnrollmentByStudentIDDTO
    {
        public string CourseTitle { get; set; }
        //public string StudentName { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        public int GradePoint { get; set; }
    }
}
