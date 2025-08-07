using Real_EstateCleanLayeredArchitecture.DTOs;

namespace Real_EstateCleanLayeredArchitecture.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserRegisterDto dto);
        Task<LoginResponseDto> LoginAsync(UserLoginDto dto);
    }

}
