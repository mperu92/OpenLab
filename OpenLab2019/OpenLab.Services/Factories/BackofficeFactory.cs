using OpenLab.DAL.EF.Models;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels;
using OpenLab.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Factories
{
    public interface IBackofficeFactory
    {
        INewsModel[] GetNewsModelFromEntities(EFNewsModel[] entities);
        INewsModel GetNewsModelFromEntity(EFNewsModel entity);
        INewsModel[] GetNewsModelFromDynamics(dynamic[] dynamics);
        INewsModel GetNewsModelFromDynamic(dynamic modelDyn, IUserModel user = null, bool fromCreate = false);
        EFNewsModel GetNewsEntityFromModel(INewsModel model);
    }

    public class BackofficeFactory : IBackofficeFactory
    {
        private readonly IIdentityFactory _identityFactory;

        public BackofficeFactory()
        {
            _identityFactory = new IdentityFactory();
        }

        public INewsModel[] GetNewsModelFromEntities(EFNewsModel[] entities)
        {
            INewsModel[] models = null;

            if (entities != null && entities.Length > 0)
            {
                models = new INewsModel[entities.Length];

                int i = 0;
                foreach (EFNewsModel entity in entities)
                {
                    models[i] = GetNewsModelFromEntity(entity);
                    i++;
                }

                if (models != null && models.Length > 0)
                    return models;
                else
                    return Array.Empty<INewsModel>();
            }
            else
                return Array.Empty<INewsModel>();
        }

        public INewsModel[] GetNewsModelFromDynamics(dynamic[] dynamics)
        {
            INewsModel[] models = null;

            if (dynamics != null && dynamics.Length > 0)
            {
                models = new NewsModel[dynamics.Length];

                int i = 0;
                foreach (dynamic dyn in dynamics)
                {
                    models[i] = GetNewsModelFromDynamic(dyn);
                    i++;
                }

                if (models != null && models.Length > 0)
                    return models;
                else
                    return Array.Empty<INewsModel>();
            }
            else
                return Array.Empty<INewsModel>();
        }

        public INewsModel GetNewsModelFromEntity(EFNewsModel entity)
        {
            if (entity == null)
                return null;

            INewsModel model = null;

            if (entity != null)
            {
                return model = new NewsModel
                {
                    Id = entity.Id,
                    Slug = entity.Slug,
                    Abstract = entity.Abstract,
                    BodyHtml = entity.BodyHtml,
                    BodyText = entity.BodyText,
                    CreateUserId = entity.CreateUser.Id,
                    CreateUserName = entity.CreateUser.UserName,
                    ImageUrl = entity.ImageUrl,
                    NiceLink = entity.NiceLink,
                    PublishDate = entity.PublishDate,
                    Title = entity.Title,
                    UpdateDate = entity.UpdateDate,
                    UpdateUserId = entity.UpdateUser?.Id,
                    UpdateUserName = entity.UpdateUser?.UserName,
                };
            }
            else
                return new NewsModel();
        }

        public INewsModel GetNewsModelFromDynamic(dynamic modelDyn, IUserModel user = null, bool fromCreate = false)
        {
            INewsModel newsModel = null;
            IUserModel userModel  = null;

            if (user == null)
                throw new ArgumentNullException($"{user} is null");

            if (modelDyn.CreateUser != null)
                userModel = _identityFactory.GetUserModelFromDynamic(modelDyn.CreateUser);
            else if (user != null)
                userModel = user;
            else
                userModel = new UserModel();

            bool updateUserExists = !fromCreate && modelDyn.UpdateUser != null;

            if (modelDyn != null)
            {
                return newsModel = new NewsModel
                {
                    Id = modelDyn.Id,
                    Slug = !fromCreate ? modelDyn.Slug : UrlHelper.GenerateSlug(modelDyn.Title.ToString()),
                    Abstract = modelDyn.Abstract ?? string.Empty,
                    BodyHtml = modelDyn.BodyHtml ?? string.Empty,
                    BodyText = modelDyn.BodyText ?? string.Empty,
                    CreateUserId = userModel.Id,
                    CreateUserName = userModel.UserName,
                    ImageUrl = modelDyn.ImageUrl ?? new Uri(string.Empty),
                    NiceLink = modelDyn.NiceLink ?? string.Empty,
                    PublishDate = modelDyn.PublishDate ?? DateTime.Now,
                    Title = modelDyn.Title ?? string.Empty,
                    UpdateDate = modelDyn.UpdateDate ?? null,
                    UpdateUserId = !updateUserExists ? (fromCreate ? null : (int?)userModel.Id) : modelDyn.UpdateUser.Id,
                    UpdateUserName = !updateUserExists ? (fromCreate ? null : userModel.UserName) : modelDyn.UpdateUser.UserName
                };
            }
            else
                return new NewsModel();
        }

        public EFNewsModel GetNewsEntityFromModel(INewsModel model)
        {
            EFNewsModel newsModel = null;
            int? updateUserId = null;

            if (model == null)
                throw new ArgumentException($"{model} is null");

            if (model.UpdateUserId.HasValue && model.UpdateUserId.Value > 0)
                updateUserId = model.UpdateUserId.Value;

            if (model != null)
            {
                return newsModel = new EFNewsModel
                {
                    Id = model.Id,
                    Slug = model.Slug,
                    Abstract = model.Abstract,
                    BodyHtml = model.BodyHtml,
                    BodyText = model.BodyText,
                    FKCreateUser = model.CreateUserId,
                    ImageUrl = model.ImageUrl,
                    NiceLink = model.NiceLink,
                    PublishDate = model.PublishDate,
                    Title = model.Title,
                    UpdateDate = model.UpdateDate ?? null,
                    FKUpdateUser = updateUserId,
                    Online = true,
                };
            }
            else
                return new EFNewsModel();
        }
    }
}
