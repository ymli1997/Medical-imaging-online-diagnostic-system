//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace CloudDiagnosis.UI.File
{
    using System.Data;
    using Rising.Utilities;

    public partial class FormConnectToProject : Form
    {
        public FormConnectToProject()
        {
            InitializeComponent();

        }


        private void btnConnectTest_Click(object sender, EventArgs e)
        {

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(SystemConfiguration.DbType))
            {
                try
                {
                    dbHelper.Open(SystemConfiguration.DbConnectionString);
                    string commandText = "Exec sp_helpdb";

                    DataTable dtTemp = new DataTable("sp_helpdb");
                    dtTemp.Clear();
                    dbHelper.Fill(dtTemp, commandText);

                    foreach (DataRow drDB in dtTemp.Rows)
                    {
                        string strDbName = drDB["name"].ToString();
                        if (strDbName != "master" && strDbName != "model" && strDbName != "msdb" && strDbName != "tempdb")
                        {
                            //comboBoxDatabaseName.Items.Add(strDbName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
        }
    }
}