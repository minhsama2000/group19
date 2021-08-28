using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using group19Web.Models;
using group19Web.DAO;
using group19Web.Utility;
using PagedList;

namespace group19Web.Controllers
{
    [ValidateInput(false)]
    public class tbl_productController : Controller
    {
        private CayCanhDB db = new CayCanhDB();
        private ProductDAO ProductDAO = new ProductDAO();
        private CategoryDAO CategoryDAO = new CategoryDAO();
        // GET: tbl_product

        [ValidateInput(false)]      
        private tbl_product getRequestProduct()
        {
            tbl_product tbl_Product = new tbl_product();
            tbl_Product.title = Request["title"];
            tbl_Product.price = decimal.Parse(Request["price"]);
            tbl_Product.price_sale = decimal.Parse(Request["priceSale"]);
            tbl_Product.short_description = Request["shortDescription"];
            tbl_Product.detail_description = Request["detailDescription"];
            tbl_Product.quantity = Int32.Parse(Request["quantity"]);
            tbl_Product.avatar = "";
            var file = Request.Files["ImageFile"];
            System.Diagnostics.Debug.WriteLine(file);
            if (file != null && file.ContentLength >0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/UploadFile/productImage/" + fileName);
                file.SaveAs(uploadPath);

                tbl_Product.avatar = fileName;
            }

            

            tbl_Product.seo = SeoUltil.seo(Request["title"]) + DateTimeUltil.CurrentTimeMillis().ToString();
            tbl_Product.created_date = DateTime.UtcNow.Date;
            tbl_Product.category_id = Int32.Parse(Request["selectCate"]);
            return tbl_Product;
        }

        private tbl_product getRequestProductForUpdate()
        {
            tbl_product tbl_Product = new tbl_product();
            tbl_Product.title = Request["title"];
            tbl_Product.price = decimal.Parse(Request["price"]);
            tbl_Product.price_sale = decimal.Parse(Request["priceSale"]);
            tbl_Product.short_description = Request["shortDescription"];
            tbl_Product.detail_description = Request["detailDescription"];
            tbl_Product.quantity = Int32.Parse(Request["quantity"]);

            tbl_Product.avatar = Request["OldImageFile"];
            var file = Request.Files["ImageFile"];

            if (file != null && file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/UploadFile/productImage/" + fileName);
                file.SaveAs(uploadPath);
                tbl_Product.avatar = fileName;
            }

            tbl_Product.seo = SeoUltil.seo(Request["title"]) + DateTimeUltil.CurrentTimeMillis().ToString();
            tbl_Product.updated_date = DateTime.UtcNow.Date;


            tbl_Product.category_id = Int32.Parse(Request["selectCate"]);

            return tbl_Product;
        }


        public ActionResult IndexProduct(int? page)
        {
            var product = db.tbl_product.Select(s => s);
            product = product.OrderBy(s => s.id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(product.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SearchProduct(int? page)
        {
            string searchText = Request["searchText"];
            var product = db.tbl_product.Select(s => s);
            product = product.OrderBy(s => s.id);

            if (searchText != null)
            {
                page = 1;
            }

            if (!String.IsNullOrEmpty(searchText))
            {
                product = product.Where(p => p.title.Contains(searchText));
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(product.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CreateNew()
        {
            ViewBag.categories = CategoryDAO.getAll();
            return View();
        }
        public ActionResult UpdateNew()
        {
            int id = Int32.Parse(Request["id"]);
            ViewBag.categories = CategoryDAO.getAll();
            ViewBag.product = ProductDAO.findById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Update(FormCollection obj)
        {
            int id = Int32.Parse(Request["id"]);
            tbl_product tbl_Product = getRequestProductForUpdate();
            if (CategoryDAO.findById((int)tbl_Product.category_id) != CategoryDAO.findByName(obj["hidText"].ToString()))
            {
                tbl_Product.category_id = CategoryDAO.findByName(obj["hidText"].ToString()).id;
                System.Diagnostics.Debug.WriteLine(tbl_Product.category_id);
            }
            ProductDAO.updateById(id, tbl_Product);
            return RedirectToAction("IndexProduct");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create()
        {
            db.tbl_product.Add(getRequestProduct());
            System.Diagnostics.Debug.WriteLine(getRequestProduct().avatar);
            db.SaveChanges();
            return RedirectToAction("CreateNew");
        }

        public ActionResult delete()
        {
            int id = Int32.Parse(Request["id"]);
            ProductDAO.deleteById(id);
            return RedirectToAction("IndexProduct");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
