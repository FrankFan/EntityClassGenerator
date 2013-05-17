/*
 * Author:fanyong@gmail.com
 * Desciptioni: A simple SqlHelper
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EntityClassGenerator
{
    public class SqlHelper
    {
        #region 变量
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;
        #endregion

        public SqlHelper(string connStr)
        {
            conn = new SqlConnection(connStr);
        }

        #region 获取数据库的连接
        /// <summary>
        /// 获取数据库的连接
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection GetConn()
        {
            //判断数据库状态
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return conn;
        }
        #endregion

        #region 执行不带参数的SQL语句或存储过程
        /// <summary>
        /// 执行SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                //把数据装入到DataTable中
                dt.Load(sdr);
            }
            //记的关闭
            conn.Close();
            return dt;
        }
        #endregion
    }
}
