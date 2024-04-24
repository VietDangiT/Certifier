using Certificate.Domain.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace Certificate.Infrastructure.Utilities
{
    public static class HttpHelper
    {
        public static void AddHeaders(RestRequest request, string token)
        {
            request.AddHeader("accept", "application/json");
            request.AddHeader("Certifier-Version", "2022-10-26");
            request.AddHeader("authorization", $"Bearer {token}");
        }


        public static void AddBody(RestRequest request, string recipientName, string recipientEmail, string issueDate, string groupId, string headSign, string mentorSign)
        {
            var requestBody = new
            {
                recipient = new
                {
                    name = recipientName,
                    email = recipientEmail
                },
                issueDate,
                groupId,
                customAttributes = new JObject
                {
                    { CustomAttributes.HEAD_SIGN, headSign },
                    { CustomAttributes.MENTOR_SIGN, mentorSign }
                }
            };

            request.AddJsonBody(JsonConvert.SerializeObject(requestBody), false);
        }
    }
}
