using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms; 
using TinyDB.Query; 

namespace TinyDB.QueryManager
{
    class DBQuery
    {
     private   QueryI.Qur Q = new  QueryI.Qur() ;
     String filepath = Path.Combine(StorageManger.DirectoryOps.MainPath,StorageManger.DirectoryOps.Dirs[3],"DBS.xml"); //path to dbs.xml 
     QueryResult Res = new QueryResult(); 
        public DBQuery (QueryI.Qur q) {
            Q = q; 
        }

        public void ExecuteQuery()
        {

            if (Q.Q == 'C')
            {
                //Check  if database name already exist
                //If not create the database
                //database names should not contain illgel chars as space,@
                if (!CheckDataBaseExists(Q.DBName))
                {
                    
                    //create a new dbname.xml file 
                    String[] es = new String[] {"db_name","db_table","db_recods_sectors"}; 
                    String[] evs = new String[] { Q.DBName  , "0", "0"};
                  
                    MemoryOps.CreateNodeWithElements(filepath, "db_" + Q.DBName, es, evs);
                
                    Res.setResultBool(true);
                    Res.setResultSuccessText("Database " + Q.DBName + " has been created successfully..");  
                }
                Res.setResultBool(false);
                Res.setResultErrorID(1);
                Res.setResultErrorText("Error: " + Q.DBName + " already exists.."); 
            }
            if (Q.Q == 'R')
            {
                //Check if database exists 
                //Check the password is correct** 
                if (CheckDataBaseExists(Q.DBName)) 
                {
                   
                  //  MemoryOps.DeleteNode(filepath, "db_" +Q.DBName);
                    MemoryOps.DeleteElement(filepath, "db_" + Q.DBName, "db_name"); 
                    Res.setResultBool(true);
                    Res.setResultSuccessText("Database " + Q.DBName + " has been deleted successfully.."); 
                }

            }

        }
        private bool CheckDataBaseExists(String DBName)
        {
      
            XmlNodeList DBS_LIST = MemoryOps.SelectNode(filepath, "db_" +  DBName); //select database lists
            if (DBS_LIST.Count == 0)
            {
                return false  ; 
            }
            return true; 

        }
    }
}
