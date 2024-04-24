using Certificate.Domain.Entities;
using Certificate.Domain.IRepositories;
using Certificate.Infrastructure.Data;

namespace Certificate.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        protected ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
