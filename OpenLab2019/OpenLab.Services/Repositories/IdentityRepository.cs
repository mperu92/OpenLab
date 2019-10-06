using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Repositories
{
    public interface IIdentityRepository
    {
        Task<IUserModel> GetUserAsync(ClaimsPrincipal userPrincipal, UserManager<IdentityUserModel> userManager);
        Task<IUserModel[]> GetAllUsers();
    }

    public class IdentityRepository : IIdentityRepository
    {
        private readonly OpenLabDbContext _context;
        private readonly IIdentityFactory _identityFactory;

        public IdentityRepository(OpenLabDbContext context)
        {
            _context = context;
            _identityFactory = new IdentityFactory();
        }

        public async Task<IUserModel> GetUserAsync(ClaimsPrincipal userPrincipal, UserManager<IdentityUserModel> userManager)
        {
            if (userManager == null)
                throw new ArgumentNullException($"UserManager {userManager} is null");

            IdentityUserModel entityUser = await userManager.GetUserAsync(userPrincipal).ConfigureAwait(false);

            if (entityUser == null)
                return null;

            return _identityFactory.GetUserModelFromEntity(entityUser);
        }

        public async Task<IUserModel[]> GetAllUsers()
        {
            IdentityUserModel[] entityUsers = await _context.Users.AsNoTracking().ToArrayAsync().ConfigureAwait(false);

            if (entityUsers == null || (entityUsers != null && entityUsers.Length <= 0))
                return null;

            return _identityFactory.GetUserModelArrayFromEntity(entityUsers);
        }
    }
}
