using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMaterial.Web.Models
{
    public class InstructorDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}