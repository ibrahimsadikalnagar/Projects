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
    public partial class Form2 : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID); 
        public event DataBackEventHandler DataBack;
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonReturnData_Click(object sender, EventArgs e)
        {
            int PersonID = int.Parse(txtboxPersonID.Text);
            DataBack?.Invoke(this, PersonID);
            this.Close();
        }
    }
}
