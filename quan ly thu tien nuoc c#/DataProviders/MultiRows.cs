using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataProviders;

namespace DataProviders
{
    class MultiRows
    {
        SqlCommand cmd;
        SqlConnection cnn;
        public MultiRows()
        {
            cmd = new SqlCommand();
            cnn = new SqlConnection(ConfigurationSettings.AppSettings["SQLProvider"]);
        }
        public void Begin(string SPName, SqlParameter[] para)
        {
            try
            {
                cnn.Open();
                SqlTransaction tran = cnn.BeginTransaction();
                cmd.CommandText = SPName;
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tran;
                if (para != null)
                    cmd.Parameters.AddRange(para);
            }
            catch
            { }
        }
        public void Excuting(ArrayList list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                    cmd.Parameters[i].Value = list[i];
                cmd.ExecuteNonQuery();
            }
            catch
            {
                cmd.Transaction.Rollback();
            }
        }
        public void complete()
        {
            try
            {
                cmd.Transaction.Commit();
            }
            catch
            { }
            finally
            {
                cnn.Close();
            }
        }
    }
}
