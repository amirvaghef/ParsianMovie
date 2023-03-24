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
using AjaxControlToolkit;
using System.IO;

public partial class PAdmin_Advertisment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GWExpiredAdvertisment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region Delete & BindData
        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.LessThan, DateTime.Today));

        ds = new SingleAdvertismentBL().GetByFilter(sf, ds.vSingleAdverisments.fldEndDateColumn);
        ds.vSingleAdverisments.FindByfldAdvertismentsID(long.Parse(((Label)GWExpiredAdvertisment.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleAdvertismentBL().Update(ref ds);

        GWExpiredAdvertisment.DataSource = ds.vSingleAdverisments;
        GWExpiredAdvertisment.DataBind();
        #endregion
    }

    protected void GWCurrentAdvertisment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region Delete & BindData
        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SearchFilter sf = new SearchFilter();
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.GreaterThanEqual, DateTime.Today));
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.IsNull, null));

        ds = new SingleAdvertismentBL().GetByFilter(sf, ds.vSingleAdverisments.fldEndDateColumn);
        ds.vSingleAdverisments.FindByfldAdvertismentsID(long.Parse(((Label)GWCurrentAdvertisment.Rows[e.RowIndex].FindControl("Label1")).Text)).Delete();
        new SingleAdvertismentBL().Update(ref ds);

        GWCurrentAdvertisment.DataSource = ds.vSingleAdverisments;
        GWCurrentAdvertisment.DataBind();
        #endregion
    }

    protected void ExpiredAdvertisment_Load(object sender, EventArgs e)
    {
        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SearchFilter sf = new SearchFilter();
        sf.AddFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.LessThan, DateTime.Today));

        GWExpiredAdvertisment.DataSource = new SingleAdvertismentBL().GetByFilter(sf, ds.vSingleAdverisments.fldEndDateColumn).vSingleAdverisments;
        GWExpiredAdvertisment.DataBind();
    }

    protected void CurrentAdvertisment_Load(object sender, EventArgs e)
    {
        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SearchFilter sf = new SearchFilter();
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.GreaterThanEqual, DateTime.Today));
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.IsNull, null));

        GWCurrentAdvertisment.DataSource = new SingleAdvertismentBL().GetByFilter(sf, ds.vSingleAdverisments.fldEndDateColumn).vSingleAdverisments;
        GWCurrentAdvertisment.DataBind();
    }

    protected void IBSubmit_Click(object sender, ImageClickEventArgs e)
    {
        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SingleAdvertismentsDS.vSingleAdverismentsRow row = ds.vSingleAdverisments.NewvSingleAdverismentsRow();
        row.fldCode = TXTCode.Text;
        row.fldName = TXTName.Text;
        if(TXTTime.Text != "")
        {
            switch(DRPTime.SelectedValue)
            {
                case "0":
                    row.fldEndDate = DateTime.Today.AddDays(double.Parse(TXTTime.Text));
                    break;
                case "1":
                    row.fldEndDate = DateTime.Today.AddMonths(int.Parse(TXTTime.Text));
                    break;
                case "2":
                    row.fldEndDate = DateTime.Today.AddYears(int.Parse(TXTTime.Text));
                    break;
            }
        }
        row.fldStartDate = DateTime.Today;
        ds.vSingleAdverisments.AddvSingleAdverismentsRow(row);
        new SingleAdvertismentBL().Update(ref ds);

        IBReset_Click(sender, e);
    }
    protected void IBReset_Click(object sender, ImageClickEventArgs e)
    {
        TXTCode.Text = "";
        TXTLink.Text = "";
        TXTName.Text = "";
        TXTTime.Text = "";
        DRPTime.SelectedIndex = -1;
    }
    protected void IBUpload_Click(object sender, ImageClickEventArgs e)
    {
        WithoutModalPopup.Show();
    }
    protected void IBUploadPanel_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload1.PostedFile.ContentLength != 0)
        {
            HttpPostedFile catalogFile = FileUpload1.PostedFile;
            byte[] catalogData = new byte[catalogFile.ContentLength];
            catalogFile.InputStream.Read(catalogData, 0, catalogFile.ContentLength);

            FileStream newFile = new FileStream(MapPath("../Ad/" + catalogFile.FileName.Substring(catalogFile.FileName.LastIndexOf("\\") + 1)), FileMode.Create);
            newFile.Write(catalogData, 0, catalogData.Length);
            newFile.Close();
        }
        string code = "<a target=\"_blank\" href=\"";
        code += TXTLink.Text;
        code += "\"><img src=\"";
        code += "../Ad/" + FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1);
        code += "\" /></a>";

        TXTCode.Text = code;
    }
    protected void IBCancelPanel_Click(object sender, ImageClickEventArgs e)
    {
        WithoutModalPopup.Hide();
    }
}
