using OpenLab.Infrastructure.Interfaces.PresentationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Infrastructure.Interfaces.Repositories
{
    public interface IIdentityRepository
    {
        Task<IUserModel[]> GetAllUsers();
    }
}
