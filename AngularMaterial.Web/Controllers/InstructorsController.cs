using AngularMaterial.Data.Repositories;
using AngularMaterial.Entity;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using AngularMaterial.Web.Models;
using System.Net;

namespace AngularMaterial.Web.Controllers
{
    [RoutePrefix("api/instructors")]
    public class InstructorsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Instructor> _instructorRepository;

        public InstructorsController(
            IEntityBaseRepository<Instructor> instructorRepository)
            : base()
        {
            _instructorRepository = instructorRepository;
        }

        [HttpGet]
        public HttpResponseMessage Instructors(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var instructors = _instructorRepository
                    .GetAll()
                    .Select(i => new InstructorDTO()
                    {
                        ID = i.ID,
                        FirstName = i.FirstName,
                        LastName = i.LastName
                    });

                response = request.CreateResponse(HttpStatusCode.OK, instructors); 

                return response;
            });
        }
    }
}