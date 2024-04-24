using Certificate.Domain.DTOs.CertificateDTO;
using RestSharp;

namespace Certificate.Domain.IServices
{
    public interface ICertificateService
    {
        Task<List<RestResponse>> CreateCertificates(CertificateRequest certificateRequest);
    }
}
