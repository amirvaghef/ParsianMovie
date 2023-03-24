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

public partial class rate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();
        sfDT = sfBL.GetByID(Request.QueryString["FilmID"].ToString());

        sfDT[0][sfDT.fldSumVotesColumn] = int.Parse(sfDT[0][sfDT.fldSumVotesColumn].ToString()) + int.Parse(Request.QueryString["rating"].ToString());
        sfDT[0][sfDT.fldCountVotesColumn] = int.Parse(sfDT[0][sfDT.fldCountVotesColumn].ToString()) + 1;

        sfBL.Update(ref sfDT);
    }
}
