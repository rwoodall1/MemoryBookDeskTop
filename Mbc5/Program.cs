using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mbc5.Forms;
using Exceptionless;
using Mbc5.Forms.MixBook;

namespace Mbc5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            ExceptionlessClient.Default.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new frmMain());

            } catch(Exception ex)
            {
                MessageBox.Show("There was an unhandled error:" + ex.Message);


            }
            
			

		}
    }
}
