/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Rising.Utilities.Office;

namespace CloudDiagnosis.UI.Tools
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormMakeFakeResults : Form
    {
        DataTable dtPoints = null;     //监测点信息
        DataTable dtResults = null;    //监测点结果
        public FormMakeFakeResults()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            InitPoints();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void InitPoints()
        {

            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;

            string sql = @"SELECT ID,Name FROM Points Order by Name";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);
                da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                dtPoints = ds.Tables[0];

                comboBoxPoints.ValueMember = "ID";
                comboBoxPoints.DisplayMember = "Name";

                comboBoxPoints.DataSource = dtPoints;

            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        void BtnQueryNodeDataClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;
            string sql = @"SELECT *
                              FROM PointReportViewAvgByDay
                              where PointNo = @PrismNodeid";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);
                sc.Parameters.Add(new SqlParameter("@PrismNodeid", comboBoxPoints.Text));
                
                da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                dtResults = ds.Tables[0];
                dtResults.TableName = "PointReportViewAvgByDay";

                dataGridViewMain.DataSource = dtResults;

            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        private void btnResultsPreprocessing_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            string sql = @"EXEC	ResultsPreprocessing";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);

                sc.ExecuteNonQuery();

                InitPoints();

                MessageBox.Show("数据预处理完成。");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel(*.xls,*.xlsx) |*.xls;*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
            ExcelHelper Excel = new ExcelHelper();
            Excel.DataTableToExcel(dtResults, 1, 1);
            Excel.SaveFile(strFilePath);
        }

        private void btnImportFromExcel_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel(*.xls,*.xlsx) |*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            ReadFromExcel(strFilePath);

        }
        private void ReadFromExcel(string strFilePath)
        {
            int iRowIndex = 1;
            string strCellText = string.Empty;
            ExcelHelper Excel = new ExcelHelper(strFilePath);
            GetNullDatatable();
            strCellText = Excel.GetCell(iRowIndex, 1);
            while (!string.IsNullOrEmpty(strCellText))
            {
                DataRow dr = dtResults.NewRow();
                for (int j = 0; j < dtResults.Columns.Count; j++)
                {
                    strCellText = Excel.GetCell(iRowIndex, j + 1);
                    if (j > 1)
                    {
                        double dTemp = Convert.ToDouble(strCellText);
                        dr[j] = dTemp;
                    }
                    else
                    {
                        dr[j] = strCellText;
                    }

                }
                dtResults.Rows.Add(dr);
                iRowIndex++;
                strCellText = Excel.GetCell(iRowIndex, 1);
            }

            Excel.KillExcelProcess();

            dataGridViewMain.DataSource = dtResults;
        }
        private void GetNullDatatable()
        {
            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;
            string sql = @"SELECT *
                              FROM PointReportViewAvgByDay
                              where 1=2";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);

                da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                dtResults = ds.Tables[0];
                dtResults.TableName = "PointReportViewAvgByDay";

                dataGridViewMain.DataSource = dtResults;

            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnSaveData2DB_Click(object sender, EventArgs e)
        {
            string strSqlDelete = @"Delete from [PointReportViewAvgByDay] where [PointNo]=@PointNo and [Day]=@Day";
            string strSqlInsert = @"insert into [PointReportViewAvgByDay]( [PointNo]
                                      ,[Day]
                                      ,[MaxLD]
                                      ,[MinLD]
                                      ,[AvgLD]
                                      ,[MaxTD]
                                      ,[MinTD]
                                      ,[AvgTD]
                                      ,[MaxHD]
                                      ,[MinHD]
                                      ,[AvgHD]
                                      ,[Pressure]
                                      ,[AvTemp])
                                values (@PointNo,@Day,@MaxLD,@MinLD,@AvgLD,@MaxTD,@MinTD,@AvgTD,@MaxHD,@MinHD,@AvgHD,@Pressure,@AvTemp)";
            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
                try
                {
                    conn.Open();
                    SqlCommand scDelete = new SqlCommand(strSqlDelete, conn);
                    scDelete.Parameters.Add(new SqlParameter("@PointNo", dataGridViewMain.Rows[i].Cells[0].FormattedValue));
                    scDelete.Parameters.Add(new SqlParameter("@Day", dataGridViewMain.Rows[i].Cells[1].FormattedValue));
                    scDelete.ExecuteNonQuery();

                    SqlCommand sc = new SqlCommand(strSqlInsert, conn);
                    sc.Parameters.Add(new SqlParameter("@PointNo", dataGridViewMain.Rows[i].Cells[0].FormattedValue));
                    sc.Parameters.Add(new SqlParameter("@Day", dataGridViewMain.Rows[i].Cells[1].FormattedValue));
                    sc.Parameters.Add(new SqlParameter("@MaxLD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[2].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@MinLD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[3].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AvgLD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[4].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@MaxTD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[5].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@MinTD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[6].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AvgTD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[7].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@MaxHD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[8].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@MinHD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[9].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AvgHD", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[10].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@Pressure", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[11].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AvTemp", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[12].FormattedValue)));
                    sc.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }


            }
        }

        private void btnFakeDailyResults_Click(object sender, EventArgs e)
        {
            DataRow dr = GetDataRow();

            try
            {
                string strTest = string.Empty;
                strTest = dr["PointNo"].ToString();
                strTest = dr["Day"].ToString();
                strTest = dr["MaxLD"].ToString();
                strTest = dr["MinLD"].ToString();
                strTest = dr["AvgLD"].ToString();
                strTest = dr["MaxTD"].ToString();
                strTest = dr["MinTD"].ToString();
                strTest = dr["AvgTD"].ToString();
                strTest = dr["MaxHD"].ToString();
                strTest = dr["MinHD"].ToString();
                strTest = dr["AvgHD"].ToString();
                strTest = dr["Pressure"].ToString();
                strTest = dr["AvTemp"].ToString();
            }
            catch 
            {
                MessageBox.Show("请将行内数据填写完整再生成明细数据！");
                return;
            }
            
            FormMakeFakeDailyResults formMakeFakeDailyResults = new FormMakeFakeDailyResults(dr);
            formMakeFakeDailyResults.ShowDialog();
        }

        private DataRow GetDataRow()
        {
            DataRow dr = dtResults.NewRow();
            for (int i = 0; i < dataGridViewMain.ColumnCount; i++)
            {
                dr[i] = dataGridViewMain.CurrentRow.Cells[i].FormattedValue;
            }
            return dr;
        }


    }
}
