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

public partial class PSuperAdmin_UsersInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Panel)Master.FindControl("PLSearch")).Visible = false;
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUserWizard1.UserName, ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("DRPSelectRole")).SelectedValue);

        SinglePersonalDS personalDS = new SinglePersonalDS();
        SinglePersonalDS.vSinglePersonalRow personalRow = personalDS.vSinglePersonal.NewvSinglePersonalRow();
        personalRow.fldAddress = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address")).Text;
        personalRow.fldEmail = CreateUserWizard1.Email;
        personalRow.fldFamily = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Family")).Text;
        personalRow.fldMobilePhone = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Mob")).Text;
        personalRow.fldName = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Name")).Text;
        personalRow.fldPostalCode = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PostalCode")).Text;
        personalRow.fldTel = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Tel")).Text;
        personalRow.fldUsername = CreateUserWizard1.UserName;
        personalDS.vSinglePersonal.AddvSinglePersonalRow(personalRow);

        new SinglePersonalBL().Update(ref personalDS);
        personalDS.AcceptChanges();
    }

    protected void GWUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Membership.DeleteUser(((Label)GWUsers.Rows[e.RowIndex].FindControl("Label1")).Text);
        SinglePersonalDS ds = new SinglePersonalDS();

        string[] users = Roles.GetUsersInRole(DRPRole.SelectedValue);

        SearchFilter sf = new SearchFilter();
        foreach (string user in users)
        {
            sf.OrFilter(new FilterDefinition(ds.vSinglePersonal.fldUsernameColumn, FilterOperation.Equal, user));
        }

        ds = new SinglePersonalBL().GetByFilter(sf, ds.vSinglePersonal.fldUsernameColumn);
        ds.vSinglePersonal.FindByfldUsername(((Label)GWUsers.Rows[e.RowIndex].FindControl("Label1")).Text).Delete();
        new SinglePersonalBL().Update(ref ds);

        GWUsers.DataSource = ds.vSinglePersonal;
        GWUsers.DataBind();
    }

    protected void GWUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //BOUGHT
        TXTUsername.Text = ((Label)GWUsers.Rows[e.RowIndex].FindControl("Label1")).Text;

        RequestBuyDS.vRequestBuyDataTable requestDS = new RequestBuyDS.vRequestBuyDataTable();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.fldUsernameColumn, FilterOperation.Equal, TXTUsername.Text));
        requestDS = new RequestBuyBL().GetByFilter(sf, GWFilms.PageIndex, GWFilms.PageCount, requestDS.fldFilmIDColumn);

        ArrayList tempFldBuyIdArray = new ArrayList();
        SingleBuyDS sBuyDS = new SingleBuyDS();
        SearchFilter sfBuyDate = new SearchFilter();
        foreach (RequestBuyDS.vRequestBuyRow row in requestDS.Rows)
        {
            if (!tempFldBuyIdArray.Contains(row.fldfk_BuyID))
            {
                sfBuyDate.AddFilter(new FilterDefinition(sBuyDS.vSingleBuy.fldBuyIDColumn, FilterOperation.Equal, row.fldfk_BuyID));
                tempFldBuyIdArray.Add(row.fldfk_BuyID);
            }
        }
        if (tempFldBuyIdArray.Count != 0)
        {
            sBuyDS = new SingleBuyBL().GetByFilter(sfBuyDate, sBuyDS.vSingleBuy.fldBuyDateColumn);
            RepeaterBought.DataSource = sBuyDS.Tables[0];
            RepeaterBought.DataBind();
        }
        //GWFilms.DataSource = new RequestBuyBL().GetByFilter(sf, GWFilms.PageIndex, GWFilms.PageCount, requestDS.vRequestBuy.fldFilmIDColumn);
        //GWFilms.DataBind();

    }

    protected void GWUser_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //BASKET
        TXTUsername.Text = ((Label)GWUsers.Rows[e.NewEditIndex].FindControl("Label1")).Text;

        #region BindData
        RequestDS requestDS = new RequestDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, TXTUsername.Text));
        requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);
        GWFilms.DataSource = requestDS.Tables[0];
        GWFilms.DataBind();

        int sum = 0;
        for (int i = 0; i < requestDS.vRequest.Count; i++)
            sum += int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString());
        PriceFilms.Visible = true;
        LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(sum.ToString()));
        #endregion
    }

    protected void GWUser_RowCanceling(object sender, GridViewCancelEditEventArgs e)
    {
        Advertisment.SelectedIndex = 0;
        PanelUserInformation.Visible = true;
        TXTUsername.Text = ((Label)GWUsers.Rows[e.RowIndex].FindControl("Label1")).Text;

        SinglePersonalDS personalDS = new SinglePersonalDS();
        personalDS = new SinglePersonalBL().GetByID(TXTUsername.Text);
        
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
            Email.Text = Membership.GetUser(TXTUsername.Text).Email;
            Name.Text = "";
            Family.Text = "";
            Tel.Text = "";
            Mob.Text = "";
            Address.Text = "";
            PostalCode.Text = "";
        }
    }

    protected void DRPRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void UpdateUser_Load(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        if (TXTUsername.Text == "")
        {
            SinglePersonalDS ds = new SinglePersonalDS();

            string[] users = Roles.GetUsersInRole(DRPRole.SelectedValue);

            SearchFilter sf = new SearchFilter();
            foreach (string user in users)
            {
                sf.OrFilter(new FilterDefinition(ds.vSinglePersonal.fldUsernameColumn, FilterOperation.Equal, user));
            }
            GWUsers.DataSource = new SinglePersonalBL().GetByFilter(sf, ds.vSinglePersonal.fldUsernameColumn);
            GWUsers.DataBind();
        }
    }

    protected void GWUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GWUsers.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void LBUsername_OnClick(object sender, EventArgs e)
    {
        SinglePersonalDS ds = new SinglePersonalDS();
        SearchFilter sf = new SearchFilter();
        sf.OrFilter(new FilterDefinition(ds.vSinglePersonal.fldUsernameColumn, FilterOperation.Like, TXTUsername.Text));
        GWUsers.DataSource = new SinglePersonalBL().GetByFilter(sf, ds.vSinglePersonal.fldUsernameColumn);
        GWUsers.DataBind();
    }

    protected void GWFilms_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region Delete & BindData
        RequestDS requestDS = new RequestDS();
        SearchFilter sf = new SearchFilter();

        sf.AddFilter(new FilterDefinition(requestDS.vRequest.fldUsernameColumn, FilterOperation.Equal, TXTUsername.Text));

        requestDS = new RequestBL().GetByFilter(sf, requestDS.vRequest.fldFilmIDColumn);

        requestDS.vRequest.Rows[e.RowIndex].Delete();
        new RequestBL().Update(ref requestDS);
        GWFilms.DataSource = requestDS.vRequest;
        GWFilms.DataBind();

        int sum = 0;
        for (int i = 0; i < requestDS.vRequest.Count; i++)
            sum += int.Parse(requestDS.vRequest.Rows[i][requestDS.vRequest.fldPriceColumn].ToString());
        LBPriceFilms.Text = String.Format("{0:#,###}", int.Parse(sum.ToString())).Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(sum.ToString()));
        #endregion
    }
}
