using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool ChangeTTL(int value)
        {
            MessageBox.Show(value.ToString());
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
