using Certificate.Domain.DTOs.CertificateDTO;
using RestSharp;

namespace Certificate.Domain.IServices
{
    public interface ICertificateService
    {
        Task<CertificateResponse> CreateCertificates(CertificateRequest certificateRequest);
    }
}
