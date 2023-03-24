using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleDVDKindBL
    {
        public void Update(ref SingleDVDKindDS ds)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new SingleDVDKindDAL().Update(ds);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleDVDKindDS GetAll()
        {
            try
            {
                return new SingleDVDKindDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
        public SingleDVDKindDS GetByID(object id)
        {
            try
            {
                return new SingleDVDKindDAL().GetByID(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
