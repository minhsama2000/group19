using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace group19Web.Models
{
    public partial class CayCanhDB : DbContext
    {
        public CayCanhDB()
            : base("name=CayCanhDB")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_contact> tbl_contact { get; set; }
        public virtual DbSet<tbl_product> tbl_product { get; set; }
        public virtual DbSet<tbl_products_images> tbl_products_images { get; set; }
        public virtual DbSet<tbl_saleorder> tbl_saleorder { get; set; }
        public virtual DbSet<tbl_saleorder_products> tbl_saleorder_products { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_category>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_category>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_category>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_category>()
                .HasMany(e => e.tbl_category1)
                .WithOptional(e => e.tbl_category2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<tbl_category>()
                .HasMany(e => e.tbl_product)
                .WithOptional(e => e.tbl_category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<tbl_contact>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_contact>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_contact>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.price)
                .HasPrecision(13, 2);

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.price_sale)
                .HasPrecision(19, 2);

            modelBuilder.Entity<tbl_product>()
                .HasMany(e => e.tbl_products_images)
                .WithRequired(e => e.tbl_product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_product>()
                .HasMany(e => e.tbl_saleorder_products)
                .WithRequired(e => e.tbl_product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_products_images>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_products_images>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_products_images>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_saleorder>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_saleorder>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_saleorder>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_saleorder>()
                .Property(e => e.total)
                .HasPrecision(13, 2);

            modelBuilder.Entity<tbl_saleorder>()
                .HasMany(e => e.tbl_saleorder_products)
                .WithRequired(e => e.tbl_saleorder)
                .HasForeignKey(e => e.saleorder_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_saleorder_products>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_saleorder_products>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_saleorder_products>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.created_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.updated_date)
                .HasPrecision(6);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_saleorder)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);
        }
    }
}
