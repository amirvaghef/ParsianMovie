using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleTransmissionKindBL
    {
        public void Update(ref SingleTransmissionKindDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleTransmissionKindDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleTransmissionKindDS GetAll()
        {
            try
            {
                return new SingleTransmissionKindDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleTransmissionKindDS GetByID(object id)
        {
            try
            {
                return new SingleTransmissionKindDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
