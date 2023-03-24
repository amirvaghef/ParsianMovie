using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;

namespace Common
{
    public class ConnectionManagerSample
    {
        private int ConnectionCounter;
        private SqlConnection Connection;
        private static Hashtable CMS = new Hashtable();
        private SqlTransaction Transaction;

        private ConnectionManagerSample()
        {
            ConnectionCounter = 0;
        }

        private static string _connectionString;
        public static string connectionString
        {
            set
            {
                _connectionString = value;
            }
            get
            {
                return _connectionString;
            }
        }

        public static ConnectionManagerSample Instance
        {
            get
            {
                if(! CMS.Contains(Thread.CurrentThread))
                    CMS.Add(Thread.CurrentThread, new ConnectionManagerSample());
                return (ConnectionManagerSample)CMS[Thread.CurrentThread];
            }
        }

        public SqlConnection OpenConnection()
        {
            ConnectionCounter += 1;
            if (ConnectionCounter == 1)
            {
                Connection = new SqlConnection(_connectionString);
                Connection.Open();
            }
            return Connection;
        }

        public void CloseConnection()
        {
            ConnectionCounter -= 1;
            if (ConnectionCounter == 0)
            {
                Connection.Close();
                Connection = null;
            }
        }

        //public void DeleteBranch(int BranchCode)
        //{
        //    SqlConnection conn = ConnectionManagerHelper.GetConnection();
        //    try
        //    {
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        SqlCommand DeleteCommand = new SqlCommand("ProcDeleteBranchTbl");
        //        DeleteCommand.CommandType = CommandType.StoredProcedure;
        //        DeleteCommand.Transaction = (SqlTransaction)SkyPW.ConnectionManager.ConnectionManager.Instance.ActiveTransaction;
        //        SqlHelper.AddParameters(DeleteCommand, "BranchCode", SqlDbType.Int);
        //        DeleteCommand.Parameters["@BranchCode"].Value = BranchCode;
        //        DeleteCommand.Connection = conn;
        //        DeleteCommand.ExecuteNonQuery();
        //    }
        //}
    }
}
