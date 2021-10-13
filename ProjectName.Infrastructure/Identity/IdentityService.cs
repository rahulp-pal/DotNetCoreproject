using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Common.Models;
using ProjectName.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityService> _logger;
        public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                               IEmailSender emailSender, IMapper mapper, ILogger<IdentityService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<UserDto>> GetUserListAsync()
        {
            var userList = await _userManager.Users.ToListAsync();
            List<UserDto> users = _mapper.Map<List<UserDto>>(userList);
            return users;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(CreateUserDto userInput)
        {
            var user = new IdentityUser { UserName = userInput.Email, Email = userInput.Email };
            var result = await _userManager.CreateAsync(user, userInput.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created");

                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = $"http://localhost:52041/api/account/confirmemail?id={user.Id}&code={code}";
                await _emailSender.SendEmailAsync(
                    userInput.Email,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            }
            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(IdentityUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<string> AuthenticateUser(LoginDto userInput)
        {
            var signinResult = await _signInManager.PasswordSignInAsync(userInput.Email, userInput.Password, userInput.RememberMe, lockoutOnFailure: true);
            var user = await _userManager.FindByNameAsync(userInput.Email);
            if (signinResult.Succeeded)
            {
                _logger.LogInformation("User logged in");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return "succeeded";
            }
            if (signinResult.IsNotAllowed)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    _logger.LogInformation("Email isn't confirmed");
                    return "Email isn't confirmed";
                }

                if (!await _userManager.IsPhoneNumberConfirmedAsync(user))
                {
                    _logger.LogInformation("Phone Number isn't confirmed");
                    return "Phone Number isn't confirmed";
                }
            }
            else if (signinResult.IsLockedOut)
            {
                _logger.LogInformation("Account is locked out");
                return "Account is locked out";
            }
            else if (signinResult.RequiresTwoFactor)
            {
                _logger.LogInformation("2FA required");
                return "2FA required";
            }
            else
            {
                if (user == null)
                {
                    _logger.LogInformation("Username is incorrect");
                    return "Username is incorrect";
                }
                else
                {
                    _logger.LogInformation("Password is incorrect");
                    return "Password is incorrect";
                }
            }
            return user.Id;
        }

        public async Task<string> ForgotPassword(ForgotPasswordDto userInput)
        {
            var user = await _userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return "ForgotPasswordConfirmation";
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string callbackUrl = $"http://localhost:52041/api/account/resetPassword?id={user.Id}&code={token}";
            await _emailSender.SendEmailAsync(
                userInput.Email,
                "Reset Password",
                $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            return user.Id;
        }
        
        public async Task<string> ResetPassword(ResetPasswordDto userInput)
        {
            var user = await _userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return "ResetPasswordConfirmation";
            }
            var result = await _userManager.ResetPasswordAsync(user, userInput.Code, userInput.Password);
            if (result.Succeeded)
            {
                return "ResetPasswordConfirmation";
            }
            return user.Id;
        }
        
        public async Task<string> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return "/Index";
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return $"Unable to load user with ID '{userId}'";
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }
            return user.Id;
        }
        
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return "User logged out.";
        }

        
    }
}
