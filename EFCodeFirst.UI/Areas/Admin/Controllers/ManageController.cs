using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Admin.Controllers
{
    public class ManageController : BaseController
    {
        [Common.Attr.SkipPermission]
        public ActionResult Index()
        {
            //ViewBag.usrName = operContext.UserSession.UserName;
            return View();
        }

    }
}
