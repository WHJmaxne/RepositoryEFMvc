using EFCodeFirst.Common;
using EFCodeFirst.Model;
using EFCodeFirst.Model.ExtensionModel;
using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Tender.Controllers
{
    public class AcceptController : BaseController
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
            IList<TApply> list = new List<TApply>();

            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ProjectManager == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAcceptance && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue)), u => u.Id, false, "UserInfo", "BillType").ToList();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ProjectManager == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAcceptance, u => u.Id, false, "UserInfo", "BillType").ToList();
            }

            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp, totalCount = totalCount }));
        }
        [HttpPost]
        public ActionResult Accept()
        {
            try
            {
                int ssid = Convert.ToInt32(true);
                int id = Convert.ToInt32(Request["Id"]);
                var tapply = operContext.BllSession.TApplyBLL.LoadEntities(t => t.Id == id).FirstOrDefault();
                tapply.ApplyState = ApplyState.PendingRelease;
                operContext.BllSession.SaveChanges();
                return Content("yes:操作成功!");
            }
            catch
            {
                return Content("no:请求异常!");
            }
        }
    }
}
