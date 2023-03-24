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

public partial class PAdmin_Faq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;

        if (!IsPostBack)
        {
            GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
            GWFAQ.DataBind();
        }
    }
    #region FAQ
    protected void GWFAQ_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SingleFAQDS ds = new SingleFAQDS();
        ds = new SingleFAQBL().GetAll();
        ds.vSingleFAQ.FindByfldFAQID(long.Parse(((Label)GWFAQ.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleFAQBL().Update(ref ds);

        GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
        GWFAQ.DataBind();
    }
    protected void GWFAQ_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SingleFAQDS ds = new SingleFAQDS();
        ds = new SingleFAQBL().GetAll();
        SingleFAQDS.vSingleFAQRow row = ds.vSingleFAQ.FindByfldFAQID(long.Parse(((TextBox)GWFAQ.Rows[e.RowIndex].FindControl("TextBox1")).Text));
        row[ds.vSingleFAQ.fldFAQQuestionColumn] = ((TextBox)GWFAQ.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        row[ds.vSingleFAQ.fldFAQAnswerColumn] = ((TextBox)GWFAQ.Rows[e.RowIndex].FindControl("TextBox3")).Text;
        new SingleFAQBL().Update(ref ds);

        GWFAQ.EditIndex = -1;
        GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
        GWFAQ.DataBind();
    }
    protected void GWFAQ_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWFAQ.EditIndex = e.NewEditIndex;

        GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
        GWFAQ.DataBind();
    }
    protected void GWFAQ_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWFAQ.EditIndex = -1;

        GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
        GWFAQ.DataBind();
    }
    protected void IBFAQ_Click(object sender, ImageClickEventArgs e)
    {
        SingleFAQDS ds = new SingleFAQDS();
        SingleFAQDS.vSingleFAQRow row = ds.vSingleFAQ.NewvSingleFAQRow();
        row.fldFAQQuestion = TXTFAQQuestion.Text;
        row.fldFAQAnswer = TXTFAQAnswer.Text;
        ds.vSingleFAQ.AddvSingleFAQRow(row);
        new SingleFAQBL().Update(ref ds);

        GWFAQ.DataSource = ObjectDataSourceFAQ.Select();
        GWFAQ.DataBind();
    }
    #endregion
}
