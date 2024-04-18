using AutoMapper;
using BACKEND.Common;
using BACKEND.Models;
using BACKEND.Models.Auth;
using BACKEND.Models.DTOs;
using BACKEND.Persistence;
using BACKEND.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Services  
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IMapper _mapper;
        private SafariDbContext _context;

        public UserRepository(SafariDbContext context, UserManager<User> userManager , SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager; _signInManager = signInManager; _mapper = mapper;
            _context = context;
        }

        public async Task<GetResponseDto<TokenInfo>> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var response = new GetResponseDto<TokenInfo>();
            var user = _mapper.Map<User>(userCreateDto);
            var result = await _userManager.CreateAsync(user, userCreateDto.Password);

            if (result.Succeeded)
            {
                response.Success = true; response.Message = "User Created";
                response.Content = await BuildToken(user); 
            }
            else
            {
                result.Errors.ToList().ForEach(x =>
                {
                    response.Message += x.Description + "\n";
                });
            }
            return response;
        }

        public async Task<GetResponseDto<TokenInfo>> LoginAsync(LoginDto loginDto)
        {
            var response = new GetResponseDto<TokenInfo>();
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                response.Message = "Invalid Credetianls";
            }

            var result = await _signInManager.PasswordSignInAsync(user,loginDto.Password, false, true);
            if (result.IsLockedOut) response.Message = "Your acoount is locked for any rason";
            if(result.Succeeded)
            {
                response.Success = true; response.Content = await BuildToken(user);
            }
            else
            {
                response.Message = "Invalid Credentials";
            }
            return response;
        }


        public async Task<DeleteResponseDto> DeleteAsync(UserDeleteDto userDeleteDto)
        {
            var response = new DeleteResponseDto();
            var user = await _userManager.FindByIdAsync(userDeleteDto.Id);
            if (user == null)
            {
                response.Message = "Invalid Credetianls";
            }

            var result = await _signInManager.PasswordSignInAsync(user,userDeleteDto.Password, false, true);
            if (result.IsLockedOut) response.Message = "Your acoount is locked for any rason";

            if (result.Succeeded)
            {
                response.Success = true; response.Message = "User Deleted";
                await _userManager.DeleteAsync(new User() { Id = userDeleteDto.Id }); await _context.SaveChangesAsync();
            }
            else
            {
                response.Message = "Invalid Credentials";
            }      
            return response;
        }

        public async Task<GetResponseDto<DataCollection<UserGetDto>>> GetAsync(List<Func<User, bool>> filter, int page, int take)
        {
            var response = new GetResponseDto<DataCollection<UserGetDto>>();
            try
            {
                var users = _context.Users.ToList();
                filter.ForEach(f => { users = users.Where(f).ToList(); });
                var usersMapped = users.Select(x => _mapper.Map<UserGetDto>(x));
                var result = await usersMapped.GetPagedAsync(page, take);

                response.Success = true;
                response.Message = "Success";
                response.Content = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GetResponseDto<UserGetDto>> GetByIdAsync(string id)
        {
            var response = new GetResponseDto<UserGetDto>();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                response.Message = "The user doesn't exist";
            }
            else
            {
                response.Success = true; response.Content = _mapper.Map<UserGetDto>(user);
            }
            return response;
        }

       
        public async Task<PostResponseDto<UserGetDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var response = new PostResponseDto<UserGetDto>();
            try
            {
                var user = _context.Users.Find(userUpdateDto.Id);
                user.Image = userUpdateDto.Image;
                user.Job = userUpdateDto.Job;
                user.Age = userUpdateDto.Age;
                user.FullName = userUpdateDto.FullName;
                user.UserName = userUpdateDto.Username;

                var result = _context.Users.Update(user);
                _context.SaveChanges();
                response.Success = true; response.Entity = _mapper.Map<UserGetDto>(result.Entity); 
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }




        private async Task<TokenInfo> BuildToken(User userInfo)
        {
            var claims = new List<Claim> //the claims are created
            {
                new Claim(JwtRegisteredClaimNames.NameId,userInfo.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName,userInfo.UserName),
            };

            foreach (var role in await _userManager.GetRolesAsync(userInfo))
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); //user roles have be added
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")); //for now the private key is matita
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds
            );

            return (new TokenInfo
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            }); //return the info token
        }

    }
}
