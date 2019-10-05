using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenLab.Services.Services;

namespace OpenLab.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailSender;

        public BaseController(ILogger logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, IEmailService emailSender = null)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            if (identityService != null)
                _identityService = identityService;
            if (emailSender != null)
                _emailSender = emailSender;
        }

        public ILogger Logger { get => _logger; }
        public IHttpContextAccessor HttpContextAccessor { get => _httpContextAccessor; }

        public IEmailService EmailService { get => _emailSender; }
        public IIdentityService IdentityService { get => _identityService; }
    }
}