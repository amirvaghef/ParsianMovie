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

public partial class PUsers_Specification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
    protected void AccordionPaneUpdateUser_PreRender(object sender, EventArgs e)
    {
        SinglePersonalDS personalDS = new SinglePersonalDS();
        personalDS = new SinglePersonalBL().GetByID(User.Identity.Name);

        if (personalDS.vSinglePersonal.Rows.Count > 0)
        {
            Email.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldEmailColumn.ColumnName].ToString();
            Name.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldNameColumn.ColumnName].ToString();
            Family.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldFamilyColumn.ColumnName].ToString();
            Tel.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldTelColumn.ColumnName].ToString();
            Mob.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldMobilePhoneColumn.ColumnName].ToString();
            Address.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldAddressColumn.ColumnName].ToString();
            PostalCode.Text = personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldPostalCodeColumn.ColumnName].ToString();
        }
        else
        {
            Email.Text = Membership.GetUser(User.Identity.Name).Email;
            Name.Text = "";
            Family.Text = "";
            Tel.Text = "";
            Mob.Text = "";
            Address.Text = "";
            PostalCode.Text = "";
        }
    }
    protected void BTSubmit_Click(object sender, EventArgs e)
    {
        SinglePersonalBL SPBL = new SinglePersonalBL();
        SinglePersonalDS personalDS = new SinglePersonalDS();

        personalDS = SPBL.GetByID(User.Identity.Name);

        MembershipUser user = Membership.GetUser(User.Identity.Name);

        user.Email = Email.Text;

        if (personalDS.vSinglePersonal.Rows.Count > 0)
        {
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldEmailColumn] = Email.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldNameColumn] = Name.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldFamilyColumn] = Family.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldTelColumn] = Tel.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldMobilePhoneColumn] = Mob.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldAddressColumn] = Address.Text;
            personalDS.vSinglePersonal.Rows[0][personalDS.vSinglePersonal.fldPostalCodeColumn] = PostalCode.Text;
        }
        else
        {
            SinglePersonalDS.vSinglePersonalRow personalRow = personalDS.vSinglePersonal.NewvSinglePersonalRow();
            personalRow.fldAddress = Address.Text;
            personalRow.fldEmail = Email.Text;
            personalRow.fldFamily = Family.Text;
            personalRow.fldMobilePhone = Mob.Text;
            personalRow.fldName = Name.Text;
            personalRow.fldPostalCode = PostalCode.Text;
            personalRow.fldTel = Tel.Text;
            personalDS.vSinglePersonal.AddvSinglePersonalRow(personalRow);
        }

        Membership.UpdateUser(user);
        SPBL.Update(ref personalDS);
    }
}
