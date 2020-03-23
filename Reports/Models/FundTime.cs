namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FundTime
    {
        public int FundTimeID { get; set; }

        public TimeSpan Time { get; set; }

        public int FundId { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        public string Maker { get; set; }

        public bool Chk { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Fund Fund { get; set; }
    }
}
