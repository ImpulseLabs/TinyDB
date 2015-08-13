using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
namespace TinyDB.BosY
{ 
    //BosY: Binary Organization System (Version Y) 
  public  class Main
    {
        public static void CreateFile(String filepath, Byte[] fileContents)
        {
            File.WriteAllBytes(filepath, fileContents); 
           
        }
      public static Byte[] ConvertToBytes (Object [] NB) 
      {
          Byte[] B = new Byte[] { }; 
          for (int i = 0; i < NB.Length; i++)
          {
              B[i] = Convert.ToByte(NB[i]); 
          }
          return B; 
      }
      public static int[] GetContents(String filepath)
      {
          return(ConvertBytesinRange(filepath , 0 , -1)) ; 
      }
      public static void ModifyFile(String filepath, int byteoffset , Byte bt )
      {
          Byte[] B = File.ReadAllBytes(filepath);
          B[byteoffset] = bt;
          File.WriteAllBytes(filepath , B); 
      }
      public static void AppendFile(String filepath,  Byte[] bt)
      {
          Byte[] B = File.ReadAllBytes(filepath);
          int offset = B.Length; 
          Array.Resize(ref B,offset + bt.Length);
          for (int i = 0; i< bt.Length; i++)
          {
              B[offset++] = bt[i];   
          }
          File.WriteAllBytes(filepath, B); 
      }
      public static int[] ConvertBytesinRange(String filepath, int from , int to )
      {
          Byte[] B = File.ReadAllBytes(filepath);
          int[] FC = new int[] { }; 
          //Ranges check 
          if (from >= to)
          {
              return null; 
          }
          if (to >= B.Length)
          {
              return null; 
          }
          if (to <= 0)
          {
              to = B.Length; 
          }

          int offset = 0 ; 
          for (int i = from; i < to; i++)
          {
              FC[offset++] = Convert.ToInt16(B[i]); 
          }
          return FC;   
      }

       
    }
}
