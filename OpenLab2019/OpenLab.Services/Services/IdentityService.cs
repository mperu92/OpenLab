using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Services
{
    public interface IIdentityService
    {
        Task<IUserModel[]> GetUsers();
        Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel model);
        Task<IdentityResult> RegisterUser(IdentityUserModel user, string password);
        Task<string> GenerateConfirmUserCode(IdentityUserModel user);
        Task LogOff();
        Task<IdentityUserModel> GetUserEntityById(string userId);
        Task<IdentityResult> ConfirmEmailAsync(IdentityUserModel user, string code);
    }

    public class IdentityService
    {

    }
}
