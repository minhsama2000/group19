using System;

using System.Linq;

using System.Web.Mvc;
using group19Web.DAO;
using System.Data;
using PagedList;
using group19Web.Models;

namespace group19Web.Controllers
{
    public class ClientController : Controller
    {
        CategoryDAO CategoryDAO = new CategoryDAO();
        ProductDAO ProductDAO = new ProductDAO();
        private CayCanhDB db = new CayCanhDB();
        // GET: Client
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

        public ActionResult Login()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            return View();
        }

        public ActionResult Register()
        {
            // get all cate
            var listCategory = CategoryDAO.getAll();
            ViewBag.categories = listCategory;

            return View();
        }

    }
}