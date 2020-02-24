using OpenLab.DAL.EF.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenLab.DAL.EF.Models
{
    [Table("OpenLab_News")]
    public class EFNewsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Slug { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string BodyHtml { get; set; }
        public string BodyText { get; set; }
        public Uri ImageUrl { get; set; }
        public string NiceLink { get; set; }

        [DataType("datetime2")]
        public DateTime PublishDate { get; set; }

        [DataType("datetime2")]
        public DateTime? UpdateDate { get; set; } = null;

        public int FKCreateUser { get; set; }

        [ForeignKey("FKCreateUser")]
        public virtual IdentityUserModel CreateUser { get; set; }

        public int? FKUpdateUser { get; set; } = null;

        [ForeignKey("FKUpdateUser")]
        public virtual IdentityUserModel UpdateUser { get; set; }

        public bool Online { get; set; }

        public virtual ICollection<EFNewsAuthorModel> NewsAuthors { get; set; }
    }
}
