using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleFAQBL
    {
        public void Update(ref SingleFAQDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleFAQDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleFAQDS GetAll()
        {
            try
            {
                return new SingleFAQDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleFAQDS GetByID(object id)
        {
            try
            {
                return new SingleFAQDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
