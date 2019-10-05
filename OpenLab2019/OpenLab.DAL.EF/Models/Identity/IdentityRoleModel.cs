using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF.Models.Identity
{
    public class IdentityRoleModel : IdentityRole<int>
    {
        public virtual ICollection<IdentityUserRoleModel> UserRoles { get; }
        
        public string Description { get; set; }
    }
}
