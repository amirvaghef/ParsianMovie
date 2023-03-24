using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common;

namespace DataAccess
{
    public class BuyDetailDAL
    {
        public void Update(SingleBuyDS singleBuyDS, RequestDS requestDS)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                new SingleBuyDAL().Update(singleBuyDS);
                new RequestDAL().Update(requestDS);
            }
            catch (SqlException ex)
            {
                //Set Error
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        #region Reterive Methods
        public BuyDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            BuyDS ds = new BuyDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                string selectStatement = TranslateFilter(filter, sortColumns);

                SqlDataAdapter sda = new SqlDataAdapter(selectStatement, connection);
                sda.SelectCommand.Transaction = ConnectionManager.Instance.ActiveTransaction;
                sda.Fill(ds.vBuy);
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
        #endregion

        #region Helper Methods
        private string TranslateFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            string commandString = "SELECT * FROM vBuy";

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
            ft.AddTableToJoin("vBuy");
            string fromClause = ft.GetFromClause(new SingleBuyDS().Relations);
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
