using Certificate.Domain.DTOs.UserDTO;
using Certificate.Domain.IServices;
using Certificate.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Application.Certificate.Queries.GetUsers
{
    public class GetUsersWithPagination : IRequest<BaseResponse<IReadOnlyList<UserDTO>>>
    {
        public int courseId { get; set; }
    }

    public class GetUsersHandler : IRequestHandler<GetUsersWithPagination, BaseResponse<IReadOnlyList<UserDTO>>>
    {
        private readonly IUserService _userService;

        public GetUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<IReadOnlyList<UserDTO>>> Handle(GetUsersWithPagination request, CancellationToken cancellationToken)
        {
            var returnData = await _userService.GetUsers(request.courseId);
            return new BaseResponse<IReadOnlyList<UserDTO>>()
            {
                Success = true,
                Data = returnData
            };
        }
    }
}
