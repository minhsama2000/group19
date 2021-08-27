namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webcaycanh.tbl_products_images")]
    public partial class tbl_products_images
    {
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
        [StringLength(200)]
        public string path { get; set; }

        [Required]
        [StringLength(500)]
        public string title { get; set; }

        public int product_id { get; set; }

        public virtual tbl_product tbl_product { get; set; }
    }
}
