using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBUtility
{
   public  class SQLHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["DevSuiteConnection"].ToString();
        //增删改
        public static int Update(string sql,SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connString))//定义连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        
        }

        public static int Update(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connString))//定义连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                { 
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }


        }

        //singleresult单集合查
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connString))//定义连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //sqldatareader查询

        public static SqlDataReader GetResultByReader(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

          
        }


        public static SqlDataReader GetResultByReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
             
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }


        }

        //datatable查询
        public static DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, connString))
            {
                sda.SelectCommand.Parameters.AddRange(ps);
                sda.Fill(ds);
            }
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        #region
        /// <summary>
        /// 执行带参数的增删改SQL存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程的字符串</param>
        /// <param name="paras">往存储过程或SQL中赋的参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns>受影响的函数</returns>
        #endregion
        public static int ExecuteNonQueryProc(string cmdText, SqlParameter[] paras)
        {
            

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paras);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
