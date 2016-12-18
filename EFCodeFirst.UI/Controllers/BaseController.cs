using EFCodeFirst.BLLFactory;
using EFCodeFirst.IBLL;
using EFCodeFirst.Model.ViewModel;
using EFCodeFirst.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI.Controllers
{
    public class BaseController : Controller
    {
        public OperationContext operContext
        {
            get
            {
                return OperationContext.OperContext;
            }
        }

        public ViewMenu GetBread(int id)
        {
            var per = operContext.PerSession;
            var bread1 = (from p in per where p.Id == id select p).FirstOrDefault();
            var bread2 = (from p in per where p.Id == bread1.ParentId && p.Id != 1 select p).FirstOrDefault();
            ViewMenu viewModel = bread1.ToMenu();
            if (bread2 != null)
            {
                viewModel.text = bread2.PName + ">" + bread1.PName;
            }
            return viewModel;
        }
    }
}
