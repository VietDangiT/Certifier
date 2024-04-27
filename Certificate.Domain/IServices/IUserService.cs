using Certificate.Domain.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Domain.IServices
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDTO>> GetUsers(int courseId);

    }
}
