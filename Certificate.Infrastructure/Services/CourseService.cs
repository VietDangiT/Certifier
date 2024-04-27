using Certificate.Domain.DTOs.CourseDTO;
using Certificate.Domain.IRepositories;
using Certificate.Domain.IServices;

namespace Certificate.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IReadOnlyList<CourseDTO>> GetCourses()
        {
            var course = await _courseRepository.GetAllAsync();
            return course.Select(x => new CourseDTO
            {
                Id = x.Id,
                courseName = x.courseName,
                groupId = x.groupId,
                headSign = x.headSign,
                mentorSign = x.mentorSign
            }).ToList();
        }
    }
}
