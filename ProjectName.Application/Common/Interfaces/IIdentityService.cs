using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Models;
using ProjectName.Application.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectName.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<IList<UserDto>> GetUserListAsync();
        Task<string> GetUserNameAsync(string userId);
        Task<(Result Result, string UserId)> CreateUserAsync(CreateUserDto userInput);
        Task<Result> DeleteUserAsync(string userId);
        Task<string> AuthenticateUser(LoginDto userInput);
        Task<string> ForgotPassword(ForgotPasswordDto userInput);
        Task<string> ResetPassword(ResetPasswordDto userInput);
        Task<string> ConfirmEmail(string userId, string code);
        Task<string> Logout();
    }
}
