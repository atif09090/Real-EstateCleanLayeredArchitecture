namespace Real_EstateCleanLayeredArchitecture.DTOs
{
    public class LoginResponseDto : BaseResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
