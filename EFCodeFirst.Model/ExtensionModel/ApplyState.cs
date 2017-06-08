using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model.ExtensionModel
{
    public enum ApplyState
    {
        /// <summary>
        /// 待审核
        /// </summary>
        PendingAudit = 1,
        /// <summary>
        /// 待分派
        /// </summary>
        PendingAssignment = 2,
        /// <summary>
        /// 待受理
        /// </summary>
        PendingAcceptance = 3,
        /// <summary>
        /// 待发布
        /// </summary>
        PendingRelease = 4,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 5,
        /// <summary>
        /// 已驳回
        /// </summary>
        Rejected = 6
    }
}
