using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyDB.Query; 
using System.IO; 
using TinyDB.StorageManger;

namespace TinyDB.QueryManager
{
    class TableQuery
    {
        private QueryI.Qur Q = new QueryI.Qur();
        String filepath;
        public TableQuery(QueryI.Qur q) {
            Q = q;
            filepath = Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[1], Q.Table+".xml"); 
        }
        public void ExecuteQuery() {

            if (Q.Q == 'T')
            {
                //Create table.xml 
                MemoryOps.CreateStartElement(filepath, Q.Table);
               MemoryOps.CreateNodeWithElements(filepath, "INFO", new String[] {"db_name"}  , new String[] {Q.DBName} );
               MemoryOps.CreateNode(filepath, "ATTRS");
           

                for (int index = 0; index < Q.Attrs.Count; index++)
                {
                    MemoryOps.CreateNodeWithElements(filepath, "ATTRS", new String[] { Q.Attrs[index].getAttrName() }, null); 
                    for (int i = 0; i < Q.Data.Length; i++)
                    {
                   if(Q.Data[i] !=null)
                   MemoryOps.CreateNodeWithElements(filepath, Q.Attrs[index].getAttrName(),new String []{Q.Data[i].getDataObjectName()},new String[] {Q.Data[i].getDataObjectValue().ToString()}); 
                    }
                }




            }
        }
    }
}
