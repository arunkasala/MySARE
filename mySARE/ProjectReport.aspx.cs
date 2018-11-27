using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections.Specialized;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

using UrlQuery;


namespace daikon
{
    public partial class ProjectReport : System.Web.UI.Page
    {
        protected UrlQuery.UrlQuery thisPageURL;
        protected string xslTemplate;
        protected string outputMessage1;
        protected string outputMessage2;

        protected StringWriter writerString;
        protected XmlTextWriter xmlWriter;
        protected XsltArgumentList xsltArgs;

        protected void Page_Load(object sender, EventArgs e)
        {
            thisPageURL = new UrlQuery.UrlQuery();
            writerString = new StringWriter();
            xmlWriter = new XmlTextWriter(writerString);
            xsltArgs = new XsltArgumentList();

            //xslTemplate = ConfigurationManager.AppSettings["mainpageXslt"].ToString();
            //string navbarXslTemplate = ConfigurationManager.AppSettings["projectnavbarXslt"].ToString();

            if (Session["statusMessage1"] != null)
                outputMessage1 = Session["statusMessage1"].ToString();
            else
                outputMessage1 = "";
            if (Session["statusMessage2"] != null)
                outputMessage2 = Session["statusMessage2"].ToString();
            else
                outputMessage2 = "";

			if (thisPageURL["q"] == null)
			{
				thisPageURL.FormToQuery("Query");
				thisPageURL["q"] = thisPageURL["Query"];
				thisPageURL["Query"] = null;
			}

			if (thisPageURL["projType"] == null)
			{
				thisPageURL.FormToQuery("projType");
			}
			if (thisPageURL["region"] == null)
			{
			thisPageURL.FormToQuery("region");
			}
			if (thisPageURL["state"] == null)
			{
			thisPageURL.FormToQuery("state");
			}
			if (thisPageURL["userRole"] == null)
			{
			thisPageURL.FormToQuery("userRole");
			}
			if (thisPageURL["recent"] == null)
			{
			thisPageURL.FormToQuery("recent");
			}
			if (thisPageURL["sortby"] == null)
			{
			thisPageURL.FormToQuery("sortby");
			}

            StringReader readerString;
            XmlDocument xmlDoc = new XmlDocument();
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            XslCompiledTransform xslTransformNavbar = new XslCompiledTransform();

            StringWriter writerStringNavbar;
            XmlTextWriter xmlWriterNavbar;
            XsltArgumentList xsltArgsNavbar;
            StringReader readerStringNavbar;
            XmlDocument xmlDocNavbar = new XmlDocument();

            writerStringNavbar = new StringWriter();
            xmlWriterNavbar = new XmlTextWriter(writerStringNavbar);
            xsltArgsNavbar = new XsltArgumentList();

            xmlWriter.Formatting = Formatting.Indented;
            xmlWriterNavbar.Formatting = Formatting.Indented;

            xmlWriter.WriteStartElement("SAREroot");
            xmlWriterNavbar.WriteStartElement("SAREroot");

            DaikonGrantFieldValues staticVals = new DaikonGrantFieldValues();

            staticVals.DaikonGrantFieldValues(ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());

            xmlWriterNavbar.WriteEndElement();

            readerStringNavbar = new StringReader(writerStringNavbar.ToString());
            xmlDocNavbar.Load(readerStringNavbar);

            //			Response.Clear();
            Response.ContentType = "text/html";
            /*
                        XmlTextWriter xmlCache = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
                        xmlCache.Formatting = Formatting.Indented;
            */
            HtmlTextWriter htmlCache = new HtmlTextWriter(Response.Output);
            System.IO.StreamReader headerFile;
            
            if(Request.Params["do"] == "viewRept")
                headerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\header_list_indent.inc");
            else
                 headerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\header.inc");

            string htmlHeader = headerFile.ReadToEnd();
            headerFile.Close();
            /*
            System.IO.StreamReader navbarFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\leftsidebar.inc");
            string htmlNavbar = navbarFile.ReadToEnd();
            navbarFile.Close();
            */
            System.IO.StreamReader footerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\footer.inc");
            string htmlFooter = footerFile.ReadToEnd();
            footerFile.Close();

            if (Request.Params["do"] != null)
            {
                if (Request.Params["do"].ToLower() == "searchproj" || Request.Params["do"].ToLower() == "search")
				{
					SearchProjectReports(sender, e);

					xmlWriter.WriteRaw(File.ReadAllText(this.MapPath(Page.TemplateSourceDirectory) + ConfigurationManager.AppSettings["profiledefinitionXml"].ToString()));
					xslTemplate = ConfigurationManager.AppSettings["reportSearchProjectXslt"].ToString();
				}
				else if (Request.Params["do"].ToLower() == "searchprojprofile")
				{
					if (Request.Form["profilesearch"] != null)
					{
						ProfileSearchHandler(sender, e);
						SearchProfilesXMLWriter();
					}
					else if (null != Session["searchProfile"])
					{
						((DaikonProfile)(Session["searchProfile"])).toXml(xmlWriter);
						SearchProfilesXMLWriter();
					}
					xmlWriter.WriteRaw(File.ReadAllText(this.MapPath(Page.TemplateSourceDirectory) + ConfigurationManager.AppSettings["profiledefinitionXml"].ToString()));
					xslTemplate = ConfigurationManager.AppSettings["reportSearchProfileXslt"].ToString();
                    xsltArgs.AddParam("viewtype", "", "public");
				}
				else if (Request.Params["do"].ToLower() == "searchcoord")
				{
                    SearchCoordReports(sender, e);
                    xmlWriter.WriteRaw(File.ReadAllText(this.MapPath(Page.TemplateSourceDirectory) + ConfigurationManager.AppSettings["profiledefinitionXml"].ToString()));
					xslTemplate = ConfigurationManager.AppSettings["reportSearchCoordinatorXslt"].ToString();
				}
					xmlWriter.WriteRaw(staticVals.pStateInfo);
                    xmlWriter.WriteRaw(staticVals.pRegionInfo);
                    xmlWriter.WriteRaw(staticVals.pProjTypeInfo);
                    xmlWriter.WriteRaw(staticVals.pTextSectionInfo);
                    xmlWriter.WriteRaw(staticVals.pSubsectionTypeInfo);
                    xmlWriter.WriteRaw(staticVals.pUserRoleInfo);

                if (Request.Params["do"] == "viewRept")
                {
                    xslTemplate = ConfigurationManager.AppSettings["viewreportXslt"].ToString();
                    ReportViewerXMLWriter();
                }
                if (Request.Params["do"] == "viewProj")
                {
                    xslTemplate = ConfigurationManager.AppSettings["viewprojectXslt"].ToString();
                    ProjectViewerXMLWriter();
                }
                if (Request.Params["do"] == "infoproddetail")
                {
                    string resourceID = "";
                    string uploadID = "";

                    xslTemplate = ConfigurationManager.AppSettings["infoproductdetailXslt"].ToString();
                    xsltArgs.AddParam("publicview", "", "True"); 

                    string userSQL;
                    string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();


                    SqlConnection userConnection;
                    SqlCommand userCommand;
                    SqlDataReader userDataReader;

                    userConnection = new SqlConnection(userConnString);
                    userSQL = "DaikonProjectBasicDetails";
                    userCommand = new SqlCommand(userSQL, userConnection);
                    userCommand.CommandType = CommandType.StoredProcedure;
                    userCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50).Value = Request.Params.Get("pn");
                    userConnection.Open();
                    userDataReader = userCommand.ExecuteReader();

                    while (userDataReader.Read())
                    {
                        xsltArgs.AddParam("projectType", "", userDataReader["proj_type_text"].ToString());
                        xsltArgs.AddParam("projectRegion", "", userDataReader["proj_region_text"].ToString());
                        xsltArgs.AddParam("projectTitle", "", userDataReader["proj_title_text"].ToString());
                        xsltArgs.AddParam("sareGrant", "", userDataReader["funds_sare"].ToString());
                    }
                    userConnection.Dispose();                    

                    if (Request.Params.Get("resourceID") != null && Request.Params.Get("resourceID") != null)
                    {
                        resourceID = Request.Params.Get("resourceID");
                        uploadID = Request.Params.Get("uploadID");
                        xsltArgs.AddParam("editprojectprodinfo", "", "True");
                        daikonProdInfo.ProductInfo prodInfoRow = new daikonProdInfo.ProductInfo();
                        if (uploadID != null && uploadID.Length == 0)
                            prodInfoRow.getProdInfoDetailsByUploadID(Int32.Parse(resourceID));
                        else
                            prodInfoRow.getProdInfoDetails(Int32.Parse(resourceID));
                        prodInfoRow.toXmlProdInfoDetails(xmlWriter);
                        xsltArgs.AddParam("mytitle", "", prodInfoRow.Title);
                    }                 
                }
                if (Request.Form["btnPDF"] != null)
                {
                    string projectNum = "";
                    int reportType = 0;
                    int reportYear = 2010;
                    string path = Server.MapPath("~/assocfiles/pdf/");
                    string fileName = "pdfDocument" + DateTime.Now.Ticks + ".pdf";

                    if (Request.Params.Get("pn") != null && Request.Params.Get("pn") != "")
                        projectNum = Request.Params.Get("pn");

                    if (Request.Params.Get("y") != null && Request.Params.Get("y") != "")
                        reportYear = int.Parse(Request.Params.Get("y"));

                    if (Request.Params.Get("t") != null && Request.Params.Get("t") != "")
                        reportType = int.Parse(Request.Params.Get("t"));

                    GeneratePDF(path, fileName, true, projectNum, Request.Form["oHidden"], reportType, reportYear);


                }

            }
            else
            {
                xslTemplate = ConfigurationManager.AppSettings["projectReportMenuXslt"].ToString();
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            xsltArgs.AddParam("message", "", outputMessage1);
            xsltArgs.AddParam("message2", "", outputMessage2);           

            readerString = new StringReader(writerString.ToString());
            xmlDoc.Load(readerString);

            if (Request.Params["output"] == "xml")
            {
                //                Response.Write(xmlDoc.ToString());
                Response.Write(writerString.ToString());
                //                Response.Write(doPage);
            }

            htmlCache.Write(htmlHeader);

            htmlCache.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td class=\"leftnav\" style=\"width: 159px; vertical-align: top;\">");

            //xslTransformNavbar.Load(MapPath(Page.TemplateSourceDirectory) + navbarXslTemplate);
            //xslTransformNavbar.Transform(xmlDocNavbar, xsltArgsNavbar, htmlCache);

            htmlCache.Write("</td><td class=\"copy\">");

            string xsltFilePath = Server.MapPath(Page.TemplateSourceDirectory);
            xslTransform.Load(xsltFilePath + xslTemplate);

            xslTransform.Transform(xmlDoc, xsltArgs, htmlCache);

            htmlCache.Write("</td></tr>");
            htmlCache.Write(htmlFooter);
            htmlCache.Write("</tbody></table>");
            htmlCache.Write("</body></html>");

            htmlCache.Close();
                       
        }
        
        protected void SearchCoordReports(object sender, EventArgs e)
        {
            
            string searchTerms = "";
           
            int thisPage = 1;
            int resultsPerPage;
            int startRecord;
            //int searchProjType = 0;
            //int sortby = 1;

            //bool orderDesc = true;

            DaikonGrantCollection userGrants = new DaikonGrantCollection();


            resultsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["searchResultsPerPage"]);

            if (Request.Params.Get("page") != null)
            {
                thisPage = int.Parse(Request.Params.Get("page"));
            }

            startRecord = (resultsPerPage * (thisPage - 1) + 1);

            if (thisPageURL["q"] != null)
            {
                searchTerms = thisPageURL["q"];
            }
           
            if (searchTerms != null && searchTerms.Length != 0)
            {
                searchTerms = searchTerms.Replace('"', ' ');
                userGrants.populateByCoordinateNameSearch(searchTerms, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());
                xsltArgs.AddParam("searchMode", "", "searchcoord");
                xsltArgs.AddParam("startrecord", "", startRecord);
                xsltArgs.AddParam("maxrecords", "", userGrants.MaxRecord);
                xsltArgs.AddParam("resultsperpage", "", resultsPerPage);
                xsltArgs.AddParam("searchString", "", searchTerms);                
            }

