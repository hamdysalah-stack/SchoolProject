namespace SchoolProject.Data.Helpers
{
    public class JwtAuhtResult
    {
        public string AccessToken { get; set; }
        public RefreshToken refreshToken { get; set; }
    }

    public class RefreshToken
    {
        public string UserName { get; set; }
        public string refreshToken { get; set; }

        public DateTime ExpireAt { get; set; }

    }
}
