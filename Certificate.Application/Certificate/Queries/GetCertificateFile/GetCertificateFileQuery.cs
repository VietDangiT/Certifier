using Certificate.Domain.Entities;
using Certificate.Domain.IServices;
using Certificate.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Application.Certificate.Queries.GetCertificateFile
{
    public class GetCertificateFileQuery : IRequest<byte[]>
    {
        public int userId { get; set; }
    }

    public class GetCertificateFileHandler : IRequestHandler<GetCertificateFileQuery, byte[]>
    {
        private readonly ICertificateService _certificateService;
        public GetCertificateFileHandler(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        async Task<byte[]> IRequestHandler<GetCertificateFileQuery, byte[]>.Handle(GetCertificateFileQuery request, CancellationToken cancellationToken)
        {
            return await _certificateService.GetCredentialFile(request.userId);
        }
        //sas
    }
}
