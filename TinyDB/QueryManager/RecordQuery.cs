using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TinyDB.Query;
using TinyDB.StorageManger; 
namespace TinyDB.QueryManager
{
    class RecordQuery:QueryI
    {
        private QueryI.Qur Q = new QueryI.Qur();
        private QueryResult Res = new QueryResult(); 
        private String Tablepath;
        int sectornumber;
        int documentnumber; 
        public RecordQuery(QueryI.Qur Qur)
        {
            Q = Qur;
          
            Tablepath = Path.Combine(StorageManger.DirectoryOps.MainPath, StorageManger.DirectoryOps.Dirs[2], "db_" + Q.Table); 
            
         
        }
        public void ExecuteQuery()
        {
            if (Q.Q == 'I')
            {
                //check database selected 
                //check table 
                if (CheckDataBaseExists(Q.DBName))
                {
                    if (CheckTableExists(Tablepath))
                    {
                        //Check if cols obeys schema 
                        MemoryOps.CreateNodeWithElements(SectorOps.GetSectorDocPath(Q.Table), "RECORD", Q.Cols, Q.Data.Select(i => i.ToString()).ToArray());
                        Res.setResultBool(true);
                        Res.setResultSuccessText("Done executing query..");  
                    }
                    else
                    {
                        Res.setResultBool(false);
                        Res.setResultErrorID(2);
                        Res.setResultErrorText("Error on executing query: Table does not exist");
                    }
                }
                else
                {
                    Res.setResultBool(false);
                    Res.setResultErrorID(3);
                    Res.setResultErrorText("Error on executing query: Database does not exist");
                }
           
            }
        }
        private bool CheckDataBaseExists(String DBName)
        {

            XmlNodeList DBS_LIST = MemoryOps.SelectNode(Paths.DBS_XML, "db_" + DBName); //select database lists
            if (DBS_LIST.Count == 0)
            {
                return false;
            }
            return true;

        }
        private bool CheckTableExists(String DBName)
        {
            return Directory.Exists(Tablepath); 
        }
        public QueryResult getQueryResult()
        {
            return Res; 
        }
    }
}
