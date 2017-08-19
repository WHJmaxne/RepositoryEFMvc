using EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirst.Common;

namespace EFCodeFirst.BLL
{
    public partial class UserInfoBLL
    {
        #region 1.0 用户登陆方法
        /// <summary>
        /// 用户登陆方法
        /// </summary>
        /// <param name="usrName">用户名</param>
        /// <param name="usrPwd">密码</param>
        /// <returns></returns>
        public UserInfo Login(string usrName, string usrPwd)
        {
            var user = DbSession.UserInfoDAL.LoadEntities(u => u.UserName == usrName && u.UserIsDel == false).FirstOrDefault();
            if (user != null)
            {
                if (user.UserPwd.IsSameStr(usrPwd))
                {
                    return user;
                }
            }
            return null;
        }
        #endregion
        //{"列名 'Department_Id' 无效。\r\n列名 'Department1_Id' 无效。"}
        #region 2.0 查询用户权限
        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public IList<Permission> UserPermission(int userId)
        {
            //根据用户id查询角色id
            var roleIds = DbSession.UserRoleDAL.LoadEntities(r => r.UserInfoId == userId).Select(u => u.RoleId).ToList();
            //根据角色id查询权限id
            var perIds = DbSession.RolePerDAL.LoadEntities(p => roleIds.Contains(p.RoleId)).Select(p => p.PermissionId).ToList();
            //根据权限id查询权限集合
            var pers = DbSession.PermissionDAL.LoadEntities(p => perIds.Contains(p.Id)).ToList();
            //根据用户id查询特权id
            var vipIds = DbSession.UserVipPermissionDAL.LoadEntities(v => v.UserInfoId == userId).Select(p => p.Id).ToList();
            //根据特权id查询用户权限
            var vipPers = DbSession.PermissionDAL.LoadEntities(p => vipIds.Contains(p.Id)).ToList();

            //合并角色权限和用户特权
            vipPers.ForEach(p =>
            {
                //如果用户特权不在角色权限中，则将特权添加到角色权限
                if (!perIds.Contains(p.Id))
                {
                    pers.Add(p);
                }
            });
            return pers;
        }
        #endregion
    }
}
