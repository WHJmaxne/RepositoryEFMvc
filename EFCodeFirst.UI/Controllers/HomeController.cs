using EFCodeFirst.IBLL;
using EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var userList = operContext.BllSession.UserInfoBLL.LoadInculdeEntities(u => true, "Departments").ToList();
            //var userList = bll.UserInfoBLL.LoadEntities(u => true).ToList();
            return View(userList);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //public ActionResult Add(UserInfo user)
        //{
        //    bll.UserInfoBLL.AddEntity(user);
        //    bll.SaveChanges();
        //    return Content("<script>alert('添加成功！');location='Home/Index';</script>");
        //}
    }
}
