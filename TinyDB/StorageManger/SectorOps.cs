using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyDB.BosY;
using System.IO; 
namespace TinyDB.StorageManger
{
    class SectorOps
    {
        public static void CreateSector(String TableName)
        {
            //Check SectorsFile for table name 
    int  [] SectorInfo =  Main.GetContents(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3] , "dbsx_"+ TableName+ "si.sector")) ;
    if (SectorInfo[0] == STAT.MAX_NO_SECTORS-1)
    {
        //let's hope that the first byte is equal to sectorsno in table 

    }
    else
    {
        //create sector folder
        Directory.CreateDirectory(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[2], "db_" + TableName, "sec_"+( SectorInfo[0] +1 ))); 
        //Add sector to sectorInfo 
        Main.ModifyFile(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3], "dbsx_" + TableName + "si.sector"), 0, Convert.ToByte(SectorInfo[0] + 1));
        Main.AppendFile(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3], "dbsx_" + TableName + "si.sector"), new Byte[] { Convert.ToByte(SectorInfo[0] + 1), Convert.ToByte(0), Convert.ToByte('?') }); 
     //Note we can make so to load the bytes once then modify on the fly then save the file once
    }
        }
        public static void DeleteSector(String TableName)
        {

        }
        public static void CreateDoc(String TableName)
        {

        }
        public static void DeleteDoc(String TableName)
        {

        }
       public static String GetSectorDocPath(String TableName)
        {
            int[] SectorInfo = Main.GetContents(Path.Combine(DirectoryOps.MainPath, DirectoryOps.Dirs[3], "dbsx_" + TableName + "si.sector"));
           String finalpath = Path.Combine(new String [] {DirectoryOps.MainPath, DirectoryOps.Dirs[2], "db_" + TableName, "sec_" + SectorInfo[1], SectorInfo[2].ToString()});

           if (SectorInfo[2] == STAT.MIN_DOCS_IN_SECTOR)
           {
               //Go to a new sector 
               if (SectorInfo[1] == STAT.MAX_NO_SECTORS)
               {
                   SectorInfo[1] = SectorInfo[1] % STAT.MAX_NO_SECTORS;
               }
               else
               {
                   //Create new Sector
                   CreateSector(TableName);
                   SectorInfo[1] = SectorInfo[1] + 1; 
               }

           }
           else if (SectorInfo[2] < STAT.MIN_DOCS_IN_SECTOR)
           {
               //Check Doc free or not 
               if (MemoryOps.GetNumberofNodes(finalpath) == STAT.MAX_NO_NODES)
               {
                   //create new Doc 
                   CreateDoc(TableName); 
                   SectorInfo[2] = SectorInfo[2] + 1;
               }
           }
           else
           {
               //Go to a new sector 
               SectorInfo[1] = SectorInfo[1] % STAT.MAX_NO_SECTORS;
               //create new doc 
               CreateDoc(TableName);
               SectorInfo[2] = SectorInfo[2] + 1;
           }
        return finalpath;      
        }
    }
}
