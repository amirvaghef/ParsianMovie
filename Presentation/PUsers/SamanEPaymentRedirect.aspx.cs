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
using com.sb24.acquirer;
using System.Net.Mail;

public partial class PUsers_SamanEPaymentRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //HLBuy.NavigateUrl = "SamanEPayment.aspx?TransmissionKind=" + Session["TransmissionKind"].ToString() + "&DVDKind=" + Session["DVDKind"].ToString() + "&PaymentWay=" + Session["PaymentWay"].ToString();

        string ResNum = Request.Form["ResNum"];
        string RefNum = Request.Form["RefNum"];
        string State = Request.Form["State"];

        double Amount = double.Parse(Session["Amount"].ToString());
        string MID = "00245034-41265";

        LBResNum.Text = "شماره خرید شما  " + ResNum + "  می باشد، لطفاً آنرا تا دریافت محصول به خاطر بسپارید.";

        int error = 0;
        if (State.ToLower() == "ok")
        {
            if (RefNum != "")
            {
                SearchFilter sf = new SearchFilter();
                sf.AddFilter(new FilterDefinition(new SingleBuyDS().vSingleBuy.fldReferenceNumberColumn, FilterOperation.Equal, RefNum));

                if (new SingleBuyBL().CountByFilter(sf) <= 0)
                {
                    try
                    {
                        ReferencePayment payment = new ReferencePayment();
                        double result = payment.verifyTransaction(RefNum, MID);

                        LBMessage.Text = result.ToString() + "---------" + Amount.ToString();
                        if (result == Amount)
                        {
                            InsertAndEmail();
                            LBMessage.Text = "خرید شما با موفقیت انجام شد.";
                            error = 0;
                        }
                        if (result < Amount)
                        {
                            payment.reverseTransaction(RefNum, MID, "351252", result);
                            LBMessage.Text = "مبلغ پرداختی از مبلغ فاکتور کمتر می باشد و کل سند پرداختی شما برگشت می خورد. خرید شما با شکست مواجه شد.";
                            error = 1;
                        }
                        if (result > Amount)
                        {
                            InsertAndEmail();
                            payment.reverseTransaction(RefNum, MID, "351252", result - Amount);
                            LBMessage.Text = "مبلغ پرداختی از مبلغ فاکتور بیشتر می باشد و ما به التفاوت آن به حساب شما برگشت خورده است. خرید شما با موفقیت انجام شد.";
                            error = 0;
                        }
                        if (result < 0)
                        {
                            switch (int.Parse(result.ToString()))
                            {
                                case -1: //TP_ERROR
                                    error = 1;
                                    LBMessage.Text = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -2:		//ACCOUNTS_DONT_MATCH
                                    error = 1;
                                    LBMessage.Text = "بروز خطا در هنگام تاييد رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -3:		//BAD_INPUT
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -4:		//INVALID_PASSWORD_OR_ACCOUNT
                                    error = 1;
                                    LBMessage.Text = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -5:		//DATABASE_EXCEPTION
                                    error = 1;
                                    LBMessage.Text = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -7:		//ERROR_STR_NULL
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -8:		//ERROR_STR_TOO_LONG
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -9:		//ERROR_STR_NOT_AL_NUM
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -10:	//ERROR_STR_NOT_BASE64
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                case -11:	//ERROR_STR_TOO_SHORT
                                    error = 1;
                                    LBMessage.Text = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                                default:
                                    error = 1;
                                    LBMessage.Text = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                                    break;
                            }
                            error = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    LBMessage.Text = "سیستم با مشکل مواجه شده است. لطفاً دوباره تلاش نمائید.";
                    error = 1;
                }
            }
            else
            {
                LBMessage.Text = "گويا خريد شما توسط بانک تاييد شده است اما رسيد ديجيتالي شما تاييد نگشت.";
                error = 1;
            }
        }
        else
        {
            switch (State.ToLower())
            {
                case "canceled by user":
                    error = 1;
                    LBMessage.Text = "تراکنش توسط خریدار کنسل شده است.";
                    break;
                case "invalid amount":
                    error = 1;
                    LBMessage.Text = "مبلغ سند برگشتی، از مبلغ تراکنش اصلی بیشتر است.";
                    break;
                case "invalid transaction":
                    error = 1;
                    LBMessage.Text = "درخواست برگشت یک تراکنش رسیده است، در حالی که تراکنش اصلی پیدا نمی شود.";
                    break;
                case "invalid card number":
                    error = 1;
                    LBMessage.Text = "شماره کارت اشتباه می باشد.";
                    break;
                case "no such issuer":
                    error = 1;
                    LBMessage.Text = "چنین کارتی وجود ندارد.";
                    break;
                case "expired card pick up":
                    error = 1;
                    LBMessage.Text = "از تاریخ انقضای کارت گذشته است و کارت دیگر معتبر نمی باشد.";
                    break;
                case "allowable pin tries exceeded pick up":
                    error = 1;
                    LBMessage.Text = "رمز کارت-PIN-3 مرتبه اشتباه وارد شده است و در نتیجه کارت غیر فعال خواهد شد.";
                    break;
                case "incorrect pin":
                    error = 1;
                    LBMessage.Text = "رمز کارت-PIN-اشتباه وارد شده است.";
                    break;
                case "exceeds withdrawal amount limit":
                    error = 1;
                    LBMessage.Text = "مبلغ بیش از سقف برداشت می باشد.";
                    break;
                case "transaction cannot be completed":
                    error = 1;
                    LBMessage.Text = "تراکنش Authorize شده است ولی امکان سند خوردن وجود ندارد.";
                    break;
                case "response received too late":
                    error = 1;
                    LBMessage.Text = "تراکنش در شبکه بانکی  TimeOut خورده است.";
                    break;
                case "suspected fraund pick up":
                    error = 1;
                    LBMessage.Text = "خریدار فیلد CVV و یا فیلد ExpDate را اشتباه زده است و یا اصلاً وارد نکرده است.";
                    break;
                case "no sufficient funds":
                    error = 1;
                    LBMessage.Text = "موجودی به اندازه کافی در حساب موجود نمی باشد.";
                    break;
                case "issuer down slm":
                    error = 1;
                    LBMessage.Text = "سیستم کارت بانک صادر کننده در وضعیت عملیاتی نمی باشد";
                    break;
                case "tme error":
                    error = 1;
                    LBMessage.Text = "خطای بانکی رخ داده است.";
                    break;
                default:
                    error = 1;
                    LBMessage.Text = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد";
                    break;
            }
            error = 1;
        }
        Session.Add("error", error);

        if (error == 0)
            HLBuy.Visible = false;
    }
    protected void InsertAndEmail()
    {
        string ResNum = Request.Form["ResNum"];
        string RefNum = Request.Form["RefNum"];
        LBMessage.Text = "Level1";
        int Amount = int.Parse(Session["Amount"].ToString());
        LBMessage.Text = "Level2";
        RequestDS requestDS = new RequestDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, User.Identity.Name));
        requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);
        LBMessage.Text = "Level3";
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

            requestDS.vRequest.Rows[i][requestDS.vRequest.fldfk_BuyIDColumn] = new Guid(ResNum);
        }
        LBMessage.Text = "Level4";
        SingleBuyDS singleBuyDS = new SingleBuyDS();
        LBMessage.Text = "Level4-0";
        SingleBuyDS.vSingleBuyRow singleBuyRow = singleBuyDS.vSingleBuy.NewvSingleBuyRow();
        LBMessage.Text = "Level4-1";
        singleBuyRow.fldBuyDate = Persia.Calendar.ConvertToPersian(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Persia.DateType.Gerigorian).Persian.ToString();
        LBMessage.Text = "Level4-2";
        singleBuyRow.fldBuyID = new Guid(ResNum);
        LBMessage.Text = "Level4-3";
        singleBuyRow.fldfk_DVDKindID = short.Parse(Session["DVDKind"].ToString());
        LBMessage.Text = "Level4-4";
        singleBuyRow.fldfk_PaymentWayID = short.Parse(Session["PaymentWay"].ToString());
        LBMessage.Text = "Level4-5";
        singleBuyRow.fldfk_TransmissionKindID = short.Parse(Session["TransmissionKind"].ToString());
        LBMessage.Text = "Level4-6";
        singleBuyRow.fldPrice = Amount;
        LBMessage.Text = "Level4-7";
        singleBuyRow.fldReferenceNumber = RefNum;
        LBMessage.Text = "Level4-8";
        singleBuyDS.vSingleBuy.AddvSingleBuyRow(singleBuyRow);
        LBMessage.Text = "Level5";
        new BuyDetailBL().Update(ref singleBuyDS, ref requestDS);
        LBMessage.Text = "Level6";
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
        singleTransmissionKindDS = new SingleTransmissionKindBL().GetByID(Session["TransmissionKind"]);
        body += singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindNameColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ ارسال :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\"><hr width=\"60%\"/></td>		</tr>	<tr>		<td colspan=\"2\"><span lang=\"fa\">نوع دی وی دی : </span>&nbsp;";
        SingleDVDKindDS singleDVDKindDS = new SingleDVDKindDS();
        singleDVDKindDS = new SingleDVDKindBL().GetByID(Session["DVDKind"]);
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
        singlePaymentWayDS = new SinglePaymentWayBL().GetByID(Session["PaymentWay"]);
        body += singlePaymentWayDS.vSinglePaymentWay.Rows[0][singlePaymentWayDS.vSinglePaymentWay.fldPaymentWayNameColumn].ToString();
        body += "</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ کل :&nbsp;";
        int kol = int.Parse(sum.ToString()) + int.Parse(singleTransmissionKindDS.vSingleTransmissionKind.Rows[0][singleTransmissionKindDS.vSingleTransmissionKind.fldTransmissionKindPriceColumn].ToString()) + int.Parse(DVDs.ToString());
        body += String.Format("{0:#,###}", int.Parse(kol.ToString()));
        body += "&nbsp; 		ریال</span></td>	</tr>	<tr>		<td colspan=\"2\" align=\"left\"><span lang=\"fa\">مبلغ پرداختی :&nbsp;";
        body += String.Format("{0:#,###}", int.Parse(Session["Amount"].ToString()));
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
        LBMessage.Text = "Level7";

    }
}
