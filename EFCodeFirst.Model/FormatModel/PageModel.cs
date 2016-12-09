using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model.FormatModel
{
   public class PageModel
    {
       public int pageIndex { get; set; }
       public int pageSize { get; set; }
       public int total { get; set; }
       public object rows { get; set; }
       public int pageCount
       {
           get
           {
               return (int)Math.Ceiling(total * 1.0 / pageSize);
           }
       }
    }
}
