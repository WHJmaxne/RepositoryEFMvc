using EFCodeFirst.Common.Attr;
using EFCodeFirst.Common;
using EFCodeFirst.Model;
using EFCodeFirst.Model.FormatModel;
using EFCodeFirst.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Filter
{
    public class PermissionValidataAttribute : AuthorizeAttribute
    {
        #region 权限过滤器
        /// <summary>
        /// 权限过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //创建要验证的区域名单
            List<string> areasList = new List<string>() { "Admin", "Sys", "Tender" };
            //验证当前请求的区域名是否在名单中
            //验证当前url是否存在区域
            if (filterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                //获取区域名
                string areaName = filterContext.RouteData.DataTokens["area"].ToString();
                //验证当前区域是否存在区域名单中
                if (!areasList.Contains(areaName, StringComparer.CurrentCultureIgnoreCase))
                {
                    ProcessResult(filterContext, AjaxMsgStatu.NoPer, "您没有操作权限！", "/User/Login");
                }
                //验证被请求的方法或者类上是否贴有跳过登陆标签，如果没有贴，则进行登陆验证
                if (!DoseSticAttr<SkipLoginAttribute>(filterContext.ActionDescriptor))
                {
                    if (IsLogin())
                    {
                        //获取控制器名称
                        string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                        //获取方法名称
                        string actionName = filterContext.ActionDescriptor.ActionName;
                        //获取请求方式
                        string httpMethod = filterContext.HttpContext.Request.HttpMethod;
                        //验证被请求的方法或者类上是否贴有跳过权限验证标签，如果没有贴，则进行权限验证
                        if (!DoseSticAttr<SkipPermissionAttribute>(filterContext.ActionDescriptor))
                        {
                            if (!HasPermission(areaName, controllerName, actionName, httpMethod))
                            {
                                ProcessResult(filterContext, AjaxMsgStatu.NoPer, "您没有权限访问", "/User/Login");
                            }
                        }
                    }
                    else
                    {
                        ProcessResult(filterContext, AjaxMsgStatu.NoLogin, "您没有登录", "/User/Login");
                    }
                }
            }
        }
        #endregion

        #region 验证是否登录(自动登录)
        /// <summary>
        /// 验证是否登录(自动登录)
        /// </summary>
        /// <returns></returns>
        private bool IsLogin()

        {
            bool isLogin = true;
            //1.是否有session
            //1.1如果session中没有登录对象
            if (operContext.UserSession == null)
            {
                //2.验证cookie是否存在
                if (operContext.UserIdCookie < 0)
                {
                    //2.1返回没有登录的错误消息
                    isLogin = false;
                }
                //2.2如果id大于0 说明登录有效
                else
                {
                    //2.3查询登录用户
                    var userModel = operContext.BllSession.UserInfoBLL.LoadEntities(u => u.Id == operContext.UserIdCookie).FirstOrDefault();
                    //2.4如果不等于空，则登录成功
                    if (userModel != null)
                    {
                        //2.5登录成功，加载用户权限，并存入session
                        operContext.PerSession = operContext.BllSession.UserInfoBLL.UserPermission(userModel.Id).ToList();
                        //2.6将当前登录的用户对象存到 session 中
                        operContext.UserSession = userModel;
                    }
                    else
                    {
                        isLogin = false;
                    }
                }
            }
            return isLogin;
        }
        #endregion

        #region 检查当前url是否在用户登录权限中
        /// <summary>
        /// 检查当前url是否在用户登录权限中
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private bool HasPermission(string areaName, string controllerName, string actionName, string method)
        {
            var perList = operContext.PerSession;
            var perNow = perList.ToList().Find(delegate (Permission per) { return per.PAreaName.IsSameStr(areaName) && per.PControllerName.IsSameStr(controllerName) && per.PActionName.IsSameStr(actionName) && (method.IsSameStr("get") ? (per.PFormmethod == 1 || per.PFormmethod == 3) : (per.PFormmethod == 2 || per.PFormmethod == 3)); });
            if (perNow == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 根据方法被请求的方式，返回不同的 js 代码（json/js）
        /// <summary>
        /// 根据方法被请求的方式，返回不同的 js 代码（json/js）
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="statu"></param>
        /// <param name="msg"></param>
        /// <param name="backUrl"></param>
        /// <param name="data"></param>
        private void ProcessResult(AuthorizationContext filterContext, AjaxMsgStatu statu, string msg = "", string backUrl = "", object data = null)
        {
            if (DoseSticAttr<AjaxRequestAttribute>(filterContext.ActionDescriptor))
            {
                filterContext.Result = new ContentResult() { Content = operContext.JsonMsg(statu, msg, backUrl, data) };
            }
            else
            {
                filterContext.Result = operContext.JsMsg(msg, backUrl);
            }
        }
        #endregion

        #region 判断方法和类是否贴有指定的标记
        /// <summary>
        /// 判断方法和类是否贴有指定的标记
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool DoseSticAttr<T>(ActionDescriptor action)
        {
            Type t = typeof(T);
            return action.IsDefined(t, false) || action.ControllerDescriptor.IsDefined(t, false);
        }
        #endregion

        #region 使用公共属性
        public OperationContext operContext
        {
            get
            {
                return OperationContext.OperContext;
            }
        }
        #endregion
    }
}