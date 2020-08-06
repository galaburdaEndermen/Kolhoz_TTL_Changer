using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolhoz_TTL_Changer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (!IsAdministrator())
            {
                // Restart and run as admin
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                //Application.Exit();

                Process.GetCurrentProcess().Kill();
                //this.Close();
            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private int bits = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                bits = 64;
            }
            else
            {
                bits = 32;
            }
            this.Text = $"TTL_Changer {bits}-bit";
            if (IsAdministrator())
            {
                this.Text += "(Administrator)";
            }
        }

        private bool ChangeTTL(int value)
        {
            switch (bits)
            {
                case 32:
                    MessageBox.Show("32");
                    break;
                case 64:
                    MessageBox.Show("64");
                    break;
                default:
                    MessageBox.Show("System instruction set recognition error!");
                    break;
            }

            return false;
        }

        //Change
        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            if (TextBox.Text != "" && int.TryParse(TextBox.Text, out value))
            {
                if (ChangeTTL(value))
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
            else
            {
                MessageBox.Show("Input error!");
            }
        }

        //Reset
        private void button2_Click(object sender, EventArgs e)
        {
            if (ChangeTTL(128))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        //Info
        private void button3_Click(object sender, EventArgs e)
        {
            InfoForm info = new InfoForm();
            info.ShowDialog();
        }
    }
}
