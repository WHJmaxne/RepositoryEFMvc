using EFCodeFirst.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DALFactory
{
   public class DbSessionFactory
    {
       public static IDBSession CreatDbSession()
       {
           IDBSession DbSession = (IDBSession)CallContext.GetData("DbSession");
           if (DbSession==null)
           {
               DbSession = new DBSession();
               CallContext.SetData("DbSession", DbSession);
           }
           return DbSession;
       }
    }
}
