using Microsoft.IdentityModel.Tokens;
using MvcCoreCryptography.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MvcCoreCryptography.Helpers
{
    public class HelperTools
    {
        RepositoryUsers repository;
        public HelperTools(RepositoryUsers repository)
        {
            this.repository = repository;
        }

        public bool IsValidUser(string email, string password)
        {
            if (repository.LogIn(email, password) == null)
            {
                return false;
            }
            return true;
        }

        public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("HOLA");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
