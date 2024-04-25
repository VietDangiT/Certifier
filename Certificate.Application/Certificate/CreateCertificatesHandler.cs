using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.IServices;
using MediatR;
using RestSharp;

namespace Certificate.Application.Certificate
{
    public class CreateCertificatesHandler : IRequestHandler<CreateCertificatesCommand, CertificateResponse>
    {
        private readonly ICertificateService _certificateService;
        
        public CreateCertificatesHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public async Task<CertificateResponse> Handle(CreateCertificatesCommand request, CancellationToken cancellationToken)
        {
            var req = new CertificateRequest()
            {
                certificateDTOs = request.certificateDTOs,
                courseId = request.courseId
            };
            var result = await _certificateService.CreateCertificates(req);
            return result;
        }
    }
}
