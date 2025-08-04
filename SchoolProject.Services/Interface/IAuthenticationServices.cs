using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Services.Interface
{
    public interface IAuthenticationServices
    {
        public Task<JwtAuhtResult> GetJWTTokenAsync(Users user);
    }
}
