using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Dodo is a simple xml parser 
namespace TinyDB.Dodo
{
    public class DoXmlNode
    {
     public   String InnerXml;
     private String[] XmlElements;
     private String[] Seps = new String[] { "<", ">", "</" }; 

        public DoXmlNode(String XmlString)
        {
            InnerXml = XmlString; 
        }
        public String GetValueofElement(String ElementTagName)
        {
         XmlElements=  InnerXml.Split(Seps, StringSplitOptions.RemoveEmptyEntries);
         for (int i = 0; i < XmlElements.Length; i++)
         {
             if (XmlElements[i] == ElementTagName)
             {
                 return XmlElements[i + 1]; 
             }
         }
  return null; 
        }
      
    }
}
