using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.Data.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Services.Interface
{
    public interface IAuthenticationServices
    {
        public Task<JwtAuhtResult> GetJWTTokenAsync(Users user);

        public JwtSecurityToken ReadJwtToken(string accessToken);

        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken JwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuhtResult> GetRefreshToken(Users User, JwtSecurityToken JwtToken, DateTime? ExpiresAt, string refreshToken);

        public Task<string> validateToken(string accessToken);


    }
}
