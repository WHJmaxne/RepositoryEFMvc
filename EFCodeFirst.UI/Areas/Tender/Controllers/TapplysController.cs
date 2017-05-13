using EFCodeFirst.Common;
using EFCodeFirst.Model;
using EFCodeFirst.Model.ExtensionModel;
using EFCodeFirst.Model.ViewModel;
using EFCodeFirst.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Areas.Tender.Controllers
{
    public class TapplysController : BaseController
    {
        //
        // GET: /Tapply/Tapply/

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
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue)), u => u.Id, true, "UserInfo", "BillType").ToList();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false, u => u.Id, true, "UserInfo", "BillType").ToList();
            }
            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp }));
        }

        public ActionResult Total()
        {
            string seachValue = Request.Form["seachValue"];
            int list = 0;
            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue))).Count();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false).Count();
            }

            return Content(Common.SerializerHelper.SerializerToString(new { total = list }));
        }
        public ActionResult AddTender(int id)
        {
            ViewBag.bread = GetBread(id);
            ViewBag.plantypes = Enumeration.GetPlanTypes().Select(p => new SelectListItem()
            {
                Value = p.Value.ToString(),
                Text = p.Text,
                Selected = p.Value == 0
            });
            ViewBag.projecttypes = Enumeration.GetProjectTypes().Select(p => new SelectListItem()
            {
                Value = p.Value.ToString(),
                Text = p.Text,
                Selected = p.Value == 0
            });
            ViewBag.billtypes = operContext.BllSession.BillTypeBLL.LoadEntities(b => true).Select(b => new SelectListItem()
            {
                Value = b.Id.ToString(),
                Text = b.BillTypeName
            });
            return View();
        }
    }
}
