using ASSIGNEMENT_2;
using System;
using System.Windows.Forms;


namespace assignemnt_2_vp
{
    internal static class Program
    {
   
  
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
