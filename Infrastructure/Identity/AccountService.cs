using Aplication.Identity;
using Microsoft.AspNetCore.Identity;
using Shared;

namespace Infrastructure.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public SignInManager<IdentityUser> SignInManager { get; }

        public async Task<Result> Signin(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Result.Success();
            }

            return Result.Failure(IdentityErrors.InvalidUserOrPassword());
        }

        public async Task<Result> Signup(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return Result.Success();
            }

            return Result.Failure(IdentityErrors.NotCreated());
        }

        public async Task Signout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
