using Certificate.Domain.Entities;

namespace Certificate.Domain.IRepositories
{
    public interface ICertificateRepository : IRepository<UserInfo>
    {
        public IQueryable<UserInfo> getUsers(int courseId);
    }
}
