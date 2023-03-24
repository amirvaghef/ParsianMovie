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
    public class RequestDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspRequestInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldRequestID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
                AddParameter(InsertCommand.Parameters, "fldfk_Username", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldfk_BuyID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(InsertCommand.Parameters, "fldRequestDate", SqlDbType.NVarChar);
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
                UpdateCommand = new SqlCommand("PMspRequestUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldRequestID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_Username", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldfk_BuyID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(UpdateCommand.Parameters, "fldRequestDate", SqlDbType.NVarChar);
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
                DeleteCommand = new SqlCommand("PMspRequestDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldRequestID", SqlDbType.UniqueIdentifier);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(RequestDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vRequest", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.Tables["vRequest"]);
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

        #region Retrive Methods
        public RequestDS.vRequestDataTable GetAll()
        {
            RequestDS ds = new RequestDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vRequest", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vRequest);
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
            return ds.vRequest;
        }
        public RequestDS.vRequestDataTable GetAll(int index, int size)
        {
            RequestDS ds = new RequestDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vRequest", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vRequest");
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
            return ds.vRequest;
        }
        public RequestDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            RequestDS ds = new RequestDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vRequest);
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
        public RequestDS.vRequestDataTable GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            RequestDS ds = new RequestDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vRequest");
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
            return ds.vRequest;
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
        public int CountAll()
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = "SELECT COUNT(*) FROM vRequest";

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
            string commandString = "SELECT * FROM vRequest";

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
            ft.AddTableToJoin("vRequest");
            string fromClause = ft.GetFromClause(new RequestDS().Relations);
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
