using AngularMaterial.Data.Repositories;
using AngularMaterial.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial.Data.Extensions
{
    public static class CourseExtension
    {
        public static bool IsCourseIDExist(this IEntityBaseRepository<Course> courseRepository, int id)
        {
            return (courseRepository.FindBy(c => c.ID == id) != null);
        }
    }
}
