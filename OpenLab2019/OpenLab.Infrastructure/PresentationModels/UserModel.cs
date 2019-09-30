using OpenLab.Infrastructure.Interfaces.PresentationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Infrastructure.PresentationModels
{
    public class UserModel : IUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CustomTag { get; set; }
    }
}
