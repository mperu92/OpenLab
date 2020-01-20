using OpenLab.Infrastructure.Interfaces.PresentationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Infrastructure.PresentationModels.Web
{
    public class UserInfoModel
    {
        public bool IsLogged { get; set; }
        public bool IsAdmin { get; set; }
        public IUserModel User { get; set; }
    }
}
