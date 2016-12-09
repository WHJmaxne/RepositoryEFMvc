using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Admin/Menu/
        [Common.Attr.SkipPermission]
        public PartialViewResult Index()
        {
            return PartialView("Menu");
        }

    }
}
