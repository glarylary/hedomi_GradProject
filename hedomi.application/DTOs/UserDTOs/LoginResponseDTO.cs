using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.UserDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
