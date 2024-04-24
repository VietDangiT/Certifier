using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.IServices;
using RestSharp;

namespace Certificate.Application.Certificate
{
    public class CreateCertificatesHandler
    {
        private readonly ICertificateService _certificateService;
        
        public CreateCertificatesHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public async Task<List<RestResponse>> Handle(CreateCertificatesCommand request, CancellationToken cancellationToken)
        {
            var req = new CertificateRequest()
            {
                certificateDTOs = request.certificateDTOs
            };
            var result = await _certificateService.CreateCertificates(req);
            return result;
        }
    }
}
