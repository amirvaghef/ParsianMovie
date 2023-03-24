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

public partial class TopBuy : System.Web.UI.Page
{
    protected void FillPLBuy()
    {

        SearchFilter rSF = new SearchFilter();
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_UsernameColumn, FilterOperation.Equal, User.Identity.Name));
        rSF.AndFilter(new FilterDefinition(new SingleRequestDS().vSingleRequest.fldfk_BuyIDColumn, FilterOperation.IsNull, null));

        SingleRequestBL rBL = new SingleRequestBL();
        SingleRequestDS srDS = rBL.GetByFilter(rSF, new SingleRequestDS().vSingleRequest.fldRequestIDColumn);

        LBPricePanel.Text = srDS.vSingleRequest.Compute("SUM(fldPrice)", "").ToString().Equals("") ? "0" : String.Format("{0:#,###}", int.Parse(srDS.vSingleRequest.Compute("SUM(fldPrice)", "").ToString()));
        LBFilmNumber.Text = srDS.vSingleRequest.Count.ToString();
        if (int.Parse(srDS.vSingleRequest.Count.ToString()) > 0)
        {
            HyperLink1.Visible = true;
            HyperLink2.Visible = false;
        }
        else
        {
            HyperLink1.Visible = false;
            HyperLink2.Visible = true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        if (Request.IsAuthenticated && User.IsInRole("Users"))
        {
            PLBuy.Visible = true;

            FillPLBuy();
        }

        #region Set Top Buy
        RequestBuyBL rbBL = new RequestBuyBL();
        RequestBuyDS.vRequestBuyDataTable rbDT = new RequestBuyDS.vRequestBuyDataTable();
        rbDT = rbBL.GetTopBuy(20);
        DLTopBuy.DataSource = rbDT;
        DLTopBuy.DataBind();
        #endregion
    }
}
