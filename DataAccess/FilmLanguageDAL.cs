using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class FilmLanguageDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspFilmLanguageInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldFilmLanguageID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldfk_LanguageID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
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
                UpdateCommand = new SqlCommand("PMspFilmLanguageUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldFilmLanguageID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldfk_LanguageID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
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
                DeleteCommand = new SqlCommand("PMspFilmLanguageDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(FilmDS.vFilmLanguageDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmLanguage", connection);

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
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        public void Delete(object id)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlCommand deleteCommand = GetDeleteCommand(connection);
                deleteCommand.Parameters[0].Value = long.Parse(id.ToString());

                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        public void GetAll(ref FilmDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmLanguage", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Fill(ds.vFilmLanguage);
            }
            catch (Exception ex)
            {
                //Set Error
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        public void GetByID(ref FilmDS ds, object id)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmLanguage WHERE fldfk_FilmID=" + long.Parse(id.ToString()), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmLanguage);
            }
            catch (Exception ex)
            {
                //Set Error
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        private void AddParameter(SqlParameterCollection sqlParams, string columnName, SqlDbType type)
        {
            string paramName = "@" + columnName;
            sqlParams.Add(new SqlParameter(paramName, type));
            sqlParams[paramName].SourceColumn = columnName;
        }
    }
}
