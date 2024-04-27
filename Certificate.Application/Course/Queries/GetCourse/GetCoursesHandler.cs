using Certificate.Domain.DTOs.CourseDTO;
using Certificate.Domain.IServices;
using Certificate.Domain.Responses;
using MediatR;

namespace Certificate.Application.Course.Queries.GetCourse
{
    public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, BaseResponse<IReadOnlyList<CourseDTO>>>
    {
        private readonly ICourseService _courseService;

        public GetCoursesHandler(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public async Task<BaseResponse<IReadOnlyList<CourseDTO>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var returnData = await _courseService.GetCourses();
            return new BaseResponse<IReadOnlyList<CourseDTO>>()
            {
                Success = true,
                Data = returnData
            };
        }
    }
}
