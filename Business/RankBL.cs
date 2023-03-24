using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class RankBL
    {
        public void Update(ref SingleRankDS.vSingleRankDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new RankDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleRankDS.vSingleRankDataTable GetAll()
        {
            try
            {
                return new RankDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
