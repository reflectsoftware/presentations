using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using AOPDemo.Layers;
using ReflectSoftware.Insight;

namespace Demo4
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------
        private void BtnAOPTest1_Click(object sender, EventArgs e)
        {
            try
            {
                WebApi api = new WebApi();

                api.Method1("Ross Pellegrino", new DateTime(2000, 09, 30), "123-456-789");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------
        private void BtnAOPTest2WithException_Click(object sender, EventArgs e)
        {
            try
            {
                WebApi api = new WebApi();

                api.Method1("Ross Pellegrino", new DateTime(2020, 09, 30), "123-456-789");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------
        private void BtnAOPFieldTest3_Click(object sender, EventArgs e)
        {
            SomeClass sc = new SomeClass();
            sc.Name = Guid.NewGuid().ToString();
            sc.Address = Guid.NewGuid().ToString();
            sc.Age = new Random().Next();
        }
        //---------------------------------------------------------------------
        private void BntClearView_Click(object sender, EventArgs e)
        {
            GReflectInsight.ViewerClearAll();
        }
    }
}
