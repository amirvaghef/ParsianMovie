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
using System.Globalization;
using Common;
using Business;
using Common.Data;
using Persia;
using System.Net.Mail;

public partial class PUsers_Saderat : System.Web.UI.Page
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

            //Amount.Value = int.Parse(LBPriceKol.Text, NumberStyles.Number).ToString();
            //MID.Value = "00245034-41265";
            //ResNum.Value = Guid.NewGuid().ToString();
            //RedirectURL.Value = "http://www.parsianmovie.com/PUsers/SamanEPaymentRedirect.aspx";

            //Session.Add("Amount", int.Parse(LBPriceKol.Text, NumberStyles.Number));
            //Session.Add("DVDKind", Request.QueryString["DVDKind"]);
            //Session.Add("PaymentWay", Request.QueryString["PaymentWay"]);
            //Session.Add("TransmissionKind", Request.QueryString["TransmissionKind"]);

        }
    }
    protected void IBBuy_Click(object sender, ImageClickEventArgs e)
    {
        Guid ResNum = Guid.NewGuid();
        int Amount = int.Parse(LBPriceKol.Text, NumberStyles.Number);

        RequestDS requestDS = new RequestDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
        requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);

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

            requestDS.vRequest.Rows[i][requestDS.vRequest.fldfk_BuyIDColumn] = ResNum;
        }

        SingleBuyDS singleBuyDS = new SingleBuyDS();
        SingleBuyDS.vSingleBuyRow singleBuyRow = singleBuyDS.vSingleBuy.NewvSingleBuyRow();
        singleBuyRow.fldBuyDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
        singleBuyRow.fldBuyID = ResNum;
        singleBuyRow.fldfk_DVDKindID = short.Parse(Request.QueryString["DVDKind"].ToString());
        singleBuyRow.fldfk_PaymentWayID = short.Parse(Request.QueryString["PaymentWay"].ToString());
        singleBuyRow.fldfk_TransmissionKindID = short.Parse(Request.QueryString["TransmissionKind"].ToString());
        singleBuyRow.fldPrice = Amount;
        singleBuyRow.fldReferenceNumber = TXTFishNumber.Text;
        singleBuyDS.vSingleBuy.AddvSingleBuyRow(singleBuyRow);

        new BuyDetailBL().Update(ref singleBuyDS, ref requestDS);

        #region Sending Email
        MailMessage objMessage = new MailMessage();
        objMessage.Subject = "::ParsianMovie::";
        objMessage.From = new MailAddress("info@parsianmovie.com");

        MembershipUser currentUser = Membership.GetUser(User.Identity.Name);
        string[] adminUsersTemp1 = Roles.GetUsersInRole("SuperAdmin");
        string[] adminUsersTemp2 = Roles.GetUsersInRole("Admin");
        string[] adminUsers = new string[adminUsersTemp1.Length + adminUsersTemp2.Length];
        adminUsersTemp1.CopyTo(adminUsers, 0);
        adminUsersTemp2.CopyTo(adminUsers, adminUsersTemp1.Length);
        objMessage.To.Add(new MailAddress(currentUser.Email));
        foreach (string user in adminUsers)
        {
            objMessage.To.Add(Membership.GetUser(user).Email);
        }

        #region Set Body of Email
        string body = "<html><head><meta http-equiv=\"Content-Language\" content=\"en-us\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
            "<title>ParsianMovie</title></head><body dir=\"rtl\"  style=\"margin: 0; padding: 0; font-family: Tahoma, Verdana, Arial, Times, san-serif; font-size: 13px; " +
            "color: #fff; background-color: #530200;\"><table style=\"width: 800px\" cellspacing=\"0\" cellpadding=\"0\" dir=\"rtl\" align=\"center\">	<tr>		" +
            "<td colspan=\"2\" align=\"center\" style=\" font-family:'Showcard Gothic'; font-size:32px; font-weight:bold; color:#FFFFFF;\">Parsian Movie <br/> <br /></td>" +
            "	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">نام کاربری :&nbsp;";
        body += User.Identity.Name;
        body += "</span></td>	</tr>	<tr>		<td><span lang=\"fa\">نام و نام خانوادگی :&nbsp;";
        body += requestDS.vRequest.Rows[0][requestDS.vRequest.fldNameColumn].ToString() + " " + requestDS.vRequest.Rows[0][requestDS.vRequest.fldFamilyColumn].ToString();
        body += "</span></td>		<td><span lang=\"fa\">آدرس ایمیل :&nbsp;";
        body += currentUser.Email;
        body += "</span></td>	</tr>	<tr>		<td><span lang=\"fa\">شماره همراه :&nbsp;";
        body += requestDS.vRequest.Rows[0][requestDS.vRequest.fldMobilePhoneColumn].ToString();
        body += "</span></td>		<td><span lang=\"fa\">شماره تماس :&nbsp;";
        body += requestDS.vRequest.Rows[0][requestDS.vRequest.fldTelColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">آدرس :&nbsp;";
        body += requestDS.vRequest.Rows[0][requestDS.vRequest.fldAddressColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">کد پستی :&nbsp;";
        body += requestDS.vRequest.Rows[0][requestDS.vRequest.fldPostalCodeColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\">		<table style=\"width: 95%\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">" +
            "			<tr>				<td width=\"9%\" align=\"center\"><span lang=\"fa\">شماره</span></td>				<td width=\"8%\" align=\"center\"><span lang=\"fa\">نوع</span></td>" +
            "	<td width=\"33%\" align=\"center\"><span lang=\"fa\">نام اصلی</span></td>				<td width=\"33%\" align=\"center\"><span lang=\"fa\">نام فارسی</span></td>" +
            "				<td width=\"7%\" align=\"center\"><span lang=\"fa\">تعداد بخش</span></td>				<td width=\"10%\" align=\"center\"><span lang=\"fa\">قیمت</span></td>			</tr>";
        for (int i = 0; i < requestDS.vRequest.Count; i++)
        {
            body += "<tr>				<td width=\"9%\"><span lang=\"fa\">";
            body += requestDS.vRequest.Rows[i][requestDS.vRequest.fldFilmIDColumn].ToString();
            body += "</span></td>				<td width=\"8%\"><span lang=\"fa\">";
            body += requestDS.vRequest.Rows[i][requestDS.vRequest.fldKindOfferNameColumn].ToString();
            body += "</span></td>				<td width=\"33%\"><span lang=\"fa\">";
            body += requestDS.vRequest.Rows[i][requestDS.vRequest.fldEnglishNameColumn].ToString();
            body += "</span></td>				<td width=\"33%\"><span lang=\"fa\">";
            body += requestDS.vRequest.Rows[i][requestDS.vRequest.fldFarsiNameColumn].ToString();
            body += "</span></td>				<td width=\"7%\"><span lang=\"fa\">";
            body += requestDS.vRequest.Rows[i][requestDS.vRequest.fldSectionColumn].ToString();
            body += "</span></td>				<td width=\"10%\"><span lang=\"fa\">";
            body += String.Format("{0:#,###}", int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString()));
            body += "</span></td>			</tr>";
        }
        body += "</table>		</td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">قیمت فیلم ها :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(sum.ToString()));
        body += "&nbsp;		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">روش ارسال :&nbsp;";
        SingleTransmissionKindDS singleTransmissionKindDS = new SingleTransmissionKindDS();
        singleTransmissionKindDS = new SingleTransmissionKindBL().GetByID(Request.QueryString["TransmissionKind"]);
        body += singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindNameColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ ارسال :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>		</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">نوع دی وی دی : </span>&nbsp;";
        SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
        singleDVDKindDS = new SingleDVDKindBL().GetByID(Request.QueryString["DVDKind"]);
        body += singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindNameColumn].ToString();
        body += "</td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">تعداد&nbsp;";
        body += ((double)Math.Ceiling(dvdNumber / 5)).ToString();
        body += "&nbsp; عدد *&nbsp; 		هر عدد&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindPriceColumn].ToString()));
        body += "&nbsp; ریال = مبلغ دی وی دی ها :&nbsp;";
        int DVDs = int.Parse(singleDVDKindDS.vSingleDVDKind.Rows[0][singleDVDKindDS.vSingleDVDKind.fldDVDKindPriceColumn].ToString()) * int.Parse(((double)Math.Ceiling(dvdNumber / 5)).ToString());
        body += String.Format("{0:#,###}", int.Parse(DVDs.ToString()));
        body += "&nbsp; ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">روش پرداخت :&nbsp;";
        SinglePaymentWayDS singlePaymentWayDS = new SinglePaymentWayDS();
        singlePaymentWayDS = new SinglePaymentWayBL().GetByID(Request.QueryString["PaymentWay"]);
        body += singlePaymentWayDS.vSinglePaymentWay.Rows[0][singlePaymentWayDS.vSinglePaymentWay.fldPaymentWayNameColumn].ToString() + " -" + TXTFishNumber.Text + "- ";
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ کل :&nbsp;";
        int kol = int.Parse(sum.ToString()) + int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()) + int.Parse(DVDs.ToString());
        body += String.Format("{0:#,###}", int.Parse(kol.ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ پرداختی :&nbsp;";
        body += String.Format("{0:#,###}", Amount);
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\" style=\"color:#FF0000\">* با تشکر از خرید شما اگر با مشکلی مواجه " +
            "		شده اید و یا سوالی دارید برای تماس با ما تعلل نفرمائید.<br />        (09354340109 یوسفی, <a href=\"mailto:info@ParsianMovie.com\">info@ParsianMovie.com</a>)</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">به امید دیدار دوباره شما&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " +
            "		مدیر سایت پارسیان مووی</span></td>	</tr></table></body></html>";
        #endregion

        objMessage.IsBodyHtml = true;
        objMessage.BodyEncoding = System.Text.Encoding.UTF8;
        objMessage.Body = body;

        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new System.Net.NetworkCredential("info@parsianmovie.com", "nirvana12248");
        smtp.EnableSsl = false;
        smtp.Host = "mail.parsianmovie.com";
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(objMessage);
        #endregion
        Response.Redirect("~/index.aspx");
    }
}
