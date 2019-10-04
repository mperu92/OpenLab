using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLab.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IIdentityService _identityService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IEmailService _emailSender;

        public BaseApiController(ILogger logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, IEmailService emailSender = null)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            if (identityService != null)
                _identityService = identityService;
            if (emailSender != null)
                _emailSender = emailSender;
        }
    }
}
