using EFCodeFirst.BLLFactory;
using EFCodeFirst.IBLL;
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
    }
}
