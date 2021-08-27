namespace group19Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webcaycanh.tbl_saleorder_products")]
    public partial class tbl_saleorder_products
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

        public int quality { get; set; }

        public int product_id { get; set; }

        public int saleorder_id { get; set; }

        public virtual tbl_product tbl_product { get; set; }

        public virtual tbl_saleorder tbl_saleorder { get; set; }
    }
}
