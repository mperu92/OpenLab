using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLab.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        public readonly IIdentityService _identityService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IEmailSender _emailSender;

        public BaseApiController(IHttpContextAccessor httpContextAccessor, IIdentityService identityService = null, IEmailSender emailSender = null)
        {
            _httpContextAccessor = httpContextAccessor;
            if (identityService != null)
                _identityService = identityService;
            if (emailSender != null)
                _emailSender = emailSender;
        }
    }
}
