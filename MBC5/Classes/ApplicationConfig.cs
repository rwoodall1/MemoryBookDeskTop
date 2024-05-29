using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbc5.Classes
{
    public class ApplicationConfig
    {
        //********************* DO NOT FORGET TO SET THE VALUE IN THE STARTUP FILE *******************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        public static string DefaultConnectionString { get; set; }
        public static string OPYConnectionString { get; set; }
        public static string ServerStorageUrl { get; set; }
        public static string DomainStorageUrl { get; set; }
        public static string BaseUrl { get; set; }
        public static string AppVersion { get; set; }
        public static string ExceptionlessKey { get; set; }
        public static string Environment { get; set; }
        public static string CurrentYear { get; set; }
        public static bool IsDeveloperMachine { get; set; }
        public static string SqlPassPhrase { get; set; }
        public static string APISecretKey { get; set; }
        public static string TokenDomain { get; set; }
        //public static string AuthNetAPILoginId { get; set; }
        //public static string AuthNetClientKey { get; set; }
        //public static string AuthNetPublicClientKey { get; set; }
        //public static string AuthNetEndPoint { get; set; }
        public static string ErrorEmailAddress { get; set; }
        public static string RecievingEmail { get; set; }
     
        public static decimal ServiceFee { get; set; }
        public static string VerTexPassWord { get; set; }
        public static string SendGridKey { get; set; }
        public static string uPPUrl { get; set; }
        public static string Version { get; set; } = "CR1563-2";
        //********************* DO NOT FORGET TO SET THE VALUE IN THE STARTUP FILE *******************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        public static void SetCurrentYear()
        {
            int _month = DateTime.Now.Month;
            int _year = DateTime.Now.Year;
            if (_month > 6)
            {
                CurrentYear = (_year + 1).ToString().Substring(2);
            }
            else
            {
                CurrentYear = _year.ToString().Substring(2);

            }

        }
        public static void SetVersion(string version)
        {
            Version = version;

        }
    }
}
