using Microsoft.AspNetCore.Http;
using OpenLab.Services.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile file);
        bool DeleteImage(string imgName);
    }

    public class ImageService : IImageService
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            return await ImageWriter.UploadImage(file).ConfigureAwait(false);
        }

        public bool DeleteImage(string imgName)
        {
            return ImageWriter.DeleteFile(imgName);
        }
    }
}
