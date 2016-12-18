using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Sys.Controllers
{
    public class SysController : BaseController
    {
        [Common.Attr.SkipPermission]
        public ActionResult OutLogin()
        {
            operContext.OutLogin();
            return operContext.JsMsg("退出成功！", "/User/Login");
        }

    }
}
