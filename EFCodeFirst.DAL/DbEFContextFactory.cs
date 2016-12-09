using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DAL
{
   public class DbEFContextFactory
    {
       public static DbContext CreatDbContext()
       {
           DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
           if (dbContext==null)
           {
               dbContext = new DbEFContext();
               CallContext.SetData("dbContext", dbContext);
           }
           return dbContext;
       }
    }
}
