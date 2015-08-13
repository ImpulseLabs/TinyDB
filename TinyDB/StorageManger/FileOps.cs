using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace TinyDB.StorageManger
{
    class FileOps
    {
        public bool DeleteFile(String path) {
         if(File.Exists(path)) 
         {
             File.Delete(path); 
             return true; 
         }
         return false;
        }

    }
}
