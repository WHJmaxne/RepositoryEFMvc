using EFCodeFirst.Model.ExtensionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model.ViewModel
{
    public class Enumeration
    {
        public int Value { get; set; }
        public string Text { get; set; }

        #region 1.0 获取权限操作类型
        private static List<Enumeration> _planType = null;
        /// <summary>
        /// 获取权限操作类型
        /// </summary>
        /// <returns></returns>
        public static List<Enumeration> GetPlanTypes()
        {
            if (_planType == null)
            {
                _planType = new List<Enumeration>()
               {
                   new Enumeration(){Value=(int)PlanType.Month,Text="月度计划"},
                   new Enumeration(){Value=(int)PlanType.Year,Text="年度计划"}
               };
            }
            return _planType;
        }
        #endregion

        #region 2.0 获取HttpMethod方式
        private static List<Enumeration> _projectType = null;
        /// <summary>’；
        /// 获取HttpMethod方式
        /// </summary>
        /// <returns></returns>
        public static List<Enumeration> GetProjectTypes()
        {
            if (_projectType == null)
            {
                _projectType = new List<Enumeration>()
               {
                   new Enumeration(){Value=(int)ProjectType.Open,Text="公开招标"},
                   new Enumeration(){Value=(int)ProjectType.Invitation,Text="邀请招标"}
               };
            }
            return _projectType;
        }
        #endregion

        //#region 3.0 获取申请单状态
        //private static List<Enumeration> _wfState = null;
        ///// <summary>’；
        ///// 获取申请单状态
        ///// </summary>
        ///// <returns></returns>
        //public static List<Enumeration> GetWFState()
        //{
        //    if (_wfState == null)
        //    {
        //        _wfState = new List<Enumeration>()
        //       {
        //           new Enumeration(){Value="0",Text="已提交"},
        //           new Enumeration(){Value="1",Text="已拒绝"},
        //           new Enumeration(){Value="2",Text="审批中"},
        //           new Enumeration(){Value="3",Text="已结束"}
        //       };
        //    }
        //    return _wfState;
        //}
        //#endregion

        //#region 4.0 获取工作流申请表优先级
        //private static List<Enumeration> _priority = null;
        ///// <summary>
        ///// 获取工作流申请表优先级
        ///// </summary>
        ///// <returns></returns>
        //public static List<Enumeration> GetPriority()
        //{
        //    if (_priority == null)
        //    {
        //        _priority = new List<Enumeration>() {
        //       new Enumeration() { Value="1",Text="高"},
        //       new Enumeration(){Value="2",Text="中"},
        //       new Enumeration(){Value="3",Text="低"}
        //       };
        //    }
        //    return _priority;
        //}
        //#endregion

        //#region 4.0 获取工作流操作类型
        //private static List<Enumeration> _wfoperation = null;
        ///// <summary>
        ///// 获取工作流操作类型
        ///// </summary>
        ///// <returns></returns>
        //public static List<Enumeration> GetWFOperation()
        //{
        //    if (_wfoperation == null)
        //    {
        //        _wfoperation = new List<Enumeration>() {
        //       new Enumeration() { Value="0",Text="提交"},
        //       new Enumeration() { Value="1",Text="通过"},
        //       new Enumeration(){Value="2",Text="驳回"},
        //       new Enumeration(){Value="3",Text="拒绝"}
        //       };
        //    }
        //    return _wfoperation;
        //}
        //#endregion
    }
}
