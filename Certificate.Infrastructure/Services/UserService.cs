using Certificate.Domain.DTOs.UserDTO;
using Certificate.Domain.IRepositories;
using Certificate.Domain.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ICertificateRepository _certificateRepository;

        public UserService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<IReadOnlyList<UserDTO>> GetUsers(int courseId)
        {
            var returnData = _certificateRepository.getUsers(courseId);
            return await returnData.Select(x => new UserDTO
            {
                Id = x.Id,
                name = x.name,
                email = x.email,
                CourseName = x.Course.courseName
            }).ToListAsync();
        }
    }
}
