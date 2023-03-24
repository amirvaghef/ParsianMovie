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
    public class SingleDVDKindDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspDVDKindInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldDVDKindName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldDVDKindPrice", SqlDbType.Int);
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
                UpdateCommand = new SqlCommand("PMspDVDKindUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldDVDKindID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldDVDKindName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldDVDKindPrice", SqlDbType.Int);
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
                DeleteCommand = new SqlCommand("PMspDVDKindDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldDVDKindID", SqlDbType.SmallInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleDVDKindDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleDVDKind", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.vSingleDVDKind);
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

        public SingleDVDKindDS GetAll()
        {
            SingleDVDKindDS ds = new SingleDVDKindDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleDVDKind", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleDVDKind);
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
        public SingleDVDKindDS GetByID(object id)
        {
            SingleDVDKindDS ds = new SingleDVDKindDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleDVDKind WHERE fldDVDKindID=" + id, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleDVDKind);
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
