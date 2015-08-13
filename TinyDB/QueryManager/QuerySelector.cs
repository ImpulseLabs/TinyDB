using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyDB.Query; 
namespace TinyDB.QueryManager 
{
    class QuerySelector
    {
        /*
         * Q = S,D,U,I  ================> Select/Update/Delete/Insert 
         * Q = C =======================> Create database 
         * Q = R =======================> dRop database 
         * Q = T =======================> create Table 
         * Q = O =======================> drOp table 
         * Q = A =======================> Alter Table
         */
        public static void SelectQueryType(QueryI.Qur Q ) {

            if (Q.Q == 'S' || Q.Q == 'D' || Q.Q == 'U' || Q.Q == 'I')
            {
                RecordQuery RQ = new RecordQuery(Q);
                QueryExecuter.ExecuteQuery(RQ);
            }
            else if (Q.Q == 'C' || Q.Q =='R' )
            {
                DBQuery DBQ = new DBQuery(Q);
             //   QueryExecuter.ExecuteQuery(DBQ);
               
                DBQ.ExecuteQuery(); 
            }
            else if (Q.Q == 'T' || Q.Q =='O' || Q.Q =='A')
            {
                TableQuery TQ = new TableQuery(Q);
                TQ.ExecuteQuery(); 
            }
         
        }
    }
}
