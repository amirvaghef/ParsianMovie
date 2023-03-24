using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleRequestBL
    {
        public void Update(ref SingleRequestDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleRequestDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        #region Reterive Methods
        public SingleRequestDS GetAll()
        {
            try
            {
                return new SingleRequestDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleRequestDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleRequestDAL().GetByFilter(filter, sortColumns);
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
                return new SingleRequestDAL().CountByFilter(filter);
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
