using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SingleFilmGenreDAL
    {
        public SingleFilmGenreDS.vFilmGenreDataTable GetByFilter(SearchFilter sf, params AMDataColumn[] sortColumns)
        {
            SingleFilmGenreDS ds = new SingleFilmGenreDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(TranslateFilter(sf, sortColumns), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmGenre);
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
            return ds.vFilmGenre;
        }

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            IFilterTranslator ft = new SQLFilterTranslator(filter);
            ft.AddTableToJoin("vFilmGenre");
            string fromClause = ft.GetFromClause(new SingleFilmGenreDS().Relations);
            string whereClause = ft.GetWhereClause();
            string selectClause = ft.GetTableAlias("vFilmGenre");
            if (selectClause != null && selectClause.Length > 0)
                selectClause += ".";
            selectClause += "*";
            selectClause = "DISTINCT " + selectClause;
            string orderByClause = ft.GetOrderByClause(ft.GetTableAlias("vFilmGenre"), sortColumns);
            string selectStatement = "SELECT " + selectClause
                                        + " FROM " + fromClause
                                        + (whereClause.Length > 0 ? " WHERE " + whereClause : "")
                                        + (orderByClause.Length > 0 ? " ORDER BY " + orderByClause : "");
            return selectStatement;
        }
        #endregion
    }
}
