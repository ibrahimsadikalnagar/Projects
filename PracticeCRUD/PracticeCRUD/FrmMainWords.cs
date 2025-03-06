using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeCRUD
{
    public partial class FrmMainWords : Form
    {
        public FrmMainWords()
        {
            InitializeComponent();
        }
        private void _RefreshWordsList()
        {
            dataGridViewNewWord.DataSource = clsBusniessWords.GetAllData();
        }

        private void FrmMainWords_Load(object sender, EventArgs e)
        {
            _RefreshWordsList();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmAddEditWords frmAddEdit = new FrmAddEditWords();
            frmAddEdit.ShowDialog();
        }
    }
}
