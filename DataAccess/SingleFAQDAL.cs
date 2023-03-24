using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DataAccess
{
    public class SingleFAQDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspFAQInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldFAQQuestion", SqlDbType.NText);
                AddParameter(InsertCommand.Parameters, "fldFAQAnswer", SqlDbType.NText);
            }
            return InsertCommand;
        }
        #endregion

        #region Update Command
        private SqlCommand UpdateCommand = null;
        private SqlCommand GetUpdateCommand(SqlConnection connection)
        {
            if (UpdateCommand == null)
            {
                UpdateCommand = new SqlCommand("PMspFAQUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldFAQID", SqlDbType.BigInt);
                AddParameter(UpdateCommand.Parameters, "fldFAQQuestion", SqlDbType.NText);
                AddParameter(UpdateCommand.Parameters, "fldFAQAnswer", SqlDbType.NText);
            }
            return UpdateCommand;
        }
        #endregion

        #region Insert Command
        private SqlCommand DeleteCommand = null;
        private SqlCommand GetDeleteCommand(SqlConnection connection)
        {
            if (DeleteCommand == null)
            {
                DeleteCommand = new SqlCommand("PMspFAQDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldFAQID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleFAQDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleFAQ", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.vSingleFAQ);
            }
            catch (Exception ex)
            {
                //SetError
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        public SingleFAQDS GetAll()
        {
            SingleFAQDS ds = new SingleFAQDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleFAQ", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFAQ);
            }
            catch (Exception ex)
            {
                //Set Error
                return null;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
            return ds;
        }
        public SingleFAQDS GetByID(object id)
        {
            SingleFAQDS ds = new SingleFAQDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleFAQ WHERE fldFAQID=" + id, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFAQ);
            }
            catch (Exception ex)
            {
                //Set Error
                return null;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
            return ds;
        }

        private void AddParameter(SqlParameterCollection sqlParams, string columnName, SqlDbType type)
        {
            string paramName = "@" + columnName;
            sqlParams.Add(new SqlParameter(paramName, type));
            sqlParams[paramName].SourceColumn = columnName;
        }
    }
}
