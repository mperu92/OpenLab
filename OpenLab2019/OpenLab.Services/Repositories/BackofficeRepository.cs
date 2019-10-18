using Microsoft.EntityFrameworkCore;
using OpenLab.DAL.EF.Contexts;
using OpenLab.DAL.EF.Models;
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

            if (newsModel != null && newsModel.Length >= 0)
                return newsModel;
            else
                return null;
        }

        public async Task<bool> CreateNewsFromDynamicAsync(dynamic news, IUserModel user = null)
        {
            if (news == null)
                return false;

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news, user, true);
            if (newsModel == null)
                return false;
            try
            {
                await _context.News.AddAsync(_backofficeFactory.GetNewsEntityFromModel(newsModel));
                int response = await _context.SaveChangesAsync().ConfigureAwait(false);
                if (response == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string exe = ex.Message;
                throw new Exception($"EX: {exe}");
            }
        }

        public async Task<bool> UpdateNewsFromDynamicAsync(dynamic news, IUserModel user = null)
        {
            if (news == null)
                return false;

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news, user);
            if (newsModel == null)
                return false;

            _context.News.Update((EFNewsModel)newsModel);
            int response = await _context.SaveChangesAsync().ConfigureAwait(false);
            if (response == 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteNewsAsync(dynamic news)
        {
            if (news == null)
                return false;

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news);
            if (newsModel == null)
                return false;

            _context.News.Remove((EFNewsModel)newsModel);
            int response = await _context.SaveChangesAsync().ConfigureAwait(false);
            if (response == 0)
                return true;
            else
                return false;
        }
    }
}
