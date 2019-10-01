using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Services.Services;

namespace OpenLab.Controllers.Base
{
    public class BaseController : Controller
    {
        public readonly ILogger _logger;
        public readonly IIdentityService _identityService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly EmailService _emailSender;

        public BaseController(ILogger logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, EmailService emailSender = null)
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