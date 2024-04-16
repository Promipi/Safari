using static Azure.Core.HttpHeader;
using BACKEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND.Common;
using BACKEND.Models.DTOs;
using BACKEND.Models.Auth;


namespace BACKEND.Services
{
    public partial interface IUserRepository
    {
        public Task<GetResponseDto<DataCollection<UserGetDto>>> GetAsync(List<Func<User, bool>> filter, int page, int take);

        public Task<PostResponseDto<UserGetDto>> UpdateAsync(UserUpdateDto helpUpdateDto);

        public Task<DeleteResponseDto> DeleteAsync(UserDeleteDto userDeleteDto);

        public Task<GetResponseDto<UserGetDto>> GetByIdAsync(string id);
    }

    public partial interface IUserRepository
    {
        public Task<GetResponseDto<TokenInfo>> LoginAsync(LoginDto loginDto);

        public Task<GetResponseDto<TokenInfo>> CreateUserAsync(UserCreateDto userCreateDto);
    }
   
}
