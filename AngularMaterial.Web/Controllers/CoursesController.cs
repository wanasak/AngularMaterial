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
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Course> _courseRepository;

        public CoursesController()
            : base()
        {
            _courseRepository = new EntityBaseRepository<Course>();
        }

        [HttpGet]
        public HttpResponseMessage Courses(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var courses = _courseRepository.GetAll();

                response = request.CreateResponse(HttpStatusCode.OK, courses);

                return response;
            });
        }

        [Route("{id:int}")]
        public HttpResponseMessage Course(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var course = _courseRepository.GetSingle(id);

                response = request.CreateResponse(HttpStatusCode.OK, course);

                return response;
            });
        }
    }
}