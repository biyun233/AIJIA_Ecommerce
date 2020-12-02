using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AIJIA.Models;

namespace AIJIA.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return RedirectToAction("Home_list", "Articles");
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddToCart(int ArticleId)
        {
            if(Session["cart"] == null)
            {
                Console.WriteLine("Cart est null");
                var article = db.Articles.Find(ArticleId);
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem()
                {
                    Article = article,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                var equal = false;
                var article = db.Articles.Find(ArticleId);
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                foreach (var item in cart)
                {
                    if (item.Article.ArticleId == ArticleId)
                    {
                        item.Quantity = item.Quantity + 1;
                        equal = true;
                        break;
                    }
                    
                }
                if(equal == false)
                {
                    cart.Add(new CartItem()
                    {
                        Article = article,
                        Quantity = 1,
                    });
                }
                Session["cart"] = cart;
            }
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        public ActionResult AddToCartDetails(int Quantity, int ArticleId)
        {
            var article = db.Articles.Find(ArticleId);
            if (Quantity > article.QuantityStock)
            {
                TempData["AlertMessage"] = "Il n'y a pas assez de stockage.";
                return RedirectToAction("Details", "Articles", new { id = ArticleId });
            }
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem()
                {
                    Article = article,
                    Quantity = Quantity
                });
                Session["cart"] = cart;
            }
            else
            {
                var equal = false;
                
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                foreach (var item in cart)
                {
                    if (item.Article.ArticleId == ArticleId)
                    {
                        item.Quantity = item.Quantity + Quantity;
                        equal = true;
                        break;
                    }

                }
                if (equal == false)
                {
                    cart.Add(new CartItem()
                    {
                        Article = article,
                        Quantity = Quantity,
                    });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Details", "Articles", new { id = ArticleId });
        }

        public ActionResult AddOneCart(int ArticleId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Article.ArticleId == ArticleId)
                {
                    item.Quantity = item.Quantity + 1;
                    break;
                }
            }
            Session["cart"] = cart;

            return Redirect("Cart");
        }

        public ActionResult ReduceOneCart(int ArticleId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Article.ArticleId == ArticleId)
                {
                    item.Quantity = item.Quantity - 1;
                    if(item.Quantity == 0)
                    {
                        cart.Remove(item);
                    }
                    break;
                }
            }
            Session["cart"] = cart;

            return Redirect("Cart");
        }

        public ActionResult RemoveFromCart(int ArticleId)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            
            foreach(var item in cart)
            {
                if(item.Article.ArticleId == ArticleId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}