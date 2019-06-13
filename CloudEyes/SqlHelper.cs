using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CloudEyes
{
    public class SqlHelper
    {
        //读取连接字符串
        private static readonly string str = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

        //三个方法
        /// <summary>
        /// 此方法可以做增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回受影响的行数，int类型</returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[]ps)
        {
            //连接数据库
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }                    
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// 该方法用在查询上
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>首行首列，object类型</returns>
        public static object ExecuteSclary(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 该方法用于查询读取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回的是SqlDataReader对象，里面有数据</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlConnection con = new SqlConnection(str);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
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

    }
}
