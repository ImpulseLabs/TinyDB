using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyDB.StorageManger;
using TinyDB.QueryManager ; 
using System.IO;
using System.Xml ; 
using TinyDB.Query; 
namespace TinyDB
{
    public class Driver
    {
        public static void Start() 
        {
           //Start method check esstinal storage function 
            if (DirectoryOps.CheckDirectoriesStruct() == false)
            {
                //Recreate the DirectoryStructure 

                DirectoryOps.ReCreateDirectoriesStruct(); 
                MemoryOps.CreateStartElement(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3], "DBS.xml"), "DBS_LISTS");
            }
        }
        public static void ProcessQuery(QueryI.Qur Query)
        {
           QuerySelector.SelectQueryType(Query); 
        }
        public static String Test()
        {
            return (MemoryOps.SelectNodes(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3], "DBS.xml"), "DB_LISTS").InnerXml); 
        }
    }
}
