using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHCForms
{
    public partial class DrugInfo : Form
    {
        public DrugInfo()
        {
            InitializeComponent();
        }

        private void DrugInfo_Load(object sender, EventArgs e)
        {
            List<Druginfo> lstdruginfo = new List<Druginfo>();
            Druginfo di = new Druginfo();
            di.Drugid = "1";
            di.DrugName = "Calpal";
            lstdruginfo.Add(di);
            Druginfo di1 = new Druginfo();
            di1.Drugid = "2";
            di1.DrugName = "Combiflam";
            lstdruginfo.Add(di1);
            ddldrugname.DataSource = lstdruginfo;
            ddldrugname.DisplayMember = "DrugName";
            ddldrugname.ValueMember = "Drugid";
        }
    }
}
