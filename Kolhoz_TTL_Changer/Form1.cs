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

                Process.GetCurrentProcess().Kill();
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
            string key1 = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters";
            string key2 = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip6\\Parameters";
            string valueName = "DefaultTTL";

            try
            {
                switch (bits)
                {
                    case 32:
                        Microsoft.Win32.Registry.SetValue(key1, valueName, value, Microsoft.Win32.RegistryValueKind.DWord);
                        Microsoft.Win32.Registry.SetValue(key2, valueName, value, Microsoft.Win32.RegistryValueKind.DWord);
                        return true;
                    case 64:
                        Microsoft.Win32.Registry.SetValue(key1, valueName, value, Microsoft.Win32.RegistryValueKind.QWord);
                        Microsoft.Win32.Registry.SetValue(key2, valueName, value, Microsoft.Win32.RegistryValueKind.QWord);
                        return true;
                    default:
                        MessageBox.Show("System instruction set recognition error!");
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Change
        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            if (TextBox.Text != "" && int.TryParse(TextBox.Text, out value))
            {
                if (ChangeTTL(value))
                {
                    SuccessForm success = new SuccessForm();
                    success.ShowDialog();
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
                SuccessForm success = new SuccessForm();
                success.ShowDialog();
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
