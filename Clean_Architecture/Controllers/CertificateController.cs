using Certificate.Application.Certificate.Commands.CreateCertificates;
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
    }
}
