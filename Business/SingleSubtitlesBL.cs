using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleSubtitlesBL
    {
        public void Update(ref SingleSubtitlesDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleSubtitlesDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleSubtitlesDS GetAll()
        {
            try
            {
                return new SingleSubtitlesDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
