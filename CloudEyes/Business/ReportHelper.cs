using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rising.Utilities;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Rising.Utilities.Utilities;
namespace CloudEyes.Business
{

    public delegate DataTable GetPointsDisplacementDelegate(string selectedPointsList);

    /// <summary>
    /// 报表助手类
    /// </summary>
    public class ReportHelper
    {
        #region sql执行公共函数

        public static DataTable GetDtBySQL(string commandText)
        {
            DataTable dtTemp = new DataTable("dtTemp");
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(SystemConfiguration.DbType))
            {
                try
                {
                    dbHelper.Open(SystemConfiguration.DbConnectionString);

                    dtTemp.Clear();
                    dbHelper.Fill(dtTemp, commandText);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
                return dtTemp;
            }
        }

        public static void ExecuteNonQuery(string commandText)
        {
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(SystemConfiguration.DbType))
            {
                try
                {
                    dbHelper.Open(SystemConfiguration.DbConnectionString);

                    dbHelper.ExecuteNonQuery(commandText);

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
        #endregion

        #region 杂项功能
        /// <summary>
        /// 获取数据库中的最大时间和最小时间
        /// </summary>
        /// <param name="startTime">最小时间</param>
        /// <param name="endTime">最大时间</param>
        public static void GetMaxAndMinTime(ref DateTime startTime, ref DateTime endTime)
        {

            SqlConnection conn = new SqlConnection(SystemConfiguration.DbConnectionString);
            SqlDataAdapter da = null;
            string sql = @"SELECT MAX([Time]) AS Epoch_Max,MIN([Time]) AS Epoch_Min FROM [PointReportView]";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(sql, conn);

                da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                DataTable dtResults = ds.Tables[0];
                startTime = Convert.ToDateTime(dtResults.Rows[0]["Epoch_Min"].ToString()).AddSeconds(-1);
                endTime = Convert.ToDateTime(dtResults.Rows[0]["Epoch_Max"].ToString()).AddSeconds(1);
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region 查询点数据

        /// <summary>
        /// 查询点的时间段数据，此处应该改为使用ID，防止重名
        /// </summary>
        /// <param name="pointsNos">点名称列表，用逗号分隔，如果点名称列表为空，那么不返回任何数据</param>
        /// <returns>查询到的数据</returns>
        public static DataTable GetPointsDisplacement(string pointsNos, DateTime startTime, DateTime endTime)
        {
            if (string.IsNullOrEmpty(pointsNos))
            {
                return null;
            }
            string sql = string.Format("Select * from PointReportView where (Time >='{0:yyyy-MM-dd HH:mm:ss}' and Time <='{1:yyyy-MM-dd HH:mm:ss}') ", startTime, endTime);
            if (!string.IsNullOrEmpty(sql))
            {
                if (!string.IsNullOrEmpty(pointsNos))
                {
                    sql = sql + " and PointNo in (" + pointsNos + ")";
                }
            }

            sql += " Order by Time ASC";

            return GetDtBySQL(sql);
        }

        /// <summary>
        /// 查询点的时间段数据，此处应该改为使用ID，防止重名
        /// </summary>
        /// <param name="pointsNos">点名称列表，用逗号分隔，如果点名称列表为空，那么不返回任何数据</param>
        /// <returns>查询到的数据</returns>
        public static DataTable GetPointsDisplacement(string pointsNos)
        {
            if (string.IsNullOrEmpty(pointsNos))
            {
                return null;
            }
            string sql = string.Format("Select * from PointReportView where (Time >='{0:yyyy-MM-dd HH:mm:ss}' and Time <='{1:yyyy-MM-dd HH:mm:ss}') ");
            if (!string.IsNullOrEmpty(sql))
            {
                if (!string.IsNullOrEmpty(pointsNos))
                {
                    sql = sql + " and PointNo in (" + pointsNos + ")";
                }
            }

            sql += " Order by Time ASC";

            return GetDtBySQL(sql);
        }
        #endregion

        #region 日报
        /// <summary>
        /// 数据平滑周期设置
        /// </summary>
        /// <returns></returns>
        private static string GetDataSmoothCycleCast()
        {
            string strReturn = "DATEPART(Hh, [Time])";
            if (DailyReportOption.DataSmoothCycle == EnumDataSmoothCycle.每1小时)
            {
                return strReturn;
            }

            int dataSmoothCycle = (int)DailyReportOption.DataSmoothCycle;
            strReturn = "case DATEPART(Hh, [Time]) ";
            for (int i = 0; i < 24; i++)
            {
                strReturn += string.Format(" when {0} then {1}", i, dataSmoothCycle * Math.Floor((double)(i / dataSmoothCycle)));
            }
            strReturn += " end ";
            return strReturn;
        }


        /// <summary>
        /// 获取日报原始数据
        /// </summary>
        /// <param name="strStartTime">开始时间</param>
        /// <param name="strEndTime">结束时间</param>
        /// <returns></returns>
        public static DataTable GetDailyReportRawData(string strStartTime, string strEndTime)
        {
            string strDataSmoothCycleCast = GetDataSmoothCycleCast();
            string sql = @"select [PointNo]
                                    ,CONVERT(varchar(100),[Time], 111) as 'Date'
                                    ," + strDataSmoothCycleCast + @" as 'Hour'
                                    ,AVG([DiffFromNullMeas])*1000 as 'AvgLD'
                                    ,AVG([TransverseDisplacement])*1000 as 'AvgTD'
                                    ,AVG([HeightDisplacement])*1000 as 'AvgHD'
                                    ,AVG([Pressure]) as 'Pressure'
                                    ,AVG([Av.Temp.]) as 'AvTemp'
                                    from [PointReportView]
                                    where SUBSTRING ([PointNo],1,2)not in ('TM','HS','FS')
                                    and CONVERT(varchar(100),[Time], 111)>='" + strStartTime + @"'
                                    and CONVERT(varchar(100),[Time], 111)<='" + strEndTime + @"'
                                    group by [PointNo],CONVERT(varchar(100),[Time], 111)," + strDataSmoothCycleCast + @"
                                    order by [PointNo],'Date','Hour'";

            return GetDtBySQL(sql);
        }
        private static double[] CaculateInterpolation(object frontEnd, object backEnd, int count)
        {
            return CaculateInterpolation(Convert.ToDouble(frontEnd), Convert.ToDouble(backEnd), count);
        }
        private static double[] CaculateInterpolation(double frontEnd, double backEnd, int count)
        {
            double[] interpolation = new double[count];

            for (int i = 0; i < interpolation.Length; i++)
            {
                switch (DailyReportOption.HandleMissingDataMethod)
                {
                    case EnumHandleMissingDataMethod.插值:
                        interpolation[i] = frontEnd + (backEnd - frontEnd) * (i + 1) / (count + 1);
                        break;
                    case EnumHandleMissingDataMethod.前端值:
                        interpolation[i] = frontEnd;
                        break;
                    case EnumHandleMissingDataMethod.后端值:
                        interpolation[i] = backEnd;
                        break;
                    case EnumHandleMissingDataMethod.平均值:
                        interpolation[i] = (backEnd + frontEnd) / 2;
                        break;
                    default:
                        interpolation[i] = frontEnd + (backEnd - frontEnd) * (i + 1) / (count + 1);
                        break;
                }
            }
            return interpolation;

        }
        private static void CaculateInterpolation(DataRow frontEnd, DataRow backEnd, DataTable dtPreprocessed)
        {
            int dataSmoothCycle = (int)DailyReportOption.DataSmoothCycle;
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
            DateTime dt1 = Convert.ToDateTime(string.Format("{0} {1}:00:00", frontEnd["Date"], frontEnd["Hour"]), dtFormat);
            DateTime dt2 = Convert.ToDateTime(string.Format("{0} {1}:00:00", backEnd["Date"], backEnd["Hour"]), dtFormat);
            TimeSpan ts = dt2 - dt1;
            int hours = ts.Days * 24 + ts.Hours;
            int count = (hours - dataSmoothCycle) / dataSmoothCycle;

            if (count > 0)
            {
                double[] AvgLDInterpolation = CaculateInterpolation(frontEnd["AvgLD"], backEnd["AvgLD"], count);
                double[] AvgTDInterpolation = CaculateInterpolation(frontEnd["AvgTD"], backEnd["AvgTD"], count);
                double[] AvgHDInterpolation = CaculateInterpolation(frontEnd["AvgHD"], backEnd["AvgHD"], count);
                double[] PressureInterpolation = CaculateInterpolation(frontEnd["Pressure"], backEnd["Pressure"], count);
                double[] AvTempInterpolation = CaculateInterpolation(frontEnd["AvTemp"], backEnd["AvTemp"], count);

                for (int i = 0; i < count; i++)
                {
                    DataRow drNew = dtPreprocessed.NewRow();
                    DateTime date = Convert.ToDateTime(frontEnd["Date"]);
                    int hour = Convert.ToInt32(frontEnd["Hour"].ToString()) + (i + 1) * dataSmoothCycle;
                    int days = (int)Math.Floor((double)(hour / 24));
                    hour = hour - days * 24;
                    drNew["PointNo"] = frontEnd["PointNo"];
                    drNew["Date"] = date.AddDays(days).ToString("yyyy\\/MM\\/dd");
                    drNew["Hour"] = hour;
                    drNew["AvgLD"] = AvgLDInterpolation[i];
                    drNew["AvgTD"] = AvgTDInterpolation[i];
                    drNew["AvgHD"] = AvgHDInterpolation[i];
                    drNew["Pressure"] = PressureInterpolation[i];
                    drNew["AvTemp"] = AvTempInterpolation[i];
                    dtPreprocessed.Rows.Add(drNew);
                }
            }

        }

        public static DataTable GetOneDailyReport(DataTable dtDailyReport, DateTime day)
        {
            DataTable dtOneDay = dtDailyReport.Clone();
            dtOneDay.Columns.Add("DeltaLD", typeof(System.Double));
            dtOneDay.Columns.Add("DeltaTD", typeof(System.Double));
            dtOneDay.Columns.Add("DeltaHD", typeof(System.Double));

            string filter = string.Empty;
            filter = string.Format("(Date >='{0}' and Date <= '{1}') and hour={2}", day.AddDays(-1).ToString("yyyy\\/MM\\/dd"), day.ToString("yyyy\\/MM\\/dd"), 24 - (int)DailyReportOption.DataSmoothCycle);
            string sort = "PointNo      , Date       , Hour ";
            DataRow[] drFilter = dtDailyReport.Select(filter, sort);

            DataTable dtTemp = dtDailyReport.Clone();
            foreach (var item in drFilter)
            {
                dtTemp.Rows.Add(item.ItemArray);
            }


            for (int i = 0; i < drFilter.Length; )
            {
                string strPointNo = drFilter[i]["PointNo"].ToString();
                //去除反光贴数据（需要修改）
                if (strPointNo.Substring(strPointNo.Length - 1) == "F" || strPointNo.Substring(0, 3) != "JCD")
                {
                    i++;

                    continue;
                }
                if (i + 1 < drFilter.Length)
                {
                    if (drFilter[i]["PointNo"].ToString() == drFilter[i + 1]["PointNo"].ToString())
                    {
                        DataRow drNew = dtOneDay.NewRow();
                        drNew["PointNo"] = drFilter[i + 1]["PointNo"].ToString();
                        drNew["Date"] = drFilter[i + 1]["Date"].ToString();
                        drNew["Hour"] = 24 - (int)DailyReportOption.DataSmoothCycle;                        
                        drNew["AvgLD"] = drFilter[i + 1]["AvgLD"];
                        drNew["DeltaLD"] = Convert.ToDouble(drFilter[i + 1]["AvgLD"]) - Convert.ToDouble(drFilter[i]["AvgLD"]);
                        drNew["AvgTD"] = drFilter[i + 1]["AvgTD"];
                        drNew["DeltaTD"] = Convert.ToDouble(drFilter[i + 1]["AvgTD"]) - Convert.ToDouble(drFilter[i]["AvgTD"]);
                        drNew["AvgHD"] = drFilter[i + 1]["AvgHD"];
                        drNew["DeltaHD"] = Convert.ToDouble(drFilter[i + 1]["AvgHD"]) - Convert.ToDouble(drFilter[i]["AvgHD"]);
                        drNew["Pressure"] = drFilter[i + 1]["Pressure"];
                        drNew["AvTemp"] = drFilter[i + 1]["AvTemp"];

                        dtOneDay.Rows.Add(drNew);
                        i = i + 2;
                    }
                    else
                    {
                        if (Convert.ToDateTime(drFilter[i]["Date"]).ToString("yyyy\\/MM\\/dd") == day.AddDays(-1).ToString("yyyy\\/MM\\/dd"))
                        {
                            i++;
                        }
                        else if (Convert.ToDateTime(drFilter[i]["Date"]).ToString("yyyy\\/MM\\/dd") == day.ToString("yyyy\\/MM\\/dd"))
                        {
                            DataRow drNew = dtOneDay.NewRow();
                            drNew["PointNo"] = drFilter[i]["PointNo"].ToString();
                            drNew["Date"] = drFilter[i]["Date"].ToString();
                            drNew["Hour"] = 24 - (int)DailyReportOption.DataSmoothCycle;     
                            drNew["AvgLD"] = drFilter[i]["AvgLD"];
                            drNew["AvgTD"] = drFilter[i]["AvgTD"];
                            drNew["AvgHD"] = drFilter[i]["AvgHD"];
                            drNew["Pressure"] = drFilter[i]["Pressure"];
                            drNew["AvTemp"] = drFilter[i]["AvTemp"];

                            dtOneDay.Rows.Add(drNew);
                            i++;
                        }
                    }

                }
                else
                {
                    if (Convert.ToDateTime(drFilter[i]["Date"]).ToString("yyyy\\/MM\\/dd") == day.AddDays(-1).ToString("yyyy\\/MM\\/dd"))
                        i++;
                    else if (Convert.ToDateTime(drFilter[i]["Date"]).ToString("yyyy\\/MM\\/dd") == day.ToString("yyyy\\/MM\\/dd"))
                    {
                        DataRow drNew = dtOneDay.NewRow();
                        drNew["PointNo"] = drFilter[i]["PointNo"].ToString();
                        drNew["Date"] = drFilter[i]["Date"].ToString();
                        drNew["Hour"] = 24 - (int)DailyReportOption.DataSmoothCycle;     
                        drNew["AvgLD"] = drFilter[i]["AvgLD"];
                        drNew["AvgTD"] = drFilter[i]["AvgTD"];
                        drNew["AvgHD"] = drFilter[i]["AvgHD"];
                        drNew["Pressure"] = drFilter[i]["Pressure"];
                        drNew["AvTemp"] = drFilter[i]["AvTemp"];

                        dtOneDay.Rows.Add(drNew);
                        i++;
                    }

                }

            }

            return dtOneDay;

        }

        public static DataTable ReportDataPreprocess(DataTable dtRawData)
        {
            DataTable dtPreprocessed = dtRawData.Clone();

            DataRow dr1 = dtRawData.Rows[0];
            DataRow dr2 = null;
            int i = 1;
            while (i < dtRawData.Rows.Count)
            {
                dr2 = dtRawData.Rows[i];
                if (dr1["PointNo"].ToString() == dr2["PointNo"].ToString())
                {
                    CaculateInterpolation(dr1, dr2, dtPreprocessed);
                }
                dr1 = dr2;
                i++;
            }

            foreach (DataRow item in dtPreprocessed.Rows)
            {
                dtRawData.Rows.Add(item.ItemArray);
            }

            return dtPreprocessed;
        }

        #endregion
    }

    #region DailyReportOption
    public class DailyReportOption
    {
        public static string TemplateFilePath = string.Empty;
        public static string OutputFilePath = string.Empty;
        public static DateTime StartDate = DateTime.Today.AddDays(-1);
        public static DateTime EndDate = DateTime.Today;
        public static DateTime ReportNoStartDate = DateTime.Today;
        public static string ReportNoPrefix = string.Empty;

        public static EnumHandleMissingDataMethod HandleMissingDataMethod = EnumHandleMissingDataMethod.插值;
        public static EnumDataSmoothCycle DataSmoothCycle = EnumDataSmoothCycle.每1小时;

        public static void Init()
        {

            string strTemplateFilePath = string.Empty;
            try
            {
                TemplateFilePath = ConfigurationManager.AppSettings["DailyReportTemplateFilePath"].ToString();
            }
            catch
            {
            }

            string strOutputFilePath = string.Empty;
            try
            {
                OutputFilePath = ConfigurationManager.AppSettings["DailyReportOutputFilePath"].ToString();
            }
            catch
            {
            }

            string strHandleMissingDataMethod = string.Empty;
            try
            {
                strHandleMissingDataMethod = ConfigurationManager.AppSettings["DailyReportHandleMissingDataMethod"].ToString();
                HandleMissingDataMethod = (EnumHandleMissingDataMethod)Enum.Parse(typeof(EnumHandleMissingDataMethod), strHandleMissingDataMethod);
            }
            catch
            {
            }


            string strDataSmoothCycle = string.Empty;
            try
            {
                strDataSmoothCycle = ConfigurationManager.AppSettings["DailyReportDataSmoothCycle"].ToString();
                DataSmoothCycle = (EnumDataSmoothCycle)Enum.Parse(typeof(EnumDataSmoothCycle), strDataSmoothCycle);
            }
            catch
            {
            }


            string strReportNoStartDay = string.Empty;
            try
            {
                strReportNoStartDay = ConfigurationManager.AppSettings["DailyReportNoStartDay"].ToString();
            }
            catch
            {
                strReportNoStartDay = "2015-01-01";
                ConfigurationManager.AppSettings["DailyReportNoStartDay"] = strReportNoStartDay;
            }
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            ReportNoStartDate = Convert.ToDateTime(strReportNoStartDay, dtFormat);

            string strPrefix = string.Empty;

            try
            {
                strPrefix = ConfigurationManager.AppSettings["DailyReportNoPrefix"].ToString();
            }
            catch
            {
                strPrefix = "2015-01-";
                ConfigurationManager.AppSettings["DailyReportNoPrefix"] = strPrefix;
            }
            ReportNoPrefix = "编号: " + strPrefix;
        }

        public static void SaveConfig()
        {
            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportTemplateFilePath", TemplateFilePath);
                //ConfigurationManager.AppSettings["DailyReportTemplateFilePath"] = TemplateFilePath;
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportOutputFilePath", OutputFilePath);
                //ConfigurationManager.AppSettings["DailyReportOutputFilePath"] = OutputFilePath;

            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportHandleMissingDataMethod", HandleMissingDataMethod.ToString());
                //ConfigurationManager.AppSettings["DailyReportHandleMissingDataMethod"] = HandleMissingDataMethod.ToString();
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }
            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportDataSmoothCycle", DataSmoothCycle.ToString());
                //ConfigurationManager.AppSettings["DailyReportDataSmoothCycle"] = DataSmoothCycle.ToString();
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportNoStartDay", ReportNoStartDate.ToString("yyyy\\/MM\\/dd"));
                //ConfigurationManager.AppSettings["DailyReportNoStartDay"] = ReportNoStartDate.ToString("yyyy\\/MM\\/dd");
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                AppConfigHelper.UpdateAppConfig("DailyReportNoPrefix", ReportNoPrefix);
                //ConfigurationManager.AppSettings["DailyReportNoPrefix"] = ReportNoPrefix;
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
    public enum EnumDataSmoothCycle
    {
        每24小时 = 24,
        每12小时 = 12,
        每6小时 = 6,
        每2小时 = 2,
        每1小时 = 1
    }
    public enum EnumHandleMissingDataMethod
    {
        插值 = 1,
        前端值 = 2,
        后端值 = 3,
        平均值 = 4
    }
    #endregion
}
