using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class BuyDetailBL
    {
        public void Update(ref SingleBuyDS singleBuyDS, ref RequestDS requestDS)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new BuyDetailDAL().Update(singleBuyDS,requestDS);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public BuyDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new BuyDetailDAL().GetByFilter(filter, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
