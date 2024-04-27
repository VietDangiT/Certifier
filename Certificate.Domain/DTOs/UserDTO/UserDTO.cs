using Certificate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Domain.DTOs.UserDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string CourseName{ get; set; }
    }
}
