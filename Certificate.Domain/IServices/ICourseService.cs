using Certificate.Domain.DTOs.CourseDTO;

namespace Certificate.Domain.IServices
{
    public interface ICourseService
    {
        public  Task<IReadOnlyList<CourseDTO>> GetCourses();
    }
}
