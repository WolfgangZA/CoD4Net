using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoD4Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly=(true);
            this.BackColor = Color.YellowGreen ;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                string HOSTS = "";
                string serverip = System.IO.File.ReadAllText("server.txt");
                richTextBox1.AppendText("Resolving server: " + serverip + Environment.NewLine);
                
                IPAddress[] ipaddress = Dns.GetHostAddresses(serverip);
                IPHostEntry HOST = Dns.GetHostEntry(serverip);

                foreach (IPAddress ip in ipaddress)
                    HOSTS = ip.ToString();


                // foreach (IPAddress ip in ipaddress)
                //{
                // richTextBox1.AppendText(ip.ToString() + Environment.NewLine); 
                // }
                richTextBox1.AppendText(serverip + " Resolved to: " + HOSTS + Environment.NewLine);
                richTextBox1.AppendText("Attempting to edit HOSTS file" + Environment.NewLine);
                System.IO.File.WriteAllText(Environment.SystemDirectory + "\\drivers\\etc\\hosts", HOSTS + " cod4master.activision.com");
                richTextBox1.AppendText("Hosts edited successfully!" + Environment.NewLine);
                richTextBox1.AppendText("Launching CoD4..."+ Environment.NewLine);
                System.Diagnostics.Process.Start("iw3mp.exe");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("ERROR: " + ex.Message + Environment.NewLine);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
