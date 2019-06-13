using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rising.Utilities;

namespace CloudEyes.Business
{
    public class PointsHelper
    {
        #region sql执行公共函数

        public static DataTable GetDtBySQL(string commandText)
        {
            DataTable dtTemp = new DataTable("dtTemp");
            //using (IDbHelper dbHelper = DbHelperFactory.GetHelper(SystemConfiguration.DbType))
            //{
            //    try
            //    {
            //        dbHelper.Open(SystemConfiguration.DbConnectionString);

            //        dtTemp.Clear();
            //        dbHelper.Fill(dtTemp, commandText);

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        dbHelper.Close();
            //    }
                return dtTemp;
            //}
        }

        #endregion

        #region 点组
        public static DataTable GetPointsDt()
        {
            string commandText = @"SELECT PointGroups.Name AS GroupName, Points.Name AS PointName, Points.Epoch, PointGroups.ID AS GroupID, Points.ID AS PointID
                                        FROM Points INNER JOIN
                                              PointGroupItems ON Points.ID = PointGroupItems.Point_ID INNER JOIN
                                              PointGroups ON PointGroupItems.PointGroup_ID = PointGroups.ID
                                        order by GroupName,PointName";

            return GetDtBySQL(commandText);
        }

        public static PointM[] GetPoints()
        {
            DataTable dtPoints = GetPointsDt();
            PointM[] Points = new PointM[dtPoints.Rows.Count];
            int i = 0;
            foreach (DataRow drPoint in dtPoints.Rows)
            {
                PointM temp = new PointM(drPoint["GroupName"].ToString(),
                                       drPoint["PointName"].ToString(),
                                       drPoint["Epoch"].ToString(),
                                       drPoint["GroupID"].ToString(),
                                       drPoint["PointID"].ToString()
                                       );
                Points[i++] = temp;
            }

            return Points;
        }

        public static string GetPointsListFromPoinMs(PointM[] points)
        {
            string strPointsList = string.Empty;

            if (points.Length == 0)
            {
                return strPointsList;
            }

            foreach (PointM point in points)
            {
                strPointsList += "'"+point.PointName + "',";
            }

            strPointsList = strPointsList.Substring(0, strPointsList.Length - 1);

            return strPointsList;
        }

        #endregion
    }

    #region Point Class

    /// <summary>
    /// 监测点类
    /// </summary>
    public class PointM
    {
        /// <summary>
        /// 初始化监测点
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="pointName">点名</param>
        /// <param name="epoch">最后取数时间</param>
        /// <param name="groupID">组编号</param>
        /// <param name="pointID">点编号</param>
        public PointM(string groupName, string pointName, string epoch, string groupID, string pointID)
        {
            GroupName = groupName;
            PointName = pointName;
            Epoch = epoch;
            GroupID = groupID;
            PointID = pointID;
        }
        private string _GroupName;
        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName
        {
            get { return _GroupName; }
            set
            {
                _GroupName = value;
            }
        }
        private string _PointName;
        /// <summary>
        /// 点名
        /// </summary>
        public string PointName
        {
            get { return _PointName; }
            set
            {
                _PointName = value;
            }
        }
        private string _Epoch;
        /// <summary>
        /// 最后取数时间
        /// </summary>
        public string Epoch
        {
            get { return _Epoch; }
            set
            {
                _Epoch = value;
            }
        }
        private string _GroupID;
        /// <summary>
        /// 组编号
        /// </summary>
        public string GroupID
        {
            get { return _GroupID; }
            set
            {
                _GroupID = value;
            }
        }
        private string _PointID;
        /// <summary>
        /// 点编号
        /// </summary>
        public string PointID
        {
            get { return _PointID; }
            set
            {
                _PointID = value;
            }
        }
    }
    #endregion
}
