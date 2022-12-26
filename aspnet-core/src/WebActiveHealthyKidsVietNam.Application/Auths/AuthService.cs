using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Identity;
using WebActiveHealthyKidsVietNam.Options;

namespace WebActiveHealthyKidsVietNam.Auths
{
    [RemoteService(false)]
    public class AuthService : WebActiveHealthyKidsVietNamAppService, IAuthService
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly JwtSettings _JwtSettings;
        public AuthService(IdentityUserManager identityUserManager, JwtSettings jwtSettings)
        {
            _identityUserManager = identityUserManager;
            _JwtSettings = jwtSettings;
        }
        public async Task ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user =await  _identityUserManager.FindByIdAsync(CurrentUser.Id.ToString());
            var isAuthentication = await _identityUserManager.CheckPasswordAsync(user, dto.OldPassword);
            if(!isAuthentication)
            {
                throw new BusinessException("Vui long nhap dung mat khau");
            }
            await _identityUserManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        }

        public async Task<SignInResultDto> SignInAsync(SignInDto dto)
        {
            var isEmail= dto.UsernameOrEmail.Contains("@");
            IdentityUser user=null;
            if(isEmail)
            {
                user = await _identityUserManager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _identityUserManager.FindByNameAsync(dto.UsernameOrEmail);
            }
            
            var isAuthentication= await _identityUserManager.CheckPasswordAsync(user,dto.Password);
            if (isAuthentication)
            {
                //
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_JwtSettings.Secret);
                var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("iss","https://localhost:44354")

                    };
                // add all claims of userIdentity
                var userClaim = await _identityUserManager.GetClaimsAsync(user);
                claims.AddRange(userClaim);
               
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.Add(_JwtSettings.TokenLifeTime),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);


                //
                return new SignInResultDto
                {
                    AccessToken = tokenHandler.WriteToken(token),
                    Email = user.Email,
                    Username = user.UserName
                };
            }
            else
            {
                throw new BusinessException("Cut");
            }
        }

        public async Task UserCreateAsync(UserCreateDto dto)
        {
            var user = new IdentityUser(Guid.NewGuid(), dto.UserName, dto.Email);
            await _identityUserManager.CreateAsync(user, dto.Password);
        }
    }
}
