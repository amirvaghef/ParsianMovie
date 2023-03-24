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
    public class SinglePaymentWayDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspPaymentWayInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldPaymentWayName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldPaymentWayPage", SqlDbType.VarChar);
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
                UpdateCommand = new SqlCommand("PMspPaymentWayUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldPaymentWayID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldPaymentWayName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldPaymentWayPage", SqlDbType.VarChar);
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
                DeleteCommand = new SqlCommand("PMspPaymentWayDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldPaymentWayID", SqlDbType.SmallInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SinglePaymentWayDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSinglePaymentWay", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.vSinglePaymentWay);
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

        public SinglePaymentWayDS GetAll()
        {
            SinglePaymentWayDS ds = new SinglePaymentWayDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSinglePaymentWay", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSinglePaymentWay);
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
        public SinglePaymentWayDS GetByID(object id)
        {
            SinglePaymentWayDS ds = new SinglePaymentWayDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSinglePaymentWay WHERE fldPaymentWayID=" + id, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSinglePaymentWay);
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
