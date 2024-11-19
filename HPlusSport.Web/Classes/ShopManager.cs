using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HPlusSport.Web.Models;

namespace HPlusSport.Web.Classes
{
    public static class ShopManager
    {
        private const string sessionName = "cart";

        public static List<Article> GetCart()
        {
            var articles = HttpContext.Current.Session[sessionName] as List<Article>;
            if (articles == null) articles = new List<Article>();
            return articles;
        }

        public static bool AddToCart(Article article)
        {
            var articles = GetCart();
            if (articles.Contains(article)) return false;

            articles.Add(article);
            HttpContext.Current.Session[sessionName] = articles;
            return true;
        }

        public static bool RemoveFromCart(Article article)
        {
            var articles = GetCart();
            if (!articles.Contains(article)) return false;

            articles.Remove(article);
            HttpContext.Current.Session[sessionName] = articles;
            return true;
        }

        public static Order CreateOrder()
        {
            var articles = GetCart();
            if (articles.Count() == 0) throw new InvalidOperationException("Shopping cart is empty");
            using (var db = new ShopContext())
            {
                var order = new Order
                {
                    Articles = articles,
                    OrderDate = DateTime.Now,
                    User = db.Users.Single(u => u.Email == HttpContext.Current.User.Identity.Name)
                };
                db.Orders.Add(order);
                db.SaveChanges();
                EmptyCart();
                return order;
            }
        }

        private static bool EmptyCart()
        {
            HttpContext.Current.Session.Remove(sessionName);
            return true;
        }
    }
}