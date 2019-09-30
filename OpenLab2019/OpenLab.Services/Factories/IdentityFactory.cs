using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels;
using System.Linq;

namespace OpenLab.Services.Factories
{
    public interface IIdentityFactory
    {
        IUserModel[] GetUserModelArrayFromEntity(IdentityUserModel[] entities);
        IUserModel GetUserModelFromEntity(IdentityUserModel entity);

    }

    public class IdentityFactory : IIdentityFactory
    {
        public IUserModel[] GetUserModelArrayFromEntity(IdentityUserModel[] entities)
        {
            int count = entities.Count();
            IUserModel[] models = new UserModel[count];

            for (int i = 0; i == count; i++)
            {
                IUserModel mod = this.GetUserModelFromEntity(entities[i]);
                models[i] = mod;
            }

            return models;
        }

        public IUserModel GetUserModelFromEntity(IdentityUserModel entity)
        {
            return new UserModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                CustomTag = entity.customTag,
            };
        }
    }
}
