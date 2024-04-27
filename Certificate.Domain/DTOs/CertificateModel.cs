using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Domain.DTOs
{
    public class CertificateModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("publicId")]
        public string PublicId { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("issueDate")]
        public DateTimeOffset IssueDate { get; set; }

        [JsonProperty("issueAt")]
        public object IssueAt { get; set; }

        [JsonProperty("expiryDate")]
        public object ExpiryDate { get; set; }

        [JsonProperty("customAttributes")]
        public CustomAttributes CustomAttributes { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class CustomAttributes
    {
        [JsonProperty("custom.head")]
        public string CustomHead { get; set; }

        [JsonProperty("custom.mentor")]
        public string CustomMentor { get; set; }
    }

    public partial class Recipient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
