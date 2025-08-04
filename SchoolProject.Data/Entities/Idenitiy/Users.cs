using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Idenitiy
{
    public class Users : IdentityUser<int>
    {

        public Users()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        [InverseProperty("User")]
        //[InverseProperty(nameof(UserRefreshToken.User))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
