using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDB
{
   public class DataObject
    {
       private String Name;
     private  Object Value;
     public void SetDataObjectName(String ObjDataName)
     {
         this.Name = ObjDataName;   
     }
     public void SetDataObjectValue(String ObjDataValue)
     {
         this.Value = ObjDataValue;
     }
     public String getDataObjectName() { return this.Name;  }
     public Object getDataObjectValue() { return this.Value; }
    }
}
