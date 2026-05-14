using hedomi.application.DTOs.UserDTOs;
using hedomi.application.Services___tharwat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("User ID not found in claims.");


        [HttpGet("user/profile")]
        public async Task<IActionResult> GetProfile()
        {
            var result = await _userService.GetProfileAsync(GetUserId());
            if (result == null) return NotFound("User not found");
            return Ok(result);
        }

        [HttpPut("user/profile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserDTO dto)
        {
            var sucess = await _userService.UpdateProfileAsync(GetUserId(), dto);
            if (!sucess) return BadRequest("Failed to update profile");
            return Ok("Profile updated successfully");
        }

        [HttpDelete("user/account")]
        public async Task<IActionResult> DeleteAccount(string password)
        {
            var sucess = await _userService.DeleteAccountAsync(GetUserId(), password);
            if (!sucess) return BadRequest("Failed to delete account");
            return Ok("Account deleted successfully");
        }

        [HttpPut("user/change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            var sucess = await _userService.ChangePasswordAsync(GetUserId(), dto);
            if (!sucess) return BadRequest("Failed to change password");
            return Ok("Password changed successfully");
        }

        //admin specific operations

        [HttpGet("admin/users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("admin/user/{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result == null) return NotFound("User not found");
            return Ok(result);
        }

    }
}
