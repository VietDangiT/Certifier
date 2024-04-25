using Certificate.Domain.DTOs.CertificateDTO;
using Certificate.Domain.IServices;
using Moq;
using RestSharp;

namespace Certificate.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task TestMethod1()
        {
            var userList = GetUserList();
            var mockCertificateService = new Mock<ICertificateService>();
            mockCertificateService.Setup(x => x.CreateCertificates(userList))
                                                .ReturnsAsync(new CertificateResponse());

            var certificateService = mockCertificateService.Object;

            var result = await certificateService.CreateCertificates(userList);

            Assert.AreEqual(5, result.Count);
        }

        private CertificateRequest GetUserList()
        {
            return new CertificateRequest
            {
                courseId = 3,
                certificateDTOs = new List<CertificateDTO>
                {
                    new() {Name = "VietDang", Email = "vietdang15956@gmail.com"},
                    new() {Name = "HuuThinh", Email = "thinhhuu@gmail.com"},
                    new() {Name = "LeChi", Email = "chilenguyen@gmail.com"},
                    new() {Name = "HuuThanh", Email = "thanhhuu@gmail.com"},
                    new() {Name = "Jackson", Email = "jack97@gmail.com"},
                }
            };

    }

        [TestMethod]
        public async Task Create_Certificate_Test()
        {
            var options = new RestClientOptions("https://api.certifier.io/v1/credentials");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Certifier-Version", "2022-10-26");
            request.AddHeader("authorization", "Bearer cfp_HCVTr3y9KRsLeUGT0BuKXcQmKXIRdiXmyN7z");
            request.AddJsonBody("{\"recipient\":{\"name\":\"Johnn Doe\",\"email\":\"john.doe@example.com\"},\"issueDate\":\"2022-01-01\",\"expiryDate\":\"2023-01-01\",\"customAttributes\":{\"custom.mentor\":\"Jane Doe\"},\"groupId\":\"01htecdrh8dzx9mp5xt6hmag25\"}", false);
            var response = await client.PostAsync(request);

        }
}
}