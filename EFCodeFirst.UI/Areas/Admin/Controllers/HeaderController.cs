using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Admin.Controllers
{
    public class HeaderController : BaseController
    {
        //
        // GET: /Admin/Header/
        [Common.Attr.SkipPermission]
        public PartialViewResult Index()
        {
            ViewBag.usrName = operContext.UserSession.UserName;
            return PartialView("Header");
        }

    }
}
