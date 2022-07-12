using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CallBoardNix.Extentions
{
    public class AuthOptions
    {
        public const string ISSUER = "https://localhost:7009";
        public const string AUDIENCE = ISSUER;
        public const string KEY = "SecuretyCal1BoardN!xk2y";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
