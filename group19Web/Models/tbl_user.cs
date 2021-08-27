namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webcaycanh.tbl_user")]
    public partial class tbl_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_user()
        {
            tbl_saleorder = new HashSet<tbl_saleorder>();
        }

        public int id { get; set; }

        public int? created_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_date { get; set; }

        [MaxLength(1)]
        public byte[] status { get; set; }

        public int? updated_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_date { get; set; }

        [Required]
        [StringLength(45)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [Required]
        [StringLength(45)]
        public string username { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        [Required]
        [StringLength(45)]
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_saleorder> tbl_saleorder { get; set; }

        public override string ToString()
        {
            return "username: " + username + " password :" + password + " role: " + role + " email: " + email;
        }
    }
}
