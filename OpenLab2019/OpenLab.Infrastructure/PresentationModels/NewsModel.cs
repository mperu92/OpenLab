using OpenLab.Infrastructure.Interfaces.PresentationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenLab.Infrastructure.PresentationModels
{
    public class NewsModel : INewsModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string BodyHtml { get; set; }
        public string BodyText { get; set; }
        public Uri ImageUrl { get; set; }
        public string NiceLink { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime? UpdateDate { get; set; } = null;

        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }

        //public IUserModel CreateUser { get; set; }
        //public IUserModel UpdateUser { get; set; }
    }
}
