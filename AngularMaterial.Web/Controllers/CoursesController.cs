﻿using AngularMaterial.Data.Repositories;
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

                var courses = _courseRepository
                    .GetAll()
                    .Select(c => new CourseDTO()
                    {
                        ID = c.ID,
                        Title = c.Title,
                        Credits = c.Credits
                    });

                response = request.CreateResponse(HttpStatusCode.OK, courses);

                return response;
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Course(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var course = _courseRepository
                    .GetAll()
                    .Select(c => new CourseDTO()
                    {
                        ID = c.ID,
                        Title = c.Title,
                        Credits = c.Credits
                    })
                    .SingleOrDefault(c => c.ID == id);

                response = request.CreateResponse(HttpStatusCode.OK, course);

                return response;
            });
        }

        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CourseDTO model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Course course = new Course()
                {
                    ID = model.ID,
                    Title = model.Title,
                    Credits = model.Credits,
                };

                _courseRepository.Add(course);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }
    }
}