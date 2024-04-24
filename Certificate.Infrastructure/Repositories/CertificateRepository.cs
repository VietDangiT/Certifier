using Certificate.Domain.Entities;
using Certificate.Domain.IRepositories;
using Certificate.Infrastructure.Data;

namespace Certificate.Infrastructure.Repositories
{
    public class CertificateRepository : Repository<UserInfo>, ICertificateRepository
    {
        protected readonly ApplicationDbContext _context;
        public CertificateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
