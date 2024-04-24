using Certificate.Application.Certificate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Clean_Architecture.Controllers
{
    [Route("/api/certificate")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<List<RestResponse>>> Create([FromBody] CreateCertificatesCommand request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        } 
    }
}
