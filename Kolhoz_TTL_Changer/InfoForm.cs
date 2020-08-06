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
    //TTL   Операционная система
    //54	FreeBSD / BSD
    //64	Linux
    //128	Windows
    //255	Cisco / Solaris
    //65    Android
    //65    IOS
    //130   Lumia

    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;


            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "OS";
            dataGridView1.Columns[1].Name = "TTL";

            dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Dock = DockStyle.None;

            dataGridView1.Rows.Add(new string[]{ "FreeBSD", "54" });
            dataGridView1.Rows.Add(new string[]{ "Linux", "64" });
            dataGridView1.Rows.Add(new string[]{ "Windows", "128" });
            dataGridView1.Rows.Add(new string[]{ "Cisco / Solaris", "255" });
            dataGridView1.Rows.Add(new string[]{ "Android", "65" });
            dataGridView1.Rows.Add(new string[]{ "IOS", "IOS" });
            dataGridView1.Rows.Add(new string[]{ "Lumia", "130" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
