using AngularMaterial.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Web.Models
{
    public class EnrollmentDTO
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Grade? Grade { get; set; }
        public CourseDTO Course { get; set; }
    }
}
