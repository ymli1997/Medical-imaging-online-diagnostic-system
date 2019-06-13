using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CloudDiagnosis.UI.View
{
    public partial class FormSetTimePeriod : Form
    {
        public FormSetTimePeriod()
        {
            InitializeComponent();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            SystemConfiguration.SaveConfig();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnStartFromNow_Click(object sender, EventArgs e)
        {
            dateTimePickerStartTime.Value = DateTime.Now;
        }

        private void btnEndByNow_Click(object sender, EventArgs e)
        {
            dateTimePickerEndTime.Value = DateTime.Now;
        }

        private void btnQueryFromDatabase_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();                                  
            dateTimePickerStartTime.Value = startTime;
            dateTimePickerEndTime.Value = endTime;
        }
    }
}
