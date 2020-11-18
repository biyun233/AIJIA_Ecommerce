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
    public class TypeArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeArticles
        public ActionResult Index()
        {
            return View(db.TypeArticles.ToList());
        }

        // GET: TypeArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeArticle typeArticle = db.TypeArticles.Find(id);
            if (typeArticle == null)
            {
                return HttpNotFound();
            }
            return View(typeArticle);
        }

        // GET: TypeArticles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeArticles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TypeArticle typeArticle)
        {
            if (ModelState.IsValid)
            {
                db.TypeArticles.Add(typeArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeArticle);
        }

        // GET: TypeArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeArticle typeArticle = db.TypeArticles.Find(id);
            if (typeArticle == null)
            {
                return HttpNotFound();
            }
            return View(typeArticle);
        }

        // POST: TypeArticles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TypeArticle typeArticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeArticle);
        }

        // Delete With Ajax
        public JsonResult DeleteTypeArticle(int TypeArticleID)
        {
            bool result = false;
            TypeArticle typeArticle = db.TypeArticles.Where(x => x.ID == TypeArticleID).SingleOrDefault();
            if (typeArticle != null)
            {
                db.TypeArticles.Remove(typeArticle);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
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
