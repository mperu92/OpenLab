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
using System.Security.Claims;

namespace OpenLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newsApiController : BaseApiController
    {
        public newsApiController(ILogger<newsApiController> logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService, IBackofficeService backendService, IEmailService emailSender) : base(logger, httpContextAccessor, identityService, backendService, emailSender) { }

        [HttpPost("getNewsList")]
        [Produces("application/json")]
        public async Task<IActionResult> getNewsList([FromBody] dynamic data)
        {
            if (data == null)
                return BadRequest($"Error loading news");

            bool online = data.online.ToObject<bool>() ?? false;
            INewsModel[] news = await BackendService.GetNewsAsync(online).ConfigureAwait(false);

            if (news != null && news.Length >= 0)
            {
                dynamic[] newsList = ((IEnumerable<dynamic>)news).ToArray();
                if (newsList != null && newsList.Length >= 0)
                    return Ok(newsList);
            }
            
            return BadRequest($"Error loading news");
        }

        [HttpPost("createUpdateNews")]
        [Produces("application/json")]
        public async Task<IActionResult> createUpdateNews([FromBody] dynamic news)
        {
            if (news == null || (news != null && news.news == null))
                return BadRequest($"Error editing news");

            // string userId = IHttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            IUserModel user = null;
            if (news.CreateUser == null)
                user = await IdentityService.GetUserAsync(IHttpContextAccessor.HttpContext.User).ConfigureAwait(false);
            
            dynamic _news = news.news;
            Tuple<bool, dynamic> resp = await BackendService.CreateUpdateNews(_news, user);
            
            if(resp.Item1 == true && resp.Item2 != null)
            {
                dynamic respNews = resp.Item2;
                return Ok(new { respNews });
            }
            else
                return BadRequest($"Error editing news");
        }

        [HttpPost("deleteNews")]
        [Produces("application/json")]
        public async Task<IActionResult> deleteNews([FromBody] dynamic news)
        {
            if (news == null || (news != null && news.news == null))
                return BadRequest($"Error deleting news");

            dynamic _news = news.news;
            bool deleted = await BackendService.DeleteNews(_news);
            if (deleted)
                return Ok(new { deleted });
            else
                return BadRequest($"Error deleting news");
        }
    }
}
