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
    public class tbl_categoryController : Controller
    {
        private CategoryDAO CategoryDAO = new CategoryDAO();
        private CayCanhDB db = new CayCanhDB();


        [HttpGet]
        public ActionResult IndexCategory(int? page)
        {
            var category = db.tbl_category.Select(s => s);
            category = category.OrderBy(s => s.id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(category.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Search(int? page)
        {
            string searchText = Request["searchText"];
            var category = db.tbl_category.Select(s => s);
            category = category.OrderBy(s => s.id);

            if(searchText != null)
            {
                page = 1;
            }

            if (!String.IsNullOrEmpty(searchText))
            {
                category = category.Where(p => p.name.Contains(searchText));
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(category.ToPagedList(pageNumber, pageSize));
        }

        [ValidateAntiForgeryToken]
        private tbl_category getRequestCategory()
        {
            tbl_category tbl_Category = new tbl_category();
            tbl_Category.name = Request["name"];
            tbl_Category.description = Request["description"];
            tbl_Category.seo = SeoUltil.seo(Request["name"]) + DateTimeUltil.CurrentTimeMillis().ToString();          
            tbl_Category.created_date = DateTime.UtcNow.Date;

            tbl_Category.avatar = "";
            var file = Request.Files["ImageFile"];

            if (file != null && file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/UploadFile/categoryImage/" + fileName);
                file.SaveAs(uploadPath);

                tbl_Category.avatar = fileName;
            }

            return tbl_Category;
        }

        private tbl_category getRequestCategoryForUpdate()
        {
            tbl_category tbl_Category = new tbl_category();
            tbl_Category.name = Request["name"];
            tbl_Category.description = Request["description"];
            tbl_Category.seo = SeoUltil.seo(Request["name"]) + DateTimeUltil.CurrentTimeMillis().ToString();
            tbl_Category.updated_date = DateTime.UtcNow.Date;

            tbl_Category.avatar = Request["OldImageFile"];
            System.Diagnostics.Debug.WriteLine(tbl_Category.avatar);
            var file = Request.Files["ImageFile"];
            System.Diagnostics.Debug.WriteLine(file);

            if (file != null && file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/UploadFile/categoryImage/" + fileName);
                file.SaveAs(uploadPath);
                System.Diagnostics.Debug.WriteLine(fileName);
                tbl_Category.avatar = fileName;
            }


            return tbl_Category;
        }

        // GET: tbl_category
        public ActionResult Index()
        {
            var tbl_category = db.tbl_category.Include(t => t.tbl_category2);
            return View(tbl_category.ToList());
        }

        

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditNew()
        {
            int id = Int32.Parse(Request["id"]);
            ViewBag.category = CategoryDAO.findById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_category.Add(getRequestCategory());
                    db.SaveChanges();
                    
                }
                return RedirectToAction("CreateNew");
            }
            catch(Exception e)
            {
                ViewBag.error = "khong duoc de trong";
                return RedirectToAction("CreateNew");
            }
            
        }

        [HttpPost]
        public ActionResult Update()
        {
            int id = Int32.Parse(Request["id"]);
            CategoryDAO.updateById(id, getRequestCategoryForUpdate());
            return RedirectToAction("IndexCategory");
        }
  
        public ActionResult delete()
        {
            int id = Int32.Parse(Request["id"]);
            CategoryDAO.deleteById(id);
            return RedirectToAction("IndexCategory");
        }

        public ActionResult MainAdmin()
        {
            return View();
        }

        public ActionResult TableAdmin()
        {
            return View();
        }

        // GET: tbl_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = db.tbl_category.Find(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_category);
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult detailCategory()
        {
            var category = (from s in db.tbl_category select s).ToList();
            ViewBag.categories = category;
            return View();
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
