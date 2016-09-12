using AngularMaterial.Data.Repositories;
using AngularMaterial.Entity;
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
    }
}