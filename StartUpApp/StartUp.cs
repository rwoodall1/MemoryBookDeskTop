using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Exceptionless;
namespace StartUpApp
{
    public class StartUp
    {
        public StartUp()
        {
       
        }
        public void VersionCheck()
        {
            //https://stackoverflow.com/questions/1112981/how-do-i-launch-application-one-from-another-in-c

            string localVersion = "";
            string serverVersion = "";
           string serverfilePath = @"M:\UpdateExe\bin\Release\";
            string localfilePath = "";
            try
            {
                var root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                 localfilePath = root.Replace("StartUpApp", "Mbc5");
                var localfile = localfilePath + "\\Mbc5.exe";
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
                    .Submit();

            }
           
            try {
                var serverfileInfo = FileVersionInfo.GetVersionInfo(serverfilePath+ "Mbc5.exe");
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

            }
           
                if (!String.IsNullOrEmpty(serverVersion)&& serverVersion != localVersion)
                {
                    //copy server to local then run
                    try
                    {
                        File.Copy(serverfilePath + "Mbc5.exe", localfilePath + "\\Mbc5.exe", true);
                        File.Copy(serverfilePath + "BindingModels.dll", localfilePath + "\\BindingModels.dll", true);
                        File.Copy(serverfilePath + "BaseClass.dll", localfilePath + "\\BaseClass.dll", true);
                    //run local
                    Process mbc = new Process();
                    mbc.StartInfo.FileName = localfilePath + "\\Mbc5.exe";
                    //notePad.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
                    mbc.Start();
                    return;
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
                    //run local
                    Process mbc = new Process();
                    mbc.StartInfo.FileName = localfilePath+ "\\Mbc5.exe";
                    //notePad.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
                    mbc.Start();
                    return;
                }

                }
            if (serverVersion == localVersion||(String.IsNullOrEmpty(serverVersion)&& !String.IsNullOrEmpty(localVersion)))
            {
                //run local
                Process mbc = new Process();
               mbc.StartInfo.FileName = localfilePath + "\\Mbc5.exe";
              

                //notePad.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
                mbc.Start();
                //return;

            }

       }

    }
}