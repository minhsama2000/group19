using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using group19Web.Models;
using PagedList;
using group19Web.DAO;

namespace group19Web.Controllers
{
    public class tbl_saleorder_productsController : Controller
    {
        private CayCanhDB db = new CayCanhDB();
        private CategoryDAO CategoryDAO = new CategoryDAO();
        // GET: tbl_saleorder_products
        public ActionResult MainAdmin(int? page)
        {
            var order = db.tbl_saleorder_products.Select(s => s);
            order = order.OrderBy(s => s.id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(order.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TableAdmin(int? page)
        {
            var user = db.tbl_user.Select(u => u);
            user = user.OrderBy(u => u.id);

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(user.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Cart()
        {
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;
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
