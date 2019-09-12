using App.UI.Web.Helpers;
using App.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Edit()
        {
            var model = new UserViewModel();
            model.ID = SecurityHelpers.GetUserID();
            return View(model);
        }

       

    }
}
