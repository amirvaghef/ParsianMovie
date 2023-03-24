using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class RequestBuyBL
    {
        #region Reterive Methods
        public RequestBuyDS.vRequestBuyDataTable GetAll()
        {
            try
            {
                return new RequestBuyDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestBuyDS.vRequestBuyDataTable GetTopBuy(int top)
        {
            try
            {
                return new RequestBuyDAL().GetTopBuy(top);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestBuyDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new RequestBuyDAL().GetByFilter(filter, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestBuyDS.vRequestBuyDataTable GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new RequestBuyDAL().GetByFilter(filter, index, size, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public int CountByFilter(SearchFilter filter)
        {
            try
            {
                return new RequestBuyDAL().CountByFilter(filter);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

        public int CountAll()
        {
            try
            {
                return new RequestBuyDAL().CountAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        #endregion
    }
}
