namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fund
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fund()
        {
            FundRights = new HashSet<FundRight>();
            FundTimes = new HashSet<FundTime>();
            ICPrices = new HashSet<ICPrice>();
            Redemptions = new HashSet<Redemption>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int FundID { get; set; }

        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        public string Name { get; set; }

        public int CurrencyID { get; set; }

        public int SponsorID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal ParView { get; set; }

        public int Units { get; set; }

        public decimal SubFeesBar { get; set; }

        public decimal RedFeesBar { get; set; }

        public int MinInd { get; set; }

        public int MaxInd { get; set; }

        public int MinCor { get; set; }

        public int MaxCor { get; set; }

        public decimal OtherSubFees { get; set; }

        public decimal OtherRedFees { get; set; }

        public int AdminFees { get; set; }

        public int EarlyFees { get; set; }

        public DateTime SysDate { get; set; }

        public DateTime EntryDate { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Nav { get; set; }

        public string Remark { get; set; }

        public string ISIN { get; set; }

        public DateTime InvDate { get; set; }

        public int FundAcc { get; set; }

        public decimal MarkFees { get; set; }

        public string SubFeesAcc { get; set; }

        public string RedemFeesAcc { get; set; }

        public string ManageFeesAcc { get; set; }

        public string AdminFeesAcc { get; set; }

        public string OtherSubAcc { get; set; }

        public string OtherRedAcc { get; set; }

        public string EarlyFeesAcc { get; set; }

        public int ClientType { get; set; }

        public int ProductEligable { get; set; }

        public string GuaranteeNotePer { get; set; }

        public string GuranteeNote { get; set; }

        public int CboType { get; set; }

        public decimal UpFrontFees { get; set; }

        public string UpFrontAcc { get; set; }

        public string FreeText { get; set; }

        public int CouponBox { get; set; }

        public string UserLog { get; set; }

        public bool Chk { get; set; }

        public bool HasFundTime { get; set; }

        public bool HasICPrice { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Currency Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundRight> FundRights { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundTime> FundTimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICPrice> ICPrices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Redemption> Redemptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
