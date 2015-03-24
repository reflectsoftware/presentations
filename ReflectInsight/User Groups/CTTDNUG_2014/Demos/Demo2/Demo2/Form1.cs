using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using ReflectSoftware.Insight;

namespace Demo2
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
        private void BtnTest1_Click(object sender, EventArgs e)
        {
            try
            {
                WebApi.Log4netDemo.WebApi api = new WebApi.Log4netDemo.WebApi();

                api.Process("Ross Pellegrino", new DateTime(2000, 09, 30), "123-456-789");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------
        private void BntClearView_Click(object sender, EventArgs e)
        {
            GReflectInsight.ViewerClearAll();
        }
    }
}
