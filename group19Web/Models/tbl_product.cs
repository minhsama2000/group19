namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("webcaycanh.tbl_product")]
    public partial class tbl_product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_product()
        {
            tbl_products_images = new HashSet<tbl_products_images>();
            tbl_saleorder_products = new HashSet<tbl_saleorder_products>();
        }

        public int id { get; set; }

        public int? created_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_date { get; set; }

        [MaxLength(1)]
        public byte[] status { get; set; }

        public int quantity { get; set; }

        public int? updated_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_date { get; set; }

        [StringLength(200)]
        public string avatar { get; set; }

        [Required]
        [AllowHtml]
        public string detail_description { get; set; }

        public decimal? price { get; set; }

        public decimal? price_sale { get; set; }

        [StringLength(1000)]
        public string seo { get; set; }

        [Required]
        [StringLength(3000)]
        public string short_description { get; set; }

        [Required]
        [StringLength(1000)]
        public string title { get; set; }

        public int? category_id { get; set; }

        public virtual tbl_category tbl_category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_products_images> tbl_products_images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_saleorder_products> tbl_saleorder_products { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
