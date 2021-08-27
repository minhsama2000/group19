using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using group19Web.Models;
using PagedList;

namespace group19Web.DAO
{  
    public class CategoryDAO
    {
        private CayCanhDB db = new CayCanhDB();
        public dynamic getAll() { 
            var category = (from s in db.tbl_category select s).ToList();
            return category;
        }

        public dynamic getAllWithPage()
        {
            var category = db.tbl_category.Select(s => s);
            category = category.OrderBy(s => s.id);
            return category;
        }

        public tbl_category findByName(string name)
        {
            var category = (from s in db.tbl_category where s.name == name select s).FirstOrDefault();
            return category;
        }

        public tbl_category findByIdObject(int id)
        {
            var category = (from s in db.tbl_category where s.id == id select s).FirstOrDefault();
            return category;
        }


        public dynamic findById(int id)
        {
            var category = (from s in db.tbl_category where s.id == id select s).FirstOrDefault();
            return category;
        }

        public void updateById(int id,tbl_category tbl_Category)
        {
            tbl_category tbl_CategoryFind = db.tbl_category.Where(s => s.id == id).FirstOrDefault();
            tbl_CategoryFind.name = tbl_Category.name;
            tbl_CategoryFind.updated_date = tbl_Category.updated_date;
            tbl_CategoryFind.description = tbl_Category.description;
            tbl_CategoryFind.seo = tbl_Category.seo;
            tbl_CategoryFind.avatar = tbl_Category.avatar;
            System.Diagnostics.Debug.WriteLine(tbl_CategoryFind.ToString());
            db.SaveChanges();
        }

        public void deleteById(int id)
        {
            var delete = (from s in db.tbl_category
                           where s.id == id
                           select s).First();
            db.tbl_category.Remove(delete);
            db.SaveChanges();

        }
    }
}