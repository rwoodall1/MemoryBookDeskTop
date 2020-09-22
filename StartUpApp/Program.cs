using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartUp VerCheck = new StartUp();
            //VerCheck.VersionCheck();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                
                var startForm = new Splash();
           
                Application.Run(startForm);
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unhandled error:" + ex.Message);


            }
        }
    }
}
