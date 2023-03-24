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
using Business;
using Common.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonData.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        SingleAdvertismentsDS ds = new SingleAdvertismentsDS();
        SearchFilter sf = new SearchFilter();
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.GreaterThanEqual, DateTime.Today));
        sf.OrFilter(new FilterDefinition(ds.vSingleAdverisments.fldEndDateColumn, FilterOperation.IsNull, null));

        RepeaterAdvertisment.DataSource = new SingleAdvertismentBL().GetByFilter(sf, ds.vSingleAdverisments.fldAdvertismentsIDColumn).vSingleAdverisments;
        RepeaterAdvertisment.DataBind();

        KindOfferBL koBL = new KindOfferBL();
        SingleKindOfferDS.vSingleKindOfferDataTable koDT = koBL.GetAll();
        RepeaterKindOffer.DataSource = koDT;
        RepeaterKindOffer.DataBind();

        GenreBL gBL = new GenreBL();
        SingleGenreDS.vSingleGenreDataTable gDT = gBL.GetAll();
        RepeaterGenre.DataSource = gDT;
        RepeaterGenre.DataBind();
    }

    protected int GetNumberAll()
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        return sfBL.CountAll();
    }
    protected int GetNumberKindOffer(object id)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable dt = new SingleFilmDS.vSingleFilmDataTable();
        SearchFilter sf = new SearchFilter();

        sf.AddFilter(new FilterDefinition(dt.fldfk_KindOfferIDColumn, FilterOperation.Equal, id));

        return sfBL.CountByFilter(sf);
    }
    protected int GetNumberGenre(object id)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable dt = new SingleFilmDS.vSingleFilmDataTable();
        SearchFilter sf = new SearchFilter();

        sf.AddFilter(new FilterDefinition(dt.fldGenreIDColumn, FilterOperation.Equal, id));

        return sfBL.CountByFilter(sf);
    }
    protected int GetNumberDecade(string start, string finish)
    {
        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable dt = new SingleFilmDS.vSingleFilmDataTable();
        SearchFilter sf = new SearchFilter();

        sf.AndFilter(new FilterDefinition(dt.fldYearsOfProductColumn, FilterOperation.GreaterThan, start));
        sf.AndFilter(new FilterDefinition(dt.fldYearsOfProductColumn, FilterOperation.LessThanEqual, finish));

        return sfBL.CountByFilter(sf);
    }

    protected void IBSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/SearchNResult.aspx?" + DRPSearch.SelectedValue + "=" + TXTSearch.Text);
    }

    #region Export To Excel
    protected void ConvertExcel_OnClick(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        // Declare your Columns - for brevity sake I went with the LameO
        // constructors, but you can (and should) get more specific 
        DataColumn ShomareyeFilm = new DataColumn("شماره");
        DataColumn NoeErae = new DataColumn("نوع");
        DataColumn NameFarsi = new DataColumn("نام فارسی");
        DataColumn NameEnglish = new DataColumn("نام اصلی");
        DataColumn SaleTolid = new DataColumn("سال تولید");
        DataColumn Subtitles = new DataColumn("زیرنویس");
        DataColumn Bazigaran = new DataColumn("بازیگران");
        DataColumn Kargardan = new DataColumn("کارگردان");
        DataColumn Genre = new DataColumn("ژانر");
        DataColumn Zaban = new DataColumn("زبان");
        DataColumn IMDBRate = new DataColumn("رتبه");
        DataColumn Bakhsh = new DataColumn("تعداد");
        DataColumn Keyfiat = new DataColumn("کیفیت");
        DataColumn Darage = new DataColumn("درجه");
        DataColumn Gheymat = new DataColumn("قیمت");
        DataColumn Keshvar = new DataColumn("کشور");
        DataColumn Zaman = new DataColumn("زمان");

        // Add them  to your DataTable
        dt.Columns.Add(ShomareyeFilm);
        dt.Columns.Add(NoeErae);
        dt.Columns.Add(NameFarsi);
        dt.Columns.Add(NameEnglish);
        dt.Columns.Add(SaleTolid);
        dt.Columns.Add(Subtitles);
        dt.Columns.Add(Bazigaran);
        dt.Columns.Add(Kargardan);
        dt.Columns.Add(Genre);
        dt.Columns.Add(Zaban);
        dt.Columns.Add(IMDBRate);
        dt.Columns.Add(Bakhsh);
        dt.Columns.Add(Keyfiat);
        dt.Columns.Add(Darage);
        dt.Columns.Add(Gheymat);
        dt.Columns.Add(Keshvar);
        dt.Columns.Add(Zaman);

        // Add the DataTable to your DataSet
        ds.Tables.Add(dt);

        SingleFilmBL sfBL = new SingleFilmBL();
        SingleFilmDS.vSingleFilmDataTable sfDT = new SingleFilmDS.vSingleFilmDataTable();
        sfDT = sfBL.GetAll();

        foreach (SingleFilmDS.vSingleFilmRow dr in sfDT.Rows)
        {
            DataRow tempDR = ds.Tables[0].NewRow();
            tempDR[0] = dr.fldFilmID;
            tempDR[1] = dr.fldKindOfferName;
            tempDR[2] = dr.fldFarsiName;
            tempDR[3] = dr.fldEnglishName;
            tempDR[4] = dr.fldYearsOfProduct;

            SingleFilmSubtitlesBL sfsBL = new SingleFilmSubtitlesBL();
            SingleFilmSubtitlesDS.vFilmSubtitlesDataTable sfsDT = new SingleFilmSubtitlesDS.vFilmSubtitlesDataTable();
            SearchFilter sfsSF = new SearchFilter();
            sfsSF.AddFilter(new FilterDefinition(sfsDT.fldfk_FilmIDColumn, FilterOperation.Equal, dr.fldFilmID.ToString()));
            sfsDT = sfsBL.GetByFilter(sfsSF, sfsDT.fldFilmSubtitlesIDColumn);
            string subtitles = "";
            foreach (SingleFilmSubtitlesDS.vFilmSubtitlesRow sfsDR in sfsDT.Rows)
                subtitles += sfsDR.fldSubtitlesName + " ,";
            tempDR[5] = subtitles;

            tempDR[6] = dr.fldActors;
            tempDR[7] = dr.fldDirector;

            SingleFilmGenreBL sfgBL = new SingleFilmGenreBL();
            SingleFilmGenreDS.vFilmGenreDataTable sfgDT = new SingleFilmGenreDS.vFilmGenreDataTable();
            SearchFilter sfgSF = new SearchFilter();
            sfgSF.AddFilter(new FilterDefinition(sfgDT.fldfk_FilmIDColumn, FilterOperation.Equal, dr.fldFilmID.ToString()));
            sfgDT = sfgBL.GetByFilter(sfgSF, sfgDT.fldFilmGenreIDColumn);
            string genre = "";
            foreach (SingleFilmGenreDS.vFilmGenreRow sfgDR in sfgDT.Rows)
                genre += sfgDR.fldGenreName + " ,";
            tempDR[8] = genre;

            SingleFilmLanguageBL sflBL = new SingleFilmLanguageBL();
            SingleFilmLanguageDS.vFilmLanguageDataTable sflDT = new SingleFilmLanguageDS.vFilmLanguageDataTable();
            SearchFilter sflSF = new SearchFilter();
            sflSF.AddFilter(new FilterDefinition(sflDT.fldfk_FilmIDColumn, FilterOperation.Equal, dr.fldFilmID.ToString()));
            sflDT = sflBL.GetByFilter(sflSF, sflDT.fldFilmLanguageIDColumn);
            string language = "";
            foreach (SingleFilmLanguageDS.vFilmLanguageRow sflDR in sflDT.Rows)
                language += sflDR.fldLanguageName + " ,";
            tempDR[9] = language;

            tempDR[10] = dr.fldIMDBRating;
            tempDR[11] = dr.fldSection;
            tempDR[12] = dr.fldQualityName;
            tempDR[13] = dr.fldRankName;
            tempDR[14] = dr.fldPrice;
            tempDR[15] = dr.fldCountryProductName;
            tempDR[16] = dr.fldTime;
            ds.Tables[0].Rows.Add(tempDR);
        }
        
        DataSetToExcel.Convert(ds, Response);
    } 
    #endregion
}
