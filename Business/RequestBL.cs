using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class RequestBL
    {
        public void Update(ref RequestDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new RequestDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        #region Reterive Methods
        public RequestDS.vRequestDataTable GetAll()
        {
            try
            {
                return new RequestDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestDS.vRequestDataTable GetAll(int index, int size)
        {
            try
            {
                return new RequestDAL().GetAll(index, size);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new RequestDAL().GetByFilter(filter, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public RequestDS.vRequestDataTable GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new RequestDAL().GetByFilter(filter, index, size, sortColumns);
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
                return new RequestDAL().CountByFilter(filter);
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
                return new RequestDAL().CountAll();
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
