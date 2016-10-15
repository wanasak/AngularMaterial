using AngularMaterial.Data.Repositories;
using AngularMaterial.Entity;
using AngularMaterial.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularMaterial.Web.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Student> _studentRepository;
        private readonly IEntityBaseRepository<Enrollment> _enrollmentRepository;

        public StudentsController(
            IEntityBaseRepository<Student> studentRepository,
            IEntityBaseRepository<Enrollment> enrollmentRepository)
            : base()
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        [Route("{filter?}")]
        public HttpResponseMessage Students(HttpRequestMessage request, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<StudentDTO> students;

                if (string.IsNullOrEmpty(filter))
                {
                    students = _studentRepository
                    .GetAll()
                    .Select(s => new StudentDTO()
                    {
                        ID = s.ID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Image = s.Image
                    });
                }
                else
                {
                    students = _studentRepository
                        .GetAll()
                        .Where(s =>
                            s.FirstName.ToLower().Contains(filter.ToLower().Trim()) ||
                            s.LastName.ToLower().Contains(filter.ToLower().Trim()))
                        .Select(s => new StudentDTO()
                        {
                            ID = s.ID,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Image = s.Image
                        });
                }

                response = request.CreateResponse(HttpStatusCode.OK, students);

                return response;
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Student(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //var student = _studentRepository.GetSingle(id);

                var student = _studentRepository
                    .AllIncluding(s => s.Enrollments.Select(e => e.Course))
                    .Select(s => new StudentDetailDTO()
                    {
                        ID = s.ID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email = s.Email,
                        Image = s.Image,
                        Enrollments = s.Enrollments.Select(e => new EnrollmentDTO()
                        {
                            StudentID = e.StudentID,
                            CourseID = e.CourseID,
                            Grade = (Grade)e.Grade,
                            Course = new CourseDTO()
                            {
                                ID = e.Course.ID,
                                Title = e.Course.Title,
                                Credits = e.Course.Credits
                            }
                        })
                    })
                    .FirstOrDefault(s => s.ID == id);

                response = request.CreateResponse(HttpStatusCode.OK, student);

                return response;
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteStudent(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var student = new Student { ID = id };
                _studentRepository.Delete(student);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, StudentDTO model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Student student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Image = "ic_face_black_48px.svg"
                };

                _studentRepository.Add(student);

                foreach (var courseID in model.Courses)
                {
                    var enrollment = new Enrollment()
                    {
                        CourseID = courseID,
                        StudentID = student.ID
                    };
                    _enrollmentRepository.Add(enrollment);
                }

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }
    }
}