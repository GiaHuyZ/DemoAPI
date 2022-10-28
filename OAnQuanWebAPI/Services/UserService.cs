using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OAnQuanWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OAnQuanWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManger;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly OAnQuanGameContext _context;

        public UserService( UserManager<UserAccount> userManager, 
                            SignInManager<UserAccount> signInManager,
                            RoleManager<UserRole> roleManager,
                            IConfiguration configuration,
                            OAnQuanGameContext context)
        {
            _userManager = userManager;
            _signInManger = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return null;
            }
            var result = await _signInManger.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role , string.Join(";",roles)),
                new Claim("NickName" , user.NickName),
                new Claim("UserName" , user.UserName),
                new Claim("Id" , user.Id.ToString()),
                new Claim("Status" , user.Status ),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], 
                                             claims, expires: DateTime.Now.AddHours(3), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new UserAccount()
            {
                UserName = request.UserName,
                NickName = request.NickName,
                Email = request.Email,
                Avatar = request.Avatar,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Status = "Active",
            };

            var userResult = await _userManager.CreateAsync(user, request.Password);
            if (userResult.Succeeded)
            {
                var userRole = _roleManager.FindByNameAsync("User").Result;

                if (userRole != null)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, userRole.Name);
                    if (roleResult.Succeeded)
                    {
                        return true;
                    }                  
                }
            }
            return false;
        }
    }
}
