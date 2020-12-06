using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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

        public ActionResult AddOrder()
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            decimal total = 0;
            decimal delivery = 10;

            //Save Facture
            Facture facture = new Facture();
            facture.DateFacture = DateTime.UtcNow.Date;
            db.Factures.Add(facture);

            db.SaveChanges();
            //Save Order
            Order order = new Order();
            order.DateOrder = DateTime.UtcNow.Date;
            order.UserID = User.Identity.GetUserId();
            order.FactureID = facture.ID;
            db.Orders.Add(order);

            db.SaveChanges();

            //Save Order Details
            foreach (var item in cart)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.ArticleId = item.Article.ArticleId;
                orderDetails.Quantity = item.Quantity;
                orderDetails.Price = item.Article.Price;
                orderDetails.OrderId = order.ID;
                db.OrderDetails.Add(orderDetails);
                db.SaveChanges();
                total = total + item.Quantity * item.Article.Price;
            }

            order = db.Orders.Find(order.ID);
            order.TotalAmount = total + delivery;
            order.AmountDelivery = delivery;

            facture = db.Factures.Find(facture.ID);
            facture.Vat = total * (decimal)0.2;
            facture.InclVat = total;
            facture.ExclVat = total - facture.Vat;
            db.SaveChanges();
            Session.Remove("cart");
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult AddToCart(int ArticleId)
        {
            if(Session["cart"] == null)
            {
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