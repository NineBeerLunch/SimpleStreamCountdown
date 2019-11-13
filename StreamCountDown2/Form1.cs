using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace StreamCountDown2
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStop.Visible = false;
			btnStart.Visible = true;
			timCountDown.Enabled = false;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			btnStart.Visible = false;
			btnStop.Visible = true;
			timCountDown.Enabled = true;
		}

		private void timCountDown_Tick(object sender, EventArgs e)
		{
			int min = Convert.ToInt16(txtMinute.Text);
			int sec = Convert.ToInt16(txtSecond.Text);

			if (sec == 0)
			{
				sec = 59;
				min = min - 1;
			}
			else
			{
				sec = sec - 1;
			}

			updateLabel(min, sec);
			if (min == 0 && sec == 0)
			{
				updateFile(txtMessage.Text);
				timCountDown.Enabled = false;
				btnStart.Visible = true;
				btnStop.Visible = false;
			}
		   else
			{
				if (min == 0)
				{
					updateFile(sec.ToString() + " Seconds");
				}
				else
				{
					updateFile(min, sec);
				}
			}

		}

		private void updateLabel(int min, int sec)
		{
			txtMinute.Text = min.ToString();
			txtSecond.Text = sec.ToString("00");
		}



		private void updateFile(int min, int sec)
		{
			var directory = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
			StreamWriter sw = new StreamWriter(directory + "\\countdown.txt");

			sw.WriteLine(min.ToString() + ":" + sec.ToString("00"));
			sw.Close();
			sw.Dispose();
		}


		private void updateFile(string message)
		{
			var directory = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
			StreamWriter sw = new StreamWriter(directory + "\\countdown.txt");

			sw.WriteLine(message);
			sw.Close();
			sw.Dispose();
		}

	}
}
