using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplicationEmpleadosOauth.Helpers
{
    public class HelperActionServicesOauth
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? SecretKey { get; set; }

        public HelperActionServicesOauth(IConfiguration configuration)
        {
            Issuer = configuration.GetValue<string>("ApiOauth:Issuer")!;
            Audience = configuration.GetValue<string>("ApiOauth:Audience")!;
            SecretKey = configuration.GetValue<string>("ApiOauth:SecretKey")!;
        }

        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] key = Encoding.UTF8.GetBytes(SecretKey!);
            return new SymmetricSecurityKey(key);
        }

        public Action<JwtBearerOptions> GetJwtBearerOptions()
        {
            Action<JwtBearerOptions> jwtOptions =
                new Action<JwtBearerOptions>(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Issuer,
                        ValidAudience = Audience,
                        IssuerSigningKey = this.GetKeyToken(),
                    };
                });
            return jwtOptions;
        }

        public Action<AuthenticationOptions> GetAuthenticationSchema()
        {
            Action<AuthenticationOptions> authenticationSchema =
                new Action<AuthenticationOptions>(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                });
            return
                authenticationSchema;
        }
    }
}
