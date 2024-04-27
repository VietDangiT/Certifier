using Certificate.Application.Course.Queries.GetCourse;
using Certificate.Domain.DTOs.CourseDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    [Route("/api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        public CourseController(IMediator mediator) => _mediator = mediator;

        [HttpGet("courses")]
        public async Task<ActionResult<List<CourseDTO>>> GetCourses()
        {
            var request = new GetCoursesQuery();
            var data = await _mediator.Send(request);
            return Ok(data);
        }
    }
}
