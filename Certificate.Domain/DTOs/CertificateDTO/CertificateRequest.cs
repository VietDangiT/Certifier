using Newtonsoft.Json;

namespace Certificate.Domain.DTOs.CertificateDTO
{
    public class CertificateRequest
    {
        [JsonProperty("user_info")]
        public List<CertificateDTO> certificateDTOs { get; set; }

        [JsonProperty("course_id")]
        public int courseId { get; set; }
    }
    public class CertificateDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }


    }
}
