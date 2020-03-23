namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Title
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Title()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int TitleID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserID { get; set; }

        public bool EditFlag { get; set; }

        public bool DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public bool Check { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public DateTime SysDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
