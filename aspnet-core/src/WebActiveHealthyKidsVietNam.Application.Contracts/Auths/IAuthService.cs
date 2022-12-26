
using System.Threading.Tasks;

namespace WebActiveHealthyKidsVietNam.Auths
{
    public interface IAuthService
    {
        /// <summary>
        /// tạo tai khoan
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UserCreateAsync(UserCreateDto dto);
        /// <summary>
        /// login
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<SignInResultDto> SignInAsync(SignInDto dto);
        /// <summary>
        /// thay doi mat khau
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task ChangePasswordAsync(ChangePasswordDto dto);
        
    }
}
