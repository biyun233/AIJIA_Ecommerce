using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using AIJIA.Models;
using System.Threading.Tasks;

namespace AIJIA.Controllers
{
    public class RoleController : Controller
    {
        private UserRoleManager _userRoleManager;
        public RoleController() { }

        public RoleController(UserRoleManager userRoleManager)
        {
            RoleManager = userRoleManager;
        }

        public UserRoleManager RoleManager
        {
            get
            {
                return _userRoleManager ?? HttpContext.GetOwinContext().Get<UserRoleManager>();
            }
            private set
            {
                _userRoleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var userRole in RoleManager.Roles)
                list.Add(new RoleViewModel(userRole));
            return View(list);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model) 
        {
            var userRole = new UserRole() { Name = model.Name };
            await RoleManager.CreateAsync(userRole);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id) 
        {
            var userRole = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(userRole));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model) 
        {
            var userRole = new UserRole() { Id = model.Id, Name = model.Name };

            if(await RoleManager.FindByNameAsync(model.Name) != null) 
            {
                return RedirectToAction("Index");
            }
            else 
            {
                await RoleManager.UpdateAsync(userRole);
                return RedirectToAction("Index");

            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            var userRole = await RoleManager.FindByIdAsync(id);

            return View(new RoleViewModel(userRole));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var userRole = await RoleManager.FindByIdAsync(id);

            await RoleManager.DeleteAsync(userRole);

            return RedirectToAction("Index");
        }




    }
}