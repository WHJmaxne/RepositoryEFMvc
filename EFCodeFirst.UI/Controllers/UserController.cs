using EFCodeFirst.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Model.ViewModel.LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return Content(operContext.JsonMsgErr("警告：请勿关闭浏览器JS功能！"));
            }
            if (operContext.valiSession == null || !user.ValidataNum.IsSameStr(operContext.valiSession))
            {
                operContext.valiSession = null;
                return Content(operContext.JsonMsgNoOK("验证码不正确"));
            }
            var usr = operContext.BllSession.UserInfoBLL.Login(user.UserName, user.UserPwd.MD5());
            if (usr == null)
            {
                return Content(operContext.JsonMsgNoOK("用户名或密码错误！"));
            }
            //将当前登陆用户存入session
            operContext.UserSession = usr;
            //获取当前登陆用户权限
            var pers = operContext.BllSession.UserInfoBLL.UserPermission(usr.Id).ToList();
            //将当前用户权限存入session
            operContext.PerSession = pers;
            string remuser = Request.Form["RemUser"];
            if (remuser != null && remuser.Length > 0)
            {
                operContext.UserIdCookie = usr.Id;
            }
            return Content(operContext.JsonMsgOK("登陆成功", "/Admin/Manage/Index"));
        }
        public ActionResult ValidataImage()
        {
            var s1 = new ValidateCode_Style4();
            string code = "6666";
            byte[] bytes = s1.CreateImage(out code);
            operContext.valiSession = code;
            return File(bytes, @"image/jpeg");
        }
    }
}
