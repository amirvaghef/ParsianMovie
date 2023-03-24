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
using Business;
using Common;
using Common.Data;
using System.Globalization;

public partial class PAdmin_BaseInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        if (!IsPostBack)
        {
            MultiViewBaseInfo.Visible = false;

            GWRank.DataSource = ObjectDataSourceRank.Select();
            GWRank.DataBind();

            GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
            GWCountryProduct.DataBind();

            GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
            GWKindOffer.DataBind();

            GWQuality.DataSource = ObjectDataSourceQuality.Select();
            GWQuality.DataBind();

            GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
            GWSubtitles.DataBind();

            GWGenre.DataSource = ObjectDataSourceGenre.Select();
            GWGenre.DataBind();

            GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
            GWLanguage.DataBind();

            GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
            GWDVDKind.DataBind();

            GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
            GWTransmissionKind.DataBind();

            GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
            GWPaymentWay.DataBind();
        }
    }
    protected void DRPBaseInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (DRPBaseInfo.SelectedValue)
        {
            case "Rank":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(Rank);
                break;
            case "CountryProduct":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(CountryProduct);
                break;
            case "KindOffer":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(KindOffer);
                break;
            case "Quality":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(Quality);
                break;
            case "Subtitles":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(Subtitles);
                break;
            case "Genre":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(Genre);
                break;
            case "Language":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(Language);
                break;
            case "DVDKind":
                MultiViewBaseInfo.Visible = true;
                MultiViewBaseInfo.SetActiveView(DVDKind);
                break;
            case "TransmissionKind":
                if (User.IsInRole("SuperAdmin"))
                {
                    MultiViewBaseInfo.Visible = true;
                    MultiViewBaseInfo.SetActiveView(TransmissionKind);
                }
                else
                {
                    MultiViewBaseInfo.Visible = true;
                    MultiViewBaseInfo.SetActiveView(vError);
                }
                break;
            case "PaymentWay":
                if (User.IsInRole("SuperAdmin"))
                {
                    MultiViewBaseInfo.Visible = true;
                    MultiViewBaseInfo.SetActiveView(PaymentWay);
                }
                else
                {
                    MultiViewBaseInfo.Visible = true;
                    MultiViewBaseInfo.SetActiveView(vError);
                }
                break;
            default:
                MultiViewBaseInfo.Visible = false;
                break;
        }
    }

    #region Rank
    protected void GWRank_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleRankDS.vSingleRankDataTable dt = new SingleRankDS.vSingleRankDataTable();
        dt = new RankBL().GetAll();
        dt.FindByfldRankID(short.Parse(((Label)GWRank.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new RankBL().Update(ref dt);

        GWRank.DataSource = ObjectDataSourceRank.Select();
        GWRank.DataBind();
    }
    protected void GWRank_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleRankDS.vSingleRankDataTable dt = new SingleRankDS.vSingleRankDataTable();
        dt = new RankBL().GetAll();
        dt.FindByfldRankID(short.Parse(((TextBox)GWRank.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldRankNameColumn] = ((TextBox)GWRank.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new RankBL().Update(ref dt);

        GWRank.EditIndex = -1;
        GWRank.DataSource = ObjectDataSourceRank.Select();
        GWRank.DataBind();
    }
    protected void GWRank_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWRank.EditIndex = e.NewEditIndex;

        GWRank.DataSource = ObjectDataSourceRank.Select();
        GWRank.DataBind();
    }
    protected void GWRank_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWRank.EditIndex = -1;

        GWRank.DataSource = ObjectDataSourceRank.Select();
        GWRank.DataBind();
    }
    protected void IBRank_Click(object sender, ImageClickEventArgs e)
    {
        SingleRankDS.vSingleRankDataTable dt = new SingleRankDS.vSingleRankDataTable();
        SingleRankDS.vSingleRankRow rankRow = dt.NewvSingleRankRow();
        rankRow.fldRankName = TXTRankName.Text;
        dt.AddvSingleRankRow(rankRow);
        new RankBL().Update(ref dt);

        GWRank.DataSource = ObjectDataSourceRank.Select();
        GWRank.DataBind();
    }
    #endregion
    #region CountryProduct
    protected void GWCountryProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleCountryProductDS.vSingleCountryProductDataTable dt = new SingleCountryProductDS.vSingleCountryProductDataTable();
        dt = new CountryProductBL().GetAll();
        dt.FindByfldCountryProductID(short.Parse(((Label)GWCountryProduct.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new CountryProductBL().Update(ref dt);

        GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
        GWCountryProduct.DataBind();
    }
    protected void GWCountryProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleCountryProductDS.vSingleCountryProductDataTable dt = new SingleCountryProductDS.vSingleCountryProductDataTable();
        dt = new CountryProductBL().GetAll();
        dt.FindByfldCountryProductID(short.Parse(((TextBox)GWCountryProduct.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldCountryProductNameColumn] = ((TextBox)GWCountryProduct.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new CountryProductBL().Update(ref dt);

        GWCountryProduct.EditIndex = -1;
        GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
        GWCountryProduct.DataBind();
    }
    protected void GWCountryProduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWCountryProduct.EditIndex = e.NewEditIndex;

        GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
        GWCountryProduct.DataBind();
    }
    protected void GWCountryProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWCountryProduct.EditIndex = -1;

        GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
        GWCountryProduct.DataBind();
    }
    protected void IBCountryProduct_Click(object sender, ImageClickEventArgs e)
    {
        SingleCountryProductDS.vSingleCountryProductDataTable dt = new SingleCountryProductDS.vSingleCountryProductDataTable();
        SingleCountryProductDS.vSingleCountryProductRow row = dt.NewvSingleCountryProductRow();
        row.fldCountryProductName = TXTCountryProductName.Text;
        dt.AddvSingleCountryProductRow(row);
        new CountryProductBL().Update(ref dt);

        GWCountryProduct.DataSource = ObjectDataSourceCountryProduct.Select();
        GWCountryProduct.DataBind();
    }
    #endregion
    #region KindOffer
    protected void GWKindOffer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleKindOfferDS.vSingleKindOfferDataTable dt = new SingleKindOfferDS.vSingleKindOfferDataTable();
        dt = new KindOfferBL().GetAll();
        dt.FindByfldKindOfferID(short.Parse(((Label)GWKindOffer.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new KindOfferBL().Update(ref dt);

        GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
        GWKindOffer.DataBind();
    }
    protected void GWKindOffer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleKindOfferDS.vSingleKindOfferDataTable dt = new SingleKindOfferDS.vSingleKindOfferDataTable();
        dt = new KindOfferBL().GetAll();
        dt.FindByfldKindOfferID(short.Parse(((TextBox)GWKindOffer.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldKindOfferNameColumn] = ((TextBox)GWKindOffer.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new KindOfferBL().Update(ref dt);

        GWKindOffer.EditIndex = -1;
        GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
        GWKindOffer.DataBind();
    }
    protected void GWKindOffer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWKindOffer.EditIndex = e.NewEditIndex;

        GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
        GWKindOffer.DataBind();
    }
    protected void GWKindOffer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWKindOffer.EditIndex = -1;

        GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
        GWKindOffer.DataBind();
    }
    protected void IBKindOffer_Click(object sender, ImageClickEventArgs e)
    {
        SingleKindOfferDS.vSingleKindOfferDataTable dt = new SingleKindOfferDS.vSingleKindOfferDataTable();
        SingleKindOfferDS.vSingleKindOfferRow row = dt.NewvSingleKindOfferRow();
        row.fldKindOfferName = TXTKindOfferName.Text;
        dt.AddvSingleKindOfferRow(row);
        new KindOfferBL().Update(ref dt);

        GWKindOffer.DataSource = ObjectDataSourceKindOffer.Select();
        GWKindOffer.DataBind();
    }
    #endregion
    #region Quality
    protected void GWQuality_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleQualityDS.vSingleQualityDataTable dt = new SingleQualityDS.vSingleQualityDataTable();
        dt = new QualityBL().GetAll();
        dt.FindByfldQualityID(short.Parse(((Label)GWQuality.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new QualityBL().Update(ref dt);

        GWQuality.DataSource = ObjectDataSourceQuality.Select();
        GWQuality.DataBind();
    }
    protected void GWQuality_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleQualityDS.vSingleQualityDataTable dt = new SingleQualityDS.vSingleQualityDataTable();
        dt = new QualityBL().GetAll();
        dt.FindByfldQualityID(short.Parse(((TextBox)GWQuality.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldQualityNameColumn] = ((TextBox)GWQuality.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new QualityBL().Update(ref dt);

        GWQuality.EditIndex = -1;
        GWQuality.DataSource = ObjectDataSourceQuality.Select();
        GWQuality.DataBind();
    }
    protected void GWQuality_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWQuality.EditIndex = e.NewEditIndex;

        GWQuality.DataSource = ObjectDataSourceQuality.Select();
        GWQuality.DataBind();
    }
    protected void GWQuality_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWQuality.EditIndex = -1;

        GWQuality.DataSource = ObjectDataSourceQuality.Select();
        GWQuality.DataBind();
    }
    protected void IBQuality_Click(object sender, ImageClickEventArgs e)
    {
        SingleQualityDS.vSingleQualityDataTable dt = new SingleQualityDS.vSingleQualityDataTable();
        SingleQualityDS.vSingleQualityRow row = dt.NewvSingleQualityRow();
        row.fldQualityName = TXTQualityName.Text;
        dt.AddvSingleQualityRow(row);
        new QualityBL().Update(ref dt);

        GWQuality.DataSource = ObjectDataSourceQuality.Select();
        GWQuality.DataBind();
    }
    #endregion
    #region Subtitles
    protected void GWSubtitles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleSubtitlesDS ds = new SingleSubtitlesDS();
        ds = new SingleSubtitlesBL().GetAll();
        ds.vSingleSubtitles.FindByfldSubtitlesID(short.Parse(((Label)GWSubtitles.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleSubtitlesBL().Update(ref ds);

        GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
        GWSubtitles.DataBind();
    }
    protected void GWSubtitles_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleSubtitlesDS ds = new SingleSubtitlesDS();
        ds = new SingleSubtitlesBL().GetAll();
        ds.vSingleSubtitles.FindByfldSubtitlesID(short.Parse(((TextBox)GWSubtitles.Rows[e.RowIndex].FindControl("TextBox1")).Text))[ds.vSingleSubtitles.fldSubtitlesNameColumn] = ((TextBox)GWSubtitles.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new SingleSubtitlesBL().Update(ref ds);

        GWSubtitles.EditIndex = -1;
        GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
        GWSubtitles.DataBind();
    }
    protected void GWSubtitles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWSubtitles.EditIndex = e.NewEditIndex;

        GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
        GWSubtitles.DataBind();
    }
    protected void GWSubtitles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWSubtitles.EditIndex = -1;

        GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
        GWSubtitles.DataBind();
    }
    protected void IBSubtitles_Click(object sender, ImageClickEventArgs e)
    {
        SingleSubtitlesDS ds = new SingleSubtitlesDS();
        SingleSubtitlesDS.vSingleSubtitlesRow row = ds.vSingleSubtitles.NewvSingleSubtitlesRow();
        row.fldSubtitlesName = TXTSubtitlesName.Text;
        ds.vSingleSubtitles.AddvSingleSubtitlesRow(row);
        new SingleSubtitlesBL().Update(ref ds);

        GWSubtitles.DataSource = ObjectDataSourceSubtitles.Select();
        GWSubtitles.DataBind();
    }
    #endregion
    #region Genre
    protected void GWGenre_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleGenreDS.vSingleGenreDataTable dt = new SingleGenreDS.vSingleGenreDataTable();
        dt = new GenreBL().GetAll();
        dt.FindByfldGenreID(short.Parse(((Label)GWGenre.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new GenreBL().Update(ref dt);

        GWGenre.DataSource = ObjectDataSourceGenre.Select();
        GWGenre.DataBind();
    }
    protected void GWGenre_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleGenreDS.vSingleGenreDataTable dt = new SingleGenreDS.vSingleGenreDataTable();
        dt = new GenreBL().GetAll();
        dt.FindByfldGenreID(short.Parse(((TextBox)GWGenre.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldGenreNameColumn] = ((TextBox)GWGenre.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new GenreBL().Update(ref dt);

        GWGenre.EditIndex = -1;
        GWGenre.DataSource = ObjectDataSourceGenre.Select();
        GWGenre.DataBind();
    }
    protected void GWGenre_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWGenre.EditIndex = e.NewEditIndex;

        GWGenre.DataSource = ObjectDataSourceGenre.Select();
        GWGenre.DataBind();
    }
    protected void GWGenre_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWGenre.EditIndex = -1;

        GWGenre.DataSource = ObjectDataSourceGenre.Select();
        GWGenre.DataBind();
    }
    protected void IBGenre_Click(object sender, ImageClickEventArgs e)
    {
        SingleGenreDS.vSingleGenreDataTable dt = new SingleGenreDS.vSingleGenreDataTable();
        SingleGenreDS.vSingleGenreRow row = dt.NewvSingleGenreRow();
        row.fldGenreName = TXTGenreName.Text;
        dt.AddvSingleGenreRow(row);
        new GenreBL().Update(ref dt);

        GWGenre.DataSource = ObjectDataSourceGenre.Select();
        GWGenre.DataBind();
    }
    #endregion
    #region Language
    protected void GWLanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleLanguageDS.vSingleLanguageDataTable dt = new SingleLanguageDS.vSingleLanguageDataTable();
        dt = new LanguageBL().GetAll();
        dt.FindByfldLanguageID(short.Parse(((Label)GWLanguage.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new LanguageBL().Update(ref dt);

        GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
        GWLanguage.DataBind();
    }
    protected void GWLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleLanguageDS.vSingleLanguageDataTable dt = new SingleLanguageDS.vSingleLanguageDataTable();
        dt = new LanguageBL().GetAll();
        dt.FindByfldLanguageID(short.Parse(((TextBox)GWLanguage.Rows[e.RowIndex].FindControl("TextBox1")).Text))[dt.fldLanguageNameColumn] = ((TextBox)GWLanguage.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        new LanguageBL().Update(ref dt);

        GWLanguage.EditIndex = -1;
        GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
        GWLanguage.DataBind();
    }
    protected void GWLanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWLanguage.EditIndex = e.NewEditIndex;

        GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
        GWLanguage.DataBind();
    }
    protected void GWLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWLanguage.EditIndex = -1;

        GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
        GWLanguage.DataBind();
    }
    protected void IBLanguage_Click(object sender, ImageClickEventArgs e)
    {
        SingleLanguageDS.vSingleLanguageDataTable dt = new SingleLanguageDS.vSingleLanguageDataTable();
        SingleLanguageDS.vSingleLanguageRow row = dt.NewvSingleLanguageRow();
        row.fldLanguageName = TXTLanguageName.Text;
        dt.AddvSingleLanguageRow(row);
        new LanguageBL().Update(ref dt);

        GWLanguage.DataSource = ObjectDataSourceLanguage.Select();
        GWLanguage.DataBind();
    }
    #endregion
    #region DVDKind
    protected void GWDVDKind_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleDVDKindDS ds = new SingleDVDKindDS();
        ds = new SingleDVDKindBL().GetAll();
        ds.vSingleDVDKind.FindByfldDVDKindID(short.Parse(((Label)GWDVDKind.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleDVDKindBL().Update(ref ds);

        GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
        GWDVDKind.DataBind();
    }
    protected void GWDVDKind_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleDVDKindDS ds = new SingleDVDKindDS();
        ds = new SingleDVDKindBL().GetAll();
        SingleDVDKindDS.vSingleDVDKindRow row = ds.vSingleDVDKind.FindByfldDVDKindID(short.Parse(((TextBox)GWDVDKind.Rows[e.RowIndex].FindControl("TextBox1")).Text));
        row[ds.vSingleDVDKind.fldDVDKindNameColumn] = ((TextBox)GWDVDKind.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        row[ds.vSingleDVDKind.fldDVDKindPriceColumn] = int.Parse(((TextBox)GWDVDKind.Rows[e.RowIndex].FindControl("TextBox3")).Text, NumberStyles.Number);
        new SingleDVDKindBL().Update(ref ds);

        GWDVDKind.EditIndex = -1;
        GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
        GWDVDKind.DataBind();
    }
    protected void GWDVDKind_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWDVDKind.EditIndex = e.NewEditIndex;

        GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
        GWDVDKind.DataBind();
    }
    protected void GWDVDKind_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWDVDKind.EditIndex = -1;

        GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
        GWDVDKind.DataBind();
    }
    protected void IBDVDKind_Click(object sender, ImageClickEventArgs e)
    {
        SingleDVDKindDS ds = new SingleDVDKindDS();
        SingleDVDKindDS.vSingleDVDKindRow row = ds.vSingleDVDKind.NewvSingleDVDKindRow();
        row.fldDVDKindName = TXTDVDKindName.Text;
        row.fldDVDKindPrice = int.Parse(TXTDVDKindPrice.Text.Trim().IndexOf(',') < 1 ? TXTDVDKindPrice.Text.Trim() : TXTDVDKindPrice.Text.Trim().Remove(TXTDVDKindPrice.Text.Trim().IndexOf(','), 1));
        ds.vSingleDVDKind.AddvSingleDVDKindRow(row);
        new SingleDVDKindBL().Update(ref ds);

        GWDVDKind.DataSource = ObjectDataSourceDVDKind.Select();
        GWDVDKind.DataBind();
    }
    #endregion
    #region TransmissionKind
    protected void GWTransmissionKind_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleTransmissionKindDS ds = new SingleTransmissionKindDS();
        ds = new SingleTransmissionKindBL().GetAll();
        ds.vSingleTransmissionKind.FindByfldTransmissionKindID(short.Parse(((Label)GWTransmissionKind.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleTransmissionKindBL().Update(ref ds);

        GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
        GWTransmissionKind.DataBind();
    }
    protected void GWTransmissionKind_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleTransmissionKindDS ds = new SingleTransmissionKindDS();
        ds = new SingleTransmissionKindBL().GetAll();

        SingleTransmissionKindDS.vSingleTransmissionKindRow row = ds.vSingleTransmissionKind.FindByfldTransmissionKindID(short.Parse(((TextBox)GWTransmissionKind.Rows[e.RowIndex].FindControl("TextBox1")).Text));
        row[ds.vSingleTransmissionKind.fldTransmissionKindNameColumn] = ((TextBox)GWTransmissionKind.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        row[ds.vSingleTransmissionKind.fldTransmissionKindPriceColumn] = int.Parse(((TextBox)GWTransmissionKind.Rows[e.RowIndex].FindControl("TextBox3")).Text, NumberStyles.Number);
        
        new SingleTransmissionKindBL().Update(ref ds);

        GWTransmissionKind.EditIndex = -1;
        GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
        GWTransmissionKind.DataBind();
    }
    protected void GWTransmissionKind_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWTransmissionKind.EditIndex = e.NewEditIndex;

        GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
        GWTransmissionKind.DataBind();
    }
    protected void GWTransmissionKind_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWTransmissionKind.EditIndex = -1;

        GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
        GWTransmissionKind.DataBind();
    }
    protected void IBTransmissionKind_Click(object sender, ImageClickEventArgs e)
    {
        SingleTransmissionKindDS ds = new SingleTransmissionKindDS();
        SingleTransmissionKindDS.vSingleTransmissionKindRow row = ds.vSingleTransmissionKind.NewvSingleTransmissionKindRow();
        row.fldTransmissionKindName = TXTTransmissionKindName.Text;
        row.fldTransmissionKindPrice = int.Parse(TXTTransmissionKindPrice.Text.Trim().IndexOf(',') < 1 ? TXTTransmissionKindPrice.Text.Trim() : TXTTransmissionKindPrice.Text.Trim().Remove(TXTTransmissionKindPrice.Text.Trim().IndexOf(','), 1));
        ds.vSingleTransmissionKind.AddvSingleTransmissionKindRow(row);
        new SingleTransmissionKindBL().Update(ref ds);

        GWTransmissionKind.DataSource = ObjectDataSourceTransmissionKind.Select();
        GWTransmissionKind.DataBind();
    }
    #endregion
    #region PaymentWay
    protected void GWPaymentWay_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SinglePaymentWayDS ds = new SinglePaymentWayDS();
        ds = new SinglePaymentWayBL().GetAll();
        ds.vSinglePaymentWay.FindByfldPaymentWayID(short.Parse(((Label)GWPaymentWay.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SinglePaymentWayBL().Update(ref ds);

        GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
        GWPaymentWay.DataBind();
    }
    protected void GWPaymentWay_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SinglePaymentWayDS ds = new SinglePaymentWayDS();
        ds = new SinglePaymentWayBL().GetAll();

        SinglePaymentWayDS.vSinglePaymentWayRow row = ds.vSinglePaymentWay.FindByfldPaymentWayID(short.Parse(((TextBox)GWPaymentWay.Rows[e.RowIndex].FindControl("TextBox1")).Text));
        row[ds.vSinglePaymentWay.fldPaymentWayNameColumn] = ((TextBox)GWPaymentWay.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        row[ds.vSinglePaymentWay.fldPaymentWayPageColumn] = ((TextBox)GWPaymentWay.Rows[e.RowIndex].FindControl("TextBox3")).Text;

        new SinglePaymentWayBL().Update(ref ds);

        GWPaymentWay.EditIndex = -1;
        GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
        GWPaymentWay.DataBind();
    }
    protected void GWPaymentWay_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWPaymentWay.EditIndex = e.NewEditIndex;

        GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
        GWPaymentWay.DataBind();
    }
    protected void GWPaymentWay_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWPaymentWay.EditIndex = -1;

        GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
        GWPaymentWay.DataBind();
    }
    protected void IBPaymentWay_Click(object sender, ImageClickEventArgs e)
    {
        SinglePaymentWayDS ds = new SinglePaymentWayDS();
        SinglePaymentWayDS.vSinglePaymentWayRow row = ds.vSinglePaymentWay.NewvSinglePaymentWayRow();
        row.fldPaymentWayName = TXTPaymentWayName.Text;
        row.fldPaymentWayPage = TXTPaymentWayPage.Text;
        ds.vSinglePaymentWay.AddvSinglePaymentWayRow(row);
        new SinglePaymentWayBL().Update(ref ds);

        GWPaymentWay.DataSource = ObjectDataSourcePaymentWay.Select();
        GWPaymentWay.DataBind();
    }
    #endregion
}
