using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDB
{
   public class Attr
    {
        private String AttrName;
        private String AttrValue;
        public String getAttrName()
        {
            return AttrName ; 
        }
        public String getAttrValue()
        {
            return AttrValue;
        }
        public void SetAttrName(String Name)
        {
            this.AttrName = Name; 
        }
        public void SetAttrValue(String Value)
        {
            this.AttrValue = Value;
        }
    }
}
