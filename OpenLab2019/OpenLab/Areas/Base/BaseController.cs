using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Services.Services;

namespace OpenLab.Areas.Base
{
    public class BaseController : Controller
    {
        public readonly ILogger _logger;
        public readonly IIdentityService _identityService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IEmailService _emailSender;
        public readonly IBackofficeService _backofficeService;

        public BaseController(ILogger logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, IEmailService emailSender = null, IBackofficeService backofficeService = null)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            if (identityService != null)
                _identityService = identityService;
            if (emailSender != null)
                _emailSender = emailSender;
            if (backofficeService != null)
                _backofficeService = backofficeService;
        }
    }
}