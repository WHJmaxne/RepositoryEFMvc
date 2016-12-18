using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Common;
using EFCodeFirst.Model;

namespace EFCodeFirst.UI.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index(int id)
        {
            ViewBag.bread = GetBread(id);
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            string pageIndexStr = Request.Form["pageIndex"];
            string pageSizeStr = Request.Form["pageSize"];
            string seachValue = Request.Form["seachValue"];
            int pageIndex = 1;
            int pageSize = 1;
            if (!int.TryParse(pageIndexStr, out pageIndex))
            {
                pageIndex = 1;
            }
            if (!int.TryParse(pageSizeStr, out pageSize))
            {
                pageSize = 10;
            }
            int totalCount = 1;
            int totalPage = 1;
            IList<UserInfo> list = new List<UserInfo>();
            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.UserInfoBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.UserIsDel == false && (u.UserName.Contains(seachValue) || u.RealName.Contains(seachValue)), u => u.Id, true, "Department").ToList();
            }
            else
            {
                list = operContext.BllSession.UserInfoBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.UserIsDel == false, u => u.Id, true, "Department").ToList();
            }
            var temp = list.Select(u => u.ToPOCO(true)).ToList();
            return Content(Common.SerializerHelper.SerializerToString(new { row = temp }));
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            return Content("aa");
        }
        [HttpPost, Common.Attr.SkipPermission]
        public ActionResult Total()
        {
            string seachValue = Request.Form["seachValue"];
            int list = 0;
            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.UserInfoBLL.LoadEntities(u => u.UserIsDel == false && (u.UserName.Contains(seachValue) || u.RealName.Contains(seachValue))).Count();
            }
            else
            {
                list = operContext.BllSession.UserInfoBLL.LoadEntities(u => u.UserIsDel == false).Count();
            }

            return Content(Common.SerializerHelper.SerializerToString(new { total = list }));
        }
    }
}
