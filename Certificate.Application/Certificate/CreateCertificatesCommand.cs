using Certificate.Domain.DTOs.CertificateDTO;
using MediatR;
using Newtonsoft.Json;

namespace Certificate.Application.Certificate
{
    public class CreateCertificatesCommand : IRequest<CertificateResponse>
    {
        [JsonProperty("user_info")]
        public List<CertificateDTO> certificateDTOs { get; set; }

        [JsonProperty("course_id")]
        public int courseId { get; set; }
    }
}
