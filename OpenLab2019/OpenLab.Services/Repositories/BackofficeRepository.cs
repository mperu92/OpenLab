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

        public BackofficeRepository(OpenLabDbContext context)
        {
            _context = context;
            _backofficeFactory = new BackofficeFactory();
        }

        public async Task<INewsModel[]> GetNewsAsync(bool online = false)
        {
            INewsModel[] newsModel = null;

            if (online)
                newsModel = await _context.News
                    .Where(x => x.Online == true)
                    .Select(s => _backofficeFactory.GetNewsModelFromEntity(s))
                    .AsNoTracking()
                    .ToArrayAsync().ConfigureAwait(false);
            else
                newsModel = await _context.News
                  .Where(x => x.Online == true)
                  .Select(s => _backofficeFactory.GetNewsModelFromEntity(s))
                  .AsNoTracking()
                  .ToArrayAsync().ConfigureAwait(false);


            if (newsModel != null && newsModel.Length > 0)
                return newsModel;
            else
                return null;
        }

        public async Task<bool> CreateNewsFromDynamicAsync(dynamic news)
        {
            if (news == null)
                return false;

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news);
            if (newsModel == null)
                return false;

            await _context.News.AddAsync((EFNewsModel)newsModel);
            int response = await _context.SaveChangesAsync().ConfigureAwait(false);
            if (response == 0)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateNewsFromDynamicAsync(dynamic news)
        {
            if (news == null)
                return false;

            INewsModel newsModel = _backofficeFactory.GetNewsModelFromDynamic(news);
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
