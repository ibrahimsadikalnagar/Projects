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

namespace WindowsFormPersentationLayer
{
    public partial class FrmAddEdit : Form
    {
        public enum enMode { AddMode =  0 , UpdateMode = 1};
        private enMode _Mode; 
        AddBusnissCountryLayer _Country;
        int _CountryID;
        public FrmAddEdit(int CountryID)
        {
           _CountryID = CountryID;
            InitializeComponent();
            if (_CountryID == -1)
            {
                _Mode = enMode.AddMode;
            }
            else
            {
                _Mode = enMode.UpdateMode;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _Country = new AddBusnissCountryLayer();
            _Country.Name = textBoxCountryName.Text;
            _Country.CountryCode=int.Parse( textBoxCountryCode.Text);  
            _Country.CountryInfo=textBoxCountryInfo.Text;
            if (_Country.save())
            {
                MessageBox.Show("Data saved succefully");
            }
            else
            {
                MessageBox.Show("Data not saved");
            }
            _Mode = enMode.UpdateMode;
            lblMode.Text = "Edit Country ID = " + _CountryID;
            textBoxCountryID.Text = _CountryID.ToString();
            

        }
        private void _load()
        {
            _Country = AddBusnissCountryLayer.FindData(_CountryID);
            if (_Country == null)
            {
                MessageBox.Show("The ID that you entered is not valid");
                return;
            }
            textBoxCountryID.Text = _Country.ID.ToString();
            textBoxCountryName.Text = _Country.Name;    
            textBoxCountryCode.Text = _Country.CountryCode.ToString();
            textBoxCountryInfo.Text = _Country.CountryInfo;

}
        private void FrmAddEdit_Load(object sender, EventArgs e)
        {
            _load();    
        }
    }
}
