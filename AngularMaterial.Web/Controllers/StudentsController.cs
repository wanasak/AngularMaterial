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
    [RoutePrefix("api/students")]
    public class StudentsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Student> _studentRepository;

        public StudentsController() : base()
        {
            _studentRepository = new EntityBaseRepository<Student>(); // studentRepository;
        }

        [HttpGet]
        public HttpResponseMessage Students(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var students = _studentRepository.GetAll();

                response = request.CreateResponse(HttpStatusCode.OK, students);

                return response;
            });
        }

        [Route("{id:int}")]
        public HttpResponseMessage Student(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var student = _studentRepository.GetSingle(id);

                response = request.CreateResponse(HttpStatusCode.OK, student);

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
                    Email = model.Email
                };

                _studentRepository.Add(student);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }
    }
}