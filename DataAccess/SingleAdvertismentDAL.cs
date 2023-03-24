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
    public class SingleAdvertismentDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspAdvertismentsInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldCode", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldStartDate", SqlDbType.DateTime);
                AddParameter(InsertCommand.Parameters, "fldEndDate", SqlDbType.DateTime);
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
                UpdateCommand = new SqlCommand("PMspAdvertismentsUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldAdvertismentsID", SqlDbType.BigInt);
                AddParameter(UpdateCommand.Parameters, "fldName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldCode", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldStartDate", SqlDbType.DateTime);
                AddParameter(UpdateCommand.Parameters, "fldEndDate", SqlDbType.DateTime);
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
                DeleteCommand = new SqlCommand("PMspAdvertismentsDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldAdvertismentsID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SingleAdvertismentsDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleAdverisments", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.Tables["vSingleAdverisments"]);
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
        public SingleAdvertismentsDS GetAll()
        {
            SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleAdverisments", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleAdverisments);
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
        public SingleAdvertismentsDS GetAll(int index, int size)
        {
            SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSingleAdverisments", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vSingleAdverisments");
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
        public SingleAdvertismentsDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleAdverisments);
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
        public SingleAdvertismentsDS GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vSingleAdverisments");
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
        public int CountAll()
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = "SELECT COUNT(*) FROM vSingleAdverisments";

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
            string commandString = "SELECT * FROM vSingleAdverisments";

            IFilterTranslator ft = new SQLFilterTranslator(filter);
            string whereClause = ft.GetWhereClause();
            string orderByClause = ft.GetOrderByClause("", sortColumns);
            string selectStatement = commandString
                                        + (whereClause.Length > 0 ? " WHERE " + whereClause : "")
                                        + (orderByClause.Length > 0 ? " ORDER BY " + orderByClause + " DESC" : "");
            return selectStatement;
        }
        private string TranslateCountFilter(SearchFilter filter)
        {
            IFilterTranslator ft = new SQLFilterTranslator(filter);
            ft.AddTableToJoin("vSingleAdverisments");
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
