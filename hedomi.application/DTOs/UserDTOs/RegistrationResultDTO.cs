namespace hedomi.application.DTOs.UserDTOs
{
    public class RegistrationResultDTO
    {
        public bool Succeeded { get; set; }
        public LoginResponseDTO? Login { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}