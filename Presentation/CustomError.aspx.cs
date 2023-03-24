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

public partial class CustomError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        HyperLink1.NavigateUrl = Request.QueryString["aspxerrorpath"].ToString();//=/PUsers/Basket.aspx;
        try
        {
            Label1.Text = Session["errormsg"].ToString();
        }
        catch
        {
            Label1.Text = "System Has Error";
        }
    }
}
