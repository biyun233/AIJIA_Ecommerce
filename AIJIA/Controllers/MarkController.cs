using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIJIA.Models;

namespace AIJIA.Controllers
{
    public class MarkController : Controller
    {
        // GET: Mark
        public ActionResult Mark()
        {
            return View();
            //using (DbModel db = new DBModels())
            //{ 
            //    return View(); 
            //}
               
        }

        public ActionResult CreateMark()
        {
            return View();
        }
    }
}