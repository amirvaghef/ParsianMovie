using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;


namespace Business
{
    public class SinglePersonalBL
    {
        public void Update(ref SinglePersonalDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SinglePersonalDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        #region Reterive Methods
        public SinglePersonalDS GetAll()
        {
            try
            {
                return new SinglePersonalDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SinglePersonalDS GetByID(object username)
        {
            try
            {
                return new SinglePersonalDAL().GetByID(username);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SinglePersonalDS GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SinglePersonalDAL().GetByFilter(filter, sortColumns);
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
                return new SinglePersonalDAL().CountByFilter(filter);
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
