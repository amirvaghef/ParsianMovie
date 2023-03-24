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
    public class SingleBuyDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspBuyInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldBuyID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldfk_PaymentWayID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_TransmissionKindID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_DVDKindID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldBuyDate", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(InsertCommand.Parameters, "fldReferenceNumber", SqlDbType.NVarChar);
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
                UpdateCommand = new SqlCommand("PMspBuyUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldBuyID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldfk_PaymentWayID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_TransmissionKindID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_DVDKindID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldBuyDate", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(UpdateCommand.Parameters, "fldReferenceNumber", SqlDbType.NVarChar);
            }
            return UpdateCommand;
        }
        #endregion

        #region Delete Command
        private SqlCommand DeleteCommand = null;
        private SqlCommand GetDeleteCommand(SqlConnection connection)
        {
            if (DeleteCommand == null)
            {
                DeleteCommand = new SqlCommand("PMspBuyDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldBuyID", SqlDbType.UniqueIdentifier);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleBuyDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleBuy", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.Tables["vSingleBuy"]);
            }
            catch (Exception ex)
            {
                //SetError
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        #region Reterive Methods
        public SingleBuyDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            SingleBuyDS ds = new SingleBuyDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleBuy);
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
        public int CountByFilter(SearchFilter filter)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateCountFilter(filter);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                return (int)sda.SelectCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //Set Error
                return -1;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }
        #endregion

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            string commandString = "SELECT * FROM vSingleBuy";

            IFilterTranslator ft = new SQLFilterTranslator(filter);
            string whereClause = ft.GetWhereClause();
            string orderByClause = ft.GetOrderByClause("", sortColumns);
            string selectStatement = commandString
                                        + (whereClause.Length > 0 ? " WHERE " + whereClause : "")
                                        + (orderByClause.Length > 0 ? " ORDER BY " + orderByClause : "");
            return selectStatement;
        }
        private string TranslateCountFilter(SearchFilter filter)
        {
            IFilterTranslator ft = new SQLFilterTranslator(filter);
            ft.AddTableToJoin("vSingleBuy");
            string fromClause = ft.GetFromClause(new SingleBuyDS().Relations);
            string whereClause = ft.GetWhereClause();
            string selectClause = "COUNT(*) ";
            string selectStatement = "SELECT " + selectClause
                + " FROM " + fromClause
                + (whereClause.Length > 0 ? " WHERE " + whereClause : "");

            return selectStatement;
        }
        private void AddParameter(SqlParameterCollection sqlParams, string columnName, SqlDbType type)
        {
            string paramName = "@" + columnName;
            sqlParams.Add(new SqlParameter(paramName, type));
            sqlParams[paramName].SourceColumn = columnName;
        }
        #endregion
    }
}
