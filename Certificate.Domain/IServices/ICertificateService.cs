using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.DTOs.UserDTO;

namespace Certificate.Domain.IServices
{
    public interface ICertificateService
    {
        Task<CertificateResponse> CreateCertificates(CertificateRequest certificateRequest);
    }
}
