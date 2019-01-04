using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc.Data.ADO.NET
{
    public static class SqlHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = DbUtility.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = commandType;
                cmd.CommandText = query;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReader(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                SqlConnection connection = DbUtility.GetSqlConnection;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = commandType;
                cmd.CommandText = query;
                cmd.Connection = connection;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = DbUtility.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = commandType;
                cmd.CommandText = query;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
        }


    }
}
