using Microsoft.AspNetCore.Http;
using OpenLab.Infrastructure.Enums;
using OpenLab.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Services.Tools
{
    public static class ImageWriter
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            if (file == null)
                return "File is null";

            if (CheckIfImageFile(file))
                return await WriteFile(file).ConfigureAwait(false);

            return "Invalid file";
        }
        public static bool DeleteFile(string imgName)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", imgName);
                File.Delete(path);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }


        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static async Task<string> WriteFile(IFormFile file)
        {
            if (file == null)
                return "Error writing file.";

            string fileName;
            try
            {
                string extension = "." + file.FileName.Split('.')[^1]; // [file.FileName.Split('.').Length - 1]

                //Create a new Name for the file due to security reasons.
                fileName = Guid.NewGuid().ToString() + extension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                try
                {
                    using FileStream bits = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(bits).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}");
                }
            }
            catch (EndOfStreamException ex)
            {
                return ex.Message;
            }

            return fileName;
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return FilesWriterHelper.GetImageFormat(fileBytes) != ImageFormat.unknown;
        }
    }
}
