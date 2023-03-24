using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class LanguageBL
    {
        public void Update(ref SingleLanguageDS.vSingleLanguageDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new LanguageDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleLanguageDS.vSingleLanguageDataTable GetAll()
        {
            try
            {
                return new LanguageDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
