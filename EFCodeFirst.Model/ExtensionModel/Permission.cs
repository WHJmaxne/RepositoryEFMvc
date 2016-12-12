using EFCodeFirst.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model
{
    public partial class Permission
    {
        public ViewMenu ToMenu()
        {
            return new ViewMenu()
            {
                Id = this.Id,
                parentId = this.ParentId,
                text = this.PName,
                url = "/" + this.PAreaName + "/" + this.PControllerName + "/" + this.PActionName
            };
        }
    }
}
