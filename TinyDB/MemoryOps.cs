using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms; 
namespace TinyDB
{
    class MemoryOps
    {
//Hint:Find better soultion than GetElementsByTagName() 
        public  static void CreateStartElement(String filepath , String NodeName)
        {
            //Writes the beignning of xmlfile
            using (XmlWriter writer = XmlWriter.Create(filepath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(NodeName);
                writer.WriteEndElement(); 
                writer.WriteEndDocument();
            }
        }
        public static void DeleteElement(String filepath, String NodeName, String ElementName) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            for (int i = 0; i < SelectNode(filepath, NodeName).Count; i++)
            {
                MessageBox.Show(i.ToString()); 
                XmlElement Node = (XmlElement)doc.GetElementsByTagName(NodeName)[i];
                XmlElement Element = (XmlElement)doc.GetElementsByTagName(ElementName)[i];
                Node.RemoveChild(Element); 
                //we dont remove from root here 
            
            }
            doc.Save(filepath); 
        }
        public static void DeleteNode(String filepath, String NodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            //select all the nodes with the nodeName 
            //delete all the node with the nodename 

           for (int i = 0; i < SelectNode(filepath, NodeName).Count; i++)
            {
                XmlElement Node = (XmlElement)doc.GetElementsByTagName(NodeName)[i];
                doc.DocumentElement.RemoveChild(Node); 
            }
            doc.Save(filepath); 
        }
        public static XmlNodeList SelectNode(String filepath, String NodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            return(doc.GetElementsByTagName(NodeName));
           
        }
        public static void CreateNode(String filepath, String NodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath); 
            XmlElement Element = doc.CreateElement(NodeName);
            doc.DocumentElement.AppendChild(Element); 
            doc.PreserveWhitespace = true;
            doc.Save(filepath);
          
        }
        public static void CreateNodeWithElements(String filepath, String NodeName, String[] Elements ,  String[] ElementsValues)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
          
            XmlElement Element = doc.CreateElement(NodeName);
            
            for (int i = 0; i < Elements.Length; i++) 
            {
              //O(Length(Elements)) 
                XmlElement Ele = doc.CreateElement(Elements[i]);
                XmlText ElementValue = doc.CreateTextNode(ElementsValues[i]);
                Ele.AppendChild(ElementValue); 
                Element.AppendChild(Ele); 
            }

            doc.DocumentElement.AppendChild(Element);
            doc.PreserveWhitespace = true;
            doc.Save(filepath);

        }
        public static int  GetNumberofNodes(String filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            return doc.ChildNodes.Count; //Check this 
        }
        public static XmlDocument SelectNodes(String filepath, String NodeName)
        {
            XmlDocument D = new XmlDocument();
            using (XmlReader R = XmlReader.Create(filepath))
            {
               
                while (R.Read())
                {
                 //   MessageBox.Show(R.Name + NodeName);
                    if (R.Name == NodeName)
                    {
                      
                     //   D.Load(R.ReadInnerXml());
                       MessageBox.Show(R.ReadInnerXml());
                      //  D.Save(filepath); 
                        break;


                    }
                }
            }
            
            return D; 
            
        }
    }
}
