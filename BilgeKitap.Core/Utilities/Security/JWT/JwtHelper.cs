using BilgeKitap.Core.Entities.Concrete;
using BilgeKitap.Core.Extensions;
using BilgeKitap.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BilgeKitap.Core.Utilities.Security.JWT
{

    public class JwtHelper : ITokenHelper
    {
      
        //IConfiguration=AppSettings dosyasını okumaya yarıyor.
        public IConfiguration Configuration { get; }

        //Appsettings de okunan degerleri TokenOptions'a atanıyor.
        private TokenOptions _tokenOptions;

        //Token ne zaman geçersizleşecek.
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //Appsettings'teki "TokenOptions" sectionunu al ve TokenOptions sınıfıyla eşleştir.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Token ne zaman bitecek.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            //Buradaki kısım TokenOptions'dan gelen Securitykey'i  SecurityKey(Encrption) formatına dönüştürecek.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //SigningCredentials=Hangi anahtar ve algoritma kullanılacak.
            var signingCredentials = SigninCredentialsHelper.CreateSigningCredentials(securityKey);
            //Hangi kullanıcı,hangi yetkiyle ve neyi kullanarak.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        //JWT oluşturuyor.
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}

