using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHC.DataAccess
{
   public  class GetUOW
    {
       static object lockUOW = new object();
       public static IUnitOfWork GetUOWInstance
       {
           get
           {
               lock (lockUOW)
                   return new PHCSolutions();

           }
       }

    }
}
