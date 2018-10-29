using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Forms.MemoryBook
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }



        private void test_Load(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(IDataAdapter))
                {
                    var a = C;


                }
            }
        }
    }
}
