using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF.Models.Identity
{
    public class IdentityUserModel : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; }
        public virtual ICollection<IdentityUserRoleModel> UserRoles { get; }

        public string customTag { get; set; }
    }
}
