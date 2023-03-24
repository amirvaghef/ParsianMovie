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
    public class SingleFilmDAL
    {
        #region Retrive Methods
  /*      public SingleFilmDS GetAllExcel()
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldAbstract, fldInformation, " +
                      "fldSection, fldTime, " +
                      "fldKindOfferName, fldCountryProductName, " +
                      "fldQualityName, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm ORDER BY fldFilmID DESC", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFilm);
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
        }*/
        public SingleFilmDS.vSingleFilmDataTable GetAll()
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldPoster, fldAbstract, fldInformation, " +
                      "fldSumVotes, fldCountVotes, fldSection, fldTime, " +
                      "fldfk_KindOfferID, fldKindOfferName, fldfk_CountryProductID, fldCountryProductName, " +
                      "fldfk_QualityID, fldQualityName, fldfk_RankID, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm ORDER BY fldFilmID DESC", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFilm);
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
            return ds.vSingleFilm;
        }
        public SingleFilmDS.vSingleFilmDataTable GetAll(int index, int size)
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldPoster, fldAbstract, fldInformation, " +
                      "fldSumVotes, fldCountVotes, fldSection, fldTime, " +
                      "fldfk_KindOfferID, fldKindOfferName, fldfk_CountryProductID, fldCountryProductName, " +
                      "fldfk_QualityID, fldQualityName, fldfk_RankID, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm ORDER BY fldFilmID DESC", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vSingleFilm");
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
            return ds.vSingleFilm;
        }
        public SingleFilmDS.vSingleFilmDataTable GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFilm);
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
            return ds.vSingleFilm;
        }
        public SingleFilmDS.vSingleFilmDataTable GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds, index, size, "vSingleFilm");
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
            return ds.vSingleFilm;
        }
        public SingleFilmDS.vSingleFilmDataTable GetByID(object id)
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldPoster, fldAbstract, fldInformation, " +
                      "fldSumVotes, fldCountVotes, fldSection, fldTime, " +
                      "fldfk_KindOfferID, fldKindOfferName, fldfk_CountryProductID, fldCountryProductName, " +
                      "fldfk_QualityID, fldQualityName, fldfk_RankID, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm WHERE fldFilmID=" + long.Parse(id.ToString()), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFilm);
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
            return ds.vSingleFilm;
        }
        public SingleFilmDS.vSingleFilmDataTable GetTopRate(int top)
        {
            SingleFilmDS ds = new SingleFilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT TOP(" + top +") fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldPoster, fldAbstract, fldInformation, " +
                      "fldSumVotes, fldCountVotes, ISNULL((fldSumVotes/NULLIF(fldCountVotes,0)),0) AS Rate, fldSection, fldTime, " +
                      "fldfk_KindOfferID, fldKindOfferName, fldfk_CountryProductID, fldCountryProductName, " +
                      "fldfk_QualityID, fldQualityName, fldfk_RankID, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm ORDER BY Rate DESC", connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vSingleFilm);
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
            return ds.vSingleFilm;
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
                string selectStatement = "SELECT COUNT(DISTINCT fldFilmID) FROM vSingleFilm";

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
        private SqlCommand DeleteCommand = null;
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

        public void Update(SingleFilmDS.vSingleFilmDataTable dt)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vSingleFilm", connection);

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

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
		{
            string commandString = "SELECT DISTINCT fldFilmID, fldFarsiName, fldEnglishName, fldActors, fldDirector, " +
                      "fldYearsOfProduct, fldIMDBRating, fldPoster, fldAbstract, fldInformation, " +
                      "fldSumVotes, fldCountVotes, fldSection, fldTime, " +
                      "fldfk_KindOfferID, fldKindOfferName, fldfk_CountryProductID, fldCountryProductName, " +
                      "fldfk_QualityID, fldQualityName, fldfk_RankID, fldRankName, fldPrice, " +
                      "fldComment FROM vSingleFilm";

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
            ft.AddTableToJoin("vSingleFilm");
            string fromClause = ft.GetFromClause(new SingleFilmDS().Relations);
            string whereClause = ft.GetWhereClause();
            string selectClause = "COUNT(DISTINCT fldFilmID) ";
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
