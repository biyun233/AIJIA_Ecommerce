using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIJIA.Models;

namespace AIJIA.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Mark).Include(a => a.Provider).Include(a => a.TypeArticle);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.MarkID = new SelectList(db.Marks, "ID", "Name");
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name");
            ViewBag.TypeArticleID = new SelectList(db.TypeArticles, "ID", "Name");
            return View();
        }

        // POST: Articles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Name,Description,TypeArticleID,MarkID,ProviderID,Color,Size,Price,QuantityStock")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarkID = new SelectList(db.Marks, "ID", "Name", article.MarkID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", article.ProviderID);
            ViewBag.TypeArticleID = new SelectList(db.TypeArticles, "ID", "Name", article.TypeArticleID);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarkID = new SelectList(db.Marks, "ID", "Name", article.MarkID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", article.ProviderID);
            ViewBag.TypeArticleID = new SelectList(db.TypeArticles, "ID", "Name", article.TypeArticleID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,Name,Description,TypeArticleID,MarkID,ProviderID,Color,Size,Price,QuantityStock")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarkID = new SelectList(db.Marks, "ID", "Name", article.MarkID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", article.ProviderID);
            ViewBag.TypeArticleID = new SelectList(db.TypeArticles, "ID", "Name", article.TypeArticleID);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
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
