using hedomi.application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.Services___tharwat.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetProfileAsync(string userId);
        Task<bool> UpdateProfileAsync(string userId, UpdateUserDTO dto);
        Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<bool> DeleteAccountAsync(string userId, string password);

        // Admin-specific operations
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);

    }
}
