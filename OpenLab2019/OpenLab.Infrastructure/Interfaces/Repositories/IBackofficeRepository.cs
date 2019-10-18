using OpenLab.Infrastructure.Interfaces.PresentationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Infrastructure.Interfaces.Repositories
{
    public interface IBackofficeRepository
    {
        Task<INewsModel[]> GetNewsAsync(bool online = false);
        Task<bool> CreateNewsFromDynamicAsync(dynamic news, IUserModel user = null);
        Task<bool> UpdateNewsFromDynamicAsync(dynamic news, IUserModel user = null);
        Task<bool> DeleteNewsAsync(dynamic news);
    }
}
