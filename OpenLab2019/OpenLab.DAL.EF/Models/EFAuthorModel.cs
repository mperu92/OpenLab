using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenLab.DAL.EF.Models
{
    [Table("OpenLab_Authors")]
    public class EFAuthorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CompleteName
        {
            get { return $"{FirstName} {LastName}"; }
            private set { }
        }

        public string Description { get; set; }
        public Uri ImageUrl { get; set; }
        public Uri SiteUrl { get; set; }
        public bool Online { get; set; }

        public virtual ICollection<EFNewsAuthorModel> NewsAuthors { get; set; }
    }
}
