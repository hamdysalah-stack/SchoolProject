using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.Data.Helpers;
using SchoolProject.InfraStructure.Interface;
using SchoolProject.Services.Interface;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Services.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {



        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshtokens;
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        #endregion

        #region Constructor
        public AuthenticationServices(JwtSettings jwtSettings, IRefreshTokenRepo refreshTokenRepo)
        {
            _jwtSettings = jwtSettings;
            _UserRefreshtokens = new ConcurrentDictionary<string, RefreshToken>();
            _refreshTokenRepo = refreshTokenRepo;
        }
        #endregion


        #region Handle Functions
        public async Task<JwtAuhtResult> GetJWTTokenAsync(Users user)
        {

            //var Claim = new List<Claim>()
            //{
            //    new Claim(nameof(UserClaimModels.UserName), user.UserName),
            //    new Claim(nameof(UserClaimModels.PhoneNumber), user.PhoneNumber),
            //    new Claim(nameof(UserClaimModels.Email), user.Email),

            //};
            var Claim = GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                Claim,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = GetRefreshToken(user.UserName);

            // Store the refresh token in the database or any persistent storage
            var UserResfeshToken = new UserRefreshToken
            {
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = false,
                IsRevoked = false,
                JWTId = jwtToken.Id,
                RefreshToken = refreshToken.refreshToken,
                Token = accessToken,
                UserId = user.Id

            };
            // Save the refresh token to the database
            var UserRefreshTokenresult = await _refreshTokenRepo.AddAsync(UserResfeshToken);
            //return Task.FromResult(accessToken);
            var response = new JwtAuhtResult();

            response.AccessToken = accessToken;
            response.refreshToken = refreshToken;

            return response;

        }

        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                UserName = userName,
                refreshToken = GenerateRefershToken(),
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate)
            };
            // Store the refresh token in the dictionary
            _UserRefreshtokens.AddOrUpdate(userName, refreshToken, (key, oldValue) => refreshToken);
            return refreshToken;
        }


        private string GenerateRefershToken()
        {
            var randomNumber = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

        private List<Claim> GetClaims(Users user)
        {
            var Claim = new List<Claim>()
            {
                new Claim(nameof(UserClaimModels.UserName), user.UserName),
                new Claim(nameof(UserClaimModels.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimModels.Email), user.Email),



            };
            return Claim;

        }
        #endregion
    }
}
