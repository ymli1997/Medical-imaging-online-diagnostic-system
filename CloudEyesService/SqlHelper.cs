using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CloudEyesService
{
    public class SqlHelper
    {
        //读取连接字符串
        private static readonly string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        
        //三个方法
        /// <summary>
        /// 此方法可以做增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回的是受影响的行数，int类型</returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[]ps)//params 可以传任意多个参数
        {
            //连接数据库
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);//ps是参数数组，所以用AddRange
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        } 

        /// <summary>
        /// 该方法返回的是首行首列，用在查询上
        /// </summary>
        /// <param name="sql">语句</param>
        /// <param name="ps">参数</param>
        /// <returns>首行首列，object类型</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);//ps是参数数组，所以用AddRange
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 该方法用于查询读取数据，读取每一行
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回的是SqlDataReader对象，里面有数据</returns>
        public static SqlDataReader ExecuteReader(string sql,params SqlParameter[]ps)
        {
            SqlConnection con = new SqlConnection(str);//没有using封装就要手动释放
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);//ps是参数数组，所以用AddRange
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回表</returns>
        public static DataTable ExecuteTable(string sql, params SqlParameter[] ps)

        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, str))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }
                sda.Fill(dt);
                return dt;
            }
        }
    }
}