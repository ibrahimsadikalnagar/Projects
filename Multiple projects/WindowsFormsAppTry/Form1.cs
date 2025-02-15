using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFirstClass;

namespace WindowsFormsAppTry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyFirstMath myFirstMath = new MyFirstMath();
            MessageBox.Show(myFirstMath.sum(10, 13).ToString()); 
        }
    }
}
