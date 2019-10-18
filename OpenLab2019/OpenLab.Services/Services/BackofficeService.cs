using OpenLab.DAL.EF.Contexts;
using OpenLab.Infrastructure.Interfaces.PresentationModels;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Services.Factories;
using OpenLab.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Services
{
    public interface IBackofficeService
    {
        Task<INewsModel[]> GetNewsAsync(bool online = false);
        Task<bool> CreateUpdateNews(dynamic news, IUserModel user = null);
        Task<bool> DeleteNews(dynamic news);
    }

    public class BackofficeService : IBackofficeService
    {
        private readonly OpenLabDbContext _context;
        private readonly IBackofficeRepository _backofficeRepository;

        public BackofficeService(OpenLabDbContext context)
        {
            _context = context;
            _backofficeRepository = new BackofficeRepository(_context);
        }

        public async Task<INewsModel[]> GetNewsAsync(bool online = false)
        {
            return await _backofficeRepository.GetNewsAsync(online).ConfigureAwait(false);
        }

        public async Task<bool> CreateUpdateNews(dynamic news, IUserModel user = null)
        {
            if (news == null)
                return false;

            if (news.Id <= 0)
                return await _backofficeRepository.CreateNewsFromDynamicAsync(news, user);
            else
                return await _backofficeRepository.UpdateNewsFromDynamicAsync(news, user);
        }

        public async Task<bool> DeleteNews(dynamic news)
        {
            if (news == null)
                return false;

            return await _backofficeRepository.DeleteNewsAsync(news);
        }
    }
}
