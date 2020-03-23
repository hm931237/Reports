namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Redemption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }

        public int branch_id { get; set; }

        [StringLength(30)]
        public string cust_acc_no { get; set; }

        [StringLength(30)]
        public string cust_id { get; set; }

        public int fund_id { get; set; }

        public int appliction_no { get; set; }

        public DateTime? pur_date { get; set; }

        public decimal? units { get; set; }

        public decimal amount_3 { get; set; }

        public decimal sub_fees { get; set; }

        public DateTime? system_date { get; set; }

        public DateTime? nav_date { get; set; }

        public string inputer { get; set; }

        public short auth { get; set; }

        public string auther { get; set; }

        public short flag_tr { get; set; }

        public short pay_method { get; set; }

        [StringLength(50)]
        public string pay_no { get; set; }

        [StringLength(30)]
        public string pay_bank { get; set; }

        public decimal total { get; set; }

        public decimal NAV { get; set; }

        public decimal other_fees { get; set; }

        public int delreason { get; set; }

        public int unauth { get; set; }

        public int Flag { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public bool Chk { get; set; }

        public string Checker { get; set; }

        public DateTime SysDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Fund Fund { get; set; }
    }
}
