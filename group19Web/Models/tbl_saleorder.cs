namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webcaycanh.tbl_saleorder")]
    public partial class tbl_saleorder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_saleorder()
        {
            tbl_saleorder_products = new HashSet<tbl_saleorder_products>();
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
        public string code { get; set; }

        [StringLength(100)]
        public string customer_address { get; set; }

        [StringLength(100)]
        public string customer_email { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(100)]
        public string customer_phone { get; set; }

        [StringLength(1000)]
        public string seo { get; set; }

        public decimal? total { get; set; }

        public int? user_id { get; set; }

        public virtual tbl_user tbl_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_saleorder_products> tbl_saleorder_products { get; set; }

        public virtual ICollection<tbl_product> Tbl_Products { get; set; }

        public override string ToString()
        {
            return "name : " + customer_name; 
        }
    }
}
