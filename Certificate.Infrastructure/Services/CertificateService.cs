using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.IServices;
using RestSharp;
using Certificate.Domain.Common;
using Certificate.Infrastructure.Utilities;
using Certificate.Domain.IRepositories;

namespace Certificate.Infrastructure.Services
{
    public class CertificateService : ICertificateService
    { 

        private ICertificateRepository _certificateRepository; 
        private ICourseRepository _courseRepository;

        public CertificateService(ICertificateRepository certificateRepository,
                                    ICourseRepository courseRepository)
        {
            _certificateRepository = certificateRepository;
            _courseRepository = courseRepository;
        }
        public async Task<CertificateResponse> CreateCertificates(CertificateRequest certificateRequest)
        {
            var content = new CertificateResponse();
            var certificates = certificateRequest.certificateDTOs;
            var course = await _courseRepository.GetByIdAsync(certificateRequest.courseId);
            string issueDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            foreach (var item in certificates)
            {
                var createClient = CreateClient();
                var createRequest = CreateRequest(item.Name, item.Email, issueDate, course.groupId, course.headSign, course.mentorSign);
                var result = await SendRequest(createClient, createRequest);
                if (result.IsSuccessful)
                {
                    content.response.Add(true);
                }
                
            }
            return content;
        }

        private async Task<RestResponse> SendRequest(RestClient client, RestRequest request)
        {
            try
            {
            var response = await client.PostAsync(request);
            return response;
        }
            catch (Exception ex)
            {
                throw new Exception();
            }


        }

        private RestClient CreateClient()
        {
            var options = new RestClientOptions(Constants.PARTNER_API);
            var client = new RestClient(options);
            return client;
        }

        private RestRequest CreateRequest(string recipientName,
                                            string recipientEmail,
                                            string issueDate,
                                            string groupID,
                                            string headSign,
                                            string mentorSign)
        {
            var request = new RestRequest("");
            HttpHelper.AddHeaders(request, Constants.TOKEN);
            HttpHelper.AddBody(request, recipientName, recipientEmail, issueDate, groupID, headSign, mentorSign);
            return request;
        }

        
    }
}
