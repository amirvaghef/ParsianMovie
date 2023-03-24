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
    public class SingleTransmissionKindDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspTransmissionKindInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldTransmissionKindName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldTransmissionKindPrice", SqlDbType.Int);
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
                UpdateCommand = new SqlCommand("PMspTransmissionKindUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldTransmissionKindID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldTransmissionKindName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldTransmissionKindPrice", SqlDbType.Int);
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
                DeleteCommand = new SqlCommand("PMspTransmissionKindDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldTransmissionKindID", SqlDbType.SmallInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleTransmissionKindDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleTransmissionKind", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.vSingleTransmissionKind);
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

        public SingleTransmissionKindDS GetAll()
        {
            SingleTransmissionKindDS ds = new SingleTransmissionKindDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleTransmissionKind", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleTransmissionKind);
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
        public SingleTransmissionKindDS GetByID(object id)
        {
            SingleTransmissionKindDS ds = new SingleTransmissionKindDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleTransmissionKind WHERE fldTransmissionKindID=" + id, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleTransmissionKind);
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
