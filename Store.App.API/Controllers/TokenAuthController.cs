using System;
//using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Store.App.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Store.App.Model.SYS;

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly StoreAppContext _context;
        public TokenAuthController(StoreAppContext context)
        {
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody]sys_user user)
        {
            //User existUser = UserStorage.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            var existUser =
                _context.SysUsers.FirstOrDefault(f => f.UserId == user.UserId && f.Pwd == user.Pwd);
            if (existUser != null)
            {

                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var token = GenerateToken(existUser, expiresIn);

                return Json(new RequestResult
                {
                    State = RequestState.Success,
                    Data = new
                    {
                        requertAt = requestAt,
                        expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                        tokeyType = TokenAuthOption.TokenType,
                        accessToken = token
                    }
                });
            }
            return Json(new RequestResult
            {
                State = RequestState.Failed,
                Msg = "�û������������"
            });
        }

        private string GenerateToken(sys_user user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserId, "TokenAuth"),
                new[] { new Claim("ID", user.UserId)}
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult CheckSession()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return Json(new RequestResult
            {
                State = RequestState.Success,
                Data = new { UserName = claimsIdentity.Name }
            });
        }
    }
}

