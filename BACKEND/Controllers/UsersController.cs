using BACKEND.Common;
using BACKEND.Models.Auth;
using BACKEND.Models.DTOs;
using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        [HttpPost("SignUp")] //SignUp
        public async Task<ActionResult<GetResponseDto<TokenInfo>>> SignUp(UserCreateDto userCreateDto)
        {
            var response = await _userRepository.CreateUserAsync(userCreateDto);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("LogIn")] //Login
        public async Task<ActionResult<GetResponseDto<TokenInfo>>> LogIn(LoginDto loginDto)
        {
            var response = await _userRepository.LoginAsync(loginDto);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetResponseDto<DataCollection<User>>>> Get(int page = 1, int take = 10)
        {
            List<Func<User, bool>> filter = new List<Func<User, bool>>() { x => x.Id == x.Id };
            var response = await _userRepository.GetAsync(filter, page, take);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetResponseDto<TokenInfo>>> Get(string id)
        {
            var response = await _userRepository.GetByIdAsync(id);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetResponseDto<TokenInfo>>> Delete(string id, [FromQuery] string password)
        {
            var response = await _userRepository.DeleteAsync(new UserDeleteDto() { Id = id, Password = password });
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<PostResponseDto<UserGetDto>>> Update(UserUpdateDto userUpdateDto)
        {
            var response = await _userRepository.UpdateAsync(userUpdateDto);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }




    }

}
