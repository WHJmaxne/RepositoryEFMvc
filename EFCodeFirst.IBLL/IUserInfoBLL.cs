using EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.IBLL
{
    public partial interface IUserInfoBLL : IBaseBLL<UserInfo>
    {
        UserInfo Login(string usrName, string usrPwd);

        IList<Permission> UserPermission(int userId);
    }
}
