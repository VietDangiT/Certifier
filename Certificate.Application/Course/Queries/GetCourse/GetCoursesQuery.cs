using Certificate.Domain.DTOs.CourseDTO;
using Certificate.Domain.Responses;
using MediatR;

namespace Certificate.Application.Course.Queries.GetCourse
{
    public class GetCoursesQuery : IRequest<BaseResponse<IReadOnlyList<CourseDTO>>>
    {

    }
}