            foreach (DaikonGrant tempGrant in userGrants.Values)
            {
                tempGrant.toXml(ref xmlWriter);
            }


        }


        protected void SearchProjectReports(object sender, EventArgs e)
        {
//			Session.Remove("searchProfile");

            string searchTerms = "";
            string searchRegion = "";
            string searchState = "";
            string searchmethod = "and";

            int thisPage = 1;
            int resultsPerPage;
            int startRecord;
            int searchProjType = 0;
			int sortby = 1;           

			bool orderDesc = true;
			
			DaikonGrantCollection userGrants = new DaikonGrantCollection();		

           
            resultsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["searchResultsPerPage"]);

			if (Request.Params.Get("page") != null)
            {
                thisPage = int.Parse(Request.Params.Get("page"));
            }

            startRecord = (resultsPerPage * (thisPage - 1) + 1);

			if (thisPageURL["q"] != null)
			{
				searchTerms = thisPageURL["q"];
			}
			if (thisPageURL["region"] != null)
			{
				searchRegion = thisPageURL["region"];
			}
			if (thisPageURL["projType"] != null)
			{
				searchProjType = Convert.ToInt16(thisPageURL["projType"]);
            }
            if (thisPageURL["state"] != null)
            {
                searchState = thisPageURL["state"];
            }
			if (thisPageURL["sortby"] != null)
			{
				sortby = Convert.ToInt16(thisPageURL["sortby"]);
			}
            if (thisPageURL["amp;searchmethod"] != null)
            {
                searchmethod = thisPageURL["amp;searchmethod"];
            }
			if (sortby == 2)
				orderDesc = false;

			if (searchTerms != null)
            {
                userGrants.SearchSelection = searchmethod;
                searchTerms = searchTerms.Replace('"',' ');
                userGrants.populateBySearch(searchTerms, searchRegion, searchState, searchProjType, sortby, orderDesc, resultsPerPage, thisPage, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString(), "public");
				xsltArgs.AddParam("searchMode", "", "searchProj");
				xsltArgs.AddParam("startrecord", "", startRecord);
                xsltArgs.AddParam("maxrecords", "", userGrants.MaxRecord);
                xsltArgs.AddParam("resultsperpage", "", resultsPerPage);
                xsltArgs.AddParam("searchString", "", searchTerms);
                xsltArgs.AddParam("searchRegion", "", searchRegion);
                xsltArgs.AddParam("searchState", "", searchState);
                xsltArgs.AddParam("searchType", "", searchProjType);
				xsltArgs.AddParam("sortby", "", sortby);
                xsltArgs.AddParam("searchmethod", "", searchmethod);
                xsltArgs.AddParam("viewtype", "", "public");
			}

            foreach (DaikonGrant tempGrant in userGrants.Values)
            {
                tempGrant.toXml(ref xmlWriter);
            }

        }
		protected void SearchProfilesXMLWriter()
		{
			DaikonSearchProfile profile;
			if (null != Session["searchProfile"])
			{
				profile = (DaikonSearchProfile)(Session["searchProfile"]);

				//string view;
				string searchTerms;
                string searchmethod = "and";

				int thisPage;
				int resultsPerPage;
				int startRecord;
                int sortby = 1;

                bool orderDesc = true;

				thisPage = 1;
				resultsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["searchResultsPerPage"]);

				if (Request.Params.Get("page") != null)
				{
					thisPage = int.Parse(Request.Params.Get("page"));
				}
				startRecord = (resultsPerPage * (thisPage - 1) + 1);

				searchTerms = "";

				/*
							if (Request.Params.Get("view") != null)
							{
								view = Request.Params.Get("view");
							}

							if (Request.Params.Get("q") != null)
							{
								searchTerms = Request.Params.Get("q");
							}
							if (Request.Params.Get("Query") != null)
							{
								searchTerms = Request.Params.Get("Query");
							}
				*/
				searchTerms = thisPageURL["q"];

				DaikonGrantCollection userGrants = new DaikonGrantCollection();

				string searchRegion = "";
                string searchState = "";
				int searchProjType = 0;
                int numChosenFields = 0;

				if (thisPageURL["region"] != null)
				{
					searchRegion = thisPageURL["region"];
				}
                if (thisPageURL["state"] != null)
                {
                    searchState = thisPageURL["state"];
                }
				if (thisPageURL["projType"] != null)
				{
					searchProjType = Convert.ToInt16(thisPageURL["projType"]);
				}
                if (thisPageURL["sortby"] != null)
                {
                    sortby = Convert.ToInt16(thisPageURL["sortby"]);
                }
                if (thisPageURL["amp;searchmethod"] != null)
                {
                    searchmethod = thisPageURL["amp;searchmethod"];
                }
                if (sortby == 2)
                    orderDesc = false;

                switch (searchmethod)
                {
                    case "and":
                        numChosenFields = profile.countTerms();
                        break;
                    case "or":
                        numChosenFields = 0;
                        break;
                    default:
                        numChosenFields = 0;
                        break;
                }

				if (true)
				{
					//                    int thisPage = ((startRecord + resultsPerPage - 1) / resultsPerPage);
                    userGrants.populateByProfileSearch(searchTerms, searchRegion, searchState, searchProjType, numChosenFields, orderDesc, orderDesc, resultsPerPage, thisPage, profile, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());
					xsltArgs.AddParam("searchMode", "", "searchprojprofile"); 
					xsltArgs.AddParam("startrecord", "", startRecord);
					xsltArgs.AddParam("maxrecords", "", userGrants.MaxRecord);
					xsltArgs.AddParam("resultsperpage", "", resultsPerPage);
					xsltArgs.AddParam("searchString", "", MNS(searchTerms));
					xsltArgs.AddParam("searchRegion", "", searchRegion);
                    xsltArgs.AddParam("searchState", "", searchState);
					xsltArgs.AddParam("searchType", "", searchProjType);
                    xsltArgs.AddParam("searchAndOr", "", searchmethod);
                    //xsltArgs.AddParam("viewtype", "", "public");
				}

				foreach (DaikonGrant tempGrant in userGrants.Values)
				{
					tempGrant.toXml(ref xmlWriter);
				}
			}

		}
		public void ProfileSearchHandler(object sender, System.EventArgs e)
		{
			DaikonSearchProfile profile;

			if (null != Session["searchProfile"])
				profile = (DaikonSearchProfile)(Session["searchProfile"]);
			else
				profile = new DaikonSearchProfile();

			//int profileID;

			bool planning = (bool)(Request.Form["inv_planning"] == "on");
			bool research = (bool)(Request.Form["inv_research"] == "on");
			bool land = (bool)(Request.Form["inv_land"] == "on");
			bool present = (bool)(Request.Form["inv_present"] == "on");

			profile.InvPlanning = planning;
			profile.InvResearch = research;
			profile.InvLand = land;
			profile.InvPresent = present;

			/*
						string cntPlanning = Request.Form["inv_planningcount"];
						string cntResarch = Request.Form["inv_researchcount"];
						string cntland = Request.Form["inv_landcount"];
						string cntpresent = Request.Form["inv_presentcount"];

						if (cntPlanning.Length > 0)
							profile.InvNumPlanning = Int32.Parse(cntPlanning);
						if (cntResarch.Length > 0)
							profile.InvNumResearch = Int32.Parse(cntResarch);
						if (cntland.Length > 0)
							profile.InvNumLand = Int32.Parse(cntland);
						if (cntpresent.Length > 0)
							profile.InvNumPresent = Int32.Parse(cntpresent);
			*/
			bool extApplied = (bool)(Request.Form["inv_extapplied"] == "on");
			bool extPlanning = (bool)(Request.Form["inv_extplanning"] == "on");

			profile.InvExtApplied = extApplied;
			profile.InvExtPlanning = extPlanning;

			bool audFarm = (bool)(Request.Form["aud_farmranchers"] == "on");
			bool audEdu = (bool)(Request.Form["aud_educators"] == "on");
			bool audRes = (bool)(Request.Form["aud_researchers"] == "on");
			bool audCons = (bool)(Request.Form["aud_consumers"] == "on");

			profile.AudFarmRanchers = audFarm;
			profile.AudEducators = audEdu;
			profile.AudResearchers = audRes;
			profile.Audconsumers = audCons;

			bool techBeg = (bool)(Request.Form["techlvl_beginner"] == "on");
			bool techInt = (bool)(Request.Form["techlvl_intermediate"] == "on");
			bool techAdv = (bool)(Request.Form["techlvl_advanced"] == "on");

			profile.TechlvlBeginner = techAdv;
			profile.TechlvlIntermediate = techInt;
			profile.TechlvlAdvanced = techAdv;

			string catA = Request.Form["cata"];
			//            string catAother = MNS(Request.Form["catb_other"]);
			string catB = Request.Form["catb"];
			//            string catBother = MNS(Request.Form["catb_other"]);

			profile.CategoryA = catA;
			//            profile.CatAother = catAother;
			profile.CategoryB = catB;
			//            profile.CatBother = catBother;

			bool IntegraEcoSys = (bool)(Request.Form["intgfrs_agroecosystemanalysis"] == "on");
			bool IntegraWhFarmPlan = (bool)(Request.Form["intgfrs_wholefarmplanning"] == "on");
			bool IntegraOrgAgri = (bool)(Request.Form["intgfrs_organicagriculture"] == "on");
			bool IntegraPerma = (bool)(Request.Form["intgfrs_permaculture"] == "on");
			//            string IntegraOther = MNS(Request.Form["intgfrs_other"]);

			profile.IntgfrsAgroEcoSystemAnalysis = IntegraEcoSys;
			profile.IntgfrsWholeFarmPlanning = IntegraWhFarmPlan;
			profile.IntgfrsOrgAgri = IntegraOrgAgri;
			profile.IntgfrsPermaCulture = IntegraPerma;
			//            profile.IntgfrsOther = IntegraOther;

			bool CropPrdAgro = (bool)(Request.Form["cropprd_agroforestry"] == "on");
			bool CropPrdFolFeed = (bool)(Request.Form["cropprd_foliarfeeding"] == "on");
			bool CropPrdNutriCyc = (bool)(Request.Form["cropprd_nutrientcycling"] == "on");
			bool CropPrdStripCrop = (bool)(Request.Form["cropprd_stripcropping"] == "on");
			bool CropPrdBioLogic = (bool)(Request.Form["cropprd_biologicalinoculants"] == "on");
			bool CropPrdForestry = (bool)(Request.Form["cropprd_forestry"] == "on");
			bool CropPrdOrgFerti = (bool)(Request.Form["cropprd_organicfertilizers"] == "on");
			bool CropPrdStubbMulch = (bool)(Request.Form["cropprd_stubblemulching"] == "on");
			bool CropPrdConticrop = (bool)(Request.Form["cropprd_continuouscropping"] == "on");
			bool CropPrdGreenManu = (bool)(Request.Form["cropprd_greenmanures"] == "on");
			bool CropPrdOrgMatt = (bool)(Request.Form["cropprd_organicmatter"] == "on");
			bool CropPrdTissueAnaly = (bool)(Request.Form["cropprd_tissueanalysis"] == "on");
			bool CropPrdCoverCrop = (bool)(Request.Form["cropprd_covercrops"] == "on");
			bool CropPrdIntCrop = (bool)(Request.Form["cropprd_intercropping"] == "on");
			bool CropPrdPermaCul = (bool)(Request.Form["cropprd_permaculture"] == "on");
            bool CropPrdTransToOrg = (bool)(Request.Form["cropprd_transitioning"] == "on");
			bool CropPrdDbleCrop = (bool)(Request.Form["cropprd_doublecropping"] == "on");
			bool CropPrdMiniTillage = (bool)(Request.Form["cropprd_minimumtillage"] == "on");
			bool CropPrdReduceAppli = (bool)(Request.Form["cropprd_reducedapplications"] == "on");
			bool CropPrdEarthworms = (bool)(Request.Form["cropprd_earthworms"] == "on");
			bool CropPrdMulticrop = (bool)(Request.Form["cropprd_multiplecropping"] == "on");
			bool CropPrdRelayCrop = (bool)(Request.Form["cropprd_relaycropping"] == "on");
			bool CropPrdFallow = (bool)(Request.Form["cropprd_fallow"] == "on");
			bool CropPrdMuniWste = (bool)(Request.Form["cropprd_municipalwastes"] == "on");
			bool CropPrdRedgeTillage = (bool)(Request.Form["cropprd_ridgetillage"] == "on");
			bool CropPrdFertigation = (bool)(Request.Form["cropprd_fertigation"] == "on");
			bool CropPrdNoTill = (bool)(Request.Form["cropprd_no-till"] == "on");
			bool CropPrdSoilAnaly = (bool)(Request.Form["cropprd_soilanalysis"] == "on");
			bool CropPrdCatchCrop = (bool)(Request.Form["cropprd_catchcrops"] == "on");
			bool CropPrdCropRota = (bool)(Request.Form["cropprd_croprotation"] == "on");
			bool CropPrdCropBreed = (bool)(Request.Form["cropprd_cropbreeding"] == "on");
			bool CropPrdIrrigation = (bool)(Request.Form["cropprd_irrigation"] == "on");
			//            string CropPrdOther = MNS(Request.Form["cropprd_other"]);

			profile.CropprdAgroforesty = CropPrdAgro;
			profile.CropprdBioInoculants = CropPrdBioLogic;
            profile.CropprdForestry = CropPrdForestry;
			profile.CropprdCatchCrops = CropPrdCatchCrop;
			profile.CropprdContinousCrop = CropPrdConticrop;
			profile.CropprdCoverCrops = CropPrdCoverCrop;
			profile.CropprdCropBreeding = CropPrdCropBreed;
			profile.CropprdCropRotation = CropPrdCropRota;
			profile.CropprdDoubleCropping = CropPrdDbleCrop;
			profile.CropprdEarthworms = CropPrdEarthworms;
			profile.CropprdFallow = CropPrdFallow;
			profile.CropprdFoliarFeeding = CropPrdFolFeed;
			profile.CropprdFertigation = CropPrdFertigation;
			profile.CropprdGreenManures = CropPrdGreenManu;
			profile.CropprdInterCropping = CropPrdIntCrop;
			profile.CropprdIrrigation = CropPrdIrrigation;
			profile.CropprdMiniTillage = CropPrdMiniTillage;
			profile.CropprdMultiCropping = CropPrdMulticrop;
			profile.CropprdMunicipalWastes = CropPrdMuniWste;
			profile.CropprdNoTill = CropPrdNoTill;
			profile.CropprdNutriCycling = CropPrdNutriCyc;
			profile.CropprdOrgFertilizers = CropPrdOrgFerti;
			profile.CropprdOrgMatter = CropPrdOrgMatt;
			profile.CropprdPermaCulture = CropPrdPermaCul;
			profile.CropprdReduceApps = CropPrdReduceAppli;
			profile.CropprdRelayCropping = CropPrdRelayCrop;
			profile.CropprdRidgeTillage = CropPrdRedgeTillage;
			profile.CropprdSoilAnalysis = CropPrdSoilAnaly;
			profile.CropprdStripCropping = CropPrdStripCrop;
			profile.CropprdStubbleMulch = CropPrdStubbMulch;
			profile.CropprdTissueAnalysis = CropPrdTissueAnaly;
			profile.CropprdTrans = CropPrdTransToOrg;
			//            profile.CropprdOther = CropPrdOther;

			bool AnimPrdAltFeedStuff = (bool)(Request.Form["animprd_alternativefeedstuffs"] == "on");
			bool AnimPrdFeedRations = (bool)(Request.Form["animprd_feedrations"] == "on");
			bool AnimPrdMultiSpeciesGrz = (bool)(Request.Form["animprd_multispeciesgrazing"] == "on");
			bool AnimPrdStockPiledForg = (bool)(Request.Form["animprd_stockpiledforages"] == "on");
			bool AnimPrdAltHouse = (bool)(Request.Form["animprd_alternativehousing"] == "on");
			bool AnimPrdFreeRange = (bool)(Request.Form["animprd_freerange"] == "on");
			bool AnimPrdPastureFerti = (bool)(Request.Form["animprd_pasturefertility"] == "on");
			bool AnimPrdVaccine = (bool)(Request.Form["animprd_vaccines"] == "on");
			bool AnimPrdAltParasiteCont = (bool)(Request.Form["animprd_alternparasitecontrol"] == "on");
			bool AnimPrdHerbalMed = (bool)(Request.Form["animprd_herbalmedicines"] == "on");
			bool AnimPrdPastureReno = (bool)(Request.Form["animprd_pasturerenovation"] == "on");
			bool AnimPrdWaterSys = (bool)(Request.Form["animprd_wateringsystem"] == "on");
			bool AnimPrdAnimalProtect = (bool)(Request.Form["animprd_animalprotection"] == "on");
			bool AnimPrdHomeopathy = (bool)(Request.Form["animprd_homeopathy"] == "on");
			bool AnimPrdPrePrac = (bool)(Request.Form["animprd_preventivepractices"] == "on");
			bool AnimPrdWinterForage = (bool)(Request.Form["animprd_winterforage"] == "on");
			bool AnimPrdComposting = (bool)(Request.Form["animprd_composting"] == "on");
			bool AnimPrdImplants = (bool)(Request.Form["animprd_implants"] == "on");
			bool AnimPrdProbiotics = (bool)(Request.Form["animprd_probiotics"] == "on");
			bool AnimPrdContGraze = (bool)(Request.Form["animprd_continuousgrazing"] == "on");
			bool AnimPrdInoculants = (bool)(Request.Form["animprd_inoculants"] == "on");
			bool AnimPrdRangeImp = (bool)(Request.Form["animprd_rangeimprovement"] == "on");
			bool AnimPrdFeedAddti = (bool)(Request.Form["animprd_feedadditives"] == "on");
			bool AnimPrdManuMgmt = (bool)(Request.Form["animprd_manuremanagement"] == "on");
			bool AnimPrdRotaGraz = (bool)(Request.Form["animprd_rotationalgrazing"] == "on");
			bool AnimPrdFeedFormula = (bool)(Request.Form["animprd_feedformulation"] == "on");
			bool AnimPrdMineralSupp = (bool)(Request.Form["animprd_mineralsupplements"] == "on");
			bool AnimPrdShadShelter = (bool)(Request.Form["animprd_shadeshelter"] == "on");
			bool AnimPrdGrazMgmt = (bool)(Request.Form["animprd_grazingmanagement"] == "on");
			bool AnimPrdTherapeutics = (bool)(Request.Form["animprd_therapeutics"] == "on");
			bool AnimPrdLiveBreed = (bool)(Request.Form["animprd_livestockbreeding"] == "on");
			bool AnimPrdStockRate = (bool)(Request.Form["animprd_stockingrate"] == "on");
			//            string AnimPrdOther = MNS(Request.Form["animprd_other"]);

			profile.AnimprdAltFeedstuffs = AnimPrdAltFeedStuff;
			profile.AnimprdAltHousing = AnimPrdAltHouse;
			profile.AnimprdAltParasiteControl = AnimPrdAltParasiteCont;
			profile.AnimprdAnimalProtection = AnimPrdAnimalProtect;
			profile.AnimprdComposting = AnimPrdComposting;
			profile.AnimprdContGrazing = AnimPrdContGraze;
			profile.AnimprdFeedAdditives = AnimPrdFeedAddti;
			profile.AnimprdFeedFormulation = AnimPrdFeedFormula;
			profile.AnimprdFeedRations = AnimPrdFeedRations;
			profile.AnimprdFreeRange = AnimPrdFreeRange;
			profile.AnimprdGrazMgmt = AnimPrdGrazMgmt;
			profile.AnimprdHerbalMed = AnimPrdHerbalMed;
			profile.AnimprdHomeopathy = AnimPrdHomeopathy;
			profile.AnimprdImplants = AnimPrdImplants;
			profile.AnimprdInoculants = AnimPrdInoculants;
			profile.AnimprdLivestockBreeding = AnimPrdLiveBreed;
			profile.AnimprdManureMgmt = AnimPrdManuMgmt;
			profile.AnimprdMineralSupp = AnimPrdMineralSupp;
			profile.AnimprdMultiSpeciesGrazing = AnimPrdMultiSpeciesGrz;
			//            profile.AnimprdOther = AnimPrdOther;
			profile.AnimprdPastureFerti = AnimPrdPastureFerti;
			profile.AnimprdPastureRenovation = AnimPrdPastureReno;
			profile.AnimprdPreventivePract = AnimPrdPrePrac;
			profile.AnimprdProbiotics = AnimPrdProbiotics;
			profile.AnimprdRangeImprovement = AnimPrdRangeImp;
			profile.AnimprdRotGrazing = AnimPrdRotaGraz;
			profile.AnimprdShadeShelter = AnimPrdShadShelter;
			profile.AnimprdStockingRate = AnimPrdStockRate;
			profile.AnimprdStockpiledForages = AnimPrdStockPiledForg;
			profile.AnimprdTherapeutics = AnimPrdTherapeutics;
			profile.AnimprdVaccines = AnimPrdVaccine;
			profile.AnimprdWateringSys = AnimPrdWaterSys;
			profile.AnimprdWinterForage = AnimPrdWinterForage;

			bool PestMgmtAllelopathy = (bool)(Request.Form["pestmgt_allelopathy"] == "on");
			bool PestMgmtEcoThres = (bool)(Request.Form["pestmgt_economicthreshold"] == "on");
			bool PestMgmtMechCont = (bool)(Request.Form["pestmgt_mechanicalcontrol"] == "on");
			bool PestMgmtSmthCrop = (bool)(Request.Form["pestmgt_smothercrops"] == "on");
			bool PestMgmtBioCont = (bool)(Request.Form["pestmgt_biologicalcontrol"] == "on");
			bool PestMgmtEradication = (bool)(Request.Form["pestmgt_eradication"] == "on");
			bool PestMgmtPhyCont = (bool)(Request.Form["pestmgt_physicalcontrol"] == "on");
			bool PestMgmtTraps = (bool)(Request.Form["pestmgt_traps"] == "on");
			bool PestMgmtBioratPest = (bool)(Request.Form["pestmgt_biorationalpesticides"] == "on");
			bool PestMgmtFlame = (bool)(Request.Form["pestmgt_flame"] == "on");
			bool PestMgmtPlstMulch = (bool)(Request.Form["pestmgt_plasticmulching"] == "on");
			bool PestMgmtTrapCrop = (bool)(Request.Form["pestmgt_trapcrops"] == "on");
			bool PestMgmtBotPest = (bool)(Request.Form["pestmgt_botanicalpesticides"] == "on");
			bool PestMgmtFieldMoni = (bool)(Request.Form["pestmgt_fieldmonitoring"] == "on");
			bool PestMgmtPreciCult = (bool)(Request.Form["pestmgt_precisioncultivation"] == "on");
			bool PestMgmtVegMulch = (bool)(Request.Form["pestmgt_vegetativemulching"] == "on");
			bool PestMgmtChemCont = (bool)(Request.Form["pestmgt_chemicalcontrol"] == "on");
			bool PestMgmtGeneticResis = (bool)(Request.Form["pestmgt_geneticresistance"] == "on");
			bool PestMgmtpreciheruse = (bool)(Request.Form["pestmgt_precisionherbicideuse"] == "on");
			bool PestMgmtWeatherMoni = (bool)(Request.Form["pestmgt_weathermonitoring"] == "on");
			bool PestMgmtCompetition = (bool)(Request.Form["pestmgt_competition"] == "on");
			bool PestMgmtIPM = (bool)(Request.Form["pestmgt_IPM"] == "on");
			bool PestMgmtPrevention = (bool)(Request.Form["pestmgt_prevention"] == "on");
			bool PestMgmtWeedEco = (bool)(Request.Form["pestmgt_weedecology"] == "on");
			bool PestMgmtCompostExt = (bool)(Request.Form["pestmgt_compostextracts"] == "on");
			bool PestMgmtKilledMulch = (bool)(Request.Form["pestmgt_killedmulches"] == "on");
			bool PestMgmtRowCover = (bool)(Request.Form["pestmgt_rowcovers"] == "on");
			bool PestMgmtWeedGeese = (bool)(Request.Form["pestmgt_weedergeese"] == "on");
			bool PestMgmtculturalCont = (bool)(Request.Form["pestmgt_culturalcontrol"] == "on");
			bool PestMgmtLivingMulch = (bool)(Request.Form["pestmgt_livingmulches"] == "on");
			bool PestMgmtSanitation = (bool)(Request.Form["pestmgt_sanitation"] == "on");
			bool PestMgmtDiseaseVect = (bool)(Request.Form["pestmgt_diseasevectors"] == "on");
			bool PestMgmtMatingDis = (bool)(Request.Form["pestmgt_matingdisruption"] == "on");
			bool PestMgmtSoilSolar = (bool)(Request.Form["pestmgt_soilsolarization"] == "on");
			//            string PestMgmtOther = MNS(Request.Form["pestmgt_other"]);

			profile.PestMgmtAllelopathy = PestMgmtAllelopathy;
			profile.PestMgmtBioControl = PestMgmtBioCont;
			profile.PestMgmtBioPest = PestMgmtBioratPest;
			profile.PestMgmtBotaPest = PestMgmtBotPest;
			profile.PestMgmtChemControl = PestMgmtChemCont;
			profile.PestMgmtCompetition = PestMgmtCompetition;
			profile.PestMgmtCompostExtracts = PestMgmtCompostExt;
			profile.PestMgmtCulturalControl = PestMgmtculturalCont;
			profile.PestMgmtDiseaseVectors = PestMgmtDiseaseVect;
			profile.PestMgmtEcoThreshold = PestMgmtEcoThres;
			profile.PestMgmtEradication = PestMgmtEradication;
			profile.PestMgmtFieldMonitoring = PestMgmtFieldMoni;
			profile.PestMgmtFlame = PestMgmtFlame;
			profile.PestMgmtGeneticResis = PestMgmtGeneticResis;
			profile.PestMgmtIPM = PestMgmtIPM;
			profile.PestMgmtKilledMulches = PestMgmtKilledMulch;
			profile.PestMgmtLivingMulches = PestMgmtLivingMulch;
			profile.PestMgmtMatingDisruption = PestMgmtMatingDis;
			profile.PestMgmtMechControl = PestMgmtMechCont;
			//            profile.PestMgmtOther = PestMgmtOther;
			profile.PestMgmtPhyControl = PestMgmtPhyCont;
			profile.PestMgmtPlasticMulch = PestMgmtPlstMulch;
			profile.PestMgmtPrecisiCulti = PestMgmtPreciCult;
			profile.PestMgmtPrecisiHerbicideUse = PestMgmtpreciheruse;
			profile.PestMgmtPrevention = PestMgmtPrevention;
			profile.PestMgmtRowCovers = PestMgmtRowCover;
			profile.PestMgmtSanitation = PestMgmtSanitation;
			profile.PestMgmtSmotherCrops = PestMgmtSmthCrop;
			profile.PestMgmtSoilSolar = PestMgmtSoilSolar;
			profile.PestMgmtTrapCrops = PestMgmtTrapCrop;
			profile.PestMgmtTraps = PestMgmtTraps;
			profile.PestMgmtVegMulch = PestMgmtVegMulch;
			profile.PestMgmtWeatherMoni = PestMgmtWeatherMoni;
			profile.PestMgmtWeedEco = PestMgmtWeedEco;
			profile.PestMgmtWeedGeese = PestMgmtWeedGeese;

			bool SoilMgmtNutriMineral = (bool)(Request.Form["soilmgt_nutrientmineralization"] == "on");
			bool SoilMgmtSoilBio = (bool)(Request.Form["soilmgt_SoilMicrobiology"] == "on");
			bool SoilMgmtSoilOrgMatter = (bool)(Request.Form["soilmgt_soilorganicmatter"] == "on");
			bool SoilMgmtSoilQty = (bool)(Request.Form["soilmgt_soilquality"] == "on");
			bool SoilMgmtSoilChem = (bool)(Request.Form["soilmgt_soilchemistry"] == "on");
			bool SoilMgmtSoilPhy = (bool)(Request.Form["soilmgt_soilphysics"] == "on");
			bool SoilMgmtCarbonSeq = (bool)(Request.Form["soilmgt_carbonsequestration"] == "on");
			//            string SoilMgmtOther = MNS(Request.Form["soilmgt_other"]);

			profile.SoilMgmtCarbonSequestration = SoilMgmtCarbonSeq;
			profile.SoilMgmtNutriMineralization = SoilMgmtNutriMineral;
			profile.SoilMgmtOrgtMatter = SoilMgmtSoilOrgMatter;
			//            profile.SoilMgmtOther = SoilMgmtOther;
			profile.SoilMgmtQty = SoilMgmtSoilQty;
			profile.SoilMgmtSoilMicroBio = SoilMgmtSoilBio;
			profile.SoilMgmtSoilChem = SoilMgmtSoilChem;
			profile.SoilMgmtSoilPhy = SoilMgmtSoilPhy;

			bool NResEnvAfforestation = (bool)(Request.Form["nresenv_afforestation"] == "on");
			bool NResEnvGrassHedges = (bool)(Request.Form["nresenv_grasshedges"] == "on");
			bool NResEnvRipariPlant = (bool)(Request.Form["nresenv_riparianplantings"] == "on");
			bool NResEnvWildlife = (bool)(Request.Form["nresenv_wildlife"] == "on");
			bool NResEnvBioDiver = (bool)(Request.Form["nresenv_biodiversity"] == "on");
			bool NResEnvGrassWater = (bool)(Request.Form["nresenv_grasswaterways"] == "on");
			bool NResEnvRiverBankProtect = (bool)(Request.Form["nresenv_riverbankprotection"] == "on");
			bool NResEnvWindBreak = (bool)(Request.Form["nresenv_windbreaks"] == "on");
			bool NResEnvBiosphere = (bool)(Request.Form["nresenv_biosphere"] == "on");
			bool NResEnvHabitEnhance = (bool)(Request.Form["nresenv_habitatenhancement"] == "on");
			bool NResEnvSoilStab = (bool)(Request.Form["nresenv_soilstabilization"] == "on");
			bool NResEnvWoodyHedge = (bool)(Request.Form["nresenv_woodyhedges"] == "on");
			bool NResEnvConservTillage = (bool)(Request.Form["nresenv_conservationtillage"] == "on");
			bool NResEnvHedgeRow = (bool)(Request.Form["nresenv_hedgerows"] == "on");
			bool NResEnvTerraces = (bool)(Request.Form["nresenv_terraces"] == "on");
			bool NResEnvContourCulti = (bool)(Request.Form["nresenv_contourcultivation"] == "on");
			bool NResEnvIndicators = (bool)(Request.Form["nresenv_indicators"] == "on");
			bool NResEnvWetlands = (bool)(Request.Form["nresenv_wetlands"] == "on");
			//            string NResEnvOther = MNS(Request.Form["nresenv_other"]);

			profile.NResEnvAfforestation = NResEnvAfforestation;
			profile.NResEnvBiodiver = NResEnvBioDiver;
			profile.NResEnvBiosphere = NResEnvBiosphere;
			profile.NResEnvConserTillage = NResEnvConservTillage;
			profile.NResEnvContourCulti = NResEnvContourCulti;
			profile.NResEnvGrassHedges = NResEnvGrassHedges;
			profile.NResEnvGrassWaterWays = NResEnvGrassWater;
			profile.NResEnvHabitatEnhance = NResEnvHabitEnhance;
			profile.NResEnvHedgerows = NResEnvHedgeRow;
			profile.NResEnvIndi = NResEnvIndicators;
			//            profile.NResEnvOther = NResEnvOther;
			profile.NResEnvRiparianPlantings = NResEnvRipariPlant;
			profile.NResEnvRiverBnkProtect = NResEnvRiverBankProtect;
			profile.NResEnvSoilStabilization = NResEnvSoilStab;
			profile.NResEnvTerraces = NResEnvTerraces;
			profile.NResEnvWetlands = NResEnvWetlands;
			profile.NResEnvWildlife = NResEnvWildlife;
			profile.NResEnvWindbreaks = NResEnvWindBreak;
			profile.NResEnvWoodyHedges = NResEnvWoodyHedge;

			bool EduTrnCaseStudy = (bool)(Request.Form["edu_trn_casestudy"] == "on");
			bool EduTrnDemo = (bool)(Request.Form["edu_trn_demonstration"] == "on");
			bool EduTrnFocusGroup = (bool)(Request.Form["edu_trn_focusgroup"] == "on");
			bool EduTrnStudyCircle = (bool)(Request.Form["edu_trn_studycircle"] == "on");
			bool EduTrnConfer = (bool)(Request.Form["edu_trn_conference"] == "on");
			bool EduTrnDisplay = (bool)(Request.Form["edu_trn_display"] == "on");
			bool EduTrnMentoring = (bool)(Request.Form["edu_trn_mentoring"] == "on");
			bool EduTrnWorkshop = (bool)(Request.Form["edu_trn_workshop"] == "on");
			bool EduTrnCurriculum = (bool)(Request.Form["edu_trn_curriculum"] == "on");
			bool EduTrnExt = (bool)(Request.Form["edu_trn_Extension"] == "on");
			bool EduTrnNetwork = (bool)(Request.Form["edu_trn_network"] == "on");
			bool EduTrnDB = (bool)(Request.Form["edu_trn_database"] == "on");
			bool EduTrnFactSheet = (bool)(Request.Form["edu_trn_factsheet"] == "on");
			bool EduTrnOnFarmRes = (bool)(Request.Form["edu_trn_on-farmresearch"] == "on");
			bool EduTrnDeciSupportSys = (bool)(Request.Form["edu_trn_decisionsupportsystem"] == "on");
			bool EduTrnFarmToFarm = (bool)(Request.Form["edu_trn_farmertofarmer"] == "on");
			bool EduTrnPartRes = (bool)(Request.Form["edu_trn_participatoryresearch"] == "on");
			bool EduTrnYouthEdu = (bool)(Request.Form["edu_trn_youtheducation"] == "on");
			//            string EduTrnOther = MNS(Request.Form["edu_trn_other"]);

			profile.EdTrainCaseStudy = EduTrnCaseStudy;
			profile.EdTrainConference = EduTrnConfer;
			profile.EdTrainCurriculum = EduTrnCurriculum;
			profile.EdTrainDB = EduTrnDB;
			profile.EdTrainDecisionSupportSys = EduTrnDeciSupportSys;
			profile.EdTrainDemo = EduTrnDemo;
			profile.EdTrainDisplay = EduTrnDisplay;
			profile.EdTrainExt = EduTrnExt;
			profile.EdTrainFactSheet = EduTrnFactSheet;
			profile.EdTrainFarmerToFarmer = EduTrnFarmToFarm;
			profile.EdTrainFocusGroup = EduTrnFocusGroup;
			profile.EdTrainMentor = EduTrnMentoring;
			profile.EdTrainNet = EduTrnNetwork;
			profile.EdTrainOnFarmResearch = EduTrnOnFarmRes;
			//            profile.EdTrainOther = EduTrnOther;
			profile.EdTrainParticipatoryResearch = EduTrnPartRes;
			profile.EdTrainStudyCircle = EduTrnStudyCircle;
			profile.EdTrainWorkshop = EduTrnWorkshop;
			profile.EdTrainYouthEdu = EduTrnYouthEdu;

			bool EconMktAltEnt = (bool)(Request.Form["econmkt_alternativeenterprise"] == "on");
			bool EconMktCSA = (bool)(Request.Form["econmkt_CSA"] == "on");
			bool EconMktFeasibilityStudy = (bool)(Request.Form["econmkt_feasibilitystudy"] == "on");
			bool EconMktRiskMgmt = (bool)(Request.Form["econmkt_riskmanagement"] == "on");
			bool EconMktBudget = (bool)(Request.Form["econmkt_budget"] == "on");
			bool EconMktCostNReturn = (bool)(Request.Form["econmkt_costandreturns"] == "on");
			bool EconMktFinAnaly = (bool)(Request.Form["econmkt_financialanalysis"] == "on");
			bool EconMktValueAdd = (bool)(Request.Form["econmkt_valueadded"] == "on");
			bool EconMktCoop = (bool)(Request.Form["econmkt_cooperatives"] == "on");
			bool EconMktDirectMark = (bool)(Request.Form["econmkt_directmarketing"] == "on");
			bool EconMktMarkStudy = (bool)(Request.Form["econmkt_marketstudy"] == "on");
			bool EconMktFoodProdQtySafe = (bool)(Request.Form["econmkt_foodproductqualitysafety"] == "on");
			bool EconMktLaborEmp = (bool)(Request.Form["econmkt_laboremployment"] == "on");
			bool EconMktECom = (bool)(Request.Form["econmkt_e-commerce"] == "on");
			bool EconMktFarmInst = (bool)(Request.Form["econmkt_farmtoinstitution"] == "on");
			//            string EconMktOther = MNS(Request.Form["econmkt_other"]);

			profile.EconMktAltEnt = EconMktAltEnt;
			profile.EconMktBudget = EconMktBudget;
			profile.EconMktCoop = EconMktCoop;
			profile.EconMktCostNReturns = EconMktCostNReturn;
			profile.EconMktCSA = EconMktCSA;
			profile.EconMktDirectMkt = EconMktDirectMark;
			profile.EconMktECom = EconMktECom;
			profile.EconMktFarmToInstitution = EconMktFarmInst;
			profile.EconMktFeasibilityStudy = EconMktFeasibilityStudy;
			profile.EconMktFinAnalysis = EconMktFinAnaly;
			profile.EconMktFoodProductQtySafety = EconMktFoodProdQtySafe;
			profile.EconMktLaborEmp = EconMktLaborEmp;
			profile.EconMktMarketStudy = EconMktMarkStudy;
			//            profile.EconMktOther = EconMktOther;
			profile.EconMktRiskMgmt = EconMktRiskMgmt;
			profile.EconMktValueAdd = EconMktValueAdd;


			bool CommDevInfraAnaly = (bool)(Request.Form["commdev_infrastructureanalysis"] == "on");
			bool CommDevTechAssist = (bool)(Request.Form["commdev_technicalassistance"] == "on");
			bool CommDevNewBusOpp = (bool)(Request.Form["commdev_newbusinessopportunities"] == "on");
			bool CommDevPartnerships = (bool)(Request.Form["commdev_partnerships"] == "on");
			bool CommDevUrbanAgri = (bool)(Request.Form["commdev_urbanagriculture"] == "on");
			bool CommDevPublicPart = (bool)(Request.Form["commdev_publicparticipation"] == "on");
			bool CommDevUrbanRuralInt = (bool)(Request.Form["commdev_urbanruralintegration"] == "on");
			bool CommDevLocalRegComFoodSys = (bool)(Request.Form["commdev_localregionalcommunityfoodsystems"] == "on");
			bool CommDevAgritourism = (bool)(Request.Form["commdev_agritourism"] == "on");
			bool CommDevCommPlan = (bool)(Request.Form["commdev_communityplanning"] == "on");
			bool CommDevPublicPolicy = (bool)(Request.Form["commdev_publicpolicy"] == "on");
			bool CommDevLeadDev = (bool)(Request.Form["commdev_leadershipdevelopment"] == "on");
			bool CommDevEthicDiffCultDemo = (bool)(Request.Form["commdev_ethnicdifferencesculturaldemographicchange"] == "on");
			//            string CommDevOther = MNS(Request.Form["commdev_other"]);

			profile.CommDevAgritourism = CommDevAgritourism;
			profile.CommDevCommunityPlanning = CommDevCommPlan;
			profile.CommDevEthnicDiffCulturDemoChange = CommDevEthicDiffCultDemo;
			profile.CommDevInfraAnalysis = CommDevInfraAnaly;
			profile.CommDevLeadershipDev = CommDevLeadDev;
			profile.CommDevLocalRegionalCommunityFoodSys = CommDevLocalRegComFoodSys;
			profile.CommDevNewBusOpp = CommDevNewBusOpp;
			//            profile.CommDevOther = CommDevOther;
			profile.CommDevPartner = CommDevPartnerships;
			profile.CommDevPublicPolicy = CommDevPublicPolicy;
			profile.CommDevPubPart = CommDevPublicPart;
			profile.CommDevTechAssist = CommDevTechAssist;
			profile.CommDevUrbanAgri = CommDevUrbanAgri;
			profile.CommDevUrbanRuralInt = CommDevUrbanRuralInt;

			bool QOfLifeAnalyPerFam = (bool)(Request.Form["qoflife_analysisofpersonalfamilylife"] == "on");
			bool QOfLifeSocialCapital = (bool)(Request.Form["qoflife_socialcapital"] == "on");
			bool QOfLifeSusMeasure = (bool)(Request.Form["qoflife_sustainabilitymeasures"] == "on");
			bool QOfLifeCommSrv = (bool)(Request.Form["qoflife_communityservices"] == "on");
			bool QOfLifeSocialNet = (bool)(Request.Form["qoflife_socialnetworks"] == "on");
			bool QOfLifeEmpOpp = (bool)(Request.Form["qoflife_employmentopportunities"] == "on");
			bool QOfLifeSocialPsyInc = (bool)(Request.Form["qoflife_socialpsychologicalindicators"] == "on");
			//            string QOfLifeOther = MNS(Request.Form["qoflife_other"]);

			profile.QofLifeAnalysisOfPersonalFamilyLife = QOfLifeAnalyPerFam;
			profile.QofLifeCommunitySrv = QOfLifeCommSrv;
			profile.QofLifeEmpOpp = QOfLifeEmpOpp;
			//            profile.QofLifeOther = QOfLifeOther;
			profile.QofLifeSocialCap = QOfLifeSocialCapital;
			profile.QofLifeSocialNet = QOfLifeSocialNet;
			profile.QofLifeSocialPsyInd = QOfLifeSocialPsyInc;
			profile.QofLifeSustainMeasures = QOfLifeSusMeasure;

			bool EngConsBioEngNFuel = (bool)(Request.Form["engcons_bioenergyandbiofuels"] == "on");
			bool EngConsWindPower = (bool)(Request.Form["engcons_windpower"] == "on");
			bool EngConsEngUseNConsump = (bool)(Request.Form["engcons_energyuseandconsumption"] == "on");
			bool EngConsSolarEng = (bool)(Request.Form["engcons_solarenergy"] == "on");
			bool EngConsEngConserEff = (bool)(Request.Form["engcons_energyconservationefficiency"] == "on");
			//            string EngConsOther = MNS(Request.Form["engcons_other"]);

			profile.EngBioEngFuels = EngConsBioEngNFuel;
			profile.EngEngConservEff = EngConsEngConserEff;
			profile.EngEngUseConsumption = EngConsEngUseNConsump;
			//            profile.EngOther = EngConsOther;
			profile.EngSolarEng = EngConsSolarEng;
			profile.EngWindPower = EngConsWindPower;

			bool CommplAgrBarley = (bool)(Request.Form["commplagr_barley"] == "on");
			bool CommplAgrGrassLegumeHay = (bool)(Request.Form["commplagr_grasslegumehay"] == "on");
			bool CommplAgrPeanuts = (bool)(Request.Form["commplagr_peanuts"] == "on");
			bool CommplAgrSorghum = (bool)(Request.Form["commplagr_sorghum"] == "on");
			bool CommplAgrSweetpotatoes = (bool)(Request.Form["commplagr_sweetpotatoes"] == "on");
			bool CommplAgrCanola = (bool)(Request.Form["commplagr_canola"] == "on");
			bool CommplAgrLegumeHay = (bool)(Request.Form["commplagr_legumehay"] == "on");
			bool CommplAgrPotatoes = (bool)(Request.Form["commplagr_potatoes"] == "on");
			bool CommplAgrSoybeans = (bool)(Request.Form["commplagr_soybeans"] == "on");
			bool CommplAgrTobacco = (bool)(Request.Form["commplagr_tobacco"] == "on");
			bool CommplAgrCorn = (bool)(Request.Form["commplagr_corn"] == "on");
			bool CommplAgrHops = (bool)(Request.Form["commplagr_hops"] == "on");
			bool CommplAgrRapeseed = (bool)(Request.Form["commplagr_rapeseed"] == "on");
			bool CommplAgrSpelt = (bool)(Request.Form["commplagr_spelt"] == "on");
			bool CommplAgrWheat = (bool)(Request.Form["commplagr_wheat"] == "on");
			bool CommplAgrCotton = (bool)(Request.Form["commplagr_cotton"] == "on");
			bool CommplAgrKenaf = (bool)(Request.Form["commplagr_kenaf"] == "on");
			bool CommplAgrRice = (bool)(Request.Form["commplagr_rice"] == "on");
			bool CommplAgrSugarbeets = (bool)(Request.Form["commplagr_sugarbeets"] == "on");
			bool CommplAgrFlax = (bool)(Request.Form["commplagr_flax"] == "on");
			bool CommplAgrMillet = (bool)(Request.Form["commplagr_millet"] == "on");
			bool CommplAgrRye = (bool)(Request.Form["commplagr_rye"] == "on");
			bool CommplAgrSugarcane = (bool)(Request.Form["commplagr_sugarcane"] == "on");
			bool CommplAgrGrassHay = (bool)(Request.Form["commplagr_grasshay"] == "on");
			bool CommplAgrOats = (bool)(Request.Form["commplagr_oats"] == "on");
			bool CommplAgrSafflower = (bool)(Request.Form["commplagr_safflower"] == "on");
			bool CommplAgrSunflower = (bool)(Request.Form["commplagr_sunflower"] == "on");
			//            string CommplAgrOther = MNS(Request.Form["commplagr_Other"]);

			profile.CommPlAgrBarley = CommplAgrBarley;
			profile.CommPlAgrCanola = CommplAgrCanola;
			profile.CommPlAgrCorn = CommplAgrCorn;
			profile.CommPlAgrCotton = CommplAgrCotton;
			profile.CommPlAgrFlax = CommplAgrFlax;
			profile.CommPlAgrGrassHay = CommplAgrGrassHay;
			profile.CommPlAgrGrassLegHay = CommplAgrGrassLegumeHay;
			profile.CommPlAgrHops = CommplAgrHops;
			profile.CommPlAgrKenaf = CommplAgrKenaf;
			profile.CommPlAgrLegHay = CommplAgrLegumeHay;
			profile.CommPlAgrMillet = CommplAgrMillet;
			profile.CommPlAgrOats = CommplAgrOats;
			//            profile.CommPlAgrOther = CommplAgrOther;
			profile.CommPlAgrPeanuts = CommplAgrPeanuts;
			profile.CommPlAgrPotatoes = CommplAgrPotatoes;
			profile.CommPlAgrRapeseed = CommplAgrRapeseed;
			profile.CommPlAgrRice = CommplAgrRice;
			profile.CommPlAgrRye = CommplAgrRye;
			profile.CommPlAgrSafflower = CommplAgrSafflower;
			profile.CommPlAgrSorghum = CommplAgrSorghum;
			profile.CommPlAgrSoybeans = CommplAgrSoybeans;
			profile.CommPlAgrSpelt = CommplAgrSpelt;
			profile.CommPlAgrSugarbeets = CommplAgrSugarbeets;
			profile.CommPlAgrSugarcane = CommplAgrSugarcane;
			profile.CommPlAgrSunflower = CommplAgrSunflower;
			profile.CommPlAgrSweetpotatoes = CommplAgrSweetpotatoes;
			profile.CommPlAgrTobacco = CommplAgrTobacco;
			profile.CommPlAgrWheat = CommplAgrWheat;

			bool CommplVegArtichokes = (bool)(Request.Form["commplveg_artichokes"] == "on");
			bool CommplVegCabbage = (bool)(Request.Form["commplveg_cabbage"] == "on");
			bool CommplVegEscarole = (bool)(Request.Form["commplveg_escarole"] == "on");
			bool CommplVegOnions = (bool)(Request.Form["commplveg_onions"] == "on");
			bool CommplVegSweetcorn = (bool)(Request.Form["commplveg_sweetcorn"] == "on");
			bool CommplVegAsparagus = (bool)(Request.Form["commplveg_asparagus"] == "on");
			bool CommplVegCarrots = (bool)(Request.Form["commplveg_carrots"] == "on");
			bool CommplVegGarlic = (bool)(Request.Form["commplveg_garlic"] == "on");
			bool CommplVegParsnips = (bool)(Request.Form["commplveg_parsnips"] == "on");
			bool CommplVegTomatoes = (bool)(Request.Form["commplveg_tomatoes"] == "on");
			bool CommplVegBeans = (bool)(Request.Form["commplveg_beans"] == "on");
			bool CommplVegCauliflower = (bool)(Request.Form["commplveg_cauliflower"] == "on");
			bool CommplVegGreens = (bool)(Request.Form["commplveg_greens"] == "on");
			bool CommplVegPeas = (bool)(Request.Form["commplveg_peas"] == "on");
			bool CommplVegTurnips = (bool)(Request.Form["commplveg_turnips"] == "on");
			bool CommplVegBeets = (bool)(Request.Form["commplveg_beets"] == "on");
			bool CommplVegCelery = (bool)(Request.Form["commplveg_celery"] == "on");
			bool CommplVegKale = (bool)(Request.Form["commplveg_kale"] == "on");
			bool CommplVegPeppers = (bool)(Request.Form["commplveg_peppers"] == "on");
			bool CommplVegWatermelon = (bool)(Request.Form["commplveg_watermelon"] == "on");
			bool CommplVegBroccoli = (bool)(Request.Form["commplveg_broccoli"] == "on");
			bool CommplVegCucumbers = (bool)(Request.Form["commplveg_cucumbers"] == "on");
			bool CommplVegLentils = (bool)(Request.Form["commplveg_lentils"] == "on");
			bool CommplVegRutabagas = (bool)(Request.Form["commplveg_rutabagas"] == "on");
			bool CommplVegBrusselSprouts = (bool)(Request.Form["commplveg_brusselsprouts"] == "on");
			bool CommplVegEggplant = (bool)(Request.Form["commplveg_eggplant"] == "on");
			bool CommplVegLettuce = (bool)(Request.Form["commplveg_lettuce"] == "on");
			bool CommplVegSpinach = (bool)(Request.Form["commplveg_spinach"] == "on");
			bool CommplVegLeeks = (bool)(Request.Form["commplveg_leeks"] == "on");
			bool CommplVegPumpkins = (bool)(Request.Form["commplveg_pumpkins"] == "on");
			bool CommplVegSquashes = (bool)(Request.Form["commplveg_squashes"] == "on");
			bool CommplVegRadishes = (bool)(Request.Form["commplveg_radishes"] == "on");
			//            string CommplVegOther = MNS(Request.Form["commplveg_Other"]);

			profile.CommPlVegArtichokes = CommplVegArtichokes;
			profile.CommPlVegAsparagus = CommplVegAsparagus;
			profile.CommPlVegBeans = CommplVegBeans;
			profile.CommPlVegBeets = CommplVegBeets;
			profile.CommPlVegBroccoli = CommplVegBroccoli;
			profile.CommPlVegBrusselSprouts = CommplVegBrusselSprouts;
			profile.CommPlVegCabbage = CommplVegCabbage;
			profile.CommPlVegCarrots = CommplVegCarrots;
			profile.CommPlVegCauliflower = CommplVegCauliflower;
			profile.CommPlVegCelery = CommplVegCelery;
			profile.CommPlVegCucumbers = CommplVegCucumbers;
			profile.CommPlVegEggplant = CommplVegEggplant;
			profile.CommPlVegEscarole = CommplVegEscarole;
			profile.CommPlVegGarlic = CommplVegGarlic;
			profile.CommPlVegGreens = CommplVegGreens;
			profile.CommPlVegKale = CommplVegKale;
			profile.CommPlVegLeeks = CommplVegLeeks;
			profile.CommPlVegLentils = CommplVegLentils;
			profile.CommPlVegLettuce = CommplVegLettuce;
			profile.CommPlVegOnions = CommplVegOnions;
			//            profile.CommPlVegOther = CommplVegOther;
			profile.CommPlVegParsnips = CommplVegParsnips;
			profile.CommPlVegPeas = CommplVegPeas;
			profile.CommPlVegPeppers = CommplVegPeppers;
			profile.CommPlVegRutabagas = CommplVegRutabagas;
			profile.CommPlVegSpinach = CommplVegSpinach;
			profile.CommPlVegPumpkins = CommplVegPumpkins;
			profile.CommPlVegRadishes = CommplVegRadishes;
			profile.CommPlVegSquashes = CommplVegSquashes;
			profile.CommPlVegSweetCorn = CommplVegSweetcorn;
			profile.CommPlVegTomatoes = CommplVegTomatoes;
			profile.CommPlVegTurnips = CommplVegTurnips;
			profile.CommPlVegWatermelon = CommplVegWatermelon;

			bool CommplFruitApples = (bool)(Request.Form["commplfruit_apples"] == "on");
			bool CommplFruitCherries = (bool)(Request.Form["ccommplfruit_cherries"] == "on");
			bool CommplFruitLemons = (bool)(Request.Form["ccommplfruit_lemons"] == "on");
			bool CommplFruitPeaches = (bool)(Request.Form["ccommplfruit_peaches"] == "on");
			bool CommplFruitStrawberries = (bool)(Request.Form["ccommplfruit_strawberries"] == "on");
			bool CommplFruitApricots = (bool)(Request.Form["ccommplfruit_apricots"] == "on");
			bool CommplFruitCranberries = (bool)(Request.Form["ccommplfruit_cranberries"] == "on");
			bool CommplFruitLimes = (bool)(Request.Form["ccommplfruit_limes"] == "on");
			bool CommplFruitPears = (bool)(Request.Form["ccommplfruit_pears"] == "on");
			bool CommplFruitFigs = (bool)(Request.Form["ccommplfruit_figs"] == "on");
			bool CommplFruitMelons = (bool)(Request.Form["ccommplfruit_melons"] == "on");
			bool CommplFruitPineapples = (bool)(Request.Form["ccommplfruit_pineapples"] == "on");
			bool CommplFruitAvocados = (bool)(Request.Form["ccommplfruit_avocados"] == "on");
			bool CommplFruitTangerines = (bool)(Request.Form["ccommplfruit_tangerines"] == "on");
			bool CommplFruitBananas = (bool)(Request.Form["ccommplfruit_bananas"] == "on");
			bool CommplFruitGrapefruit = (bool)(Request.Form["ccommplfruit_grapefruit"] == "on");
			bool CommplFruitOlives = (bool)(Request.Form["ccommplfruit_olives"] == "on");
			bool CommplFruitPlums = (bool)(Request.Form["ccommplfruit_plums"] == "on");
			bool CommplFruitBerries = (bool)(Request.Form["ccommplfruit_berries"] == "on");
			bool CommplFruitGrapes = (bool)(Request.Form["ccommplfruit_grapes"] == "on");
			bool CommplFruitOranges = (bool)(Request.Form["ccommplfruit_oranges"] == "on");
			bool CommplFruitQuinces = (bool)(Request.Form["ccommplfruit_quinces"] == "on");
			bool CommplFruitBrambles = (bool)(Request.Form["ccommplfruit_brambles"] == "on");
			bool CommplFruitBlueberries = (bool)(Request.Form["ccommplfruit_blueberries"] == "on");
			//            string CommplFruitOther = MNS(Request.Form["ccommplfruit_Other"]);

			profile.CommPlFruitApples = CommplFruitApples;
			profile.CommPlFruitApricots = CommplFruitApricots;
			profile.CommPlFruitAvocados = CommplFruitAvocados;
			profile.CommPlFruitBananas = CommplFruitBananas;
			profile.CommPlFruitBerries = CommplFruitBerries;
			profile.CommPlFruitBlueberries = CommplFruitBlueberries;
			profile.CommPlFruitBrambles = CommplFruitBrambles;
			profile.CommPlFruitCherries = CommplFruitCherries;
			profile.CommPlFruitCranberries = CommplFruitCranberries;
			profile.CommPlFruitFigs = CommplFruitFigs;
			profile.CommPlFruitGrapefruit = CommplFruitGrapefruit;
			profile.CommPlFruitGrapes = CommplFruitGrapes;
			profile.CommPlFruitLemons = CommplFruitLemons;
			profile.CommPlFruitLimes = CommplFruitLimes;
			profile.CommPlFruitMelons = CommplFruitMelons;
			profile.CommPlFruitOlives = CommplFruitOlives;
			//            profile.CommPlFruitOther = CommplFruitOther;
			profile.CommPlFruitOranges = CommplFruitOranges;
			profile.CommPlFruitPeaches = CommplFruitPeaches;
			profile.CommPlFruitPears = CommplFruitPears;
			profile.CommPlFruitPineapples = CommplFruitPineapples;
			profile.CommPlFruitPlums = CommplFruitPlums;
			profile.CommPlFruitQuinces = CommplFruitQuinces;
			profile.CommPlFruitStrawberries = CommplFruitStrawberries;
			profile.CommPlFruitTangerines = CommplFruitTangerines;

			bool CommplnutsAlmonds = (bool)(Request.Form["commplnuts_almonds"] == "on");
			bool CommplnutsHazelnuts = (bool)(Request.Form["commplnuts_hazelnuts"] == "on");
			bool CommplnutsPecans = (bool)(Request.Form["commplnuts_pecans"] == "on");
			bool CommplnutsWalnuts = (bool)(Request.Form["commplnuts_walnuts"] == "on");
			bool CommplnutsChestnuts = (bool)(Request.Form["commplnuts_chestnuts"] == "on");
			bool CommplnutsMacadamia = (bool)(Request.Form["commplnuts_macadamia"] == "on");
			bool CommplnutsPistachios = (bool)(Request.Form["commplnuts_pistachios"] == "on");
			//            string CommplnutsOther = MNS(Request.Form["commplnuts_other"]);

			profile.CommPlNutsAlmonds = CommplnutsAlmonds;
			profile.CommPlNutsChestnuts = CommplnutsChestnuts;
			profile.CommPlNutsHazel = CommplnutsHazelnuts;
			//            profile.CommPlNutsOther = CommplnutsOther;
			profile.CommPlNutsMacadamia = CommplnutsMacadamia;
			profile.CommPlNutsPecans = CommplnutsPecans;
			profile.CommPlNutsPistachios = CommplnutsPistachios;
			profile.CommPlNutsWalnuts = CommplnutsWalnuts;

			bool CommplAddHerbs = (bool)(Request.Form["commpladd_herbs"] == "on");
			bool CommplAddOrnamentals = (bool)(Request.Form["commpladd_ornamentals"] == "on");
			bool CommplAddTrees = (bool)(Request.Form["commpladd_trees"] == "on");
			bool CommplAddMushrooms = (bool)(Request.Form["commpladd_mushrooms"] == "on");
			bool CommplAddNativePlants = (bool)(Request.Form["commpladd_nativeplants"] == "on");
			//            string CommplAddOther = MNS(Request.Form["commpladd_other"]);

			profile.CommPlAddHerbs = CommplAddHerbs;
			profile.CommPlAddMushrooms = CommplAddMushrooms;
			profile.CommPlAddNativePlants = CommplAddNativePlants;
			profile.CommPlAddOrnamentals = CommplAddOrnamentals;
			//            profile.CommPlAddOther = CommplAddOther;
			profile.CommPlAddTrees = CommplAddTrees;

			bool CommAnimBeef = (bool)(Request.Form["commanim_beef"] == "on");
			bool CommAnimChicken = (bool)(Request.Form["commanim_chicken"] == "on");
			bool CommAnimRabbits = (bool)(Request.Form["commanim_rabbits"] == "on");
			bool CommAnimSwine = (bool)(Request.Form["commanim_swine"] == "on");
			bool CommAnimDairy = (bool)(Request.Form["commanim_dairy"] == "on");
			bool CommAnimGoats = (bool)(Request.Form["commanim_goats"] == "on");
			bool CommAnimTurkeys = (bool)(Request.Form["commanim_turkeys"] == "on");
			bool CommAnimSheep = (bool)(Request.Form["commanim_sheep"] == "on");
			//            string CommAnimOther = MNS(Request.Form["commanim_other"]);

			profile.CommAnimBeef = CommAnimBeef;
			profile.CommAnimChicken = CommAnimChicken;
			profile.CommAnimDairy = CommAnimDairy;
			profile.CommAnimGoats = CommAnimGoats;
			//            profile.CommAnimOther = CommAnimOther;
			profile.CommAnimRabbits = CommAnimRabbits;
			profile.CommAnimSheep = CommAnimSheep;
			profile.CommAnimSwine = CommAnimSwine;
			profile.CommAnimTurkeys = CommAnimTurkeys;

			bool CommMiscBees = (bool)(Request.Form["commmisc_Bees"] == "on");
			bool CommMiscFish = (bool)(Request.Form["commmisc_fish"] == "on");
			bool CommMiscRatites = (bool)(Request.Form["commmisc_ratites"] == "on");
			bool CommMiscShellFish = (bool)(Request.Form["commmisc_shellfish"] == "on");
			//            string CommMiscOther = MNS(Request.Form["commmisc_other"]);

			profile.CommMiscBees = CommMiscBees;
			profile.CommMiscFish = CommMiscFish;
			//            profile.CommMiscOther = CommMiscOther;
			profile.CommMiscRatites = CommMiscRatites;
			profile.CommMiscShellfish = CommMiscShellFish;


			Session["searchProfile"] = profile;

		}

        protected void ReportViewerXMLWriter()
        {
            DaikonGrant viewGrant;
			DaikonUserCollection projectPIs;
			DaikonParticipantCollection projectParticipants;
			String thisGrant = Request.Params.Get("pn");
            int thisReptYear = 0; 
            int thisReptType = 0; 
            int thisReptSection = 0;
            int thisReptSubSection = 0;

            if (Request.Params.Get("y") != null)
            {
                thisReptYear = int.Parse(Request.Params.Get("y"));
            }
            if (Request.Params.Get("t") != null)
            {
                thisReptType = int.Parse(Request.Params.Get("t"));
            }
            if (Request.Params.Get("rs") != null)
            {
                thisReptSection = int.Parse(Request.Params.Get("rs"));
            }
            if (Request.Params.Get("ss") != null)
            {
                thisReptSubSection = int.Parse(Request.Params.Get("ss"));
            }

            viewGrant = new DaikonGrant(thisGrant, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());
            if (viewGrant.projTitle == null)
                xsltArgs.AddParam("mytitle", "", "");
            else
                xsltArgs.AddParam("mytitle", "", viewGrant.projTitle);
			projectPIs = new DaikonUserCollection(viewGrant.CoreID, true);
			projectParticipants = new DaikonParticipantCollection(thisGrant, false);
            // This is added to get the project coordinators
            DaikonParticipantCollection grantNonuserCoords = new DaikonParticipantCollection(thisGrant, true);

			projectPIs.toXML(xmlWriter, "projectpis");
            // This is added to get the project coordinators
            grantNonuserCoords.toXML(xmlWriter, "projectpis");
            projectParticipants.toXML(xmlWriter, "projectparticipants");

            viewGrant.toXmlProductInfoPublic(ref xmlWriter);

            if (viewGrant.Reports.ContainsKey(thisReptYear.ToString() + thisReptType.ToString()))
                viewGrant.toXmlReport(thisReptYear, thisReptType, ref xmlWriter);
            else
            {
                viewGrant.addReport(new DaikonGrantReport(thisGrant, thisReptYear, thisReptType, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString()));
                viewGrant.toXmlReport(thisReptYear, thisReptType, ref xmlWriter);
            }
            
            xsltArgs.AddParam("reptsection", "", thisReptSection);
            xsltArgs.AddParam("reptsubsection", "", thisReptSubSection);

        }
        protected void ProjectViewerXMLWriter()
        {
            DaikonGrant viewGrant;
			DaikonUserCollection projectPIs;
			DaikonParticipantCollection projectParticipants;
			String thisGrant = Request.Params.Get("pn");
            //int thisReptSection = 0;
            //int thisReptSubSection = 0;

            viewGrant = new DaikonGrant(thisGrant, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());

            if (thisGrant == null || thisGrant.Length == 0)
                thisGrant = viewGrant.projNum;

			projectPIs = new DaikonUserCollection(viewGrant.CoreID, true);
			projectParticipants = new DaikonParticipantCollection(thisGrant, false);
            // This is added to get the project coordinators
            DaikonParticipantCollection grantNonuserCoords = new DaikonParticipantCollection(thisGrant, true);
            if (viewGrant.projTitle == null)
                xsltArgs.AddParam("mytitle", "", "");
            else
                xsltArgs.AddParam("mytitle", "", viewGrant.projTitle);
            projectPIs.toXML(xmlWriter, "projectpis");
            // This is added to get the project coordinators
            grantNonuserCoords.toXML(xmlWriter, "projectpis");
            projectParticipants.toXML(xmlWriter, "projectparticipants");

            viewGrant.toXmlProductInfoPublic(ref xmlWriter);

            viewGrant.toXml(ref xmlWriter);

        }

		public string MNS(object s)
		{
			if (s == null)
				return string.Empty;
			else
				return Convert.ToString(s);
		}

        /// <summary>
        /// generate the .pdf
        /// </summary>
        /// <param name="path">path of the document</param>
        /// <param name="fileName">name of the .pdf documen</param>
        /// <param name="download">is this downloadable</param>
        /// <param name="text">text to place in the .pdf</param>
        private void GeneratePDF(string path, string fileName, bool download, string projNum, string projTitle, int reportType, int reportYear)
        {
            /*
            Document document = new Document();
            try
            {
                //use a variable to let my code fit across the page...
                //XmlTextWriter xmlCache = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

                PdfWriter.GetInstance(document, new FileStream(path + fileName, FileMode.Create));

                document.Open();

                document.Add(new Paragraph("My first PDF"));
           
            }
            finally
            {
                document.Close();
            }
            */

            string reptTypeName = reportYear.ToString();
            if (reportType == 0)
                reptTypeName += " Annual Report";
            else if (reportType == 1)
                reptTypeName += " Final Report";
            else
                reptTypeName += " Proposal";

            //Document document = new Document();
            //System.IO.FileStream docStream = new System.IO.FileStream(path + fileName, FileMode.Create); This line is commented becuase it is add up in associaFiles Director
            MemoryStream docStream = new MemoryStream(); // PDF data will be written here
            Document document = new Document(PageSize.A4, 60, 60, 10, 10);
            PdfWriter myPDFWriter = PdfWriter.GetInstance(document, docStream);  // tie a PdfWriter instance to the stream

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            try
            {
                //PdfWriter.GetInstance(document, new FileStream(path + fileName, FileMode.Create));
                //docStream = new System.IO.FileStream(path + fileName, FileMode.Create);
                // PdfWriter myPDFWriter = PdfWriter.GetInstance(document, docStream); This line is commented becuase it is add up in associaFiles Director              


                document.Open();

                /*
                userSQL = "SELECT subsection_uid, shared_details_text.[section], ISNULL(sub_heading, '') as sub_heading,section_name, ISNULL(sub_text, '') as sub_text, section_order, subsection_order, subsection_type, [type_name] FROM shared_details_text INNER JOIN subsection_types ON subsection_type = type_num INNER JOIN text_sections ON shared_details_text.rept_isfinal = text_sections.rept_isfinal AND shared_details_text.proj_type = text_sections.proj_type AND shared_details_text.[section] = text_sections.[section] WHERE proj_num = '" + projNum + "'" + " AND rept_year = " + reportYear + " AND shared_details_text.rept_isfinal = " + reportType + " AND sub_text IS NOT NULL ORDER BY section_order, subsection_order";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.Text;
                userConnection.Open();
                userDataReader = userCommand.ExecuteReader();
                */

                userConnection = new SqlConnection(userConnString);
                userSQL = "DaikonGeneratePDFReport";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;
                userCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50).Value = projNum;
                userCommand.Parameters.Add("@rept_year", SqlDbType.Int).Value = reportYear;
                userCommand.Parameters.Add("@rept_isfinal", SqlDbType.TinyInt).Value = reportType;

                userConnection.Open();
                //userDataReader = userCommand.ExecuteReader();

                iTextSharp.text.ListItem li = new iTextSharp.text.ListItem();

                Paragraph paragraph = new Paragraph();
                Paragraph paragraphProject = new Paragraph();
                Paragraph paragraphProjectPIs = new Paragraph("", FontFactory.GetFont(BaseFont.HELVETICA, 10));
                Paragraph paragraphCoords = new Paragraph("", FontFactory.GetFont(BaseFont.HELVETICA, 10));
                Paragraph paragraphParticipants = new Paragraph("", FontFactory.GetFont(BaseFont.HELVETICA, 10));
                Paragraph paragraphAttachments = new Paragraph("", FontFactory.GetFont(BaseFont.HELVETICA, 10));

                Paragraph projViewParagraph = new Paragraph("", FontFactory.GetFont(BaseFont.HELVETICA, 10));



                //Chunk chunk = new Chunk();
                string sareamount;
                string text;
                string sectionName = "";
                string section_sub_head = "";
                string htmlText = "";

                // Add the image now
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath("~/SARE_CMYK_Small.jpg"));
                gif.ScaleToFit(80f, 80f);
                document.Add(gif);

               
                using (userDataReader = userCommand.ExecuteReader())
                {

                    while (userDataReader.Read())
                    {
                        Paragraph heading = new Paragraph(userDataReader["proj_title"].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                        heading.SpacingAfter = 12f;
                        document.Add(heading);

                        Paragraph headingReptType = new Paragraph(reptTypeName, new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                        heading.SpacingAfter = 12f;
                        document.Add(headingReptType);

                        sareamount = string.Format("{0:c}", userDataReader["funds_sare"]);
                        Chunk cProjNu = new Chunk("Project Number : ", FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10));
                        paragraphProject.Add(cProjNu);
                        Chunk cProjNuValue = new Chunk(userDataReader["proj_num"].ToString(), FontFactory.GetFont(BaseFont.HELVETICA, 10));
                        paragraphProject.Add(cProjNuValue);
                        paragraphProject.Add("\n");
                        //paragraphProject.Add("Type : " + userDataReader["proj_type_text"].ToString());
                        Chunk cProjType = new Chunk("Type : ", FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10));
                        paragraphProject.Add(cProjType);
                        Chunk cProjTypeValue = new Chunk(userDataReader["proj_type_text"].ToString(), FontFactory.GetFont(BaseFont.HELVETICA, 10));
                        paragraphProject.Add(cProjTypeValue);
                        paragraphProject.Add("\n");
                        //paragraphProject.Add("Region : " + userDataReader["proj_region_text"].ToString());
                        Chunk cProjReg = new Chunk("Region : ", FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10));
                        paragraphProject.Add(cProjReg);
                        Chunk cProjRegValue = new Chunk(userDataReader["proj_region_text"].ToString(), FontFactory.GetFont(BaseFont.HELVETICA, 10));
                        paragraphProject.Add(cProjRegValue);
                        paragraphProject.Add("\n");
                        //paragraphProject.Add("SARE Grant : " + sareamount);
                        Chunk cProjGrant = new Chunk("SARE Grant : ", FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10));
                        paragraphProject.Add(cProjGrant);
                        Chunk cProjGrantValue = new Chunk(sareamount, FontFactory.GetFont(BaseFont.HELVETICA, 10));
                        paragraphProject.Add(cProjGrantValue);
                        paragraphProject.Add("\n\n");
                    }

                    userDataReader.NextResult();

                    while (userDataReader.Read())
                    {

                        paragraphProjectPIs.Add(userDataReader["firstName"].ToString() + " " + userDataReader["lastName"].ToString());
                        paragraphProjectPIs.Add("\n");
                        if (userDataReader["orgPosition"].ToString() != "")
                        {
                            paragraphProjectPIs.Add(userDataReader["orgPosition"].ToString());
                            paragraphProjectPIs.Add("\n");
                        }
                        if (userDataReader["org"].ToString() != "")
                        {
                            paragraphProjectPIs.Add(userDataReader["org"].ToString());
                            paragraphProjectPIs.Add("\n");
                        }
                        if (userDataReader["addrStreet1"].ToString() != "")
                        {
                            paragraphProjectPIs.Add(userDataReader["addrStreet1"].ToString());
                            if (userDataReader["addrStreet2"].ToString() != "")
                            {
                                paragraphProjectPIs.Add(", " + userDataReader["addrStreet2"].ToString());
                                paragraphProjectPIs.Add("\n");
                            }
                            else
                                paragraphProjectPIs.Add("\n");
                        }
                        if (userDataReader["addrCity"].ToString() != "")
                        {
                            paragraphProjectPIs.Add(userDataReader["addrCity"].ToString());
                            if (userDataReader["addrState"].ToString() != "")
                            {
                                paragraphProjectPIs.Add(", " + userDataReader["addrState"].ToString());
                                if (userDataReader["addrZip"].ToString() != "")
                                {
                                    paragraphProjectPIs.Add(" " + userDataReader["addrZip"].ToString());
                                    paragraphProjectPIs.Add("\n");
                                }
                                else
                                    paragraphProjectPIs.Add("\n");
                            }
                        }
                        if (userDataReader["numPhone"].ToString() != "")
                        {
                            paragraphProjectPIs.Add(userDataReader["numPhone"].ToString());
                            paragraphProjectPIs.Add("\n");
                        }
                        if (userDataReader["email"].ToString() != "")
                        {
                            string email = userDataReader["email"].ToString();
                            //paragraphProjectPIs.Add("E-mail: " + "<a href='mailto:{email}'>" + userDataReader["email"].ToString() + "</a>");
                            Anchor anchoremail = new Anchor(email, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            anchoremail.Reference = "mailto:" + email;
                            paragraphProjectPIs.Add("E-mail: ");
                            paragraphProjectPIs.Add(anchoremail);
                            paragraphProjectPIs.Add("\n");
                        }
                        if (userDataReader["website"].ToString() != "")
                        {
                            string website = userDataReader["website"].ToString();
                            //paragraphProjectPIs.Add("Website: " + "<a href='{website}'>" + userDataReader["email"].ToString() + "</a>");
                            Anchor anchor = new Anchor(website, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            if (website.StartsWith("http"))
                                anchor.Reference = website;
                            else
                                anchor.Reference = "http://" + website;
                            paragraphProjectPIs.Add("Website: ");
                            paragraphProjectPIs.Add(anchor);
                            paragraphProjectPIs.Add("\n");
                        }
                        paragraphProjectPIs.Add("\n");

                    }

                    userDataReader.NextResult();

                    while (userDataReader.Read())
                    {

                        paragraphCoords.Add(userDataReader["firstName"].ToString() + " " + userDataReader["lastName"].ToString());
                        paragraphCoords.Add("\n");
                        if (userDataReader["orgPosition"].ToString() != "")
                        {
                            paragraphCoords.Add(userDataReader["orgPosition"].ToString());
                            paragraphCoords.Add("\n");
                        }
                        if (userDataReader["org"].ToString() != "")
                        {
                            paragraphCoords.Add(userDataReader["org"].ToString());
                            paragraphCoords.Add("\n");
                        }
                        if (userDataReader["addrStreet1"].ToString() != "")
                        {
                            paragraphCoords.Add(userDataReader["addrStreet1"].ToString());
                            if (userDataReader["addrStreet2"].ToString() != "")
                            {
                                paragraphCoords.Add(", " + userDataReader["addrStreet2"].ToString());
                                paragraphCoords.Add("\n");
                            }
                            else
                                paragraphCoords.Add("\n");
                        }
                        if (userDataReader["addrCity"].ToString() != "")
                        {
                            paragraphCoords.Add(userDataReader["addrCity"].ToString());
                            if (userDataReader["addrState"].ToString() != "")
                            {
                                paragraphCoords.Add(", " + userDataReader["addrState"].ToString());
                                if (userDataReader["addrZip"].ToString() != "")
                                {
                                    paragraphCoords.Add(" " + userDataReader["addrZip"].ToString());
                                    paragraphCoords.Add("\n");
                                }
                                else
                                    paragraphCoords.Add("\n");
                            }
                        }
                        if (userDataReader["numPhone"].ToString() != "")
                        {
                            paragraphCoords.Add(userDataReader["numPhone"].ToString());
                            paragraphCoords.Add("\n");
                        }
                        if (userDataReader["email"].ToString() != "")
                        {
                            string email = userDataReader["email"].ToString();
                            Anchor anchoremail = new Anchor(email, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            anchoremail.Reference = "mailto:" + email;
                            paragraphCoords.Add("E-mail: ");
                            paragraphCoords.Add(anchoremail);
                            paragraphCoords.Add("\n");
                        }
                        if (userDataReader["website"].ToString() != "")
                        {
                            string website = userDataReader["website"].ToString();
                            Anchor anchor = new Anchor(website, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            if (website.StartsWith("http"))
                                anchor.Reference = website;
                            else
                                anchor.Reference = "http://" + website;
                            paragraphCoords.Add("Website: ");
                            paragraphCoords.Add(anchor);
                            paragraphCoords.Add("\n");
                        }
                        paragraphCoords.Add("\n");

                    }

                    userDataReader.NextResult();

                    while (userDataReader.Read())
                    {

                        // add the column value to the List
                        //li.Add(userDataReader["section_name"].ToString());

                        section_sub_head = userDataReader["sub_heading"].ToString();

                        if (sectionName != userDataReader["section_name"].ToString())
                        {
                            sectionName = userDataReader["section_name"].ToString();

                            if (userDataReader["sub_text"].ToString() != "")
                            {
                                paragraph.Add("\n");
                                //paragraph.Font.SetStyle(iTextSharp.text.Font.BOLD);
                                //paragraph.Add(sectionName);
                                Chunk c = new Chunk(sectionName, FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 14));
                                paragraph.Add(c);
                                paragraph.Add("\n");

                                htmlText = htmlText + "<B>" + sectionName + "</B>" + "<br/>";
                            }
                        }


                        if (section_sub_head.Length != 0)
                        {
                            section_sub_head = section_sub_head + "<br/>";
                            //paragraph.Add(section_sub_head);
                            Chunk c1 = new Chunk(section_sub_head, FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 14));
                            paragraph.Add(c1);
                            htmlText = htmlText + "<B>" + section_sub_head + "</B>" + "<br/>";
                        }

                        //text = userDataReader["sub_text"].ToString() + "\n";
                        text = "<font size='2' face='arial unicode ms'>" + userDataReader["sub_text"].ToString() + "</font><br/><br/>";
                        text = text.Replace("font-size: medium", "");
                        //paragraph.Font.SetStyle(iTextSharp.text.Font.NORMAL);
                        Chunk c2 = new Chunk(text, FontFactory.GetFont(BaseFont.HELVETICA, 10));
                        paragraph.Add(c2);
                        //paragraph.Add(text);    
                        htmlText = htmlText + text;

                    }

                    userDataReader.NextResult();
                    while (userDataReader.Read())
                    {

                        paragraphParticipants.Add(userDataReader["firstName"].ToString() + " " + userDataReader["lastName"].ToString());
                        paragraphParticipants.Add("\n");
                        if (userDataReader["orgPosition"].ToString() != "")
                        {
                            paragraphParticipants.Add(userDataReader["orgPosition"].ToString());
                            paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["org"].ToString() != "")
                        {
                            paragraphParticipants.Add(userDataReader["org"].ToString());
                            paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["addrStreet1"].ToString() != "")
                        {
                            paragraphParticipants.Add(userDataReader["addrStreet1"].ToString());
                            if (userDataReader["addrStreet2"].ToString() != "")
                            {
                                paragraphParticipants.Add(", " + userDataReader["addrStreet2"].ToString());
                                paragraphParticipants.Add("\n");
                            }
                            else
                                paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["addrCity"].ToString() != "")
                        {
                            paragraphParticipants.Add(userDataReader["addrCity"].ToString());
                            if (userDataReader["addrState"].ToString() != "")
                            {
                                paragraphParticipants.Add(", " + userDataReader["addrState"].ToString());
                                if (userDataReader["addrZip"].ToString() != "")
                                {
                                    paragraphParticipants.Add(" " + userDataReader["addrZip"].ToString());
                                    paragraphParticipants.Add("\n");
                                }
                                else
                                    paragraphParticipants.Add("\n");
                            }
                            else
                                paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["numPhone"].ToString() != "")
                        {
                            paragraphParticipants.Add(userDataReader["numPhone"].ToString());
                            paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["email"].ToString() != "")
                        {
                            string email = userDataReader["email"].ToString();
                            Anchor anchoremail = new Anchor(email, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            anchoremail.Reference = "mailto:" + email;
                            paragraphParticipants.Add("E-mail: ");
                            paragraphParticipants.Add(anchoremail);
                            paragraphParticipants.Add("\n");
                        }
                        if (userDataReader["website"].ToString() != "")
                        {
                            string website = userDataReader["website"].ToString();
                            Anchor anchor = new Anchor(website, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                            if (website.StartsWith("http"))
                                anchor.Reference = website;
                            else
                                anchor.Reference = "http://" + website;
                            paragraphParticipants.Add("Website: ");
                            paragraphParticipants.Add(anchor);
                            paragraphParticipants.Add("\n");
                        }
                        paragraphParticipants.Add("\n\n");

                    }

                    userDataReader.NextResult();

                    while (userDataReader.Read())
                    {

                        string attachment = ConfigurationManager.AppSettings["website"].ToString() + "/mySARE/assocfiles/" + userDataReader["file_name"].ToString();
                        //string attachment = "http://saret.ifas.ufl.edu/mysare/assocfiles/" + userDataReader["file_name"].ToString();
                        Anchor anchor = new Anchor(attachment, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                        anchor.Reference = attachment;
                        paragraphAttachments.Add(userDataReader["file_caption"].ToString() + ": ");
                        paragraphAttachments.Add(anchor);
                        paragraphAttachments.Add("\n");
                    }

                }
                

                document.Add(paragraphProject);

                Paragraph headingAttachmentsExists = new Paragraph("This report has supporting files available online. See the link at the bottom of the page.\n", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                if (paragraphAttachments.Count > 1)
                {
                    headingAttachmentsExists.Add("\n");
                    document.Add(headingAttachmentsExists);
                }
                Paragraph headingCoords = new Paragraph("Coordinators:", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                //headingCoords.SpacingAfter = 2f;
                document.Add(headingCoords);
                document.Add(paragraphProjectPIs);
                document.Add(paragraphCoords);
                //document.Add(paragraph);
                iTextSharp.text.html.simpleparser.HTMLWorker htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                //htmlWorker.Parse(new StringReader(htmlText));
                string fontPath = Server.MapPath("~/ARIALUNI.TTF");
                FontFactory.Register(fontPath, "arial unicode ms");

                // step 4.2: create a style sheet and set the encoding to Identity-H
                iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
                ST.LoadTagStyle("body", "encoding", "Identity-H");

                // step 4.3: assign the style sheet to the html parser
                htmlWorker.Style = (ST);

                htmlWorker.StartDocument();

                // step 5: parse the html into the document
                htmlWorker.Parse(new StringReader(htmlText));

                // step 6: close the document and the worker
                htmlWorker.EndDocument();

                Paragraph headingParticipants = new Paragraph("Participants:", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                //headingParticipants.SpacingAfter = 2f;
                if (paragraphParticipants.Count > 1)
                {
                    document.Add(headingParticipants);
                    document.Add(paragraphParticipants);
                }
                else
                {
                    paragraphParticipants.Add("\n");
                    document.Add(paragraphParticipants);
                }

                Paragraph headingAttachments = new Paragraph("Attachments:", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                if (paragraphAttachments.Count > 1)
                {
                    document.Add(headingAttachments);
                    document.Add(paragraphAttachments);
                    projViewParagraph.Add("\n\n");
                }

                string backToProject = ConfigurationManager.AppSettings["website"].ToString() + "/ProjectReport.aspx?do=viewRept&pn=" + projNum + "&y=" + reportYear.ToString() + "&t=" + reportType.ToString();
                Anchor anchorProjView = new Anchor(backToProject, iTextSharp.text.FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.Color.BLUE));
                //anchorProjView.Reference = ConfigurationManager.AppSettings["website"].ToString() + "/sare_main.aspx?do=viewRept&pn=" + projNum + "&y=" + reportYear.ToString() + "&t=" + reportType.ToString();
                anchorProjView.Reference = backToProject;
                projViewParagraph.Add("View this report online: ");
                projViewParagraph.Add(anchorProjView);
                //projViewParagraph.Add("\n");
                document.Add(projViewParagraph);

                string disclaimer = "This project and all associated reports and support materials were supported by the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.";
                Chunk disclaimerChunk = new Chunk(disclaimer, FontFactory.GetFont("Tahoma", 8));
                Paragraph disclaimerParagraph = new Paragraph();
                disclaimerParagraph.Add("\n");
                disclaimerParagraph.Add(disclaimerChunk);
                disclaimerParagraph.Add("\n\n");
                document.Add(disclaimerParagraph);

                Paragraph footer = new Paragraph("Total Number of Pages : " + myPDFWriter.CurrentPageNumber.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                document.Add(footer);

            }
            catch (Exception ee)
            {
                Session["statusMessage1"] = ee.ToString();
            }
            finally
            {
                /*
                try
                {
                    document.Close();
                }
                finally
                {
                    // Also make sure the underlying stream is closed
                    // You could delete the file here if it's empty
                    docStream.Close();
                }
                */
                document.Close();
                userConnection.Dispose();

            }

            string docPath = path + fileName;
            //ShowPdf(docPath); This line is commented becuase it is add up in associaFiles Director
            ShowPdf(docStream, myPDFWriter);

        }
       
        public void ShowPdf(string strFileName)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
            Response.ContentType = "application/pdf";
            //Response.Write("<SCRIPT language=javascript>var pdf=window.open('" + strFileName + "','PDF');pdf.moveTo(0,0);</SCRIPT>");
            //Response.WriteFile(strFileName);
            Response.TransmitFile(strFileName);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

        public void ShowPdf(MemoryStream mem, PdfWriter writer)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            // write the document data to response stream
            writer.Flush();
            Response.OutputStream.Write(mem.GetBuffer(), 0, mem.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.End();
            Response.End();
            Response.Flush();
            Response.Clear();
        }

    }
}
