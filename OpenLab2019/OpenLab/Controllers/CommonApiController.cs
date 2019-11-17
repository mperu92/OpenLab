using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Controllers.Base;
using OpenLab.Services.Helpers;
using OpenLab.Services.Services;

namespace OpenLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonApiController : BaseApiController
    {
        private readonly string _imgFolder;

        public CommonApiController(ILogger<newsApiController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IBackofficeService backendService, IEmailService emailSender, IImageService imageService) : base(logger, httpContextAccessor, identityService, backendService, emailSender, imageService)
        {
            _imgFolder = "/images/";
        }

        [HttpPost("uploadImage")]
        [Produces("application/json")]
        public async Task<IActionResult> uploadImage([FromForm(Name = "file")] IFormFile file)
        {
            if (file == null)
                return BadRequest("File is null");

            string response = await ImageService.UploadImage(file).ConfigureAwait(false);
            if (string.IsNullOrEmpty(response))
                return BadRequest("Error uploading file");

            return Ok(new
            {
                data = new
                {
                    imagePath = $"{_imgFolder}{response}",
                    imageName = $"{response}",
                    imageType = $"{file.ContentType}",
                    imageOriginalName = $"{file.FileName}",
                    status = "success"
                }
            });
        }

        [HttpPost("deleteImage")]
        [Produces("application/json")]
        public IActionResult deleteImage([FromBody] dynamic data)
        {
            if (data == null || data.value == null)
                return BadRequest("File is null");

            string imgName = UrlHelper.ExtrapolateFileNameFromPath(data.value.ToString());
            if (string.IsNullOrEmpty(imgName))
                return BadRequest("Error retreiving filename");

            bool response = ImageService.DeleteImage(imgName);
            if (response)
                return Ok("Image deleted");
            else
                return BadRequest("Error deleting image");
        }
    }
}