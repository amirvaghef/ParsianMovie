using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleFilmBL
    {
        public void Update(ref SingleFilmDS.vSingleFilmDataTable filmDS)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleFilmDAL().Update(filmDS);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        #region Reterive Methods
        public SingleFilmDS.vSingleFilmDataTable GetAll()
        {
            try
            {
                return new SingleFilmDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleFilmDS.vSingleFilmDataTable GetAll(int index, int size)
        {
            try
            {
                return new SingleFilmDAL().GetAll(index,size);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

        public SingleFilmDS.vSingleFilmDataTable GetByFilter(SearchFilter filter, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleFilmDAL().GetByFilter(filter,sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleFilmDS.vSingleFilmDataTable GetByFilter(SearchFilter filter, int index, int size, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleFilmDAL().GetByFilter(filter, index, size, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

        public SingleFilmDS.vSingleFilmDataTable GetByID(object id)
        {
            try
            {
                return new SingleFilmDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

        public SingleFilmDS.vSingleFilmDataTable GetTopRate(int top)
        {
            try
            {
                return new SingleFilmDAL().GetTopRate(top);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        #endregion

        public int CountByFilter(SearchFilter filter)
        {
            try
            {
                return new SingleFilmDAL().CountByFilter(filter);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

        public int CountAll()
        {
            try
            {
                return new SingleFilmDAL().CountAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
