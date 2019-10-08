using OpenLab.DAL.EF.Models;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.PresentationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Factories
{
    public interface IBackofficeFactory
    {
        INewsModel[] GetNewsModelFromEntities(EFNewsModel[] entities);
        INewsModel GetNewsModelFromEntity(EFNewsModel entity);
        dynamic[] GetNewsModelFromDynamics(dynamic[] dynamics);
        dynamic GetNewsModelFromDynamic(dynamic modelDyn);
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

        public dynamic[] GetNewsModelFromDynamics(dynamic[] dynamics)
        {
            dynamic[] models = null;

            if (dynamics != null && dynamics.Length > 0)
            {
                models = new dynamic[dynamics.Length];

                int i = 0;
                foreach (dynamic dyn in dynamics)
                {
                    models[i] = GetNewsModelFromDynamic(dyn);
                    i++;
                }

                if (models != null && models.Length > 0)
                    return models;
                else
                    return Array.Empty<dynamic>();
            }
            else
                return Array.Empty<dynamic>();
        }

        public INewsModel GetNewsModelFromEntity(EFNewsModel entity)
        {
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
                    CreateUser = _identityFactory.GetUserModelFromEntity(entity.CreateUser),
                    ImageUrl = entity.ImageUrl,
                    NiceLink = entity.NiceLink,
                    PublishDate = entity.PublishDate,
                    Title = entity.Title,
                    UpdateDate = entity.UpdateDate,
                    UpdateUser = _identityFactory.GetUserModelFromEntity(entity.UpdateUser)
                };
            }
            else
                return new NewsModel();
        }

        public dynamic GetNewsModelFromDynamic(dynamic modelDyn)
        {
            dynamic dyn = null;

            if (modelDyn != null)
            {
                return dyn = new
                {
                    Id = modelDyn.Id,
                    Slug = modelDyn.Slug,
                    Abstract = modelDyn.Abstract,
                    BodyHtml = modelDyn.BodyHtml,
                    BodyText = modelDyn.BodyText,
                    CreateUser = _identityFactory.GetUserModelFromDynamic(modelDyn.CreateUser),
                    ImageUrl = modelDyn.ImageUrl,
                    NiceLink = modelDyn.NiceLink,
                    PublishDate = modelDyn.PublishDate,
                    Title = modelDyn.Title,
                    UpdateDate = modelDyn.UpdateDate,
                    UpdateUser = _identityFactory.GetUserModelFromDynamic(modelDyn.UpdateUser)
                };
            }
            else
                return new { };
        }
    }
}
