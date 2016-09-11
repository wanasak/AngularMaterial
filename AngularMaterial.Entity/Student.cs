using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Entity
{
    public class Student
    {
        public int ID { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
