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
using DataAccess;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
    
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        SinglePersonalDS personalDS = new SinglePersonalDS();
        SinglePersonalDS.vSinglePersonalRow personalRow = personalDS.vSinglePersonal.NewvSinglePersonalRow();
        personalRow.fldUsername = CreateUserWizard1.UserName;
        personalRow.fldAddress = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address")).Text;
        personalRow.fldEmail = CreateUserWizard1.Email;
        personalRow.fldFamily = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Family")).Text;
        personalRow.fldMobilePhone = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Mob")).Text;
        personalRow.fldName = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Name")).Text;
        personalRow.fldPostalCode = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PostalCode")).Text;
        personalRow.fldTel = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Tel")).Text;
        personalDS.vSinglePersonal.AddvSinglePersonalRow(personalRow);

        new SinglePersonalBL().Update(ref personalDS);
        personalDS.AcceptChanges();

        Roles.AddUserToRole(CreateUserWizard1.UserName, "Users");
    }
}
