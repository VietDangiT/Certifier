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
                                                .ReturnsAsync(new List<RestResponse>());

            var certificateService = mockCertificateService.Object;

            var result =await  certificateService.CreateCertificates(userList);

            Assert.AreEqual(5, result.Count);
        }

        private CertificateRequest GetUserList()
        {
            return new CertificateRequest
            {
                courseId = "3",
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
}
}