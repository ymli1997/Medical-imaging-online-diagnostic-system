//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace CloudDiagnosis.UI.File
{
    using System.Data;
    using Rising.Utilities;

    public partial class FormDBExport : Form
    {
        public FormDBExport()
        {
            InitializeComponent();

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
                            comboBoxDatabaseName.Items.Add(strDbName);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            string strFullExpFilePath = txtFileName.Text;
            string strDatabaseName = comboBoxDatabaseName.Text;
                
            if (string.IsNullOrEmpty(strDatabaseName))
            {
                MessageBox.Show("请选择需要备份的数据库！");
                comboBoxDatabaseName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(strFullExpFilePath))
            {
                MessageBox.Show("请选择设置保存备份文件的路径及文件名！");
                txtFileName.Focus();
                return;
            }

            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(SystemConfiguration.DbType))
            {
                try
                {
                    dbHelper.Open(SystemConfiguration.DbConnectionString);
                    string commandText = "backup database [" + strDatabaseName + "] to disk='" + strFullExpFilePath+"'";

                    dbHelper.ExecuteNonQuery(commandText);
                    MessageBox.Show("数据库："+strDatabaseName + "已经成功备份到路径："+strFullExpFilePath+"!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("备份数据库失败，请联系管理员。");
                }
                finally
                {
                    dbHelper.Close();
                }
            }
        }

        private void btnGetSaveFileDir_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "BAK文件|*.bak|所有文件|*.*";
            sf.AddExtension = true;
            sf.Title = "备份数据库为...";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = sf.FileName;
            }
        }
    }
}