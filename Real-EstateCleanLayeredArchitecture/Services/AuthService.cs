using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Real_EstateCleanLayeredArchitecture.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<string> RegisterAsync(UserRegisterDto dto)
        {
            if (await _userRepo.GetByEmailAsync(dto.Email) != null)
                throw new Exception("User already exists");

            var user = new User { Email = dto.Email };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);
            await _userRepo.AddUserAsync(user);
            return GenerateJwt(user);
        }

        public async Task<LoginResponseDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null)
                return new LoginResponseDto() { Email = dto.Email, IsSuccess = false, Message = "Email not found" };

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result != PasswordVerificationResult.Success)
                return new LoginResponseDto() { Email = dto.Email, IsSuccess = false, Message = "Invalid credentials" };
           
            var token = GenerateJwt(user);
            return new LoginResponseDto() { Email = dto.Email, IsSuccess = false, Message = "Login successful", Token = token };
        }

        private string GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
