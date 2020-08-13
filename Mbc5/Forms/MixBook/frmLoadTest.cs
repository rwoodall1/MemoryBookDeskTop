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
using System.Net.Sockets;
using Renci.SshNet;
using Microsoft.Reporting.WinForms;

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
        private async void PrinterTest()
        {
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;
            string baseXml = "http://10.37.16.168/PRT_Label.html";
            byte[] unicodeBytes = unicode.GetBytes(baseXml);
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);


            var content = new StringContent("test", Encoding.UTF8, "application/x-www-form-urlencoded");

            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("Authorize", "NbSVnRumX4zDIXuL3ZjWfwlgES8GD7fGkfu3z5WwleD4fAsSDFUlgbYvxFZgim6sGCKoaxGhJio=");
            try
            {
                var response = await client.GetAsync("http://10.37.16.168/PRT_Label.html?test");
                // var response = await client.PostAsync("https://localhost:44333/api/xml/receiveXml", content);
                var result = await response.Content.ReadAsStringAsync();

                return ;
            }
            catch (TaskCanceledException ex)
            {
                var a = 1;
                return;
            }
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
          
  
            try
            {
                TcpClient client = new TcpClient("10.37.16.168", 10200);
              
                 byte[] escapeb = new byte[] { 0x1B, 0x43, 0x0D };
                string escape = System.Text.Encoding.ASCII.GetString(escapeb);
                byte[] stxb = new byte[] {0x02};
                string stx = System.Text.Encoding.ASCII.GetString(stxb);
                byte[]crb= new byte[] { 0x0D };
                string cr = System.Text.Encoding.ASCII.GetString(crb);
                byte[] soh1b = new byte[] {0x31, 0x01 };
                string soh1 = System.Text.Encoding.ASCII.GetString(soh1b);
                byte[] soh2b = new byte[] {0x33,0x01};
                string soh2 = System.Text.Encoding.ASCII.GetString(soh2b);
                byte[] etxb = new byte[] {0x03 };
                string etx = System.Text.Encoding.ASCII.GetString(etxb);
                byte[] templateb= Encoding.ASCII.GetBytes("TZmxb.00I;10");
                string template = System.Text.Encoding.ASCII.GetString(templateb);

                string barcode = "MXBRandyYB";
                string location = "cart2";
                string datas =  stx + template + cr +soh1+ barcode + cr+soh2+location+cr + etx;
                byte[] data = Encoding.ASCII.GetBytes(datas);

                //File.WriteAllBytes("D:\\tmp", sendData);
                // , 0x02, 0x54, 0x5A, 0x4D, 0x58, 0x42, 0x2E, 0x30, 0x30, 0x49, 0x3B, 0x31, 0x30, 0x0D, 0x4D, 0x58, 0x42, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x31, 0x59, 0x42, 0x0D, 0x03
                NetworkStream stream = client.GetStream();
           
                stream.Write(data, 0, data.Length);
                byte[] bytes = new byte[client.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.
                stream.Read(bytes, 0, (int)client.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         PrinterTest();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

             var a = e.KeyChar;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var a = e.KeyCode;
            KeysConverter kc = new KeysConverter();
            string keyChar = kc.ConvertToString(e.KeyData);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
          

        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { }
        }
    }
}
