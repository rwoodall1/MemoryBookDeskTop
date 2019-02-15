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
		public static void Error(string msg,string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Error";
			}
			MessageBox.Show(msg,title,MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public static void Information(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Information";
			}
			MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		public static void Exclamation(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Success";
			}
			MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		public static void Hand(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
			MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		public static void Stop(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
			MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		public static void Warning(string msg, string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				title = "Stop";
			}
			MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

	}
}
