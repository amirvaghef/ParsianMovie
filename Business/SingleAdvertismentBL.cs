using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleAdvertismentBL
    {
        public void Update(ref SingleAdvertismentsDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleAdvertismentDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        #region Reterive Methods
        public SingleAdvertismentsDS GetAll()
        {
            try
            {
                return new SingleAdvertismentDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleAdvertismentsDS GetAll(int index, int size)
        {
            try
            {
                return new SingleAdvertismentDAL().GetAll(index, size);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleAdvertismentsDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleAdvertismentDAL().GetByFilter(filter, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleAdvertismentsDS GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleAdvertismentDAL().GetByFilter(filter, index, size, sortColumns);
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
                return new SingleAdvertismentDAL().CountByFilter(filter);
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
                return new SingleAdvertismentDAL().CountAll();
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
