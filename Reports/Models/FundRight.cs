namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FundRight
    {
        public int FundRightID { get; set; }

        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        public bool Auth { get; set; }

        public int FundID { get; set; }

        public int GroupID { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public bool FundRightAuth { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public bool Chk { get; set; }

        public string Checker { get; set; }

        public string Auther { get; set; }

        public virtual Fund Fund { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
