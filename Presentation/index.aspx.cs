﻿using System;
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

public partial class index : System.Web.UI.Page
{
    protected void FillPLBuy()
    {
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        
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

        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();

        #region Set Last Films
        sfDT = sfBL.GetAll();
        sfDT.DefaultView.Sort = "fldFilmID DESC";
        if (sfDT.Rows.Count > 0)
        {
            if (sfDT.Rows.Count >= 20)
                sfDT.DefaultView.RowFilter = "fldFilmID >=" + sfDT.DefaultView[19][sfDT.fldFilmIDColumn.ColumnName];
            else
                sfDT.DefaultView.RowFilter = "fldFilmID >=" + sfDT.DefaultView[sfDT.Rows.Count - 1][sfDT.fldFilmIDColumn.ColumnName];
        }
        DLLastFilms.DataSource = sfDT.DefaultView;
        DLLastFilms.DataBind(); 
        #endregion

        
    }

    protected int CalculateRate(object sum, object count)
    {
        if (int.Parse(sum.ToString()) != 0 && int.Parse(count.ToString()) != 0)
            return (int)Math.Round(double.Parse(sum.ToString())/double.Parse(count.ToString()));
        else 
            return 0;
    }
}
