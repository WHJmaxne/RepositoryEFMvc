using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        //
        // GET: /Admin/Menu/
        [Common.Attr.SkipPermission]
        public PartialViewResult Index()
        {
            var pers = operContext.PerSession;
            var perMenu = from p in pers where p.POperationType == 1 && p.PIsDel == false select p;
            perMenu = perMenu.OrderBy(p => p.POrder).ToList();
            //ViewData.Model = perMenu;
            return PartialView("Menu", perMenu);
        }

    }
}
