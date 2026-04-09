using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using hedomi.application.DTOs.UserDTOs;

namespace hedomi.application.Services_tharwat.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO dto);
    }
}