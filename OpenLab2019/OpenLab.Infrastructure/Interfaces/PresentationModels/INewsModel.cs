﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Infrastructure.Interfaces.PresentationModels
{
    public interface INewsModel
    {
        int Id { get; set; }
        string Slug { get; set; }

        string Title { get; set; }
        string Abstract { get; set; }
        string BodyHtml { get; set; }
        string BodyText { get; set; }
        Uri ImageUrl { get; set; }
        string NiceLink { get; set; }

        DateTime PublishDate { get; set; }
        DateTime? UpdateDate { get; set; }

        int CreateUserId { get; set; }
        string CreateUserName { get; set; }
        int? UpdateUserId { get; set; }
        string UpdateUserName { get; set; }
    }
}
