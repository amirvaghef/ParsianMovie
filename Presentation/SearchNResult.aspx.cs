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
using AjaxControlToolkit;
using System.Globalization;

public partial class SearchNResult : System.Web.UI.Page
{
    protected void FillPLBuy()
    {
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        SearchFilter rSF = new SearchFilter();
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));

        SingleRequestBL rBL = new SingleRequestBL();
        SingleRequestDS srDS = rBL.GetByFilter(rSF, new SingleRequestDS().vSingleRequest.fldRequestIDColumn);

        LBPricePanel.Text = srDS.vSingleRequest.Compute("SUM(fldPrice)", "").ToString().Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(srDS.vSingleRequest.Compute("SUM(fldPrice)", "").ToString()));
        LBFilmNumber.Text = srDS.vSingleRequest.Count.ToString();
        if (int.Parse(srDS.vSingleRequest.Count.ToString()) > 0)
        {
            HyperLink1.Visible = true;
            HyperLink2.Visible = false;
        }
        else
        {
            HyperLink1.Visible = false;
            HyperLink2.Visible = true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        if (Request.IsAuthenticated && User.IsInRole("Users"))
        {
            PLBuy.Visible = true;
            FillPLBuy();
        }
        if (!IsPostBack)
        {
            Session.Clear();
            pager1.CurrentIndex = pager2.CurrentIndex = 1;
            BindRepeater(1);
        }
    }

    public void pager_Command(object sender, CommandEventArgs e)
    {
        int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
        pager1.CurrentIndex = pager2.CurrentIndex = currnetPageIndx;
        BindRepeater(currnetPageIndx);
    }
    private void BindRepeater(int pageNo)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();

        if (Session["SearchFilter"] != null)
        {
            SearchFilter sf = Session["SearchFilter"] as SearchFilter;
            if (sf.Filters.Count > 0)
            {
                sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                pager1.ItemCount = pager2.ItemCount = int.Parse(sfBL.CountByFilter(sf).ToString());
            }
            else
            {
                sfDT = sfBL.GetAll((pageNo - 1) * pager1.PageSize, pager1.PageSize);
                pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountAll().ToString());
            }

            DataListFilms.DataSource = sfDT;
                DataListFilms.DataBind();
            if (sfDT.Count == 0)
                LBError.Visible = true;
            else
            {
                
            }
        }
        else
        {


            if (Request.QueryString["FilmName"] != null)
            {
                SearchFilter sf = new SearchFilter();
                sf.OrFilter(new FilterDefinition(sfDT.fldFarsiNameColumn, FilterOperation.Like, Request.QueryString["FilmName"]));
                sf.OrFilter(new FilterDefinition(sfDT.fldEnglishNameColumn, FilterOperation.Like, Request.QueryString["FilmName"]));

                    pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                DataListFilms.DataSource = sfDT;
                DataListFilms.DataBind();
            }
            else

                if (Request.QueryString["Actors"] != null)
                {
                    SearchFilter sf = new SearchFilter();
                    sf.AddFilter(new FilterDefinition(sfDT.fldActorsColumn, FilterOperation.Like, Request.QueryString["Actors"]));

                        pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                    sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                    DataListFilms.DataSource = sfDT;
                    DataListFilms.DataBind();
                }
                else

                    if (Request.QueryString["Director"] != null)
                    {
                        SearchFilter sf = new SearchFilter();
                        sf.AddFilter(new FilterDefinition(sfDT.fldDirectorColumn, FilterOperation.Like, Request.QueryString["Director"]));

                            pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                        sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                        DataListFilms.DataSource = sfDT;
                        DataListFilms.DataBind();
                    }
                    else

                        if (Request.QueryString["YearsOfProduct"] != null)
                        {
                            SearchFilter sf = new SearchFilter();
                            sf.AddFilter(new FilterDefinition(sfDT.fldYearsOfProductColumn, FilterOperation.Like, Request.QueryString["YearsOfProduct"]));

                                pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                            sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                            DataListFilms.DataSource = sfDT;
                            DataListFilms.DataBind();
                        }
                        else

                            if (Request.QueryString["KO"] != null)
                            {
                                SearchFilter sf = new SearchFilter();
                                sf.AddFilter(new FilterDefinition(sfDT.fldfk_KindOfferIDColumn, FilterOperation.Equal, Request.QueryString["KO"]));

                                    pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                                sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                                DataListFilms.DataSource = sfDT;
                                DataListFilms.DataBind();
                            }
                            else

                                if (Request.QueryString["DecBeg"] != null && Request.QueryString["DecEnd"] != null)
                                {
                                    SearchFilter sf = new SearchFilter();
                                    sf.AndFilter(new FilterDefinition(sfDT.fldYearsOfProductColumn, FilterOperation.GreaterThan, Request.QueryString["DecBeg"]));
                                    sf.AndFilter(new FilterDefinition(sfDT.fldYearsOfProductColumn, FilterOperation.LessThanEqual, Request.QueryString["DecEnd"]));

                                        pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                                    sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                                    DataListFilms.DataSource = sfDT;
                                    DataListFilms.DataBind();
                                }
                                else

                                    if (Request.QueryString["Gen"] != null)
                                    {
                                        SearchFilter sf = new SearchFilter();
                                        sf.AddFilter(new FilterDefinition(sfDT.fldGenreIDColumn, FilterOperation.Equal, Request.QueryString["Gen"]));

                                            pager1.ItemCount = pager2.ItemCount  = int.Parse(sfBL.CountByFilter(sf).ToString());

                                        sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                                        DataListFilms.DataSource = sfDT;
                                        DataListFilms.DataBind();
                                    }
                                    else

                                        if (Request.QueryString["CP"] != null)
                                        {
                                            SearchFilter sf = new SearchFilter();
                                            sf.AddFilter(new FilterDefinition(sfDT.fldfk_CountryProductIDColumn, FilterOperation.Equal, Request.QueryString["CP"]));

                                                pager1.ItemCount = pager2.ItemCount = int.Parse(sfBL.CountByFilter(sf).ToString());

                                            sfDT = sfBL.GetByFilter(sf, (pageNo - 1) * pager1.PageSize, pager1.PageSize, sfDT.fldFilmIDColumn);
                                            DataListFilms.DataSource = sfDT;
                                            DataListFilms.DataBind();
                                        }
                                        else
                                        {
                                                pager1.ItemCount = pager2.ItemCount = int.Parse(sfBL.CountAll().ToString());

                                            sfDT = sfBL.GetAll((pageNo - 1) * pager1.PageSize, pager1.PageSize);
                                            DataListFilms.DataSource = sfDT;
                                            DataListFilms.DataBind();
                                        }
        }
        

        for (int i = 0; i < DataListFilms.Items.Count; i++)
        {
            SingleFilmSubtitlesBL sfsBL = new SingleFilmSubtitlesBL();
            SingleFilmSubtitlesDS.vFilmSubtitlesDataTable sfsDT = new SingleFilmSubtitlesDS.vFilmSubtitlesDataTable();
            SearchFilter sfsSF = new SearchFilter();
            sfsSF.AddFilter(new FilterDefinition(sfsDT.fldfk_FilmIDColumn, FilterOperation.Equal, ((Label)DataListFilms.Items[i].FindControl("LBfldFilmID")).Text));
            sfsDT = sfsBL.GetByFilter(sfsSF, sfsDT.fldFilmSubtitlesIDColumn);
            ((DataList)DataListFilms.Items[i].FindControl("DLSubtitles")).DataSource = sfsDT;
            ((DataList)DataListFilms.Items[i].FindControl("DLSubtitles")).DataBind();

            if (Request.IsAuthenticated && User.IsInRole("Users"))
            {
                SingleRequestBL rBL = new SingleRequestBL();
                SearchFilter rSF = new SearchFilter();
                rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_FilmIDColumn, FilterOperation.Equal, ((Label)DataListFilms.Items[i].FindControl("LBfldFilmID")).Text));
                rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
                rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));
                if (rBL.CountByFilter(rSF) > 0)
                {
                    ((ImageButton)DataListFilms.Items[i].FindControl("EmptyBasket")).Visible = false;
                    ((ImageButton)DataListFilms.Items[i].FindControl("FullBasket")).Visible = true;
                }
                else
                {
                    ((ImageButton)DataListFilms.Items[i].FindControl("EmptyBasket")).Visible = true;
                    ((ImageButton)DataListFilms.Items[i].FindControl("FullBasket")).Visible = false;
                }
            }
            else
            {
                ((ImageButton)DataListFilms.Items[i].FindControl("EmptyBasket")).Visible = true;
                ((ImageButton)DataListFilms.Items[i].FindControl("EmptyBasket")).Enabled = false;
                ((ImageButton)DataListFilms.Items[i].FindControl("EmptyBasket")).ToolTip = "ابتدا بايد وارد سيستم شويد";
                ((ImageButton)DataListFilms.Items[i].FindControl("FullBasket")).Visible = false;
            }
        }
    }

    #region vAdvancedSearch Buttons
    protected void IBAdvancedSearch_Click(object sender, ImageClickEventArgs e)
    {
        Search();
    }
    protected void Search()
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
        Session.Add("SearchFilter", sf);
        BindRepeater(1);
    }
    #endregion

    #region Baskets Methods
    protected void EmptyBasketDataList_Click(object sender, DataListCommandEventArgs e)
    {
        
        SingleRequestDS requestDS = new SingleRequestDS();

        SingleRequestDS.vSingleRequestRow requestRow = requestDS.vSingleRequest.NewvSingleRequestRow();
        requestRow.fldRequestID = Guid.NewGuid();
        requestRow.fldRequestDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
        requestRow.fldPrice = int.Parse(((Label)e.Item.FindControl("LBPrice")).Text, NumberStyles.Number);
        requestRow.fldfk_Username = User.Identity.Name;
        requestRow.fldfk_FilmID = long.Parse(((Label)e.Item.FindControl("LBfldFilmID")).Text);
        requestDS.vSingleRequest.AddvSingleRequestRow(requestRow);

        new SingleRequestBL().Update(ref requestDS);

        ((ImageButton)e.Item.FindControl("EmptyBasket")).Visible = false;
        ((ImageButton)e.Item.FindControl("FullBasket")).Visible = true;

        FillPLBuy();
    }
    protected void FullBasketDataList_Click(object sender, DataListCommandEventArgs e)
    {
        SearchFilter rSF = new SearchFilter();
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_FilmIDColumn, FilterOperation.Equal, ((Label)e.Item.FindControl("LBfldFilmID")).Text));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));

        SingleRequestBL rBL = new SingleRequestBL();
        SingleRequestDS srDS = rBL.GetByFilter(rSF, new SingleRequestDS().vSingleRequest.fldRequestIDColumn);

        for (int i = 0; i < srDS.vSingleRequest.Rows.Count; i++)
            srDS.vSingleRequest.Rows[i].Delete();
        rBL.Update(ref srDS);
        srDS.AcceptChanges();

        ((ImageButton)e.Item.FindControl("EmptyBasket")).Visible = true;
        ((ImageButton)e.Item.FindControl("FullBasket")).Visible = false;

        FillPLBuy();
    }
    #endregion

    protected int CalculateRate(object sum, object count)
    {
        if (int.Parse(sum.ToString()) != 0 && int.Parse(count.ToString()) != 0)
            return (int)Math.Round(double.Parse(sum.ToString()) / double.Parse(count.ToString()));
        else
            return 0;
    }
}
