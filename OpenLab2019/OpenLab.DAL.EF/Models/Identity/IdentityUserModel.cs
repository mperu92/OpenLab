using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF.Models.Identity
{
    public class IdentityUserModel : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRoleModel> UserRoles { get; set; }

        public string customTag { get; set; }
    }
}
