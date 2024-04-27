using Certificate.Domain.DTOs.UserDTO;
using Certificate.Domain.Entities;
using Certificate.Domain.IRepositories;
using Certificate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Certificate.Infrastructure.Repositories
{
    public class CertificateRepository : Repository<UserInfo>, ICertificateRepository
    {
        protected readonly ApplicationDbContext _context;
        public CertificateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UserInfo> getUsers(int courseId)
        {
            return _context.UserInfos.Where(x => x.CourseId == courseId);
        }
    }
}
