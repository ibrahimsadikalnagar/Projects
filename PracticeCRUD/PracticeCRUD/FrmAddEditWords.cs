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

namespace PracticeCRUD
{
    public partial class FrmAddEditWords : Form
    {
        public FrmAddEditWords()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBusniessWords clsWords = new clsBusniessWords();
            clsWords.Word = txtboxNewWord.Text;
            clsWords.Translate = txtboxTranslate.Text;
            clsWords.WordTypeID = int.Parse(comboBoWordType.Text);
            if(clsWords._AddWords())
            {
                lblWordID.Text = clsWords.WordID.ToString();
                lblTitle.Text = "Edit Word"; 
            }
            

        }

    }
}
