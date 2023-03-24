using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class FilmSubtitlesDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspFilmSubtitlesInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldFilmSubtitlesID", SqlDbType.UniqueIdentifier);
                AddParameter(InsertCommand.Parameters, "fldfk_SubtitlesID", SqlDbType.SmallInt);
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
                UpdateCommand = new SqlCommand("PMspFilmSubtitlesUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldFilmSubtitlesID", SqlDbType.UniqueIdentifier);
                AddParameter(UpdateCommand.Parameters, "fldfk_SubtitlesID", SqlDbType.SmallInt);
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
                DeleteCommand = new SqlCommand("PMspFilmSubtitlesDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldfk_FilmID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(FilmDS.vFilmSubtitlesDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmSubtitles", connection);

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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmSubtitles", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Fill(ds.vFilmSubtitles);
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilmSubtitles WHERE fldfk_FilmID=" + long.Parse(id.ToString()), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmSubtitles);
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
