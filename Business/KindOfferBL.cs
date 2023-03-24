using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class KindOfferBL
    {
        public void Update(ref SingleKindOfferDS.vSingleKindOfferDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new KindOfferDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleKindOfferDS.vSingleKindOfferDataTable GetAll()
        {
            try
            {
                return new KindOfferDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
