using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities.Idenitiy
{
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public string JWTId { get; set; } = string.Empty;

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserRefreshTokens")]

        //[InverseProperty(nameof(User.UserRefreshTokens))]
        public virtual Users User { get; set; } = null!;


    }
}
