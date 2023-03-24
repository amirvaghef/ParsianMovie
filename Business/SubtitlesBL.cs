using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SubtitlesBL
    {
        public void Update(SingleSubtitlesDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                SingleSubtitlesDS copyOfDS = (SingleSubtitlesDS)ds.Copy();
                new SubtitlesDAL().Update(copyOfDS.vSingleSubtitles);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleSubtitlesDS.vSingleSubtitlesDataTable GetAll()
        {
            try
            {
                return new SubtitlesDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
