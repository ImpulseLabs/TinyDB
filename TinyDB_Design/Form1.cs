using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyDB;
using System.IO; 
using TinyDB.Query; 
namespace TinyDB_Design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Driver.Start();
//QueryI.Qur q = new QueryI.Qur();
        //    q.Q = 'T';
        //    q.Table = "file";
       //     q.DBName = "LogX"; 
           
            
          //  Driver.ProcessQuery(q);
           // MessageBox.Show(Driver.Test()); 
            Byte[] B = new Byte[4];
         
          TinyDB.BosY.Main.CreateFile(Path.Combine(Environment.CurrentDirectory,"h.exe"), B);
         
    
        }
    }
}
