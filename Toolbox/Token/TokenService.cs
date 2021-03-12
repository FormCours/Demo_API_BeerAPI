using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Toolbox.Token
{
    // Installer le nuget package : System.IdentityModel.Tokens.Jwt
    //                              System.Configuration.ConfigurationManager

    public static class TokenService
    {
        public static TokenGenerated GenerateToken(TokenData data)
        {
            // Recuperation des données de configuration pour le token
            string issue = ConfigurationManager.AppSettings["Token_Issue"];
            string audience = ConfigurationManager.AppSettings["Token_Audience"];
            string secretKey = ConfigurationManager.AppSettings["Token_Key"];

            if(string.IsNullOrWhiteSpace(issue) || string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(secretKey))
            {
                throw new ConfigurationErrorsException("Config need : Token_Issue, Token_Audience, Token_Key");
            }


            // Création d'un objet de sécurité .Net => "ClaimsIdentity"
            ClaimsIdentity claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, data.UserId),
                new Claim(ClaimTypes.Email, data.Email),
                new Claim(ClaimTypes.Role, data.Role)
            });

            // Credential pour signer le token JWT
            byte[] key = Encoding.UTF8.GetBytes(secretKey);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Generation du JWT
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issue,
                Audience = audience,
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.CreateJwtSecurityToken(tokenDescriptor);

            // Sérialisation du token 
            string token = handler.WriteToken(jwtSecurityToken);

            return new TokenGenerated()
            {
                Token = token,
                ExpireDate = (DateTime)tokenDescriptor.Expires
            };
        }
    }
}