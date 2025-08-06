using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.Data.Helpers;
using SchoolProject.InfraStructure.Interface;
using SchoolProject.Services.Interface;
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
        //private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshtokens;
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        private readonly UserManager<Users> _userManager;
        #endregion

        #region Constructor
        public AuthenticationServices(JwtSettings jwtSettings,
            IRefreshTokenRepo refreshTokenRepo, UserManager<Users> userManager)
        {
            _jwtSettings = jwtSettings;
            //_UserRefreshtokens = new ConcurrentDictionary<string, RefreshToken>();
            _refreshTokenRepo = refreshTokenRepo;
            _userManager = userManager;
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

            //go to function to generate token
            //var Claim = GetClaims(user);
            //var jwtToken = new JwtSecurityToken(
            //    _jwtSettings.Issuer,
            //    _jwtSettings.Audience,
            //    Claim,
            //    expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
            //    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            //var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var (jwtToken, accessToken) = JwtGenerateToken(user);
            var refreshToken = GetRefreshToken(user.UserName);

            // Store the refresh token in the database or any persistent storage
            var UserResfeshToken = new UserRefreshToken
            {
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
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


        private (JwtSecurityToken, string) JwtGenerateToken(Users user)  // using tuple to return both the token and the access token string
        {
            var Claim = GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                Claim,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (jwtToken, accessToken);
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
            //_UserRefreshtokens.AddOrUpdate(userName, refreshToken, (key, oldValue) => refreshToken);
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
                 new Claim(nameof(UserClaimModels.Id), user.Id.ToString()),
                new Claim(nameof(UserClaimModels.UserName), user.UserName),
                new Claim(nameof(UserClaimModels.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimModels.Email), user.Email),



            };
            return Claim;

        }

        public async Task<JwtAuhtResult> GetRefreshToken(Users User, JwtSecurityToken JwtToken, DateTime? ExpiresAt, string refreshToken)
        {
            //Read token to get claims

            //var JwtToken = ReadJwtToken(accessToken);
            //if (JwtToken == null || !JwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            //{
            //    throw new ArgumentException("Algorithms is not Equal");
            //}

            ////var USername = JwtToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModels.UserName))?.Value;

            //if (JwtToken.ValidTo > DateTime.UtcNow)
            //{
            //    throw new ArgumentException("Token is not Expired");

            //}


            //// get USer
            //var userId = JwtToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModels.Id))?.Value;
            //var UserRefreshToken = await _refreshTokenRepo.GetTableNoTracking()
            //                                              .FirstOrDefaultAsync(x => x.Token == accessToken &&
            //                                              x.RefreshToken == refreshToken && x.UserId == int.Parse(userId));


            ////validation for token and refresh token

            //if (UserRefreshToken == null)
            //{
            //    throw new ArgumentException("Refresh Token is  not found");
            //}

            ////Token is Expired or not

            //if (UserRefreshToken.ExpiresAt < DateTime.UtcNow)
            //{
            //    // If the refresh token is expired, you can throw an exception or handle it as needed
            //    UserRefreshToken.IsRevoked = true;
            //    UserRefreshToken.IsUsed = false;
            //    await _refreshTokenRepo.UpdateAsync(UserRefreshToken);
            //    throw new ArgumentException("REfresh Token is  Expired");
            //}
            // Genertaate for Refresh token

            //var User = await _userManager.FindByIdAsync(userId);
            //if (User == null) throw new ArgumentException("User is  Not found ");


            var (JwtSecurityToken, NewToken) = JwtGenerateToken(User);

            var response = new JwtAuhtResult();

            response.AccessToken = NewToken;

            var RefreshTokenDTO = new RefreshToken();
            RefreshTokenDTO.UserName = JwtToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModels.UserName))?.Value;
            RefreshTokenDTO.refreshToken = refreshToken;
            RefreshTokenDTO.ExpireAt = (DateTime)ExpiresAt;
            response.refreshToken = RefreshTokenDTO;

            return response;
        }


        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken), "Access token cannot be null or empty.");
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;





        }

        public Task<string> validateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            //var response = handler.ReadJwtToken(accessToken);

            var parameter = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            // Validate the
            try
            {

                var Validate = handler.ValidateToken(accessToken, parameter, out SecurityToken validatedToken);

                if (Validate == null)
                {
                    throw new ArgumentException("Invalid JWT token.", nameof(accessToken));
                }
                return Task.FromResult("Token is valid");

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid JWT token.", nameof(accessToken), ex);
            }

        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken JwtToken, string AccessToken, string RefreshToken)
        {
            if (JwtToken == null || !JwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {

                return ("AlgorithmsIsNotEqual", null);
            }

            //var USername = JwtToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModels.UserName))?.Value;

            if (JwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenisnotExpired", null);

            }


            // get USer
            var userId = JwtToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModels.Id))?.Value;
            var UserRefreshToken = await _refreshTokenRepo.GetTableNoTracking()
                                                          .FirstOrDefaultAsync(x => x.Token == AccessToken &&
                                                          x.RefreshToken == RefreshToken && x.UserId == int.Parse(userId));


            //validation for token and refresh token

            if (UserRefreshToken == null)
            {
                return ("RefreshTokenisnotfound", null);
            }

            //Token is Expired or not

            if (UserRefreshToken.ExpiresAt < DateTime.UtcNow)
            {
                // If the refresh token is expired, you can throw an exception or handle it as needed
                UserRefreshToken.IsRevoked = true;
                UserRefreshToken.IsUsed = false;
                await _refreshTokenRepo.UpdateAsync(UserRefreshToken);
                return ("REfreshTokenisExpired", null);
            }
            var expiredAt = UserRefreshToken.ExpiresAt;

            return (userId, expiredAt);

        }
        #endregion
    }
}
