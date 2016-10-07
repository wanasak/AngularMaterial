using AngularMaterial.Data.Repositories;
using AngularMaterial.Entity;
using AngularMaterial.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularMaterial.Web.Controllers
{
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Enrollment> _enrollmentRepository;

        public EnrollmentsController(
            IEntityBaseRepository<Enrollment> enrollmentRepository)
            : base()
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public HttpResponseMessage EnrollmentStudentCount(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var group = from e in _enrollmentRepository.GetAll()
                            group e by e.CourseID into g
                            select new EnrollmentStudentCountDTO
                            {
                                CourseID = g.Key,
                                StudentCount = g.Count()
                            };
                response = request.CreateResponse(HttpStatusCode.OK, group);
                return response;
            });
        }

        [HttpGet]
        [Route("student/{studentID:int}")]
        public HttpResponseMessage EnrollmentByStudentID(HttpRequestMessage request, int studentID)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var enrollment = _enrollmentRepository
                    .AllIncluding(e => e.Course)
                    .Where(e => e.StudentID == studentID)
                    .Select(e => new EnrollmentByStudentIDDTO()
                    {
                        GradePoint = 4 - (int)e.Grade,
                        CourseTitle = e.Course.Title,
                    });

                response = request.CreateResponse(HttpStatusCode.OK, enrollment);

                return response;
            });
        }
    }
}