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
        PendingAudit,
        /// <summary>
        /// 待分派
        /// </summary>
        PendingAssignment

    }
}
