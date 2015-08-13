using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDB.Query
{
  public  class QueryResult
    {
        private bool resultBool;
        private int ErrorID =0;
        private String ErrorText;
        private String SuccessText; 
        public void setResultBool(bool res) 
        {
            this.resultBool = res; 
        }
        public void setResultErrorID(int eid)
        {
            this.ErrorID = eid;
        }
        public void setResultErrorText(String text)
        {
            this.ErrorText = text;
        }
        public void setResultSuccessText(String text)
        {
            this.SuccessText = text;
        }
    }
}
