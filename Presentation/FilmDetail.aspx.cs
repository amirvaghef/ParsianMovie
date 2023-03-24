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
using AjaxControlToolkit;
using Persia;
using Common;
using Common.Data;
using Business;
using System.Globalization;

public partial class FilmDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       string fldFilmID = Request.QueryString["FilmID"].ToString();
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
       

       if (Request.IsAuthenticated && User.IsInRole("Users"))
       {
           SingleRequestBL rBL = new SingleRequestBL();
           SearchFilter rSF = new SearchFilter();
           rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_FilmIDColumn, FilterOperation.Equal, fldFilmID));
           rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
           rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));
           if (rBL.CountByFilter(rSF) > 0)
           {
               EmptyBasket.Visible = false;
               FullBasket.Visible = true;
           }
           else
           {
               EmptyBasket.Visible = true;
               FullBasket.Visible = false;
           }
       }
       else
       {
           EmptyBasket.Visible = true;
           EmptyBasket.Enabled = false;
           EmptyBasket.ToolTip = "ابتدا بايد وارد سيستم شويد";
           FullBasket.Visible = false;
       }

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

    }

    #region Basket Methods
    protected void EmptyBasket_Click(object sender, ImageClickEventArgs e)
    {
        SingleRequestDS requestDS = new SingleRequestDS();

        SingleRequestDS.vSingleRequestRow requestRow = requestDS.vSingleRequest.NewvSingleRequestRow();
        requestRow.fldRequestID = Guid.NewGuid();
        requestRow.fldRequestDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
        requestRow.fldPrice = int.Parse(LBPrice.Text, NumberStyles.Number);
        requestRow.fldfk_Username = User.Identity.Name;
        requestRow.fldfk_FilmID = long.Parse(LBFilmID.Text);
        requestDS.vSingleRequest.AddvSingleRequestRow(requestRow);

        new SingleRequestBL().Update(ref requestDS);

        Response.Redirect("~/" + Request.QueryString["Page"].ToString());
    }
    protected void FullBasket_Click(object sender, ImageClickEventArgs e)
    {
        SearchFilter rSF = new SearchFilter();
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_FilmIDColumn, FilterOperation.Equal, LBFilmID.Text));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));

        SingleRequestBL rBL = new SingleRequestBL();
        SingleRequestDS srDS = rBL.GetByFilter(rSF, new SingleRequestDS().vSingleRequest.fldRequestIDColumn);

        for (int i = 0; i < srDS.vSingleRequest.Rows.Count; i++)
            srDS.vSingleRequest.Rows[i].Delete();
        rBL.Update(ref srDS);
        srDS.AcceptChanges();

        Response.Redirect("~/" + Request.QueryString["Page"].ToString());
    }
    #endregion
}
