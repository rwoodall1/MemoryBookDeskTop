using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Mbc5.Classes
{
   
        public class ApplicationConfig
        {
            private static readonly object LockObject = new object();

            private static volatile string _SQLPassphrase;
            private static volatile string _mbcConnectionString;

        //private string SetConnection()
        //{
        //    string vEnvironment = ConfigurationManager.AppSettings["Environment"].ToString();
        //    string AppConnectionString = "";
        //    if (vEnvironment == "DEV")
        //    {
        //        AppConnectionString = "Data Source=192.168.1.101; Initial Catalog=Mbc5;User Id=sa;password=Briggitte1; Connect Timeout=5";
        //    }
        //    else if (vEnvironment == "PROD") { AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5"; }
        //    return vEnvironment;
        //}

        //public static string MbcConnectionString
        //    {
        //       get {
        //            if (_mbcConnectionString != null)
        //            {
        //                return _mbcConnectionString;
        //            }
        //            lock (LockObject)
        //            {
        //                _mbcConnectionString ="";
        //            }
        //            return _mbcConnectionString;
        //        }
        //    }


            
           
        }
    }


