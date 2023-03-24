using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleBuyBL
    {
        public void Update(ref SingleBuyDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleBuyDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleBuyDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleBuyDAL().GetByFilter(filter, sortColumns);
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
                return new SingleBuyDAL().CountByFilter(filter);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
