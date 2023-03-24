using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class RankDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspRankInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldRankName", SqlDbType.NVarChar);
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
                UpdateCommand = new SqlCommand("PMspRankUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldRankID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldRankName", SqlDbType.NVarChar);
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
                DeleteCommand = new SqlCommand("PMspRankDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldRankID", SqlDbType.SmallInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleRankDS.vSingleRankDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleRank", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(dt);
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

        public SingleRankDS.vSingleRankDataTable GetAll()
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            SingleRankDS ds = new SingleRankDS();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleRank", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Fill(ds.vSingleRank);
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
            return ds.vSingleRank;
        }

        private void AddParameter(SqlParameterCollection sqlParams, string columnName, SqlDbType type)
        {
            string paramName = "@" + columnName;
            sqlParams.Add(new SqlParameter(paramName, type));
            sqlParams[paramName].SourceColumn = columnName;
        }
    }
}
