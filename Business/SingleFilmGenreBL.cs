using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Data;
using DataAccess;

namespace Business
{
    public class SingleFilmGenreBL
    {
        public SingleFilmGenreDS.vFilmGenreDataTable GetByFilter(SearchFilter sf, params AMDataColumn[] sortColumns)
        {
            try
            {
                return new SingleFilmGenreDAL().GetByFilter(sf, sortColumns);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
        }
    }
}
