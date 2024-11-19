using System.Linq;
using System.Web.Mvc;
using HPlusSport.Web.Classes;
using HPlusSport.Web.Models;

namespace HPlusSport.Web.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly ShopContext db = new ShopContext();

        // GET: Shop
        public ActionResult Index()
        {
            var categories = db.Categories.Include("Articles").ToList();
            return View(categories);
        }

        // GET: Category
        public ActionResult Category(int id)
        {
            var category = db.Categories.Include("Articles").FirstOrDefault(c => c.Id == id);
            if (category == null) return HttpNotFound();
            return View(category);
        }

        // POST: AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int id)
        {
            using (var db = new ShopContext())
            {
                var article = db.Articles.Find(id);
                if (article != null) ShopManager.AddToCart(article);
            }

            return Redirect(Request.UrlReferrer?.ToString() ?? "~/Shop");
        }

        // GET: Cart
        public ActionResult Cart()
        {
            var articles = ShopManager.GetCart();
            return View(articles);
        }

        // POST: Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order()
        {
            var order = ShopManager.CreateOrder();
            return View("ThankYou", order);
        }

        // GET: Shop/Search
        [ValidateInput(false)]
        public ActionResult Search(string q)
        {
            ViewBag.SearchTerm = q;
            return View();
        }

        // GET: Shop/AdminOrders
        public ActionResult AdminOrders()
        {
            var orders = db.Orders.ToList();
            return View(orders);
        }

        // GET: Shop/AdminOrder/1
        public ActionResult AdminOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null) return HttpNotFound();

            var totalAmount = order.Articles.Sum(a => a.Price);
            ViewBag.TotalAmount = totalAmount;

            return View(order);
        }
    }
}