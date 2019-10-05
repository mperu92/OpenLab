using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels;
using System;
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
            if (entities == null)
                return Array.Empty<IUserModel>();

            int count = entities.Length;
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
            if (entity == null)
                return new UserModel();

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
