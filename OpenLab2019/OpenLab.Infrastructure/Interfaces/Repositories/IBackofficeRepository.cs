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
        Task<Tuple<bool, dynamic>> CreateNewsFromDynamicAsync(dynamic news, IUserModel user);
        Task<Tuple<bool, dynamic>> UpdateNewsFromDynamicAsync(dynamic news, IUserModel user = null);
        Task<bool> DeleteNewsAsync(dynamic news);
    }
}
