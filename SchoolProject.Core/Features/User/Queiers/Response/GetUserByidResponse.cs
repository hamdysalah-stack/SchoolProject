namespace SchoolProject.Core.Features.User.Queiers.Response
{
    public class GetUserByidResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Address { get; set; }

        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
