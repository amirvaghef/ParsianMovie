using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using Common;
using Common.Data;
using Business;
using System.IO;

public partial class PAdmin_Films : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        if(!IsPostBack)
            CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"]; //"Data Source=COMPUTER252\\SQLEXPRESS;Initial Catalog=ParsianMovieDB;Integrated Security=True";
    }

    #region vInsert Buttons
    protected void BTSubmit_Click(object sender, ImageClickEventArgs e)
    {
        SingleFilmBL sfBl = new SingleFilmBL();
        SearchFilter sf = new SearchFilter();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();

        sf.AddFilter(new FilterDefinition(sfDT.fldEnglishNameColumn, FilterOperation.Equal, TXTEnglishName.Text.Trim()));
        sf.AndFilter(new FilterDefinition(sfDT.fldfk_KindOfferIDColumn, FilterOperation.Equal, RBLKindOffer.SelectedValue));
        sfDT = sfBl.GetByFilter(sf, sfDT.fldFilmIDColumn);

        if (sfDT.Rows.Count > 0)
        {
            CountTwice.Text = sfDT.Rows.Count.ToString();

            string fldFilmID = sfDT[0][sfDT.fldFilmIDColumn].ToString();

            LBFilmID.Text = fldFilmID;
            Picture.Src = sfDT[0][sfDT.fldPosterColumn].ToString();
            LBAbstract.Text = sfDT[0][sfDT.fldAbstractColumn].ToString();
            LBActors.Text = sfDT[0][sfDT.fldActorsColumn].ToString();
            LBComment.Text = sfDT[0][sfDT.fldCommentColumn].ToString();
            LBCountryProduct.Text = sfDT[0][sfDT.fldCountryProductNameColumn].ToString();
            LBDirector.Text = sfDT[0][sfDT.fldDirectorColumn].ToString();
            LBEnglishName.Text = sfDT[0][sfDT.fldEnglishNameColumn].ToString();
            LBFarsiName.Text = sfDT[0][sfDT.fldFarsiNameColumn].ToString();
            LBIMDBRating.Text = sfDT[0][sfDT.fldIMDBRatingColumn].ToString();
            if (sfDT[0][sfDT.fldKindOfferNameColumn].ToString() == KindOfferEnum.MKV.ToString())
            {
                MKV.Visible = true;
                DVD.Visible = false;
                DIVX.Visible = false;
            }
            if (sfDT[0][sfDT.fldKindOfferNameColumn].ToString() == KindOfferEnum.DVD.ToString())
            {
                MKV.Visible = false;
                DVD.Visible = true;
                DIVX.Visible = false;
            }
            if (sfDT[0][sfDT.fldKindOfferNameColumn].ToString() == KindOfferEnum.DIVX.ToString())
            {
                MKV.Visible = false;
                DVD.Visible = false;
                DIVX.Visible = true;
            }
            LBPrice.Text = String.Format("{0:#,###}", int.Parse(sfDT[0][sfDT.fldPriceColumn].ToString()));
            LBQuality.Text = sfDT[0][sfDT.fldQualityNameColumn].ToString();
            LBRank.Text = sfDT[0][sfDT.fldRankNameColumn].ToString();
            LBSection.Text = sfDT[0][sfDT.fldSectionColumn].ToString();
            LBTime.Text = sfDT[0][sfDT.fldTimeColumn].ToString();
            LBYearsOfProduct.Text = sfDT[0][sfDT.fldYearsOfProductColumn].ToString();

            SingleFilmSubtitlesBL sfsBL = new SingleFilmSubtitlesBL();
            SingleFilmSubtitlesDS.vFilmSubtitlesDataTable sfsDT = new SingleFilmSubtitlesDS.vFilmSubtitlesDataTable();
            SearchFilter sfsSF = new SearchFilter();
            sfsSF.AddFilter(new FilterDefinition(sfsDT.fldfk_FilmIDColumn, FilterOperation.Equal, fldFilmID));
            sfsDT = sfsBL.GetByFilter(sfsSF, sfsDT.fldFilmSubtitlesIDColumn);
            DLSubtitles.DataSource = sfsDT;
            DLSubtitles.DataBind();

            SingleFilmGenreBL sfgBL = new SingleFilmGenreBL();
            SingleFilmGenreDS.vFilmGenreDataTable sfgDT = new SingleFilmGenreDS.vFilmGenreDataTable();
            SearchFilter sfgSF = new SearchFilter();
            sfgSF.AddFilter(new FilterDefinition(sfgDT.fldfk_FilmIDColumn, FilterOperation.Equal, fldFilmID));
            sfgDT = sfgBL.GetByFilter(sfgSF, sfgDT.fldFilmGenreIDColumn);
            DLGenre.DataSource = sfgDT;
            DLGenre.DataBind();

            SingleFilmLanguageBL sflBL = new SingleFilmLanguageBL();
            SingleFilmLanguageDS.vFilmLanguageDataTable sflDT = new SingleFilmLanguageDS.vFilmLanguageDataTable();
            SearchFilter sflSF = new SearchFilter();
            sflSF.AddFilter(new FilterDefinition(sflDT.fldfk_FilmIDColumn, FilterOperation.Equal, fldFilmID));
            sflDT = sflBL.GetByFilter(sflSF, sflDT.fldFilmLanguageIDColumn);
            DLLanguage.DataSource = sflDT;
            DLLanguage.DataBind();


            TwiceModalPopup.Show();
        }
        else
            Insert();

        /* Reset*/
        
    }
    protected void Insert()
    {
        string picName = "";
        if (FUPoster.PostedFile.ContentLength != 0)
        {
            HttpPostedFile picFile = FUPoster.PostedFile;
            byte[] picData = new byte[picFile.ContentLength];
            picFile.InputStream.Read(picData, 0, picFile.ContentLength);

            Random random = new Random();
            picName = "../Cover/" + random.Next(1000000).ToString() + picFile.FileName.Substring(picFile.FileName.LastIndexOf("\\") + 1);

            FileStream newFile = new FileStream(MapPath(picName), FileMode.Create);
            newFile.Write(picData, 0, picData.Length);
            newFile.Close();
        }

        FilmDS filmDS = new FilmDS();

        FilmDS.vFilmRow filmRow = filmDS.vFilm.NewvFilmRow();
        filmRow.fldAbstract = TXTAbstract.Text.Trim();
        filmRow.fldActors = TXTActors.Value.Trim();
        filmRow.fldComment = TXTComment.Text.Trim();
        filmRow.fldDirector = TXTDirector.Value.Trim();
        filmRow.fldEnglishName = TXTEnglishName.Text.Trim();
        filmRow.fldFarsiName = TXTFarsiName.Value.Trim();
        filmRow.fldfk_CountryProductID = short.Parse(DRPCountry.SelectedValue.Trim());
        filmRow.fldfk_KindOfferID = short.Parse(RBLKindOffer.SelectedValue.Trim());
        filmRow.fldfk_QualityID = short.Parse(DRPQuality.SelectedValue.Trim());
        filmRow.fldfk_RankID = short.Parse(DRPRank.SelectedValue.Trim());
        filmRow.fldIMDBRating = double.Parse(TXTIMDBRating1.Text.Trim());
        filmRow.fldInformation = TXTInformation.Text.Trim();
        filmRow.fldPoster = picName;
        filmRow.fldPrice = int.Parse(TXTPrice1.Text.Trim().IndexOf(',') < 1 ? TXTPrice1.Text.Trim() : TXTPrice1.Text.Trim().Remove(TXTPrice1.Text.Trim().IndexOf(','), 1));
        filmRow.fldSection = short.Parse(TXTSection1.Text.Trim());
        TXTTime1.Text = "0000" + TXTTime1.Text.Trim();
        filmRow.fldTime = TXTTime1.Text.Trim().Substring(TXTTime1.Text.Trim().Length - 4, 2) + ":" + TXTTime1.Text.Trim().Substring(TXTTime1.Text.Trim().Length - 2);
        filmRow.fldYearsOfProduct = TXTYearsOfProduct1.Text.Trim();
        filmDS.vFilm.AddvFilmRow(filmRow);

        foreach (ListItem ls in CHLGenre.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmGenreRow filmGenreRow = filmDS.vFilmGenre.NewvFilmGenreRow();
                filmGenreRow.fldFilmGenreID = Guid.NewGuid();
                filmGenreRow.fldfk_GenreID = short.Parse(ls.Value);
                filmDS.vFilmGenre.AddvFilmGenreRow(filmGenreRow);
        }
            }

        foreach (ListItem ls in CHLLanguages.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmLanguageRow filmLanguageRow = filmDS.vFilmLanguage.NewvFilmLanguageRow();
                filmLanguageRow.fldFilmLanguageID = Guid.NewGuid();
                filmLanguageRow.fldfk_LanguageID = short.Parse(ls.Value);
                filmDS.vFilmLanguage.AddvFilmLanguageRow(filmLanguageRow);
            }
        }

        foreach (ListItem ls in CHLSubtitles.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmSubtitlesRow filmSubtitlesRow = filmDS.vFilmSubtitles.NewvFilmSubtitlesRow();
                filmSubtitlesRow.fldFilmSubtitlesID = Guid.NewGuid();
                filmSubtitlesRow.fldfk_SubtitlesID = short.Parse(ls.Value);
                filmDS.vFilmSubtitles.AddvFilmSubtitlesRow(filmSubtitlesRow);
            }
        }

        FilmDetailBL filmDetail = new FilmDetailBL();
        filmDetail.Update(ref filmDS);

        fldFilmIDInsert.Text = filmDS.vFilm.Rows[0][filmDS.vFilm.fldFilmIDColumn].ToString();
        filmDS.AcceptChanges();
        InsertModalPopup.Show();

        #region Reset
        TXTAbstract.Text = "";
        TXTActors.Value = "";
        TXTDirector.Value = "";
        TXTEnglishName.Text = "";
        TXTFarsiName.Value = "";
        TXTIMDBRating1.Text = "";
        TXTInformation.Text = "";
        TXTPrice1.Text = "";
        TXTSection1.Text = "";
        TXTTime1.Text = "";
        TXTYearsOfProduct1.Text = "";
        TXTComment.Text = "";
        CHLGenre.SelectedIndex = -1;
        CHLLanguages.SelectedIndex = -1;
        CHLSubtitles.SelectedIndex = -1;
        RBLKindOffer.SelectedIndex = 0;
        DRPCountry.SelectedIndex = -1;
        DRPQuality.SelectedIndex = -1;
        DRPRank.SelectedIndex = -1;
        #endregion
    }
    protected void BTReset_Click(object sender, ImageClickEventArgs e)
    {
        TXTAbstract.Text = "";
        TXTActors.Value = "";
        TXTDirector.Value = "";
        TXTEnglishName.Text = "";
        TXTFarsiName.Value = "";
        TXTIMDBRating1.Text = "";
        TXTInformation.Text = "";
        TXTPrice1.Text = "";
        TXTSection1.Text = "";
        TXTTime1.Text = "";
        TXTYearsOfProduct1.Text = "";
        TXTComment.Text = "";
        CHLGenre.SelectedIndex = -1;
        CHLLanguages.SelectedIndex = -1;
        CHLSubtitles.SelectedIndex = -1;
        RBLKindOffer.SelectedIndex = 0;
        DRPCountry.SelectedIndex = -1;
        DRPQuality.SelectedIndex = -1;
        DRPRank.SelectedIndex = -1;
    } 
    #endregion

    #region vUpdate Buttons
    protected void BTUpdate_Click(object sender, ImageClickEventArgs e)
    {
        FilmDS filmDS = new FilmDS();
        FilmDetailBL fdBL = new FilmDetailBL();
        filmDS = fdBL.GetByID(TXTfldFilmID.Text);

        FilmDS.vFilmRow filmRow = filmDS.vFilm.Rows[0] as FilmDS.vFilmRow;

        string picName = "";
        if (FUPosterUpdate.PostedFile.ContentLength != 0)
        {
            HttpPostedFile picFile = FUPosterUpdate.PostedFile;
            byte[] picData = new byte[picFile.ContentLength];
            picFile.InputStream.Read(picData, 0, picFile.ContentLength);

            if (File.Exists(filmRow.fldPoster))
                File.Delete(filmRow.fldPoster);

            Random random = new Random();
            picName = "../Cover/" + random.Next(1000000).ToString() + picFile.FileName.Substring(picFile.FileName.LastIndexOf("\\") + 1);

            FileStream newFile = new FileStream(MapPath(picName), FileMode.Create);
            newFile.Write(picData, 0, picData.Length);
            newFile.Close();
        }

        filmRow.fldAbstract = TXTAbstractUpdate.Text;
        filmRow.fldActors = TXTActorsUpdate.Value;
        filmRow.fldComment = TXTCommentUpdate.Text;
        filmRow.fldDirector = TXTDirectorUpdate.Value;
        filmRow.fldEnglishName = TXTEnglishNameUpdate.Text;
        filmRow.fldFarsiName = TXTFarsiNameUpdate.Value;
        filmRow.fldfk_CountryProductID = short.Parse(DRPCountryUpdate.SelectedValue);
        filmRow.fldfk_KindOfferID = short.Parse(RBLKindOfferUpdate.SelectedValue);
        filmRow.fldfk_QualityID = short.Parse(DRPQualityUpdate.SelectedValue);
        filmRow.fldfk_RankID = short.Parse(DRPRankUpdate.SelectedValue);
        filmRow.fldIMDBRating = double.Parse(TXTIMDBRatingUpdate1.Text);
        filmRow.fldInformation = TXTInformationUpdate.Text;
        if (picName != "")
            filmRow.fldPoster = picName;
        filmRow.fldPrice = int.Parse(TXTPriceUpdate1.Text.IndexOf(',') < 1 ? TXTPriceUpdate1.Text : TXTPriceUpdate1.Text.Remove(TXTPriceUpdate1.Text.IndexOf(','), 1));
        filmRow.fldSection = short.Parse(TXTSectionUpdate1.Text);
        TXTTimeUpdate1.Text = "0000" + TXTTimeUpdate1.Text.Trim();
        filmRow.fldTime = TXTTimeUpdate1.Text.Trim().Substring(TXTTimeUpdate1.Text.Trim().Length - 4, 2) + ":" + TXTTimeUpdate1.Text.Trim().Substring(TXTTimeUpdate1.Text.Trim().Length - 2);
        filmRow.fldYearsOfProduct = TXTYearsOfProductUpdate1.Text;

        for (int i = 0; i < filmDS.vFilmGenre.Rows.Count; i++)
        {
            filmDS.vFilmGenre.Rows[i].Delete();
        }
        foreach (ListItem ls in CHLGenreUpdate.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmGenreRow filmGenreRow = filmDS.vFilmGenre.NewvFilmGenreRow();
                filmGenreRow.fldFilmGenreID = Guid.NewGuid();
                filmGenreRow.fldfk_GenreID = short.Parse(ls.Value);
                filmGenreRow.fldfk_FilmID = long.Parse(TXTfldFilmID.Text);
                filmDS.vFilmGenre.AddvFilmGenreRow(filmGenreRow);
            }
        }
        for (int i = 0; i < filmDS.vFilmLanguage.Rows.Count; i++)
        {
            filmDS.vFilmLanguage.Rows[i].Delete();
        }
        foreach (ListItem ls in CHLLanguagesUpdate.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmLanguageRow filmLanguageRow = filmDS.vFilmLanguage.NewvFilmLanguageRow();
                filmLanguageRow.fldFilmLanguageID = Guid.NewGuid();
                filmLanguageRow.fldfk_LanguageID = short.Parse(ls.Value);
                filmLanguageRow.fldfk_FilmID = long.Parse(TXTfldFilmID.Text);
                filmDS.vFilmLanguage.AddvFilmLanguageRow(filmLanguageRow);
            }
        }

        for (int i = 0; i < filmDS.vFilmSubtitles.Rows.Count; i++)
        {
            filmDS.vFilmSubtitles.Rows[i].Delete();
        }
        foreach (ListItem ls in CHLSubtitlesUpdate.Items)
        {
            if (ls.Selected)
            {
                FilmDS.vFilmSubtitlesRow filmSubtitlesRow = filmDS.vFilmSubtitles.NewvFilmSubtitlesRow();
                filmSubtitlesRow.fldFilmSubtitlesID = Guid.NewGuid();
                filmSubtitlesRow.fldfk_SubtitlesID = short.Parse(ls.Value);
                filmSubtitlesRow.fldfk_FilmID = long.Parse(TXTfldFilmID.Text);
                filmDS.vFilmSubtitles.AddvFilmSubtitlesRow(filmSubtitlesRow);
            }
        }

        FilmDetailBL filmDetail = new FilmDetailBL();
        filmDetail.Update(ref filmDS);

        filmDS.AcceptChanges();
        Search(Hidden1.Value);
        this.UpdateModalPopup.Show();
    }
    protected void BTCancel_Click(object sender, ImageClickEventArgs e)
    {
        TXTAbstractUpdate.Text = "";
        TXTActorsUpdate.Value = "";
        TXTDirectorUpdate.Value = "";
        TXTEnglishNameUpdate.Text = "";
        TXTFarsiNameUpdate.Value = "";
        TXTIMDBRatingUpdate1.Text = "";
        TXTInformationUpdate.Text = "";
        TXTPriceUpdate1.Text = "";
        TXTSectionUpdate1.Text = "";
        TXTTimeUpdate1.Text = "";
        TXTYearsOfProductUpdate1.Text = "";
        CHLGenreUpdate.SelectedIndex = -1;
        CHLLanguagesUpdate.SelectedIndex = -1;
        CHLSubtitlesUpdate.SelectedIndex = -1;
        RBLKindOfferUpdate.SelectedIndex = 0;
        DRPCountryUpdate.SelectedIndex = -1;
        DRPQualityUpdate.SelectedIndex = -1;
        DRPRankUpdate.SelectedIndex = -1;

        MultiViewSearch.SetActiveView(vAdvancedSearch);
    }
    protected void BTDelete_Click(object sender, ImageClickEventArgs e)
    {
        FilmDetailBL fBL = new FilmDetailBL();
        fBL.Delete(TXTfldFilmID.Text);
        MultiViewSearch.SetActiveView(vAdvancedSearch);
        this.DeleteModalPopup.Show();
    } 
    #endregion

    protected void LBSearchBack_Click(object sender, EventArgs e)
    {
        MultiViewSearch.SetActiveView(vAdvancedSearch);
    }

    #region vAdvancedSearch Buttons
    protected void IBAdvancedSearch_Click(object sender, ImageClickEventArgs e)
    {
        Search("fldFilmID ASC");
    }
    protected void Search(string sort)
    {
        SingleFilmDS.vSingleFilmDataTable searchDT = new SingleFilmDS.vSingleFilmDataTable();
        SearchFilter sf = new SearchFilter();

        if (CHAnd1.Checked)
        {
            if (TXTActorsSearch.Value.Trim().Length > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldActorsColumn, FilterOperation.Like, TXTActorsSearch.Value.Trim()));
            if (TXTDirectorSearch.Value.Trim().Length > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldDirectorColumn, FilterOperation.Like, TXTDirectorSearch.Value.Trim()));
            if (TXTEnglishNameSearch.Text.Trim().Length > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldEnglishNameColumn, FilterOperation.Like, TXTEnglishNameSearch.Text.Trim()));
            if (TXTYearsOfProductSearch1.Text.Trim().Length > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldYearsOfProductColumn, FilterOperation.Like, TXTYearsOfProductSearch1.Text.Trim()));
            if (DRPCountrySearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldfk_CountryProductIDColumn, FilterOperation.Equal, DRPCountrySearch.SelectedValue));
            if (DRPKindOfferSearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldfk_KindOfferIDColumn, FilterOperation.Equal, DRPKindOfferSearch.SelectedValue));
            if (DRPGenreSearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldGenreIDColumn, FilterOperation.Equal, DRPGenreSearch.SelectedValue));
            if (DRPLanguageSearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldLanguageIDColumn, FilterOperation.Equal, DRPLanguageSearch.SelectedValue));
            if (DRPRankSearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldfk_RankIDColumn, FilterOperation.Equal, DRPRankSearch.SelectedValue));
            if (DRPSubtitlesSearch.SelectedIndex > 0)
                sf.AndFilter(new FilterDefinition(searchDT.fldSubtitlesIDColumn, FilterOperation.Equal, DRPSubtitlesSearch.SelectedValue));
        }
        else
        {
            if (TXTActorsSearch.Value.Trim().Length > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldActorsColumn, FilterOperation.Like, TXTActorsSearch.Value.Trim()));
            if (TXTDirectorSearch.Value.Trim().Length > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldDirectorColumn, FilterOperation.Like, TXTDirectorSearch.Value.Trim()));
            if (TXTEnglishNameSearch.Text.Trim().Length > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldEnglishNameColumn, FilterOperation.Like, TXTEnglishNameSearch.Text.Trim()));
            if (TXTYearsOfProductSearch1.Text.Trim().Length > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldYearsOfProductColumn, FilterOperation.Like, TXTYearsOfProductSearch1.Text.Trim()));
            if (DRPCountrySearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldfk_CountryProductIDColumn, FilterOperation.Equal, DRPCountrySearch.SelectedValue));
            if (DRPKindOfferSearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldfk_KindOfferIDColumn, FilterOperation.Equal, DRPKindOfferSearch.SelectedValue));
            if (DRPGenreSearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldGenreIDColumn, FilterOperation.Equal, DRPGenreSearch.SelectedValue));
            if (DRPLanguageSearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldLanguageIDColumn, FilterOperation.Equal, DRPLanguageSearch.SelectedValue));
            if (DRPRankSearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldfk_RankIDColumn, FilterOperation.Equal, DRPRankSearch.SelectedValue));
            if (DRPSubtitlesSearch.SelectedIndex > 0)
                sf.OrFilter(new FilterDefinition(searchDT.fldSubtitlesIDColumn, FilterOperation.Equal, DRPSubtitlesSearch.SelectedValue));
        }
        SingleFilmBL fbl = new SingleFilmBL();
        if (sf.Filters.Count > 0)
            searchDT = fbl.GetByFilter(sf, searchDT.fldFilmIDColumn);
        else
            searchDT = fbl.GetAll();

        if (searchDT.Count == 0)
        {
            WithoutModalPopup.Show();
        }
        if (searchDT.Count == 1)
        {
            MultiViewSearch.SetActiveView(vUpdate);
            vUpdate_Fill(searchDT.Rows[0][searchDT.fldFilmIDColumn]);
        }
        if (searchDT.Count > 1)
        {
            MultiViewSearch.SetActiveView(vResult);
            DataView dataView = new DataView(searchDT);
            if (sort != String.Empty)
                dataView.Sort = sort;
            GridViewFilm.DataSource = dataView;
            GridViewFilm.DataBind();
        }
    } 
    #endregion

    #region vUpdate_Fill
    protected void vUpdate_Fill(object fldFilmID)
    {
        FilmDS fDS = new FilmDS();
        FilmDetailBL fdBL = new FilmDetailBL();
        fDS = fdBL.GetByID(fldFilmID);

        FilmDS.vFilmDataTable searchDT = new FilmDS.vFilmDataTable();
        searchDT = fDS.vFilm;

        TXTfldFilmID.Text = fldFilmID.ToString();
        TXTAbstractUpdate.Text = searchDT.Rows[0][searchDT.fldAbstractColumn].ToString();
        TXTActorsUpdate.Value = searchDT.Rows[0][searchDT.fldActorsColumn].ToString();
        TXTCommentUpdate.Text = searchDT.Rows[0][searchDT.fldCommentColumn].ToString();
        TXTDirectorUpdate.Value = searchDT.Rows[0][searchDT.fldDirectorColumn].ToString();
        TXTEnglishNameUpdate.Text = searchDT.Rows[0][searchDT.fldEnglishNameColumn].ToString();//searchDT.fldEnglishNameColumn.DefaultValue.ToString();
        TXTFarsiNameUpdate.Value = searchDT.Rows[0][searchDT.fldFarsiNameColumn].ToString();
        TXTIMDBRatingUpdate1.Text = searchDT.Rows[0][searchDT.fldIMDBRatingColumn].ToString();
        TXTInformationUpdate.Text = searchDT.Rows[0][searchDT.fldInformationColumn].ToString();
        TXTPriceUpdate1.Text = searchDT.Rows[0][searchDT.fldPriceColumn].ToString();
        TXTSectionUpdate1.Text = searchDT.Rows[0][searchDT.fldSectionColumn].ToString();
        TXTTimeUpdate1.Text = searchDT.Rows[0][searchDT.fldTimeColumn].ToString();
        TXTYearsOfProductUpdate1.Text = searchDT.Rows[0][searchDT.fldYearsOfProductColumn].ToString();
        RBLKindOfferUpdate.DataBind();
        RBLKindOfferUpdate.Items.FindByValue(searchDT.Rows[0][searchDT.fldfk_KindOfferIDColumn].ToString()).Selected = true;
        DRPCountryUpdate.DataBind();
        DRPCountryUpdate.Items.FindByValue(searchDT.Rows[0][searchDT.fldfk_CountryProductIDColumn].ToString()).Selected = true;
        DRPQualityUpdate.DataBind();
        DRPQualityUpdate.Items.FindByValue(searchDT.Rows[0][searchDT.fldfk_QualityIDColumn].ToString()).Selected = true;
        DRPRankUpdate.DataBind();
        DRPRankUpdate.Items.FindByValue(searchDT.Rows[0][searchDT.fldfk_RankIDColumn].ToString()).Selected = true;


        #region Fill FilmGenre CheckBoxList
        FilmDS.vFilmGenreDataTable genreDT = new FilmDS.vFilmGenreDataTable();
        genreDT = fDS.vFilmGenre;

        CHLGenreUpdate.DataBind();
        foreach (FilmDS.vFilmGenreRow row in genreDT.Rows)
            CHLGenreUpdate.Items.FindByValue(row[genreDT.fldfk_GenreIDColumn].ToString()).Selected = true;
        #endregion

        #region Fill FilmLanguage CheckBoxList
        FilmDS.vFilmLanguageDataTable languageDT = new FilmDS.vFilmLanguageDataTable();
        languageDT = fDS.vFilmLanguage;

        CHLLanguagesUpdate.DataBind();
        foreach (FilmDS.vFilmLanguageRow row in languageDT.Rows)
            CHLLanguagesUpdate.Items.FindByValue(row[languageDT.fldfk_LanguageIDColumn].ToString()).Selected = true;
        #endregion

        #region Fill FilmSubtitles
        FilmDS.vFilmSubtitlesDataTable subtitlesDT = new FilmDS.vFilmSubtitlesDataTable();
        subtitlesDT = fDS.vFilmSubtitles;

        CHLSubtitlesUpdate.DataBind();
        foreach (FilmDS.vFilmSubtitlesRow row in subtitlesDT.Rows)
            CHLSubtitlesUpdate.Items.FindByValue(row[subtitlesDT.fldfk_SubtitlesIDColumn].ToString()).Selected = true;
        #endregion
    } 
    #endregion

    #region GridView Methods
    protected void GridViewFilm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFilm.PageIndex = e.NewPageIndex;
        Search(Hidden1.Value); 
    }
    protected void GridViewFilm_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        FilmDetailBL fBL = new FilmDetailBL();
        fBL.Delete(GridViewFilm.Rows[e.RowIndex].Cells[1].Text);
        Search(Hidden1.Value);
        this.DeleteModalPopup.Show();
    }
    protected void GridViewFilm_RowEditing(object sender, GridViewEditEventArgs e)
    {
        MultiViewSearch.SetActiveView(vUpdate);
        vUpdate_Fill(GridViewFilm.Rows[e.NewEditIndex].Cells[1].Text);
    }
    protected void GridViewFilm_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (Hidden1.Value.Substring(Hidden1.Value.LastIndexOf(" ")+1) == "ASC")
        {
            Search(e.SortExpression + " DESC");
            Hidden1.Value = e.SortExpression + " DESC";
        }
        else
            if (Hidden1.Value.Substring(Hidden1.Value.LastIndexOf(" ") + 1) == "DESC")
            {
                Search(e.SortExpression + " ASC");
                Hidden1.Value = e.SortExpression + " ASC";
            }
    } 
    #endregion

    #region Hide PopupModal Methods
    protected void hideDeleteModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.DeleteModalPopup.Hide();
    }
    protected void hideUpdateModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.UpdateModalPopup.Hide();
    }
    protected void hideInsertModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.InsertModalPopup.Hide();
    }
    protected void hideWithoutModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.WithoutModalPopup.Hide();
    }
    protected void OKTwiceModalPopupViaServer_Click(object sender, EventArgs e)
    {
        Insert();
    }
    protected void CancelTwiceModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.TwiceModalPopup.Hide();
    } 
    #endregion
}