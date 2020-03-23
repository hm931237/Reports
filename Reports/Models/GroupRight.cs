namespace Reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupRight
    {
        public int GroupRightID { get; set; }

        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        public bool Create { get; set; }

        public bool Update { get; set; }

        public bool Delete { get; set; }

        public bool Read { get; set; }

        public bool Authorized { get; set; }

        public bool Check { get; set; }

        public bool None { get; set; }

        public int FormID { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int GroupId { get; set; }

        public bool EditFlag { get; set; }

        public int DeletFlag { get; set; }

        [Required]
        public string Maker { get; set; }

        public bool Chk { get; set; }

        public string Checker { get; set; }

        public bool Auth { get; set; }

        public string Auther { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Screen Screen { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
