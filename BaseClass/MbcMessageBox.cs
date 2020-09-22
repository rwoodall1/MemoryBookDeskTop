using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BaseClass
{
	public class MbcMessageBox
	{
        public static DialogResult Error(string msg)
        {
           var dr= Error(msg, "Error");
            return dr;
         }

            public static DialogResult Error(string msg,string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Error";
			}
			DialogResult dr=MessageBox.Show(msg,title,MessageBoxButtons.OK, MessageBoxIcon.Error);
            return dr;
		}

        public static DialogResult Information(string msg)
        {
            var dr = Information(msg, "Information");
            return dr;
        }

        public static DialogResult Information(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Information";
			}
            var dr = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dr;
		}
        public static DialogResult Exclamation(string msg)
        {
            var dr = Exclamation(msg, "Success");
            return dr;
        }
        
            public static DialogResult Exclamation(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Success";
			}
            var dr = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return dr;
		}
		public static DialogResult Hand(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
            var dr = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return dr;
		}
		public static DialogResult Stop(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
            var dr = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return dr;
		}
		public static DialogResult Warning(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
            var dr = MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return dr;
		}

	}
}
