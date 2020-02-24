using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenLab.DAL.EF.Models
{
    [Table("OpenLab_NewsAuthors")]
    public class EFNewsAuthorModel
    {
        public int NewsId { get; set; }
        public virtual EFNewsModel News { get; set; }

        public int AuthorId { get; set; }
        public virtual EFAuthorModel Author { get; set; }
    }
}
