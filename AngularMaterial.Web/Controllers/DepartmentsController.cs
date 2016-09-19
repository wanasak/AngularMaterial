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
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Department> _departmentRepository;

        public DepartmentsController(
            IEntityBaseRepository<Department> departmentRepository)
            : base()
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public HttpResponseMessage Departments(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var departments = _departmentRepository.GetAll().Select(d => new DepartmentDTO()
                {
                    ID = d.ID,
                    Name = d.Name
                });

                response = request.CreateResponse(HttpStatusCode.OK, departments);

                return response;
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Department(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var department = _departmentRepository.GetSingle(id);

                response = request.CreateResponse(HttpStatusCode.OK, department);

                return response;
            });
        }
    }
}