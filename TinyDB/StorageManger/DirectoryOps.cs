using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
namespace TinyDB.StorageManger
{
    class DirectoryOps
    {
      public  static String MainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TinyDB"); //the main path is in AppData\\TinyDB
       public  static String[] Dirs = new String[] { "DBS", "SCHEMAS_", "RECORDS_" , "Bins_" }; 
   
        public static bool CreateDirectoriesStruct() 
        {
            //create  TinyDB directory and Dirs[] inside 
            if (Directory.Exists(MainPath))
            {
                
                return false;
            }
            Directory.CreateDirectory(MainPath);
            for (int index = 0; index < Dirs.Length; index++)
            {
                Directory.CreateDirectory(Path.Combine(MainPath,Dirs[index])); 
            }
            return true; 
        }
        public static bool CheckDirectoriesStruct()
        {
            if (Directory.Exists(MainPath))
            {
                for (int index = 0; index < Dirs.Length; index++)
                {
                    if (Directory.Exists(Path.Combine(MainPath, Dirs[index])) == false)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false; 
            }
            return true; 
        }
        public static void ReCreateDirectoriesStruct()
        {
            if (Directory.Exists(MainPath))
            {
                for (int index = 0; index < Dirs.Length; index++)
                {
                    if (Directory.Exists(Path.Combine(MainPath, Dirs[index])) == false)
                    {
                        Directory.CreateDirectory(Path.Combine(MainPath, Dirs[index]));
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(MainPath);
                for (int index = 0; index < Dirs.Length; index++)
                {
                    Directory.CreateDirectory(Path.Combine(MainPath, Dirs[index]));
                }
              
            }
        }
       
    }
}
