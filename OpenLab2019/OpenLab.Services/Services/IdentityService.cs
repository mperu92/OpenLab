﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Infrastructure.ViewModels;
using OpenLab.Services.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenLab.Services.Services
{
    public interface IIdentityService
    {
        Task<IUserModel> GetUserAsync(ClaimsPrincipal user);
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUserModel> _userManager;
        private readonly SignInManager<IdentityUserModel> _signInManager;

        public IdentityService(OpenLabDbContext context, UserManager<IdentityUserModel> userManager,
            SignInManager<IdentityUserModel> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _identityRepository = new IdentityRepository(_context);
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IUserModel> GetUserAsync(ClaimsPrincipal user)
        {
            return await _identityRepository.GetUserAsync(user, _userManager).ConfigureAwait(false);
        }

        public async Task<IUserModel[]> GetUsers()
        {
            return await _identityRepository.GetAllUsers().ConfigureAwait(false);
        }

        public async Task<IdentityUserModel> GetUserEntityById(string userId)
        {
            return await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel model)
        {
            if (model == null)
                return null;

            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false).ConfigureAwait(false);
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
        }

        public async Task<IdentityResult> RegisterUser(IdentityUserModel user, string password)
        {
            return await _userManager.CreateAsync(user, password).ConfigureAwait(false);
        }

        public async Task<string> GenerateConfirmUserCode(IdentityUserModel user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(IdentityUserModel user, string code)
        {
            return await _userManager.ConfirmEmailAsync(user, code).ConfigureAwait(false);
        }
    }
}
