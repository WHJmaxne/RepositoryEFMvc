﻿using System;
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

            if (this.UserInfo == null)
            {
                EFCodeFirst.Model.UserInfo user = new UserInfo();
                user.RealName = "未分配";
                return new TApply()
                {
                    ApplyState = this.ApplyState,
                    ApplySum = this.ApplySum,
                    ApplyId = this.ApplyId,
                    ApplyName = this.ApplyName,
                    ApplyRemark = this.ApplyRemark,
                    ApplyUser = this.ApplyUser,
                    AssignTime = this.AssignTime,
                    BillTypeId = this.BillTypeId,
                    BillType = this.BillType.ToPOCO(),
                    CreateTime = this.CreateTime,
                    ExaminationUser = this.ExaminationUser,
                    Id = this.Id,
                    IsDelete = this.IsDelete,
                    UserInfo = user,
                    NoticeTime = this.NoticeTime,
                    PlanType = this.PlanType,
                    ProjectManager = this.ProjectManager,
                    ProjectType = this.ProjectType,
                    ReviewTime = this.ReviewTime,
                    UserInfo1 = this.UserInfo1.ToPOCO(),
                    Role = this.Role.ToPOCO()
                };
            }
            else
            {
                return new TApply()
                {
                    ApplyState = this.ApplyState,
                    ApplySum = this.ApplySum,
                    ApplyId = this.ApplyId,
                    ApplyName = this.ApplyName,
                    ApplyRemark = this.ApplyRemark,
                    ApplyUser = this.ApplyUser,
                    AssignTime = this.AssignTime,
                    BillTypeId = this.BillTypeId,
                    BillType = this.BillType.ToPOCO(),
                    CreateTime = this.CreateTime,
                    ExaminationUser = this.ExaminationUser,
                    Id = this.Id,
                    IsDelete = this.IsDelete,
                    UserInfo = this.UserInfo.ToPOCO(),
                    NoticeTime = this.NoticeTime,
                    PlanType = this.PlanType,
                    ProjectManager = this.ProjectManager,
                    ProjectType = this.ProjectType,
                    ReviewTime = this.ReviewTime,
                    UserInfo1 = this.UserInfo1.ToPOCO(),
                    Role = this.Role.ToPOCO()
                };
            }

        }
    }
}
