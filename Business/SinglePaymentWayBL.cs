using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SinglePaymentWayBL
    {
        public void Update(ref SinglePaymentWayDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SinglePaymentWayDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SinglePaymentWayDS GetAll()
        {
            try
            {
                return new SinglePaymentWayDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SinglePaymentWayDS GetByID(object id)
        {
            try
            {
                return new SinglePaymentWayDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
