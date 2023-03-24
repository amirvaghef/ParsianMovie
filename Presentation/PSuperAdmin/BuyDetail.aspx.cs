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
using Business;
using Common.Data;
using Persia;

public partial class PSuperAdmin_BuyDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int Amount = int.Parse(LBPriceKol.Text, NumberStyles.Number);

        RequestBuyDS requestDS = new RequestBuyDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.vRequestBuy.fldfk_BuyIDColumn, FilterOperation.Equal, Request.QueryString["BuyID"]));
        requestDS = new RequestBuyBL().GetByFilter(sf, requestDS.vRequestBuy.fldFilmIDColumn);

        int sum = 0;
        double dvdNumber = 0;
        for (int i = 0; i < requestDS.vRequestBuy.Count; i++)
        {
            if ((requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldKindOfferNameColumn].ToString() == KindOfferEnum.DIVX.ToString()))
                dvdNumber += double.Parse(requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldSectionColumn].ToString());
            if ((requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldKindOfferNameColumn].ToString() == KindOfferEnum.MKV.ToString()))
                dvdNumber += double.Parse(requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldSectionColumn].ToString());
            if ((requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldKindOfferNameColumn].ToString() == KindOfferEnum.DVD.ToString()))
                dvdNumber += double.Parse(requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldSectionColumn].ToString()) * 5;
            sum += int.Parse(requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldPriceColumn].ToString());
        }

        BuyDS buyDS = new BuyDS();
        SearchFilter sBuySF = new SearchFilter();
        sBuySF.AddFilter(new FilterDefinition(buyDS.vBuy.fldBuyIDColumn, FilterOperation.Equal, Request.QueryString["BuyID"]));
        buyDS = new BuyDetailBL().GetByFilter(sBuySF, buyDS.vBuy.fldBuyDateColumn);

        //SingleBuyDS.vSingleBuyRow singleBuyRow = singleBuyDS.vSingleBuy.NewvSingleBuyRow();
        //singleBuyRow.fldBuyDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
        //singleBuyRow.fldBuyID = ResNum;
        //singleBuyRow.fldfk_DVDKindID = short.Parse(Request.QueryString["DVDKind"].ToString());
        //singleBuyRow.fldfk_PaymentWayID = short.Parse(Request.QueryString["PaymentWay"].ToString());
        //singleBuyRow.fldfk_TransmissionKindID = short.Parse("1");
        //singleBuyRow.fldPrice = Amount;
        //singleBuyRow.fldReferenceNumber = "Motorcycle";
        //singleBuyDS.vSingleBuy.AddvSingleBuyRow(singleBuyRow);

        //new BuyDetailBL().Update(ref singleBuyDS, ref requestDS);

        #region Set Body of Email
        string body = "<html><head><meta http-equiv=\"Content-Language\" content=\"en-us\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
            "<title>ParsianMovie</title></head><body dir=\"rtl\"  style=\"margin: 0; padding: 0; font-family: Tahoma, Verdana, Arial, Times, san-serif; font-size: 13px; " +
            "color: #fff; background-color: #530200;\"><table style=\"width: 800px\" cellspacing=\"0\" cellpadding=\"0\" dir=\"rtl\" align=\"center\">	<tr>		" +
            "<td colspan=\"2\" align=\"center\" style=\" font-family:'Showcard Gothic'; font-size:32px; font-weight:bold; color:#FFFFFF;\">Parsian Movie <br/> <br /></td>" +
            "	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">نام کاربری :&nbsp;";
        body += User.Identity.Name;
        body += "</span></td>	</tr>	<tr>		<td><span lang=\"fa\">نام و نام خانوادگی :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldNameColumn].ToString() + " " + requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldFamilyColumn].ToString();
        body += "</span></td>		<td><span lang=\"fa\">آدرس ایمیل :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldEmailColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td><span lang=\"fa\">شماره همراه :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldMobilePhoneColumn].ToString();
        body += "</span></td>		<td><span lang=\"fa\">شماره تماس :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldTelColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">آدرس :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldAddressColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">کد پستی :&nbsp;";
        body += requestDS.vRequestBuy.Rows[0][requestDS.vRequestBuy.fldPostalCodeColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\">		<table style=\"width: 95%\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">" +
            "			<tr>				<td width=\"9%\" align=\"center\"><span lang=\"fa\">شماره</span></td>				<td width=\"8%\" align=\"center\"><span lang=\"fa\">نوع</span></td>" +
            "	<td width=\"33%\" align=\"center\"><span lang=\"fa\">نام اصلی</span></td>				<td width=\"33%\" align=\"center\"><span lang=\"fa\">نام فارسی</span></td>" +
            "				<td width=\"7%\" align=\"center\"><span lang=\"fa\">تعداد بخش</span></td>				<td width=\"10%\" align=\"center\"><span lang=\"fa\">قیمت</span></td>			</tr>";
        for (int i = 0; i < requestDS.vRequestBuy.Count; i++)
        {
            body += "<tr>				<td width=\"9%\"><span lang=\"fa\">";
            body += requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldFilmIDColumn].ToString();
            body += "</span></td>				<td width=\"8%\"><span lang=\"fa\">";
            body += requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldKindOfferNameColumn].ToString();
            body += "</span></td>				<td width=\"33%\"><span lang=\"fa\">";
            body += requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldEnglishNameColumn].ToString();
            body += "</span></td>				<td width=\"33%\"><span lang=\"fa\">";
            body += requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldFarsiNameColumn].ToString();
            body += "</span></td>				<td width=\"7%\"><span lang=\"fa\">";
            body += requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldSectionColumn].ToString();
            body += "</span></td>				<td width=\"10%\"><span lang=\"fa\">";
            body += String.Format("{0:#,###}", int.Parse(requestDS.vRequestBuy.Rows[i][requestDS.vRequestBuy.fldPriceColumn].ToString()));
            body += "</span></td>			</tr>";
        }
        body += "</table>		</td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">قیمت فیلم ها :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(sum.ToString()));
        body += "&nbsp;		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">روش ارسال :&nbsp;";
        //SingleTransmissionKindDS singleTransmissionKindDS = new SingleTransmissionKindDS();
        //singleTransmissionKindDS = new SingleTransmissionKindBL().GetByID(1);
        body += buyDS.vBuy.Rows[0][buyDS.vBuy.fldTransmissionKindNameColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ ارسال :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(buyDS.vBuy.Rows[0][buyDS.vBuy.fldTransmissionKindPriceColumn].ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>		</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">نوع دی وی دی : </span>&nbsp;";
        //SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
        //singleDVDKindDS = new SingleDVDKindBL().GetByID(Request.QueryString["DVDKind"]);
        body += buyDS.vBuy.Rows[0][buyDS.vBuy.fldDVDKindNameColumn].ToString();
        body += "</td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">تعداد&nbsp;";
        body += ((double)Math.Ceiling(dvdNumber / 5)).ToString();
        body += "&nbsp; عدد *&nbsp; 		هر عدد&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(buyDS.vBuy.Rows[0][buyDS.vBuy.fldDVDKindPriceColumn].ToString()));
        body += "&nbsp; ریال = مبلغ دی وی دی ها :&nbsp;";
        int DVDs = int.Parse(buyDS.vBuy.Rows[0][buyDS.vBuy.fldDVDKindPriceColumn].ToString()) * int.Parse(((double)Math.Ceiling(dvdNumber / 5)).ToString());
        body += String.Format("{0:#,###}", int.Parse(DVDs.ToString()));
        body += "&nbsp; ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">روش پرداخت :&nbsp;";
        //SinglePaymentWayDS singlePaymentWayDS = new SinglePaymentWayDS();
        //singlePaymentWayDS = new SinglePaymentWayBL().GetByID(Request.QueryString["PaymentWay"]);
        body += buyDS.vBuy.Rows[0][buyDS.vBuy.fldPaymentWayNameColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ کل :&nbsp;";
        int kol = int.Parse(sum.ToString()) + int.Parse(buyDS.vBuy.Rows[0][buyDS.vBuy.fldTransmissionKindPriceColumn].ToString()) + int.Parse(DVDs.ToString());
        body += String.Format("{0:#,###}", int.Parse(kol.ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ پرداختی :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(kol.ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\" style=\"color:#FF0000\">* با تشکر از خرید شما اگر با مشکلی مواجه " +
            "		شده اید و یا سوالی دارید برای تماس با ما تعلل نفرمائید.<br />        (09354340109 یوسفی, <a href=\"mailto:info@ParsianMovie.com\">info@ParsianMovie.com</a>)</span></td>	</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">به امید دیدار دوباره شما&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " +
            "		مدیر سایت پارسیان مووی</span></td>	</tr></table></body></html>";
        #endregion
        DivBought.InnerHtml = body;
    }
}
