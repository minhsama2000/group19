using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using group19Web.Models;

namespace group19Web.DAO
{
    public class ProductDAO
    {
        private CayCanhDB db = new CayCanhDB();

        public dynamic getAll()
        {
            var products = (from s in db.tbl_product select s).ToList();
            return products;
        }

        public dynamic getTop8()
        {
            var products = (from t in db.tbl_product orderby t.created_date select t).Take(8);
            return products;
        }

        public tbl_product findByIdAsObj(int id)
        {
            var product = (from s in db.tbl_product where s.id == id select s).FirstOrDefault();
            return product;
        }

        public dynamic findById(int id)
        {
            var product = (from s in db.tbl_product where s.id == id select s).FirstOrDefault();
            return product;
        }

        public dynamic getAllByCateId(int id)
        {
            var products = (from s in db.tbl_product where s.category_id == id select s).ToList();
            return products;
        }


        public void updateById(int id, tbl_product tbl_Product)
        {
            tbl_product tbl_ProductFind = db.tbl_product.Where(s => s.id == id).FirstOrDefault();
            tbl_ProductFind.title = tbl_Product.title;
            tbl_ProductFind.updated_date = tbl_Product.updated_date;
            tbl_ProductFind.price = tbl_Product.price;
            tbl_ProductFind.price_sale = tbl_Product.price_sale;
            tbl_ProductFind.short_description = tbl_Product.short_description;
            tbl_ProductFind.detail_description = tbl_Product.detail_description;
            tbl_ProductFind.seo = tbl_Product.seo;
            tbl_ProductFind.quantity = tbl_Product.quantity;
            tbl_ProductFind.avatar = tbl_Product.avatar;
            if (tbl_ProductFind.category_id != tbl_Product.category_id)
            {
                tbl_ProductFind.category_id = tbl_Product.category_id;
            }

            System.Diagnostics.Debug.WriteLine(tbl_ProductFind.ToString());
            db.SaveChanges();
        }

        public void deleteById(int id)
        {
            var delete = (from s in db.tbl_product
                          where s.id == id
                          select s).First();
            db.tbl_product.Remove(delete);
            db.SaveChanges();
        }

    }  
}