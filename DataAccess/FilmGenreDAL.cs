using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class FilmGenreDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspFilmGenreInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldFilmGenreID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldfk_GenreID", SqlDbType.SmallInt);
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
                UpdateCommand = new SqlCommand("PMspFilmGenreUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldFilmGenreID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldfk_GenreID", SqlDbType.SmallInt);
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
                DeleteCommand = new SqlCommand("PMspFilmGenreDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        } 
        #endregion

        public void Update(FilmDS.vFilmGenreDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmGenre", connection);

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
                deleteCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmGenre",connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Fill(ds.vFilmGenre);
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmGenre WHERE fldfk_FilmID=" + long.Parse(id.ToString()), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmGenre);
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
