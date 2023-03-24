using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleFilmLanguageBL
    {
        public SingleFilmLanguageDS.vFilmLanguageDataTable GetByFilter(SearchFilter sf, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleFilmLanguageDAL().GetByFilter(sf, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
