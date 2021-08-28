using System;

using System.Linq;

using System.Web.Mvc;
using group19Web.DAO;
using System.Data;
using PagedList;
using group19Web.Models;
using System.Web;
using group19Web.DTO;
using System.Collections.Generic;

namespace group19Web.Controllers
{
    public class ClientController : Controller
    {
        CategoryDAO CategoryDAO = new CategoryDAO();
        ProductDAO ProductDAO = new ProductDAO();
        UserDAO UserDAO = new UserDAO();
        private CayCanhDB db = new CayCanhDB();
        // GET: Client

        public ActionResult addCart(CartItem cartItem)
        {
            System.Diagnostics.Debug.WriteLine(cartItem.ToString());
            Cart cart = null;
            if (Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
                foreach (CartItem temp in cart.cartItems.ToList())
                {
                    if (temp.productId == cartItem.productId)
                    {
                        temp.finalTotal = temp.finalTotal + cartItem.finalTotal;
                        Session["cart"] = cart;
                    }
                    else
                    {
                        cart.cartItems.Add(temp);
                        Session["cart"] = cart;
                    }
                }
            }
            else
            {
                cart = new Cart();
                cart.cartItems = new List<CartItem>();
                cart.cartItems.Add(cartItem);
                Session["cart"] = cart;
            }
            
            Session["count"] = cart.cartItems.Count;

            decimal total = 0;
            foreach (CartItem cartTotal in cart.cartItems){
                total = total + cartTotal.finalTotal; 
            }
            Session["totalItem"] = total;
            return Json(new { Message = "test", JsonRequestBehavior.AllowGet });
        }

        public ActionResult Index()
        {
            ViewBag.banner = true;
            // get all
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;
            // get all product
            var listProduct = ProductDAO.getAll();
            ViewBag.listProduct = listProduct;
            // get top 8
            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;
            return View();
        }

        public ActionResult detail()
        {
            ViewBag.banner = false;
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            int id = Int32.Parse(Request["id"]);
            ViewBag.productFind = ProductDAO.findById(id);

            // get top 8
            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;
            return View();
        }

        public ActionResult SearchProduct(int? page)
        {
            ViewBag.banner = false;
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            string searchText = Request["searchText"];
            ViewBag.searchText = searchText;

            var product = db.tbl_product.Select(s => s);
            product = product.OrderBy(s => s.id);

            if (searchText != null)
            {
                page = 1;
            }

            if (!String.IsNullOrEmpty(searchText))
            {
                var searchTextArray = searchText.ToLower().Split(' ');
                product = product.Where(t => searchTextArray.Any(s => t.title.ToLower().Contains(s)));
                //product = product.Where(p => p.title.Contains(searchText));
            }

            // get top 8
            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(product.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailCategory(int? page)
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            int id = Int32.Parse(Request["id"]);

            var category = CategoryDAO.findById(id);
            ViewBag.category = category;

            var products = db.tbl_product.Select(p => p);
            products = products.OrderBy(p => p.id).Where(p => p.category_id == id);

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult UserLogin()
        {
            string username = Request["username"];
            string password = Request["password"];
            tbl_user user = UserDAO.findByName(username);

            try
            {
                if (user != null)
                {
                    if (user.password.Equals(password))
                    {
                        Session["user"] = user;
                        return RedirectToAction("Index");
                    }              
                }
                TempData["error"] = "tài khoản hoặc mật khẩu không đúng";
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                return RedirectToAction("Login");
            }   
        }

        public ActionResult UserRegister()
        {
            string username = Request["username"];
            string password = Request["password"];
            string email = Request["email"];
            string address = Request["address"];
            string phone = Request["phone"];
            string fullname = Request["fullname"];
            tbl_user tbl_User = null;

            try
            {
                if(UserDAO.findByName(username) == null)
                {
                    if(UserDAO.findByEmail(email) == null)
                    {
                        tbl_User = new tbl_user();
                        tbl_User.username = username;
                        tbl_User.password = password;
                        tbl_User.role = "user";
                        tbl_User.email = email;
                        tbl_User.created_date = DateTime.UtcNow.Date;
                        tbl_User.address = address;
                        tbl_User.phone = phone;
                        tbl_User.fullname = fullname;
                        db.tbl_user.Add(tbl_User);
                        db.SaveChanges();
                        Session["user"] = tbl_User;
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("this");
                        TempData["message"] = "email đã được sử dụng";
                        return RedirectToAction("Register");
                    }               
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("here");
                    TempData["message"] = "tên tài khoản đã được sử dụng";
                    return RedirectToAction("Register");
                }
                System.Diagnostics.Debug.WriteLine("that");
            }
            catch(Exception e)
            {
                return RedirectToAction("Register");
            }
        }

        public ActionResult UpdateUser()
        {
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            string email = Request["email"];
            string address = Request["address"];
            string phone = Request["phone"];
            string fullname = Request["fullname"];

            tbl_user user = Session["user"] as group19Web.Models.tbl_user;
            System.Diagnostics.Debug.WriteLine(user.ToString());
            System.Diagnostics.Debug.WriteLine(email);
            //System.Diagnostics.Debug.WriteLine(UserDAO.isEmail(email));
            System.Diagnostics.Debug.WriteLine(UserDAO.test(email).ToString());
            try
            {
                    if (!UserDAO.isEmail(email))
                    {
                        user.email = email;
                        user.address = address;
                        user.phone = phone;
                        user.fullname = fullname;
                        user.updated_date = DateTime.UtcNow.Date; 
                        UserDAO.updateUser(user);

                        Session["user"] = user;
                        return RedirectToAction("UserInfor");
                    }
                    else
                    {
                        TempData["messageInfor"] = "email đã được đăng kí cho tài khoản khác";
                        return RedirectToAction("UserInfor");
                    }
                
            }
            catch (Exception e)
            {
                return RedirectToAction("UserInfor");
            }
        }

        public ActionResult UploadImage()
        {
            tbl_user user = Session["user"] as group19Web.Models.tbl_user;
            var file = Request.Files["ImageFile"];

            if (file != null && file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string uploadPath = Server.MapPath("~/UploadFile/userImage/" + fileName);
                file.SaveAs(uploadPath);
                user.avatar = fileName;
            }
            Session["user"] = user;
            UserDAO.updateUserImage(user);
            return RedirectToAction("UserInfor");
        }

        public ActionResult UserInfor()
        {
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            if (TempData["messageInfor"] != null)
            {
                ViewBag.messageInfor = TempData["messageInfor"].ToString();
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"].ToString();
            }

            return View();
        }

        public ActionResult Register()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }

            return View();
        }












        public ActionResult Introduce()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult BuyWay()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult Waranty()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }
        public ActionResult ReturnPolicy()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult ShipPolicy()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult InforPolicy()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult Policy()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult Contact()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }
        public ActionResult Map()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult OfficeCare()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult AquaticCare()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult StoneCare()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        public ActionResult CareTreeService()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            var listTop8Product = ProductDAO.getTop8();
            ViewBag.productTop8 = listTop8Product;

            return View();
        }

        

    }
}