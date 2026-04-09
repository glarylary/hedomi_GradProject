using hedomi.application.DTOs.UserDTOs;
using hedomi.application.Services_tharwat.Interfaces;
using hedomi.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hedomi.application.Services_tharwat.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return null;

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isPasswordValid) return null;

            var token = GenerateJwtToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                Name = user.Name,
                Email = user.Email!
            };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}