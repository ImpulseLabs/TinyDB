using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDB.Query
{
  public  class QueryI
    {
        public struct Qur
        {
        public     String DBName;
      public       String Table;
      public       char Q;
       public      Key[] SelectiveKeys;
       public      String[] Cols;
       public     List<Attr> Attrs;
       public DataObject[]Data;
            public Qur(Char Q, String DBname, String Table, Key[] SelectiveKeys, String[] Cols, List<Attr> Attrs, DataObject[] Data)
            {
                this.Q = Q;
                this.DBName = DBname;
                this.Attrs = Attrs;
                this.Cols = Cols;
                this.Data = Data;
                this.SelectiveKeys = SelectiveKeys;
                this.Table = Table;

            }


        }
    }
}
