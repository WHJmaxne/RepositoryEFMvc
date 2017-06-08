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
    public class AssignmentController : BaseController
    {
        //
        // GET: /Tender/Assignment/

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
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAssignment && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue)), u => u.Id, false, "UserInfo", "BillType").ToList();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAssignment, u => u.Id, false, "UserInfo", "BillType").ToList();
            }

            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp, totalCount = totalCount }));
        }

        public ActionResult Total()
        {
            var roleids = operContext.BllSession.UserRoleBLL.LoadEntities(r => r.UserInfoId == operContext.UserSession.Id).Select(r => r.RoleId).ToList();
            string seachValue = Request.Form["seachValue"];
            int list = 0;
            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAssignment && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue))).Count();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && u.ApplyState == ApplyState.PendingAssignment).Count();
            }

            return Content(SerializerHelper.SerializerToString(new { total = list }));
        }
        [HttpGet]
        public ActionResult Agment()
        {
            var selectList = operContext.BllSession.UserInfoBLL.LoadEntities(u => true).Select(u => new SelectListItem()
            {
                Text = u.RealName,
                Value = u.Id.ToString()
            });
            ViewData["SelectUser"] = selectList;
            ViewBag.TapplyId = Request["id"];
            return PartialView();
        }
        [HttpPost]
        public ActionResult Agment(FormCollection form)
        {
            try
            {
                int userId = Convert.ToInt32(form["SelectUser"]);
                int ApplyId = Convert.ToInt32(form["TapplyId"]);
                var tapply = operContext.BllSession.TApplyBLL.LoadEntities(t => t.Id == ApplyId).FirstOrDefault();
                tapply.ReviewTime = DateTime.Now;
                tapply.ProjectManager = userId;
                tapply.ApplyState = ApplyState.PendingAcceptance;
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
