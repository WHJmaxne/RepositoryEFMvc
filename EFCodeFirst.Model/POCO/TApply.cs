using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class TApply
    {
        public TApply ToPOCO()
        {
            TApply tap = new TApply();
            tap.ApplyState = this.ApplyState;
            tap.ApplySum = this.ApplySum;
            tap.ApplyId = this.ApplyId;
            tap.ApplyName = this.ApplyName;
            tap.ApplyRemark = this.ApplyRemark;
            tap.ApplyUser = this.ApplyUser;
            tap.AssignTime = this.AssignTime;
            tap.BillTypeId = this.BillTypeId;
            tap.BillType = this.BillType.ToPOCO();
            tap.CreateTime = this.CreateTime;
            tap.ExaminationUser = this.ExaminationUser;
            tap.Id = this.Id;
            tap.IsDelete = this.IsDelete;
            tap.NoticeTime = this.NoticeTime;
            tap.PlanType = this.PlanType;
            tap.ProjectManager = this.ProjectManager;
            tap.ProjectType = this.ProjectType;
            tap.ReviewTime = this.ReviewTime;
            tap.UserInfo1 = this.UserInfo1.ToPOCO();
            tap.Role = this.Role.ToPOCO();
            if (this.UserInfo == null)
            {
                EFCodeFirst.Model.UserInfo user = new UserInfo();
                user.RealName = "未分配";
                tap.UserInfo = user;
            }
            else
            {
                tap.UserInfo = this.UserInfo.ToPOCO();
            }
            return tap;
        }
    }
}
