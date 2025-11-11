using Mbc5.Forms;
using NLog;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mbc5
{
    static class Program
    {

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var Log = LogManager.GetCurrentClassLogger();
            //ExceptionlessClient.Default.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            try
            {
                NativePathHelper.AddPdfiumNativePath();

                Application.Run(new frmMain());
                //Application.Run(new Form1());

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an unhandled error:" + ex.Message);


            }
        }



        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only
        // log the event, and inform the user about it.
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";


            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }


    }

    static class NativePathHelper
    {
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        public static void AddPdfiumNativePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string arch = Environment.Is64BitProcess ? "x64" : "x86";
            string nativePath = Path.Combine(baseDir, arch);
            if (Directory.Exists(nativePath))
            {
                SetDllDirectory(nativePath);
            }
        }
    }
}
