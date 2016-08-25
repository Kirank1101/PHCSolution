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
    public partial class AddLabTests : Form
    {
        public AddLabTests()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<employee> lstemp = new List<employee>();
            employee emp = new employee();
            emp.name="Nagavardhan";
            emp.age=22;
            emp.sex="Male";
            emp.contactno="9900990300";
            emp.place="Kappanahalli" ;
            lstemp.Add(emp);
            employee emp1 = new employee();
            emp1.name = "harshavardhan";
            emp1.age = 22;
            emp1.sex = "Male";
            emp1.contactno = "9900990300";
            emp1.place = "Kappanahalli";
            lstemp.Add(emp1);
            dataGridView1.DataSource = lstemp;
            
        }

       
    }
}
