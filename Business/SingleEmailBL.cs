using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleEmailBL
    {
        public void Update(ref SingleEmailDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleEmailDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleEmailDS GetAll()
        {
            try
            {
                return new SingleEmailDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleEmailDS GetByID(object id)
        {
            try
            {
                return new SingleEmailDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
