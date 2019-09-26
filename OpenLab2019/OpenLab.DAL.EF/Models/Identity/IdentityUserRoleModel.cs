using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF.Models.Identity
{
    public class IdentityUserRoleModel : IdentityUserRole<int>
    {
        public virtual IdentityUserModel User { get; set; }
        public virtual IdentityRoleModel Role { get; set; }
    }
}
