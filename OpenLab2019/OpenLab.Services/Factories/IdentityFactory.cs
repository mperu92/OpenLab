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
        IUserModel GetUserModelFromDynamic(dynamic userDyn);
        IdentityUserModel GetUserEntityFromModel(IUserModel userModel);
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

        public IUserModel GetUserModelFromDynamic(dynamic userDyn)
        {
            if (userDyn == null)
                return new UserModel();

            return new UserModel
            {
                Id = userDyn.Id,
                UserName = userDyn.UserName,
                Email = userDyn.Email,
                CustomTag = userDyn.customTag,
            };
        }

        public IdentityUserModel GetUserEntityFromModel(IUserModel userModel)
        {
            if (userModel == null)
                return new IdentityUserModel();

            return new IdentityUserModel
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email,
                customTag = userModel.CustomTag,
            };
        }
    }
}
