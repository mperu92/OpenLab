using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Services.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OpenLab.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;
        private readonly IBackofficeService _backendService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailSender;
        private readonly IImageService _imageService;

        public BaseApiController(ILogger logger, IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, IBackofficeService backendService = null, IEmailService emailSender = null, IImageService imageService = null)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            if (identityService != null)
                _identityService = identityService;
            if (backendService != null)
                _backendService = backendService;
            if (emailSender != null)
                _emailSender = emailSender;
            if (imageService != null)
                _imageService = imageService;
        }

        public ILogger Logger { get => _logger; }
        public IHttpContextAccessor IHttpContextAccessor { get => _httpContextAccessor; }

        public IEmailService EmailService { get => _emailSender; }
        public IIdentityService IdentityService { get => _identityService; }
        public IBackofficeService BackendService { get => _backendService; }
        public IImageService ImageService { get => _imageService; }
    }
}
