using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AIJIA.Controllers
{
    public class AdminController : Controller
    {

        // Renvoie la Page d'Administration du Site
        public ActionResult Admin()
        {
            return View();
        }



    }
}