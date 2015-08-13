using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDB.StorageManger
{
   static class STAT
    {
   public static const     int MAX_NO_SECTORS = 5;
   public  static const  int MIN_DOCS_IN_SECTOR = 5;
   public static  const   int MAX_NO_NODES= 6;
   public  static const  int MAX_NODE_DEPTH = 9; //not needed now 
    }
}
