using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SingleFilmLanguageDAL
    {
        public SingleFilmLanguageDS.vFilmLanguageDataTable GetByFilter(SearchFilter sf, params AMDataColumn[] sortColumns)
        {
            SingleFilmLanguageDS ds = new SingleFilmLanguageDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(TranslateFilter(sf, sortColumns), connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vFilmLanguage);
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
            return ds.vFilmLanguage;
        }

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            IFilterTranslator ft = new SQLFilterTranslator(filter);
            ft.AddTableToJoin("vFilmLanguage");
            string fromClause = ft.GetFromClause(new SingleFilmLanguageDS().Relations);
            string whereClause = ft.GetWhereClause();
            string selectClause = ft.GetTableAlias("vFilmLanguage");
            if (selectClause != null && selectClause.Length > 0)
                selectClause += ".";
            selectClause += "*";
            selectClause = "DISTINCT " + selectClause;
            string orderByClause = ft.GetOrderByClause(ft.GetTableAlias("vFilmLanguage"), sortColumns);
            string selectStatement = "SELECT " + selectClause
                                        + " FROM " + fromClause
                                        + (whereClause.Length > 0 ? " WHERE " + whereClause : "")
                                        + (orderByClause.Length > 0 ? " ORDER BY " + orderByClause : "");
            return selectStatement;
        }
        #endregion
    }
}
