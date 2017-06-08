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
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue)), u => u.Id, false, "UserInfo", "BillType").ToList();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id, u => u.Id, false, "UserInfo", "BillType").ToList();
            }

            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp, totalCount = totalCount }));
        }

        public ActionResult Total()
        {
            string seachValue = Request.Form["seachValue"];
            int list = 0;
            if (!seachValue.IsNullOrEmpty())
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id && (u.ApplyName.Contains(seachValue) || u.ApplyId.Contains(seachValue))).Count();
            }
            else
            {
                list = operContext.BllSession.TApplyBLL.LoadEntities(u => u.IsDelete == false && u.ApplyUser == operContext.UserSession.Id).Count();
            }

            return Content(SerializerHelper.SerializerToString(new { total = list }));
        }
        public ActionResult BillTotal()
        {
            string seachValue = Request.Form["seachValue"];
            int list = operContext.BllSession.TapplyBillBLL.LoadEntities(u => u.TApplyNumber == seachValue).Count();
            return Content(SerializerHelper.SerializerToString(new { total = list }));
        }
        public ActionResult GetBillList()
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
                pageSize = 5;
            }
            int totalCount = 1;
            int totalPage = 1;
            var list = operContext.BllSession.TapplyBillBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => u.TApplyNumber == seachValue, u => u.Id, true).ToList();
            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp, totalCount = totalCount }));
        }
        public ActionResult Detail()
        {
            int id = Convert.ToInt32(Request["Id"]);
            var model = operContext.BllSession.TApplyBLL.LoadEntities(t => t.Id == id).FirstOrDefault();
            return PartialView(model);
        }
        public ActionResult GetCompanyList()
        {
            string pageIndexStr = Request.Form["pageIndex"];
            string pageSizeStr = Request.Form["pageSize"];
            var seachValues = Request.Form["seachValue"].TrimEnd(',').Split(',').ToList();
            List<int> idList = new List<int>();
            seachValues.ForEach(s => idList.Add(Convert.ToInt32(s)));
            int pageIndex = 1;
            int pageSize = 1;
            if (!int.TryParse(pageIndexStr, out pageIndex))
            {
                pageIndex = 1;
            }
            if (!int.TryParse(pageSizeStr, out pageSize))
            {
                pageSize = 5;
            }
            int totalCount = 1;
            int totalPage = 1;
            var list = operContext.BllSession.SupplierBLL.LoadPageEntities(pageIndex, pageSize, out totalCount, out totalPage, u => idList.Contains(u.Id), u => u.Id, true).ToList();
            var temp = list.Select(u => u.ToPOCO()).ToList();
            return Content(SerializerHelper.SerializerToString(new { row = temp }));
        }
        [HttpGet]
        public ActionResult AddTender(int id)
        {
            ViewBag.bread = GetBread(id);
            ViewBag.plantypes = Enumeration.GetPlanTypes().Select(p => new SelectListItem()
            {
                Value = p.Value.ToString(),
                Text = p.Text,
                Selected = p.Value == 1
            });
            ViewBag.projecttypes = Enumeration.GetProjectTypes().Select(p => new SelectListItem()
            {
                Value = p.Value.ToString(),
                Text = p.Text,
                Selected = p.Value == 1
            });
            ViewBag.billtypes = operContext.BllSession.BillTypeBLL.LoadEntities(b => true).Select(b => new SelectListItem()
            {
                Value = b.Id.ToString(),
                Text = b.BillTypeName
            });
            ViewBag.ExtenUser = operContext.BllSession.RoleBLL.LoadEntities(r => true).Select(r => new SelectListItem()
            {
                Text = r.RoleName,
                Value = r.Id.ToString(),
                Selected = r.Id == 1

            });
            ViewBag.User = operContext.UserSession;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteTapply()
        {
            try
            {
                int id = Convert.ToInt32(Request["Id"]);
                operContext.BllSession.TapplySupplierBLL.DeleteList(t => t.TApplyId == id);
                operContext.BllSession.TApplyBLL.DeleteList(t => t.Id == id);
                operContext.BllSession.SaveChanges();
                return Content("yes:删除成功!");
            }
            catch
            {
                return Content("no:删除失败!");
            }
        }
        [HttpPost]
        public ActionResult AddTender(TApply tapply)
        {
            try
            {
                tapply.CreateTime = DateTime.Now;
                tapply.IsDelete = false;
                tapply.ApplyState = ApplyState.PendingAudit;
                operContext.BllSession.TApplyBLL.AddEntity(tapply);
                if (!tapply.CompanyIds.IsNullOrEmpty())
                {
                    var ids = tapply.CompanyIds.TrimEnd(',').Split(',').ToList();
                    TapplySupplier ts;
                    ids.ForEach(a =>
                    {
                        ts = new TapplySupplier();
                        ts.SupplierId = Convert.ToInt32(a);
                        ts.TApplyId = tapply.Id;
                        operContext.BllSession.TapplySupplierBLL.AddEntity(ts);
                    });
                }
                operContext.BllSession.SaveChanges();
                return Content("yes:提交成功!");
            }
            catch
            {
                return Content("no:请求异常!");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.applyNum = Request["ApplyNum"];
            ViewBag.billType = Request["BillType"];
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(TapplyBill bill)
        {
            bill.CreateTime = DateTime.Now;
            bill.IsDelete = false;
            operContext.BllSession.TapplyBillBLL.AddEntity(bill);
            operContext.BllSession.SaveChanges();
            return Content("yes:添加成功！");

        }

        public ActionResult DeleteBills()
        {
            try
            {
                string ids = Request["Ids"];
                var idArr = ids.TrimEnd(',').Split(',').ToList();
                List<int> idList = new List<int>();
                idArr.ForEach(i => idList.Add(Convert.ToInt32(i)));
                operContext.BllSession.TapplyBillBLL.DeleteList(t => idList.Contains(t.Id));
                operContext.BllSession.SaveChanges();
                return Content("yes:删除成功！");
            }
            catch
            {
                return Content("no:删除失败，请检查网络状态！");
            }
        }

        public ActionResult SelectCompany()
        {
            var company = operContext.BllSession.SupplierBLL.LoadEntities(c => c.SupplierState > 0);
            return PartialView(company);
        }
    }
}
