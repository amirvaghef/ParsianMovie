using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class FilmDetailBL
    {
        public void Update(ref FilmDS filmDS)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new FilmDetailDAL().Update(filmDS);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public void Delete(object id)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new FilmDetailDAL().Delete(id);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        //public void OnlyUpdate(ref FilmDS filmDS)
        //{
        //    try
        //    {
        //        ConnectionManager.Instance.BeginTransaction();

        //        new FilmDetailDAL().OnlyUpdate(filmDS);

        //        ConnectionManager.Instance.CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionManager.Instance.RollbackTransaction();
        //        throw;
        //    }
        //}

        public FilmDS GetByID(object id)
        {
            try
            {
                return new FilmDetailDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

    }
}
