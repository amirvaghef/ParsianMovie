using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Common
{
    public enum ConnectionType
    {
        OleDb = 2,
        SqlServer = 1
    }
    public class ConnectionManager
    {
        private static Hashtable ConnectionPool;
        public static Common.ConnectionManager Instance;
        private IDbConnection theConnection;
        private Hashtable TransactionHolder;
        private Hashtable TransactionRefCountHolder;

        static ConnectionManager()
        {
            Instance = new Common.ConnectionManager();
            ConnectionPool = new Hashtable();
        }

        private ConnectionManager()
        {
            this.TransactionHolder = new Hashtable();
            this.TransactionRefCountHolder = new Hashtable();
        }

        public void BeginTransaction()
        {
            IDbConnection connection = this.GetConnection();
            if ((this.ActiveTransaction == null) || !this.ActiveTransaction.Connection.Equals(connection))
            {
                IDbTransaction key = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                this.TransactionRefCountHolder.Add(key, 0);
                this.TransactionHolder.Add(Thread.CurrentThread, key);
            }
            this.TransactionRefCountHolder[this.ActiveTransaction] = ((int)this.TransactionRefCountHolder[this.ActiveTransaction]) + 1;
        }

        public void CommitTransaction()
        {
            IDbTransaction activeTransaction = this.ActiveTransaction;
            if (activeTransaction != null)
            {
                int num = (int)this.TransactionRefCountHolder[activeTransaction];
                if (num == 1)
                {
                    IDbConnection conn = activeTransaction.Connection;
                    activeTransaction.Commit();
                    this.RemoveTransaction(activeTransaction);
                    this.FreeConnection(conn);
                }
                else
                {
                    this.TransactionRefCountHolder[this.ActiveTransaction] = num - 1;
                }
            }
        }

        //private IDbConnection CreateConnection()
        //{
        //    IDbConnection connection = null;
        //    if (CommonData.ConnectionManagerType == ConnectionType.SqlServer)
        //    {
        //        connection = new SqlConnection(CommonData.ConnectionString);
        //    }
        //    else if (CommonData.ConnectionManagerType == ConnectionType.OleDb)
        //    {
        //        connection = new OleDbConnection(CommonData.ConnectionString);
        //    }
        //    connection.Open();
        //    return connection;
        //}

         private SqlConnection CreateConnection()
         {
             IDbConnection connection = null;
             if (CommonData.ConnectionManagerType == ConnectionType.SqlServer)
             {
                 connection = new SqlConnection(CommonData.ConnectionString);
             }
             else if (CommonData.ConnectionManagerType == ConnectionType.OleDb)
             {
                 connection = new OleDbConnection(CommonData.ConnectionString);
             }
             connection.Open();
             return (SqlConnection)connection;
         }

        public void FreeConnection(IDbConnection conn)
        {
            Thread key = null;
            foreach (Thread thread2 in ConnectionPool.Keys)
            {
                if (ConnectionPool[thread2] == conn)
                {
                    key = thread2;
                    break;
                }
            }
            //if (key != null && TransactionRefCountHolder.Count <= 0 )
            //{
            //    (ConnectionPool[key] as IDbConnection).Close();
            //    ConnectionPool.Remove(key);
            //}
            if (key != null && TransactionRefCountHolder.Count <= 0 && !key.IsAlive)
            {
                (ConnectionPool[key] as IDbConnection).Close();
                ConnectionPool.Remove(key);
            }
        }

        //public SqlConnection GetConnection()
        //{
        //    if (this.theConnection == null)
        //    {
        //        this.theConnection = this.CreateConnection();
        //    }
        //    return this.theConnection as SqlConnection;
        //}



        public SqlConnection GetConnection()
        {
            this.RemoveDisposedConnection();
            Thread currentThread = Thread.CurrentThread;
            if (!ConnectionPool.ContainsKey(currentThread))
            {
                ConnectionPool.Add(currentThread, this.CreateConnection());
            }
            return (ConnectionPool[currentThread] as SqlConnection);
        }

        //public IDbConnection GetConnection()
        //{
        //    this.RemoveDisposedConnection();
        //    Thread currentThread = Thread.CurrentThread;
        //    if (!ConnectionPool.ContainsKey(currentThread))
        //    {
        //        ConnectionPool.Add(currentThread, this.CreateConnection());
        //    }
        //    return (ConnectionPool[currentThread] as IDbConnection);
        //}

        private void RemoveDisposedConnection()
        {
            ArrayList list = new ArrayList();
            foreach (Thread thread in ConnectionPool.Keys)
            {
                if (thread.IsAlive && (thread.ThreadState != ThreadState.Aborted))
                {
                    continue;
                }
                list.Add(ConnectionPool[thread]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Instance.FreeConnection(list[i] as IDbConnection);
            }
        }

        private void RemoveTransaction(IDbTransaction trans)
        {
            Thread key = null;
            foreach (Thread thread2 in this.TransactionHolder.Keys)
            {
                if (this.TransactionHolder[thread2] == trans)
                {
                    key = thread2;
                    break;
                }
            }
            if (key != null)
            {
                this.TransactionHolder.Remove(key);
            }
            this.TransactionRefCountHolder.Remove(trans);
        }

        public void RollbackTransaction()
        {
            IDbTransaction activeTransaction = this.ActiveTransaction;
            if (activeTransaction != null)
            {
                IDbConnection conn = activeTransaction.Connection;
                activeTransaction.Rollback();
                this.FreeConnection(conn);
                this.TransactionHolder.Remove(activeTransaction);
                this.RemoveTransaction(activeTransaction);
            }
        }
         public SqlTransaction ActiveTransaction
         {
             get
             {
                 return (this.TransactionHolder[Thread.CurrentThread] as SqlTransaction);
             }
         }

        //public IDbTransaction ActiveTransaction
        //{
        //    get
        //    {
        //        return (this.TransactionHolder[Thread.CurrentThread] as IDbTransaction);
        //    }
        //}

        internal Hashtable GetConnectionPooler
        {
            get
            {
                return ConnectionPool;
            }
        }
    }
    public class CommonData
    {
        private static ConnectionType connectionManagerType;
        //private static string connectionString;

        static CommonData()
        {
            //connectionString = "";
            connectionManagerType = ConnectionType.SqlServer;
        }

        public CommonData()
        {
        }

        public static ConnectionType ConnectionManagerType
        {
            get
            {
                //return connectionManagerType;
                return ConnectionType.SqlServer;
            }
            set
            {
                connectionManagerType = value;
            }
        }

        //public static string ConnectionString
        //{
        //    get
        //    {
        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
        //        return builder.ConnectionString;
        //    }
        //    set
        //    {
        //        connectionString = value;
        //    }
        //}

        private static string _connectionString;
        public static string ConnectionString
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

    }
}
