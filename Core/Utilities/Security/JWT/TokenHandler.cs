using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration Configuration;

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Token CreateToken(Guid userId, string email, string roleId)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: setClaims(userId, email, roleId)
            );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }

        public IEnumerable<Claim> setClaims(Guid userId , string email , string roleId)
        {
            var claims = new List<Claim>
            {
                new Claim("userId" , userId.ToString()),
                new Claim("email" , email),
                new Claim("roleId" , roleId)
            };
            return claims;
        }
    }
}
