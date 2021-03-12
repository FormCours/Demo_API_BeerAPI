using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Demo_API_Intro.Startup))]

namespace Demo_API_Intro
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Pour plus d'informations sur la configuration de votre application, visitez https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions()
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = ConfigurationManager.AppSettings["Token_Issue"],
                        ValidateAudience = true,
                        ValidAudience = ConfigurationManager.AppSettings["Token_Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Token_Key"]))
                    }
                });
        }
    }
}
