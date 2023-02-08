using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QlickAndTestApi.BusinessObjects;
using QlickAndTestApi.Data;
using QlickAndTestApi.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static QlickAndTestApi.Controllers.AuthenticationController;

namespace QlickAndTestApi.Services
{
    public class AuthenticationService : Microsoft.AspNetCore.Mvc.ControllerBase, IAuthenticationService
    {
        private readonly DataContext _context;
        public AuthenticationService(DataContext context)
        {
            _context = context;
        }

        public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
        {
            string token = "";
            var user = _context.Identity.Where(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            token = GenerateJSONWebToken(user);
            user.Password = "";
            var loginResponse = new LoginResponse
            {
                user = user,
                token = token
            };
            return Ok(loginResponse);

        }

        public async Task<ActionResult<Identity>> AddNewUser(ApplyJobRequest request)
        {
            if (_context.Identity == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }
            if (_context.Identity.Where(x => x.Email == request.Email).Any())
            {
                return Problem("Email Already Taken");
            }

            var verificationCode = GenNumber(00000, 9999999);


            return Ok("");
        }


        public static int GenNumber(int min = 0, int max = int.MaxValue)
        {
            var Random = new Random();
            return Random.Next(min, max);
        }

        private string GenerateJSONWebToken(Identity userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Password),
                new Claim("DateOfJoing", new DateTime().ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (userInfo.Email == "test@gmail.com")
            {
                claims.Add(new Claim("Role", "admin"));

            }
            else
            {
                claims.Add(new Claim("Role", "user"));

            }
            var token = new JwtSecurityToken("https://localhost:44366",
              "https://localhost:44366",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
