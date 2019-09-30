using Microsoft.EntityFrameworkCore;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Repositories
{
    public interface IIdentityRepository
    {
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

        public async Task<IUserModel[]> GetAllUsers()
        {
            IdentityUserModel[] entityUsers = await _context.Users.AsNoTracking().ToArrayAsync();

            if (entityUsers == null || (entityUsers != null && entityUsers.Count() <= 0))
                return null;

            return _identityFactory.GetUserModelArrayFromEntity(entityUsers);
        }
    }
}
