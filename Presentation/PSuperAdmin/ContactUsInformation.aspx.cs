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

public partial class PSuperAdmin_ContactUsInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        if (!IsPostBack)
        {
            GWEmail.DataSource = ObjectDataSourceEmail.Select();
            GWEmail.DataBind();
        }
    }

    #region Email
    protected void GWEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleEmailDS ds = new SingleEmailDS();
        ds = new SingleEmailBL().GetAll();
        ds.vSingleEmail.FindByfldEmailID(short.Parse(((Label)GWEmail.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleEmailBL().Update(ref ds);

        GWEmail.DataSource = ObjectDataSourceEmail.Select();
        GWEmail.DataBind();
    }
    protected void GWEmail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleEmailDS ds = new SingleEmailDS();
        ds = new SingleEmailBL().GetAll();
        SingleEmailDS.vSingleEmailRow row = ds.vSingleEmail.FindByfldEmailID(short.Parse(((TextBox)GWEmail.Rows[e.RowIndex].FindControl("TextBox1")).Text));
        row[ds.vSingleEmail.fldAppointedTaskColumn] = ((TextBox)GWEmail.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        row[ds.vSingleEmail.fldEmailAddressColumn] = ((TextBox)GWEmail.Rows[e.RowIndex].FindControl("TextBox3")).Text;
        new SingleEmailBL().Update(ref ds);

        GWEmail.EditIndex = -1;
        GWEmail.DataSource = ObjectDataSourceEmail.Select();
        GWEmail.DataBind();
    }
    protected void GWEmail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWEmail.EditIndex = e.NewEditIndex;

        GWEmail.DataSource = ObjectDataSourceEmail.Select();
        GWEmail.DataBind();
    }
    protected void GWEmail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWEmail.EditIndex = -1;

        GWEmail.DataSource = ObjectDataSourceEmail.Select();
        GWEmail.DataBind();
    }
    protected void IBEmail_Click(object sender, ImageClickEventArgs e)
    {
        SingleEmailDS ds = new SingleEmailDS();
        SingleEmailDS.vSingleEmailRow row = ds.vSingleEmail.NewvSingleEmailRow();
        row.fldAppointedTask = TXTAppointedTask.Text;
        row.fldEmailAddress = TXTEmailAddress.Text;
        ds.vSingleEmail.AddvSingleEmailRow(row);
        new SingleEmailBL().Update(ref ds);

        GWEmail.DataSource = ObjectDataSourceEmail.Select();
        GWEmail.DataBind();
    }
    #endregion
}
