namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("webcaycanh.tbl_category")]
    public partial class tbl_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_category()
        {
            tbl_category1 = new HashSet<tbl_category>();
            tbl_product = new HashSet<tbl_product>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string avatar { get; set; }
        public int? created_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_date { get; set; }

        [MaxLength(1)]
        public byte[] status { get; set; }

        public int? updated_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_date { get; set; }

        [StringLength(100)]
        [AllowHtml]
        public string description { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string seo { get; set; }

        public int? parent_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_category> tbl_category1 { get; set; }

        public virtual tbl_category tbl_category2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_product> tbl_product { get; set; }

        public override string ToString()
        {
            return "id: " + id + " name: " + name + " description: " + description +" updatedDate: " + updated_date + " created date: " + created_date + " avatar: " + avatar;
        }


    }
}
