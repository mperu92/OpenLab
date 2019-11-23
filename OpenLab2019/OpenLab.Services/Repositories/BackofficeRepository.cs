using Microsoft.EntityFrameworkCore;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models;
using OpenLab.DAL.EF.Models.Identity;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Infrastructure.PresentationModels;
using OpenLab.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Repositories
{
    public class BackofficeRepository : IBackofficeRepository
    {
        private readonly OpenLabDbContext _context;
        private readonly IBackofficeFactory _backofficeFactory;
        private readonly IIdentityRepository _identityRepository;

        public BackofficeRepository(OpenLabDbContext context)
        {
            _context = context;
            _backofficeFactory = new BackofficeFactory();
            _identityRepository = new IdentityRepository(context);
        }

        public async Task<INewsModel[]> GetNewsAsync(bool online = false)
        {
            INewsModel[] newsModel = null;

            // Can't load UserModel with AsNoTracking() because of it tiggers a LazyLoadingProxies error
            if (online)
                newsModel = await _context.News
                    .Where(x => x.Online == true)
                    .Select(s => _backofficeFactory.GetNewsModelFromEntity(s))
                    // .AsNoTracking()
                    .ToArrayAsync().ConfigureAwait(false);
            else
                newsModel = await _context.News
                  .Select(s => _backofficeFactory.GetNewsModelFromEntity(s))
                  // .AsNoTracking()
                  .ToArrayAsync().ConfigureAwait(false);

            if (newsModel != null && newsModel.Length > 0)
                return newsModel;
            else
                return null;
        }

        public async Task<Tuple<bool, dynamic>> CreateNewsFromDynamicAsync(dynamic news, IUserModel user)
        {
            if (news == null)
                return Tuple.Create<bool, dynamic>(false, null);
            if (user == null)
                return Tuple.Create<bool, dynamic>(false, null);

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news, user, true);
            if (newsModel == null)
                return Tuple.Create<bool, dynamic>(false, null);

            try
            {
                EFNewsModel entityNews = _backofficeFactory.GetNewsEntityFromModel(newsModel);
                if (entityNews == null)
                    return Tuple.Create<bool, dynamic>(false, null);

                await _context.News.AddAsync(entityNews);
                int response = await _context.SaveChangesAsync().ConfigureAwait(false);
                if (response == 1)
                {
                    string createUserName = entityNews.CreateUser.UserName ?? string.Empty;
                    int createUserId = entityNews.CreateUser != null && entityNews.CreateUser.Id > 0 ? entityNews.CreateUser.Id : 0;

                    dynamic respNews = new
                    {
                        id = entityNews.Id,
                        @abstract = entityNews.Abstract,
                        bodyHtml = entityNews.BodyHtml,
                        bodyText = entityNews.BodyText,
                        imageUrl = entityNews.ImageUrl,
                        niceLink = entityNews.NiceLink,
                        publishDate = entityNews.PublishDate,
                        slug = entityNews.Slug,
                        title = entityNews.Title,
                        updateDate = entityNews.UpdateDate,
                        createUserName,
                        createUserId,
                    };

                    return Tuple.Create<bool, dynamic>(true, respNews);
                }
                else
                    return Tuple.Create<bool, dynamic>(false, null); ;
            }
            catch (Exception ex)
            {
                string exe = ex.Message;
                throw new Exception($"EX: {exe}");
            }
        }

        public async Task<Tuple<bool, dynamic>> UpdateNewsFromDynamicAsync(dynamic news, IUserModel user)
        {
            if (news == null && news.id == null)
                return Tuple.Create<bool, dynamic>(false, null);
            if (user == null)
                return Tuple.Create<bool, dynamic>(false, null);

            int uId = news.id.ToObject<int>();
            EFNewsModel newsModel = await _context.News.Where(x => x.Id == uId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (newsModel == null)
                return Tuple.Create<bool, dynamic>(false, null);

            newsModel.FKUpdateUser = user.Id;
            newsModel.Abstract = news.@abstract;
            newsModel.BodyHtml = news.bodyHtml;
            newsModel.BodyText = news.bodyText;
            newsModel.ImageUrl = news.imageUrl;
            newsModel.NiceLink = news.niceLink;
            newsModel.Online = true;
            newsModel.Slug = news.slug;
            newsModel.Title = news.title;
            newsModel.UpdateDate = DateTime.Now;

            _context.News.Update(newsModel);
            int response = await _context.SaveChangesAsync().ConfigureAwait(false);
            if (response == 1)
            {
                // string updateUserName = user.UserName;
                return Tuple.Create<bool, dynamic>(true, news);
            }
            else
                return Tuple.Create<bool, dynamic>(false, null);
        }

        public async Task<bool> DeleteNewsAsync(dynamic news)
        {
            if (news == null)
                return false;

            int nId = news.id.ToObject<int>();
            if (nId <= 0) return false;

            EFNewsModel entityNews = await _context.News.Where(x => x.Id == nId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (entityNews == null)
                return false;

            _context.News.Remove(entityNews);
            int response = await _context.SaveChangesAsync().ConfigureAwait(false);
            if (response == 1)
                return true;
            else
                return false;
        }
    }
}
