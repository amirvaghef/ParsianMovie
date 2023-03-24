using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class QualityBL
    {
        public void Update(ref SingleQualityDS.vSingleQualityDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new QualityDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleQualityDS.vSingleQualityDataTable GetAll()
        {
            try
            {
                return new QualityDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
