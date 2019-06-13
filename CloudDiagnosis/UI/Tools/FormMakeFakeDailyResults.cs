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

namespace CloudDiagnosis.UI.Tools
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormMakeFakeDailyResults : Form
    {
        DataTable dtResults = null;    //监测点结果
        public FormMakeFakeDailyResults(DataRow dr)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            textBoxPointNo.Text = dr["PointNo"].ToString();
            textBoxTime.Text = dr["Day"].ToString();
            textBoxMaxLD.Text = dr["MaxLD"].ToString();
            textBoxMinLD.Text = dr["MinLD"].ToString();
            textBoxAvgLD.Text = dr["AvgLD"].ToString();
            textBoxMaxTD.Text = dr["MaxTD"].ToString();
            textBoxMinTD.Text = dr["MinTD"].ToString();
            textBoxAvgTD.Text = dr["AvgTD"].ToString();
            textBoxMaxHD.Text = dr["MaxHD"].ToString();
            textBoxMinHD.Text = dr["MinHD"].ToString();
            textBoxAvgHD.Text = dr["AvgHD"].ToString();
            textBoxPressure.Text = dr["Pressure"].ToString();
            textBoxAvTemp.Text = dr["AvTemp"].ToString();
            
            GetNullDatatable();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void BtnQueryNodeDataClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;
            string sql = @"SELECT *
                              FROM PointReportView
                              where PointNo = @PrismNodeid
                                    and convert(varchar(100),[Time],111) = @Epoch";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);
                sc.Parameters.Add(new SqlParameter("@PrismNodeid", textBoxPointNo.Text));
                sc.Parameters.Add(new SqlParameter("@Epoch", textBoxTime.Text));

                da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                dtResults = ds.Tables[0];

                dataGridViewMain.DataSource = dtResults;

            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void GetNullDatatable()
        {
            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;
            string sql = @"SELECT *
                              FROM PointReportView
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
                dtResults.TableName = "PointReportView";

                dataGridViewMain.DataSource = dtResults;

            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        /// <summary>
        /// 获取double随机数
        /// </summary>
        /// <returns>随机0到1double型随机数</returns>
        private double GetRandom()
        {
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));
            double dRandom = random.NextDouble();
            return dRandom;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dtResults.Rows.Count > 0)
            {
                if (MessageBox.Show("是否需要清除下方框中数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GetNullDatatable();
                }
            }
            string strPointNO = textBoxPointNo.Text;
            DateTime dtStartTime = DateTime.Parse(string.Format("{0} {1}", textBoxTime.Text, dateTimePickerStartTime.Value.ToString("HH:mm:ss")));
            DateTime dtEndTime = DateTime.Parse(string.Format("{0} {1}", textBoxTime.Text, dateTimePickerEndTime.Value.ToString("HH:mm:ss")));
            int iInterval = int.Parse(textBoxTimeInterval.Text);
            int iID = int.Parse(textBoxID.Text);
            double dMaxLD = Convert.ToDouble(textBoxMaxLD.Text);
            double dMinLD = Convert.ToDouble(textBoxMinLD.Text);
            double dAvgLD = Convert.ToDouble(textBoxAvgLD.Text);
            double dMaxTD = Convert.ToDouble(textBoxMaxTD.Text);
            double dMinTD = Convert.ToDouble(textBoxMinTD.Text);
            double dAvgTD = Convert.ToDouble(textBoxAvgTD.Text);
            double dMaxHD = Convert.ToDouble(textBoxMaxHD.Text);
            double dMinHD = Convert.ToDouble(textBoxMinHD.Text);
            double dAvgHD = Convert.ToDouble(textBoxAvgHD.Text);
            double dPressure = Convert.ToDouble(textBoxPressure.Text);
            double AvTemp = Convert.ToDouble(textBoxAvTemp.Text);

            while (dtEndTime >= dtStartTime)
            {
                DataRow drTemp = dtResults.NewRow();
                drTemp["ID"] = iID;
                drTemp["PointNo"] = strPointNO;
                drTemp["ProfileName"] = "Profile1";
                drTemp["Time"] = dtStartTime;
                drTemp["H"] = 0;
                drTemp["V"] = 0;
                drTemp["D"] = 0;
                drTemp["PPMType"] = 1;
                drTemp["PPM"] = 0;
                drTemp["Pressure"] = dPressure;
                drTemp["Av.Temp."] = AvTemp;
                drTemp["AddConst"] = 0;
                drTemp["TargetEasting"] = 0;
                drTemp["TargetNorthing"] = 0;
                drTemp["TargetElevation"] = 0;
                drTemp["ReflectorHeight"] = 0;
                drTemp["InstrumentHeight"] = 0;
                drTemp["StationEasting"] = 0;
                drTemp["StationNorthing"] = 0;
                drTemp["StationHeight"] = 0;
                drTemp["NullMeasurement"] = 0;
                double dLD = dAvgLD + (dMaxLD - dMinLD) * GetRandom();
                drTemp["DiffFromNullMeas"] = dLD;
                drTemp["ShortTimeDiff"] = 0;
                drTemp["LongTimeDiff"] = 0;
                drTemp["VelLimitDiff"] = 0;
                drTemp["DistProfileDirection"] = 0;
                drTemp["HorzDistance"] = 0;
                drTemp["DifferenceOutlierTest"] = 0;
                drTemp["State"] = 0;
                double dTD = dAvgTD + (dMaxTD - dMinTD) * GetRandom();
                drTemp["TransverseDisplacement"] = dTD;
                double dHD = dAvgHD + (dMaxHD - dMinHD) * GetRandom();
                drTemp["HeightDisplacement"] = dHD;
                drTemp["TargetPtID"] = 0;
                drTemp["CustomText1"] = 0;

                dtStartTime = dtStartTime.AddMinutes(iInterval);
                dtResults.Rows.Add(drTemp);
            }

            dataGridViewMain.DataSource = dtResults;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string strSqlDelete = @"Delete from [PointReportView] where [PointNo]=@PointNo and [Time]=@Time";
            string strSqlInsert = @"insert into [PointReportView]( [ID]
                                      ,[PointNo]
                                      ,[ProfileName]
                                      ,[Time]
                                      ,[H]
                                      ,[V]
                                      ,[D]
                                      ,[PPMType]
                                      ,[PPM]
                                      ,[Pressure]
                                      ,[Av.Temp.]
                                      ,[AddConst]
                                      ,[TargetEasting]
                                      ,[TargetNorthing]
                                      ,[TargetElevation]
                                      ,[ReflectorHeight]
                                      ,[InstrumentHeight]
                                      ,[StationEasting]
                                      ,[StationNorthing]
                                      ,[StationHeight]
                                      ,[NullMeasurement]
                                      ,[DiffFromNullMeas]
                                      ,[ShortTimeDiff]
                                      ,[LongTimeDiff]
                                      ,[VelLimitDiff]
                                      ,[DistProfileDirection]
                                      ,[HorzDistance]
                                      ,[DifferenceOutlierTest]
                                      ,[State]
                                      ,[TransverseDisplacement]
                                      ,[HeightDisplacement]
                                      ,[TargetPtID]
                                      ,[CustomText1])
                                values (@ID
                                        ,@PointNo
                                        ,@ProfileName
                                        ,@Time
                                        ,@H
                                        ,@V
                                        ,@D
                                        ,@PPMType
                                        ,@PPM
                                        ,@Pressure
                                        ,@AvTemp
                                        ,@AddConst
                                        ,@TargetEasting
                                        ,@TargetNorthing
                                        ,@TargetElevation
                                        ,@ReflectorHeight
                                        ,@InstrumentHeight
                                        ,@StationEasting
                                        ,@StationNorthing
                                        ,@StationHeight
                                        ,@NullMeasurement
                                        ,@DiffFromNullMeas
                                        ,@ShortTimeDiff
                                        ,@LongTimeDiff
                                        ,@VelLimitDiff
                                        ,@DistProfileDirection
                                        ,@HorzDistance
                                        ,@DifferenceOutlierTest
                                        ,@State
                                        ,@TransverseDisplacement
                                        ,@HeightDisplacement
                                        ,@TargetPtID
                                        ,@CustomText1
                                )";
            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
                try
                {
                    conn.Open();
                    SqlCommand scDelete = new SqlCommand(strSqlDelete, conn);
                    scDelete.Parameters.Add(new SqlParameter("@PointNo", dataGridViewMain.Rows[i].Cells[0].FormattedValue));
                    scDelete.Parameters.Add(new SqlParameter("@Time", dataGridViewMain.Rows[i].Cells[3].FormattedValue));
                    scDelete.ExecuteNonQuery();

                    SqlCommand sc = new SqlCommand(strSqlInsert, conn);
                    sc.Parameters.Add(new SqlParameter("@ID", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[0].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@PointNo", dataGridViewMain.Rows[i].Cells[1].FormattedValue));
                    sc.Parameters.Add(new SqlParameter("@ProfileName", dataGridViewMain.Rows[i].Cells[2].FormattedValue));
                    sc.Parameters.Add(new SqlParameter("@Time", Convert.ToDateTime(dataGridViewMain.Rows[i].Cells[3].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@H", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[4].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@V", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[5].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@D", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[6].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@PPMType", Convert.ToInt32(dataGridViewMain.Rows[i].Cells[7].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@PPM", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[8].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@Pressure", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[9].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AvTemp", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[10].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@AddConst", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[11].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@TargetEasting", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[12].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@TargetNorthing", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[13].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@TargetElevation", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[14].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@ReflectorHeight", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[15].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@InstrumentHeight", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[16].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@StationEasting", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[17].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@StationNorthing", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[18].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@StationHeight", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[19].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@NullMeasurement", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[20].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@DiffFromNullMeas", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[21].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@ShortTimeDiff", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[22].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@LongTimeDiff", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[23].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@VelLimitDiff", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[24].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@DistProfileDirection", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[25].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@HorzDistance", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[26].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@DifferenceOutlierTest", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[27].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@State", Convert.ToInt16(dataGridViewMain.Rows[i].Cells[28].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@TransverseDisplacement", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[29].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@HeightDisplacement", Convert.ToDouble(dataGridViewMain.Rows[i].Cells[30].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@TargetPtID", Convert.ToInt32(dataGridViewMain.Rows[i].Cells[31].FormattedValue)));
                    sc.Parameters.Add(new SqlParameter("@CustomText1", dataGridViewMain.Rows[i].Cells[32].FormattedValue));
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


    }
}
