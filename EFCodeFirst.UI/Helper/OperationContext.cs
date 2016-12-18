using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using EFCodeFirst.Common;
using EFCodeFirst.BLLFactory;
using EFCodeFirst.IBLL;
using System.Web.Mvc;
using EFCodeFirst.Model.FormatModel;
using EFCodeFirst.Model;
using System.Text;

namespace EFCodeFirst.UI.Helper
{
    public class OperationContext
    {
        #region 0.0 常量区
        //存入session或cookie的键
        //权限session Key
        const string perSessionKey = "perSession";
        //用户session Key
        const string userSessionKey = "userSession";
        //用户cookie Key
        const string userIdCookieKey = "userIdCookie";
        //Json权限树session Key
        const string userPerTreeSessionKey = "treeJson";
        //验证码session Key
        const string valiSessionKey = "valiNumSession";
        #endregion

        #region 1.0 操作上下文属性
        //1.----便捷访问属性 HttpContext/Session/Response/Request--------
        public HttpContext context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public HttpSessionState session
        {
            get
            {
                return context.Session;
            }
        }

        public HttpResponse Response
        {
            get
            {
                return context.Response;
            }
        }

        public HttpRequest Request
        {
            get
            {
                return context.Request;
            }
        }


        #endregion

        #region 2.0 当前登陆用户存入session
        public UserInfo UserSession
        {
            set
            {
                session[userSessionKey] = value;
            }
            get
            {
                return session[userSessionKey] as Model.UserInfo;
            }
        }
        #endregion

        #region 3.0 当前登陆用户id存入cookie
        public int UserIdCookie
        {
            set
            {
                HttpCookie cookie = new HttpCookie(userIdCookieKey);
                cookie.Value = value.ToString();
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
            }
            get
            {
                HttpCookie cookie = Request.Cookies[userIdCookieKey];
                if (cookie != null && !cookie.Value.IsNullOrEmpty())
                {
                    return Convert.ToInt32(cookie.Value);
                }
                return -1;
            }
        }
        #endregion

        #region 4.0 获取BLL实例
        public IBLLSession BllSession
        {
            get
            {
                return new BLLSession();
            }
        }
        #endregion

        #region 5.0 将验证码存入session
        public string valiSession
        {
            set
            {
                session[valiSessionKey] = value;
            }
            get
            {
                if (session[valiSessionKey] != null)
                {
                    return session[valiSessionKey].ToString();
                }
                return null;
            }
        }
        #endregion

        #region 6.0 生成ajax消息，json字符串
        /// <summary>
        /// 生成ajax消息，json字符串
        /// </summary>
        /// <param name="statu">消息状态</param>
        /// <param name="msg">消息信息</param>
        /// <param name="backUrl">路径</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string JsonMsg(AjaxMsgStatu statu = AjaxMsgStatu.OK, string msg = "", string backUrl = "", object data = null)
        {
            AjaxMsg ajaxMsg = new AjaxMsg()
            {
                Statu = statu,
                Msg = msg,
                BackUrl = backUrl,
                Data = data
            };
            return SerializerHelper.SerializerToString(ajaxMsg);
        }
        #endregion

        #region 6.1 生成ajax消息json字符串便捷方法
        public string JsonMsgOK(string msg = "", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStatu.OK, msg, backUrl, data);
        }
        public string JsonMsgNoOK(string msg = "", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStatu.NoOK, msg, backUrl, data);
        }
        public string JsonMsgErr(string msg = "", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStatu.Err, msg, backUrl, data);
        }
        public string JsonMsgNoLogin(string msg = "", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStatu.NoLogin, msg, backUrl, data);
        }
        public string JsonMsgNoPer(string msg = "", string backUrl = "", object data = null)
        {
            return JsonMsg(AjaxMsgStatu.NoPer, msg, backUrl, data);
        }
        #endregion

        #region 6.3 生成JS消息
        /// <summary>
        /// 生成JS消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="backUrl">url</param>
        /// <returns></returns>
        public ContentResult JsMsg(string msg, string backUrl)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>alert('" + msg + "');");
            if (!backUrl.IsNullOrEmpty())
            {
                sb.Append("if(window.top)");
                sb.Append("   window.top.location.href='" + backUrl + "';");
                sb.Append("else");
                sb.Append("   window.location.href='" + backUrl + "';");
            }
            sb.Append("</script>");
            ContentResult content = new ContentResult()
            {
                Content = sb.ToString(),
                ContentType = "text/html"
            };
            return content;
        }
        #endregion

        #region 7.0 将用户权限存入session
        public IList<Permission> PerSession
        {
            set
            {
                session[perSessionKey] = value;
            }
            get
            {
                return session[perSessionKey] as IList<Permission>;
            }
        }
        #endregion

        #region 8.0 清空session和cookie
        /// <summary>
        /// 清空session和cookie
        /// </summary>
        public void OutLogin()
        {
            session.Abandon();
            HttpCookie cookie = Request.Cookies[userIdCookieKey];
            if (cookie != null && !cookie.Value.IsNullOrEmpty())
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region END 操作以上属性
        public static OperationContext OperContext
        {
            get
            {
                return new OperationContext();
            }
        }
        #endregion
    }
}