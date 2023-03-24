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
    public class SinglePersonalDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspPersonalInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldFamily", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldMobilePhone", SqlDbType.Char);
                AddParameter(InsertCommand.Parameters, "fldTel", SqlDbType.Char);
                AddParameter(InsertCommand.Parameters, "fldAddress", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldPostalCode", SqlDbType.Char);
                AddParameter(InsertCommand.Parameters, "fldUsername", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldEmail", SqlDbType.VarChar);
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
                UpdateCommand = new SqlCommand("PMspPersonalUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldFamily", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldMobilePhone", SqlDbType.Char);
                AddParameter(UpdateCommand.Parameters, "fldTel", SqlDbType.Char);
                AddParameter(UpdateCommand.Parameters, "fldAddress", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldPostalCode", SqlDbType.Char);
                AddParameter(UpdateCommand.Parameters, "fldUsername", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldEmail", SqlDbType.VarChar);
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
                DeleteCommand = new SqlCommand("PMspPersonalDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldUsername", SqlDbType.NVarChar);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(SinglePersonalDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSinglePersonal", connection);

                sda.UpdateCommand = GetUpdateCommand(connection);
                sda.UpdateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.InsertCommand = GetInsertCommand(connection);
                sda.InsertCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.DeleteCommand = GetDeleteCommand(connection);
                sda.DeleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Update(ds.Tables["vSinglePersonal"]);
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
        public SinglePersonalDS GetAll()
        {
            SinglePersonalDS ds = new SinglePersonalDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT * FROM vSinglePersonal", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSinglePersonal);
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
        public SinglePersonalDS GetByID(object username)
        {
            SinglePersonalDS ds = new SinglePersonalDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSinglePersonal WHERE fldUsername='" + username + "'", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSinglePersonal);
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
        public SinglePersonalDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            SinglePersonalDS ds = new SinglePersonalDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSinglePersonal);
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
            string commandString = "SELECT DISTINCT * FROM vSinglePersonal";

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
            ft.AddTableToJoin("vSinglePersonal");
            string fromClause = ft.GetFromClause(new SingleFilmDS().Relations);
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
