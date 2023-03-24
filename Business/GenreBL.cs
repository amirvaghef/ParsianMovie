using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class GenreBL
    {
        public void Update(ref SingleGenreDS.vSingleGenreDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new GenreDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleGenreDS.vSingleGenreDataTable GetAll()
        {
            try
            {
                return new GenreDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
