namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSecurity
    {
        public int UserSecurityId { get; set; }

        public int NumberOfTrials { get; set; }

        public int ExpireInterval { get; set; }

        public int Levels { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public DateTime SysDate { get; set; }

        public bool Chk { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
