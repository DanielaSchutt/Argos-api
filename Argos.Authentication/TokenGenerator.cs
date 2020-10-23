using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Argos.Authentication
{
    public class TokenGenerator
    {   
        private static string TokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY");

        public static string BuildToken(long id, string accessLevel)
        {
            var claims = new[] {
                new Claim("id", Convert.ToString(id)),
                new Claim(ClaimTypes.Role, accessLevel)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string ReBuildToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            token = token.Replace("Bearer", "");
            token = token.Trim();

            var tokenAntigo = handler.ReadToken(token) as JwtSecurityToken;

            var id = tokenAntigo.Claims.First(claim => claim.Type == "id").Value;
            var accessLevel = tokenAntigo.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("id", Convert.ToString(id)),
                new Claim(ClaimTypes.Role, accessLevel)
            };

            var novoToken = new JwtSecurityToken(
                null,
                null,
                claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(novoToken);
        }

        //public static int GetIdCliente (string token)
        //{
            //var handler = new JwtSecurityTokenHandler();

            //token = token.Replace("Bearer", "");
            //token = token.Trim();

            //var tokenAntigo = handler.ReadToken(token) as JwtSecurityToken;

            //var id = tokenAntigo.Claims.First(claim => claim.Type == "id").Value;

            //return Convert.ToInt32(id);
        //}
    }
}