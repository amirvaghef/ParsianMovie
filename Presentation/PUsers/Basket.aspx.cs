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
using DataAccess;
using Common;
using Common.Data;
using Business;
using System.Globalization;
using Persia;

public partial class PUsers_Basket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        if (!IsPostBack)
        {
            CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            #region BindData
            RequestDS requestDS = new RequestDS();
            SearchFilter sf = new SearchFilter();
            sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
            requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);
            GWFilms.DataSource = requestDS.Tables[0];
            GWFilms.DataBind();

            int sum = 0;
            double dvdNumber = 0;
            for (int i = 0; i < requestDS.vRequest.Count; i++)
            {
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DIVX.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.MKV.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DVD.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString()) * 5;
                sum += int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString());
            }
            LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(sum.ToString()));

            #region PriceKol
            int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
            LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(kol.ToString()));
            #endregion

            LBDVDNumber.Text = ((double)Math.Ceiling(dvdNumber / 5)).ToString();
            #endregion

            SingleTransmissionKindDS singleTransmissionKindDS = new SingleTransmissionKindDS();
            singleTransmissionKindDS = new SingleTransmissionKindBL().GetAll();
            RBLTransmissionKind.DataSource = singleTransmissionKindDS.vSingleTransmissionKind;
            RBLTransmissionKind.DataTextField = singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindNameColumn.ColumnName;
            RBLTransmissionKind.DataValueField = singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindIDColumn.ColumnName;
            RBLTransmissionKind.DataBind();

            SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
            singleDVDKindDS = new SingleDVDKindBL().GetAll();
            RBLDVDKind.DataSource = singleDVDKindDS.vSingleDVDKind;
            RBLDVDKind.DataTextField = singleDVDKindDS.vSingleDVDKind.fldDVDKindNameColumn.ColumnName;
            RBLDVDKind.DataValueField = singleDVDKindDS.vSingleDVDKind.fldDVDKindIDColumn.ColumnName;
            RBLDVDKind.DataBind();

            SinglePaymentWayDS singlePaymentWayDS = new SinglePaymentWayDS();
            singlePaymentWayDS = new SinglePaymentWayBL().GetAll();
            RBLPaymentWay.DataSource = singlePaymentWayDS.vSinglePaymentWay;
            RBLPaymentWay.DataTextField = singlePaymentWayDS.vSinglePaymentWay.fldPaymentWayNameColumn.ColumnName;
            RBLPaymentWay.DataValueField = singlePaymentWayDS.vSinglePaymentWay.fldPaymentWayIDColumn.ColumnName;
            RBLPaymentWay.DataBind();
        }
    }
    protected void GWFilms_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region Delete & BindData
        RequestDS requestDS = new RequestDS();
        SearchFilter sf = new SearchFilter();

        sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));

        requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);

        requestDS.vRequest.Rows[e.RowIndex].Delete();
        new RequestBL().Update(ref requestDS);
        GWFilms.DataSource = requestDS.vRequest;
        GWFilms.DataBind();

        int sum = 0;
        double dvdNumber = 0;
        for (int i = 0; i < requestDS.vRequest.Count; i++)
        {
            if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DIVX.ToString()))
                dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
            if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.MKV.ToString()))
                dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
            if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DVD.ToString()))
                dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString()) * 5;
            sum += int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString());
        }
        LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(sum.ToString()));

        LBDVDNumber.Text = ((double)Math.Ceiling(dvdNumber / 5)).ToString();
        #region PriceDVDs
        int DVDs = int.Parse(LBPriceOneDVD.Text, NumberStyles.Number) * int.Parse(LBDVDNumber.Text);
        LBPriceDVDKind.Text = String.Format("{0:#,###}", int.Parse(DVDs.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(DVDs.ToString()));
        #endregion

        #region PriceKol
        int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
        LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(kol.ToString()));
        #endregion
        
        #endregion
    }
    protected void RBLTransmissionKind_SelectedIndexChanged(object sender, EventArgs e)
    {
        SingleTransmissionKindDS singleTransmissionKindDS = new SingleTransmissionKindDS();
        singleTransmissionKindDS = new SingleTransmissionKindBL().GetByID(RBLTransmissionKind.SelectedValue);
        LBPriceTransmissionKind.Text = String.Format("{0:#,###}", int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()));

        #region PriceKol
        int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
        LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(kol.ToString()));
        #endregion
    }
    protected void RBLDVDKind_SelectedIndexChanged(object sender, EventArgs e)
    {
        SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
        singleDVDKindDS = new SingleDVDKindBL().GetByID(RBLDVDKind.SelectedValue);
        LBPriceOneDVD.Text = String.Format("{0:#,###}", int.Parse(singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindPriceColumn].ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindPriceColumn].ToString()));

        int DVDs = int.Parse(LBPriceOneDVD.Text, NumberStyles.Number) * int.Parse(LBDVDNumber.Text);
        LBPriceDVDKind.Text = String.Format("{0:#,###}", int.Parse(DVDs.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(DVDs.ToString()));

        #region PriceKol
        int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
        LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(kol.ToString()));
        #endregion
    }
    protected void IBBuy_Click(object sender, ImageClickEventArgs e)
    {
        SinglePaymentWayDS singlePaymentWayDS = new SinglePaymentWayDS();
        singlePaymentWayDS = new SinglePaymentWayBL().GetByID(RBLPaymentWay.SelectedValue);
        Response.Redirect(singlePaymentWayDS.vSinglePaymentWay.Rows[0][singlePaymentWayDS.vSinglePaymentWay.fldPaymentWayPageColumn].ToString() + "?TransmissionKind=" + RBLTransmissionKind.SelectedValue + "&DVDKind=" + RBLDVDKind.SelectedValue + "&PaymentWay=" + RBLPaymentWay.SelectedValue);
    }
    protected void LBInsertFilm_OnClick(object sender, EventArgs e)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();
        sfDT = sfBL.GetByID(TXTFilmID.Text);

        if (sfDT.Rows.Count != 0)
        {
            SingleRequestDS requestDSAdd = new SingleRequestDS();

            SingleRequestDS.vSingleRequestRow requestRow = requestDSAdd.vSingleRequest.NewvSingleRequestRow();
            requestRow.fldRequestID = Guid.NewGuid();
            requestRow.fldRequestDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
            requestRow.fldPrice = int.Parse(sfDT[0][sfDT.fldPriceColumn].ToString(), NumberStyles.Number);
            requestRow.fldfk_Username = User.Identity.Name;
            requestRow.fldfk_FilmID = long.Parse(TXTFilmID.Text);
            requestDSAdd.vSingleRequest.AddvSingleRequestRow(requestRow);

            new SingleRequestBL().Update(ref requestDSAdd);

            #region BindData
            RequestDS requestDS = new RequestDS();
            SearchFilter sf = new SearchFilter();
            sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
            requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);
            GWFilms.DataSource = requestDS.Tables[0];
            GWFilms.DataBind();

            int sum = 0;
            double dvdNumber = 0;
            for (int i = 0; i < requestDS.vRequest.Count; i++)
            {
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DIVX.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.MKV.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString());
                if ((requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString() == KindOfferEnum.DVD.ToString()))
                    dvdNumber += double.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString()) * 5;
                sum += int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString());
            }
            LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(sum.ToString()));

            #region PriceKol
            int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
            LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(kol.ToString()));
            #endregion

            LBDVDNumber.Text = ((double)Math.Ceiling(dvdNumber / 5)).ToString();
            #endregion
        }
        else
            WithoutModalPopup.Show();

        TXTFilmID.Text = "";
    }
    protected void RBLPaymentWay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
