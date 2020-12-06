using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIJIA.Models;
using System.Net;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Identity.Controllers
{
    public class AdminUsersController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: AdminUsers
        public virtual ActionResult Index()
        {
            var users = db.Users;
            return View(users.ToList());
        }

        // Edit: AdminUsers
        public ActionResult Edit(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AIJIA.ApplicationUserManager>();



            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser = userManager.FindById(id);
            AIJIA.Models.ApplicationUser user = new AIJIA.Models.ApplicationUser();
            user.Address = applicationUser.Address;
            user.Firstname = applicationUser.Firstname;
            user.Lastename = applicationUser.Lastename;
            user.Address = applicationUser.Address;
            user.PostalCode = applicationUser.PostalCode;
            user.City = applicationUser.City;
            user.Country = applicationUser.Country;
            user.Phone = applicationUser.Phone;
            user.Birthday = applicationUser.Birthday;
            user.Sex = applicationUser.Sex;
            user.IsAdmin = applicationUser.IsAdmin;

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AIJIA.Models.ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(model.Id);
            currentUser.Firstname = model.Firstname;
            currentUser.Lastename = model.Lastename;
            currentUser.PostalCode = model.PostalCode;
            currentUser.Address = model.Address;
            currentUser.City = model.City;
            currentUser.Country = model.Country;
            currentUser.Phone = model.Phone;
            currentUser.Birthday = model.Birthday;
            currentUser.Sex = model.Sex;
            currentUser.IsAdmin = model.IsAdmin;

            await manager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        //// Delete With Ajax
        //public JsonResult DeleteUser(int UserID)
        //{
        //    bool result = false;
        //    AIJIA.Models.ApplicationUser model = db.Users.Where(x => x.ID == UserID).SingleOrDefault();
        //    if (model != null)
        //    {
        //        db.Users.Remove(model);
        //        db.SaveChanges();
        //        result = true;
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


    }
}