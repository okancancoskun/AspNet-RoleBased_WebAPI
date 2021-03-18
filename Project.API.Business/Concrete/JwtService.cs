using Microsoft.IdentityModel.Tokens;
using Project.API.Business.Interfaces;
using Project.API.Business.StringInfos;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.API.Business.Concrete
{
    public class JwtService : IJwtService
    {
        public string GenerateJwt(AppUser user, Role role)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtInfo.Issuer,
                audience: JwtInfo.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.TokenExp),
                signingCredentials: signingCredentials,
                claims: GetClaims(user, role)
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser user, Role role)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
            return claims;
        }
    }
}
