using Microsoft.AspNetCore.Identity;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Infrastructure.ViewModels;
using OpenLab.Services.Repositories;
using System.Threading.Tasks;

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

    public class IdentityService : IIdentityService
    {
        private readonly OpenLabDbContext _context;
        private readonly IIdentityRepository _identityRepository;
        private readonly UserManager<IdentityUserModel> _userManager;
        private readonly SignInManager<IdentityUserModel> _signInManager;

        public IdentityService(OpenLabDbContext context, UserManager<IdentityUserModel> userManager,
            SignInManager<IdentityUserModel> signInManager)
        {
            _context = context;
            _identityRepository = new IdentityRepository(_context);
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IUserModel[]> GetUsers()
        {
            return await _identityRepository.GetAllUsers();
        }

        public async Task<IdentityUserModel> GetUserEntityById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUser(IdentityUserModel user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<string> GenerateConfirmUserCode(IdentityUserModel user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(IdentityUserModel user, string code)
        {
            return await _userManager.ConfirmEmailAsync(user, code);
        }
    }
}
