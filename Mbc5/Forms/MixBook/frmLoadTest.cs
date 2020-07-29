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
        public int count { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        public int ErrorCount { get; set; } = 0;
        private static HttpClientHandler handler = new HttpClientHandler();
        private static HttpClient client = new HttpClient(handler);
        private void frmLoadTest_Load(object sender, EventArgs e)
        {
           client.Timeout= client.Timeout = TimeSpan.FromMinutes(30);
            client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
        }
        private  void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("started");
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
        private async void RunLoadTest2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = await PostData2();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapasedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            //foreach(var result in results)
            //{

            //}

            MessageBox.Show(elapasedTime);
        }
        private async void RunLoadTest3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = await PostData3();
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

                for (int i = 0; i <500 ; i++)
                {
                baseXml = baseXml.Replace(baseJobid.ToString(), (baseJobid + 1).ToString());
                baseJobid += 1;
                var content = new StringContent(baseXml, Encoding.UTF8, "application/xml");
               
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
            
                tasks.Add(GetData(content));
                
          
                }
            MessageBox.Show(count.ToString());
            return await Task.WhenAll(tasks);
        }
        private async Task<string[]> PostData2()
        {
            int baseJobid = 3667441;
            int errorCount = 0;
            string baseXml = File.ReadAllText("D:\\Projects\\MemoryBookDeskTop\\Mbc5\\baseXml2.xml");
            var tasks = new List<Task<string>>();

            for (int i = 0; i < 100; i++)
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
        private async Task<string[]> PostData3()
        {
            int baseJobid = 3669441;
            int errorCount = 0;
            string baseXml = File.ReadAllText("D:\\Projects\\MemoryBookDeskTop\\Mbc5\\baseXml3.xml");
            var tasks = new List<Task<string>>();

            for (int i = 0; i < 1000; i++)
            {
                baseXml = baseXml.Replace(baseJobid.ToString(), (baseJobid + 1).ToString());
                baseJobid += 1;
                var content = new StringContent(baseXml, Encoding.UTF8, "application/xml");
                //var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                //var result = await response.Content.ReadAsStringAsync();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
                tasks.Add(GetData(content));
                Thread.Sleep(500);

                //var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                //var result = response.Content.ReadAsStringAsync();
            }
            return await Task.WhenAll(tasks);
        }

        private async Task<string> GetData(StringContent content)
        {
            count += 1;
            try
            {
                var response = await client.PostAsync("https://demomxbivp.jostens.com/api/xml/receiveXml", content);
               // var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                var result = await response.Content.ReadAsStringAsync();
              
                return result;
            }catch(TaskCanceledException ex)
            {
                var a = 1;
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var a = Process.Start("https://www.foxnews.com/");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("started");
               RunLoadTest3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        MessageBox.Show("started");
                RunLoadTest2();
        }
    }
}
