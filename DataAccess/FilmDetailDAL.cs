using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common;

namespace DataAccess
{
    public class FilmDetailDAL
    {
        public void Update(FilmDS ds)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                new FilmDAL().Update(ds.vFilm);

                if(ds.Tables["vFilmGenre"].Rows.Count != 0)
                    foreach(FilmDS.vFilmGenreRow row in ds.Tables["vFilmGenre"].Rows)
                        if(row.RowState != DataRowState.Deleted)
                            row["fldfk_FilmID"] = ds.Tables["vFilm"].Rows[0]["fldFilmID"];
                new FilmGenreDAL().Update(ds.vFilmGenre);

                if(ds.Tables["vFilmLanguage"].Rows.Count != 0)
                    foreach (FilmDS.vFilmLanguageRow row in ds.Tables["vFilmLanguage"].Rows)
                        if(row.RowState != DataRowState.Deleted)
                            row["fldfk_FilmID"] = ds.Tables["vFilm"].Rows[0]["fldFilmID"];
                new FilmLanguageDAL().Update(ds.vFilmLanguage);

                if (ds.Tables["vFilmSubtitles"].Rows.Count != 0)
                    foreach (FilmDS.vFilmSubtitlesRow row in ds.Tables["vFilmSubtitles"].Rows)
                        if(row.RowState != DataRowState.Deleted)
                            row["fldfk_FilmID"] = ds.Tables["vFilm"].Rows[0]["fldFilmID"];
                new FilmSubtitlesDAL().Update(ds.vFilmSubtitles);

            }
            catch (SqlException ex)
            {
                //Set Error
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        public void Delete(object id)
        {
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                new FilmGenreDAL().Delete(id);
                new FilmLanguageDAL().Delete(id);
                new FilmSubtitlesDAL().Delete(id);
                new FilmDAL().Delete(id);
            }
            catch (Exception ex)
            {
                //Set Error
                throw;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
        }

        //public void OnlyUpdate(FilmDS ds)
        //{
        //    SqlConnection connection = ConnectionManager.Instance.GetConnection();
        //    try
        //    {
        //        FilmDS copyOfDS = (FilmDS)ds.Copy();


        //        new FilmDAL().OnlyUpdate(copyOfDS.vFilm);

        //        if (copyOfDS.Tables["vFilmGenre"].Rows.Count != 0)
        //            foreach (FilmDS.vFilmGenreRow row in copyOfDS.Tables["vFilmGenre"].Rows)
        //                new FilmGenreDAL().Delete(copyOfDS.Tables["vFilm"].Rows[0]["fldFilmID"]);
        //        new FilmGenreDAL().Update(copyOfDS.vFilmGenre);

        //        if (copyOfDS.Tables["vFilmLanguage"].Rows.Count != 0)
        //            foreach (FilmDS.vFilmLanguageRow row in copyOfDS.Tables["vFilmLanguage"].Rows)
        //                new FilmLanguageDAL().Delete(copyOfDS.Tables["vFilm"].Rows[0]["fldFilmID"]);
        //        new FilmLanguageDAL().Update(copyOfDS.vFilmLanguage);

        //        if (copyOfDS.Tables["vFilmSubtitles"].Rows.Count != 0)
        //            foreach (FilmDS.vFilmSubtitlesRow row in copyOfDS.Tables["vFilmSubtitles"].Rows)
        //                new FilmSubtitlesDAL().Delete(copyOfDS.Tables["vFilm"].Rows[0]["fldFilmID"]);
        //        new FilmSubtitlesDAL().Update(copyOfDS.vFilmSubtitles);

        //    }
        //    catch (SqlException ex)
        //    {
        //        //Set Error
        //        throw;
        //    }
        //    finally
        //    {
        //        ConnectionManager.Instance.FreeConnection(connection);
        //    }
        //}

        #region Reterive
        public FilmDS GetByID(object id)
        {
            FilmDS ds = new FilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                new FilmDAL().GetByID(ref ds, id);
                new FilmGenreDAL().GetByID(ref ds, id);
                new FilmLanguageDAL().GetByID(ref ds, id);
                new FilmSubtitlesDAL().GetByID(ref ds, id);
            }
            catch (Exception ex)
            {
                //Set Error
                return null;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
            return ds;
        }
        public FilmDS GetAll()
        {
            FilmDS ds = new FilmDS();
            SqlConnection connection = ConnectionManager.Instance.GetConnection();
            try
            {
                new FilmDAL().GetAll(ref ds);
                new FilmGenreDAL().GetAll(ref ds);
                new FilmLanguageDAL().GetAll(ref ds);
                new FilmSubtitlesDAL().GetAll(ref ds);
            }
            catch (Exception ex)
            {
                //Set Error
                return null;
            }
            finally
            {
                ConnectionManager.Instance.FreeConnection(connection);
            }
            return ds;
        }
        #endregion
    }
}
