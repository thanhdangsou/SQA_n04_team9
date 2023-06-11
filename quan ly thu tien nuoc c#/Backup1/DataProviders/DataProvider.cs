using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataProviders
{
    public abstract class DataProvider
    {
        public abstract DataTable Execute_Table(string strSQL);
        public abstract int Execute_Modify(string strSQL);
        public abstract SqlDataReader Execute_Reader(string strSQL);
        public virtual DataTable Execute_Table(string SPName, SqlParameter[] para)
        {
            return null;
        }
        public virtual int Execute_Modify(string SPName, SqlParameter[] para)
        {
            return -1;
        }
        public virtual SqlDataReader Execute_Reader(string SPName,SqlParameter []para)
        {
            return null;
        }
    }
    public class SQLProvider : DataProvider
    {
        MultiRows db;
        public override DataTable Execute_Table(string strSQL)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cnn);
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cnn.Close();
                }
            }
        }
        public override int Execute_Modify(string strSQL)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cnn);
                    int kq = (int)cmd.ExecuteNonQuery();
                    return kq;
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    cnn.Close();
                }
            }
        }
        public override DataTable Execute_Table(string SPName, SqlParameter[] para)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(SPName, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                        cmd.Parameters.AddRange(para);
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cnn.Close();
                }
            }
        }
        public override int Execute_Modify(string SPName, SqlParameter[] para)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(SPName, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                        cmd.Parameters.AddRange(para);
                    int kq = (int)cmd.ExecuteNonQuery();
                    return kq;
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    cnn.Close();
                }
            }
        }
        public override SqlDataReader Execute_Reader(string strSQL)
        {
            using(SqlConnection cnn=new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cnn);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch
                {
                    return null;
                }
        }
        public override SqlDataReader Execute_Reader(string SPName, SqlParameter[] para)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(SPName,cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            cmd.Parameters.Add(para[i]);
                        }
                    }
                    return cmd.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static string GetAll(string str)
        {
            string s = "select * from " + str;
            return s;
        }
    }
}
