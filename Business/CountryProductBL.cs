using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class CountryProductBL
    {
        public void Update(ref SingleCountryProductDS.vSingleCountryProductDataTable dt)
        {
            try
            {
                ConnectionManager.Instance.BeginTransaction();

                new CountryProductDAL().Update(dt);

                ConnectionManager.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionManager.Instance.RollbackTransaction();
                throw;
            }
        }

        public SingleCountryProductDS.vSingleCountryProductDataTable GetAll()
        {
            try
            {
                return new CountryProductDAL().GetAll();
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }

    }
}
