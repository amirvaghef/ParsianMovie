using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SingleFilmSubtitlesDAL
    {
        public SingleFilmSubtitlesDS.vFilmSubtitlesDataTable GetByFilter(SearchFilter sf, params AMDataColumn[] sortColumns)
        {
            SingleFilmSubtitlesDS ds = new SingleFilmSubtitlesDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(TranslateFilter(sf, sortColumns), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmSubtitles);
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
            return ds.vFilmSubtitles;
        }

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            IFilterTranslator ft = new SQLFilterTranslator(filter);
            ft.AddTableToJoin("vFilmSubtitles");
            string fromClause = ft.GetFromClause(new SingleFilmSubtitlesDS().Relations);
            string whereClause = ft.GetWhereClause();
            string selectClause = ft.GetTableAlias("vFilmSubtitles");
            if (selectClause != null && selectClause.Length > 0)
                selectClause += ".";
            selectClause += "*";
            selectClause = "DISTINCT " + selectClause;
            string orderByClause = ft.GetOrderByClause(ft.GetTableAlias("vFilmSubtitles"), sortColumns);
            string selectStatement = "SELECT " + selectClause
                                        + " FROM " + fromClause
                                        + (whereClause.Length > 0 ? " WHERE " + whereClause : "")
                                        + (orderByClause.Length > 0 ? " ORDER BY " + orderByClause : "");
            return selectStatement;
        }
        #endregion
    }
}
