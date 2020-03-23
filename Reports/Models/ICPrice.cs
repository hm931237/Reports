namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ICPrice
    {
        public int ICPriceID { get; set; }

        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        public int FundId { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public bool Chk { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public DateTime SysDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Fund Fund { get; set; }
    }
}
