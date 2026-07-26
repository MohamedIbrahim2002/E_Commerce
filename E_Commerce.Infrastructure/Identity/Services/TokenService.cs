using E_Commerce.Application.Services.Contracts;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> CreateTokenAsync(string userId, string email, string userName, IReadOnlyList<string> roles, CancellationToken ct = default)
        {
            // Header[alg, typ]

            // Payload[claims]

            // Signature (secret Key)

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.GivenName, userName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretkey = "MySecretKey123MySecretKey123MySecretKey123MySecretKey123MySecretKey123!";

            var securtyritKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey)); 

            var jwtToken = new JwtSecurityToken(
                issuer: "https://localhost:7136",  
                audience: "MyOnlineStore",
                claims:claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(securtyritKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
