using BindingModels;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace Mbc5.Forms.JPIX
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = "D:\\JPIX\\";
                this.textBox1.Text = openFileDialog1.FileName;

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "D:\\JPIX\\";
            if (Directory.Exists(path))
            {
                System.IO.DirectoryInfo dir = new DirectoryInfo(path);
                var serializer = new XmlSerializer(typeof(JostensPIXFulfillmentRequests));
                foreach (FileInfo file in dir.GetFiles("*.xml"))
                {
                    string contents = File.ReadAllText(file.FullName);
                    try
                    {
                        string Val = "20240704";
                        var bb = Val.Substring(0, 4) + "-" + Val.Substring(4, 2) + "-" + Val.Substring(6);
                        var stringreader = new StringReader(contents);
                        var vObj = (JostensPIXFulfillmentRequests)serializer.Deserialize(stringreader);
                        //var a = DateTime.Parse("2024-07-26");
                        //var b = DateTime.FromOADate(20240726);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }











            ////string contents = File.ReadAllText(this.textBox1.Text);


        }
    }
}
