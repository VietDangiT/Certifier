using Certificate.Application.Certificate.Commands.CreateCertificates;
using Certificate.Application.Certificate.Queries.GetCertificateFile;
using Certificate.Application.Certificate.Queries.GetUsers;
using Certificate.Domain.DTOs.UserDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    [Route("/api/certificate")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<ActionResult<List<bool>>> Create([FromBody] CreateCertificatesCommand request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("users")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers([FromBody]GetUsersWithPagination request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("pdf")]
        public async Task<IActionResult> GetCredentialFile([FromBody]GetCertificateFileQuery request)
        {
            var file = await _mediator.Send(request);
            return File(file, "application/pdf");
        }
        [HttpGet("/{userId}/pdf")]
        public async Task<IActionResult> GetUsersOfCourse(int userId)
        {
            var query = new GetCertificateFileQuery { userId = userId };
            var file = await _mediator.Send(query);
            return File(file, "application/pdf");

        }
    }
}
