using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer; 


namespace WindowsFormPersentationLayer
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
           

        }
        private void _RefreshCountryList()
        {
            dataGridViewCountry.DataSource = AddBusnissCountryLayer.GetAllData();   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _RefreshCountryList();
        }

        private void toolStripComboBoxEdit_Click(object sender, EventArgs e)
        {
            //  MainForm frm = new MainForm((int)dataGridViewCountry.CurrentRow.Cells[0].Value);
            MessageBox.Show("hello"); 
        }
    }
}
