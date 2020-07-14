using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mbc5.Classes;
using System.IO;
using BaseClass.Classes;

using System.Threading;
using System.Threading.Tasks;
using Core;
using System.Diagnostics;

using System.Linq;
using System.Net;
using System.Net.Http;

using System.Net.Http.Headers;
using System.Configuration;
using Exceptionless;
using BindingModels;
using GenCode128;
namespace Mbc5.Forms.MemoryBook
{
    public partial class frmLoadTest : BaseClass.frmBase
    {
        public frmLoadTest(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }

        public UserPrincipal ApplicationUser { get; set; }
        public int ErrorCount { get; set; } = 0;
        private static HttpClientHandler handler = new HttpClientHandler();
        private static HttpClient client = new HttpClient(handler);
        private void frmLoadTest_Load(object sender, EventArgs e)
        {
          
            client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
        }
        private  void btnStart_Click(object sender, EventArgs e)
        {
            RunLoadTest();
        }

        private async void RunLoadTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = await PostData();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapasedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            //foreach(var result in results)
            //{

            //}
            
            MessageBox.Show(elapasedTime);
        }
        private async Task<string[]> PostData()
        {
                int baseJobid = 3665441;
                int errorCount = 0;
                string baseXml = File.ReadAllText("D:\\Projects\\MemoryBookDeskTop\\Mbc5\\baseXml.xml");
                var tasks = new List<Task<string>>();

                for (int i = 0; i < 15; i++)
                {
                baseXml = baseXml.Replace(baseJobid.ToString(), (baseJobid + 1).ToString());
                baseJobid += 1;
                var content = new StringContent(baseXml, Encoding.UTF8, "application/xml");
                //var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                //var result = await response.Content.ReadAsStringAsync();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
                tasks.Add(GetData(content));
                
          
                //var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                //var result = response.Content.ReadAsStringAsync();
                }
            return await Task.WhenAll(tasks);
        }

        private async Task<string> GetData(StringContent content)
        {
            var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into MixbookBarCodes (Invno,BarcodeType,Image) Values(38304801,'Cover',@Image)");
           
            
            try
            {
                Image myimg = Code128Rendering.MakeBarcodeImage("MXB38304801YB", int.Parse("1"), true);
                byte[] Ret;
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                       
                        myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Ret = ms.ToArray();
                        sqlClient.AddParameter("@Image", Ret);
                        var result = sqlClient.Insert();
                        var c = "";
                       // picbox.Image = Ret;

                    }
                }
                catch (Exception) { throw; }
                myimg.Save("D:\\tmp\\test.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }
    }
}
