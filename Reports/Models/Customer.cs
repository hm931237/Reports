namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Redemptions = new HashSet<Redemption>();
            Subscriptions = new HashSet<Subscription>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Key]
        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(30)]
        public string AccountNO { get; set; }

        [Required]
        public string EnName { get; set; }

        public string ArName { get; set; }

        [Required]
        public string EnAddress1 { get; set; }

        public string EnAddress2 { get; set; }

        [Required]
        public string ArAddress1 { get; set; }

        public string ArAddress2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Email4 { get; set; }

        public string CRNumber { get; set; }

        public string Sector { get; set; }

        public DateTime IssuanceDate { get; set; }

        public int CustTypeId { get; set; }

        public int NationalityId { get; set; }

        public int BranchId { get; set; }

        public int CityId { get; set; }

        [Required]
        public string IdNumber { get; set; }

        public int idType { get; set; }

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

        public int? PostalCode { get; set; }

        public int? tel1 { get; set; }

        public int? tel2 { get; set; }

        public int? tel3 { get; set; }

        public int? Fax1 { get; set; }

        public int? Fax2 { get; set; }

        public int? Fax3 { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual City City { get; set; }

        public virtual CustType CustType { get; set; }

        public virtual Nationality Nationality { get; set; }

        public virtual UserIdentityType UserIdentityType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Redemption> Redemptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
