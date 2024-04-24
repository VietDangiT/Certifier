using Certificate.Domain.DTOs.CertificateDTO;
using MediatR;
using Newtonsoft.Json;

namespace Certificate.Application.Certificate
{
    public class CreateCertificatesCommand : IRequest<CertificateRequest>
    {
        [JsonProperty("user_info")]
        public List<CertificateDTO> certificateDTOs { get; set; }

        [JsonProperty("course_id")]
        public string courseId { get; set; }
    }
}
