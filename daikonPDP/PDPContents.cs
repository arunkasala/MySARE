using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Web.Security;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace daikonPDP
{
    public class PDPContents
    {
        // PDP Info
        protected string projNum = "";
        protected string piFName = "";
        protected string piLName = "";
        protected string piInstName = "";
        protected string piInstName2 = "";
        protected string piInstName3 = "";
        protected string piAdd = "";
        protected string piCity = "";
        protected string piState = "";
        protected string piZip = "";
        protected string piPhone = "";
        protected string piFax = "";
        protected string piEmail = "";
        protected string piStatePro = "";
        protected string advName = "";
        protected string advLName = "";
        protected string advType = "";
        protected string advLocationState = "";
        protected string advLocationZip = "";
        protected string advAff = "";
        protected string advDate = "";
        protected string advLoc = "";
        protected string advName1 = "";
        protected string advLName1 = "";
        protected string advType1 = "";
        protected string advLocationState1 = "";
        protected string advLocationZip1 = "";
        protected string advAff1 = "";
        protected string advDate1 = "";
        protected string advLoc1 = "";
        protected string advName2 = "";
        protected string advLName2 = "";
        protected string advType2 = "";
        protected string advLocationState2 = "";
        protected string advLocationZip2 = "";
        protected string advAff2 = "";
        protected string advDate2 = "";
        protected string advLoc2 = "";
        protected string advName3 = "";
        protected string advLName3 = "";
        protected string advType3 = "";
        protected string advLocationState3 = "";
        protected string advLocationZip3 = "";
        protected string advAff3 = "";
        protected string advDate3 = "";
        protected string advLoc3 = "";
        protected string advName4 = "";
        protected string advLName4 = "";
        protected string advType4 = "";
        protected string advLocationState4 = "";
        protected string advLocationZip4 = "";
        protected string advAff4 = "";
        protected string advDate4 = "";
        protected string advLoc4 = "";
        protected string advName5 = "";
        protected string advLName5 = "";
        protected string advType5 = "";
        protected string advLocationState5 = "";
        protected string advLocationZip5 = "";
        protected string advAff5 = "";
        protected string advDate5 = "";
        protected string advLoc5 = "";
        protected string advName6 = "";
        protected string advLName6 = "";
        protected string advType6 = "";
        protected string advLocationState6 = "";
        protected string advLocationZip6 = "";
        protected string advAff6 = "";
        protected string advDate6 = "";
        protected string advLoc6 = "";
        protected string advName7 = "";
        protected string advLName7 = "";
        protected string advAff7 = "";
        protected string advName8 = "";
        protected string advLName8 = "";
        protected string advAff8 = "";
        protected string advName9 = "";
        protected string advLName9 = "";
        protected string advAff9 = "";
        protected string advName10 = "";
        protected string advLName10 = "";
        protected string advAff10 = "";
        protected string advName11 = "";
        protected string advLName11 = "";
        protected string advAff11 = "";
        protected string advName12 = "";
        protected string advLName12 = "";
        protected string advAff12 = "";
        protected string advName13 = "";
        protected string advLName13 = "";
        protected string advAff13 = "";
        protected string advName14 = "";
        protected string advLName14 = "";
        protected string advAff14 = "";
        protected string advName15 = "";
        protected string advLName15 = "";
        protected string advAff15 = ""; 
        protected int piInstType = 0;
        protected int piRace = 0;
        protected string piEthinicity = "";
        protected int piInstType2 = 0;
        protected int piRace2 = 0;
        protected string piEthinicity2 = "";
        protected int piInstType3 = 0;
        protected int piRace3 = 0;
        protected string piEthinicity3 = "";
        protected int initiative_count = 0;
        protected int pdpid = 0;
        protected string initiative_title = "";
        protected string initiative_title1 = "";
        protected string initiative_title2 = "";
        protected string initiative_title3 = "";
        protected string initiative_title4 = "";
        protected string initiative_title5 = "";

        //PDP Initiative/Topic and Partners
        protected int pdpInitID = 0;
        protected string sare_outreach;
        protected string init_topic;
        protected string training_obj;
        protected int part_ext;
        protected int part_nrcs;
        protected int part_ngo;
        protected int part_state;
        protected int part_farmer;
        protected int part_other;
        protected int train_ext;
        protected int train_nrcs;
        protected int train_ngo;
        protected int train_state;
        protected int train_farmer;
        protected int train_other;
        protected int dev_ext;
        protected int dev_nrcs;
        protected int dev_ngo;
        protected int dev_state;
        protected int dev_farmer;
        protected int dev_other;
        protected int inv_ext;
        protected int inv_nrcs;
        protected int inv_ngo;
        protected int inv_state;
        protected int inv_farmer;
        protected int inv_other;
        protected int initiative_num;
        protected int key_out_study_sessions;
        protected string key_out_study_title1 = "";
        protected string key_out_study_title2 = "";
        protected string key_out_study_title3 = "";
        protected string key_out_study_title4 = "";
        protected string key_out_study_title5 = "";
        protected string key_out_study_title6 = "";
        protected int key_out_work_sessions;
        protected string key_out_work_titles1 = "";
        protected string key_out_work_titles2 = "";
        protected string key_out_work_titles3 = "";
        protected string key_out_work_titles4 = "";
        protected string key_out_work_titles5 = "";
        protected string key_out_work_titles6 = "";
        protected int key_out_field_sessions;
        protected string key_out_field_titles1 = "";
        protected string key_out_field_titles2 = "";
        protected string key_out_field_titles3 = "";
        protected string key_out_field_titles4 = "";
        protected string key_out_field_titles5 = "";
        protected string key_out_field_titles6 = "";
        protected int key_out_web_sessions;
        protected string key_out_web_titles1 = "";
        protected string key_out_web_titles2 = "";
        protected string key_out_web_titles3 = "";
        protected string key_out_web_titles4 = "";
        protected string key_out_web_titles5 = "";
        protected string key_out_web_titles6 = "";
        protected int key_out_grant_sessions;
        protected string key_out_grant_titles1 = "";
        protected string key_out_grant_titles2 = "";
        protected string key_out_grant_titles3 = "";
        protected string key_out_grant_titles4 = "";
        protected string key_out_grant_titles5 = "";
        protected string key_out_grant_titles6 = "";
        protected int key_out_travel_sessions;
        protected string key_out_travel_titles1 = "";
        protected string key_out_travel_titles2 = "";
        protected string key_out_travel_titles3 = "";
        protected string key_out_travel_titles4 = "";
        protected string key_out_travel_titles5 = "";
        protected string key_out_travel_titles6 = "";
        protected string key_out_travel_titles7 = "";
        protected string key_out_travel_titles8 = "";
        protected string key_out_travel_titles9 = "";
        protected string key_out_travel_titles10 = "";
        protected string key_out_travel_titles11 = "";
        protected string key_out_travel_titles12 = "";
        protected string key_out_travel_titles13 = "";
        protected string key_out_travel_titles14 = "";
        protected string key_out_travel_titles15 = "";
        protected string key_out_travel_titles16 = "";
        protected string key_out_travel_titles17 = "";
        protected string key_out_travel_titles18 = "";
        protected string key_out_travel_titles19 = "";
        protected string key_out_travel_titles20 = "";
        protected int key_out_other_sessions;
        protected string key_out_other_titles1 = "";
        protected string key_out_other_titles2 = "";
        protected string key_out_other_titles3 = "";
        protected string key_out_other_titles4 = "";
        protected string key_out_other_titles5 = "";
        protected string key_out_other_titles6 = "";

        //PDP Outcome Narrative
        protected int pdp_out_id;
        protected string out_summary;
        protected string out_desc;
        protected string out_other;
        protected int attachment_id;
        protected string attachment_title;
        protected string attachment_caption;

       
        public PDPContents()
        {
            projNum = "";
            piFName = "";
            piLName = "";
            piInstName = "";
            piAdd = "";
            piCity = "";
            piState = "";
            piZip = "";
            piPhone = "";
            piFax = "";
            piEmail = "";
            piStatePro = "";
            advName = "";
            advAff = "";
            advDate = "";
            advLoc = "";
            advName1 = "";
            advAff1 = "";
            advDate1 = "";
            advLoc1 = "";
            advName2 = "";
            advAff2 = "";
            advDate2 = "";
            advLoc2 = "";
            advName3 = "";
            advAff3 = "";
            advDate3 = "";
            advLoc3 = "";
            advName4 = "";
            advAff4 = "";
            advDate4 = "";
            advLoc4 = "";
            advName5 = "";
            advAff5 = "";
            advDate5 = "";
            advLoc5 = "";
            advName6 = "";
            advAff6 = "";
            advDate6 = "";
            advLoc6 = "";
            piInstType = 0;
            piRace = 0;
            piEthinicity = "";

            pdpInitID = 0;
            sare_outreach = "";
            init_topic = "";
            training_obj = "";
            part_ext = 0;
            part_nrcs = 0;
            part_ngo = 0;
            part_state = 0;
            part_farmer = 0;
            part_other = 0;
            train_ext = 0;
            train_nrcs = 0;
            train_ngo = 0;
            train_state = 0;
            train_farmer = 0;
            train_other = 0;
            dev_ext = 0;
            dev_nrcs = 0;
            dev_ngo = 0;
            dev_state = 0;
            dev_farmer = 0;
            dev_other = 0;
            inv_ext = 0;
            inv_nrcs = 0;
            inv_ngo = 0;
            inv_state = 0;
            inv_farmer = 0;
            inv_other = 0;
            initiative_num = 0;
            key_out_study_sessions = 0;
            key_out_work_sessions = 0;
            key_out_field_sessions = 0;
            key_out_web_sessions = 0;
            key_out_grant_sessions = 0;
            key_out_travel_sessions = 0;
            key_out_other_sessions = 0;

            pdp_out_id = 0;
            out_summary = "";
            out_desc = "";
            out_other = "";
            attachment_id = 0;
            attachment_title = "";
        }

        public int saveNewPDPInfoToDB()
        {
            string pdpInfoSQL;
            string pdpInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpInfoConnection;
            SqlCommand pdpInfoCommand;

            pdpInfoConnection = new SqlConnection(pdpInfoConnString);

            pdpInfoSQL = "DaikonPDPInfoCreate";
            pdpInfoCommand = new SqlCommand(pdpInfoSQL, pdpInfoConnection);
            pdpInfoCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpInfoCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_firstName", SqlDbType.VarChar, 120);
            pdpInfoCommand.Parameters.Add("@pi_lastName", SqlDbType.VarChar, 120);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity2", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race2", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType2", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity3", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race3", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType3", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_address", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_city", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_state", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@pi_zip", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@pi_phone", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_fax", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_email", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_statePro", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState1", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip1", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate1", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState2", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip2", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate2", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState3", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip3", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate3", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState4", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip4", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate4", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState5", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip5", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate5", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState6", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip6", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate6", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@sare_outreach", SqlDbType.NText);
            pdpInfoCommand.Parameters.Add(keyOutput);

            pdpInfoCommand.Parameters["@proj_num"].Value = projNum;
            pdpInfoCommand.Parameters["@pi_firstName"].Value = piFName;
            pdpInfoCommand.Parameters["@pi_lastName"].Value = piLName;
            pdpInfoCommand.Parameters["@pi_ethinicity"].Value = PiEthinicity;
            pdpInfoCommand.Parameters["@pi_race"].Value = piRace;
            if (piInstName == null)
                pdpInfoCommand.Parameters["@pi_instituteName"].Value = "";
            else
                pdpInfoCommand.Parameters["@pi_instituteName"].Value = piInstName;
            pdpInfoCommand.Parameters["@pi_instituteType"].Value = piInstType;
            pdpInfoCommand.Parameters["@pi_ethinicity2"].Value = PiEthinicity2;
            pdpInfoCommand.Parameters["@pi_race2"].Value = piRace2;
            pdpInfoCommand.Parameters["@pi_instituteName2"].Value = piInstName2;
            pdpInfoCommand.Parameters["@pi_instituteType2"].Value = piInstType2;
            pdpInfoCommand.Parameters["@pi_ethinicity3"].Value = PiEthinicity3;
            pdpInfoCommand.Parameters["@pi_race3"].Value = piRace3;
            pdpInfoCommand.Parameters["@pi_instituteName3"].Value = piInstName3;
            pdpInfoCommand.Parameters["@pi_instituteType3"].Value = piInstType3;
            pdpInfoCommand.Parameters["@pi_address"].Value = piAdd;
            pdpInfoCommand.Parameters["@pi_city"].Value = piCity;
            pdpInfoCommand.Parameters["@pi_state"].Value = piState;
            pdpInfoCommand.Parameters["@pi_zip"].Value = piZip;
            pdpInfoCommand.Parameters["@pi_phone"].Value = piPhone;
            pdpInfoCommand.Parameters["@pi_fax"].Value = piFax;
            pdpInfoCommand.Parameters["@pi_email"].Value = piEmail;
            pdpInfoCommand.Parameters["@pi_statePro"].Value = piStatePro;
            pdpInfoCommand.Parameters["@advName"].Value = advName;
            pdpInfoCommand.Parameters["@advLName"].Value = advLName;
            pdpInfoCommand.Parameters["@advType"].Value = advType;
            pdpInfoCommand.Parameters["@advLocationState"].Value = advLocationState;
            pdpInfoCommand.Parameters["@advLocationZip"].Value = advLocationZip;
            pdpInfoCommand.Parameters["@advAff"].Value = advAff;
            if (advDate !=  "")
                pdpInfoCommand.Parameters["@advDate"].Value = DateTime.Parse(advDate);
            else
                pdpInfoCommand.Parameters["@advDate"].Value = null;
            pdpInfoCommand.Parameters["@advLocation"].Value = advLoc;
            pdpInfoCommand.Parameters["@advName1"].Value = advName1;
            pdpInfoCommand.Parameters["@advLName1"].Value = advLName1;
            pdpInfoCommand.Parameters["@advType1"].Value = advType1;
            pdpInfoCommand.Parameters["@advLocationState1"].Value = advLocationState1;
            pdpInfoCommand.Parameters["@advLocationZip1"].Value = advLocationZip1;
            pdpInfoCommand.Parameters["@advAff1"].Value = advAff1;
            if (advDate1 != "")
                pdpInfoCommand.Parameters["@advDate1"].Value = DateTime.Parse(advDate1);
            else
                pdpInfoCommand.Parameters["@advDate1"].Value = null;
            pdpInfoCommand.Parameters["@advLocation1"].Value = advLoc1;
            pdpInfoCommand.Parameters["@advName2"].Value = advName2;
            pdpInfoCommand.Parameters["@advLName2"].Value = advLName2;
            pdpInfoCommand.Parameters["@advType2"].Value = advType2;
            pdpInfoCommand.Parameters["@advLocationState2"].Value = advLocationState2;
            pdpInfoCommand.Parameters["@advLocationZip2"].Value = advLocationZip2;
            pdpInfoCommand.Parameters["@advAff2"].Value = advAff2;
            if (advDate2 !=  "")
                pdpInfoCommand.Parameters["@advDate2"].Value = DateTime.Parse(advDate2);
            else
                pdpInfoCommand.Parameters["@advDate2"].Value = null;
            pdpInfoCommand.Parameters["@advLocation2"].Value = advLoc2;
            pdpInfoCommand.Parameters["@advName3"].Value = advName3;
            pdpInfoCommand.Parameters["@advLName3"].Value = advLName3;
            pdpInfoCommand.Parameters["@advType3"].Value = advType3;
            pdpInfoCommand.Parameters["@advLocationState3"].Value = advLocationState3;
            pdpInfoCommand.Parameters["@advLocationZip3"].Value = advLocationZip3;
            pdpInfoCommand.Parameters["@advAff3"].Value = advAff3;
            if (advDate3 !=  "")
                pdpInfoCommand.Parameters["@advDate3"].Value = DateTime.Parse(advDate3);
            else
                pdpInfoCommand.Parameters["@advDate3"].Value = null;
            pdpInfoCommand.Parameters["@advLocation3"].Value = advLoc3;
            pdpInfoCommand.Parameters["@advName4"].Value = advName4;
            pdpInfoCommand.Parameters["@advLName4"].Value = advLName4;
            pdpInfoCommand.Parameters["@advType4"].Value = advType4;
            pdpInfoCommand.Parameters["@advLocationState4"].Value = advLocationState4;
            pdpInfoCommand.Parameters["@advLocationZip4"].Value = advLocationZip4;
            pdpInfoCommand.Parameters["@advAff4"].Value = advAff4;
            if (advDate4 !=  "")
                pdpInfoCommand.Parameters["@advDate4"].Value = DateTime.Parse(advDate4);
            else
                pdpInfoCommand.Parameters["@advDate4"].Value = null;
            pdpInfoCommand.Parameters["@advLocation4"].Value = advLoc4;
            pdpInfoCommand.Parameters["@advName5"].Value = advName5;
            pdpInfoCommand.Parameters["@advLName5"].Value = advLName5;
            pdpInfoCommand.Parameters["@advType5"].Value = advType5;
            pdpInfoCommand.Parameters["@advLocationState5"].Value = advLocationState5;
            pdpInfoCommand.Parameters["@advLocationZip5"].Value = advLocationZip5;
            pdpInfoCommand.Parameters["@advAff5"].Value = advAff5;
            if (advDate5 !=  "")
                pdpInfoCommand.Parameters["@advDate5"].Value = DateTime.Parse(advDate5);
            else
                pdpInfoCommand.Parameters["@advDate5"].Value = null;
            pdpInfoCommand.Parameters["@advLocation5"].Value = advLoc5;
            pdpInfoCommand.Parameters["@advName6"].Value = advName6;
            pdpInfoCommand.Parameters["@advLName6"].Value = advLName6;
            pdpInfoCommand.Parameters["@advType6"].Value = advType6;
            pdpInfoCommand.Parameters["@advLocationState6"].Value = advLocationState6;
            pdpInfoCommand.Parameters["@advLocationZip6"].Value = advLocationZip6;
            pdpInfoCommand.Parameters["@advAff6"].Value = advAff6;
            if (advDate6 !=  "")
                pdpInfoCommand.Parameters["@advDate6"].Value = DateTime.Parse(advDate6);
            else
                pdpInfoCommand.Parameters["@advDate6"].Value = null;
            pdpInfoCommand.Parameters["@advLocation6"].Value = advLoc6;
            pdpInfoCommand.Parameters["@advName7"].Value = advName7;
            pdpInfoCommand.Parameters["@advLName7"].Value = advLName7;
            pdpInfoCommand.Parameters["@advAff7"].Value = advAff7;
            pdpInfoCommand.Parameters["@advName8"].Value = advName8;
            pdpInfoCommand.Parameters["@advLName8"].Value = advLName8;
            pdpInfoCommand.Parameters["@advAff8"].Value = advAff8;
            pdpInfoCommand.Parameters["@advName9"].Value = advName9;
            pdpInfoCommand.Parameters["@advLName9"].Value = advLName9;
            pdpInfoCommand.Parameters["@advAff9"].Value = advAff9;
            pdpInfoCommand.Parameters["@advName10"].Value = advName10;
            pdpInfoCommand.Parameters["@advLName10"].Value = advLName10;
            pdpInfoCommand.Parameters["@advAff10"].Value = advAff10;
            pdpInfoCommand.Parameters["@advName11"].Value = advName11;
            pdpInfoCommand.Parameters["@advLName11"].Value = advLName11;
            pdpInfoCommand.Parameters["@advAff11"].Value = advAff11;
            pdpInfoCommand.Parameters["@advName12"].Value = advName12;
            pdpInfoCommand.Parameters["@advLName12"].Value = advLName12;
            pdpInfoCommand.Parameters["@advAff12"].Value = advAff12;
            pdpInfoCommand.Parameters["@advName13"].Value = advName13;
            pdpInfoCommand.Parameters["@advLName13"].Value = advLName13;
            pdpInfoCommand.Parameters["@advAff13"].Value = advAff13;
            pdpInfoCommand.Parameters["@advName14"].Value = advName14;
            pdpInfoCommand.Parameters["@advLName14"].Value = advLName14;
            pdpInfoCommand.Parameters["@advAff14"].Value = advAff14;
            pdpInfoCommand.Parameters["@advName15"].Value = advName15;
            pdpInfoCommand.Parameters["@advLName15"].Value = advLName15;
            pdpInfoCommand.Parameters["@advAff15"].Value = advAff15;
            pdpInfoCommand.Parameters["@sare_outreach"].Value = sare_outreach;


            pdpInfoConnection.Open();
            pdpInfoCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpInfoConnection.Close();
            pdpInfoCommand.Dispose();
            pdpInfoConnection.Dispose();

            return key;
        }

        public bool UpdatePDPInitPartnersToDB()
        {
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPInitPartnersUpdate";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;

            pdpInitPartnersCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@init_topic", SqlDbType.NText);
            pdpInitPartnersCommand.Parameters.Add("@training_obj", SqlDbType.NText);
            pdpInitPartnersCommand.Parameters.Add("@part_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@initiative_num", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@proj_num"].Value = projNum;
            pdpInitPartnersCommand.Parameters["@init_topic"].Value = init_topic;
            pdpInitPartnersCommand.Parameters["@training_obj"].Value = training_obj;
            pdpInitPartnersCommand.Parameters["@part_ext"].Value = part_ext;
            pdpInitPartnersCommand.Parameters["@part_nrcs"].Value = part_nrcs;
            pdpInitPartnersCommand.Parameters["@part_ngo"].Value = part_ngo;
            pdpInitPartnersCommand.Parameters["@part_state"].Value = part_state;
            pdpInitPartnersCommand.Parameters["@part_farmer"].Value = part_farmer;
            pdpInitPartnersCommand.Parameters["@part_other"].Value = part_other;
            pdpInitPartnersCommand.Parameters["@train_ext"].Value = train_ext;
            pdpInitPartnersCommand.Parameters["@train_nrcs"].Value = train_nrcs;
            pdpInitPartnersCommand.Parameters["@train_ngo"].Value = train_ngo;
            pdpInitPartnersCommand.Parameters["@train_state"].Value = train_state;
            pdpInitPartnersCommand.Parameters["@train_farmer"].Value = train_farmer;
            pdpInitPartnersCommand.Parameters["@train_other"].Value = train_other;
            pdpInitPartnersCommand.Parameters["@dev_ext"].Value = dev_ext;
            pdpInitPartnersCommand.Parameters["@dev_nrcs"].Value = dev_nrcs;
            pdpInitPartnersCommand.Parameters["@dev_ngo"].Value = dev_ngo;
            pdpInitPartnersCommand.Parameters["@dev_state"].Value = dev_state;
            pdpInitPartnersCommand.Parameters["@dev_farmer"].Value = dev_farmer;
            pdpInitPartnersCommand.Parameters["@dev_other"].Value = dev_other;
            pdpInitPartnersCommand.Parameters["@inv_ext"].Value = inv_ext;
            pdpInitPartnersCommand.Parameters["@inv_nrcs"].Value = inv_nrcs;
            pdpInitPartnersCommand.Parameters["@inv_ngo"].Value = inv_ngo;
            pdpInitPartnersCommand.Parameters["@inv_state"].Value = inv_state;
            pdpInitPartnersCommand.Parameters["@inv_farmer"].Value = inv_farmer;
            pdpInitPartnersCommand.Parameters["@inv_other"].Value = inv_other;
            pdpInitPartnersCommand.Parameters["@initiative_num"].Value = initiative_num;


            pdpInitPartnersConnection.Open();
            pdpInitPartnersCommand.ExecuteScalar();

            pdpInitPartnersConnection.Close();
            pdpInitPartnersCommand.Dispose();
            pdpInitPartnersConnection.Dispose();

            return true;

        }

        public int saveNewPDPInitPartnersToDB()
        {
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPInitPartnersCreate";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpInitPartnersCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@init_topic", SqlDbType.NText);
            pdpInitPartnersCommand.Parameters.Add("@training_obj", SqlDbType.NText);
            pdpInitPartnersCommand.Parameters.Add("@part_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@part_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@train_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@dev_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_ext", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_nrcs", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_ngo", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_state", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_farmer", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@inv_other", SqlDbType.Int);
            pdpInitPartnersCommand.Parameters.Add("@init_num", SqlDbType.Int);


            pdpInitPartnersCommand.Parameters.Add(keyOutput);

            pdpInitPartnersCommand.Parameters["@proj_num"].Value = projNum;
            pdpInitPartnersCommand.Parameters["@init_topic"].Value = init_topic;
            pdpInitPartnersCommand.Parameters["@training_obj"].Value = training_obj;
            pdpInitPartnersCommand.Parameters["@part_ext"].Value = part_ext;
            pdpInitPartnersCommand.Parameters["@part_nrcs"].Value = part_nrcs;
            pdpInitPartnersCommand.Parameters["@part_ngo"].Value = part_ngo;
            pdpInitPartnersCommand.Parameters["@part_state"].Value = part_state;
            pdpInitPartnersCommand.Parameters["@part_farmer"].Value = part_farmer;
            pdpInitPartnersCommand.Parameters["@part_other"].Value = part_other;
            pdpInitPartnersCommand.Parameters["@train_ext"].Value = train_ext;
            pdpInitPartnersCommand.Parameters["@train_nrcs"].Value = train_nrcs;
            pdpInitPartnersCommand.Parameters["@train_ngo"].Value = train_ngo;
            pdpInitPartnersCommand.Parameters["@train_state"].Value = train_state;
            pdpInitPartnersCommand.Parameters["@train_farmer"].Value = train_farmer;
            pdpInitPartnersCommand.Parameters["@train_other"].Value = train_other;
            pdpInitPartnersCommand.Parameters["@dev_ext"].Value = dev_ext;
            pdpInitPartnersCommand.Parameters["@dev_nrcs"].Value = dev_nrcs;
            pdpInitPartnersCommand.Parameters["@dev_ngo"].Value = dev_ngo;
            pdpInitPartnersCommand.Parameters["@dev_state"].Value = dev_state;
            pdpInitPartnersCommand.Parameters["@dev_farmer"].Value = dev_farmer;
            pdpInitPartnersCommand.Parameters["@dev_other"].Value = dev_other;
            pdpInitPartnersCommand.Parameters["@inv_ext"].Value = inv_ext;
            pdpInitPartnersCommand.Parameters["@inv_nrcs"].Value = inv_nrcs;
            pdpInitPartnersCommand.Parameters["@inv_ngo"].Value = inv_ngo;
            pdpInitPartnersCommand.Parameters["@inv_state"].Value = inv_state;
            pdpInitPartnersCommand.Parameters["@inv_farmer"].Value = inv_farmer;
            pdpInitPartnersCommand.Parameters["@inv_other"].Value = inv_other;
            pdpInitPartnersCommand.Parameters["@init_num"].Value = initiative_count;
            
            
            pdpInitPartnersConnection.Open();
            pdpInitPartnersCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpInitPartnersConnection.Close();
            pdpInitPartnersCommand.Dispose();
            pdpInitPartnersConnection.Dispose();

            return key;
        }

        public int saveNewPDPOutNarrToDB()
        {
            string pdpOutNarrSQL;
            string pdpOutNarrConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpOutNarrConnection;
            SqlCommand pdpOutNarrCommand;

            pdpOutNarrConnection = new SqlConnection(pdpOutNarrConnString);

            pdpOutNarrSQL = "DaikonPDPOutNarrCreate";
            pdpOutNarrCommand = new SqlCommand(pdpOutNarrSQL, pdpOutNarrConnection);
            pdpOutNarrCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpOutNarrCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpOutNarrCommand.Parameters.Add("@out_summary", SqlDbType.NText);
            pdpOutNarrCommand.Parameters.Add("@out_desc", SqlDbType.NText);
            pdpOutNarrCommand.Parameters.Add("@out_other", SqlDbType.NText);


            pdpOutNarrCommand.Parameters.Add(keyOutput);

            pdpOutNarrCommand.Parameters["@proj_num"].Value = projNum;
            pdpOutNarrCommand.Parameters["@out_summary"].Value = out_summary;
            pdpOutNarrCommand.Parameters["@out_desc"].Value = out_desc;
            pdpOutNarrCommand.Parameters["@out_other"].Value = out_other;

            pdpOutNarrConnection.Open();
            pdpOutNarrCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpOutNarrConnection.Close();
            pdpOutNarrCommand.Dispose();
            pdpOutNarrConnection.Dispose();

            return key;
        }



        public bool UpdatePDPInfoToDB()
        {
            string pdpInfoSQL;
            string pdpInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpInfoConnection;
            SqlCommand pdpInfoCommand;

            pdpInfoConnection = new SqlConnection(pdpInfoConnString);

            pdpInfoSQL = "DaikonPDPInfoUpdate";
            pdpInfoCommand = new SqlCommand(pdpInfoSQL, pdpInfoConnection);
            pdpInfoCommand.CommandType = CommandType.StoredProcedure;

            pdpInfoCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_firstName", SqlDbType.VarChar, 120);
            pdpInfoCommand.Parameters.Add("@pi_lastName", SqlDbType.VarChar, 120);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity2", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race2", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType2", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_ethinicity3", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_race3", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_instituteName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_instituteType3", SqlDbType.Int);
            pdpInfoCommand.Parameters.Add("@pi_address", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_city", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_state", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@pi_zip", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@pi_phone", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_fax", SqlDbType.VarChar, 50);
            pdpInfoCommand.Parameters.Add("@pi_email", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@pi_statePro", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState1", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip1", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate1", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation1", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState2", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip2", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate2", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation2", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState3", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip3", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate3", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation3", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState4", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip4", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate4", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation4", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState5", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip5", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate5", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation5", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advType6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLocationState6", SqlDbType.VarChar, 4);
            pdpInfoCommand.Parameters.Add("@advLocationZip6", SqlDbType.VarChar, 5);
            pdpInfoCommand.Parameters.Add("@advAff6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advDate6", SqlDbType.Date);
            pdpInfoCommand.Parameters.Add("@advLocation6", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff7", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff8", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff9", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff10", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff11", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff12", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff13", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff14", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advName15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advLName15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@advAff15", SqlDbType.VarChar, 255);
            pdpInfoCommand.Parameters.Add("@sare_outreach", SqlDbType.NText);
            //pdpInfoCommand.Parameters.Add("@initiative_count", SqlDbType.Int);
          

            pdpInfoCommand.Parameters["@proj_num"].Value = projNum;
            pdpInfoCommand.Parameters["@pi_firstName"].Value = piFName;
            pdpInfoCommand.Parameters["@pi_lastName"].Value = piLName;
            pdpInfoCommand.Parameters["@pi_ethinicity"].Value = PiEthinicity;
            pdpInfoCommand.Parameters["@pi_race"].Value = piRace;
            pdpInfoCommand.Parameters["@pi_instituteName"].Value = piInstName;
            pdpInfoCommand.Parameters["@pi_instituteType"].Value = piInstType;
            pdpInfoCommand.Parameters["@pi_ethinicity2"].Value = PiEthinicity2;
            pdpInfoCommand.Parameters["@pi_race2"].Value = piRace2;
            pdpInfoCommand.Parameters["@pi_instituteName2"].Value = piInstName2;
            pdpInfoCommand.Parameters["@pi_instituteType2"].Value = piInstType2;
            pdpInfoCommand.Parameters["@pi_ethinicity3"].Value = PiEthinicity3;
            pdpInfoCommand.Parameters["@pi_race3"].Value = piRace3;
            pdpInfoCommand.Parameters["@pi_instituteName3"].Value = piInstName3;
            pdpInfoCommand.Parameters["@pi_instituteType3"].Value = piInstType3;
            pdpInfoCommand.Parameters["@pi_address"].Value = piAdd;
            pdpInfoCommand.Parameters["@pi_city"].Value = piCity;
            pdpInfoCommand.Parameters["@pi_state"].Value = piState;
            pdpInfoCommand.Parameters["@pi_zip"].Value = piZip;
            pdpInfoCommand.Parameters["@pi_phone"].Value = piPhone;
            pdpInfoCommand.Parameters["@pi_fax"].Value = piFax;
            pdpInfoCommand.Parameters["@pi_email"].Value = piEmail;
            pdpInfoCommand.Parameters["@pi_statePro"].Value = piStatePro;
            pdpInfoCommand.Parameters["@advName"].Value = advName;
            pdpInfoCommand.Parameters["@advLName"].Value = advLName;
            pdpInfoCommand.Parameters["@advType"].Value = advType;
            pdpInfoCommand.Parameters["@advLocationState"].Value = advLocationState;
            pdpInfoCommand.Parameters["@advLocationZip"].Value = advLocationZip;
            pdpInfoCommand.Parameters["@advAff"].Value = advAff;
            if (advDate != "")
                pdpInfoCommand.Parameters["@advDate"].Value = DateTime.Parse(advDate);
            else
                pdpInfoCommand.Parameters["@advDate"].Value = null;
            pdpInfoCommand.Parameters["@advLocation"].Value = advLoc;
            pdpInfoCommand.Parameters["@advName1"].Value = advName1;
            pdpInfoCommand.Parameters["@advLName1"].Value = advLName1;
            pdpInfoCommand.Parameters["@advType1"].Value = advType1;
            pdpInfoCommand.Parameters["@advLocationState1"].Value = advLocationState1;
            pdpInfoCommand.Parameters["@advLocationZip1"].Value = advLocationZip1;
            pdpInfoCommand.Parameters["@advAff1"].Value = advAff1;
            if (advDate1 != "")
                pdpInfoCommand.Parameters["@advDate1"].Value = DateTime.Parse(advDate1);
            else
                pdpInfoCommand.Parameters["@advDate1"].Value = null;
            pdpInfoCommand.Parameters["@advLocation1"].Value = advLoc1;
            pdpInfoCommand.Parameters["@advName2"].Value = advName2;
            pdpInfoCommand.Parameters["@advLName2"].Value = advLName2;
            pdpInfoCommand.Parameters["@advType2"].Value = advType2;
            pdpInfoCommand.Parameters["@advLocationState2"].Value = advLocationState2;
            pdpInfoCommand.Parameters["@advLocationZip2"].Value = advLocationZip2;
            pdpInfoCommand.Parameters["@advAff2"].Value = advAff2;
            if (advDate2 != "")
                pdpInfoCommand.Parameters["@advDate2"].Value = DateTime.Parse(advDate2);
            else
                pdpInfoCommand.Parameters["@advDate2"].Value = null;
            pdpInfoCommand.Parameters["@advLocation2"].Value = advLoc2;
            pdpInfoCommand.Parameters["@advName3"].Value = advName3;
            pdpInfoCommand.Parameters["@advLName3"].Value = advLName3;
            pdpInfoCommand.Parameters["@advType3"].Value = advType3;
            pdpInfoCommand.Parameters["@advLocationState3"].Value = advLocationState3;
            pdpInfoCommand.Parameters["@advLocationZip3"].Value = advLocationZip3;
            pdpInfoCommand.Parameters["@advAff3"].Value = advAff3;
            if (advDate3 != "")
                pdpInfoCommand.Parameters["@advDate3"].Value = DateTime.Parse(advDate3);
            else
                pdpInfoCommand.Parameters["@advDate3"].Value = null;
            pdpInfoCommand.Parameters["@advLocation3"].Value = advLoc3;
            pdpInfoCommand.Parameters["@advName4"].Value = advName4;
            pdpInfoCommand.Parameters["@advLName4"].Value = advLName4;
            pdpInfoCommand.Parameters["@advType4"].Value = advType4;
            pdpInfoCommand.Parameters["@advLocationState4"].Value = advLocationState4;
            pdpInfoCommand.Parameters["@advLocationZip4"].Value = advLocationZip4;
            pdpInfoCommand.Parameters["@advAff4"].Value = advAff4;
            if (advDate4 != "")
                pdpInfoCommand.Parameters["@advDate4"].Value = DateTime.Parse(advDate4);
            else
                pdpInfoCommand.Parameters["@advDate4"].Value = null;
            pdpInfoCommand.Parameters["@advLocation4"].Value = advLoc4;
            pdpInfoCommand.Parameters["@advName5"].Value = advName5;
            pdpInfoCommand.Parameters["@advLName5"].Value = advLName5;
            pdpInfoCommand.Parameters["@advType5"].Value = advType5;
            pdpInfoCommand.Parameters["@advLocationState5"].Value = advLocationState5;
            pdpInfoCommand.Parameters["@advLocationZip5"].Value = advLocationZip5;
            pdpInfoCommand.Parameters["@advAff5"].Value = advAff5;
            if (advDate5 != "")
                pdpInfoCommand.Parameters["@advDate5"].Value = DateTime.Parse(advDate5);
            else
                pdpInfoCommand.Parameters["@advDate5"].Value = null;
            pdpInfoCommand.Parameters["@advLocation5"].Value = advLoc5;
            pdpInfoCommand.Parameters["@advName6"].Value = advName6;
            pdpInfoCommand.Parameters["@advLName6"].Value = advLName6;
            pdpInfoCommand.Parameters["@advType6"].Value = advType6;
            pdpInfoCommand.Parameters["@advLocationState6"].Value = advLocationState6;
            pdpInfoCommand.Parameters["@advLocationZip6"].Value = advLocationZip6;
            pdpInfoCommand.Parameters["@advAff6"].Value = advAff6;
            if (advDate6 != "")
                pdpInfoCommand.Parameters["@advDate6"].Value = DateTime.Parse(advDate6);
            else
                pdpInfoCommand.Parameters["@advDate6"].Value = null;
            pdpInfoCommand.Parameters["@advLocation6"].Value = advLoc6;
            pdpInfoCommand.Parameters["@advName7"].Value = advName7;
            pdpInfoCommand.Parameters["@advLName7"].Value = advLName7;
            pdpInfoCommand.Parameters["@advAff7"].Value = advAff7;
            pdpInfoCommand.Parameters["@advName8"].Value = advName8;
            pdpInfoCommand.Parameters["@advLName8"].Value = advLName8;
            pdpInfoCommand.Parameters["@advAff8"].Value = advAff8;
            pdpInfoCommand.Parameters["@advName9"].Value = advName9;
            pdpInfoCommand.Parameters["@advLName9"].Value = advLName9;
            pdpInfoCommand.Parameters["@advAff9"].Value = advAff9;
            pdpInfoCommand.Parameters["@advName10"].Value = advName10;
            pdpInfoCommand.Parameters["@advLName10"].Value = advLName10;
            pdpInfoCommand.Parameters["@advAff10"].Value = advAff10;
            pdpInfoCommand.Parameters["@advName11"].Value = advName11;
            pdpInfoCommand.Parameters["@advLName11"].Value = advLName11;
            pdpInfoCommand.Parameters["@advAff11"].Value = advAff11;
            pdpInfoCommand.Parameters["@advName12"].Value = advName12;
            pdpInfoCommand.Parameters["@advLName12"].Value = advLName12;
            pdpInfoCommand.Parameters["@advAff12"].Value = advAff12;
            pdpInfoCommand.Parameters["@advName13"].Value = advName13;
            pdpInfoCommand.Parameters["@advLName13"].Value = advLName13;
            pdpInfoCommand.Parameters["@advAff13"].Value = advAff13;
            pdpInfoCommand.Parameters["@advName14"].Value = advName14;
            pdpInfoCommand.Parameters["@advLName14"].Value = advLName14;
            pdpInfoCommand.Parameters["@advAff14"].Value = advAff14;
            pdpInfoCommand.Parameters["@advName15"].Value = advName15;
            pdpInfoCommand.Parameters["@advLName15"].Value = advLName15;
            pdpInfoCommand.Parameters["@advAff15"].Value = advAff15;
            pdpInfoCommand.Parameters["@sare_outreach"].Value = sare_outreach;
            //pdpInfoCommand.Parameters["@initiative_count"].Value = initiative_count;

            pdpInfoConnection.Open();
            pdpInfoCommand.ExecuteScalar();

            pdpInfoConnection.Close();
            pdpInfoCommand.Dispose();
            pdpInfoConnection.Dispose();

            return true;
        }

        public int UpdatePDPOutNarrToDB()
        {
            string pdpOutNarrSQL;
            string pdpOutNarrConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpOutNarrConnection;
            SqlCommand pdpOutNarrCommand;

            pdpOutNarrConnection = new SqlConnection(pdpOutNarrConnString);

            pdpOutNarrSQL = "DaikonPDPOutNarrUpdate";
            pdpOutNarrCommand = new SqlCommand(pdpOutNarrSQL, pdpOutNarrConnection);
            pdpOutNarrCommand.CommandType = CommandType.StoredProcedure;
           

            pdpOutNarrCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpOutNarrCommand.Parameters.Add("@out_summary", SqlDbType.NText);
            pdpOutNarrCommand.Parameters.Add("@out_desc", SqlDbType.NText);
            pdpOutNarrCommand.Parameters.Add("@out_other", SqlDbType.NText);


            pdpOutNarrCommand.Parameters["@proj_num"].Value = projNum;
            pdpOutNarrCommand.Parameters["@out_summary"].Value = out_summary;
            pdpOutNarrCommand.Parameters["@out_desc"].Value = out_desc;
            pdpOutNarrCommand.Parameters["@out_other"].Value = out_other;

            pdpOutNarrConnection.Open();
            pdpOutNarrCommand.ExecuteScalar();

           
            pdpOutNarrConnection.Close();
            pdpOutNarrCommand.Dispose();
            pdpOutNarrConnection.Dispose();

            return 1;
        }

        public bool getPdpInfoDetailsByPdpID(string pdp_projnum)
        {
            string pdpInfoSQL;
            string pdpInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInfoConnection;
            SqlCommand pdpInfoCommand;
            SqlDataReader pdpInfoDataReader;

            pdpInfoConnection = new SqlConnection(pdpInfoConnString);

            pdpInfoSQL = "DaikonPDPInfoByPdpID";
            pdpInfoCommand = new SqlCommand(pdpInfoSQL, pdpInfoConnection);
            pdpInfoCommand.CommandType = CommandType.StoredProcedure;
            pdpInfoCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);

            pdpInfoCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            
            pdpInfoConnection.Open();
            pdpInfoDataReader = pdpInfoCommand.ExecuteReader();

            if (pdpInfoDataReader.HasRows)
            {
                pdpInfoDataReader.Read();
                pdpid = int.Parse(pdpInfoDataReader["pdpID"].ToString());
                projNum = pdpInfoDataReader["proj_num"].ToString();
                piFName = pdpInfoDataReader["pi_firstName"].ToString();
                piLName = pdpInfoDataReader["pi_lastName"].ToString();
                piEthinicity = pdpInfoDataReader["pi_ethinicity"].ToString();
                piRace = int.Parse(pdpInfoDataReader["pi_race"].ToString());
                piInstName = pdpInfoDataReader["pi_instituteName"].ToString();
                piInstType = int.Parse(pdpInfoDataReader["pi_instituteType"].ToString());
                piEthinicity2 = pdpInfoDataReader["pi_ethinicity2"].ToString();
                if (pdpInfoDataReader["pi_race2"].ToString() != "")
                    piRace2 = int.Parse(pdpInfoDataReader["pi_race2"].ToString());
                piInstName2 = pdpInfoDataReader["pi_instituteName2"].ToString();
                if (pdpInfoDataReader["pi_instituteType2"].ToString() != "")
                    piInstType2 = int.Parse(pdpInfoDataReader["pi_instituteType2"].ToString());
                piEthinicity3 = pdpInfoDataReader["pi_ethinicity3"].ToString();
                if (pdpInfoDataReader["pi_race3"].ToString() != "")
                    piRace3 = int.Parse(pdpInfoDataReader["pi_race3"].ToString());
                piInstName3 = pdpInfoDataReader["pi_instituteName3"].ToString();
                if (pdpInfoDataReader["pi_instituteType3"].ToString() != "")
                    piInstType3 = int.Parse(pdpInfoDataReader["pi_instituteType3"].ToString());
                piAdd = pdpInfoDataReader["pi_address"].ToString();
                piCity = pdpInfoDataReader["pi_city"].ToString();
                piState = pdpInfoDataReader["pi_state"].ToString();
                piZip = pdpInfoDataReader["pi_zip"].ToString();
                piPhone = pdpInfoDataReader["pi_phone"].ToString();
                piFax = pdpInfoDataReader["pi_fax"].ToString();
                piEmail = pdpInfoDataReader["pi_email"].ToString();
                piStatePro = pdpInfoDataReader["pi_statePro"].ToString();
                advName = pdpInfoDataReader["advName"].ToString();
                advLName = pdpInfoDataReader["advLName"].ToString();
                advType = pdpInfoDataReader["advType"].ToString();
                advLocationState = pdpInfoDataReader["advLocationState"].ToString();
                advLocationZip = pdpInfoDataReader["advLocationZip"].ToString();
                advAff = pdpInfoDataReader["advAff"].ToString();
                advDate = pdpInfoDataReader["advDate"].ToString();
                if (advDate != "")
                {
                    DateTime advDateTrim = DateTime.Parse(advDate);
                    advDate = advDateTrim.ToShortDateString();
                }
                advLoc = pdpInfoDataReader["advLocation"].ToString();
                advName1 = pdpInfoDataReader["advName1"].ToString();
                advLName1 = pdpInfoDataReader["advLName1"].ToString();
                advType1 = pdpInfoDataReader["advType1"].ToString();
                advLocationState1 = pdpInfoDataReader["advLocationState1"].ToString();
                advLocationZip1 = pdpInfoDataReader["advLocationZip1"].ToString();
                advAff1 = pdpInfoDataReader["advAff1"].ToString();
                advDate1 = pdpInfoDataReader["advDate1"].ToString();
                if (advDate1 != "")
                {
                    DateTime advDateTrim1 = DateTime.Parse(advDate1);
                    advDate1 = advDateTrim1.ToShortDateString();
                }
                advLoc1 = pdpInfoDataReader["advLocation1"].ToString();
                advName2 = pdpInfoDataReader["advName2"].ToString();
                advLName2 = pdpInfoDataReader["advLName2"].ToString();
                advType2 = pdpInfoDataReader["advType2"].ToString();
                advLocationState2 = pdpInfoDataReader["advLocationState2"].ToString();
                advLocationZip2 = pdpInfoDataReader["advLocationZip2"].ToString();
                advAff2 = pdpInfoDataReader["advAff2"].ToString();
                advDate2 = pdpInfoDataReader["advDate2"].ToString();
                if (advDate2 != "")
                {
                    DateTime advDateTrim2 = DateTime.Parse(advDate2);
                    advDate2 = advDateTrim2.ToShortDateString();
                }
                advLoc2 = pdpInfoDataReader["advLocation2"].ToString();
                advName3 = pdpInfoDataReader["advName3"].ToString();
                advLName3 = pdpInfoDataReader["advLName3"].ToString();
                advType3 = pdpInfoDataReader["advType3"].ToString();
                advLocationState3 = pdpInfoDataReader["advLocationState3"].ToString();
                advLocationZip3 = pdpInfoDataReader["advLocationZip3"].ToString();
                advAff3 = pdpInfoDataReader["advAff3"].ToString();
                advDate3 = pdpInfoDataReader["advDate3"].ToString();
                if (advDate3 != "")
                {
                    DateTime advDateTrim3 = DateTime.Parse(advDate3);
                    advDate3 = advDateTrim3.ToShortDateString();
                }
                advLoc3 = pdpInfoDataReader["advLocation3"].ToString();
                advName4 = pdpInfoDataReader["advName4"].ToString();
                advLName4 = pdpInfoDataReader["advLName4"].ToString();
                advType4 = pdpInfoDataReader["advType4"].ToString();
                advLocationState4 = pdpInfoDataReader["advLocationState4"].ToString();
                advLocationZip4 = pdpInfoDataReader["advLocationZip4"].ToString();
                advAff4 = pdpInfoDataReader["advAff4"].ToString();
                advDate4 = pdpInfoDataReader["advDate4"].ToString();
                if (advDate4 != "")
                {
                    DateTime advDateTrim4 = DateTime.Parse(advDate4);
                    advDate4 = advDateTrim4.ToShortDateString();
                }
                advLoc4 = pdpInfoDataReader["advLocation4"].ToString();
                advName5 = pdpInfoDataReader["advName5"].ToString();
                advLName5 = pdpInfoDataReader["advLName5"].ToString();
                advType5 = pdpInfoDataReader["advType5"].ToString();
                advLocationState5 = pdpInfoDataReader["advLocationState5"].ToString();
                advLocationZip5 = pdpInfoDataReader["advLocationZip5"].ToString();
                advAff5 = pdpInfoDataReader["advAff5"].ToString();
                advDate5 = pdpInfoDataReader["advDate5"].ToString();
                if (advDate5 != "")
                {
                    DateTime advDateTrim5 = DateTime.Parse(advDate5);
                    advDate5 = advDateTrim5.ToShortDateString();
                }
                advLoc5 = pdpInfoDataReader["advLocation5"].ToString();
                advName6 = pdpInfoDataReader["advName6"].ToString();
                advLName6 = pdpInfoDataReader["advLName6"].ToString();
                advType6 = pdpInfoDataReader["advType6"].ToString();
                advLocationState6 = pdpInfoDataReader["advLocationState6"].ToString();
                advLocationZip6 = pdpInfoDataReader["advLocationZip6"].ToString();
                advAff6 = pdpInfoDataReader["advAff6"].ToString();
                advDate6 = pdpInfoDataReader["advDate6"].ToString();
                if (advDate6 != "")
                {
                    DateTime advDateTrim6 = DateTime.Parse(advDate6);
                    advDate6 = advDateTrim6.ToShortDateString();
                }
                advLoc6 = pdpInfoDataReader["advLocation6"].ToString();
                advName7 = pdpInfoDataReader["advName7"].ToString();
                advLName7 = pdpInfoDataReader["advLName7"].ToString();
                advAff7 = pdpInfoDataReader["advAff7"].ToString();
                advName8 = pdpInfoDataReader["advName8"].ToString();
                advLName8 = pdpInfoDataReader["advLName8"].ToString();
                advAff8 = pdpInfoDataReader["advAff8"].ToString();
                advName9 = pdpInfoDataReader["advName9"].ToString();
                advLName9 = pdpInfoDataReader["advLName9"].ToString();
                advAff9 = pdpInfoDataReader["advAff9"].ToString();
                advName10 = pdpInfoDataReader["advName10"].ToString();
                advLName10 = pdpInfoDataReader["advLName10"].ToString();
                advAff10 = pdpInfoDataReader["advAff10"].ToString();
                advName11 = pdpInfoDataReader["advName11"].ToString();
                advLName11 = pdpInfoDataReader["advLName11"].ToString();
                advAff11 = pdpInfoDataReader["advAff11"].ToString();
                advName12 = pdpInfoDataReader["advName12"].ToString();
                advLName12 = pdpInfoDataReader["advLName12"].ToString();
                advAff12 = pdpInfoDataReader["advAff12"].ToString();
                advName13 = pdpInfoDataReader["advName13"].ToString();
                advLName13 = pdpInfoDataReader["advLName13"].ToString();
                advAff13 = pdpInfoDataReader["advAff13"].ToString();
                advName14 = pdpInfoDataReader["advName14"].ToString();
                advLName14 = pdpInfoDataReader["advLName14"].ToString();
                advAff14 = pdpInfoDataReader["advAff14"].ToString();
                advName15 = pdpInfoDataReader["advName15"].ToString();
                advLName15 = pdpInfoDataReader["advLName15"].ToString();
                advAff15 = pdpInfoDataReader["advAff15"].ToString();
                sare_outreach = pdpInfoDataReader["sare_outreach"].ToString();
                initiative_count = int.Parse(pdpInfoDataReader["initiative_count"].ToString());
            }
            else
            {
            }
            pdpInfoConnection.Dispose();

            return true;
        }

        public bool getPdpInitPartnersByProjNum(string pdp_projnum)
        {
            bool result = false;
            int initiative_num = 0;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPInitParrnersByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;

            pdpInitPartnersConnection.Open();
            //pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            //if (pdpInitPartnersDataReader.HasRows)
            using (pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader())
            {
                //pdpInitPartnersDataReader.Read(); 
                if (pdpInitPartnersDataReader.HasRows)
                    result = true;

                while (pdpInitPartnersDataReader.Read())
                {
                    initiative_num = int.Parse(pdpInitPartnersDataReader["initiative_num"].ToString());
                    if (initiative_num == 0)
                    {
                        pdpInitID = int.Parse(pdpInitPartnersDataReader["pdp_init_id"].ToString());
                        projNum = pdpInitPartnersDataReader["proj_num"].ToString();
                        init_topic = pdpInitPartnersDataReader["init_topic"].ToString();
                        training_obj = pdpInitPartnersDataReader["training_obj"].ToString();
                        part_ext = int.Parse(pdpInitPartnersDataReader["part_ext"].ToString());
                        part_nrcs = int.Parse(pdpInitPartnersDataReader["part_nrcs"].ToString());
                        part_ngo = int.Parse(pdpInitPartnersDataReader["part_ngo"].ToString());
                        part_state = int.Parse(pdpInitPartnersDataReader["part_state"].ToString());
                        part_farmer = int.Parse(pdpInitPartnersDataReader["part_farmer"].ToString());
                        part_other = int.Parse(pdpInitPartnersDataReader["part_other"].ToString());
                        train_ext = int.Parse(pdpInitPartnersDataReader["train_ext"].ToString());
                        train_nrcs = int.Parse(pdpInitPartnersDataReader["train_nrcs"].ToString());
                        train_ngo = int.Parse(pdpInitPartnersDataReader["train_ngo"].ToString());
                        train_farmer = int.Parse(pdpInitPartnersDataReader["train_farmer"].ToString());
                        train_state = int.Parse(pdpInitPartnersDataReader["train_state"].ToString());
                        train_other = int.Parse(pdpInitPartnersDataReader["train_other"].ToString());
                        dev_ext = int.Parse(pdpInitPartnersDataReader["dev_ext"].ToString());
                        dev_nrcs = int.Parse(pdpInitPartnersDataReader["dev_nrcs"].ToString());
                        dev_ngo = int.Parse(pdpInitPartnersDataReader["dev_ngo"].ToString());
                        dev_state = int.Parse(pdpInitPartnersDataReader["dev_state"].ToString());
                        dev_farmer = int.Parse(pdpInitPartnersDataReader["dev_farmer"].ToString());
                        dev_other = int.Parse(pdpInitPartnersDataReader["dev_other"].ToString());
                        inv_ext = int.Parse(pdpInitPartnersDataReader["inv_ext"].ToString());
                        inv_nrcs = int.Parse(pdpInitPartnersDataReader["inv_nrcs"].ToString());
                        inv_ngo = int.Parse(pdpInitPartnersDataReader["inv_ngo"].ToString());
                        inv_state = int.Parse(pdpInitPartnersDataReader["inv_state"].ToString());
                        inv_farmer = int.Parse(pdpInitPartnersDataReader["inv_farmer"].ToString());
                        inv_other = int.Parse(pdpInitPartnersDataReader["inv_other"].ToString());
                        initiative_title = init_topic;
                    }
                    if (initiative_num == 1)
                    {
                        initiative_title1 = pdpInitPartnersDataReader["init_topic"].ToString();
                    }
                    if (initiative_num == 2)
                    {
                        initiative_title2 = pdpInitPartnersDataReader["init_topic"].ToString();
                    }
                    if (initiative_num == 3)
                    {
                        initiative_title3 = pdpInitPartnersDataReader["init_topic"].ToString();
                    }
                    if (initiative_num == 4)
                    {
                        initiative_title4 = pdpInitPartnersDataReader["init_topic"].ToString();
                    }
                    if (initiative_num == 5)
                    {
                        initiative_title5 = pdpInitPartnersDataReader["init_topic"].ToString();
                    }

                }     

            }
           
            pdpInitPartnersConnection.Dispose();
            
            return result;
        }

        public bool getPdpInitPartnersByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPInitPartnersByProjNumAndInitId";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            if (pdpInitPartnersDataReader.HasRows)
            {
                pdpInitPartnersDataReader.Read();
                pdpInitID = int.Parse(pdpInitPartnersDataReader["pdp_init_id"].ToString());
                projNum = pdpInitPartnersDataReader["proj_num"].ToString();
                init_topic = pdpInitPartnersDataReader["init_topic"].ToString();
                training_obj = pdpInitPartnersDataReader["training_obj"].ToString();
                part_ext = int.Parse(pdpInitPartnersDataReader["part_ext"].ToString());
                part_nrcs = int.Parse(pdpInitPartnersDataReader["part_nrcs"].ToString());
                part_ngo = int.Parse(pdpInitPartnersDataReader["part_ngo"].ToString());
                part_state = int.Parse(pdpInitPartnersDataReader["part_state"].ToString());
                part_farmer = int.Parse(pdpInitPartnersDataReader["part_farmer"].ToString());
                part_other = int.Parse(pdpInitPartnersDataReader["part_other"].ToString());
                train_ext = int.Parse(pdpInitPartnersDataReader["train_ext"].ToString());
                train_nrcs = int.Parse(pdpInitPartnersDataReader["train_nrcs"].ToString());
                train_ngo = int.Parse(pdpInitPartnersDataReader["train_ngo"].ToString());
                train_farmer = int.Parse(pdpInitPartnersDataReader["train_farmer"].ToString());
                train_state = int.Parse(pdpInitPartnersDataReader["train_state"].ToString());
                train_other = int.Parse(pdpInitPartnersDataReader["train_other"].ToString());
                dev_ext = int.Parse(pdpInitPartnersDataReader["dev_ext"].ToString());
                dev_nrcs = int.Parse(pdpInitPartnersDataReader["dev_nrcs"].ToString());
                dev_ngo = int.Parse(pdpInitPartnersDataReader["dev_ngo"].ToString());
                dev_state = int.Parse(pdpInitPartnersDataReader["dev_state"].ToString());
                dev_farmer = int.Parse(pdpInitPartnersDataReader["dev_farmer"].ToString());
                dev_other = int.Parse(pdpInitPartnersDataReader["dev_other"].ToString());
                inv_ext = int.Parse(pdpInitPartnersDataReader["inv_ext"].ToString());
                inv_nrcs = int.Parse(pdpInitPartnersDataReader["inv_nrcs"].ToString());
                inv_ngo = int.Parse(pdpInitPartnersDataReader["inv_ngo"].ToString());
                inv_state = int.Parse(pdpInitPartnersDataReader["inv_state"].ToString());
                inv_farmer = int.Parse(pdpInitPartnersDataReader["inv_farmer"].ToString());
                inv_other = int.Parse(pdpInitPartnersDataReader["inv_other"].ToString());
                initiative_num = int.Parse(pdpInitPartnersDataReader["initiative_num"].ToString());

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityStudyByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutStudyByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_study_sessions == 0)
                    key_out_study_title1 = pdpInitPartnersDataReader["study_title"].ToString();
                if (key_out_study_sessions == 1)
                    key_out_study_title2 = pdpInitPartnersDataReader["study_title"].ToString();
                if (key_out_study_sessions == 2)
                    key_out_study_title3 = pdpInitPartnersDataReader["study_title"].ToString();
                if (key_out_study_sessions == 3)
                    key_out_study_title4 = pdpInitPartnersDataReader["study_title"].ToString();
                if (key_out_study_sessions == 4)
                    key_out_study_title5 = pdpInitPartnersDataReader["study_title"].ToString();
                if (key_out_study_sessions == 5)
                    key_out_study_title6 = pdpInitPartnersDataReader["study_title"].ToString();
                key_out_study_sessions++; 

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityWorkByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutWorkshopsByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_work_sessions == 0)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles1 = pdpInitPartnersDataReader["short_title"].ToString()+ "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles1 +=  pdpInitPartnersDataReader["inter_title"].ToString()+ "; " ;
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles1 += pdpInitPartnersDataReader["multi_title"].ToString() + "; " ;
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles1 +=  pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_work_sessions == 1)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles2 = pdpInitPartnersDataReader["short_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles2 += pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles2 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles2 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_work_sessions == 2)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles3 = pdpInitPartnersDataReader["short_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles3 += pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles3 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles3 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_work_sessions == 3)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles4 = pdpInitPartnersDataReader["short_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles4 += pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles4 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles4 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_work_sessions == 4)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles5 = pdpInitPartnersDataReader["short_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles5 += pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles5 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles5 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_work_sessions == 5)
                {
                    if (pdpInitPartnersDataReader["short_title"].ToString().Trim() != "")
                        key_out_work_titles6 = pdpInitPartnersDataReader["short_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_work_titles6 += pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_work_titles6 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_work_titles6 += pdpInitPartnersDataReader["extend_title"].ToString();
                }

                key_out_work_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityFieldByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutFieldByProjNumAndInitId";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_field_sessions == 0)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles1 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles1 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles1 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_field_sessions == 1)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles2 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles2 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles2 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_field_sessions == 2)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles3 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles3 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles3 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_field_sessions == 3)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles4 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles4 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles4 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_field_sessions == 4)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles5 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles5 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles5 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                if (key_out_field_sessions == 5)
                {
                    if (pdpInitPartnersDataReader["inter_title"].ToString().Trim() != "")
                        key_out_field_titles6 = pdpInitPartnersDataReader["inter_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["multi_title"].ToString().Trim() != "")
                        key_out_field_titles6 += pdpInitPartnersDataReader["multi_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["extend_title"].ToString().Trim() != "")
                        key_out_field_titles6 += pdpInitPartnersDataReader["extend_title"].ToString();
                }
                key_out_field_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityWebByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutWebByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_web_sessions == 0)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles1 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles1 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles1 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                if (key_out_web_sessions == 1)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles2 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles2 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles2 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                if (key_out_web_sessions == 2)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles3 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles3 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles3 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                if (key_out_web_sessions == 3)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles4 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles4 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles4 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                if (key_out_web_sessions == 4)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles5 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles5 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles5 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                if (key_out_web_sessions == 5)
                {
                    if (pdpInitPartnersDataReader["web_title"].ToString().Trim() != "")
                        key_out_web_titles6 = pdpInitPartnersDataReader["web_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webseries_title"].ToString().Trim() != "")
                        key_out_web_titles6 += pdpInitPartnersDataReader["webseries_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["webcur_title"].ToString().Trim() != "")
                        key_out_web_titles6 += pdpInitPartnersDataReader["webcur_title"].ToString();
                }
                key_out_web_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityGrantsByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutGrantsByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_grant_sessions == 0)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles1 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles1 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles1 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles1 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                if (key_out_grant_sessions == 1)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles2 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles2 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles2 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles2 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                if (key_out_grant_sessions == 2)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles3 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles3 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles3 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles3 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                if (key_out_grant_sessions == 3)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles4 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles4 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles4 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles4 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                if (key_out_grant_sessions == 4)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles5 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles5 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles5 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles5 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                if (key_out_grant_sessions == 5)
                {
                    if (pdpInitPartnersDataReader["demo_title"].ToString().Trim() != "")
                        key_out_grant_titles6 = pdpInitPartnersDataReader["demo_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["work_title"].ToString().Trim() != "")
                        key_out_grant_titles6 += pdpInitPartnersDataReader["work_title"].ToString() + "; ";
                    if (pdpInitPartnersDataReader["tour_title"].ToString().Trim() != "")
                        key_out_grant_titles6 += pdpInitPartnersDataReader["tour_title"].ToString();
                    if (pdpInitPartnersDataReader["cur_title"].ToString().Trim() != "")
                        key_out_grant_titles6 += pdpInitPartnersDataReader["cur_title"].ToString();
                }
                key_out_grant_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityTravelByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutTravelByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_travel_sessions == 0)
                    key_out_travel_titles1 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 1)
                    key_out_travel_titles2= pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 2)
                    key_out_travel_titles3 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 3)
                    key_out_travel_titles4 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 4)
                    key_out_travel_titles5 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 5)
                    key_out_travel_titles6 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 6)
                    key_out_travel_titles7 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 7)
                    key_out_travel_titles8 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 8)
                    key_out_travel_titles9= pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 9)
                    key_out_travel_titles10 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 10)
                    key_out_travel_titles11 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 11)
                    key_out_travel_titles12 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 12)
                    key_out_travel_titles13 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 13)
                    key_out_travel_titles14 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 14)
                    key_out_travel_titles15 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 15)
                    key_out_travel_titles16 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 16)
                    key_out_travel_titles17 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 17)
                    key_out_travel_titles18 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 18)
                    key_out_travel_titles19 = pdpInitPartnersDataReader["travel_title"].ToString();
                if (key_out_travel_sessions == 19)
                    key_out_travel_titles20 = pdpInitPartnersDataReader["travel_title"].ToString();
                key_out_travel_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }

        public bool getPdpKeyActivityOtherByProjNum(string pdp_projnum, int initNum)
        {
            bool result = false;
            string pdpInitPartnersSQL;
            string pdpInitPartnersConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpInitPartnersConnection;
            SqlCommand pdpInitPartnersCommand;
            SqlDataReader pdpInitPartnersDataReader;

            pdpInitPartnersConnection = new SqlConnection(pdpInitPartnersConnString);

            pdpInitPartnersSQL = "DaikonPDPKeyOutOtherByProjNum";
            pdpInitPartnersCommand = new SqlCommand(pdpInitPartnersSQL, pdpInitPartnersConnection);
            pdpInitPartnersCommand.CommandType = CommandType.StoredProcedure;
            pdpInitPartnersCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpInitPartnersCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);

            pdpInitPartnersCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpInitPartnersCommand.Parameters["@pdp_initID"].Value = initNum;

            pdpInitPartnersConnection.Open();
            pdpInitPartnersDataReader = pdpInitPartnersCommand.ExecuteReader();

            while (pdpInitPartnersDataReader.Read())
            {
                if (key_out_other_sessions == 0)
                    key_out_other_titles1 = pdpInitPartnersDataReader["other_title"].ToString();
                if (key_out_other_sessions == 1)
                    key_out_other_titles2 = pdpInitPartnersDataReader["other_title"].ToString();
                if (key_out_other_sessions == 2)
                    key_out_other_titles3 = pdpInitPartnersDataReader["other_title"].ToString();
                if (key_out_other_sessions == 3)
                    key_out_other_titles4 = pdpInitPartnersDataReader["other_title"].ToString();
                if (key_out_other_sessions == 4)
                    key_out_other_titles5 = pdpInitPartnersDataReader["other_title"].ToString();
                if (key_out_other_sessions == 5)
                    key_out_other_titles6 = pdpInitPartnersDataReader["other_title"].ToString();
                key_out_other_sessions++;

                result = true;
            }

            pdpInitPartnersConnection.Dispose();

            return result;
        }


        public bool getPdpOutNarrByProjNum(string proj_Num)
        {
            bool result = false;
            string pdpOutNarrSQL;
            string pdpOutNarrConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpOutNarrConnection;
            SqlCommand pdpOutNarrCommand;
            SqlDataReader pdpOutNarrDataReader;

            pdpOutNarrConnection = new SqlConnection(pdpOutNarrConnString);

            pdpOutNarrSQL = "DaikonPDPOutNarrByProjNum";
            pdpOutNarrCommand = new SqlCommand(pdpOutNarrSQL, pdpOutNarrConnection);
            pdpOutNarrCommand.CommandType = CommandType.StoredProcedure;
            pdpOutNarrCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);

            pdpOutNarrCommand.Parameters["@pdp_projnum"].Value = proj_Num;

            pdpOutNarrConnection.Open();
            //pdpOutNarrDataReader = pdpOutNarrCommand.ExecuteReader();

            using (pdpOutNarrDataReader = pdpOutNarrCommand.ExecuteReader())
            {
                while (pdpOutNarrDataReader.Read())
                {
                    //pdpOutNarrDataReader.Read();
                    pdp_out_id = int.Parse(pdpOutNarrDataReader["pdp_out_id"].ToString());
                    projNum = pdpOutNarrDataReader["proj_num"].ToString();
                    out_summary = pdpOutNarrDataReader["out_summary"].ToString();
                    out_desc = pdpOutNarrDataReader["out_desc"].ToString();
                    out_other = pdpOutNarrDataReader["out_other"].ToString();

                    result = true;
                }
                /*
                pdpOutNarrDataReader.NextResult();

                
                while (pdpOutNarrDataReader.Read())
                {
                    attachment_id = int.Parse(pdpOutNarrDataReader["attachment_id"].ToString());
                    attachment_title = pdpOutNarrDataReader["attachment_title"].ToString();
                }
                

                while (pdpOutNarrDataReader.Read())
                {
                    AddPdpAttachment(int.Parse(pdpOutNarrDataReader["attachment_id"].ToString()), pdpOutNarrDataReader["attachment_title"].ToString(), pdpOutNarrDataReader["attachment_caption"].ToString());
                }
                */
            }

            pdpOutNarrConnection.Dispose();

            return result;
        }

        public bool DeletePDPInitiative(string proj_num, int init_num)
        {
            bool result = false;

            string pdpIniativeSQL;
            string pdpIniativeConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpIniativeConnection;
            SqlCommand pdpIniativeCommand;
            SqlDataReader pdpIniativeDataReader;
            SqlParameter pdpReturnParameter;

            pdpIniativeConnection = new SqlConnection(pdpIniativeConnString);

            pdpIniativeSQL = "DaikonPDPInitiativeDelete";
            pdpIniativeCommand = new SqlCommand(pdpIniativeSQL, pdpIniativeConnection);
            pdpIniativeCommand.CommandType = CommandType.StoredProcedure;
            pdpReturnParameter = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            pdpReturnParameter.Direction = ParameterDirection.ReturnValue;

            pdpIniativeCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpIniativeCommand.Parameters.Add("@init_num", SqlDbType.Int);

            pdpIniativeCommand.Parameters["@proj_num"].Value = proj_num;
            pdpIniativeCommand.Parameters["@init_num"].Value = init_num;
            pdpIniativeCommand.Parameters.Add(pdpReturnParameter);

            pdpIniativeConnection.Open();

            pdpIniativeDataReader = pdpIniativeCommand.ExecuteReader();

            pdpIniativeDataReader.Read();
            pdpIniativeDataReader.Dispose();

            if (pdpReturnParameter.Value != null)
                result = true;

            return result;
        }

        public void toXmlPdpInfoDetails(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpInfoDetails");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_id", pdpid.ToString());
            if (getPdpInitPartnersByProjNum(projNum) == true)
            {
                xmlOut.WriteAttributeString("pdp_init_partners", "True");
                if (initiative_title != "")
                    xmlOut.WriteAttributeString("pdp_init_title", initiative_title);
                if (initiative_title1 != "")
                    xmlOut.WriteAttributeString("pdp_init_title1", initiative_title1);
                if (initiative_title2 != "")
                    xmlOut.WriteAttributeString("pdp_init_title2", initiative_title2);
                if (initiative_title3 != "")
                    xmlOut.WriteAttributeString("pdp_init_title3", initiative_title3);
                if (initiative_title4 != "")
                    xmlOut.WriteAttributeString("pdp_init_title4", initiative_title4);
                if (initiative_title5 != "")
                    xmlOut.WriteAttributeString("pdp_init_title5", initiative_title5);

            }
            else
                xmlOut.WriteAttributeString("pdp_init_partners", "False");
            if (getPdpOutNarrByProjNum(projNum) == true)
                xmlOut.WriteAttributeString("pdp_output_narrative", "True");
            else
                xmlOut.WriteAttributeString("pdp_output_narrative", "False");

            xmlOut.WriteElementString("coordfirst", piFName);
            xmlOut.WriteElementString("coordlast", piLName);

            if (piEthinicity == "hispanic")
                xmlOut.WriteElementString("hispanic", "True");
            else
                xmlOut.WriteElementString("hispanic", "False");
            if (piEthinicity == "nothispanic")
                xmlOut.WriteElementString("nothispanic", "True");
            else
                xmlOut.WriteElementString("nothispanic", "False");

            if (piRace == 1)
                xmlOut.WriteElementString("american","True");
            else
                xmlOut.WriteElementString("american","False");
            if (piRace == 2)                
                xmlOut.WriteElementString("asian","True");
            else
                xmlOut.WriteElementString("asian","False");
            if (piRace == 3)                
                xmlOut.WriteElementString("black","True");
            else
                xmlOut.WriteElementString("black","False");
             if (piRace == 4)                
                xmlOut.WriteElementString("hawaiian","True");
            else
                xmlOut.WriteElementString("hawaiian","False");
            if (piRace == 7)                
                xmlOut.WriteElementString("white","True");
            else
                xmlOut.WriteElementString("white","False");         
            
            xmlOut.WriteElementString("institute", piInstName);

            if (piInstType == 1862)
                xmlOut.WriteElementString("Grant1862", "True");
            else
                xmlOut.WriteElementString("Grant1862", "False");
            if (piInstType == 1890)
                xmlOut.WriteElementString("Grant1890", "True");
            else
                xmlOut.WriteElementString("Grant1890", "False");

            if (piEthinicity2 == "hispanic")
                xmlOut.WriteElementString("hispanic2", "True");
            else
                xmlOut.WriteElementString("hispanic2", "False");
            if (piEthinicity2 == "nothispanic")
                xmlOut.WriteElementString("nothispanic2", "True");
            else
                xmlOut.WriteElementString("nothispanic2", "False");

            if (piRace2 == 1)
                xmlOut.WriteElementString("american2", "True");
            else
                xmlOut.WriteElementString("american2", "False");
            if (piRace2 == 2)
                xmlOut.WriteElementString("asian2", "True");
            else
                xmlOut.WriteElementString("asian2", "False");
            if (piRace2 == 3)
                xmlOut.WriteElementString("black2", "True");
            else
                xmlOut.WriteElementString("black2", "False");
            if (piRace2 == 4)
                xmlOut.WriteElementString("hawaiian2", "True");
            else
                xmlOut.WriteElementString("hawaiian2", "False");
            if (piRace2 == 7)
                xmlOut.WriteElementString("white2", "True");
            else
                xmlOut.WriteElementString("white2", "False");

            xmlOut.WriteElementString("institute2", piInstName2);
            if (piInstType2 == 1862)
                xmlOut.WriteElementString("Grant1862_2", "True");
            else
                xmlOut.WriteElementString("Grant1862_2", "False");
            if (piInstType2 == 1890)
                xmlOut.WriteElementString("Grant1890_2", "True");
            else
                xmlOut.WriteElementString("Grant1890_2", "False");

            if (piEthinicity3 == "hispanic")
                xmlOut.WriteElementString("hispanic3", "True");
            else
                xmlOut.WriteElementString("hispanic3", "False");
            if (piEthinicity3 == "nothispanic")
                xmlOut.WriteElementString("nothispanic3", "True");
            else
                xmlOut.WriteElementString("nothispanic3", "False");

            if (piRace3 == 1)
                xmlOut.WriteElementString("american3", "True");
            else
                xmlOut.WriteElementString("american3", "False");
            if (piRace3 == 2)
                xmlOut.WriteElementString("asian3", "True");
            else
                xmlOut.WriteElementString("asian3", "False");
            if (piRace3 == 3)
                xmlOut.WriteElementString("black3", "True");
            else
                xmlOut.WriteElementString("black3", "False");
            if (piRace3 == 4)
                xmlOut.WriteElementString("hawaiian3", "True");
            else
                xmlOut.WriteElementString("hawaiian3", "False");
            if (piRace3 == 7)
                xmlOut.WriteElementString("white3", "True");
            else
                xmlOut.WriteElementString("white3", "False");

            xmlOut.WriteElementString("institute3", piInstName3);
            if (piInstType3 == 1862)
                xmlOut.WriteElementString("Grant1862_3", "True");
            else
                xmlOut.WriteElementString("Grant1862_3", "False");
            if (piInstType3 == 1890)
                xmlOut.WriteElementString("Grant1890_3", "True");
            else
                xmlOut.WriteElementString("Grant1890_3", "False");

            xmlOut.WriteElementString("address", piAdd);
            xmlOut.WriteElementString("city", piCity);
            xmlOut.WriteElementString("state", piState);
            xmlOut.WriteElementString("zip", piZip);
            xmlOut.WriteElementString("phone", piPhone);
            xmlOut.WriteElementString("fax", piFax);
            xmlOut.WriteElementString("email", piEmail);
            xmlOut.WriteElementString("statePro", piStatePro);
            xmlOut.WriteElementString("advname", advName);
            xmlOut.WriteElementString("advLName", advLName);
            xmlOut.WriteElementString("advType", advType);
            xmlOut.WriteElementString("AdvLocationState", advLocationState);
            xmlOut.WriteElementString("AdvLocationZip", advLocationZip);
            xmlOut.WriteElementString("advaff", advAff);
            xmlOut.WriteElementString("advdate", advDate);
            xmlOut.WriteElementString("advloc", advLoc);
            xmlOut.WriteElementString("advname1", advName1);
            xmlOut.WriteElementString("advLName1", advLName1);
            xmlOut.WriteElementString("advType1", advType1);
            xmlOut.WriteElementString("AdvLocationState1", advLocationState1);
            xmlOut.WriteElementString("AdvLocationZip1", advLocationZip1);
            xmlOut.WriteElementString("advaff1", advAff1);
            xmlOut.WriteElementString("advdate1", advDate1);
            xmlOut.WriteElementString("advloc1", advLoc1);
            xmlOut.WriteElementString("advname2", advName2);
            xmlOut.WriteElementString("advLName2", advLName2);
            xmlOut.WriteElementString("advType2", advType2);
            xmlOut.WriteElementString("AdvLocationState2", advLocationState2);
            xmlOut.WriteElementString("AdvLocationZip2", advLocationZip2);
            xmlOut.WriteElementString("advaff2", advAff2);
            xmlOut.WriteElementString("advdate2", advDate2);
            xmlOut.WriteElementString("advloc2", advLoc2);
            xmlOut.WriteElementString("advname3", advName3);
            xmlOut.WriteElementString("advLName3", advLName3);
            xmlOut.WriteElementString("advType3", advType3);
            xmlOut.WriteElementString("AdvLocationState3", advLocationState3);
            xmlOut.WriteElementString("AdvLocationZip3", advLocationZip3);
            xmlOut.WriteElementString("advaff3", advAff3);
            xmlOut.WriteElementString("advdate3", advDate3);
            xmlOut.WriteElementString("advloc3", advLoc3);
            xmlOut.WriteElementString("advname4", advName4);
            xmlOut.WriteElementString("advLName4", advLName4);
            xmlOut.WriteElementString("advType4", advType4);
            xmlOut.WriteElementString("AdvLocationState4", advLocationState4);
            xmlOut.WriteElementString("AdvLocationZip4", advLocationZip4);
            xmlOut.WriteElementString("advaff4", advAff4);
            xmlOut.WriteElementString("advdate4", advDate4);
            xmlOut.WriteElementString("advloc4", advLoc4);
            xmlOut.WriteElementString("advname5", advName5);
            xmlOut.WriteElementString("advLName5", advLName5);
            xmlOut.WriteElementString("advType5", advType5);
            xmlOut.WriteElementString("AdvLocationState5", advLocationState5);
            xmlOut.WriteElementString("AdvLocationZip5", advLocationZip5);
            xmlOut.WriteElementString("advaff5", advAff5);
            xmlOut.WriteElementString("advdate5", advDate5);
            xmlOut.WriteElementString("advloc5", advLoc5);
            xmlOut.WriteElementString("advname6", advName6);
            xmlOut.WriteElementString("advLName6", advLName6);
            xmlOut.WriteElementString("advType6", advType6);
            xmlOut.WriteElementString("AdvLocationState6", advLocationState6);
            xmlOut.WriteElementString("AdvLocationZip6", advLocationZip6);
            xmlOut.WriteElementString("advaff6", advAff6);
            xmlOut.WriteElementString("advdate6", advDate6);
            xmlOut.WriteElementString("advloc6", advLoc6);
            xmlOut.WriteElementString("advname7", advName7);
            xmlOut.WriteElementString("advLName7", advLName7);
            xmlOut.WriteElementString("advaff7", advAff7);
            xmlOut.WriteElementString("advname8", advName8);
            xmlOut.WriteElementString("advLName8", advLName8);
            xmlOut.WriteElementString("advaff8", advAff8);
            xmlOut.WriteElementString("advname9", advName9);
            xmlOut.WriteElementString("advLName9", advLName9);
            xmlOut.WriteElementString("advaff9", advAff9);
            xmlOut.WriteElementString("advname10", advName10);
            xmlOut.WriteElementString("advLName10", advLName10);
            xmlOut.WriteElementString("advaff10", advAff10);
            xmlOut.WriteElementString("advname11", advName11);
            xmlOut.WriteElementString("advLName11", advLName11);
            xmlOut.WriteElementString("advaff11", advAff11);
            xmlOut.WriteElementString("advname12", advName12);
            xmlOut.WriteElementString("advLName12", advLName12);
            xmlOut.WriteElementString("advaff12", advAff12);
            xmlOut.WriteElementString("advname13", advName13);
            xmlOut.WriteElementString("advLName13", advLName13);
            xmlOut.WriteElementString("advaff13", advAff13);            
            xmlOut.WriteElementString("advname14", advName14);
            xmlOut.WriteElementString("advLName14", advLName14);
            xmlOut.WriteElementString("advaff14", advAff14);
            xmlOut.WriteElementString("advname15", advName15);
            xmlOut.WriteElementString("advLName15", advLName15);
            xmlOut.WriteElementString("advaff15", advAff15);
            xmlOut.WriteElementString("sare_outreach", sare_outreach);
            xmlOut.WriteElementString("initiative_count", initiative_count.ToString());

            xmlOut.WriteEndElement();
        }     

        public void toXmlPdpInitPartners(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpInitPartners");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_init_id", pdpInitID.ToString());

            if (getPdpKeyActivityStudyByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_study_sessions", key_out_study_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_study_title1", key_out_study_title1.ToString());
                xmlOut.WriteAttributeString("key_out_study_title2", key_out_study_title2.ToString());
                xmlOut.WriteAttributeString("key_out_study_title3", key_out_study_title3.ToString());
                xmlOut.WriteAttributeString("key_out_study_title4", key_out_study_title4.ToString());
                xmlOut.WriteAttributeString("key_out_study_title5", key_out_study_title5.ToString());
                xmlOut.WriteAttributeString("key_out_study_title6", key_out_study_title6.ToString());
            }

            if (getPdpKeyActivityWorkByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_work_sessions", key_out_work_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles1", key_out_work_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles2", key_out_work_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles3", key_out_work_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles4", key_out_work_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles5", key_out_work_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_work_titles6", key_out_work_titles6.ToString());
            }

            if (getPdpKeyActivityFieldByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_field_sessions", key_out_field_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles1", key_out_field_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles2", key_out_field_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles3", key_out_field_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles4", key_out_field_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles5", key_out_field_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_field_titles6", key_out_field_titles6.ToString());
            }

            if (getPdpKeyActivityWebByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_web_sessions", key_out_web_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles1", key_out_web_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles2", key_out_web_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles3", key_out_web_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles4", key_out_web_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles5", key_out_web_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_web_titles6", key_out_web_titles6.ToString());
            }

            if (getPdpKeyActivityGrantsByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_grant_sessions", key_out_grant_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles1", key_out_grant_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles2", key_out_grant_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles3", key_out_grant_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles4", key_out_grant_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles5", key_out_grant_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_grant_titles6", key_out_grant_titles6.ToString());
            }

            if (getPdpKeyActivityTravelByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_travel_sessions", key_out_travel_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles1", key_out_travel_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles2", key_out_travel_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles3", key_out_travel_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles4", key_out_travel_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles5", key_out_travel_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles6", key_out_travel_titles6.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles7", key_out_travel_titles7.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles8", key_out_travel_titles8.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles9", key_out_travel_titles9.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles10", key_out_travel_titles10.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles11", key_out_travel_titles11.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles12", key_out_travel_titles12.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles13", key_out_travel_titles13.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles14", key_out_travel_titles14.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles15", key_out_travel_titles15.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles16", key_out_travel_titles16.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles17", key_out_travel_titles17.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles18", key_out_travel_titles18.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles19", key_out_travel_titles19.ToString());
                xmlOut.WriteAttributeString("key_out_travel_titles20", key_out_travel_titles20.ToString());
            }

            if (getPdpKeyActivityOtherByProjNum(projNum, initiative_num) == true)
            {
                xmlOut.WriteAttributeString("key_out_other_sessions", key_out_other_sessions.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles1", key_out_other_titles1.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles2", key_out_other_titles2.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles3", key_out_other_titles3.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles4", key_out_other_titles4.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles5", key_out_other_titles5.ToString());
                xmlOut.WriteAttributeString("key_out_other_titles6", key_out_other_titles6.ToString());
            }

             xmlOut.WriteElementString("init_topic", init_topic);
             xmlOut.WriteElementString("training_obj", training_obj);
             xmlOut.WriteElementString("part_ext", part_ext.ToString());
             xmlOut.WriteElementString("part_nrcs", part_nrcs.ToString());
             xmlOut.WriteElementString("part_ngo", part_ngo.ToString());
             xmlOut.WriteElementString("part_state", part_state.ToString());
             xmlOut.WriteElementString("part_farmer", part_farmer.ToString());
             xmlOut.WriteElementString("part_other", part_other.ToString());
             xmlOut.WriteElementString("train_ext", train_ext.ToString());
             xmlOut.WriteElementString("train_nrcs", train_nrcs.ToString());
             xmlOut.WriteElementString("train_ngo", train_ngo.ToString());
             xmlOut.WriteElementString("train_state", train_state.ToString());
             xmlOut.WriteElementString("train_farmer", train_farmer.ToString());
             xmlOut.WriteElementString("train_other", train_other.ToString());
             xmlOut.WriteElementString("dev_ext", dev_ext.ToString());
             xmlOut.WriteElementString("dev_nrcs", dev_nrcs.ToString());
             xmlOut.WriteElementString("dev_ngo", dev_ngo.ToString());
             xmlOut.WriteElementString("dev_state", dev_state.ToString());
             xmlOut.WriteElementString("dev_farmer", dev_farmer.ToString());
             xmlOut.WriteElementString("dev_other", dev_other.ToString());
             xmlOut.WriteElementString("inv_ext", inv_ext.ToString());
             xmlOut.WriteElementString("inv_nrcs", inv_nrcs.ToString());
             xmlOut.WriteElementString("inv_ngo", inv_nrcs.ToString());
             xmlOut.WriteElementString("inv_state", inv_nrcs.ToString());
             xmlOut.WriteElementString("inv_farmer", inv_nrcs.ToString());
             xmlOut.WriteElementString("inv_other", inv_other.ToString());
             xmlOut.WriteElementString("initiative_num", initiative_num.ToString());

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpOutNarr(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpOutNarr");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_out_id", pdp_out_id.ToString());

            xmlOut.WriteElementString("out_summary", out_summary);
            xmlOut.WriteElementString("out_desc", out_desc);
            xmlOut.WriteElementString("out_other", out_other);
            /*
            if (attachment_id > 0)
            {
                xmlOut.WriteElementString("attachment_id", attachment_id.ToString());
                xmlOut.WriteElementString("attachment_title", attachment_title);
            }
            */
            xmlOut.WriteEndElement();
        }

        public void toXmlPdpAttachments(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpAttachments");
            
            string pdpOutAttachmentSQL;
            string pdpOutAttachmentConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpOutAttachmentConnection;
            SqlCommand pdpOutAttachmentCommand;
            SqlDataReader pdpOutAttachmentDataReader;

            pdpOutAttachmentConnection = new SqlConnection(pdpOutAttachmentConnString);

            pdpOutAttachmentSQL = "DaikonPDPAttachmentListByProjNum";
            pdpOutAttachmentCommand = new SqlCommand(pdpOutAttachmentSQL, pdpOutAttachmentConnection);
            pdpOutAttachmentCommand.CommandType = CommandType.StoredProcedure;
            pdpOutAttachmentCommand.Parameters.Add("@projnum", SqlDbType.VarChar, 50);

            pdpOutAttachmentCommand.Parameters["@projnum"].Value = projNum;

            pdpOutAttachmentConnection.Open();

            using (pdpOutAttachmentDataReader = pdpOutAttachmentCommand.ExecuteReader())
            {
                while (pdpOutAttachmentDataReader.Read())
                {
                    xmlOut.WriteStartElement("list");
                    xmlOut.WriteElementString("attachment_id", pdpOutAttachmentDataReader["attachment_id"].ToString());
                    xmlOut.WriteElementString("attachment_title", pdpOutAttachmentDataReader["attachment_title"].ToString());
                    xmlOut.WriteElementString("attachment_caption", pdpOutAttachmentDataReader["attachment_caption"].ToString());
                    xmlOut.WriteEndElement();
                }

            }

            pdpOutAttachmentConnection.Dispose();


            xmlOut.WriteEndElement();
        }

        public string ProjectNum
        {
            get { return projNum; }
            set { projNum = value; }
        }

        public string PiFirstName
        {
            get { return piFName; }
            set { piFName = value; }
        }

        public string PiLasttName
        {
            get { return piLName; }
            set { piLName = value; }
        }

        public string PiInstituteName
        {
            get { return piInstName; }
            set { piInstName = value; }
        }

        public string PiInstituteName2
        {
            get { return piInstName2; }
            set { piInstName2 = value; }
        }

        public string PiInstituteName3
        {
            get { return piInstName3; }
            set { piInstName3 = value; }
        }


        public string PiAddress
        {
            get { return piAdd; }
            set { piAdd = value; }
        }

        public string PiCity
        {
            get { return piCity; }
            set { piCity = value; }
        }

        public string PiState
        {
            get { return piState; }
            set { piState = value; }
        }

        public string PiZip
        {
            get { return piZip; }
            set { piZip = value; }
        }

        public string PiPhone
        {
            get { return piPhone; }
            set { piPhone = value; }
        }

        public string PiFax
        {
            get { return piFax; }
            set { piFax = value; }            
        }

        public string PiEmail
        {
            get { return piEmail; }
            set { piEmail = value; }
        }

        public string PiStatePro
        {
            get { return piStatePro; }
            set { piStatePro = value; }
        }

        public string AdvisoryName
        {
            get { return advName; }
            set { advName = value; }
        }

        public string AdvisoryLName
        {
            get { return advLName; }
            set { advLName = value; }
        }

        public string AdvisoryType
        {
            get { return advType; }
            set { advType = value; }
        }

        public string AdvisoryState
        {
            get { return advLocationState; }
            set { advLocationState = value; }
        }

        public string AdvisoryZip
        {
            get { return advLocationZip; }
            set { advLocationZip = value; }
        }

        public string AdvisoryAff
        {
            get { return advAff; }
            set { advAff = value; }
        }

        public string AdvisoryDate
        {
            get { return advDate; }
            set { advDate = value; }
        }

        public string AdvisoryLocation
        {
            get { return advLoc; }
            set { advLoc = value; }
        }

        public string AdvisoryName1
        {
            get { return advName1; }
            set { advName1 = value; }
        }

        public string AdvisoryLName1
        {
            get { return advLName1; }
            set { advLName1 = value; }
        }

        public string AdvisoryType1
        {
            get { return advType1; }
            set { advType1 = value; }
        }

        public string AdvisoryState1
        {
            get { return advLocationState1; }
            set { advLocationState1 = value; }
        }

        public string AdvisoryZip1
        {
            get { return advLocationZip1; }
            set { advLocationZip1 = value; }
        }

        public string AdvisoryAff1
        {
            get { return advAff1; }
            set { advAff1 = value; }
        }

        public string AdvisoryDate1
        {
            get { return advDate1; }
            set { advDate1 = value; }
        }

        public string AdvisoryLocation1
        {
            get { return advLoc1; }
            set { advLoc1 = value; }
        }

        public string AdvisoryName2
        {
            get { return advName2; }
            set { advName2 = value; }
        }

        public string AdvisoryLName2
        {
            get { return advLName2; }
            set { advLName2 = value; }
        }

        public string AdvisoryType2
        {
            get { return advType2; }
            set { advType2 = value; }
        }

        public string AdvisoryState2
        {
            get { return advLocationState2; }
            set { advLocationState2 = value; }
        }

        public string AdvisoryZip2
        {
            get { return advLocationZip2; }
            set { advLocationZip2 = value; }
        }

        public string AdvisoryAff2
        {
            get { return advAff2; }
            set { advAff2 = value; }
        }

        public string AdvisoryDate2
        {
            get { return advDate2; }
            set { advDate2 = value; }
        }

        public string AdvisoryLocation2
        {
            get { return advLoc2; }
            set { advLoc2 = value; }
        }

        public string AdvisoryName3
        {
            get { return advName3; }
            set { advName3 = value; }
        }

        public string AdvisoryLName3
        {
            get { return advLName3; }
            set { advLName3 = value; }
        }

        public string AdvisoryType3
        {
            get { return advType3; }
            set { advType3 = value; }
        }

        public string AdvisoryState3
        {
            get { return advLocationState3; }
            set { advLocationState3 = value; }
        }

        public string AdvisoryZip3
        {
            get { return advLocationZip3; }
            set { advLocationZip3 = value; }
        }

        public string AdvisoryAff3
        {
            get { return advAff3; }
            set { advAff3 = value; }
        }

        public string AdvisoryDate3
        {
            get { return advDate3; }
            set { advDate3 = value; }
        }

        public string AdvisoryLocation3
        {
            get { return advLoc3; }
            set { advLoc3 = value; }
        }

        public string AdvisoryName4
        {
            get { return advName4; }
            set { advName4 = value; }
        }

        public string AdvisoryLName4
        {
            get { return advLName4; }
            set { advLName4 = value; }
        }

        public string AdvisoryType4
        {
            get { return advType4; }
            set { advType4 = value; }
        }

        public string AdvisoryState4
        {
            get { return advLocationState4; }
            set { advLocationState4 = value; }
        }

        public string AdvisoryZip4
        {
            get { return advLocationZip4; }
            set { advLocationZip4 = value; }
        }

        public string AdvisoryAff4
        {
            get { return advAff4; }
            set { advAff4 = value; }
        }

        public string AdvisoryDate4
        {
            get { return advDate4; }
            set { advDate4 = value; }
        }

        public string AdvisoryLocation4
        {
            get { return advLoc4; }
            set { advLoc4 = value; }
        }

        public string AdvisoryName5
        {
            get { return advName5; }
            set { advName5 = value; }
        }

        public string AdvisoryLName5
        {
            get { return advLName5; }
            set { advLName5 = value; }
        }
        
        public string AdvisoryType5
        {
            get { return advType5; }
            set { advType5 = value; }
        }

        public string AdvisoryState5
        {
            get { return advLocationState5; }
            set { advLocationState5 = value; }
        }

        public string AdvisoryZip5
        {
            get { return advLocationZip5; }
            set { advLocationZip5 = value; }
        }

        public string AdvisoryAff5
        {
            get { return advAff5; }
            set { advAff5 = value; }
        }

        public string AdvisoryDate5
        {
            get { return advDate5; }
            set { advDate5 = value; }
        }

        public string AdvisoryLocation5
        {
            get { return advLoc5; }
            set { advLoc5 = value; }
        }

        public string AdvisoryName6
        {
            get { return advName6; }
            set { advName6 = value; }
        }

        public string AdvisoryLName6
        {
            get { return advLName6; }
            set { advLName6 = value; }
        }

        public string AdvisoryType6
        {
            get { return advType6; }
            set { advType6 = value; }
        }

        public string AdvisoryState6
        {
            get { return advLocationState6; }
            set { advLocationState6 = value; }
        }

        public string AdvisoryZip6
        {
            get { return advLocationZip6; }
            set { advLocationZip6 = value; }
        }

        public string AdvisoryAff6
        {
            get { return advAff6; }
            set { advAff6 = value; }
        }

        public string AdvisoryDate6
        {
            get { return advDate6; }
            set { advDate6 = value; }
        }

        public string AdvisoryLocation6
        {
            get { return advLoc6; }
            set { advLoc6 = value; }
        }

        public string AdvisoryName7
        {
            get { return advName7; }
            set { advName7 = value; }
        }

        public string AdvisoryLName7
        {
            get { return advLName7; }
            set { advLName7 = value; }
        }

        public string AdvisoryAff7
        {
            get { return advAff7; }
            set { advAff7 = value; }
        }

        public string AdvisoryName8
        {
            get { return advName8; }
            set { advName8 = value; }
        }

        public string AdvisoryLName8
        {
            get { return advLName8; }
            set { advLName8 = value; }
        }

        public string AdvisoryAff8
        {
            get { return advAff8; }
            set { advAff8 = value; }
        }

        public string AdvisoryName9
        {
            get { return advName9; }
            set { advName9 = value; }
        }

        public string AdvisoryLName9
        {
            get { return advLName9; }
            set { advLName9 = value; }
        }

        public string AdvisoryAff9
        {
            get { return advAff9; }
            set { advAff9 = value; }
        }

        public string AdvisoryName10
        {
            get { return advName10; }
            set { advName10 = value; }
        }

        public string AdvisoryLName10
        {
            get { return advLName10; }
            set { advLName10 = value; }
        }

        public string AdvisoryAff10
        {
            get { return advAff10; }
            set { advAff10 = value; }
        }

        public string AdvisoryName11
        {
            get { return advName11; }
            set { advName11 = value; }
        }

        public string AdvisoryLName11
        {
            get { return advLName11; }
            set { advLName11 = value; }
        }

        public string AdvisoryAff11
        {
            get { return advAff11; }
            set { advAff11 = value; }
        }

        public string AdvisoryName12
        {
            get { return advName12; }
            set { advName12 = value; }
        }

        public string AdvisoryLName12
        {
            get { return advLName12; }
            set { advLName12 = value; }
        }

        public string AdvisoryAff12
        {
            get { return advAff12; }
            set { advAff12 = value; }
        }

        public string AdvisoryName13
        {
            get { return advName13; }
            set { advName13 = value; }
        }

        public string AdvisoryLName13
        {
            get { return advLName13; }
            set { advLName13 = value; }
        }

        public string AdvisoryAff13
        {
            get { return advAff13; }
            set { advAff13 = value; }
        }

        public string AdvisoryName14
        {
            get { return advName14; }
            set { advName14 = value; }
        }

        public string AdvisoryLName14
        {
            get { return advLName14; }
            set { advLName14 = value; }
        }

        public string AdvisoryAff14
        {
            get { return advAff14; }
            set { advAff14 = value; }
        }

        public string AdvisoryName15
        {
            get { return advName15; }
            set { advName15 = value; }
        }

        public string AdvisoryLName15
        {
            get { return advLName15; }
            set { advLName15 = value; }
        }

        public string AdvisoryAff15
        {
            get { return advAff15; }
            set { advAff15 = value; }
        }  
     
        public int PiInstituteType
        {
            get { return piInstType; }
            set { piInstType = value; }
        }

        public int PiRace
        {
            get { return piRace; }
            set { piRace = value; }
        }

        public string PiEthinicity
        {
            get { return piEthinicity; }
            set { piEthinicity = value; }
        }

        public int PiInstituteType2
        {
            get { return piInstType2; }
            set { piInstType2 = value; }
        }

        public int PiRace2
        {
            get { return piRace2; }
            set { piRace2 = value; }
        }

        public string PiEthinicity2
        {
            get { return piEthinicity2; }
            set { piEthinicity2 = value; }
        }

        public int PiInstituteType3
        {
            get { return piInstType3; }
            set { piInstType3 = value; }
        }

        public int PiRace3
        {
            get { return piRace3; }
            set { piRace3 = value; }
        }

        public string PiEthinicity3
        {
            get { return piEthinicity3; }
            set { piEthinicity3 = value; }
        }


        public int InitiativeCount
        {
            get { return initiative_count; }
            set { initiative_count = value; }
        }

        public string SareOutreach
        {
            get { return sare_outreach; }
            set { sare_outreach = value;}
        }

        public string InitTopic
        {
            get { return init_topic; }
            set { init_topic = value; }
        }

        public string TrainingObj
        {
            get { return training_obj; }
            set { training_obj = value; }
        }

        public int PartExt
        {
            get { return part_ext; }
            set { part_ext = value; }
        }

        public int PartNRCS
        {
            get { return part_nrcs; }
            set { part_nrcs = value; }
        }

        public int PartNGO
        {
            get { return part_ngo; }
            set { part_ngo = value; }
        }

        public int PartState
        {
            get { return part_state; }
            set { part_state = value; }
        }

        public int PartFarmer
        {
            get { return part_farmer; }
            set { part_farmer = value; }
        }

        public int PartOther
        {
            get { return part_other; }
            set { part_other = value; }
        }

        public int TrainExt
        {
            get { return train_ext; }
            set { train_ext = value; }
        }

        public int TrainNRCS
        {
            get { return train_nrcs; }
            set { train_nrcs = value; }
        }

        public int TrainNGO
        {
            get { return train_ngo; }
            set { train_ngo = value; }
        }

        public int TrainState
        {
            get { return train_state; }
            set { train_state = value; }
        }

        public int TrainFarmer
        {
            get { return train_farmer; }
            set { train_farmer = value; }
        }

        public int TrainOther
        {
            get { return train_other; }
            set { train_other = value; }
        }

        public int DevExt
        {
            get { return dev_ext; }
            set { dev_ext = value; }
        }

        public int DevNRCS
        {
            get { return dev_nrcs; }
            set { dev_nrcs = value; }
        }

        public int DevNGO
        {
            get { return dev_ngo; }
            set { dev_ngo = value; }
        }

        public int DevState
        {
            get { return dev_state; }
            set { dev_state = value; }
        }

        public int DevFarmer
        {
            get { return dev_farmer; }
            set { dev_farmer = value; }
        }

        public int DevOther
        {
            get { return dev_other; }
            set { dev_other = value; }
        }

        public int InvExt
        {
            get { return inv_ext; }
            set { inv_ext = value; }
        }

        public int InvNRCS
        {
            get { return inv_nrcs; }
            set { inv_nrcs = value; }
        }

        public int InvNGO
        {
            get { return inv_ngo; }
            set { inv_ngo = value; }
        }

        public int InvState
        {
            get { return inv_state; }
            set { inv_state = value; }
        }

        public int InvFarmer
        {
            get { return inv_farmer; }
            set { inv_farmer = value; }
        }

        public int InvOther
        {
            get { return inv_other; }
            set { inv_other = value; }
        }

        public int InitiativeNum
        {
            get { return initiative_num; }
            set { initiative_num = value; }
        }

        public string OutSummary
        {
            get { return out_summary; }
            set { out_summary = value; }
        }

        public string OutDesc
        {
            get { return out_desc; }
            set { out_desc = value; }
        }

        public string OutOther
        {
            get { return out_other; }
            set { out_other = value; }
        }

    }

}
