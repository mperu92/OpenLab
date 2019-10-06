using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Controllers.Base;
using OpenLab.Services.Services;
using Newtonsoft.Json;
using OpenLab.Infrastructure.Interfaces.PresentationModels;

namespace OpenLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newsApiController : BaseApiController
    {
        public newsApiController(ILogger<newsApiController> logger, IHttpContextAccessor httpContextAccessor, IBackofficeService backendService, IEmailService emailSender) : base(logger, httpContextAccessor, null, backendService, emailSender) { }

        [HttpPost("getNews")]
        [Produces("appication/json")]
        public async Task<IActionResult> getNews([FromBody] dynamic data)
        {
            if (data == null)
                return BadRequest($"Error loading news");

            bool online = data.online.ToObject<bool>() ?? false;
            INewsModel[] news = await BackendService.GetNewsAsync(online).ConfigureAwait(false);

            if (news != null && news.Length > 0)
            {
                string newsString = JsonConvert.SerializeObject(news);
                return Ok(new { data = newsString });
            }
            
            return BadRequest($"Error loading news");
        }

        [HttpPost("createUpdateNews")]
        [Produces("appication/json")]
        public async Task<IActionResult> createUpdateNews([FromBody] dynamic news)
        {
            if (news == null)
                return BadRequest($"Error editing news");

            bool saved = await BackendService.CreateUpdateNews(news);
            if (saved)
                return Ok(new { news });
            else
                return BadRequest($"Error editing news");
        }

        [HttpPost("deleteNews")]
        [Produces("appication/json")]
        public async Task<IActionResult> deleteNews([FromBody] dynamic news)
        {
            if (news == null)
                return BadRequest($"Error deleting news");

            bool deleted = await BackendService.DeleteNews(news);
            if (deleted)
                return Ok(new { deleted });
            else
                return BadRequest($"Error deleting news");
        }
    }
}