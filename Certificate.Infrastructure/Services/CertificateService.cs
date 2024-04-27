using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.IServices;
using RestSharp;
using Certificate.Domain.Common;
using Certificate.Infrastructure.Utilities;
using Certificate.Domain.IRepositories;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Certificate.Domain.DTOs;

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
                var certificate = await CreateCredential(item.Name, item.Email, issueDate, course.groupId, course.headSign, course.mentorSign);
                await PublishAsync(certificate.Id);
                var file = await StoreByte(certificate.PublicId);
                await UpdateUserInfo(item.id, file);
            }
            return content;
        }

        private RestClient CreateClient(string apiLink)
        {
            var options = new RestClientOptions(apiLink);
            var client = new RestClient(options);
            return client;
        }



        private async Task<CertificateModel> CreateCredential(string recipientName,
                                            string recipientEmail,
                                            string issueDate,
                                            string groupID,
                                            string headSign,
                                            string mentorSign)
        {
            var client = CreateClient(Constants.PARTNER_API);
            var request = new RestRequest("");
            HttpHelper.AddHeaders(request, Constants.TOKEN);
            HttpHelper.AddBody(request, recipientName, recipientEmail, issueDate, groupID, headSign, mentorSign);
            var response = await client.PostAsync(request);
            return JsonConvert.DeserializeObject<CertificateModel>(response.Content);
        }
        private async Task PublishAsync(string Id)
        {
            var client = CreateClient(Constants.PARTNER_API + "/" + Id + Constants.PUBLISH);
            var request = new RestRequest("");
            HttpHelper.AddHeaders(request, Constants.TOKEN);
            var response = await client.PostAsync(request);

        }
        private async Task<byte[]> StoreByte(string publishId)
        {
            var link = Constants.CERTI_PDF + publishId + Constants.PDF;
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetByteArrayAsync(link);
            }
        }

        private async Task UpdateUserInfo(int userId, byte[] file)
        {
            var user = await _certificateRepository.GetByIdAsync(userId);
            user.pdfFile = file;
            await _certificateRepository.UpdateAsync(user);
        }


        public async Task<byte[]> GetCredentialFile(int userId)
        {
            var user = await _certificateRepository.GetByIdAsync(userId);
            return user.pdfFile;
        }
    }
}
