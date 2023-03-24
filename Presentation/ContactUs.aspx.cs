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
using System.Web.Mail;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        SingleEmailDS ds = new SingleEmailDS();
        DRPTO.DataSource = new SingleEmailBL().GetAll();
        DRPTO.DataTextField = ds.vSingleEmail.fldAppointedTaskColumn.Caption;
        DRPTO.DataValueField = ds.vSingleEmail.fldEmailAddressColumn.Caption;
        DRPTO.DataBind();

        DRPTO.SelectedIndex = -1;
    }
    protected void IBSubmit_Click(object sender, ImageClickEventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.From = TXTFrom.Text;
        msg.To = DRPTO.SelectedValue;
        msg.Subject = TXTSubject.Text;
        msg.Body = TXTMessage.Text;

        try
        {
            SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(msg);
            LBError.Text = "پیام با موفقیت ارسال شد.";
        }
        catch(Exception ex)
        {
            LBError.Text = "ارسال پیام با مشکل مواجه شد. " + ex.Message;
        }
    }
    protected void IBReset_Click(object sender, ImageClickEventArgs e)
    {
        TXTFrom.Text = "";
        TXTMessage.Text = "";
        TXTSubject.Text = "";
        DRPTO.SelectedIndex = -1;
    }
}
