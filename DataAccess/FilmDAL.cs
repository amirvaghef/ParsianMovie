using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class FilmDAL
    {
        #region Insert Command
        private SqlCommand InsertCommand = null;
        private SqlCommand GetInsertCommand(SqlConnection connection)
        {
            if (InsertCommand == null)
            {
                InsertCommand = new SqlCommand("PMspFilmInsert", connection, ConnectionManager.Instance.ActiveTransaction);
                InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(InsertCommand.Parameters, "fldFilmID", SqlDbType.BigInt);
                AddParameter(InsertCommand.Parameters, "fldFarsiName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldEnglishName", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldActors", SqlDbType.VarChar);
                AddParameter(InsertCommand.Parameters, "fldDirector", SqlDbType.VarChar);
                AddParameter(InsertCommand.Parameters, "fldYearsOfProduct", SqlDbType.Char);
                AddParameter(InsertCommand.Parameters, "fldIMDBRating", SqlDbType.Float);
                AddParameter(InsertCommand.Parameters, "fldPoster", SqlDbType.VarChar);
                AddParameter(InsertCommand.Parameters, "fldAbstract", SqlDbType.NVarChar);
                AddParameter(InsertCommand.Parameters, "fldInformation", SqlDbType.VarChar);
                AddParameter(InsertCommand.Parameters, "fldSumVotes", SqlDbType.Int);
                AddParameter(InsertCommand.Parameters, "fldCountVotes", SqlDbType.Int);
                AddParameter(InsertCommand.Parameters, "fldSection", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldTime", SqlDbType.VarChar);
                AddParameter(InsertCommand.Parameters, "fldfk_KindOfferID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_CountryProductID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_QualityID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldfk_RankID", SqlDbType.SmallInt);
                AddParameter(InsertCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(InsertCommand.Parameters, "fldComment", SqlDbType.NVarChar);

                InsertCommand.Parameters["@fldFilmID"].Direction = ParameterDirection.Output;
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
                UpdateCommand = new SqlCommand("PMspFilmUpdate", connection, ConnectionManager.Instance.ActiveTransaction);
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(UpdateCommand.Parameters, "fldFilmID", SqlDbType.BigInt);
                AddParameter(UpdateCommand.Parameters, "fldFarsiName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldEnglishName", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldActors", SqlDbType.VarChar);
                AddParameter(UpdateCommand.Parameters, "fldDirector", SqlDbType.VarChar);
                AddParameter(UpdateCommand.Parameters, "fldYearsOfProduct", SqlDbType.Char);
                AddParameter(UpdateCommand.Parameters, "fldIMDBRating", SqlDbType.Float);
                AddParameter(UpdateCommand.Parameters, "fldPoster", SqlDbType.VarChar);
                AddParameter(UpdateCommand.Parameters, "fldAbstract", SqlDbType.NVarChar);
                AddParameter(UpdateCommand.Parameters, "fldInformation", SqlDbType.VarChar);
                AddParameter(UpdateCommand.Parameters, "fldSumVotes", SqlDbType.Int);
                AddParameter(UpdateCommand.Parameters, "fldCountVotes", SqlDbType.Int);
                AddParameter(UpdateCommand.Parameters, "fldSection", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldTime", SqlDbType.VarChar);
                AddParameter(UpdateCommand.Parameters, "fldfk_KindOfferID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_CountryProductID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_QualityID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldfk_RankID", SqlDbType.SmallInt);
                AddParameter(UpdateCommand.Parameters, "fldPrice", SqlDbType.Int);
                AddParameter(UpdateCommand.Parameters, "fldComment", SqlDbType.NVarChar);
            }
            return UpdateCommand;
        }
        #endregion

        #region Delete Command
        private SqlCommand DeleteCommand=null;
        private SqlCommand GetDeleteCommand(SqlConnection connection)
        {
            if (DeleteCommand == null)
            {
                DeleteCommand = new SqlCommand("PMspFilmDelete", connection, ConnectionManager.Instance.ActiveTransaction);
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                AddParameter(DeleteCommand.Parameters, "fldFilmID", SqlDbType.BigInt);
            }
            return DeleteCommand;
        }
        #endregion

        public void Update(FilmDS.vFilmDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilm", connection);

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

        //public void OnlyUpdate(FilmDS.vFilmDataTable dt)
        //{
        //    SqlConnection connection = ConnectionManager.Instance.GetConnection();
        //    try
        //    {
        //        SqlCommand updateCommand = GetUpdateCommand(connection);
        //        updateCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

        //        if (dt.Rows[0][dt.fldFilmIDColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldFilmIDColumn.ColumnName].Value = dt.Rows[0][dt.fldFilmIDColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldAbstractColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldAbstractColumn.ColumnName].Value = dt.Rows[0][dt.fldAbstractColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldActorsColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldActorsColumn.ColumnName].Value = dt.Rows[0][dt.fldActorsColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldCommentColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldCommentColumn.ColumnName].Value = dt.Rows[0][dt.fldCommentColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldCountVotesColumn.ColumnName] != DBNull.Value)
        //            updateCommand.Parameters["@" + dt.fldCountVotesColumn.ColumnName].Value = dt.Rows[0][dt.fldCountVotesColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldDirectorColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldDirectorColumn.ColumnName].Value = dt.Rows[0][dt.fldDirectorColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldEnglishNameColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldEnglishNameColumn.ColumnName].Value = dt.Rows[0][dt.fldEnglishNameColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldFarsiNameColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldFarsiNameColumn.ColumnName].Value = dt.Rows[0][dt.fldFarsiNameColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldfk_CountryProductIDColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldfk_CountryProductIDColumn.ColumnName].Value = dt.Rows[0][dt.fldfk_CountryProductIDColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldfk_KindOfferIDColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldfk_KindOfferIDColumn.ColumnName].Value = dt.Rows[0][dt.fldfk_KindOfferIDColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldfk_QualityIDColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldfk_QualityIDColumn.ColumnName].Value = dt.Rows[0][dt.fldfk_QualityIDColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldfk_RankIDColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldfk_RankIDColumn.ColumnName].Value = dt.Rows[0][dt.fldfk_RankIDColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldIMDBRatingColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldIMDBRatingColumn.ColumnName].Value = dt.Rows[0][dt.fldIMDBRatingColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldInformationColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldInformationColumn.ColumnName].Value = dt.Rows[0][dt.fldInformationColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldPosterColumn.ColumnName] != DBNull.Value)
        //            updateCommand.Parameters["@" + dt.fldPosterColumn.ColumnName].Value = dt.Rows[0][dt.fldPosterColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldPosterExtensionColumn.ColumnName].ToString() != String.Empty)
        //            updateCommand.Parameters["@" + dt.fldPosterExtensionColumn.ColumnName].Value = dt.Rows[0][dt.fldPosterExtensionColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldPriceColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldPriceColumn.ColumnName].Value = dt.Rows[0][dt.fldPriceColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldSectionColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldSectionColumn.ColumnName].Value = dt.Rows[0][dt.fldSectionColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldSumVotesColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldSumVotesColumn.ColumnName].Value = dt.Rows[0][dt.fldSumVotesColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldTimeColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldTimeColumn.ColumnName].Value = dt.Rows[0][dt.fldTimeColumn.ColumnName];
        //        if (dt.Rows[0][dt.fldYearsOfProductColumn.ColumnName] != null)
        //            updateCommand.Parameters["@" + dt.fldYearsOfProductColumn.ColumnName].Value = dt.Rows[0][dt.fldYearsOfProductColumn.ColumnName];

        //        updateCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //SetError
        //        throw;
        //    }
        //    finally
        //    {
        //        ConnectionManager.Instance.FreeConnection(connection);
        //    }
        //}

        #region Reterive
        public void GetAll(ref FilmDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilm", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;

                sda.Fill(ds.vFilm);
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vFilm WHERE fldFilmID=" + long.Parse(id.ToString()), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilm);
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
        #endregion

        private void AddParameter(SqlParameterCollection sqlParams, string columnName, SqlDbType type)
        {
            string paramName = "@" + columnName;
            sqlParams.Add(new SqlParameter(paramName, type));
            sqlParams[paramName].SourceColumn = columnName;
        }
    }
}
