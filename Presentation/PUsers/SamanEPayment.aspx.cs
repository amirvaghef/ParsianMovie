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
using System.Web.Mail;
using System.Globalization;

public partial class PUsers_SamanEPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            #region BindData
            RequestDS requestDS = new RequestDS();
            SearchFilter sf = new SearchFilter();
            sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
            requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);

            SingleTransmissionKindDS singleTransmissionKindDS = new SingleTransmissionKindDS();
            singleTransmissionKindDS = new SingleTransmissionKindBL().GetByID(Request.QueryString["TransmissionKind"]);
            LBTransmissionKind.Text = singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindNameColumn].ToString();
            LBPriceTransmissionKind.Text = String.Format("{0:#,###}", int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()));
            
            SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
            singleDVDKindDS = new SingleDVDKindBL().GetByID(Request.QueryString["DVDKind"]);
            LBDVDKind.Text = singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindNameColumn].ToString();
            LBPriceOneDVD.Text = String.Format("{0:#,###}", int.Parse(singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindPriceColumn].ToString()));

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
            LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString()));

            LBDVDNumber.Text = ((double)Math.Ceiling(dvdNumber / 5)).ToString();
            #region PriceDVDs
            int DVDs = int.Parse(LBPriceOneDVD.Text, NumberStyles.Number) * int.Parse(LBDVDNumber.Text);
            LBPriceDVDKind.Text = String.Format("{0:#,###}", int.Parse(DVDs.ToString()));
            #endregion


            #region PriceKol
            int kol = int.Parse(LBPriceFilms.Text, NumberStyles.Number) + int.Parse(LBPriceTransmissionKind.Text, NumberStyles.Number) + int.Parse(LBPriceDVDKind.Text, NumberStyles.Number);
            LBPriceKol.Text = String.Format("{0:#,###}", int.Parse(kol.ToString()));
            #endregion

            #endregion

            Amount.Value = int.Parse(LBPriceKol.Text, NumberStyles.Number).ToString();
            MID.Value = "00245034-41265";
            ResNum.Value = Guid.NewGuid().ToString();
            RedirectURL.Value = "http://www.parsianmovie.com/PUsers/SamanEPaymentRedirect.aspx";

            Session.Add("Amount", int.Parse(LBPriceKol.Text, NumberStyles.Number));
            Session.Add("DVDKind", Request.QueryString["DVDKind"]);
            Session.Add("PaymentWay", Request.QueryString["PaymentWay"]);
            Session.Add("TransmissionKind", Request.QueryString["TransmissionKind"]);

        }
    }
}
