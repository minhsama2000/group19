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
using group19Web.DTO;
using group19Web.Utility;

namespace group19Web.Controllers
{
    public class tbl_saleorder_productsController : Controller
    {
        private CayCanhDB db = new CayCanhDB();
        private CategoryDAO CategoryDAO = new CategoryDAO();
        private ProductDAO ProductDAO = new ProductDAO();
        // GET: tbl_saleorder_products
        public ActionResult MainAdmin(int? page)
        {
            var order = db.tbl_saleorder_products.Select(s => s);
            order = order.OrderBy(s => s.id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(order.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult removecartItem()
        {
            int id = Int32.Parse(Request["id"]);
            Cart cart = null;
            if(Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
                foreach(CartItem temp in cart.cartItems.ToList())
                {
                    if(temp.productId == id)
                    {
                        cart.cartItems.Remove(temp);
                    }
                }
                Session["cart"] = cart;
            }

            Session["count"] = cart.cartItems.Count;

            decimal total = 0;
            foreach (CartItem cartTotal in cart.cartItems)
            {
                total = total + cartTotal.finalTotal;
            }
            Session["totalItem"] = total;

            return RedirectToAction("Cart");
        }
        public ActionResult TableAdmin(int? page)
        {
            var user = db.tbl_user.Select(u => u);
            user = user.OrderBy(u => u.id);

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(user.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult postPayment()
        {
            Cart cart = null;
            if (Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
                tbl_saleorder tbl_Saleorder = new tbl_saleorder();

                if (Request["id"] != null && Request["id"] != "")
                {
                    tbl_Saleorder.user_id = Int32.Parse(Request["id"]);
                }

                tbl_Saleorder.customer_address = Request["address"];
                tbl_Saleorder.customer_email = Request["email"];
                tbl_Saleorder.customer_name = Request["fullname"];
                tbl_Saleorder.customer_phone = Request["phone"];
                tbl_Saleorder.code = "ORDER-" + Utility.DateTimeUltil.CurrentTimeMillis();
                tbl_Saleorder.seo = "ORDER-" + Utility.DateTimeUltil.CurrentTimeMillis();
                tbl_Saleorder.created_date = DateTime.UtcNow.Date;
                tbl_Saleorder.total = Convert.ToDecimal(Session["totalItem"]);

                
                List<tbl_product> tbl_Products = new List<tbl_product>();
                foreach (CartItem temp in cart.cartItems)
                {
                    System.Diagnostics.Debug.WriteLine(temp.productId);
                    System.Diagnostics.Debug.WriteLine((ProductDAO.findByIdAsObj(temp.productId)).ToString());
                    //tbl_saleorder_products tbl_Saleorder_Products = new tbl_saleorder_products();
                    //tbl_Saleorder_Products.tbl_product = ;
                    //tbl_Saleorder_Products.quantity = temp.quantity;
                    //tbl_Saleorder_Products.created_date = DateTime.UtcNow.Date;
                    //System.Diagnostics.Debug.WriteLine(tbl_Saleorder_Products.ToString());
                    //tbl_Products.Add(ProductDAO.findByIdAsObj(temp.productId));
                    tbl_Saleorder.Tbl_Products.Add(ProductDAO.findByIdAsObj(temp.productId));
                    
                }
                db.tbl_saleorder.Add(tbl_Saleorder);

                db.SaveChanges();




            }
            return RedirectToAction("payment");
        }

        public ActionResult payment()
        {
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;
           
            return View();
        }

        public ActionResult UpdateCart()
        {
            int id = Int32.Parse(Request["productId"]);
            int quantity = Int32.Parse(Request["quantity"]);

            System.Diagnostics.Debug.WriteLine(id);

            Cart cart = null;
            if (Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
                foreach (CartItem temp in cart.cartItems)
                {
                    if (temp.productId == id)
                    {
                        temp.quantity = quantity;
                        temp.finalTotal = quantity * temp.priceUnit;

                    }
                }
                Session["cart"] = cart;
            }

            decimal total = 0;
            foreach (CartItem cartTotal in cart.cartItems)
            {
                total = total + cartTotal.finalTotal;
            }
            Session["totalItem"] = total;

            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;
            return View();
        }

        public ActionResult UpdateRole()
        {
            string role = Request["role"];
            int id = Int32.Parse(Request["id"]);

            tbl_user tbl_User = (tbl_user)Session["user"];

            if (tbl_User.role.Equals("fullcontrol"))
            {
                tbl_user tbl_UserFind = db.tbl_user.Where(u => u.id == id).FirstOrDefault();
                tbl_UserFind.role = role;
                db.SaveChanges();
            }
            else
            {
                ViewBag.error = "bạn không có quyền";
            }

            

            return RedirectToAction("TableAdmin");
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
