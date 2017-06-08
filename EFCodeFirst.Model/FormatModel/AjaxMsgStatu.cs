using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model.FormatModel
{
    public enum AjaxMsgStatu
    {
        /// <summary>
        /// 处理成功
        /// </summary>
        OK,
        /// <summary>
        /// 处理失败
        /// </summary>
        NoOK,
        /// <summary>
        /// 异常
        /// </summary>
        Err,
        /// <summary>
        /// 没有登陆
        /// </summary>
        NoLogin,
        /// <summary>
        /// 没有权限
        /// </summary>
        NoPer,
        /// <summary>
        /// 验证码不正确
        /// </summary>
        ErrValidata
    }
}
