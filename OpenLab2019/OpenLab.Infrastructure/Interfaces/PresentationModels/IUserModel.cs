using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Infrastructure.Interfaces.PresentationModels
{
    public interface IUserModel
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string CustomTag { get; set; }
    }
}
