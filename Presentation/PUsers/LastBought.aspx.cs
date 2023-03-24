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
using Common;
using Common.Data;
using Business;
using AjaxControlToolkit;
using System.Threading;

public partial class PUsers_LastBought : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        if (!IsPostBack)
        {
            CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            RequestBuyDS requestDS = new RequestBuyDS();
            SearchFilter sf = new SearchFilter();
            sf.AddFilter(new FilterDefinition(requestDS.vRequestBuy.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
            GWFilms.DataSource = new RequestBuyBL().GetByFilter(sf, GWFilms.PageIndex, GWFilms.PageCount, requestDS.vRequestBuy.fldFilmIDColumn);
            GWFilms.DataBind();
        }
    }

    protected void GWFilms_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RequestBuyDS requestDS = new RequestBuyDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.vRequestBuy.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
        GWFilms.DataSource = new RequestBuyBL().GetByFilter(sf, GWFilms.PageCount * (e.NewPageIndex - 1), GWFilms.PageCount, requestDS.vRequestBuy.fldKindOfferNameColumn);
        GWFilms.DataBind();
    }

    #region Film Details
    protected void GWFilms_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string fldFilmID = ((Label)GWFilms.Rows[e.NewEditIndex].FindControl("LBfldFilmID")).Text;
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();
        sfDT = sfBL.GetByID(fldFilmID);
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
        HLInformation.NavigateUrl = sfDT[0][sfDT.fldInformationColumn].ToString();
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
        if (int.Parse(sfDT[0][sfDT.fldSumVotesColumn].ToString()) != 0 && int.Parse(sfDT[0][sfDT.fldCountVotesColumn].ToString()) != 0)
            YourRating.CurrentRating = (int)Math.Round(double.Parse(sfDT[0][sfDT.fldSumVotesColumn].ToString()) / double.Parse(sfDT[0][sfDT.fldCountVotesColumn].ToString()));
        else
            YourRating.CurrentRating = 0;

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

        FilmDetailModalPopup.Show();
    }
    protected void YourRating_Changed(object sender, RatingEventArgs e)
    {
        Thread.Sleep(400);
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();
        sfDT = sfBL.GetByID(LBFilmID.Text);

        sfDT[0][sfDT.fldSumVotesColumn] = int.Parse(sfDT[0][sfDT.fldSumVotesColumn].ToString()) + int.Parse(e.Value);
        sfDT[0][sfDT.fldCountVotesColumn] = int.Parse(sfDT[0][sfDT.fldCountVotesColumn].ToString()) + 1;

        sfBL.Update(ref sfDT);
    }
    #endregion
}
