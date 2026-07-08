using Exceptionless;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace StartUpApp
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        private string StartPath { get; set; }
        private void Splash_Shown(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();

        }
        public void VersionCheck()
        {
            //https://stackoverflow.com/questions/1112981/how-do-i-launch-application-one-from-another-in-c

            string localVersion = "";
            string serverVersion = "";
            string serverfilePath = @"M:\UpdateExe\bin\Release\";
            string serverfilePathDir = @"M:\UpdateExe\bin";
            string localfilePath = "";
            try
            {
                var root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                localfilePath = root.Replace("StartUpApp", "Mbc5");
                var localfile = localfilePath + "\\Mbc5.exe";
                // File.AppendAllText("D:\\temp\\log.txt", "local" + localfile);
                StartPath = localfilePath + "\\Mbc5.exe";
                try
                {
                    var localfileInfo = FileVersionInfo.GetVersionInfo(localfile);
                    localVersion = localfileInfo.FileVersion;
                    //in order of entry
                    var lMajor = localfileInfo.FileMajorPart;
                    var lMinor = localfileInfo.FileMinorPart;
                    var lBuild = localfileInfo.FileBuildPart;
                    var lPrivate = localfileInfo.FilePrivatePart;

                }
                catch (Exception ex)
                {
                    ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
                    return;
                }

            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
                this.Close();
                return;
            }

            try
            {
                var serverfileInfo = FileVersionInfo.GetVersionInfo(serverfilePath + "\\Mbc5.exe");
                serverVersion = serverfileInfo.FileVersion;
                //in order of entry
                var sMajor = serverfileInfo.FileMajorPart;
                var sMinor = serverfileInfo.FileMinorPart;
                var sBuild = serverfileInfo.FileBuildPart;
                var sPrivate = serverfileInfo.FilePrivatePart;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .Submit();
                return;
            }
            // File.AppendAllText("D:\\temp\\log.txt", "localvers" + localVersion + " | serververs:" + serverVersion);
            if (!String.IsNullOrEmpty(serverVersion) && serverVersion != localVersion)
            {
                //copy server to local then run
                try
                {
                    //File.Copy(serverfilePath + "Mbc5.exe", localfilePath + "\\Mbc5.exe", true);
                    //File.Copy(serverfilePath + "BindingModels.dll", localfilePath + "\\BindingModels.dll", true);
                    //File.Copy(serverfilePath + "BaseClass.dll", localfilePath + "\\BaseClass.dll", true);
                    //-----------------------------------------
                    var result = MessageBox.Show("A new version of MBC is available. Would you like to update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }


                    string localfilePathDir = localfilePath.Substring(0, localfilePath.IndexOf("bin") + 3);

                    DirectoryCopy(serverfilePathDir, localfilePathDir, true);
                    StartPath = localfilePath + "\\Mbc5.exe";

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(Dns.GetHostName());
                    //IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                    //foreach (IPAddress addr in localIPs)
                    //{
                    //    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    //    {
                    //        Console.WriteLine(addr);
                    //    }
                    //}
                    ex.ToExceptionless()
                         .SetMessage("Failed to copy server exe to local directory.")
                         .AddObject("Computer:" + System.Environment.MachineName)
                         .AddObject("ServerPath:" + serverfilePath)
                         .AddObject("LocalPath:" + localfilePath)
                         .Submit();

                    return;
                }

            }
            if (serverVersion == localVersion || (String.IsNullOrEmpty(serverVersion) && !String.IsNullOrEmpty(localVersion)))
            {
                //run local

                //StartPath = localfilePath + "\\Mbc5.exe";
            }

        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);

                file.CopyTo(temppath, true);

            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            VersionCheck();
            System.Threading.Thread.Sleep(3000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Process mbc = new Process();
            mbc.StartInfo.FileName = StartPath;
            this.Close();

            mbc.Start();

        }
    }
}
