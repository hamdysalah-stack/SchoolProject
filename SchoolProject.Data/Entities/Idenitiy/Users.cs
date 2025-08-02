using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Idenitiy
{
    public class Users : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
