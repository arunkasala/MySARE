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
    public class PDPKeyOut
    {
        //initiative number
        protected int pdp_initiative_num = 0;

        // PDP Key Outcome & Activities Study 
        protected int pdp_key_studyID = 0;
        protected string projNum = "";
        protected int study_session = 0;
        protected string study_start_date = "";
        protected string study_end_date = "";
        protected int study_ext = 0;
        protected int study_nrcs = 0;
        protected int study_ngo = 0;
        protected int study_st = 0;
        protected int study_pro = 0;
        protected int study_farm = 0;
        protected string study_att_desc = "";
        protected string study_att_other = "";
        protected string study_loc = "";
        protected string study_state = "";
        protected string study_zip = "";
        protected int study_media = 0;
        protected int study_client = 0;
        protected int study_devel = 0;
        protected int study_incorp = 0;
        protected int study_prog = 0;
        protected int study_consult = 0;
        protected int study_farmers = 0;
        protected string study_out_other = "";
        protected string study_out_desc = "";
        protected string study_title = "";
        protected string study_description = "";

        // PDP Key Outcome & Activities Web
        protected int pdp_key_WebID = 0;

        // PDP Key Travel
        protected int pdp_key_TravelID = 0;
        protected string travel_desc = "";
        protected string travel_individual1 = "";
        protected string travel_individual2 = "";
        protected string travel_individual3 = "";
        protected string travel_individual4 = "";
        protected string travel_individual5 = "";
        protected string travel_individual6 = "";
        protected string travel_individual7 = "";
        protected string travel_individual8 = "";
        protected string travel_individual9 = "";
        protected string travel_individual10 = "";
        protected string travel_individual11 = "";
        protected string travel_individual12 = "";
        protected string travel_individual_other = "";

        // PDP Key Other
        protected int pdp_key_OtherID = 0;
        protected string other_desc = "";

        // PDP Key Multi
        protected int pdp_key_workID = 0;
       
        protected int short_session = 0;
        protected string short_start_date = "";
        protected string short_end_date = "";
        protected int short_ext = 0;
        protected int short_nrcs = 0;
        protected int short_ngo = 0;
        protected int short_st = 0;
        protected int short_pro = 0;
        protected int short_farm = 0;
        protected string short_att_desc = "";
        protected string short_att_other = "";
        protected string short_loc = "";
        protected string short_state = "";
        protected string short_zip = "";
        protected int short_media = 0;
        protected int short_client = 0;
        protected int short_devel = 0;
        protected int short_incorp = 0;
        protected int short_prog = 0;
        protected int short_consult = 0;
        protected int short_farmers = 0;
        protected string short_out_other = "";
        protected string short_out_desc = "";
        protected string short_title = "";
        protected string short_description = "";

        protected int inter_session = 0;
        protected string inter_start_date = "";
        protected string inter_end_date = "";
        protected int inter_ext = 0;
        protected int inter_nrcs = 0;
        protected int inter_ngo = 0;
        protected int inter_st = 0;
        protected int inter_pro = 0;
        protected int inter_farm = 0;
        protected string inter_att_desc = "";
        protected string inter_att_other = "";
        protected string inter_loc = "";
        protected string inter_state = "";
        protected string inter_zip = "";
        protected int inter_media = 0;
        protected int inter_client = 0;
        protected int inter_devel = 0;
        protected int inter_incorp = 0;
        protected int inter_prog = 0;
        protected int inter_consult = 0;
        protected int inter_farmers = 0;
        protected string inter_out_other = "";
        protected string inter_out_desc = "";
        protected string inter_title = "";
        protected string inter_description = "";

        protected int multi_session = 0;
        protected string multi_start_date = "";
        protected string multi_end_date = "";
        protected int multi_ext = 0;
        protected int multi_nrcs = 0;
        protected int multi_ngo = 0;
        protected int multi_st = 0;
        protected int multi_pro = 0;
        protected int multi_farm = 0;
        protected string multi_att_desc = "";
        protected string multi_att_other = "";
        protected string multi_loc = "";
        protected string multi_state = "";
        protected string multi_zip = "";
        protected int multi_media = 0;
        protected int multi_client = 0;
        protected int multi_devel = 0;
        protected int multi_incorp = 0;
        protected int multi_prog = 0;
        protected int multi_consult = 0;
        protected int multi_farmers = 0;
        protected string multi_out_other = "";
        protected string multi_out_desc = "";
        protected string multi_title = "";
        protected string multi_description = "";

        // PDP Key Field
        protected int pdp_key_fieldID = 0;

        // PDP Key Field
        protected int pdp_key_grantID = 0;

        public PDPKeyOut()
        {
            projNum = "";
            study_session = 0;
            study_start_date = "";
            study_end_date = "";
            study_ext = 0;
            study_nrcs = 0;
            study_ngo = 0;
            study_st = 0;
            study_pro = 0;
            study_farm = 0;
            study_att_desc = "";
            study_att_other = "";
            study_loc = "";
            study_state = "";
            study_media = 0;
            study_client = 0;
            study_devel = 0;
            study_incorp = 0;
            study_prog = 0;
            study_consult = 0;
            study_farmers = 0;
            study_out_other = "";
            study_out_desc = "";

            // PDP Key Travel
            travel_desc = "";
            travel_individual1 = "";
            travel_individual2 = "";
            travel_individual3 = "";
            travel_individual4 = "";
            travel_individual5 = "";
            travel_individual6 = "";
            travel_individual7 = "";
            travel_individual8 = "";
            travel_individual9 = "";
            travel_individual10 = "";
            travel_individual11 = "";
            travel_individual12 = "";
            travel_individual_other = "";

            //PDP Key Other
            other_desc = "";

        }

        public int SaveNewPDPKeyOutStudyToDB()
        {
            string pdpKeyOutStudySQL;
            string pdpKeyOutStudyConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutStudyConnection;
            SqlCommand pdpKeyOutStudyCommand;

            pdpKeyOutStudyConnection = new SqlConnection(pdpKeyOutStudyConnString);

            pdpKeyOutStudySQL = "DaikonPDPKeyOutStudyCreate";
            pdpKeyOutStudyCommand = new SqlCommand(pdpKeyOutStudySQL, pdpKeyOutStudyConnection);
            pdpKeyOutStudyCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutStudyCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutStudyCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_session", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_title", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_start_date", SqlDbType.Date);
            pdpKeyOutStudyCommand.Parameters.Add("@study_end_date", SqlDbType.Date);
            pdpKeyOutStudyCommand.Parameters.Add("@study_ext", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_nrcs", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_ngo", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_st", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_pro", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_farm", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_att_desc", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_att_other", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_loc", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_state", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_zip", SqlDbType.VarChar, 5);
            pdpKeyOutStudyCommand.Parameters.Add("@study_media", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_client", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_devel", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_incorp", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_prog", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_consult", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_farmers", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_out_other", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_out_desc", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_description", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add(keyOutput);

            pdpKeyOutStudyCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutStudyCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutStudyCommand.Parameters["@study_title"].Value = study_title;
            pdpKeyOutStudyCommand.Parameters["@study_session"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutStudyCommand.Parameters["@study_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutStudyCommand.Parameters["@study_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutStudyCommand.Parameters["@study_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutStudyCommand.Parameters["@study_end_date"].Value = null;
            pdpKeyOutStudyCommand.Parameters["@study_ext"].Value = study_ext;
            pdpKeyOutStudyCommand.Parameters["@study_nrcs"].Value = study_nrcs;
            pdpKeyOutStudyCommand.Parameters["@study_ngo"].Value = study_ngo;
            pdpKeyOutStudyCommand.Parameters["@study_st"].Value = study_st;
            pdpKeyOutStudyCommand.Parameters["@study_pro"].Value = study_pro;
            pdpKeyOutStudyCommand.Parameters["@study_farm"].Value = study_farm;
            pdpKeyOutStudyCommand.Parameters["@study_att_desc"].Value = study_att_desc;
            pdpKeyOutStudyCommand.Parameters["@study_att_other"].Value = study_att_other;
            pdpKeyOutStudyCommand.Parameters["@study_loc"].Value = study_loc;
            pdpKeyOutStudyCommand.Parameters["@study_state"].Value = study_state;
            pdpKeyOutStudyCommand.Parameters["@study_zip"].Value = study_zip;
            pdpKeyOutStudyCommand.Parameters["@study_media"].Value = study_media;
            pdpKeyOutStudyCommand.Parameters["@study_client"].Value = study_client;
            pdpKeyOutStudyCommand.Parameters["@study_devel"].Value = study_devel;
            pdpKeyOutStudyCommand.Parameters["@study_incorp"].Value = study_incorp;
            pdpKeyOutStudyCommand.Parameters["@study_prog"].Value = study_prog;
            pdpKeyOutStudyCommand.Parameters["@study_consult"].Value = study_consult;
            pdpKeyOutStudyCommand.Parameters["@study_farmers"].Value = study_farmers;
            pdpKeyOutStudyCommand.Parameters["@study_out_other"].Value = study_out_other;
            pdpKeyOutStudyCommand.Parameters["@study_out_desc"].Value = study_out_desc;
            pdpKeyOutStudyCommand.Parameters["@study_description"].Value = study_description;

            pdpKeyOutStudyConnection.Open();
            pdpKeyOutStudyCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutStudyConnection.Close();
            pdpKeyOutStudyCommand.Dispose();
            pdpKeyOutStudyConnection.Dispose();

            return key;
        }

        public int SaveNewPDPKeyOutTravelToDB()
        {
            string pdpKeyOutTravelSQL;
            string pdpKeyOutTravelConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutTravelConnection;
            SqlCommand pdpKeyOutTravelCommand;

            pdpKeyOutTravelConnection = new SqlConnection(pdpKeyOutTravelConnString);

            pdpKeyOutTravelSQL = "DaikonPDPKeyOutTravelCreate";
            pdpKeyOutTravelCommand = new SqlCommand(pdpKeyOutTravelSQL, pdpKeyOutTravelConnection);
            pdpKeyOutTravelCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutTravelCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutTravelCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_title", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_desc", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_scholarship", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual1", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual2", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual3", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual4", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual5", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual6", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual7", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual8", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual9", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual10", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual11", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual12", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual_other", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_start_date", SqlDbType.Date);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_end_date", SqlDbType.Date);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_ext", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_nrcs", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_ngo", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_st", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_pro", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_farm", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_reci_desc", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_other", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_loc", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_state", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_zip", SqlDbType.VarChar, 5);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_media", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_client", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_devel", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_incorp", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_prog", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_consult", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_farmers", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_out_other", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_out_desc", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add(keyOutput);

            pdpKeyOutTravelCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutTravelCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutTravelCommand.Parameters["@travel_title"].Value = study_title;
            pdpKeyOutTravelCommand.Parameters["@travel_desc"].Value = travel_desc;
            pdpKeyOutTravelCommand.Parameters["@travel_scholarship"].Value = study_session;
            pdpKeyOutTravelCommand.Parameters["@travel_individual1"].Value = travel_individual1;
            pdpKeyOutTravelCommand.Parameters["@travel_individual2"].Value = travel_individual2;
            pdpKeyOutTravelCommand.Parameters["@travel_individual3"].Value = travel_individual3;
            pdpKeyOutTravelCommand.Parameters["@travel_individual4"].Value = travel_individual4;
            pdpKeyOutTravelCommand.Parameters["@travel_individual5"].Value = travel_individual5;
            pdpKeyOutTravelCommand.Parameters["@travel_individual6"].Value = travel_individual6;
            pdpKeyOutTravelCommand.Parameters["@travel_individual7"].Value = travel_individual7;
            pdpKeyOutTravelCommand.Parameters["@travel_individual8"].Value = travel_individual8;
            pdpKeyOutTravelCommand.Parameters["@travel_individual9"].Value = travel_individual9;
            pdpKeyOutTravelCommand.Parameters["@travel_individual10"].Value = travel_individual10;
            pdpKeyOutTravelCommand.Parameters["@travel_individual11"].Value = travel_individual11;
            pdpKeyOutTravelCommand.Parameters["@travel_individual12"].Value = travel_individual12;
            pdpKeyOutTravelCommand.Parameters["@travel_individual_other"].Value = travel_individual_other;
            if (study_start_date != "")
                pdpKeyOutTravelCommand.Parameters["@travel_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutTravelCommand.Parameters["@travel_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutTravelCommand.Parameters["@travel_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutTravelCommand.Parameters["@travel_end_date"].Value = null;
            pdpKeyOutTravelCommand.Parameters["@travel_ext"].Value = study_ext;
            pdpKeyOutTravelCommand.Parameters["@travel_nrcs"].Value = study_nrcs;
            pdpKeyOutTravelCommand.Parameters["@travel_ngo"].Value = study_ngo;
            pdpKeyOutTravelCommand.Parameters["@travel_st"].Value = study_st;
            pdpKeyOutTravelCommand.Parameters["@travel_pro"].Value = study_pro;
            pdpKeyOutTravelCommand.Parameters["@travel_farm"].Value = study_farm;
            pdpKeyOutTravelCommand.Parameters["@travel_reci_desc"].Value = study_att_desc;
            pdpKeyOutTravelCommand.Parameters["@travel_other"].Value = study_att_other;
            pdpKeyOutTravelCommand.Parameters["@travel_loc"].Value = study_loc;
            pdpKeyOutTravelCommand.Parameters["@travel_state"].Value = study_state;
            pdpKeyOutTravelCommand.Parameters["@travel_zip"].Value = study_zip;
            pdpKeyOutTravelCommand.Parameters["@travel_media"].Value = study_media;
            pdpKeyOutTravelCommand.Parameters["@travel_client"].Value = study_client;
            pdpKeyOutTravelCommand.Parameters["@travel_devel"].Value = study_devel;
            pdpKeyOutTravelCommand.Parameters["@travel_incorp"].Value = study_incorp;
            pdpKeyOutTravelCommand.Parameters["@travel_prog"].Value = study_prog;
            pdpKeyOutTravelCommand.Parameters["@travel_consult"].Value = study_consult;
            pdpKeyOutTravelCommand.Parameters["@travel_farmers"].Value = study_farmers;
            pdpKeyOutTravelCommand.Parameters["@travel_out_other"].Value = study_out_other;
            pdpKeyOutTravelCommand.Parameters["@travel_out_desc"].Value = study_out_desc;

            pdpKeyOutTravelConnection.Open();
            pdpKeyOutTravelCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutTravelConnection.Close();
            pdpKeyOutTravelCommand.Dispose();
            pdpKeyOutTravelConnection.Dispose();

            return key;
        }

        public int SaveNewPDPKeyOutOtherToDB()
        {
            string pdpKeyOutOtherSQL;
            string pdpKeyOutOtherConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutOtherConnection;
            SqlCommand pdpKeyOutOtherCommand;

            pdpKeyOutOtherConnection = new SqlConnection(pdpKeyOutOtherConnString);

            pdpKeyOutOtherSQL = "DaikonpdpKeyOutOtherCreate";
            pdpKeyOutOtherCommand = new SqlCommand(pdpKeyOutOtherSQL, pdpKeyOutOtherConnection);
            pdpKeyOutOtherCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutOtherCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutOtherCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_title", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_desc", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_start_date", SqlDbType.Date);
            pdpKeyOutOtherCommand.Parameters.Add("@other_end_date", SqlDbType.Date);
            pdpKeyOutOtherCommand.Parameters.Add("@other_num", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_ext", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_nrcs", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_ngo", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_st", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_pro", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_farm", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_reci_desc", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_other", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_loc", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_state", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_zip", SqlDbType.VarChar, 5);
            pdpKeyOutOtherCommand.Parameters.Add("@other_media", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_client", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_devel", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_incorp", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_prog", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_consult", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_farmers", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_out_other", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_out_desc", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add(keyOutput);

            pdpKeyOutOtherCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutOtherCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutOtherCommand.Parameters["@other_title"].Value = study_title;
            pdpKeyOutOtherCommand.Parameters["@other_desc"].Value = other_desc;
            pdpKeyOutOtherCommand.Parameters["@other_num"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutOtherCommand.Parameters["@other_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutOtherCommand.Parameters["@other_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutOtherCommand.Parameters["@other_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutOtherCommand.Parameters["@other_end_date"].Value = null;
            pdpKeyOutOtherCommand.Parameters["@other_ext"].Value = study_ext;
            pdpKeyOutOtherCommand.Parameters["@other_nrcs"].Value = study_nrcs;
            pdpKeyOutOtherCommand.Parameters["@other_ngo"].Value = study_ngo;
            pdpKeyOutOtherCommand.Parameters["@other_st"].Value = study_st;
            pdpKeyOutOtherCommand.Parameters["@other_pro"].Value = study_pro;
            pdpKeyOutOtherCommand.Parameters["@other_farm"].Value = study_farm;
            pdpKeyOutOtherCommand.Parameters["@other_reci_desc"].Value = study_att_desc;
            pdpKeyOutOtherCommand.Parameters["@other_other"].Value = study_att_other;
            pdpKeyOutOtherCommand.Parameters["@other_loc"].Value = study_loc;
            pdpKeyOutOtherCommand.Parameters["@other_state"].Value = study_state;
            pdpKeyOutOtherCommand.Parameters["@other_zip"].Value = study_zip;
            pdpKeyOutOtherCommand.Parameters["@other_media"].Value = study_media;
            pdpKeyOutOtherCommand.Parameters["@other_client"].Value = study_client;
            pdpKeyOutOtherCommand.Parameters["@other_devel"].Value = study_devel;
            pdpKeyOutOtherCommand.Parameters["@other_incorp"].Value = study_incorp;
            pdpKeyOutOtherCommand.Parameters["@other_prog"].Value = study_prog;
            pdpKeyOutOtherCommand.Parameters["@other_consult"].Value = study_consult;
            pdpKeyOutOtherCommand.Parameters["@other_farmers"].Value = study_farmers;
            pdpKeyOutOtherCommand.Parameters["@other_out_other"].Value = study_out_other;
            pdpKeyOutOtherCommand.Parameters["@other_out_desc"].Value = study_out_desc;

            pdpKeyOutOtherConnection.Open();
            pdpKeyOutOtherCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutOtherConnection.Close();
            pdpKeyOutOtherCommand.Dispose();
            pdpKeyOutOtherConnection.Dispose();

            return key;
        }

        public int SaveNewPDPKeyOutWebToDB()
        {
            string pdpKeyOutWebSQL;
            string pdpKeyOutWebConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWebConnection;
            SqlCommand pdpKeyOutWebCommand;

            pdpKeyOutWebConnection = new SqlConnection(pdpKeyOutWebConnString);

            pdpKeyOutWebSQL = "DaikonPDPKeyOutWebCreate";
            pdpKeyOutWebCommand = new SqlCommand(pdpKeyOutWebSQL, pdpKeyOutWebConnection);
            pdpKeyOutWebCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutWebCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutWebCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_curricula", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@web_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@web_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@web_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_description", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_description", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_description", SqlDbType.NText);

            pdpKeyOutWebCommand.Parameters.Add(keyOutput);

            pdpKeyOutWebCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutWebCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutWebCommand.Parameters["@web_curricula"].Value = study_session;
            pdpKeyOutWebCommand.Parameters["@web_title"].Value = study_title;
            if (study_start_date != "")
                pdpKeyOutWebCommand.Parameters["@web_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@web_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutWebCommand.Parameters["@web_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@web_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@web_ext"].Value = study_ext;
            pdpKeyOutWebCommand.Parameters["@web_nrcs"].Value = study_nrcs;
            pdpKeyOutWebCommand.Parameters["@web_ngo"].Value = study_ngo;
            pdpKeyOutWebCommand.Parameters["@web_st"].Value = study_st;
            pdpKeyOutWebCommand.Parameters["@web_pro"].Value = study_pro;
            pdpKeyOutWebCommand.Parameters["@web_farm"].Value = study_farm;
            pdpKeyOutWebCommand.Parameters["@web_att_desc"].Value = study_att_desc;
            pdpKeyOutWebCommand.Parameters["@web_att_other"].Value = study_att_other;
            pdpKeyOutWebCommand.Parameters["@web_media"].Value = study_media;
            pdpKeyOutWebCommand.Parameters["@web_client"].Value = study_client;
            pdpKeyOutWebCommand.Parameters["@web_devel"].Value = study_devel;
            pdpKeyOutWebCommand.Parameters["@web_incorp"].Value = study_incorp;
            pdpKeyOutWebCommand.Parameters["@web_prog"].Value = study_prog;
            pdpKeyOutWebCommand.Parameters["@web_consult"].Value = study_consult;
            pdpKeyOutWebCommand.Parameters["@web_farmers"].Value = study_farmers;
            pdpKeyOutWebCommand.Parameters["@web_out_other"].Value = study_out_other;
            pdpKeyOutWebCommand.Parameters["@web_out_desc"].Value = study_out_other;
            pdpKeyOutWebCommand.Parameters["@web_description"].Value = study_description;

            pdpKeyOutWebCommand.Parameters["@webseries_title"].Value = short_title;
            if (short_start_date != "")
                pdpKeyOutWebCommand.Parameters["@webseries_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@webseries_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutWebCommand.Parameters["@webseries_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@webseries_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@webseries_ext"].Value = short_ext;
            pdpKeyOutWebCommand.Parameters["@webseries_nrcs"].Value = short_nrcs;
            pdpKeyOutWebCommand.Parameters["@webseries_ngo"].Value = short_ngo;
            pdpKeyOutWebCommand.Parameters["@webseries_st"].Value = short_st;
            pdpKeyOutWebCommand.Parameters["@webseries_pro"].Value = short_pro;
            pdpKeyOutWebCommand.Parameters["@webseries_farm"].Value = short_farm;
            pdpKeyOutWebCommand.Parameters["@webseries_att_desc"].Value = short_att_desc;
            pdpKeyOutWebCommand.Parameters["@webseries_att_other"].Value = short_att_other;
            pdpKeyOutWebCommand.Parameters["@webseries_media"].Value = short_media;
            pdpKeyOutWebCommand.Parameters["@webseries_client"].Value = short_client;
            pdpKeyOutWebCommand.Parameters["@webseries_devel"].Value = short_devel;
            pdpKeyOutWebCommand.Parameters["@webseries_incorp"].Value = short_incorp;
            pdpKeyOutWebCommand.Parameters["@webseries_prog"].Value = short_prog;
            pdpKeyOutWebCommand.Parameters["@webseries_consult"].Value = short_consult;
            pdpKeyOutWebCommand.Parameters["@webseries_farmers"].Value = short_farmers;
            pdpKeyOutWebCommand.Parameters["@webseries_out_other"].Value = short_out_other;
            pdpKeyOutWebCommand.Parameters["@webseries_out_desc"].Value = short_out_desc;
            pdpKeyOutWebCommand.Parameters["@webseries_description"].Value = short_description;

            pdpKeyOutWebCommand.Parameters["@webcur_title"].Value = "";//inter_title;
            if (inter_start_date != "")
                pdpKeyOutWebCommand.Parameters["@webcur_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@webcur_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutWebCommand.Parameters["@webcur_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@webcur_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@webcur_ext"].Value = inter_ext;
            pdpKeyOutWebCommand.Parameters["@webcur_nrcs"].Value = inter_nrcs;
            pdpKeyOutWebCommand.Parameters["@webcur_ngo"].Value = inter_ngo;
            pdpKeyOutWebCommand.Parameters["@webcur_st"].Value = inter_st;
            pdpKeyOutWebCommand.Parameters["@webcur_pro"].Value = inter_pro;
            pdpKeyOutWebCommand.Parameters["@webcur_farm"].Value = inter_farm;
            pdpKeyOutWebCommand.Parameters["@webcur_att_desc"].Value = ""; //inter_att_desc;
            pdpKeyOutWebCommand.Parameters["@webcur_att_other"].Value = ""; //inter_att_other;
            pdpKeyOutWebCommand.Parameters["@webcur_media"].Value = inter_media;
            pdpKeyOutWebCommand.Parameters["@webcur_client"].Value = inter_client;
            pdpKeyOutWebCommand.Parameters["@webcur_devel"].Value = inter_devel;
            pdpKeyOutWebCommand.Parameters["@webcur_incorp"].Value = inter_incorp;
            pdpKeyOutWebCommand.Parameters["@webcur_prog"].Value = inter_prog;
            pdpKeyOutWebCommand.Parameters["@webcur_consult"].Value = inter_consult;
            pdpKeyOutWebCommand.Parameters["@webcur_farmers"].Value = inter_farmers;
            pdpKeyOutWebCommand.Parameters["@webcur_out_other"].Value = ""; // inter_out_other;
            pdpKeyOutWebCommand.Parameters["@webcur_out_desc"].Value = ""; // inter_out_desc;
            pdpKeyOutWebCommand.Parameters["@webcur_description"].Value = ""; // inter_description;

            pdpKeyOutWebConnection.Open();
            pdpKeyOutWebCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutWebConnection.Close();
            pdpKeyOutWebCommand.Dispose();
            pdpKeyOutWebConnection.Dispose();

            return key;

        }

        public int SaveNewPDPKeyOutWorkshopsToDB()
        {
            string pdpKeyOutWorkshopsSQL;
            string pdpKeyOutWorkshopsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWorkshopsConnection;
            SqlCommand pdpKeyOutWorkshopsCommand;

            pdpKeyOutWorkshopsConnection = new SqlConnection(pdpKeyOutWorkshopsConnString);

            pdpKeyOutWorkshopsSQL = "DaikonpdpKeyOutWorkshopsCreate";
            pdpKeyOutWorkshopsCommand = new SqlCommand(pdpKeyOutWorkshopsSQL, pdpKeyOutWorkshopsConnection);
            pdpKeyOutWorkshopsCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutWorkshopsCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_description", SqlDbType.NText);           
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_description", SqlDbType.NText);    
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_description", SqlDbType.NText);    
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_zip", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_description", SqlDbType.NText);    
            pdpKeyOutWorkshopsCommand.Parameters.Add(keyOutput);

            pdpKeyOutWorkshopsCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutWorkshopsCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutWorkshopsCommand.Parameters["@short_session"].Value = short_session;
           if (short_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@short_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@short_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@short_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@short_end_date"].Value = null;
            //pdpKeyOutWorkshopsCommand.Parameters["@short_start_date"].Value = short_start_date;
            pdpKeyOutWorkshopsCommand.Parameters["@short_ext"].Value = short_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@short_nrcs"].Value = short_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@short_ngo"].Value = short_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@short_st"].Value = short_st;
            pdpKeyOutWorkshopsCommand.Parameters["@short_pro"].Value = short_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@short_farm"].Value = short_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@short_att_desc"].Value = short_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_att_other"].Value = short_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@short_loc"].Value = short_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_state"].Value = short_state;
            pdpKeyOutWorkshopsCommand.Parameters["@short_zip"].Value = short_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@short_media"].Value = short_media;
            pdpKeyOutWorkshopsCommand.Parameters["@short_client"].Value = short_client;
            pdpKeyOutWorkshopsCommand.Parameters["@short_devel"].Value = short_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@short_incorp"].Value = short_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@short_prog"].Value = short_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@short_consult"].Value = short_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@short_farmers"].Value = short_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@short_out_other"].Value = short_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@short_out_desc"].Value = short_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_title"].Value = short_title;
            pdpKeyOutWorkshopsCommand.Parameters["@short_description"].Value = short_description;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_session"].Value = inter_session;
            if (inter_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@inter_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@inter_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@inter_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@inter_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_ext"].Value = inter_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_nrcs"].Value = inter_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_ngo"].Value = inter_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_st"].Value = inter_st;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_pro"].Value = inter_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_farm"].Value = inter_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_att_desc"].Value = inter_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_att_other"].Value = inter_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_loc"].Value = inter_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_state"].Value = inter_state;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_zip"].Value = inter_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_media"].Value = inter_media;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_client"].Value = inter_client;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_devel"].Value = inter_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_incorp"].Value = inter_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_prog"].Value = inter_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_consult"].Value = inter_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_farmers"].Value = inter_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_out_other"].Value = inter_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_out_desc"].Value = inter_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_title"].Value = inter_title;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_description"].Value = inter_description;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_session"].Value = multi_session;
            if (multi_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@multi_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@multi_start_date"].Value = null;
            if (multi_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@multi_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@short_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_ext"].Value = multi_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_nrcs"].Value = multi_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_ngo"].Value = multi_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_st"].Value = multi_st;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_pro"].Value = multi_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_farm"].Value = multi_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_att_desc"].Value = multi_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_att_other"].Value = multi_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_loc"].Value = multi_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_state"].Value = multi_state;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_zip"].Value = multi_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_media"].Value = multi_media;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_client"].Value = multi_client;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_devel"].Value = multi_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_incorp"].Value = multi_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_prog"].Value = multi_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_consult"].Value = multi_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_farmers"].Value = multi_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_out_other"].Value = multi_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_out_desc"].Value = multi_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_title"].Value = multi_title;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_description"].Value = multi_description;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_session"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@extend_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@extend_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@extend_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@extend_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_ext"].Value = study_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_nrcs"].Value = study_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_ngo"].Value = study_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_st"].Value = study_st;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_pro"].Value = study_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_farm"].Value = study_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_att_desc"].Value = study_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_att_other"].Value = study_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_loc"].Value = study_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_state"].Value = study_state;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_zip"].Value = short_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_media"].Value = study_media;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_client"].Value = study_client;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_devel"].Value = study_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_incorp"].Value = study_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_prog"].Value = study_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_consult"].Value = study_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_farmers"].Value = study_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_out_other"].Value = study_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_out_desc"].Value = study_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_title"].Value = study_title;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_description"].Value = study_description;


            pdpKeyOutWorkshopsConnection.Open();
            pdpKeyOutWorkshopsCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutWorkshopsConnection.Close();
            pdpKeyOutWorkshopsCommand.Dispose();
            pdpKeyOutWorkshopsConnection.Dispose();

            return key;
        }

        public int SaveNewPDPKeyOutGrantsToDB()
        {
            string pdpKeyOutGrantsSQL;
            string pdpKeyOutGrantsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutGrantsConnection;
            SqlCommand pdpKeyOutGrantsCommand;

            pdpKeyOutGrantsConnection = new SqlConnection(pdpKeyOutGrantsConnString);

            pdpKeyOutGrantsSQL = "DaikonpdpKeyOutGrantsCreate";
            pdpKeyOutGrantsCommand = new SqlCommand(pdpKeyOutGrantsSQL, pdpKeyOutGrantsConnection);
            pdpKeyOutGrantsCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            pdpKeyOutGrantsCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutGrantsCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add(keyOutput);

            pdpKeyOutGrantsCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutGrantsCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutGrantsCommand.Parameters["@demo_session"].Value = short_session;
            if (short_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@demo_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@demo_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@demo_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@demo_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@demo_ext"].Value = short_ext;
            pdpKeyOutGrantsCommand.Parameters["@demo_nrcs"].Value = short_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@demo_ngo"].Value = short_ngo;
            pdpKeyOutGrantsCommand.Parameters["@demo_st"].Value = short_st;
            pdpKeyOutGrantsCommand.Parameters["@demo_pro"].Value = short_pro;
            pdpKeyOutGrantsCommand.Parameters["@demo_farm"].Value = short_farm;
            pdpKeyOutGrantsCommand.Parameters["@demo_att_desc"].Value = short_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@demo_att_other"].Value = short_att_other;
            pdpKeyOutGrantsCommand.Parameters["@demo_loc"].Value = short_loc;
            pdpKeyOutGrantsCommand.Parameters["@demo_state"].Value = short_state;
            pdpKeyOutGrantsCommand.Parameters["@demo_zip"].Value = short_zip;
            pdpKeyOutGrantsCommand.Parameters["@demo_media"].Value = short_media;
            pdpKeyOutGrantsCommand.Parameters["@demo_client"].Value = short_client;
            pdpKeyOutGrantsCommand.Parameters["@demo_devel"].Value = short_devel;
            pdpKeyOutGrantsCommand.Parameters["@demo_incorp"].Value = short_incorp;
            pdpKeyOutGrantsCommand.Parameters["@demo_prog"].Value = short_prog;
            pdpKeyOutGrantsCommand.Parameters["@demo_consult"].Value = short_consult;
            pdpKeyOutGrantsCommand.Parameters["@demo_farmers"].Value = short_farmers;
            pdpKeyOutGrantsCommand.Parameters["@demo_out_other"].Value = short_out_other;
            pdpKeyOutGrantsCommand.Parameters["@demo_out_desc"].Value = short_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@work_session"].Value = inter_session;
            if (inter_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@work_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@work_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@work_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@work_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@work_ext"].Value = inter_ext;
            pdpKeyOutGrantsCommand.Parameters["@work_nrcs"].Value = inter_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@work_ngo"].Value = inter_ngo;
            pdpKeyOutGrantsCommand.Parameters["@work_st"].Value = inter_st;
            pdpKeyOutGrantsCommand.Parameters["@work_pro"].Value = inter_pro;
            pdpKeyOutGrantsCommand.Parameters["@work_farm"].Value = inter_farm;
            pdpKeyOutGrantsCommand.Parameters["@work_att_desc"].Value = inter_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@work_att_other"].Value = inter_att_other;
            pdpKeyOutGrantsCommand.Parameters["@work_loc"].Value = inter_loc;
            pdpKeyOutGrantsCommand.Parameters["@work_state"].Value = inter_state;
            pdpKeyOutGrantsCommand.Parameters["@work_zip"].Value = inter_zip;
            pdpKeyOutGrantsCommand.Parameters["@work_media"].Value = inter_media;
            pdpKeyOutGrantsCommand.Parameters["@work_client"].Value = inter_client;
            pdpKeyOutGrantsCommand.Parameters["@work_devel"].Value = inter_devel;
            pdpKeyOutGrantsCommand.Parameters["@work_incorp"].Value = inter_incorp;
            pdpKeyOutGrantsCommand.Parameters["@work_prog"].Value = inter_prog;
            pdpKeyOutGrantsCommand.Parameters["@work_consult"].Value = inter_consult;
            pdpKeyOutGrantsCommand.Parameters["@work_farmers"].Value = inter_farmers;
            pdpKeyOutGrantsCommand.Parameters["@work_out_other"].Value = inter_out_other;
            pdpKeyOutGrantsCommand.Parameters["@work_out_desc"].Value = inter_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@tour_session"].Value = multi_session;
            if (multi_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@tour_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@tour_start_date"].Value = null;
            if (multi_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@tour_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@tour_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@tour_ext"].Value = multi_ext;
            pdpKeyOutGrantsCommand.Parameters["@tour_nrcs"].Value = multi_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@tour_ngo"].Value = multi_ngo;
            pdpKeyOutGrantsCommand.Parameters["@tour_st"].Value = multi_st;
            pdpKeyOutGrantsCommand.Parameters["@tour_pro"].Value = multi_pro;
            pdpKeyOutGrantsCommand.Parameters["@tour_farm"].Value = multi_farm;
            pdpKeyOutGrantsCommand.Parameters["@tour_att_desc"].Value = multi_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@tour_att_other"].Value = multi_att_other;
            pdpKeyOutGrantsCommand.Parameters["@tour_loc"].Value = multi_loc;
            pdpKeyOutGrantsCommand.Parameters["@tour_state"].Value = multi_state;
            pdpKeyOutGrantsCommand.Parameters["@tour_zip"].Value = multi_zip;
            pdpKeyOutGrantsCommand.Parameters["@tour_media"].Value = multi_media;
            pdpKeyOutGrantsCommand.Parameters["@tour_client"].Value = multi_client;
            pdpKeyOutGrantsCommand.Parameters["@tour_devel"].Value = multi_devel;
            pdpKeyOutGrantsCommand.Parameters["@tour_incorp"].Value = multi_incorp;
            pdpKeyOutGrantsCommand.Parameters["@tour_prog"].Value = multi_prog;
            pdpKeyOutGrantsCommand.Parameters["@tour_consult"].Value = multi_consult;
            pdpKeyOutGrantsCommand.Parameters["@tour_farmers"].Value = multi_farmers;
            pdpKeyOutGrantsCommand.Parameters["@tour_out_other"].Value = multi_out_other;
            pdpKeyOutGrantsCommand.Parameters["@tour_out_desc"].Value = multi_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@cur_session"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@cur_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@cur_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@cur_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@cur_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@cur_ext"].Value = study_ext;
            pdpKeyOutGrantsCommand.Parameters["@cur_nrcs"].Value = study_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@cur_ngo"].Value = study_ngo;
            pdpKeyOutGrantsCommand.Parameters["@cur_st"].Value = study_st;
            pdpKeyOutGrantsCommand.Parameters["@cur_pro"].Value = study_pro;
            pdpKeyOutGrantsCommand.Parameters["@cur_farm"].Value = study_farm;
            pdpKeyOutGrantsCommand.Parameters["@cur_att_desc"].Value = study_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@cur_att_other"].Value = study_att_other;
            pdpKeyOutGrantsCommand.Parameters["@cur_loc"].Value = study_loc;
            pdpKeyOutGrantsCommand.Parameters["@cur_state"].Value = study_state;
            pdpKeyOutGrantsCommand.Parameters["@cur_zip"].Value = study_zip;
            pdpKeyOutGrantsCommand.Parameters["@cur_media"].Value = study_media;
            pdpKeyOutGrantsCommand.Parameters["@cur_client"].Value = study_client;
            pdpKeyOutGrantsCommand.Parameters["@cur_devel"].Value = study_devel;
            pdpKeyOutGrantsCommand.Parameters["@cur_incorp"].Value = study_incorp;
            pdpKeyOutGrantsCommand.Parameters["@cur_prog"].Value = study_prog;
            pdpKeyOutGrantsCommand.Parameters["@cur_consult"].Value = study_consult;
            pdpKeyOutGrantsCommand.Parameters["@cur_farmers"].Value = study_farmers;
            pdpKeyOutGrantsCommand.Parameters["@cur_out_other"].Value = study_out_other;
            pdpKeyOutGrantsCommand.Parameters["@cur_out_desc"].Value = study_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@demo_title"].Value = short_title;
            pdpKeyOutGrantsCommand.Parameters["@demo_description"].Value = short_description;
            pdpKeyOutGrantsCommand.Parameters["@work_title"].Value = inter_title;
            pdpKeyOutGrantsCommand.Parameters["@work_description"].Value = inter_description;
            pdpKeyOutGrantsCommand.Parameters["@tour_title"].Value = multi_title;
            pdpKeyOutGrantsCommand.Parameters["@tour_description"].Value = multi_description;
            pdpKeyOutGrantsCommand.Parameters["@cur_title"].Value = study_title;
            pdpKeyOutGrantsCommand.Parameters["@cur_description"].Value = study_description;

            pdpKeyOutGrantsConnection.Open();
            pdpKeyOutGrantsCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            pdpKeyOutGrantsConnection.Close();
            pdpKeyOutGrantsCommand.Dispose();
            pdpKeyOutGrantsConnection.Dispose();

            return key;
        }

        public int SaveNewPDPKeyOutFieldToDB()
        {
            string PDPKeyOutFieldSQL;
            string PDPKeyOutFieldConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection PDPKeyOutFieldConnection;
            SqlCommand PDPKeyOutFieldCommand;

            PDPKeyOutFieldConnection = new SqlConnection(PDPKeyOutFieldConnString);

            PDPKeyOutFieldSQL = "DaikonPDPKeyOutFieldCreate";
            PDPKeyOutFieldCommand = new SqlCommand(PDPKeyOutFieldSQL, PDPKeyOutFieldConnection);
            PDPKeyOutFieldCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            PDPKeyOutFieldCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            PDPKeyOutFieldCommand.Parameters.Add("@initiative_num", SqlDbType.Int);

            PDPKeyOutFieldCommand.Parameters.Add("@inter_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_description", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_session", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_description", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_session", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_description", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add(keyOutput);

            PDPKeyOutFieldCommand.Parameters["@proj_num"].Value = projNum;
            PDPKeyOutFieldCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            PDPKeyOutFieldCommand.Parameters["@inter_title"].Value = inter_title;
            if (inter_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@inter_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@inter_start_date"].Value = null;
            if (inter_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@inter_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@inter_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@inter_ext"].Value = inter_ext;
            PDPKeyOutFieldCommand.Parameters["@inter_nrcs"].Value = inter_nrcs;
            PDPKeyOutFieldCommand.Parameters["@inter_ngo"].Value = inter_ngo;
            PDPKeyOutFieldCommand.Parameters["@inter_st"].Value = inter_st;
            PDPKeyOutFieldCommand.Parameters["@inter_pro"].Value = inter_pro;
            PDPKeyOutFieldCommand.Parameters["@inter_farm"].Value = inter_farm;
            PDPKeyOutFieldCommand.Parameters["@inter_att_desc"].Value = inter_att_desc;
            PDPKeyOutFieldCommand.Parameters["@inter_att_other"].Value = inter_att_other;
            PDPKeyOutFieldCommand.Parameters["@inter_loc"].Value = inter_loc;
            PDPKeyOutFieldCommand.Parameters["@inter_state"].Value = inter_state;
            PDPKeyOutFieldCommand.Parameters["@inter_zip"].Value = inter_zip;
            PDPKeyOutFieldCommand.Parameters["@inter_media"].Value = inter_media;
            PDPKeyOutFieldCommand.Parameters["@inter_client"].Value = inter_client;
            PDPKeyOutFieldCommand.Parameters["@inter_devel"].Value = inter_devel;
            PDPKeyOutFieldCommand.Parameters["@inter_incorp"].Value = inter_incorp;
            PDPKeyOutFieldCommand.Parameters["@inter_prog"].Value = inter_prog;
            PDPKeyOutFieldCommand.Parameters["@inter_consult"].Value = inter_consult;
            PDPKeyOutFieldCommand.Parameters["@inter_farmers"].Value = inter_farmers;
            PDPKeyOutFieldCommand.Parameters["@inter_out_other"].Value = inter_out_other;
            PDPKeyOutFieldCommand.Parameters["@inter_out_desc"].Value = inter_out_desc;
            PDPKeyOutFieldCommand.Parameters["@inter_description"].Value = inter_description;
            PDPKeyOutFieldCommand.Parameters["@multi_session"].Value = multi_session;
            PDPKeyOutFieldCommand.Parameters["@multi_title"].Value = multi_title;
            if (multi_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@multi_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@multi_start_date"].Value = null;
            if (multi_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@multi_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@multi_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@multi_ext"].Value = multi_ext;
            PDPKeyOutFieldCommand.Parameters["@multi_nrcs"].Value = multi_nrcs;
            PDPKeyOutFieldCommand.Parameters["@multi_ngo"].Value = multi_ngo;
            PDPKeyOutFieldCommand.Parameters["@multi_st"].Value = multi_st;
            PDPKeyOutFieldCommand.Parameters["@multi_pro"].Value = multi_pro;
            PDPKeyOutFieldCommand.Parameters["@multi_farm"].Value = multi_farm;
            PDPKeyOutFieldCommand.Parameters["@multi_att_desc"].Value = multi_att_desc;
            PDPKeyOutFieldCommand.Parameters["@multi_att_other"].Value = multi_att_other;
            PDPKeyOutFieldCommand.Parameters["@multi_loc"].Value = multi_loc;
            PDPKeyOutFieldCommand.Parameters["@multi_state"].Value = multi_state;
            PDPKeyOutFieldCommand.Parameters["@multi_zip"].Value = multi_zip;
            PDPKeyOutFieldCommand.Parameters["@multi_media"].Value = multi_media;
            PDPKeyOutFieldCommand.Parameters["@multi_client"].Value = multi_client;
            PDPKeyOutFieldCommand.Parameters["@multi_devel"].Value = multi_devel;
            PDPKeyOutFieldCommand.Parameters["@multi_incorp"].Value = multi_incorp;
            PDPKeyOutFieldCommand.Parameters["@multi_prog"].Value = multi_prog;
            PDPKeyOutFieldCommand.Parameters["@multi_consult"].Value = multi_consult;
            PDPKeyOutFieldCommand.Parameters["@multi_farmers"].Value = multi_farmers;
            PDPKeyOutFieldCommand.Parameters["@multi_out_other"].Value = multi_out_other;
            PDPKeyOutFieldCommand.Parameters["@multi_out_desc"].Value = multi_out_desc;
            PDPKeyOutFieldCommand.Parameters["@multi_description"].Value = multi_description;
            PDPKeyOutFieldCommand.Parameters["@extend_session"].Value = study_session;
            PDPKeyOutFieldCommand.Parameters["@extend_title"].Value = study_title;
            if (study_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@extend_start_date"].Value = DateTime.Parse(study_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@extend_start_date"].Value = null;
            if (study_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@extend_end_date"].Value = DateTime.Parse(study_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@extend_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@extend_ext"].Value = study_ext;
            PDPKeyOutFieldCommand.Parameters["@extend_nrcs"].Value = study_nrcs;
            PDPKeyOutFieldCommand.Parameters["@extend_ngo"].Value = study_ngo;
            PDPKeyOutFieldCommand.Parameters["@extend_st"].Value = study_st;
            PDPKeyOutFieldCommand.Parameters["@extend_pro"].Value = study_pro;
            PDPKeyOutFieldCommand.Parameters["@extend_farm"].Value = study_farm;
            PDPKeyOutFieldCommand.Parameters["@extend_att_desc"].Value = study_att_desc;
            PDPKeyOutFieldCommand.Parameters["@extend_att_other"].Value = study_att_other;
            PDPKeyOutFieldCommand.Parameters["@extend_loc"].Value = study_loc;
            PDPKeyOutFieldCommand.Parameters["@extend_state"].Value = study_state;
            PDPKeyOutFieldCommand.Parameters["@extend_zip"].Value = study_zip;
            PDPKeyOutFieldCommand.Parameters["@extend_media"].Value = study_media;
            PDPKeyOutFieldCommand.Parameters["@extend_client"].Value = study_client;
            PDPKeyOutFieldCommand.Parameters["@extend_devel"].Value = study_devel;
            PDPKeyOutFieldCommand.Parameters["@extend_incorp"].Value = study_incorp;
            PDPKeyOutFieldCommand.Parameters["@extend_prog"].Value = study_prog;
            PDPKeyOutFieldCommand.Parameters["@extend_consult"].Value = study_consult;
            PDPKeyOutFieldCommand.Parameters["@extend_farmers"].Value = study_farmers;
            PDPKeyOutFieldCommand.Parameters["@extend_out_other"].Value = study_out_other;
            PDPKeyOutFieldCommand.Parameters["@extend_out_desc"].Value = study_out_desc;
            PDPKeyOutFieldCommand.Parameters["@extend_description"].Value = study_description;

            PDPKeyOutFieldConnection.Open();
            PDPKeyOutFieldCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            PDPKeyOutFieldConnection.Close();
            PDPKeyOutFieldCommand.Dispose();
            PDPKeyOutFieldConnection.Dispose();

            return key;
        }

        public bool UpdatePDPKeyOutGrantsToDB()
        {
            string pdpKeyOutGrantsSQL;
            string pdpKeyOutGrantsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutGrantsConnection;
            SqlCommand pdpKeyOutGrantsCommand;

            pdpKeyOutGrantsConnection = new SqlConnection(pdpKeyOutGrantsConnString);

            pdpKeyOutGrantsSQL = "DaikonpdpKeyOutGrantsUpdate";
            pdpKeyOutGrantsCommand = new SqlCommand(pdpKeyOutGrantsSQL, pdpKeyOutGrantsConnection);
            pdpKeyOutGrantsCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutGrantsCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutGrantsCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_session", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_start_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_end_Date", SqlDbType.Date);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_ext", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_nrcs", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_ngo", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_st", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_pro", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_farm", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_att_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_att_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_loc", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_state", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_zip", SqlDbType.VarChar, 5);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_media", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_client", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_devel", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_incorp", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_prog", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_consult", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_farmers", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_out_other", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_out_desc", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@demo_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@work_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@tour_description", SqlDbType.NText);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_title", SqlDbType.VarChar, 255);
            pdpKeyOutGrantsCommand.Parameters.Add("@cur_description", SqlDbType.NText);

            pdpKeyOutGrantsCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutGrantsCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutGrantsCommand.Parameters["@demo_session"].Value = short_session;
            if (short_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@demo_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@demo_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@demo_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@demo_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@demo_ext"].Value = short_ext;
            pdpKeyOutGrantsCommand.Parameters["@demo_nrcs"].Value = short_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@demo_ngo"].Value = short_ngo;
            pdpKeyOutGrantsCommand.Parameters["@demo_st"].Value = short_st;
            pdpKeyOutGrantsCommand.Parameters["@demo_pro"].Value = short_pro;
            pdpKeyOutGrantsCommand.Parameters["@demo_farm"].Value = short_farm;
            pdpKeyOutGrantsCommand.Parameters["@demo_att_desc"].Value = short_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@demo_att_other"].Value = short_att_other;
            pdpKeyOutGrantsCommand.Parameters["@demo_loc"].Value = short_loc;
            pdpKeyOutGrantsCommand.Parameters["@demo_state"].Value = short_state;
            pdpKeyOutGrantsCommand.Parameters["@demo_zip"].Value = short_zip;
            pdpKeyOutGrantsCommand.Parameters["@demo_media"].Value = short_media;
            pdpKeyOutGrantsCommand.Parameters["@demo_client"].Value = short_client;
            pdpKeyOutGrantsCommand.Parameters["@demo_devel"].Value = short_devel;
            pdpKeyOutGrantsCommand.Parameters["@demo_incorp"].Value = short_incorp;
            pdpKeyOutGrantsCommand.Parameters["@demo_prog"].Value = short_prog;
            pdpKeyOutGrantsCommand.Parameters["@demo_consult"].Value = short_consult;
            pdpKeyOutGrantsCommand.Parameters["@demo_farmers"].Value = short_farmers;
            pdpKeyOutGrantsCommand.Parameters["@demo_out_other"].Value = short_out_other;
            pdpKeyOutGrantsCommand.Parameters["@demo_out_desc"].Value = short_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@work_session"].Value = inter_session;
            if (inter_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@work_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@work_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@work_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@work_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@work_ext"].Value = inter_ext;
            pdpKeyOutGrantsCommand.Parameters["@work_nrcs"].Value = inter_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@work_ngo"].Value = inter_ngo;
            pdpKeyOutGrantsCommand.Parameters["@work_st"].Value = inter_st;
            pdpKeyOutGrantsCommand.Parameters["@work_pro"].Value = inter_pro;
            pdpKeyOutGrantsCommand.Parameters["@work_farm"].Value = inter_farm;
            pdpKeyOutGrantsCommand.Parameters["@work_att_desc"].Value = inter_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@work_att_other"].Value = inter_att_other;
            pdpKeyOutGrantsCommand.Parameters["@work_loc"].Value = inter_loc;
            pdpKeyOutGrantsCommand.Parameters["@work_state"].Value = inter_state;
            pdpKeyOutGrantsCommand.Parameters["@work_zip"].Value = inter_zip;
            pdpKeyOutGrantsCommand.Parameters["@work_media"].Value = inter_media;
            pdpKeyOutGrantsCommand.Parameters["@work_client"].Value = inter_client;
            pdpKeyOutGrantsCommand.Parameters["@work_devel"].Value = inter_devel;
            pdpKeyOutGrantsCommand.Parameters["@work_incorp"].Value = inter_incorp;
            pdpKeyOutGrantsCommand.Parameters["@work_prog"].Value = inter_prog;
            pdpKeyOutGrantsCommand.Parameters["@work_consult"].Value = inter_consult;
            pdpKeyOutGrantsCommand.Parameters["@work_farmers"].Value = inter_farmers;
            pdpKeyOutGrantsCommand.Parameters["@work_out_other"].Value = inter_out_other;
            pdpKeyOutGrantsCommand.Parameters["@work_out_desc"].Value = inter_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@tour_session"].Value = multi_session;
            if (multi_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@tour_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@tour_start_date"].Value = null;
            if (multi_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@tour_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@tour_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@tour_ext"].Value = multi_ext;
            pdpKeyOutGrantsCommand.Parameters["@tour_nrcs"].Value = multi_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@tour_ngo"].Value = multi_ngo;
            pdpKeyOutGrantsCommand.Parameters["@tour_st"].Value = multi_st;
            pdpKeyOutGrantsCommand.Parameters["@tour_pro"].Value = multi_pro;
            pdpKeyOutGrantsCommand.Parameters["@tour_farm"].Value = multi_farm;
            pdpKeyOutGrantsCommand.Parameters["@tour_att_desc"].Value = multi_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@tour_att_other"].Value = multi_att_other;
            pdpKeyOutGrantsCommand.Parameters["@tour_loc"].Value = multi_loc;
            pdpKeyOutGrantsCommand.Parameters["@tour_state"].Value = multi_state;
            pdpKeyOutGrantsCommand.Parameters["@tour_zip"].Value = multi_zip;
            pdpKeyOutGrantsCommand.Parameters["@tour_media"].Value = multi_media;
            pdpKeyOutGrantsCommand.Parameters["@tour_client"].Value = multi_client;
            pdpKeyOutGrantsCommand.Parameters["@tour_devel"].Value = multi_devel;
            pdpKeyOutGrantsCommand.Parameters["@tour_incorp"].Value = multi_incorp;
            pdpKeyOutGrantsCommand.Parameters["@tour_prog"].Value = multi_prog;
            pdpKeyOutGrantsCommand.Parameters["@tour_consult"].Value = multi_consult;
            pdpKeyOutGrantsCommand.Parameters["@tour_farmers"].Value = multi_farmers;
            pdpKeyOutGrantsCommand.Parameters["@tour_out_other"].Value = multi_out_other;
            pdpKeyOutGrantsCommand.Parameters["@tour_out_desc"].Value = multi_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@cur_session"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutGrantsCommand.Parameters["@cur_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@cur_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutGrantsCommand.Parameters["@cur_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutGrantsCommand.Parameters["@cur_end_date"].Value = null;
            pdpKeyOutGrantsCommand.Parameters["@cur_ext"].Value = study_ext;
            pdpKeyOutGrantsCommand.Parameters["@cur_nrcs"].Value = study_nrcs;
            pdpKeyOutGrantsCommand.Parameters["@cur_ngo"].Value = study_ngo;
            pdpKeyOutGrantsCommand.Parameters["@cur_st"].Value = study_st;
            pdpKeyOutGrantsCommand.Parameters["@cur_pro"].Value = study_pro;
            pdpKeyOutGrantsCommand.Parameters["@cur_farm"].Value = study_farm;
            pdpKeyOutGrantsCommand.Parameters["@cur_att_desc"].Value = study_att_desc;
            pdpKeyOutGrantsCommand.Parameters["@cur_att_other"].Value = study_att_other;
            pdpKeyOutGrantsCommand.Parameters["@cur_loc"].Value = study_loc;
            pdpKeyOutGrantsCommand.Parameters["@cur_state"].Value = study_state;
            pdpKeyOutGrantsCommand.Parameters["@cur_zip"].Value = study_zip;
            pdpKeyOutGrantsCommand.Parameters["@cur_media"].Value = study_media;
            pdpKeyOutGrantsCommand.Parameters["@cur_client"].Value = study_client;
            pdpKeyOutGrantsCommand.Parameters["@cur_devel"].Value = study_devel;
            pdpKeyOutGrantsCommand.Parameters["@cur_incorp"].Value = study_incorp;
            pdpKeyOutGrantsCommand.Parameters["@cur_prog"].Value = study_prog;
            pdpKeyOutGrantsCommand.Parameters["@cur_consult"].Value = study_consult;
            pdpKeyOutGrantsCommand.Parameters["@cur_farmers"].Value = study_farmers;
            pdpKeyOutGrantsCommand.Parameters["@cur_out_other"].Value = study_out_other;
            pdpKeyOutGrantsCommand.Parameters["@cur_out_desc"].Value = study_out_desc;
            pdpKeyOutGrantsCommand.Parameters["@demo_title"].Value = short_title;
            pdpKeyOutGrantsCommand.Parameters["@demo_description"].Value = short_description;
            pdpKeyOutGrantsCommand.Parameters["@work_title"].Value = inter_title;
            pdpKeyOutGrantsCommand.Parameters["@work_description"].Value = inter_description;
            pdpKeyOutGrantsCommand.Parameters["@tour_title"].Value = multi_title;
            pdpKeyOutGrantsCommand.Parameters["@tour_description"].Value = multi_description;
            pdpKeyOutGrantsCommand.Parameters["@cur_title"].Value = study_title;
            pdpKeyOutGrantsCommand.Parameters["@cur_description"].Value = study_description;          

            pdpKeyOutGrantsConnection.Open();
            pdpKeyOutGrantsCommand.ExecuteScalar();

            pdpKeyOutGrantsConnection.Close();
            pdpKeyOutGrantsCommand.Dispose();
            pdpKeyOutGrantsConnection.Dispose();

            return true;
        }
        
        public bool UpdatePDPKeyOutStudyToDB()
        {
            string pdpKeyOutStudySQL;
            string pdpKeyOutStudyConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutStudyConnection;
            SqlCommand pdpKeyOutStudyCommand;

            pdpKeyOutStudyConnection = new SqlConnection(pdpKeyOutStudyConnString);

            pdpKeyOutStudySQL = "DaikonPDPKeyOutStudyUpdate";
            pdpKeyOutStudyCommand = new SqlCommand(pdpKeyOutStudySQL, pdpKeyOutStudyConnection);
            pdpKeyOutStudyCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutStudyCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutStudyCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_title", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_session", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_start_Date", SqlDbType.Date);
            pdpKeyOutStudyCommand.Parameters.Add("@study_end_Date", SqlDbType.Date);
            pdpKeyOutStudyCommand.Parameters.Add("@study_ext", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_nrcs", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_ngo", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_st", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_pro", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_farm", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_att_desc", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_att_other", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_loc", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_state", SqlDbType.VarChar, 255);
            pdpKeyOutStudyCommand.Parameters.Add("@study_zip", SqlDbType.VarChar, 5);
            pdpKeyOutStudyCommand.Parameters.Add("@study_media", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_client", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_devel", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_incorp", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_prog", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_consult", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_farmers", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@study_out_other", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_out_desc", SqlDbType.NText);
            pdpKeyOutStudyCommand.Parameters.Add("@study_description", SqlDbType.NText);
            
            pdpKeyOutStudyCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutStudyCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutStudyCommand.Parameters["@study_session"].Value = study_session;
            pdpKeyOutStudyCommand.Parameters["@study_title"].Value = study_title;
            if (study_start_date != "")
                pdpKeyOutStudyCommand.Parameters["@study_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutStudyCommand.Parameters["@study_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutStudyCommand.Parameters["@study_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutStudyCommand.Parameters["@study_end_date"].Value = null;
            pdpKeyOutStudyCommand.Parameters["@study_ext"].Value = study_ext;
            pdpKeyOutStudyCommand.Parameters["@study_nrcs"].Value = study_nrcs;
            pdpKeyOutStudyCommand.Parameters["@study_ngo"].Value = study_ngo;
            pdpKeyOutStudyCommand.Parameters["@study_st"].Value = study_st;
            pdpKeyOutStudyCommand.Parameters["@study_pro"].Value = study_pro;
            pdpKeyOutStudyCommand.Parameters["@study_farm"].Value = study_farm;
            pdpKeyOutStudyCommand.Parameters["@study_att_desc"].Value = study_att_desc;
            pdpKeyOutStudyCommand.Parameters["@study_att_other"].Value = study_att_other;
            pdpKeyOutStudyCommand.Parameters["@study_loc"].Value = study_loc;
            pdpKeyOutStudyCommand.Parameters["@study_state"].Value = study_state;
            pdpKeyOutStudyCommand.Parameters["@study_zip"].Value = study_zip;
            pdpKeyOutStudyCommand.Parameters["@study_media"].Value = study_media;
            pdpKeyOutStudyCommand.Parameters["@study_client"].Value = study_client;
            pdpKeyOutStudyCommand.Parameters["@study_devel"].Value = study_devel;
            pdpKeyOutStudyCommand.Parameters["@study_incorp"].Value = study_incorp;
            pdpKeyOutStudyCommand.Parameters["@study_prog"].Value = study_prog;
            pdpKeyOutStudyCommand.Parameters["@study_consult"].Value = study_consult;
            pdpKeyOutStudyCommand.Parameters["@study_farmers"].Value = study_farmers;
            pdpKeyOutStudyCommand.Parameters["@study_out_other"].Value = study_out_other;
            pdpKeyOutStudyCommand.Parameters["@study_out_desc"].Value = study_out_other;
            pdpKeyOutStudyCommand.Parameters["@study_description"].Value = study_description;

            pdpKeyOutStudyConnection.Open();
            pdpKeyOutStudyCommand.ExecuteScalar();

            pdpKeyOutStudyConnection.Close();
            pdpKeyOutStudyCommand.Dispose();
            pdpKeyOutStudyConnection.Dispose();

            return true;
        }

        public bool UpdatePDPKeyOutTravelToDB()
        {
            string pdpKeyOutTravelSQL;
            string pdpKeyOutTravelConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutTravelConnection;
            SqlCommand pdpKeyOutTravelCommand;

            pdpKeyOutTravelConnection = new SqlConnection(pdpKeyOutTravelConnString);

            pdpKeyOutTravelSQL = "DaikonPDPKeyOutTravelUpdate";
            pdpKeyOutTravelCommand = new SqlCommand(pdpKeyOutTravelSQL, pdpKeyOutTravelConnection);
            pdpKeyOutTravelCommand.CommandType = CommandType.StoredProcedure;

           
            pdpKeyOutTravelCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutTravelCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_title", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_desc", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_scholarship", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual1", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual2", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual3", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual4", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual5", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual6", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual7", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual8", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual9", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual10", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual11", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual12", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_individual_other", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_start_date", SqlDbType.Date);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_end_date", SqlDbType.Date);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_ext", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_nrcs", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_ngo", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_st", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_pro", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_farm", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_reci_desc", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_other", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_loc", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_state", SqlDbType.VarChar, 255);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_zip", SqlDbType.VarChar, 5);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_media", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_client", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_devel", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_incorp", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_prog", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_consult", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_farmers", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_out_other", SqlDbType.NText);
            pdpKeyOutTravelCommand.Parameters.Add("@travel_out_desc", SqlDbType.NText);
           

            pdpKeyOutTravelCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutTravelCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutTravelCommand.Parameters["@travel_title"].Value = study_title;
            pdpKeyOutTravelCommand.Parameters["@travel_desc"].Value = travel_desc;
            pdpKeyOutTravelCommand.Parameters["@travel_scholarship"].Value = study_session;
            pdpKeyOutTravelCommand.Parameters["@travel_individual1"].Value = travel_individual1;
            pdpKeyOutTravelCommand.Parameters["@travel_individual2"].Value = travel_individual2;
            pdpKeyOutTravelCommand.Parameters["@travel_individual3"].Value = travel_individual3;
            pdpKeyOutTravelCommand.Parameters["@travel_individual4"].Value = travel_individual4;
            pdpKeyOutTravelCommand.Parameters["@travel_individual5"].Value = travel_individual5;
            pdpKeyOutTravelCommand.Parameters["@travel_individual6"].Value = travel_individual6;
            pdpKeyOutTravelCommand.Parameters["@travel_individual7"].Value = travel_individual7;
            pdpKeyOutTravelCommand.Parameters["@travel_individual8"].Value = travel_individual8;
            pdpKeyOutTravelCommand.Parameters["@travel_individual9"].Value = travel_individual9;
            pdpKeyOutTravelCommand.Parameters["@travel_individual10"].Value = travel_individual10;
            pdpKeyOutTravelCommand.Parameters["@travel_individual11"].Value = travel_individual11;
            pdpKeyOutTravelCommand.Parameters["@travel_individual12"].Value = travel_individual12;
            pdpKeyOutTravelCommand.Parameters["@travel_individual_other"].Value = travel_individual_other;
            if (study_start_date != "")
                pdpKeyOutTravelCommand.Parameters["@travel_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutTravelCommand.Parameters["@travel_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutTravelCommand.Parameters["@travel_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutTravelCommand.Parameters["@travel_end_date"].Value = null;
            pdpKeyOutTravelCommand.Parameters["@travel_ext"].Value = study_ext;
            pdpKeyOutTravelCommand.Parameters["@travel_nrcs"].Value = study_nrcs;
            pdpKeyOutTravelCommand.Parameters["@travel_ngo"].Value = study_ngo;
            pdpKeyOutTravelCommand.Parameters["@travel_st"].Value = study_st;
            pdpKeyOutTravelCommand.Parameters["@travel_pro"].Value = study_pro;
            pdpKeyOutTravelCommand.Parameters["@travel_farm"].Value = study_farm;
            pdpKeyOutTravelCommand.Parameters["@travel_reci_desc"].Value = study_att_desc;
            pdpKeyOutTravelCommand.Parameters["@travel_other"].Value = study_att_other;
            pdpKeyOutTravelCommand.Parameters["@travel_loc"].Value = study_loc;
            pdpKeyOutTravelCommand.Parameters["@travel_state"].Value = study_state;
            pdpKeyOutTravelCommand.Parameters["@travel_zip"].Value = study_zip;
            pdpKeyOutTravelCommand.Parameters["@travel_media"].Value = study_media;
            pdpKeyOutTravelCommand.Parameters["@travel_client"].Value = study_client;
            pdpKeyOutTravelCommand.Parameters["@travel_devel"].Value = study_devel;
            pdpKeyOutTravelCommand.Parameters["@travel_incorp"].Value = study_incorp;
            pdpKeyOutTravelCommand.Parameters["@travel_prog"].Value = study_prog;
            pdpKeyOutTravelCommand.Parameters["@travel_consult"].Value = study_consult;
            pdpKeyOutTravelCommand.Parameters["@travel_farmers"].Value = study_farmers;
            pdpKeyOutTravelCommand.Parameters["@travel_out_other"].Value = study_out_other;
            pdpKeyOutTravelCommand.Parameters["@travel_out_desc"].Value = study_out_desc;

            pdpKeyOutTravelConnection.Open();
            pdpKeyOutTravelCommand.ExecuteScalar();

          
            pdpKeyOutTravelConnection.Close();
            pdpKeyOutTravelCommand.Dispose();
            pdpKeyOutTravelConnection.Dispose();

            return true;
        }

        public bool DeletePDPKeyOutTravelFromDB(int pdp_key_travelID)
        {
            string pdpKeyOutTravelSQL;
            string pdpKeyOutTravelConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutTravelConnection;
            SqlCommand pdpKeyOutTravelCommand;

            pdpKeyOutTravelConnection = new SqlConnection(pdpKeyOutTravelConnString);

            pdpKeyOutTravelSQL = "DaikonPDPKeyOutTravelDelete";
            pdpKeyOutTravelCommand = new SqlCommand(pdpKeyOutTravelSQL, pdpKeyOutTravelConnection);
            pdpKeyOutTravelCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutTravelCommand.Parameters.Add("@pdp_key_travelID", SqlDbType.Int);

            pdpKeyOutTravelCommand.Parameters["@pdp_key_travelID"].Value = pdp_key_travelID;

            pdpKeyOutTravelConnection.Open();
            pdpKeyOutTravelCommand.ExecuteScalar();


            pdpKeyOutTravelConnection.Close();
            pdpKeyOutTravelCommand.Dispose();
            pdpKeyOutTravelConnection.Dispose();

            return true;

        }

        public bool DeletePDPKeyOutFieldFromDB(int pdp_key_fieldID)
        {
            string pdpKeyOutFieldSQL;
            string pdpKeyOutFieldConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutFieldConnection;
            SqlCommand pdpKeyOutFieldCommand;

            pdpKeyOutFieldConnection = new SqlConnection(pdpKeyOutFieldConnString);

            pdpKeyOutFieldSQL = "DaikonpdpKeyOutFieldDelete";
            pdpKeyOutFieldCommand = new SqlCommand(pdpKeyOutFieldSQL, pdpKeyOutFieldConnection);
            pdpKeyOutFieldCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutFieldCommand.Parameters.Add("@pdp_key_fieldID", SqlDbType.Int);

            pdpKeyOutFieldCommand.Parameters["@pdp_key_fieldID"].Value = pdp_key_fieldID;

            pdpKeyOutFieldConnection.Open();
            pdpKeyOutFieldCommand.ExecuteScalar();


            pdpKeyOutFieldConnection.Close();
            pdpKeyOutFieldCommand.Dispose();
            pdpKeyOutFieldConnection.Dispose();

            return true;

        }

        public bool DeletePDPKeyOutWorkshopsFromDB(int pdp_key_workID)
        {
            string pdpKeyOutWorkshopsSQL;
            string pdpKeyOutWorkshopsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWorkshopsConnection;
            SqlCommand pdpKeyOutWorkshopsCommand;

            pdpKeyOutWorkshopsConnection = new SqlConnection(pdpKeyOutWorkshopsConnString);

            pdpKeyOutWorkshopsSQL = "DaikonPDPKeyOutWorkshopsDelete";
            pdpKeyOutWorkshopsCommand = new SqlCommand(pdpKeyOutWorkshopsSQL, pdpKeyOutWorkshopsConnection);
            pdpKeyOutWorkshopsCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutWorkshopsCommand.Parameters.Add("@pdp_key_workID", SqlDbType.Int);

            pdpKeyOutWorkshopsCommand.Parameters["@pdp_key_workID"].Value = pdp_key_workID;

            pdpKeyOutWorkshopsConnection.Open();
            pdpKeyOutWorkshopsCommand.ExecuteScalar();


            pdpKeyOutWorkshopsConnection.Close();
            pdpKeyOutWorkshopsCommand.Dispose();
            pdpKeyOutWorkshopsConnection.Dispose();

            return true;
        }

        public bool DeletePDPKeyOutStudyFromDB(int pdp_key_studyID)
        {
            string pdpKeyOutStudySQL;
            string pdpKeyOutStudyConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutStudyConnection;
            SqlCommand pdpKeyOutStudyCommand;

            pdpKeyOutStudyConnection = new SqlConnection(pdpKeyOutStudyConnString);

            pdpKeyOutStudySQL = "DaikonPDPKeyOutStudyDelete";
            pdpKeyOutStudyCommand = new SqlCommand(pdpKeyOutStudySQL, pdpKeyOutStudyConnection);
            pdpKeyOutStudyCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutStudyCommand.Parameters.Add("@pdp_key_studyID", SqlDbType.Int);

            pdpKeyOutStudyCommand.Parameters["@pdp_key_studyID"].Value = pdp_key_studyID;

            pdpKeyOutStudyConnection.Open();
            pdpKeyOutStudyCommand.ExecuteScalar();


            pdpKeyOutStudyConnection.Close();
            pdpKeyOutStudyCommand.Dispose();
            pdpKeyOutStudyConnection.Dispose();

            return true;
        }

        public bool DeletePDPKeyOutGrantsFromDB(int pdp_key_grantID)
        {
            string pdpKeyOutGrantsSQL;
            string pdpKeyOutGrantsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutGrantsConnection;
            SqlCommand pdpKeyOutGrantsCommand;

            pdpKeyOutGrantsConnection = new SqlConnection(pdpKeyOutGrantsConnString);

            pdpKeyOutGrantsSQL = "DaikonPDPKeyOutGrantsDelete";
            pdpKeyOutGrantsCommand = new SqlCommand(pdpKeyOutGrantsSQL, pdpKeyOutGrantsConnection);
            pdpKeyOutGrantsCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutGrantsCommand.Parameters.Add("@pdp_key_grantID", SqlDbType.Int);

            pdpKeyOutGrantsCommand.Parameters["@pdp_key_grantID"].Value = pdp_key_grantID;

            pdpKeyOutGrantsConnection.Open();
            pdpKeyOutGrantsCommand.ExecuteScalar();


            pdpKeyOutGrantsConnection.Close();
            pdpKeyOutGrantsCommand.Dispose();
            pdpKeyOutGrantsConnection.Dispose();

            return true;
        }

        public bool DeletePDPKeyOutWebFromDB(int pdp_key_webID)
        {
            string pdpKeyOutWebSQL;
            string pdpKeyOutWebConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWebConnection;
            SqlCommand pdpKeyOutWebCommand;

            pdpKeyOutWebConnection = new SqlConnection(pdpKeyOutWebConnString);

            pdpKeyOutWebSQL = "DaikonPDPKeyOutWebDelete";
            pdpKeyOutWebCommand = new SqlCommand(pdpKeyOutWebSQL, pdpKeyOutWebConnection);
            pdpKeyOutWebCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutWebCommand.Parameters.Add("@pdp_key_webID", SqlDbType.Int);

            pdpKeyOutWebCommand.Parameters["@pdp_key_webID"].Value = pdp_key_webID;

            pdpKeyOutWebConnection.Open();
            pdpKeyOutWebCommand.ExecuteScalar();


            pdpKeyOutWebConnection.Close();
            pdpKeyOutWebCommand.Dispose();
            pdpKeyOutWebConnection.Dispose();

            return true;
        }

        public bool DeletePDPKeyOutOtherFromDB(int pdp_key_otherID)
        {
            string pdpKeyOutOtherSQL;
            string pdpKeyOutOtherConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutOtherConnection;
            SqlCommand pdpKeyOutOtherCommand;

            pdpKeyOutOtherConnection = new SqlConnection(pdpKeyOutOtherConnString);

            pdpKeyOutOtherSQL = "DaikonPDPKeyOutOtherDelete";
            pdpKeyOutOtherCommand = new SqlCommand(pdpKeyOutOtherSQL, pdpKeyOutOtherConnection);
            pdpKeyOutOtherCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutOtherCommand.Parameters.Add("@pdp_key_otherID", SqlDbType.Int);

            pdpKeyOutOtherCommand.Parameters["@pdp_key_otherID"].Value = pdp_key_otherID;

            pdpKeyOutOtherConnection.Open();
            pdpKeyOutOtherCommand.ExecuteScalar();


            pdpKeyOutOtherConnection.Close();
            pdpKeyOutOtherCommand.Dispose();
            pdpKeyOutOtherConnection.Dispose();

            return true;
        }


        public bool UpdatePDPKeyOutOtherToDB()
        {
            string pdpKeyOutOtherSQL;
            string pdpKeyOutOtherConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutOtherConnection;
            SqlCommand pdpKeyOutOtherCommand;

            pdpKeyOutOtherConnection = new SqlConnection(pdpKeyOutOtherConnString);

            pdpKeyOutOtherSQL = "DaikonpdpKeyOutOtherUpdate";
            pdpKeyOutOtherCommand = new SqlCommand(pdpKeyOutOtherSQL, pdpKeyOutOtherConnection);
            pdpKeyOutOtherCommand.CommandType = CommandType.StoredProcedure;

       
            pdpKeyOutOtherCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutOtherCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_title", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_desc", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_num", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_start_date", SqlDbType.Date);
            pdpKeyOutOtherCommand.Parameters.Add("@other_end_date", SqlDbType.Date);
            pdpKeyOutOtherCommand.Parameters.Add("@other_ext", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_nrcs", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_ngo", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_st", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_pro", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_farm", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_reci_desc", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_other", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_loc", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_state", SqlDbType.VarChar, 255);
            pdpKeyOutOtherCommand.Parameters.Add("@other_zip", SqlDbType.VarChar, 5);
            pdpKeyOutOtherCommand.Parameters.Add("@other_media", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_client", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_devel", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_incorp", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_prog", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_consult", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_farmers", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@other_out_other", SqlDbType.NText);
            pdpKeyOutOtherCommand.Parameters.Add("@other_out_desc", SqlDbType.NText);
          

            pdpKeyOutOtherCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutOtherCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutOtherCommand.Parameters["@other_title"].Value = study_title;
            pdpKeyOutOtherCommand.Parameters["@other_desc"].Value = other_desc;
            pdpKeyOutOtherCommand.Parameters["@other_num"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutOtherCommand.Parameters["@other_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutOtherCommand.Parameters["@other_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutOtherCommand.Parameters["@other_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutOtherCommand.Parameters["@other_end_date"].Value = null;
            pdpKeyOutOtherCommand.Parameters["@other_ext"].Value = study_ext;
            pdpKeyOutOtherCommand.Parameters["@other_nrcs"].Value = study_nrcs;
            pdpKeyOutOtherCommand.Parameters["@other_ngo"].Value = study_ngo;
            pdpKeyOutOtherCommand.Parameters["@other_st"].Value = study_st;
            pdpKeyOutOtherCommand.Parameters["@other_pro"].Value = study_pro;
            pdpKeyOutOtherCommand.Parameters["@other_farm"].Value = study_farm;
            pdpKeyOutOtherCommand.Parameters["@other_reci_desc"].Value = study_att_desc;
            pdpKeyOutOtherCommand.Parameters["@other_other"].Value = study_att_other;
            pdpKeyOutOtherCommand.Parameters["@other_loc"].Value = study_loc;
            pdpKeyOutOtherCommand.Parameters["@other_state"].Value = study_state;
            pdpKeyOutOtherCommand.Parameters["@other_zip"].Value = study_zip;
            pdpKeyOutOtherCommand.Parameters["@other_media"].Value = study_media;
            pdpKeyOutOtherCommand.Parameters["@other_client"].Value = study_client;
            pdpKeyOutOtherCommand.Parameters["@other_devel"].Value = study_devel;
            pdpKeyOutOtherCommand.Parameters["@other_incorp"].Value = study_incorp;
            pdpKeyOutOtherCommand.Parameters["@other_prog"].Value = study_prog;
            pdpKeyOutOtherCommand.Parameters["@other_consult"].Value = study_consult;
            pdpKeyOutOtherCommand.Parameters["@other_farmers"].Value = study_farmers;
            pdpKeyOutOtherCommand.Parameters["@other_out_other"].Value = study_out_other;
            pdpKeyOutOtherCommand.Parameters["@other_out_desc"].Value = study_out_desc;

            pdpKeyOutOtherConnection.Open();
            pdpKeyOutOtherCommand.ExecuteScalar();

            pdpKeyOutOtherConnection.Close();
            pdpKeyOutOtherCommand.Dispose();
            pdpKeyOutOtherConnection.Dispose();

            return true;
        }

        public bool UpdatePDPKeyOutWebToDB()
        {
            string pdpKeyOutWebSQL;
            string pdpKeyOutWebConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWebConnection;
            SqlCommand pdpKeyOutWebCommand;

            pdpKeyOutWebConnection = new SqlConnection(pdpKeyOutWebConnString);

            pdpKeyOutWebSQL = "DaikonPDPKeyOutWebUpdate";
            pdpKeyOutWebCommand = new SqlCommand(pdpKeyOutWebSQL, pdpKeyOutWebConnection);
            pdpKeyOutWebCommand.CommandType = CommandType.StoredProcedure;

            pdpKeyOutWebCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutWebCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_curricula", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@web_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@web_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@web_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@web_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@web_description", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webseries_description", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_title", SqlDbType.VarChar, 255);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_start_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_end_date", SqlDbType.Date);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_ext", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_nrcs", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_ngo", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_st", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_pro", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_farm", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_att_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_att_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_media", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_client", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_devel", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_incorp", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_prog", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_consult", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_farmers", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_out_other", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_out_desc", SqlDbType.NText);
            pdpKeyOutWebCommand.Parameters.Add("@webcur_description", SqlDbType.NText);

            pdpKeyOutWebCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutWebCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutWebCommand.Parameters["@web_curricula"].Value = study_session;
            pdpKeyOutWebCommand.Parameters["@web_title"].Value = study_title;
            if (study_start_date != "")
                pdpKeyOutWebCommand.Parameters["@web_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@web_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutWebCommand.Parameters["@web_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@web_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@web_ext"].Value = study_ext;
            pdpKeyOutWebCommand.Parameters["@web_nrcs"].Value = study_nrcs;
            pdpKeyOutWebCommand.Parameters["@web_ngo"].Value = study_ngo;
            pdpKeyOutWebCommand.Parameters["@web_st"].Value = study_st;
            pdpKeyOutWebCommand.Parameters["@web_pro"].Value = study_pro;
            pdpKeyOutWebCommand.Parameters["@web_farm"].Value = study_farm;
            pdpKeyOutWebCommand.Parameters["@web_att_desc"].Value = study_att_desc;
            pdpKeyOutWebCommand.Parameters["@web_att_other"].Value = study_att_other;
            pdpKeyOutWebCommand.Parameters["@web_media"].Value = study_media;
            pdpKeyOutWebCommand.Parameters["@web_client"].Value = study_client;
            pdpKeyOutWebCommand.Parameters["@web_devel"].Value = study_devel;
            pdpKeyOutWebCommand.Parameters["@web_incorp"].Value = study_incorp;
            pdpKeyOutWebCommand.Parameters["@web_prog"].Value = study_prog;
            pdpKeyOutWebCommand.Parameters["@web_consult"].Value = study_consult;
            pdpKeyOutWebCommand.Parameters["@web_farmers"].Value = study_farmers;
            pdpKeyOutWebCommand.Parameters["@web_out_other"].Value = study_out_other;
            pdpKeyOutWebCommand.Parameters["@web_out_desc"].Value = study_out_other;
            pdpKeyOutWebCommand.Parameters["@web_description"].Value = study_description;

            pdpKeyOutWebCommand.Parameters["@webseries_title"].Value = short_title;
            if (short_start_date != "")
                pdpKeyOutWebCommand.Parameters["@webseries_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@webseries_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutWebCommand.Parameters["@webseries_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@webseries_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@webseries_ext"].Value = short_ext;
            pdpKeyOutWebCommand.Parameters["@webseries_nrcs"].Value = short_nrcs;
            pdpKeyOutWebCommand.Parameters["@webseries_ngo"].Value = short_ngo;
            pdpKeyOutWebCommand.Parameters["@webseries_st"].Value = short_st;
            pdpKeyOutWebCommand.Parameters["@webseries_pro"].Value = short_pro;
            pdpKeyOutWebCommand.Parameters["@webseries_farm"].Value = short_farm;
            pdpKeyOutWebCommand.Parameters["@webseries_att_desc"].Value = short_att_desc;
            pdpKeyOutWebCommand.Parameters["@webseries_att_other"].Value = short_att_other;
            pdpKeyOutWebCommand.Parameters["@webseries_media"].Value = short_media;
            pdpKeyOutWebCommand.Parameters["@webseries_client"].Value = short_client;
            pdpKeyOutWebCommand.Parameters["@webseries_devel"].Value = short_devel;
            pdpKeyOutWebCommand.Parameters["@webseries_incorp"].Value = short_incorp;
            pdpKeyOutWebCommand.Parameters["@webseries_prog"].Value = short_prog;
            pdpKeyOutWebCommand.Parameters["@webseries_consult"].Value = short_consult;
            pdpKeyOutWebCommand.Parameters["@webseries_farmers"].Value = short_farmers;
            pdpKeyOutWebCommand.Parameters["@webseries_out_other"].Value = short_out_other;
            pdpKeyOutWebCommand.Parameters["@webseries_out_desc"].Value = short_out_other;
            pdpKeyOutWebCommand.Parameters["@webseries_description"].Value = short_description;

            pdpKeyOutWebCommand.Parameters["@webcur_title"].Value = ""; //inter_title;
            if (inter_start_date != "")
                pdpKeyOutWebCommand.Parameters["@webcur_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutWebCommand.Parameters["@webcur_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutWebCommand.Parameters["@webcur_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutWebCommand.Parameters["@webcur_end_date"].Value = null;
            pdpKeyOutWebCommand.Parameters["@webcur_ext"].Value = inter_ext;
            pdpKeyOutWebCommand.Parameters["@webcur_nrcs"].Value = inter_nrcs;
            pdpKeyOutWebCommand.Parameters["@webcur_ngo"].Value = inter_ngo;
            pdpKeyOutWebCommand.Parameters["@webcur_st"].Value = inter_st;
            pdpKeyOutWebCommand.Parameters["@webcur_pro"].Value = inter_pro;
            pdpKeyOutWebCommand.Parameters["@webcur_farm"].Value = inter_farm;
            pdpKeyOutWebCommand.Parameters["@webcur_att_desc"].Value = ""; // inter_att_desc;
            pdpKeyOutWebCommand.Parameters["@webcur_att_other"].Value = ""; // inter_att_other;
            pdpKeyOutWebCommand.Parameters["@webcur_media"].Value = inter_media;
            pdpKeyOutWebCommand.Parameters["@webcur_client"].Value = inter_client;
            pdpKeyOutWebCommand.Parameters["@webcur_devel"].Value = inter_devel;
            pdpKeyOutWebCommand.Parameters["@webcur_incorp"].Value = inter_incorp;
            pdpKeyOutWebCommand.Parameters["@webcur_prog"].Value = inter_prog;
            pdpKeyOutWebCommand.Parameters["@webcur_consult"].Value = inter_consult;
            pdpKeyOutWebCommand.Parameters["@webcur_farmers"].Value = inter_farmers;
            pdpKeyOutWebCommand.Parameters["@webcur_out_other"].Value = ""; // inter_out_other;
            pdpKeyOutWebCommand.Parameters["@webcur_out_desc"].Value = ""; // inter_out_other;
            pdpKeyOutWebCommand.Parameters["@webcur_description"].Value = ""; // inter_description;

            pdpKeyOutWebConnection.Open();
            pdpKeyOutWebCommand.ExecuteScalar();

            pdpKeyOutWebConnection.Close();
            pdpKeyOutWebCommand.Dispose();
            pdpKeyOutWebConnection.Dispose();

            return true;
        }

        public bool UpdatePDPKeyOutWorkshopsToDB()
        {
            string pdpKeyOutWorkshopsSQL;
            string pdpKeyOutWorkshopsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection pdpKeyOutWorkshopsConnection;
            SqlCommand pdpKeyOutWorkshopsCommand;

            pdpKeyOutWorkshopsConnection = new SqlConnection(pdpKeyOutWorkshopsConnString);

            pdpKeyOutWorkshopsSQL = "DaikonpdpKeyOutWorkshopsUpdate";
            pdpKeyOutWorkshopsCommand = new SqlCommand(pdpKeyOutWorkshopsSQL, pdpKeyOutWorkshopsConnection);
            pdpKeyOutWorkshopsCommand.CommandType = CommandType.StoredProcedure;


            pdpKeyOutWorkshopsCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@initiative_num", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@short_description", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@inter_description", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@multi_description", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_session", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_start_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_end_Date", SqlDbType.Date);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_ext", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_nrcs", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_ngo", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_st", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_pro", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_farm", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_att_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_att_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_loc", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_state", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_zip", SqlDbType.VarChar, 5);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_media", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_client", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_devel", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_incorp", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_prog", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_consult", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_farmers", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_out_other", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_out_desc", SqlDbType.NText);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_title", SqlDbType.VarChar, 255);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@extend_description", SqlDbType.NText);

            pdpKeyOutWorkshopsCommand.Parameters["@proj_num"].Value = projNum;
            pdpKeyOutWorkshopsCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            pdpKeyOutWorkshopsCommand.Parameters["@short_session"].Value = short_session;
            if (short_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@short_start_date"].Value = DateTime.Parse(short_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@short_start_date"].Value = null;
            if (short_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@short_end_date"].Value = DateTime.Parse(short_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@short_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@short_ext"].Value = short_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@short_nrcs"].Value = short_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@short_ngo"].Value = short_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@short_st"].Value = short_st;
            pdpKeyOutWorkshopsCommand.Parameters["@short_pro"].Value = short_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@short_farm"].Value = short_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@short_att_desc"].Value = short_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_att_other"].Value = short_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@short_loc"].Value = short_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_state"].Value = short_state;
            pdpKeyOutWorkshopsCommand.Parameters["@short_zip"].Value = short_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@short_media"].Value = short_media;
            pdpKeyOutWorkshopsCommand.Parameters["@short_client"].Value = short_client;
            pdpKeyOutWorkshopsCommand.Parameters["@short_devel"].Value = short_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@short_incorp"].Value = short_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@short_prog"].Value = short_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@short_consult"].Value = short_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@short_farmers"].Value = short_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@short_out_other"].Value = short_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@short_out_desc"].Value = short_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@short_title"].Value = short_title;
            pdpKeyOutWorkshopsCommand.Parameters["@short_description"].Value = short_description;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_session"].Value = inter_session;
            if (inter_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@inter_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@inter_start_date"].Value = null;
            if (inter_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@inter_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@inter_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_ext"].Value = inter_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_nrcs"].Value = inter_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_ngo"].Value = inter_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_st"].Value = inter_st;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_pro"].Value = inter_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_farm"].Value = inter_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_att_desc"].Value = inter_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_att_other"].Value = inter_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_loc"].Value = inter_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_state"].Value = inter_state;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_zip"].Value = inter_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_media"].Value = inter_media;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_client"].Value = inter_client;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_devel"].Value = inter_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_incorp"].Value = inter_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_prog"].Value = inter_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_consult"].Value = inter_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_farmers"].Value = inter_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_out_other"].Value = inter_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_out_desc"].Value = inter_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_title"].Value = inter_title;
            pdpKeyOutWorkshopsCommand.Parameters["@inter_description"].Value = inter_description;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_session"].Value = multi_session;
            if (multi_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@multi_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@multi_start_date"].Value = null;
            if (multi_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@multi_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@multi_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_ext"].Value = multi_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_nrcs"].Value = multi_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_ngo"].Value = multi_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_st"].Value = multi_st;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_pro"].Value = multi_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_farm"].Value = multi_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_att_desc"].Value = multi_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_att_other"].Value = multi_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_loc"].Value = multi_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_state"].Value = multi_state;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_zip"].Value = multi_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_media"].Value = multi_media;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_client"].Value = multi_client;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_devel"].Value = multi_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_incorp"].Value = multi_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_prog"].Value = multi_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_consult"].Value = multi_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_farmers"].Value = multi_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_out_other"].Value = multi_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_out_desc"].Value = multi_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_title"].Value = multi_title;
            pdpKeyOutWorkshopsCommand.Parameters["@multi_description"].Value = multi_description;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_session"].Value = study_session;
            if (study_start_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@extend_start_date"].Value = DateTime.Parse(study_start_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@extend_start_date"].Value = null;
            if (study_end_date != "")
                pdpKeyOutWorkshopsCommand.Parameters["@extend_end_date"].Value = DateTime.Parse(study_end_date);
            else
                pdpKeyOutWorkshopsCommand.Parameters["@extend_end_date"].Value = null;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_ext"].Value = study_ext;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_nrcs"].Value = study_nrcs;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_ngo"].Value = study_ngo;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_st"].Value = study_st;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_pro"].Value = study_pro;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_farm"].Value = study_farm;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_att_desc"].Value = study_att_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_att_other"].Value = study_att_other;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_loc"].Value = study_loc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_state"].Value = study_state;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_zip"].Value = study_zip;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_media"].Value = study_media;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_client"].Value = study_client;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_devel"].Value = study_devel;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_incorp"].Value = study_incorp;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_prog"].Value = study_prog;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_consult"].Value = study_consult;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_farmers"].Value = study_farmers;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_out_other"].Value = study_out_other;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_out_desc"].Value = study_out_desc;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_title"].Value = study_title;
            pdpKeyOutWorkshopsCommand.Parameters["@extend_description"].Value = study_description;

            pdpKeyOutWorkshopsConnection.Open();
            pdpKeyOutWorkshopsCommand.ExecuteScalar();


            pdpKeyOutWorkshopsConnection.Close();
            pdpKeyOutWorkshopsCommand.Dispose();
            pdpKeyOutWorkshopsConnection.Dispose();

            return true;
        }

        public bool UpdatePDPKeyOutFieldToDB()
        {
            string PDPKeyOutFieldSQL;
            string PDPKeyOutFieldConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection PDPKeyOutFieldConnection;
            SqlCommand PDPKeyOutFieldCommand;

            PDPKeyOutFieldConnection = new SqlConnection(PDPKeyOutFieldConnString);

            PDPKeyOutFieldSQL = "DaikonPDPKeyOutFieldUpdate";
            PDPKeyOutFieldCommand = new SqlCommand(PDPKeyOutFieldSQL, PDPKeyOutFieldConnection);
            PDPKeyOutFieldCommand.CommandType = CommandType.StoredProcedure;

            PDPKeyOutFieldCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            PDPKeyOutFieldCommand.Parameters.Add("@initiative_num", SqlDbType.Int);

            PDPKeyOutFieldCommand.Parameters.Add("@inter_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@inter_description", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_session", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@multi_description", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_session", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_title", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_start_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_end_Date", SqlDbType.Date);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_ext", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_nrcs", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_ngo", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_st", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_pro", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_farm", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_att_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_att_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_loc", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_state", SqlDbType.VarChar, 255);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_zip", SqlDbType.VarChar, 5);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_media", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_client", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_devel", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_incorp", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_prog", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_consult", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_farmers", SqlDbType.Int);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_out_other", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_out_desc", SqlDbType.NText);
            PDPKeyOutFieldCommand.Parameters.Add("@extend_description", SqlDbType.NText);

            PDPKeyOutFieldCommand.Parameters["@proj_num"].Value = projNum;
            PDPKeyOutFieldCommand.Parameters["@initiative_num"].Value = pdp_initiative_num;
            PDPKeyOutFieldCommand.Parameters["@inter_title"].Value = inter_title;
            if (inter_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@inter_start_date"].Value = DateTime.Parse(inter_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@inter_start_date"].Value = null;
            if (inter_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@inter_end_date"].Value = DateTime.Parse(inter_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@inter_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@inter_ext"].Value = inter_ext;
            PDPKeyOutFieldCommand.Parameters["@inter_nrcs"].Value = inter_nrcs;
            PDPKeyOutFieldCommand.Parameters["@inter_ngo"].Value = inter_ngo;
            PDPKeyOutFieldCommand.Parameters["@inter_st"].Value = inter_st;
            PDPKeyOutFieldCommand.Parameters["@inter_pro"].Value = inter_pro;
            PDPKeyOutFieldCommand.Parameters["@inter_farm"].Value = inter_farm;
            PDPKeyOutFieldCommand.Parameters["@inter_att_desc"].Value = inter_att_desc;
            PDPKeyOutFieldCommand.Parameters["@inter_att_other"].Value = inter_att_other;
            PDPKeyOutFieldCommand.Parameters["@inter_loc"].Value = inter_loc;
            PDPKeyOutFieldCommand.Parameters["@inter_state"].Value = inter_state;
            PDPKeyOutFieldCommand.Parameters["@inter_zip"].Value = inter_zip;
            PDPKeyOutFieldCommand.Parameters["@inter_media"].Value = inter_media;
            PDPKeyOutFieldCommand.Parameters["@inter_client"].Value = inter_client;
            PDPKeyOutFieldCommand.Parameters["@inter_devel"].Value = inter_devel;
            PDPKeyOutFieldCommand.Parameters["@inter_incorp"].Value = inter_incorp;
            PDPKeyOutFieldCommand.Parameters["@inter_prog"].Value = inter_prog;
            PDPKeyOutFieldCommand.Parameters["@inter_consult"].Value = inter_consult;
            PDPKeyOutFieldCommand.Parameters["@inter_farmers"].Value = inter_farmers;
            PDPKeyOutFieldCommand.Parameters["@inter_out_other"].Value = inter_out_other;
            PDPKeyOutFieldCommand.Parameters["@inter_out_desc"].Value = inter_out_desc;
            PDPKeyOutFieldCommand.Parameters["@inter_description"].Value = inter_description;
            PDPKeyOutFieldCommand.Parameters["@multi_session"].Value = multi_session;
            PDPKeyOutFieldCommand.Parameters["@multi_title"].Value = multi_title;
            if (multi_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@multi_start_date"].Value = DateTime.Parse(multi_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@multi_start_date"].Value = null;
            if (multi_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@multi_end_date"].Value = DateTime.Parse(multi_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@multi_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@multi_ext"].Value = multi_ext;
            PDPKeyOutFieldCommand.Parameters["@multi_nrcs"].Value = multi_nrcs;
            PDPKeyOutFieldCommand.Parameters["@multi_ngo"].Value = multi_ngo;
            PDPKeyOutFieldCommand.Parameters["@multi_st"].Value = multi_st;
            PDPKeyOutFieldCommand.Parameters["@multi_pro"].Value = multi_pro;
            PDPKeyOutFieldCommand.Parameters["@multi_farm"].Value = multi_farm;
            PDPKeyOutFieldCommand.Parameters["@multi_att_desc"].Value = multi_att_desc;
            PDPKeyOutFieldCommand.Parameters["@multi_att_other"].Value = multi_att_other;
            PDPKeyOutFieldCommand.Parameters["@multi_loc"].Value = multi_loc;
            PDPKeyOutFieldCommand.Parameters["@multi_state"].Value = multi_state;
            PDPKeyOutFieldCommand.Parameters["@multi_zip"].Value = multi_zip;
            PDPKeyOutFieldCommand.Parameters["@multi_media"].Value = multi_media;
            PDPKeyOutFieldCommand.Parameters["@multi_client"].Value = multi_client;
            PDPKeyOutFieldCommand.Parameters["@multi_devel"].Value = multi_devel;
            PDPKeyOutFieldCommand.Parameters["@multi_incorp"].Value = multi_incorp;
            PDPKeyOutFieldCommand.Parameters["@multi_prog"].Value = multi_prog;
            PDPKeyOutFieldCommand.Parameters["@multi_consult"].Value = multi_consult;
            PDPKeyOutFieldCommand.Parameters["@multi_farmers"].Value = multi_farmers;
            PDPKeyOutFieldCommand.Parameters["@multi_out_other"].Value = multi_out_other;
            PDPKeyOutFieldCommand.Parameters["@multi_out_desc"].Value = multi_out_desc;
            PDPKeyOutFieldCommand.Parameters["@multi_description"].Value = multi_description;
            PDPKeyOutFieldCommand.Parameters["@extend_session"].Value = study_session;
            PDPKeyOutFieldCommand.Parameters["@extend_title"].Value = study_title;
            if (study_start_date != "")
                PDPKeyOutFieldCommand.Parameters["@extend_start_date"].Value = DateTime.Parse(study_start_date);
            else
                PDPKeyOutFieldCommand.Parameters["@extend_start_date"].Value = null;
            if (study_end_date != "")
                PDPKeyOutFieldCommand.Parameters["@extend_end_date"].Value = DateTime.Parse(study_end_date);
            else
                PDPKeyOutFieldCommand.Parameters["@extend_end_date"].Value = null;
            PDPKeyOutFieldCommand.Parameters["@extend_ext"].Value = study_ext;
            PDPKeyOutFieldCommand.Parameters["@extend_nrcs"].Value = study_nrcs;
            PDPKeyOutFieldCommand.Parameters["@extend_ngo"].Value = study_ngo;
            PDPKeyOutFieldCommand.Parameters["@extend_st"].Value = study_st;
            PDPKeyOutFieldCommand.Parameters["@extend_pro"].Value = study_pro;
            PDPKeyOutFieldCommand.Parameters["@extend_farm"].Value = study_farm;
            PDPKeyOutFieldCommand.Parameters["@extend_att_desc"].Value = study_att_desc;
            PDPKeyOutFieldCommand.Parameters["@extend_att_other"].Value = study_att_other;
            PDPKeyOutFieldCommand.Parameters["@extend_loc"].Value = study_loc;
            PDPKeyOutFieldCommand.Parameters["@extend_state"].Value = study_state;
            PDPKeyOutFieldCommand.Parameters["@extend_zip"].Value = study_zip;
            PDPKeyOutFieldCommand.Parameters["@extend_media"].Value = study_media;
            PDPKeyOutFieldCommand.Parameters["@extend_client"].Value = study_client;
            PDPKeyOutFieldCommand.Parameters["@extend_devel"].Value = study_devel;
            PDPKeyOutFieldCommand.Parameters["@extend_incorp"].Value = study_incorp;
            PDPKeyOutFieldCommand.Parameters["@extend_prog"].Value = study_prog;
            PDPKeyOutFieldCommand.Parameters["@extend_consult"].Value = study_consult;
            PDPKeyOutFieldCommand.Parameters["@extend_farmers"].Value = study_farmers;
            PDPKeyOutFieldCommand.Parameters["@extend_out_other"].Value = study_out_other;
            PDPKeyOutFieldCommand.Parameters["@extend_out_desc"].Value = study_out_desc;
            PDPKeyOutFieldCommand.Parameters["@extend_description"].Value = study_description;

            PDPKeyOutFieldConnection.Open();
            PDPKeyOutFieldCommand.ExecuteScalar();


            PDPKeyOutFieldConnection.Close();
            PDPKeyOutFieldCommand.Dispose();
            PDPKeyOutFieldConnection.Dispose();

            return true;
        }


        public bool getPdpKeyOutStudyByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutStudySQL;
            string pdpKeyOutStudyConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutStudyConnection;
            SqlCommand pdpKeyOutStudyCommand;
            SqlDataReader pdpKeyOutStudyDataReader;

            pdpKeyOutStudyConnection = new SqlConnection(pdpKeyOutStudyConnString);

            pdpKeyOutStudySQL = "DaikonPDPKeyOutStudyByProjNumSessionID";
            pdpKeyOutStudyCommand = new SqlCommand(pdpKeyOutStudySQL, pdpKeyOutStudyConnection);
            pdpKeyOutStudyCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutStudyCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutStudyCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutStudyCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutStudyCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutStudyCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutStudyCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutStudyConnection.Open();
            pdpKeyOutStudyDataReader = pdpKeyOutStudyCommand.ExecuteReader();

            if (pdpKeyOutStudyDataReader.HasRows)
            {
                pdpKeyOutStudyDataReader.Read();
                pdp_key_studyID = int.Parse(pdpKeyOutStudyDataReader["pdp_key_studyID"].ToString());
                projNum = pdpKeyOutStudyDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutStudyDataReader["initiative_num"].ToString());
                study_session = int.Parse(pdpKeyOutStudyDataReader["study_session"].ToString());
                study_title = pdpKeyOutStudyDataReader["study_title"].ToString();         
                study_start_date = pdpKeyOutStudyDataReader["study_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutStudyDataReader["study_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutStudyDataReader["study_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutStudyDataReader["study_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutStudyDataReader["study_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutStudyDataReader["study_st"].ToString());
                study_pro = int.Parse(pdpKeyOutStudyDataReader["study_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutStudyDataReader["study_farm"].ToString());
                study_att_desc = pdpKeyOutStudyDataReader["study_att_desc"].ToString();
                study_att_other = pdpKeyOutStudyDataReader["study_att_other"].ToString();
                study_loc = pdpKeyOutStudyDataReader["study_loc"].ToString();
                study_state = pdpKeyOutStudyDataReader["study_state"].ToString();
                study_zip = pdpKeyOutStudyDataReader["study_zip"].ToString();
                study_media = int.Parse(pdpKeyOutStudyDataReader["study_media"].ToString());
                study_client = int.Parse(pdpKeyOutStudyDataReader["study_client"].ToString());
                study_devel = int.Parse(pdpKeyOutStudyDataReader["study_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutStudyDataReader["study_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutStudyDataReader["study_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutStudyDataReader["study_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutStudyDataReader["study_farmers"].ToString());
                study_out_other = pdpKeyOutStudyDataReader["study_out_other"].ToString();
                study_out_desc = pdpKeyOutStudyDataReader["study_out_desc"].ToString();
                study_description = pdpKeyOutStudyDataReader["study_description"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutStudyConnection.Dispose();

            return result;
        }


        public bool getPdpKeyOutTravelByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutTravelSQL;
            string pdpKeyOutTravelConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutTravelConnection;
            SqlCommand pdpKeyOutTravelCommand;
            SqlDataReader pdpKeyOutTravelDataReader;

            pdpKeyOutTravelConnection = new SqlConnection(pdpKeyOutTravelConnString);

            pdpKeyOutTravelSQL = "DaikonPDPKeyOutTravelByProjNumSessionID";
            pdpKeyOutTravelCommand = new SqlCommand(pdpKeyOutTravelSQL, pdpKeyOutTravelConnection);
            pdpKeyOutTravelCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutTravelCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutTravelCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutTravelCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutTravelCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutTravelCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutTravelCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutTravelConnection.Open();
            pdpKeyOutTravelDataReader = pdpKeyOutTravelCommand.ExecuteReader();

            if (pdpKeyOutTravelDataReader.HasRows)
            {
                pdpKeyOutTravelDataReader.Read();
                pdp_key_TravelID = int.Parse(pdpKeyOutTravelDataReader["pdp_key_TravelID"].ToString());
                projNum = pdpKeyOutTravelDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutTravelDataReader["initiative_num"].ToString());
                study_title = pdpKeyOutTravelDataReader["travel_title"].ToString();
                travel_desc = pdpKeyOutTravelDataReader["travel_desc"].ToString();
                travel_individual1 = pdpKeyOutTravelDataReader["travel_individual1"].ToString();
                travel_individual2 = pdpKeyOutTravelDataReader["travel_individual2"].ToString();
                travel_individual3 = pdpKeyOutTravelDataReader["travel_individual3"].ToString();
                travel_individual4 = pdpKeyOutTravelDataReader["travel_individual4"].ToString();
                travel_individual5 = pdpKeyOutTravelDataReader["travel_individual5"].ToString();
                travel_individual6 = pdpKeyOutTravelDataReader["travel_individual6"].ToString();
                travel_individual7 = pdpKeyOutTravelDataReader["travel_individual7"].ToString();
                travel_individual8 = pdpKeyOutTravelDataReader["travel_individual8"].ToString();
                travel_individual9 = pdpKeyOutTravelDataReader["travel_individual9"].ToString();
                travel_individual10 = pdpKeyOutTravelDataReader["travel_individual10"].ToString();
                travel_individual11 = pdpKeyOutTravelDataReader["travel_individual11"].ToString();
                travel_individual12 = pdpKeyOutTravelDataReader["travel_individual12"].ToString();
                travel_individual_other = pdpKeyOutTravelDataReader["travel_individual_other"].ToString();
                study_session = int.Parse(pdpKeyOutTravelDataReader["travel_scholarship"].ToString());
                study_start_date = pdpKeyOutTravelDataReader["travel_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutTravelDataReader["travel_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutTravelDataReader["travel_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutTravelDataReader["travel_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutTravelDataReader["travel_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutTravelDataReader["travel_st"].ToString());
                study_pro = int.Parse(pdpKeyOutTravelDataReader["travel_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutTravelDataReader["travel_farm"].ToString());
                study_att_desc = pdpKeyOutTravelDataReader["travel_reci_desc"].ToString();
                study_att_other = pdpKeyOutTravelDataReader["travel_other"].ToString();
                study_loc = pdpKeyOutTravelDataReader["travel_loc"].ToString();
                study_state = pdpKeyOutTravelDataReader["travel_state"].ToString();
                study_zip = pdpKeyOutTravelDataReader["travel_zip"].ToString();
                study_media = int.Parse(pdpKeyOutTravelDataReader["travel_media"].ToString());
                study_client = int.Parse(pdpKeyOutTravelDataReader["travel_client"].ToString());
                study_devel = int.Parse(pdpKeyOutTravelDataReader["travel_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutTravelDataReader["travel_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutTravelDataReader["travel_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutTravelDataReader["travel_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutTravelDataReader["travel_farmers"].ToString());
                study_out_other = pdpKeyOutTravelDataReader["travel_out_other"].ToString();
                study_out_desc = pdpKeyOutTravelDataReader["travel_out_desc"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutTravelConnection.Dispose();

            return result;
        }

        public bool getPdpKeyOutOtherByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutOtherSQL;
            string pdpKeyOutOtherConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutOtherConnection;
            SqlCommand pdpKeyOutOtherCommand;
            SqlDataReader pdpKeyOutOtherDataReader;

            pdpKeyOutOtherConnection = new SqlConnection(pdpKeyOutOtherConnString);

            pdpKeyOutOtherSQL = "DaikonPDPKeyOutOtherByProjNumSessionID";
            pdpKeyOutOtherCommand = new SqlCommand(pdpKeyOutOtherSQL, pdpKeyOutOtherConnection);
            pdpKeyOutOtherCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutOtherCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutOtherCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutOtherCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutOtherCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutOtherCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutOtherCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutOtherConnection.Open();
            pdpKeyOutOtherDataReader = pdpKeyOutOtherCommand.ExecuteReader();

            if (pdpKeyOutOtherDataReader.HasRows)
            {
                pdpKeyOutOtherDataReader.Read();
                pdp_key_OtherID = int.Parse(pdpKeyOutOtherDataReader["pdp_key_otherID"].ToString());
                projNum = pdpKeyOutOtherDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutOtherDataReader["initiative_num"].ToString());
                study_title = pdpKeyOutOtherDataReader["other_title"].ToString();
                other_desc = pdpKeyOutOtherDataReader["other_desc"].ToString();
                study_session = int.Parse(pdpKeyOutOtherDataReader["other_num"].ToString());
                study_start_date = pdpKeyOutOtherDataReader["other_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutOtherDataReader["other_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutOtherDataReader["other_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutOtherDataReader["other_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutOtherDataReader["other_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutOtherDataReader["other_st"].ToString());
                study_pro = int.Parse(pdpKeyOutOtherDataReader["other_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutOtherDataReader["other_farm"].ToString());
                study_att_desc = pdpKeyOutOtherDataReader["other_reci_desc"].ToString();
                study_att_other = pdpKeyOutOtherDataReader["other_other"].ToString();
                study_loc = pdpKeyOutOtherDataReader["other_loc"].ToString();
                study_state = pdpKeyOutOtherDataReader["other_state"].ToString();
                study_zip = pdpKeyOutOtherDataReader["other_zip"].ToString();
                study_media = int.Parse(pdpKeyOutOtherDataReader["other_media"].ToString());
                study_client = int.Parse(pdpKeyOutOtherDataReader["other_client"].ToString());
                study_devel = int.Parse(pdpKeyOutOtherDataReader["other_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutOtherDataReader["other_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutOtherDataReader["other_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutOtherDataReader["other_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutOtherDataReader["other_farmers"].ToString());
                study_out_other = pdpKeyOutOtherDataReader["other_out_other"].ToString();
                study_out_desc = pdpKeyOutOtherDataReader["other_out_desc"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutOtherConnection.Dispose();

            return result;
        }

        public bool getPdpKeyOutWebByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutWebSQL;
            string pdpKeyOutWebConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutWebConnection;
            SqlCommand pdpKeyOutWebCommand;
            SqlDataReader pdpKeyOutWebDataReader;

            pdpKeyOutWebConnection = new SqlConnection(pdpKeyOutWebConnString);

            pdpKeyOutWebSQL = "DaikonPDPKeyOutWebByProjNumSessionID";
            pdpKeyOutWebCommand = new SqlCommand(pdpKeyOutWebSQL, pdpKeyOutWebConnection);
            pdpKeyOutWebCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutWebCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutWebCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutWebCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutWebCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutWebCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutWebCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutWebConnection.Open();
            pdpKeyOutWebDataReader = pdpKeyOutWebCommand.ExecuteReader();

            if (pdpKeyOutWebDataReader.HasRows)
            {
                pdpKeyOutWebDataReader.Read();
                pdp_key_WebID = int.Parse(pdpKeyOutWebDataReader["pdp_key_WebID"].ToString());
                projNum = pdpKeyOutWebDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutWebDataReader["initiative_num"].ToString());
                study_session = int.Parse(pdpKeyOutWebDataReader["web_curricula"].ToString());
                study_title = pdpKeyOutWebDataReader["web_title"].ToString();
                study_start_date = pdpKeyOutWebDataReader["web_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutWebDataReader["web_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutWebDataReader["web_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutWebDataReader["web_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutWebDataReader["web_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutWebDataReader["web_st"].ToString());
                study_pro = int.Parse(pdpKeyOutWebDataReader["web_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutWebDataReader["web_farm"].ToString());
                study_att_desc = pdpKeyOutWebDataReader["web_att_desc"].ToString();
                study_att_other = pdpKeyOutWebDataReader["web_att_other"].ToString();
                study_media = int.Parse(pdpKeyOutWebDataReader["web_media"].ToString());
                study_client = int.Parse(pdpKeyOutWebDataReader["web_client"].ToString());
                study_devel = int.Parse(pdpKeyOutWebDataReader["web_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutWebDataReader["web_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutWebDataReader["web_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutWebDataReader["web_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutWebDataReader["web_farmers"].ToString());
                study_out_other = pdpKeyOutWebDataReader["web_out_other"].ToString();
                study_out_desc = pdpKeyOutWebDataReader["web_out_desc"].ToString();
                study_description = pdpKeyOutWebDataReader["web_description"].ToString();

                short_title = pdpKeyOutWebDataReader["webseries_title"].ToString();
                short_start_date = pdpKeyOutWebDataReader["webseries_start_date"].ToString();
                if (short_start_date != "")
                {
                    DateTime short_start_dateTrim = DateTime.Parse(short_start_date);
                    short_start_date = short_start_dateTrim.ToShortDateString();
                }
                short_end_date = pdpKeyOutWebDataReader["webseries_end_date"].ToString();
                if (short_end_date != "")
                {
                    DateTime short_end_dateTrim = DateTime.Parse(short_end_date);
                    short_end_date = short_end_dateTrim.ToShortDateString();
                }
                short_ext = int.Parse(pdpKeyOutWebDataReader["webseries_ext"].ToString());
                short_nrcs = int.Parse(pdpKeyOutWebDataReader["webseries_nrcs"].ToString());
                short_ngo = int.Parse(pdpKeyOutWebDataReader["webseries_ngo"].ToString());
                short_st = int.Parse(pdpKeyOutWebDataReader["webseries_st"].ToString());
                short_pro = int.Parse(pdpKeyOutWebDataReader["webseries_pro"].ToString());
                short_farm = int.Parse(pdpKeyOutWebDataReader["webseries_farm"].ToString());
                short_att_desc = pdpKeyOutWebDataReader["webseries_att_desc"].ToString();
                short_att_other = pdpKeyOutWebDataReader["webseries_att_other"].ToString();
                short_media = int.Parse(pdpKeyOutWebDataReader["webseries_media"].ToString());
                short_client = int.Parse(pdpKeyOutWebDataReader["webseries_client"].ToString());
                short_devel = int.Parse(pdpKeyOutWebDataReader["webseries_devel"].ToString());
                short_incorp = int.Parse(pdpKeyOutWebDataReader["webseries_incorp"].ToString());
                short_prog = int.Parse(pdpKeyOutWebDataReader["webseries_prog"].ToString());
                short_consult = int.Parse(pdpKeyOutWebDataReader["webseries_consult"].ToString());
                short_farmers = int.Parse(pdpKeyOutWebDataReader["webseries_farmers"].ToString());
                short_out_other = pdpKeyOutWebDataReader["webseries_out_other"].ToString();
                short_out_desc = pdpKeyOutWebDataReader["webseries_out_desc"].ToString();
                short_description = pdpKeyOutWebDataReader["webseries_description"].ToString();

                inter_title = pdpKeyOutWebDataReader["webcur_title"].ToString();
                inter_start_date = pdpKeyOutWebDataReader["webcur_start_date"].ToString();
                if (inter_start_date != "")
                {
                    DateTime inter_start_dateTrim = DateTime.Parse(inter_start_date);
                    inter_start_date = inter_start_dateTrim.ToShortDateString();
                }
                inter_end_date = pdpKeyOutWebDataReader["webcur_end_date"].ToString();
                if (inter_end_date != "")
                {
                    DateTime inter_end_dateTrim = DateTime.Parse(inter_end_date);
                    inter_end_date = inter_end_dateTrim.ToShortDateString();
                }
                inter_ext = int.Parse(pdpKeyOutWebDataReader["webcur_ext"].ToString());
                inter_nrcs = int.Parse(pdpKeyOutWebDataReader["webcur_nrcs"].ToString());
                inter_ngo = int.Parse(pdpKeyOutWebDataReader["webcur_ngo"].ToString());
                inter_st = int.Parse(pdpKeyOutWebDataReader["webcur_st"].ToString());
                inter_pro = int.Parse(pdpKeyOutWebDataReader["webcur_pro"].ToString());
                inter_farm = int.Parse(pdpKeyOutWebDataReader["webcur_farm"].ToString());
                inter_att_desc = pdpKeyOutWebDataReader["webcur_att_desc"].ToString();
                inter_att_other = pdpKeyOutWebDataReader["webcur_att_other"].ToString();
                inter_media = int.Parse(pdpKeyOutWebDataReader["webcur_media"].ToString());
                inter_client = int.Parse(pdpKeyOutWebDataReader["webcur_client"].ToString());
                inter_devel = int.Parse(pdpKeyOutWebDataReader["webcur_devel"].ToString());
                inter_incorp = int.Parse(pdpKeyOutWebDataReader["webcur_incorp"].ToString());
                inter_prog = int.Parse(pdpKeyOutWebDataReader["webcur_prog"].ToString());
                inter_consult = int.Parse(pdpKeyOutWebDataReader["webcur_consult"].ToString());
                inter_farmers = int.Parse(pdpKeyOutWebDataReader["webcur_farmers"].ToString());
                inter_out_other = pdpKeyOutWebDataReader["webcur_out_other"].ToString();
                inter_out_desc = pdpKeyOutWebDataReader["webcur_out_desc"].ToString();
                inter_description = pdpKeyOutWebDataReader["webcur_description"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutWebConnection.Dispose();
            return result;
        }

        public bool getPdpKeyOutWorkshopsByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutWorkshopsSQL;
            string pdpKeyOutWorkshopsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutWorkshopsConnection;
            SqlCommand pdpKeyOutWorkshopsCommand;
            SqlDataReader pdpKeyOutWorkshopsDataReader;

            pdpKeyOutWorkshopsConnection = new SqlConnection(pdpKeyOutWorkshopsConnString);

            pdpKeyOutWorkshopsSQL = "DaikonpdpKeyOutWorkshopsByProjNumSessionID";
            pdpKeyOutWorkshopsCommand = new SqlCommand(pdpKeyOutWorkshopsSQL, pdpKeyOutWorkshopsConnection);
            pdpKeyOutWorkshopsCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutWorkshopsCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutWorkshopsCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutWorkshopsCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutWorkshopsCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutWorkshopsCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutWorkshopsConnection.Open();
            pdpKeyOutWorkshopsDataReader = pdpKeyOutWorkshopsCommand.ExecuteReader();

            if (pdpKeyOutWorkshopsDataReader.HasRows)
            {
                pdpKeyOutWorkshopsDataReader.Read();
                pdp_key_workID = int.Parse(pdpKeyOutWorkshopsDataReader["pdp_key_workID"].ToString());
                projNum = pdpKeyOutWorkshopsDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutWorkshopsDataReader["initiative_num"].ToString());
                short_session = int.Parse(pdpKeyOutWorkshopsDataReader["short_session"].ToString());
                short_start_date = pdpKeyOutWorkshopsDataReader["short_start_date"].ToString();
                if (short_start_date != "")
                {
                    DateTime short_start_dateTrim = DateTime.Parse(short_start_date);
                    short_start_date = short_start_dateTrim.ToShortDateString();
                }
                short_end_date = pdpKeyOutWorkshopsDataReader["short_end_date"].ToString();
                if (short_end_date != "")
                {
                    DateTime short_end_dateTrim = DateTime.Parse(short_end_date);
                    short_end_date = short_end_dateTrim.ToShortDateString();
                }
                short_ext = int.Parse(pdpKeyOutWorkshopsDataReader["short_ext"].ToString());
                short_nrcs = int.Parse(pdpKeyOutWorkshopsDataReader["short_nrcs"].ToString());
                short_ngo = int.Parse(pdpKeyOutWorkshopsDataReader["short_ngo"].ToString());
                short_st = int.Parse(pdpKeyOutWorkshopsDataReader["short_st"].ToString());
                short_pro = int.Parse(pdpKeyOutWorkshopsDataReader["short_pro"].ToString());
                short_farm = int.Parse(pdpKeyOutWorkshopsDataReader["short_farm"].ToString());
                short_att_desc = pdpKeyOutWorkshopsDataReader["short_att_desc"].ToString();
                short_att_other = pdpKeyOutWorkshopsDataReader["short_att_other"].ToString();
                short_loc = pdpKeyOutWorkshopsDataReader["short_loc"].ToString();
                short_state = pdpKeyOutWorkshopsDataReader["short_state"].ToString();
                short_zip = pdpKeyOutWorkshopsDataReader["short_zip"].ToString();
                short_media = int.Parse(pdpKeyOutWorkshopsDataReader["short_media"].ToString());
                short_client = int.Parse(pdpKeyOutWorkshopsDataReader["short_client"].ToString());
                short_devel = int.Parse(pdpKeyOutWorkshopsDataReader["short_devel"].ToString());
                short_incorp = int.Parse(pdpKeyOutWorkshopsDataReader["short_incorp"].ToString());
                short_prog = int.Parse(pdpKeyOutWorkshopsDataReader["short_prog"].ToString());
                short_consult = int.Parse(pdpKeyOutWorkshopsDataReader["short_consult"].ToString());
                short_farmers = int.Parse(pdpKeyOutWorkshopsDataReader["short_farmers"].ToString());
                short_out_other = pdpKeyOutWorkshopsDataReader["short_out_other"].ToString();
                short_out_desc = pdpKeyOutWorkshopsDataReader["short_out_desc"].ToString();
                short_title = pdpKeyOutWorkshopsDataReader["short_title"].ToString();
                short_description = pdpKeyOutWorkshopsDataReader["short_description"].ToString();

                inter_session = int.Parse(pdpKeyOutWorkshopsDataReader["inter_session"].ToString());
                inter_start_date = pdpKeyOutWorkshopsDataReader["inter_start_date"].ToString();
                if (inter_start_date != "")
                {
                    DateTime inter_start_dateTrim = DateTime.Parse(inter_start_date);
                    inter_start_date = inter_start_dateTrim.ToShortDateString();
                }
                inter_end_date = pdpKeyOutWorkshopsDataReader["inter_end_date"].ToString();
                if (inter_end_date != "")
                {
                    DateTime inter_end_dateTrim = DateTime.Parse(inter_end_date);
                    inter_end_date = inter_end_dateTrim.ToShortDateString();
                }
                inter_ext = int.Parse(pdpKeyOutWorkshopsDataReader["inter_ext"].ToString());
                inter_nrcs = int.Parse(pdpKeyOutWorkshopsDataReader["inter_nrcs"].ToString());
                inter_ngo = int.Parse(pdpKeyOutWorkshopsDataReader["inter_ngo"].ToString());
                inter_st = int.Parse(pdpKeyOutWorkshopsDataReader["inter_st"].ToString());
                inter_pro = int.Parse(pdpKeyOutWorkshopsDataReader["inter_pro"].ToString());
                inter_farm = int.Parse(pdpKeyOutWorkshopsDataReader["inter_farm"].ToString());
                inter_att_desc = pdpKeyOutWorkshopsDataReader["inter_att_desc"].ToString();
                inter_att_other = pdpKeyOutWorkshopsDataReader["inter_att_other"].ToString();
                inter_loc = pdpKeyOutWorkshopsDataReader["inter_loc"].ToString();
                inter_state = pdpKeyOutWorkshopsDataReader["inter_state"].ToString();
                inter_zip = pdpKeyOutWorkshopsDataReader["inter_zip"].ToString();
                inter_media = int.Parse(pdpKeyOutWorkshopsDataReader["inter_media"].ToString());
                inter_client = int.Parse(pdpKeyOutWorkshopsDataReader["inter_client"].ToString());
                inter_devel = int.Parse(pdpKeyOutWorkshopsDataReader["inter_devel"].ToString());
                inter_incorp = int.Parse(pdpKeyOutWorkshopsDataReader["inter_incorp"].ToString());
                inter_prog = int.Parse(pdpKeyOutWorkshopsDataReader["inter_prog"].ToString());
                inter_consult = int.Parse(pdpKeyOutWorkshopsDataReader["inter_consult"].ToString());
                inter_farmers = int.Parse(pdpKeyOutWorkshopsDataReader["inter_farmers"].ToString());
                inter_out_other = pdpKeyOutWorkshopsDataReader["inter_out_other"].ToString();
                inter_out_desc = pdpKeyOutWorkshopsDataReader["inter_out_desc"].ToString();
                inter_title = pdpKeyOutWorkshopsDataReader["inter_title"].ToString();
                inter_description = pdpKeyOutWorkshopsDataReader["inter_description"].ToString();

                multi_session = int.Parse(pdpKeyOutWorkshopsDataReader["multi_session"].ToString());
                multi_start_date = pdpKeyOutWorkshopsDataReader["multi_start_date"].ToString();
                if (multi_start_date != "")
                {
                    DateTime multi_start_dateTrim = DateTime.Parse(multi_start_date);
                    multi_start_date = multi_start_dateTrim.ToShortDateString();
                }
                multi_end_date = pdpKeyOutWorkshopsDataReader["multi_end_date"].ToString();
                if (multi_end_date != "")
                {
                    DateTime multi_end_dateTrim = DateTime.Parse(multi_end_date);
                    multi_end_date = multi_end_dateTrim.ToShortDateString();
                }
                multi_ext = int.Parse(pdpKeyOutWorkshopsDataReader["multi_ext"].ToString());
                multi_nrcs = int.Parse(pdpKeyOutWorkshopsDataReader["multi_nrcs"].ToString());
                multi_ngo = int.Parse(pdpKeyOutWorkshopsDataReader["multi_ngo"].ToString());
                multi_st = int.Parse(pdpKeyOutWorkshopsDataReader["multi_st"].ToString());
                multi_pro = int.Parse(pdpKeyOutWorkshopsDataReader["multi_pro"].ToString());
                multi_farm = int.Parse(pdpKeyOutWorkshopsDataReader["multi_farm"].ToString());
                multi_att_desc = pdpKeyOutWorkshopsDataReader["multi_att_desc"].ToString();
                multi_att_other = pdpKeyOutWorkshopsDataReader["multi_att_other"].ToString();
                multi_loc = pdpKeyOutWorkshopsDataReader["multi_loc"].ToString();
                multi_state = pdpKeyOutWorkshopsDataReader["multi_state"].ToString();
                multi_zip = pdpKeyOutWorkshopsDataReader["multi_zip"].ToString();
                multi_media = int.Parse(pdpKeyOutWorkshopsDataReader["multi_media"].ToString());
                multi_client = int.Parse(pdpKeyOutWorkshopsDataReader["multi_client"].ToString());
                multi_devel = int.Parse(pdpKeyOutWorkshopsDataReader["multi_devel"].ToString());
                multi_incorp = int.Parse(pdpKeyOutWorkshopsDataReader["multi_incorp"].ToString());
                multi_prog = int.Parse(pdpKeyOutWorkshopsDataReader["multi_prog"].ToString());
                multi_consult = int.Parse(pdpKeyOutWorkshopsDataReader["multi_consult"].ToString());
                multi_farmers = int.Parse(pdpKeyOutWorkshopsDataReader["multi_farmers"].ToString());
                multi_out_other = pdpKeyOutWorkshopsDataReader["multi_out_other"].ToString();
                multi_out_desc = pdpKeyOutWorkshopsDataReader["multi_out_desc"].ToString();
                multi_title = pdpKeyOutWorkshopsDataReader["multi_title"].ToString();
                multi_description = pdpKeyOutWorkshopsDataReader["multi_description"].ToString();

                study_session = int.Parse(pdpKeyOutWorkshopsDataReader["extend_session"].ToString());
                study_start_date = pdpKeyOutWorkshopsDataReader["extend_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutWorkshopsDataReader["extend_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutWorkshopsDataReader["extend_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutWorkshopsDataReader["extend_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutWorkshopsDataReader["extend_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutWorkshopsDataReader["extend_st"].ToString());
                study_pro = int.Parse(pdpKeyOutWorkshopsDataReader["extend_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutWorkshopsDataReader["extend_farm"].ToString());
                study_att_desc = pdpKeyOutWorkshopsDataReader["extend_att_desc"].ToString();
                study_att_other = pdpKeyOutWorkshopsDataReader["extend_att_other"].ToString();
                study_loc = pdpKeyOutWorkshopsDataReader["extend_loc"].ToString();
                study_state = pdpKeyOutWorkshopsDataReader["extend_state"].ToString();
                study_zip = pdpKeyOutWorkshopsDataReader["extend_zip"].ToString();
                study_media = int.Parse(pdpKeyOutWorkshopsDataReader["extend_media"].ToString());
                study_client = int.Parse(pdpKeyOutWorkshopsDataReader["extend_client"].ToString());
                study_devel = int.Parse(pdpKeyOutWorkshopsDataReader["extend_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutWorkshopsDataReader["extend_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutWorkshopsDataReader["extend_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutWorkshopsDataReader["extend_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutWorkshopsDataReader["extend_farmers"].ToString());
                study_out_other = pdpKeyOutWorkshopsDataReader["extend_out_other"].ToString();
                study_out_desc = pdpKeyOutWorkshopsDataReader["extend_out_desc"].ToString();
                study_title = pdpKeyOutWorkshopsDataReader["extend_title"].ToString();
                study_description = pdpKeyOutWorkshopsDataReader["extend_description"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutWorkshopsConnection.Dispose();

            return result;
        }

        public bool getPdpKeyOutGrantsByProjNum(string pdp_projnum, int pdp_initnum, int pdp_sessnum)
        {
            bool result = false;
            string pdpKeyOutGrantsSQL;
            string pdpKeyOutGrantsConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutGrantsConnection;
            SqlCommand pdpKeyOutGrantsCommand;
            SqlDataReader pdpKeyOutGrantsDataReader;

            pdpKeyOutGrantsConnection = new SqlConnection(pdpKeyOutGrantsConnString);

            pdpKeyOutGrantsSQL = "DaikonPDPKeyOutGrantsByProjNumSessionID";
            pdpKeyOutGrantsCommand = new SqlCommand(pdpKeyOutGrantsSQL, pdpKeyOutGrantsConnection);
            pdpKeyOutGrantsCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutGrantsCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutGrantsCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutGrantsCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutGrantsCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutGrantsCommand.Parameters["@pdp_initID"].Value = pdp_initnum;
            pdpKeyOutGrantsCommand.Parameters["@pdp_sessID"].Value = pdp_sessnum;

            pdpKeyOutGrantsConnection.Open();
            pdpKeyOutGrantsDataReader = pdpKeyOutGrantsCommand.ExecuteReader();

            if (pdpKeyOutGrantsDataReader.HasRows)
            {
                pdpKeyOutGrantsDataReader.Read();
                pdp_key_grantID = int.Parse(pdpKeyOutGrantsDataReader["pdp_key_grantID"].ToString());
                projNum = pdpKeyOutGrantsDataReader["proj_num"].ToString();
                pdp_initiative_num = int.Parse(pdpKeyOutGrantsDataReader["initiative_num"].ToString());
                short_session = int.Parse(pdpKeyOutGrantsDataReader["demo_session"].ToString());
                short_title = pdpKeyOutGrantsDataReader["demo_title"].ToString();
                short_description = pdpKeyOutGrantsDataReader["demo_description"].ToString();
                short_start_date = pdpKeyOutGrantsDataReader["demo_start_date"].ToString();
                if (short_start_date != "")
                {
                    DateTime short_start_dateTrim = DateTime.Parse(short_start_date);
                    short_start_date = short_start_dateTrim.ToShortDateString();
                }
                short_end_date = pdpKeyOutGrantsDataReader["demo_end_date"].ToString();
                if (short_end_date != "")
                {
                    DateTime short_end_dateTrim = DateTime.Parse(short_end_date);
                    short_end_date = short_end_dateTrim.ToShortDateString();
                }
                short_ext = int.Parse(pdpKeyOutGrantsDataReader["demo_ext"].ToString());
                short_nrcs = int.Parse(pdpKeyOutGrantsDataReader["demo_nrcs"].ToString());
                short_ngo = int.Parse(pdpKeyOutGrantsDataReader["demo_ngo"].ToString());
                short_st = int.Parse(pdpKeyOutGrantsDataReader["demo_st"].ToString());
                short_pro = int.Parse(pdpKeyOutGrantsDataReader["demo_pro"].ToString());
                short_farm = int.Parse(pdpKeyOutGrantsDataReader["demo_farm"].ToString());
                short_att_desc = pdpKeyOutGrantsDataReader["demo_att_desc"].ToString();
                short_att_other = pdpKeyOutGrantsDataReader["demo_att_other"].ToString();
                short_loc = pdpKeyOutGrantsDataReader["demo_loc"].ToString();
                short_state = pdpKeyOutGrantsDataReader["demo_state"].ToString();
                short_zip = pdpKeyOutGrantsDataReader["demo_zip"].ToString();
                short_media = int.Parse(pdpKeyOutGrantsDataReader["demo_media"].ToString());
                short_client = int.Parse(pdpKeyOutGrantsDataReader["demo_client"].ToString());
                short_devel = int.Parse(pdpKeyOutGrantsDataReader["demo_devel"].ToString());
                short_incorp = int.Parse(pdpKeyOutGrantsDataReader["demo_incorp"].ToString());
                short_prog = int.Parse(pdpKeyOutGrantsDataReader["demo_prog"].ToString());
                short_consult = int.Parse(pdpKeyOutGrantsDataReader["demo_consult"].ToString());
                short_farmers = int.Parse(pdpKeyOutGrantsDataReader["demo_farmers"].ToString());
                short_out_other = pdpKeyOutGrantsDataReader["demo_out_other"].ToString();
                short_out_desc = pdpKeyOutGrantsDataReader["demo_out_desc"].ToString();

                inter_session = int.Parse(pdpKeyOutGrantsDataReader["work_session"].ToString());
                inter_title = pdpKeyOutGrantsDataReader["work_title"].ToString();
                inter_description = pdpKeyOutGrantsDataReader["work_description"].ToString();
                inter_start_date = pdpKeyOutGrantsDataReader["work_start_date"].ToString();
                if (inter_start_date != "")
                {
                    DateTime inter_start_dateTrim = DateTime.Parse(inter_start_date);
                    inter_start_date = inter_start_dateTrim.ToShortDateString();
                }
                inter_end_date = pdpKeyOutGrantsDataReader["work_end_date"].ToString();
                if (inter_end_date != "")
                {
                    DateTime inter_end_dateTrim = DateTime.Parse(inter_end_date);
                    inter_end_date = inter_end_dateTrim.ToShortDateString();
                }
                inter_ext = int.Parse(pdpKeyOutGrantsDataReader["work_ext"].ToString());
                inter_nrcs = int.Parse(pdpKeyOutGrantsDataReader["work_nrcs"].ToString());
                inter_ngo = int.Parse(pdpKeyOutGrantsDataReader["work_ngo"].ToString());
                inter_st = int.Parse(pdpKeyOutGrantsDataReader["work_st"].ToString());
                inter_pro = int.Parse(pdpKeyOutGrantsDataReader["work_pro"].ToString());
                inter_farm = int.Parse(pdpKeyOutGrantsDataReader["work_farm"].ToString());
                inter_att_desc = pdpKeyOutGrantsDataReader["work_att_desc"].ToString();
                inter_att_other = pdpKeyOutGrantsDataReader["work_att_other"].ToString();
                inter_loc = pdpKeyOutGrantsDataReader["work_loc"].ToString();
                inter_state = pdpKeyOutGrantsDataReader["work_state"].ToString();
                inter_zip = pdpKeyOutGrantsDataReader["work_zip"].ToString();
                inter_media = int.Parse(pdpKeyOutGrantsDataReader["work_media"].ToString());
                inter_client = int.Parse(pdpKeyOutGrantsDataReader["work_client"].ToString());
                inter_devel = int.Parse(pdpKeyOutGrantsDataReader["work_devel"].ToString());
                inter_incorp = int.Parse(pdpKeyOutGrantsDataReader["work_incorp"].ToString());
                inter_prog = int.Parse(pdpKeyOutGrantsDataReader["work_prog"].ToString());
                inter_consult = int.Parse(pdpKeyOutGrantsDataReader["work_consult"].ToString());
                inter_farmers = int.Parse(pdpKeyOutGrantsDataReader["work_farmers"].ToString());
                inter_out_other = pdpKeyOutGrantsDataReader["work_out_other"].ToString();
                inter_out_desc = pdpKeyOutGrantsDataReader["work_out_desc"].ToString();

                multi_session = int.Parse(pdpKeyOutGrantsDataReader["tour_session"].ToString());
                multi_title = pdpKeyOutGrantsDataReader["tour_title"].ToString();
                multi_description = pdpKeyOutGrantsDataReader["tour_description"].ToString();
                multi_start_date = pdpKeyOutGrantsDataReader["tour_start_date"].ToString();
                if (multi_start_date != "")
                {
                    DateTime multi_start_dateTrim = DateTime.Parse(multi_start_date);
                    multi_start_date = multi_start_dateTrim.ToShortDateString();
                }
                multi_end_date = pdpKeyOutGrantsDataReader["tour_end_date"].ToString();
                if (multi_end_date != "")
                {
                    DateTime multi_end_dateTrim = DateTime.Parse(multi_end_date);
                    multi_end_date = multi_end_dateTrim.ToShortDateString();
                }
                multi_ext = int.Parse(pdpKeyOutGrantsDataReader["tour_ext"].ToString());
                multi_nrcs = int.Parse(pdpKeyOutGrantsDataReader["tour_nrcs"].ToString());
                multi_ngo = int.Parse(pdpKeyOutGrantsDataReader["tour_ngo"].ToString());
                multi_st = int.Parse(pdpKeyOutGrantsDataReader["tour_st"].ToString());
                multi_pro = int.Parse(pdpKeyOutGrantsDataReader["tour_pro"].ToString());
                multi_farm = int.Parse(pdpKeyOutGrantsDataReader["tour_farm"].ToString());
                multi_att_desc = pdpKeyOutGrantsDataReader["tour_att_desc"].ToString();
                multi_att_other = pdpKeyOutGrantsDataReader["tour_att_other"].ToString();
                multi_loc = pdpKeyOutGrantsDataReader["tour_loc"].ToString();
                multi_state = pdpKeyOutGrantsDataReader["tour_state"].ToString();
                multi_zip = pdpKeyOutGrantsDataReader["tour_zip"].ToString();
                multi_media = int.Parse(pdpKeyOutGrantsDataReader["tour_media"].ToString());
                multi_client = int.Parse(pdpKeyOutGrantsDataReader["tour_client"].ToString());
                multi_devel = int.Parse(pdpKeyOutGrantsDataReader["tour_devel"].ToString());
                multi_incorp = int.Parse(pdpKeyOutGrantsDataReader["tour_incorp"].ToString());
                multi_prog = int.Parse(pdpKeyOutGrantsDataReader["tour_prog"].ToString());
                multi_consult = int.Parse(pdpKeyOutGrantsDataReader["tour_consult"].ToString());
                multi_farmers = int.Parse(pdpKeyOutGrantsDataReader["tour_farmers"].ToString());
                multi_out_other = pdpKeyOutGrantsDataReader["tour_out_other"].ToString();
                multi_out_desc = pdpKeyOutGrantsDataReader["tour_out_desc"].ToString();


                study_session = int.Parse(pdpKeyOutGrantsDataReader["cur_session"].ToString());
                study_title = pdpKeyOutGrantsDataReader["cur_title"].ToString();
                study_description = pdpKeyOutGrantsDataReader["cur_description"].ToString();
                study_start_date = pdpKeyOutGrantsDataReader["cur_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutGrantsDataReader["cur_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutGrantsDataReader["cur_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutGrantsDataReader["cur_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutGrantsDataReader["cur_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutGrantsDataReader["cur_st"].ToString());
                study_pro = int.Parse(pdpKeyOutGrantsDataReader["cur_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutGrantsDataReader["cur_farm"].ToString());
                study_att_desc = pdpKeyOutGrantsDataReader["cur_att_desc"].ToString();
                study_att_other = pdpKeyOutGrantsDataReader["cur_att_other"].ToString();
                study_loc = pdpKeyOutGrantsDataReader["cur_loc"].ToString();
                study_state = pdpKeyOutGrantsDataReader["cur_state"].ToString();
                study_zip = pdpKeyOutGrantsDataReader["cur_zip"].ToString();
                study_media = int.Parse(pdpKeyOutGrantsDataReader["cur_media"].ToString());
                study_client = int.Parse(pdpKeyOutGrantsDataReader["cur_client"].ToString());
                study_devel = int.Parse(pdpKeyOutGrantsDataReader["cur_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutGrantsDataReader["cur_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutGrantsDataReader["cur_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutGrantsDataReader["cur_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutGrantsDataReader["cur_farmers"].ToString());
                study_out_other = pdpKeyOutGrantsDataReader["cur_out_other"].ToString();
                study_out_desc = pdpKeyOutGrantsDataReader["cur_out_desc"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutGrantsConnection.Dispose();

            return result;
        }

        public bool getPdpKeyOutFieldByProjNum(string pdp_projnum)
        {
            bool result = false;
            string pdpKeyOutFieldSQL;
            string pdpKeyOutFieldConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutFieldConnection;
            SqlCommand pdpKeyOutFieldCommand;
            SqlDataReader pdpKeyOutFieldDataReader;

            pdpKeyOutFieldConnection = new SqlConnection(pdpKeyOutFieldConnString);

            pdpKeyOutFieldSQL = "DaikonpdpKeyOutFieldByProjNum";
            pdpKeyOutFieldCommand = new SqlCommand(pdpKeyOutFieldSQL, pdpKeyOutFieldConnection);
            pdpKeyOutFieldCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutFieldCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);

            pdpKeyOutFieldCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;

            pdpKeyOutFieldConnection.Open();
            pdpKeyOutFieldDataReader = pdpKeyOutFieldCommand.ExecuteReader();

            if (pdpKeyOutFieldDataReader.HasRows)
            {
                pdpKeyOutFieldDataReader.Read();
                pdp_key_fieldID = int.Parse(pdpKeyOutFieldDataReader["pdp_key_fieldID"].ToString());
                projNum = pdpKeyOutFieldDataReader["proj_num"].ToString();

                multi_session = int.Parse(pdpKeyOutFieldDataReader["multi_session"].ToString());
                multi_ext = int.Parse(pdpKeyOutFieldDataReader["multi_ext"].ToString());
                multi_nrcs = int.Parse(pdpKeyOutFieldDataReader["multi_nrcs"].ToString());
                multi_ngo = int.Parse(pdpKeyOutFieldDataReader["multi_ngo"].ToString());
                multi_st = int.Parse(pdpKeyOutFieldDataReader["multi_st"].ToString());
                multi_pro = int.Parse(pdpKeyOutFieldDataReader["multi_pro"].ToString());
                multi_farm = int.Parse(pdpKeyOutFieldDataReader["multi_farm"].ToString());
                multi_att_desc = pdpKeyOutFieldDataReader["multi_att_desc"].ToString();
                multi_att_other = pdpKeyOutFieldDataReader["multi_att_other"].ToString();
                multi_loc = pdpKeyOutFieldDataReader["multi_loc"].ToString();
                multi_state = pdpKeyOutFieldDataReader["multi_state"].ToString();
                multi_zip = pdpKeyOutFieldDataReader["multi_zip"].ToString();
                multi_media = int.Parse(pdpKeyOutFieldDataReader["multi_media"].ToString());
                multi_client = int.Parse(pdpKeyOutFieldDataReader["multi_client"].ToString());
                multi_devel = int.Parse(pdpKeyOutFieldDataReader["multi_devel"].ToString());
                multi_incorp = int.Parse(pdpKeyOutFieldDataReader["multi_incorp"].ToString());
                multi_prog = int.Parse(pdpKeyOutFieldDataReader["multi_prog"].ToString());
                multi_consult = int.Parse(pdpKeyOutFieldDataReader["multi_consult"].ToString());
                multi_farmers = int.Parse(pdpKeyOutFieldDataReader["multi_farmers"].ToString());
                multi_out_other = pdpKeyOutFieldDataReader["multi_out_other"].ToString();
                multi_out_desc = pdpKeyOutFieldDataReader["multi_out_desc"].ToString();


                study_session = int.Parse(pdpKeyOutFieldDataReader["extend_session"].ToString());
                study_ext = int.Parse(pdpKeyOutFieldDataReader["extend_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutFieldDataReader["extend_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutFieldDataReader["extend_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutFieldDataReader["extend_st"].ToString());
                study_pro = int.Parse(pdpKeyOutFieldDataReader["extend_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutFieldDataReader["extend_farm"].ToString());
                study_att_desc = pdpKeyOutFieldDataReader["extend_att_desc"].ToString();
                study_att_other = pdpKeyOutFieldDataReader["extend_att_other"].ToString();
                study_loc = pdpKeyOutFieldDataReader["extend_loc"].ToString();
                study_state = pdpKeyOutFieldDataReader["extend_state"].ToString();
                study_zip = pdpKeyOutFieldDataReader["extend_zip"].ToString();
                study_media = int.Parse(pdpKeyOutFieldDataReader["extend_media"].ToString());
                study_client = int.Parse(pdpKeyOutFieldDataReader["extend_client"].ToString());
                study_devel = int.Parse(pdpKeyOutFieldDataReader["extend_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutFieldDataReader["extend_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutFieldDataReader["extend_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutFieldDataReader["extend_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutFieldDataReader["extend_farmers"].ToString());
                study_out_other = pdpKeyOutFieldDataReader["extend_out_other"].ToString();
                study_out_desc = pdpKeyOutFieldDataReader["extend_out_desc"].ToString();

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutFieldConnection.Dispose();

            return result;
        }

        public bool getPdpKeyOutFieldByProjNum(string pdp_projnum, int pdp_initid, int pdp_sessid)
        {
            bool result = false;
            string pdpKeyOutFieldSQL;
            string pdpKeyOutFieldConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection pdpKeyOutFieldConnection;
            SqlCommand pdpKeyOutFieldCommand;
            SqlDataReader pdpKeyOutFieldDataReader;

            pdpKeyOutFieldConnection = new SqlConnection(pdpKeyOutFieldConnString);

            pdpKeyOutFieldSQL = "DaikonPDPKeyOutFieldByProjNumSessionID";
            pdpKeyOutFieldCommand = new SqlCommand(pdpKeyOutFieldSQL, pdpKeyOutFieldConnection);
            pdpKeyOutFieldCommand.CommandType = CommandType.StoredProcedure;
            pdpKeyOutFieldCommand.Parameters.Add("@pdp_projnum", SqlDbType.VarChar, 50);
            pdpKeyOutFieldCommand.Parameters.Add("@pdp_initID", SqlDbType.Int);
            pdpKeyOutFieldCommand.Parameters.Add("@pdp_sessID", SqlDbType.Int);

            pdpKeyOutFieldCommand.Parameters["@pdp_projnum"].Value = pdp_projnum;
            pdpKeyOutFieldCommand.Parameters["@pdp_initID"].Value = pdp_initid;
            pdpKeyOutFieldCommand.Parameters["@pdp_sessID"].Value = pdp_sessid;

            pdpKeyOutFieldConnection.Open();
            pdpKeyOutFieldDataReader = pdpKeyOutFieldCommand.ExecuteReader();

            if (pdpKeyOutFieldDataReader.HasRows)
            {
                pdpKeyOutFieldDataReader.Read();
                pdp_key_fieldID = int.Parse(pdpKeyOutFieldDataReader["pdp_key_fieldID"].ToString());
                projNum = pdpKeyOutFieldDataReader["proj_num"].ToString();

                inter_title = pdpKeyOutFieldDataReader["inter_title"].ToString();
                inter_start_date = pdpKeyOutFieldDataReader["inter_start_date"].ToString();
                if (inter_start_date != "")
                {
                    DateTime inter_start_dateTrim = DateTime.Parse(inter_start_date);
                    inter_start_date = inter_start_dateTrim.ToShortDateString();
                }
                inter_end_date = pdpKeyOutFieldDataReader["inter_end_date"].ToString();
                if (inter_end_date != "")
                {
                    DateTime inter_end_dateTrim = DateTime.Parse(inter_end_date);
                    inter_end_date = inter_end_dateTrim.ToShortDateString();
                }
                inter_ext = int.Parse(pdpKeyOutFieldDataReader["inter_ext"].ToString());
                inter_nrcs = int.Parse(pdpKeyOutFieldDataReader["inter_nrcs"].ToString());
                inter_ngo = int.Parse(pdpKeyOutFieldDataReader["inter_ngo"].ToString());
                inter_st = int.Parse(pdpKeyOutFieldDataReader["inter_st"].ToString());
                inter_pro = int.Parse(pdpKeyOutFieldDataReader["inter_pro"].ToString());
                inter_farm = int.Parse(pdpKeyOutFieldDataReader["inter_farm"].ToString());
                inter_att_desc = pdpKeyOutFieldDataReader["inter_att_desc"].ToString();
                inter_att_other = pdpKeyOutFieldDataReader["inter_att_other"].ToString();
                inter_loc = pdpKeyOutFieldDataReader["inter_loc"].ToString();
                inter_state = pdpKeyOutFieldDataReader["inter_state"].ToString();
                inter_zip = pdpKeyOutFieldDataReader["inter_zip"].ToString();
                inter_media = int.Parse(pdpKeyOutFieldDataReader["inter_media"].ToString());
                inter_client = int.Parse(pdpKeyOutFieldDataReader["inter_client"].ToString());
                inter_devel = int.Parse(pdpKeyOutFieldDataReader["inter_devel"].ToString());
                inter_incorp = int.Parse(pdpKeyOutFieldDataReader["inter_incorp"].ToString());
                inter_prog = int.Parse(pdpKeyOutFieldDataReader["inter_prog"].ToString());
                inter_consult = int.Parse(pdpKeyOutFieldDataReader["inter_consult"].ToString());
                inter_farmers = int.Parse(pdpKeyOutFieldDataReader["inter_farmers"].ToString());
                inter_out_other = pdpKeyOutFieldDataReader["inter_out_other"].ToString();
                inter_out_desc = pdpKeyOutFieldDataReader["inter_out_desc"].ToString();
                inter_description = pdpKeyOutFieldDataReader["inter_description"].ToString();

                multi_session = int.Parse(pdpKeyOutFieldDataReader["multi_session"].ToString());
                multi_title = pdpKeyOutFieldDataReader["multi_title"].ToString();
                multi_start_date = pdpKeyOutFieldDataReader["multi_start_date"].ToString();
                if (multi_start_date != "")
                {
                    DateTime multi_start_dateTrim = DateTime.Parse(multi_start_date);
                    multi_start_date = multi_start_dateTrim.ToShortDateString();
                }
                multi_end_date = pdpKeyOutFieldDataReader["multi_end_date"].ToString();
                if (multi_end_date != "")
                {
                    DateTime multi_end_dateTrim = DateTime.Parse(multi_end_date);
                    multi_end_date = multi_end_dateTrim.ToShortDateString();
                }
                multi_ext = int.Parse(pdpKeyOutFieldDataReader["multi_ext"].ToString());
                multi_nrcs = int.Parse(pdpKeyOutFieldDataReader["multi_nrcs"].ToString());
                multi_ngo = int.Parse(pdpKeyOutFieldDataReader["multi_ngo"].ToString());
                multi_st = int.Parse(pdpKeyOutFieldDataReader["multi_st"].ToString());
                multi_pro = int.Parse(pdpKeyOutFieldDataReader["multi_pro"].ToString());
                multi_farm = int.Parse(pdpKeyOutFieldDataReader["multi_farm"].ToString());
                multi_att_desc = pdpKeyOutFieldDataReader["multi_att_desc"].ToString();
                multi_att_other = pdpKeyOutFieldDataReader["multi_att_other"].ToString();
                multi_loc = pdpKeyOutFieldDataReader["multi_loc"].ToString();
                multi_state = pdpKeyOutFieldDataReader["multi_state"].ToString();
                multi_zip = pdpKeyOutFieldDataReader["multi_zip"].ToString();
                multi_media = int.Parse(pdpKeyOutFieldDataReader["multi_media"].ToString());
                multi_client = int.Parse(pdpKeyOutFieldDataReader["multi_client"].ToString());
                multi_devel = int.Parse(pdpKeyOutFieldDataReader["multi_devel"].ToString());
                multi_incorp = int.Parse(pdpKeyOutFieldDataReader["multi_incorp"].ToString());
                multi_prog = int.Parse(pdpKeyOutFieldDataReader["multi_prog"].ToString());
                multi_consult = int.Parse(pdpKeyOutFieldDataReader["multi_consult"].ToString());
                multi_farmers = int.Parse(pdpKeyOutFieldDataReader["multi_farmers"].ToString());
                multi_out_other = pdpKeyOutFieldDataReader["multi_out_other"].ToString();
                multi_out_desc = pdpKeyOutFieldDataReader["multi_out_desc"].ToString();
                multi_description = pdpKeyOutFieldDataReader["multi_description"].ToString();

                study_session = int.Parse(pdpKeyOutFieldDataReader["extend_session"].ToString());
                study_title = pdpKeyOutFieldDataReader["extend_title"].ToString();
                study_start_date = pdpKeyOutFieldDataReader["extend_start_date"].ToString();
                if (study_start_date != "")
                {
                    DateTime study_start_dateTrim = DateTime.Parse(study_start_date);
                    study_start_date = study_start_dateTrim.ToShortDateString();
                }
                study_end_date = pdpKeyOutFieldDataReader["extend_end_date"].ToString();
                if (study_end_date != "")
                {
                    DateTime study_end_dateTrim = DateTime.Parse(study_end_date);
                    study_end_date = study_end_dateTrim.ToShortDateString();
                }
                study_ext = int.Parse(pdpKeyOutFieldDataReader["extend_ext"].ToString());
                study_nrcs = int.Parse(pdpKeyOutFieldDataReader["extend_nrcs"].ToString());
                study_ngo = int.Parse(pdpKeyOutFieldDataReader["extend_ngo"].ToString());
                study_st = int.Parse(pdpKeyOutFieldDataReader["extend_st"].ToString());
                study_pro = int.Parse(pdpKeyOutFieldDataReader["extend_pro"].ToString());
                study_farm = int.Parse(pdpKeyOutFieldDataReader["extend_farm"].ToString());
                study_att_desc = pdpKeyOutFieldDataReader["extend_att_desc"].ToString();
                study_att_other = pdpKeyOutFieldDataReader["extend_att_other"].ToString();
                study_loc = pdpKeyOutFieldDataReader["extend_loc"].ToString();
                study_state = pdpKeyOutFieldDataReader["extend_state"].ToString();
                study_zip = pdpKeyOutFieldDataReader["extend_zip"].ToString();
                study_media = int.Parse(pdpKeyOutFieldDataReader["extend_media"].ToString());
                study_client = int.Parse(pdpKeyOutFieldDataReader["extend_client"].ToString());
                study_devel = int.Parse(pdpKeyOutFieldDataReader["extend_devel"].ToString());
                study_incorp = int.Parse(pdpKeyOutFieldDataReader["extend_incorp"].ToString());
                study_prog = int.Parse(pdpKeyOutFieldDataReader["extend_prog"].ToString());
                study_consult = int.Parse(pdpKeyOutFieldDataReader["extend_consult"].ToString());
                study_farmers = int.Parse(pdpKeyOutFieldDataReader["extend_farmers"].ToString());
                study_out_other = pdpKeyOutFieldDataReader["extend_out_other"].ToString();
                study_out_desc = pdpKeyOutFieldDataReader["extend_out_desc"].ToString();
                study_description = pdpKeyOutFieldDataReader["extend_description"].ToString();

                pdp_initiative_num = int.Parse(pdpKeyOutFieldDataReader["initiative_num"].ToString());

                result = true;
            }
            else
                projNum = pdp_projnum;

            pdpKeyOutFieldConnection.Dispose();

            return result;
        }

        public void toXmlPdpKeyOutStudy(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutStudy");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_studyID", pdp_key_studyID.ToString());

            xmlOut.WriteElementString("pdp_initNum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("study_session", study_session.ToString());
            xmlOut.WriteElementString("study_title", study_title);
            xmlOut.WriteElementString("study_start_date", study_start_date);
            xmlOut.WriteElementString("study_end_date", study_end_date);
            xmlOut.WriteElementString("study_ext", study_ext.ToString());
            xmlOut.WriteElementString("study_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("study_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("study_st", study_st.ToString());
            xmlOut.WriteElementString("study_pro", study_pro.ToString());
            xmlOut.WriteElementString("study_farm", study_farm.ToString());
            xmlOut.WriteElementString("study_att_desc", study_att_desc);
            xmlOut.WriteElementString("study_att_other", study_att_other);
            xmlOut.WriteElementString("study_loc", study_loc);
            xmlOut.WriteElementString("study_state", study_state);
            xmlOut.WriteElementString("study_zip", study_zip);
            xmlOut.WriteElementString("study_media", study_media.ToString());
            xmlOut.WriteElementString("study_client", study_client.ToString());
            xmlOut.WriteElementString("study_devel", study_devel.ToString());
            xmlOut.WriteElementString("study_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("study_prog", study_prog.ToString());
            xmlOut.WriteElementString("study_consult", study_consult.ToString());
            xmlOut.WriteElementString("study_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("study_out_other", study_out_other);
            xmlOut.WriteElementString("study_out_desc", study_out_desc);
            xmlOut.WriteElementString("study_description", study_description);
            xmlOut.WriteElementString("initiative_num",pdp_initiative_num.ToString());

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpKeyOutTravel(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutTravel");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_travelID", pdp_key_TravelID.ToString());

            xmlOut.WriteElementString("pdp_initNum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("travel_title", study_title.ToString());
            xmlOut.WriteElementString("travel_desc", travel_desc.ToString());
            xmlOut.WriteElementString("travel_scholarship", study_session.ToString());
            xmlOut.WriteElementString("travel_individual1", travel_individual1.ToString());
            xmlOut.WriteElementString("travel_individual2", travel_individual2.ToString());
            xmlOut.WriteElementString("travel_individual3", travel_individual3.ToString());
            xmlOut.WriteElementString("travel_individual4", travel_individual4.ToString());
            xmlOut.WriteElementString("travel_individual5", travel_individual5.ToString());
            xmlOut.WriteElementString("travel_individual6", travel_individual6.ToString());
            xmlOut.WriteElementString("travel_individual7", travel_individual7.ToString());
            xmlOut.WriteElementString("travel_individual8", travel_individual8.ToString());
            xmlOut.WriteElementString("travel_individual9", travel_individual9.ToString());
            xmlOut.WriteElementString("travel_individual10", travel_individual10.ToString());
            xmlOut.WriteElementString("travel_individual11", travel_individual11.ToString());
            xmlOut.WriteElementString("travel_individual12", travel_individual12.ToString());
            xmlOut.WriteElementString("travel_individual_other", travel_individual_other.ToString());
            xmlOut.WriteElementString("travel_start_date", study_start_date);
            xmlOut.WriteElementString("travel_end_date", study_end_date);
            xmlOut.WriteElementString("travel_ext", study_ext.ToString());
            xmlOut.WriteElementString("travel_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("travel_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("travel_st", study_st.ToString());
            xmlOut.WriteElementString("travel_pro", study_pro.ToString());
            xmlOut.WriteElementString("travel_farm", study_farm.ToString());
            xmlOut.WriteElementString("travel_reci_desc", study_att_desc);
            xmlOut.WriteElementString("travel_other", study_att_other);
            xmlOut.WriteElementString("travel_loc", study_loc);
            xmlOut.WriteElementString("travel_state", study_state);
            xmlOut.WriteElementString("travel_zip", study_zip);
            xmlOut.WriteElementString("travel_media", study_media.ToString());
            xmlOut.WriteElementString("travel_client", study_client.ToString());
            xmlOut.WriteElementString("travel_devel", study_devel.ToString());
            xmlOut.WriteElementString("travel_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("travel_prog", study_prog.ToString());
            xmlOut.WriteElementString("travel_consult", study_consult.ToString());
            xmlOut.WriteElementString("travel_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("travel_out_other", study_out_other);
            xmlOut.WriteElementString("travel_out_desc", study_out_desc);

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpKeyOutOther(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutOther");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_otherID", pdp_key_OtherID.ToString());

            xmlOut.WriteElementString("pdp_initnum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("other_title", study_title.ToString());
            xmlOut.WriteElementString("other_desc", other_desc.ToString());
            xmlOut.WriteElementString("other_start_date", study_start_date);
            xmlOut.WriteElementString("other_end_date", study_end_date);
            xmlOut.WriteElementString("other_ext", study_ext.ToString());
            xmlOut.WriteElementString("other_ext", study_ext.ToString());
            xmlOut.WriteElementString("other_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("other_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("other_st", study_st.ToString());
            xmlOut.WriteElementString("other_pro", study_pro.ToString());
            xmlOut.WriteElementString("other_farm", study_farm.ToString());
            xmlOut.WriteElementString("other_reci_desc", study_att_desc);
            xmlOut.WriteElementString("other_other", study_att_other);
            xmlOut.WriteElementString("other_loc", study_loc);
            xmlOut.WriteElementString("other_state", study_state);
            xmlOut.WriteElementString("other_zip", study_zip);
            xmlOut.WriteElementString("other_media", study_media.ToString());
            xmlOut.WriteElementString("other_client", study_client.ToString());
            xmlOut.WriteElementString("other_devel", study_devel.ToString());
            xmlOut.WriteElementString("other_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("other_prog", study_prog.ToString());
            xmlOut.WriteElementString("other_consult", study_consult.ToString());
            xmlOut.WriteElementString("other_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("other_out_other", study_out_other);
            xmlOut.WriteElementString("other_out_desc", study_out_desc);

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpKeyOutWeb(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutWeb");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_webID", pdp_key_WebID.ToString());

            xmlOut.WriteElementString("pdp_initNum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("web_curricula", study_session.ToString());
            xmlOut.WriteElementString("web_title", study_title);
            xmlOut.WriteElementString("web_start_date", study_start_date);
            xmlOut.WriteElementString("web_end_date", study_end_date);
            xmlOut.WriteElementString("web_ext", study_ext.ToString());
            xmlOut.WriteElementString("web_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("web_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("web_st", study_st.ToString());
            xmlOut.WriteElementString("web_pro", study_pro.ToString());
            xmlOut.WriteElementString("web_farm", study_farm.ToString());
            xmlOut.WriteElementString("web_att_desc", study_att_desc);
            xmlOut.WriteElementString("web_att_other", study_att_other);
            xmlOut.WriteElementString("web_media", study_media.ToString());
            xmlOut.WriteElementString("web_client", study_client.ToString());
            xmlOut.WriteElementString("web_devel", study_devel.ToString());
            xmlOut.WriteElementString("web_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("web_prog", study_prog.ToString());
            xmlOut.WriteElementString("web_consult", study_consult.ToString());
            xmlOut.WriteElementString("web_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("web_out_other", study_out_other);
            xmlOut.WriteElementString("web_out_desc", study_out_desc);
            xmlOut.WriteElementString("web_description", study_description);

            xmlOut.WriteElementString("webseries_title", short_title);
            xmlOut.WriteElementString("webseries_start_date", short_start_date);
            xmlOut.WriteElementString("webseries_end_date", short_end_date);
            xmlOut.WriteElementString("webseries_ext", short_ext.ToString());
            xmlOut.WriteElementString("webseries_nrcs", short_nrcs.ToString());
            xmlOut.WriteElementString("webseries_ngo", short_ngo.ToString());
            xmlOut.WriteElementString("webseries_st", short_st.ToString());
            xmlOut.WriteElementString("webseries_pro", short_pro.ToString());
            xmlOut.WriteElementString("webseries_farm", short_farm.ToString());
            xmlOut.WriteElementString("webseries_att_desc", short_att_desc);
            xmlOut.WriteElementString("webseries_att_other", short_att_other);
            xmlOut.WriteElementString("webseries_media", short_media.ToString());
            xmlOut.WriteElementString("webseries_client", short_client.ToString());
            xmlOut.WriteElementString("webseries_devel", short_devel.ToString());
            xmlOut.WriteElementString("webseries_incorp", short_incorp.ToString());
            xmlOut.WriteElementString("webseries_prog", short_prog.ToString());
            xmlOut.WriteElementString("webseries_consult", short_consult.ToString());
            xmlOut.WriteElementString("webseries_farmers", short_farmers.ToString());
            xmlOut.WriteElementString("webseries_out_other", short_out_other);
            xmlOut.WriteElementString("webseries_out_desc", short_out_desc);
            xmlOut.WriteElementString("webseries_description", short_description);

            xmlOut.WriteElementString("webcur_title", inter_title);
            xmlOut.WriteElementString("webcur_start_date", inter_start_date);
            xmlOut.WriteElementString("webcur_end_date", inter_end_date);
            xmlOut.WriteElementString("webcur_ext", inter_ext.ToString());
            xmlOut.WriteElementString("webcur_nrcs", inter_nrcs.ToString());
            xmlOut.WriteElementString("webcur_ngo", inter_ngo.ToString());
            xmlOut.WriteElementString("webcur_st", inter_st.ToString());
            xmlOut.WriteElementString("webcur_pro", inter_pro.ToString());
            xmlOut.WriteElementString("webcur_farm", inter_farm.ToString());
            xmlOut.WriteElementString("webcur_att_desc", inter_att_desc);
            xmlOut.WriteElementString("webcur_att_other", inter_att_other);
            xmlOut.WriteElementString("webcur_media", inter_media.ToString());
            xmlOut.WriteElementString("webcur_client", inter_client.ToString());
            xmlOut.WriteElementString("webcur_devel", inter_devel.ToString());
            xmlOut.WriteElementString("webcur_incorp", inter_incorp.ToString());
            xmlOut.WriteElementString("webcur_prog", inter_prog.ToString());
            xmlOut.WriteElementString("webcur_consult", inter_consult.ToString());
            xmlOut.WriteElementString("webcur_farmers", inter_farmers.ToString());
            xmlOut.WriteElementString("webcur_out_other", inter_out_other);
            xmlOut.WriteElementString("webcur_out_desc", inter_out_desc);
            xmlOut.WriteElementString("webcur_description", inter_description);

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpKeyOutWorkshops(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutWorkshops");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_workID", pdp_key_workID.ToString());

            xmlOut.WriteElementString("pdp_initID", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("short_session", short_session.ToString());
            xmlOut.WriteElementString("short_start_date", short_start_date);
            xmlOut.WriteElementString("short_end_date", short_end_date);
            xmlOut.WriteElementString("short_ext", short_ext.ToString());
            xmlOut.WriteElementString("short_nrcs", short_nrcs.ToString());
            xmlOut.WriteElementString("short_ngo", short_ngo.ToString());
            xmlOut.WriteElementString("short_st", short_st.ToString());
            xmlOut.WriteElementString("short_pro", short_pro.ToString());
            xmlOut.WriteElementString("short_farm", short_farm.ToString());
            xmlOut.WriteElementString("short_att_desc", short_att_desc);
            xmlOut.WriteElementString("short_att_other", short_att_other);
            xmlOut.WriteElementString("short_loc", short_loc);
            xmlOut.WriteElementString("short_state", short_state);
            xmlOut.WriteElementString("short_zip", short_zip);
            xmlOut.WriteElementString("short_media", short_media.ToString());
            xmlOut.WriteElementString("short_client", short_client.ToString());
            xmlOut.WriteElementString("short_devel", short_devel.ToString());
            xmlOut.WriteElementString("short_incorp", short_incorp.ToString());
            xmlOut.WriteElementString("short_prog", short_prog.ToString());
            xmlOut.WriteElementString("short_consult", short_consult.ToString());
            xmlOut.WriteElementString("short_farmers", short_farmers.ToString());
            xmlOut.WriteElementString("short_out_other", short_out_other);
            xmlOut.WriteElementString("short_out_desc", short_out_desc);
            xmlOut.WriteElementString("short_title", short_title);
            xmlOut.WriteElementString("short_description", short_description);
            xmlOut.WriteElementString("inter_session", inter_session.ToString());
            xmlOut.WriteElementString("inter_start_date", inter_start_date);
            xmlOut.WriteElementString("inter_end_date", inter_end_date);
            xmlOut.WriteElementString("inter_ext", inter_ext.ToString());
            xmlOut.WriteElementString("inter_nrcs", inter_nrcs.ToString());
            xmlOut.WriteElementString("inter_ngo", inter_ngo.ToString());
            xmlOut.WriteElementString("inter_st", inter_st.ToString());
            xmlOut.WriteElementString("inter_pro", inter_pro.ToString());
            xmlOut.WriteElementString("inter_farm", inter_farm.ToString());
            xmlOut.WriteElementString("inter_att_desc", inter_att_desc);
            xmlOut.WriteElementString("inter_att_other", inter_att_other);
            xmlOut.WriteElementString("inter_loc", inter_loc);
            xmlOut.WriteElementString("inter_state", inter_state);
            xmlOut.WriteElementString("inter_zip", inter_zip);
            xmlOut.WriteElementString("inter_media", inter_media.ToString());
            xmlOut.WriteElementString("inter_client", inter_client.ToString());
            xmlOut.WriteElementString("inter_devel", inter_devel.ToString());
            xmlOut.WriteElementString("inter_incorp", inter_incorp.ToString());
            xmlOut.WriteElementString("inter_prog", inter_prog.ToString());
            xmlOut.WriteElementString("inter_consult", inter_consult.ToString());
            xmlOut.WriteElementString("inter_farmers", inter_farmers.ToString());
            xmlOut.WriteElementString("inter_out_other", inter_out_other);
            xmlOut.WriteElementString("inter_out_desc", inter_out_desc);
            xmlOut.WriteElementString("inter_title", inter_title);
            xmlOut.WriteElementString("inter_description", inter_description);
            xmlOut.WriteElementString("multi_session", multi_session.ToString());
            xmlOut.WriteElementString("multi_start_date", multi_start_date);
            xmlOut.WriteElementString("multi_end_date", multi_end_date);
            xmlOut.WriteElementString("multi_ext", multi_ext.ToString());
            xmlOut.WriteElementString("multi_nrcs", multi_nrcs.ToString());
            xmlOut.WriteElementString("multi_ngo", multi_ngo.ToString());
            xmlOut.WriteElementString("multi_st", multi_st.ToString());
            xmlOut.WriteElementString("multi_pro", multi_pro.ToString());
            xmlOut.WriteElementString("multi_farm", multi_farm.ToString());
            xmlOut.WriteElementString("multi_att_desc", multi_att_desc);
            xmlOut.WriteElementString("multi_att_other", multi_att_other);
            xmlOut.WriteElementString("multi_loc", multi_loc);
            xmlOut.WriteElementString("multi_state", multi_state);
            xmlOut.WriteElementString("multi_zip", multi_zip);
            xmlOut.WriteElementString("multi_media", multi_media.ToString());
            xmlOut.WriteElementString("multi_client", multi_client.ToString());
            xmlOut.WriteElementString("multi_devel", multi_devel.ToString());
            xmlOut.WriteElementString("multi_incorp", multi_incorp.ToString());
            xmlOut.WriteElementString("multi_prog", multi_prog.ToString());
            xmlOut.WriteElementString("multi_consult", multi_consult.ToString());
            xmlOut.WriteElementString("multi_farmers", multi_farmers.ToString());
            xmlOut.WriteElementString("multi_out_other", multi_out_other);
            xmlOut.WriteElementString("multi_out_desc", multi_out_desc);
            xmlOut.WriteElementString("multi_title", multi_title);
            xmlOut.WriteElementString("multi_description", multi_description);
            xmlOut.WriteElementString("extend_session", study_session.ToString());
            xmlOut.WriteElementString("extend_start_date", study_start_date);
            xmlOut.WriteElementString("extend_end_date", study_end_date);
            xmlOut.WriteElementString("extend_ext", study_ext.ToString());
            xmlOut.WriteElementString("extend_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("extend_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("extend_st", study_st.ToString());
            xmlOut.WriteElementString("extend_pro", study_pro.ToString());
            xmlOut.WriteElementString("extend_farm", study_farm.ToString());
            xmlOut.WriteElementString("extend_att_desc", study_att_desc);
            xmlOut.WriteElementString("extend_att_other", study_att_other);
            xmlOut.WriteElementString("extend_loc", study_loc);
            xmlOut.WriteElementString("extend_state", study_state);
            xmlOut.WriteElementString("extend_zip", study_zip);
            xmlOut.WriteElementString("extend_media", study_media.ToString());
            xmlOut.WriteElementString("extend_client", study_client.ToString());
            xmlOut.WriteElementString("extend_devel", study_devel.ToString());
            xmlOut.WriteElementString("extend_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("extend_prog", study_prog.ToString());
            xmlOut.WriteElementString("extend_consult", study_consult.ToString());
            xmlOut.WriteElementString("extend_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("extend_out_other", study_out_other);
            xmlOut.WriteElementString("extend_out_desc", study_out_desc);
            xmlOut.WriteElementString("extend_title", study_title);
            xmlOut.WriteElementString("extend_description", study_description);

            xmlOut.WriteEndElement();
        }

        public void toXmlPdpKeyOutGrants(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutGrants");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_grantID", pdp_key_grantID.ToString());

            xmlOut.WriteElementString("pdp_initNum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("demo_session", short_session.ToString());
            xmlOut.WriteElementString("demo_title", short_title);
            xmlOut.WriteElementString("demo_description", short_description);
            xmlOut.WriteElementString("demo_start_date", short_start_date);
            xmlOut.WriteElementString("demo_end_date", short_end_date);
            xmlOut.WriteElementString("demo_ext", short_ext.ToString());
            xmlOut.WriteElementString("demo_nrcs", short_nrcs.ToString());
            xmlOut.WriteElementString("demo_ngo", short_ngo.ToString());
            xmlOut.WriteElementString("demo_st", short_st.ToString());
            xmlOut.WriteElementString("demo_pro", short_pro.ToString());
            xmlOut.WriteElementString("demo_farm", short_farm.ToString());
            xmlOut.WriteElementString("demo_att_desc", short_att_desc);
            xmlOut.WriteElementString("demo_att_other", short_att_other);
            xmlOut.WriteElementString("demo_loc", short_loc);
            xmlOut.WriteElementString("demo_state", short_state);
            xmlOut.WriteElementString("demo_zip", short_zip);
            xmlOut.WriteElementString("demo_media", short_media.ToString());
            xmlOut.WriteElementString("demo_client", short_client.ToString());
            xmlOut.WriteElementString("demo_devel", short_devel.ToString());
            xmlOut.WriteElementString("demo_incorp", short_incorp.ToString());
            xmlOut.WriteElementString("demo_prog", short_prog.ToString());
            xmlOut.WriteElementString("demo_consult", short_consult.ToString());
            xmlOut.WriteElementString("demo_farmers", short_farmers.ToString());
            xmlOut.WriteElementString("demo_out_other", short_out_other);
            xmlOut.WriteElementString("demo_out_desc", short_out_desc);
            xmlOut.WriteElementString("work_session", inter_session.ToString());
            xmlOut.WriteElementString("work_title", inter_title);
            xmlOut.WriteElementString("work_description", inter_description);
            xmlOut.WriteElementString("work_start_date", inter_start_date);
            xmlOut.WriteElementString("work_end_date", inter_end_date);
            xmlOut.WriteElementString("work_ext", inter_ext.ToString());
            xmlOut.WriteElementString("work_nrcs", inter_nrcs.ToString());
            xmlOut.WriteElementString("work_ngo", inter_ngo.ToString());
            xmlOut.WriteElementString("work_st", inter_st.ToString());
            xmlOut.WriteElementString("work_pro", inter_pro.ToString());
            xmlOut.WriteElementString("work_farm", inter_farm.ToString());
            xmlOut.WriteElementString("work_att_desc", inter_att_desc);
            xmlOut.WriteElementString("work_att_other", inter_att_other);
            xmlOut.WriteElementString("work_loc", inter_loc);
            xmlOut.WriteElementString("work_state", inter_state);
            xmlOut.WriteElementString("work_zip", inter_zip);
            xmlOut.WriteElementString("work_media", inter_media.ToString());
            xmlOut.WriteElementString("work_client", inter_client.ToString());
            xmlOut.WriteElementString("work_devel", inter_devel.ToString());
            xmlOut.WriteElementString("work_incorp", inter_incorp.ToString());
            xmlOut.WriteElementString("work_prog", inter_prog.ToString());
            xmlOut.WriteElementString("work_consult", inter_consult.ToString());
            xmlOut.WriteElementString("work_farmers", inter_farmers.ToString());
            xmlOut.WriteElementString("work_out_other", inter_out_other);
            xmlOut.WriteElementString("work_out_desc", inter_out_desc);
            xmlOut.WriteElementString("tour_session", multi_session.ToString());
            xmlOut.WriteElementString("tour_title", multi_title);
            xmlOut.WriteElementString("tour_description", multi_description);
            xmlOut.WriteElementString("tour_start_date", multi_start_date);
            xmlOut.WriteElementString("tour_end_date", multi_end_date);
            xmlOut.WriteElementString("tour_ext", multi_ext.ToString());
            xmlOut.WriteElementString("tour_nrcs", multi_nrcs.ToString());
            xmlOut.WriteElementString("tour_ngo", multi_ngo.ToString());
            xmlOut.WriteElementString("tour_st", multi_st.ToString());
            xmlOut.WriteElementString("tour_pro", multi_pro.ToString());
            xmlOut.WriteElementString("tour_farm", multi_farm.ToString());
            xmlOut.WriteElementString("tour_att_desc", multi_att_desc);
            xmlOut.WriteElementString("tour_att_other", multi_att_other);
            xmlOut.WriteElementString("tour_loc", multi_loc);
            xmlOut.WriteElementString("tour_state", multi_state);
            xmlOut.WriteElementString("tour_zip", multi_zip);
            xmlOut.WriteElementString("tour_media", multi_media.ToString());
            xmlOut.WriteElementString("tour_client", multi_client.ToString());
            xmlOut.WriteElementString("tour_devel", multi_devel.ToString());
            xmlOut.WriteElementString("tour_incorp", multi_incorp.ToString());
            xmlOut.WriteElementString("tour_prog", multi_prog.ToString());
            xmlOut.WriteElementString("tour_consult", multi_consult.ToString());
            xmlOut.WriteElementString("tour_farmers", multi_farmers.ToString());
            xmlOut.WriteElementString("tour_out_other", multi_out_other);
            xmlOut.WriteElementString("tour_out_desc", multi_out_desc);
            xmlOut.WriteElementString("cur_session", study_session.ToString());
            xmlOut.WriteElementString("cur_start_date", study_start_date);
            xmlOut.WriteElementString("cur_end_date", study_end_date);
            xmlOut.WriteElementString("cur_ext", study_ext.ToString());
            xmlOut.WriteElementString("cur_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("cur_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("cur_st", study_st.ToString());
            xmlOut.WriteElementString("cur_pro", study_pro.ToString());
            xmlOut.WriteElementString("cur_farm", study_farm.ToString());
            xmlOut.WriteElementString("cur_att_desc", study_att_desc);
            xmlOut.WriteElementString("cur_att_other", study_att_other);
            xmlOut.WriteElementString("cur_loc", study_loc);
            xmlOut.WriteElementString("cur_state", study_state);
            xmlOut.WriteElementString("cur_zip", study_zip);
            xmlOut.WriteElementString("cur_media", study_media.ToString());
            xmlOut.WriteElementString("cur_client", study_client.ToString());
            xmlOut.WriteElementString("cur_devel", study_devel.ToString());
            xmlOut.WriteElementString("cur_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("cur_prog", study_prog.ToString());
            xmlOut.WriteElementString("cur_consult", study_consult.ToString());
            xmlOut.WriteElementString("cur_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("cur_out_other", study_out_other);
            xmlOut.WriteElementString("cur_out_desc", study_out_desc);
            xmlOut.WriteElementString("cur_title", study_title);
            xmlOut.WriteElementString("cur_description", study_description);

            xmlOut.WriteEndElement();
        }


        public void toXmlPdpKeyOutField(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("pdpKeyOutField");
            xmlOut.WriteAttributeString("proj_num", projNum);
            xmlOut.WriteAttributeString("pdp_key_fieldID", pdp_key_fieldID.ToString());

            xmlOut.WriteElementString("pdp_initNum", pdp_initiative_num.ToString());
            xmlOut.WriteElementString("inter_title", inter_title);
            xmlOut.WriteElementString("inter_start_date", inter_start_date);
            xmlOut.WriteElementString("inter_end_date", inter_end_date);
            xmlOut.WriteElementString("inter_ext", inter_ext.ToString());
            xmlOut.WriteElementString("inter_nrcs", inter_nrcs.ToString());
            xmlOut.WriteElementString("inter_ngo", inter_ngo.ToString());
            xmlOut.WriteElementString("inter_st", inter_st.ToString());
            xmlOut.WriteElementString("inter_pro", inter_pro.ToString());
            xmlOut.WriteElementString("inter_farm", inter_farm.ToString());
            xmlOut.WriteElementString("inter_att_desc", inter_att_desc);
            xmlOut.WriteElementString("inter_att_other", inter_att_other);
            xmlOut.WriteElementString("inter_loc", inter_loc);
            xmlOut.WriteElementString("inter_state", inter_state);
            xmlOut.WriteElementString("inter_zip", inter_zip);
            xmlOut.WriteElementString("inter_media", inter_media.ToString());
            xmlOut.WriteElementString("inter_client", inter_client.ToString());
            xmlOut.WriteElementString("inter_devel", inter_devel.ToString());
            xmlOut.WriteElementString("inter_incorp", inter_incorp.ToString());
            xmlOut.WriteElementString("inter_prog", inter_prog.ToString());
            xmlOut.WriteElementString("inter_consult", inter_consult.ToString());
            xmlOut.WriteElementString("inter_farmers", inter_farmers.ToString());
            xmlOut.WriteElementString("inter_out_other", inter_out_other);
            xmlOut.WriteElementString("inter_out_desc", inter_out_desc);
            xmlOut.WriteElementString("inter_description", inter_description);
            xmlOut.WriteElementString("multi_session", multi_session.ToString());
            xmlOut.WriteElementString("multi_title", multi_title);
            xmlOut.WriteElementString("multi_start_date", multi_start_date);
            xmlOut.WriteElementString("multi_end_date", multi_end_date);
            xmlOut.WriteElementString("multi_ext", multi_ext.ToString());
            xmlOut.WriteElementString("multi_nrcs", multi_nrcs.ToString());
            xmlOut.WriteElementString("multi_ngo", multi_ngo.ToString());
            xmlOut.WriteElementString("multi_st", multi_st.ToString());
            xmlOut.WriteElementString("multi_pro", multi_pro.ToString());
            xmlOut.WriteElementString("multi_farm", multi_farm.ToString());
            xmlOut.WriteElementString("multi_att_desc", multi_att_desc);
            xmlOut.WriteElementString("multi_att_other", multi_att_other);
            xmlOut.WriteElementString("multi_loc", multi_loc);
            xmlOut.WriteElementString("multi_state", multi_state);
            xmlOut.WriteElementString("multi_zip", multi_zip);
            xmlOut.WriteElementString("multi_media", multi_media.ToString());
            xmlOut.WriteElementString("multi_client", multi_client.ToString());
            xmlOut.WriteElementString("multi_devel", multi_devel.ToString());
            xmlOut.WriteElementString("multi_incorp", multi_incorp.ToString());
            xmlOut.WriteElementString("multi_prog", multi_prog.ToString());
            xmlOut.WriteElementString("multi_consult", multi_consult.ToString());
            xmlOut.WriteElementString("multi_farmers", multi_farmers.ToString());
            xmlOut.WriteElementString("multi_out_other", multi_out_other);
            xmlOut.WriteElementString("multi_out_desc", multi_out_desc);
            xmlOut.WriteElementString("multi_description", multi_description);
            xmlOut.WriteElementString("extend_session", study_session.ToString());
            xmlOut.WriteElementString("extend_title", study_title.ToString());
            xmlOut.WriteElementString("extend_start_date", study_start_date);
            xmlOut.WriteElementString("extend_end_date", study_end_date);
            xmlOut.WriteElementString("extend_ext", study_ext.ToString());
            xmlOut.WriteElementString("extend_nrcs", study_nrcs.ToString());
            xmlOut.WriteElementString("extend_ngo", study_ngo.ToString());
            xmlOut.WriteElementString("extend_st", study_st.ToString());
            xmlOut.WriteElementString("extend_pro", study_pro.ToString());
            xmlOut.WriteElementString("extend_farm", study_farm.ToString());
            xmlOut.WriteElementString("extend_att_desc", study_att_desc);
            xmlOut.WriteElementString("extend_att_other", study_att_other);
            xmlOut.WriteElementString("extend_loc", study_loc);
            xmlOut.WriteElementString("extend_state", study_state);
            xmlOut.WriteElementString("extend_zip", study_zip);
            xmlOut.WriteElementString("extend_media", study_media.ToString());
            xmlOut.WriteElementString("extend_client", study_client.ToString());
            xmlOut.WriteElementString("extend_devel", study_devel.ToString());
            xmlOut.WriteElementString("extend_incorp", study_incorp.ToString());
            xmlOut.WriteElementString("extend_prog", study_prog.ToString());
            xmlOut.WriteElementString("extend_consult", study_consult.ToString());
            xmlOut.WriteElementString("extend_farmers", study_farmers.ToString());
            xmlOut.WriteElementString("extend_out_other", study_out_other);
            xmlOut.WriteElementString("extend_out_desc", study_out_desc);
            xmlOut.WriteElementString("extend_description", study_description.ToString());

            xmlOut.WriteEndElement();
        }


        public string ProjectNum
        {
            get { return projNum; }
            set { projNum = value; }
        }

        public int InitiativeNum
        {
            get { return pdp_initiative_num; }
            set { pdp_initiative_num = value; }
        }
        
        public int StudySess
        {
            get { return study_session; }
            set { study_session = value; }
        }

        public string StudyStartDate
        {
            get { return study_start_date; }
            set { study_start_date = value; }
        }

        public string StudyEndDate
        {
            get { return study_end_date; }
            set { study_end_date = value; }
        }


        public int StudyExt
        {
            get { return study_ext; }
            set { study_ext = value; }
        }

        public int StudyNRCS
        {
            get { return study_nrcs; }
            set { study_nrcs = value; }
        }

        public int StudyNGO
        {
            get { return study_ngo; }
            set { study_ngo = value; }
        }

        public int StudyST
        {
            get { return study_st; }
            set { study_st = value; }
        }

        public int StudyProfit
        {
            get { return study_pro; }
            set { study_pro = value; }
        }

        public int StudyFarm
        {
            get { return study_farm; }
            set { study_farm = value; }
        }

        public string StudyAttOther
        {
            get { return study_att_other; }
            set { study_att_other = value; }
        }

        public string StudyAttDesc
        {
            get { return study_att_desc; }
            set { study_att_desc = value; }
        }

        public string StudyLocation
        {
            get { return study_loc; }
            set { study_loc = value; }
        }

        public string StudyState
        {
            get { return study_state; }
            set { study_state = value; }
        }

        public string StudyZip
        {
            get { return study_zip; }
            set { study_zip = value; }
        }

        public int StudyMedia
        {
            get { return study_media; }
            set { study_media = value; }
        }

        public int StudyClient
        {
            get { return study_client; }
            set { study_client = value; }
        }

        public int StudyDevel
        {
            get { return study_devel; }
            set { study_devel = value; }
        }

        public int StudyIncorp
        {
            get { return study_incorp; }
            set { study_incorp = value; }
        }

        public int StudyProgram
        {
            get { return study_prog; }
            set { study_prog = value; }
        }

        public int StudyConsult
        {
            get { return study_consult; }
            set { study_consult = value; }
        }

        public int StudyFarmers
        {
            get { return study_farmers; }
            set { study_farmers = value; }
        }

        public string StudyOutOther
        {
            get { return study_out_other; }
            set { study_out_other = value; }
        }

        public string StudyOutDesc
        {
            get { return study_out_desc; }
            set { study_out_desc = value; }
        }

        public string StudyTitle
        {
            get { return study_title; }
            set { study_title = value; }
        }

        public string StudyDescription
        {
            get { return study_description; }
            set { study_description = value; }
        }

        public string TravelDescription
        {
            get { return travel_desc; }
            set { travel_desc = value; }
        }

        public string TravelIndividual1
        {
            get { return travel_individual1; }
            set { travel_individual1 = value; }
        }

        public string TravelIndividual2
        {
            get { return travel_individual2; }
            set { travel_individual2 = value; }
        }

        public string TravelIndividual3
        {
            get { return travel_individual3; }
            set { travel_individual3 = value; }
        }

        public string TravelIndividual4
        {
            get { return travel_individual4; }
            set { travel_individual4 = value; }
        }

        public string TravelIndividual5
        {
            get { return travel_individual5; }
            set { travel_individual5 = value; }
        }

        public string TravelIndividual6
        {
            get { return travel_individual6; }
            set { travel_individual6 = value; }
        }

        public string TravelIndividual7
        {
            get { return travel_individual7; }
            set { travel_individual7 = value; }
        }

        public string TravelIndividual8
        {
            get { return travel_individual8; }
            set { travel_individual8 = value; }
        }

        public string TravelIndividual9
        {
            get { return travel_individual9; }
            set { travel_individual9 = value; }
        }

        public string TravelIndividual10
        {
            get { return travel_individual10; }
            set { travel_individual10 = value; }
        }

        public string TravelIndividual11
        {
            get { return travel_individual11; }
            set { travel_individual11 = value; }
        }

        public string TravelIndividual12
        {
            get { return travel_individual12; }
            set { travel_individual12 = value; }
        }

        public string TravelIndividualOther
        {
            get { return travel_individual_other; }
            set { travel_individual_other = value; }
        }

        public string OtherDescription
        {
            get { return other_desc; }
            set { other_desc = value; }
        }

        public int ShortSess
        {
            get { return short_session; }
            set { short_session = value; }
        }

        public string ShortStartDate
        {
            get { return short_start_date; }
            set { short_start_date = value; }
        }

        public string ShortEndDate
        {
            get { return short_end_date; }
            set { short_end_date = value; }
        }

        public int ShortExt
        {
            get { return short_ext; }
            set { short_ext = value; }
        }

        public int ShortNRCS
        {
            get { return short_nrcs; }
            set { short_nrcs = value; }
        }

        public int ShortNGO
        {
            get { return short_ngo; }
            set { short_ngo = value; }
        }

        public int ShortST
        {
            get { return short_st; }
            set { short_st = value; }
        }

        public int ShortProfit
        {
            get { return short_pro; }
            set { short_pro = value; }
        }

        public int ShortFarm
        {
            get { return short_farm; }
            set { short_farm = value; }
        }

        public string ShortAttOther
        {
            get { return short_att_other; }
            set { short_att_other = value; }
        }

        public string ShortAttDesc
        {
            get { return short_att_desc; }
            set { short_att_desc = value; }
        }

        public string ShortLocation
        {
            get { return short_loc; }
            set { short_loc = value; }
        }

        public string ShortState
        {
            get { return short_state; }
            set { short_state = value; }
        }

        public string ShortZip
        {
            get { return short_zip; }
            set { short_zip = value; }
        }


        public int ShortMedia
        {
            get { return short_media; }
            set { short_media = value; }
        }

        public int ShortClient
        {
            get { return short_client; }
            set { short_client = value; }
        }

        public int ShortDevel
        {
            get { return short_devel; }
            set { short_devel = value; }
        }

        public int ShortIncorp
        {
            get { return short_incorp; }
            set { short_incorp = value; }
        }

        public int ShortProgram
        {
            get { return short_prog; }
            set { short_prog = value; }
        }

        public int ShortConsult
        {
            get { return short_consult; }
            set { short_consult = value; }
        }

        public int ShortFarmers
        {
            get { return short_farmers; }
            set { short_farmers = value; }
        }

        public string ShortOutOther
        {
            get { return short_out_other; }
            set { short_out_other = value; }
        }

        public string ShortOutDesc
        {
            get { return short_out_desc; }
            set { short_out_desc = value; }
        }

        public string ShortTitle
        {
            get { return short_title; }
            set { short_title = value; }
        }

        public string ShortDescription
        {
            get { return short_description; }
            set { short_description = value; }
        }

        public int InterSess
        {
            get { return inter_session; }
            set { inter_session = value; }
        }

        public string InterStartDate
        {
            get { return inter_start_date; }
            set { inter_start_date = value; }
        }

        public string InterEndDate
        {
            get { return inter_end_date; }
            set { inter_end_date = value; }
        }

        public int InterExt
        {
            get { return inter_ext; }
            set { inter_ext = value; }
        }

        public int InterNRCS
        {
            get { return inter_nrcs; }
            set { inter_nrcs = value; }
        }

        public int InterNGO
        {
            get { return inter_ngo; }
            set { inter_ngo = value; }
        }

        public int InterST
        {
            get { return inter_st; }
            set { inter_st = value; }
        }

        public int InterProfit
        {
            get { return inter_pro; }
            set { inter_pro = value; }
        }

        public int InterFarm
        {
            get { return inter_farm; }
            set { inter_farm = value; }
        }

        public string InterAttOther
        {
            get { return inter_att_other; }
            set { inter_att_other = value; }
        }

        public string InterAttDesc
        {
            get { return inter_att_desc; }
            set { inter_att_desc = value; }
        }

        public string InterLocation
        {
            get { return inter_loc; }
            set { inter_loc = value; }
        }

        public string InterState
        {
            get { return inter_state; }
            set { inter_state = value; }
        }

        public string InterZip
        {
            get { return inter_zip; }
            set { inter_zip = value; }
        }


        public int InterMedia
        {
            get { return inter_media; }
            set { inter_media = value; }
        }

        public int InterClient
        {
            get { return inter_client; }
            set { inter_client = value; }
        }

        public int InterDevel
        {
            get { return inter_devel; }
            set { inter_devel = value; }
        }

        public int InterIncorp
        {
            get { return inter_incorp; }
            set { inter_incorp = value; }
        }

        public int InterProgram
        {
            get { return inter_prog; }
            set { inter_prog = value; }
        }

        public int InterConsult
        {
            get { return inter_consult; }
            set { inter_consult = value; }
        }

        public int InterFarmers
        {
            get { return inter_farmers; }
            set { inter_farmers = value; }
        }

        public string InterOutOther
        {
            get { return inter_out_other; }
            set { inter_out_other = value; }
        }

        public string InterOutDesc
        {
            get { return inter_out_desc; }
            set { inter_out_desc = value; }
        }

        public string InterTitle
        {
            get { return inter_title; }
            set { inter_title = value; }
        }

        public string InterDescription
        {
            get { return inter_description; }
            set { inter_description = value; }
        }

        public int MultiSess
        {
            get { return multi_session; }
            set { multi_session = value; }
        }

        public string MultiStartDate
        {
            get { return multi_start_date; }
            set { multi_start_date = value; }
        }

        public string MultiEndDate
        {
            get { return multi_end_date; }
            set { multi_end_date = value; }
        }

        public int MultiExt
        {
            get { return multi_ext; }
            set { multi_ext = value; }
        }

        public int MultiNRCS
        {
            get { return multi_nrcs; }
            set { multi_nrcs = value; }
        }

        public int MultiNGO
        {
            get { return multi_ngo; }
            set { multi_ngo = value; }
        }

        public int MultiST
        {
            get { return multi_st; }
            set { multi_st = value; }
        }

        public int MultiProfit
        {
            get { return multi_pro; }
            set { multi_pro = value; }
        }

        public int MultiFarm
        {
            get { return multi_farm; }
            set { multi_farm = value; }
        }

        public string MultiAttOther
        {
            get { return multi_att_other; }
            set { multi_att_other = value; }
        }

        public string MultiAttDesc
        {
            get { return multi_att_desc; }
            set { multi_att_desc = value; }
        }

        public string MultiLocation
        {
            get { return multi_loc; }
            set { multi_loc = value; }
        }

        public string MultiState
        {
            get { return multi_state; }
            set { multi_state = value; }
        }

        public string MultiZip
        {
            get { return multi_zip; }
            set { multi_zip = value; }
        }

        public int MultiMedia
        {
            get { return multi_media; }
            set { multi_media = value; }
        }

        public int MultiClient
        {
            get { return multi_client; }
            set { multi_client = value; }
        }

        public int MultiDevel
        {
            get { return multi_devel; }
            set { multi_devel = value; }
        }

        public int MultiIncorp
        {
            get { return multi_incorp; }
            set { multi_incorp = value; }
        }

        public int MultiProgram
        {
            get { return multi_prog; }
            set { multi_prog = value; }
        }

        public int MultiConsult
        {
            get { return multi_consult; }
            set { multi_consult = value; }
        }

        public int MultiFarmers
        {
            get { return multi_farmers; }
            set { multi_farmers = value; }
        }

        public string MultiOutOther
        {
            get { return multi_out_other; }
            set { multi_out_other = value; }
        }

        public string MultiOutDesc
        {
            get { return multi_out_desc; }
            set { multi_out_desc = value; }
        }

        public string MultiTitle
        {
            get { return multi_title; }
            set { multi_title = value; }
        }

        public string MultiDescription
        {
            get { return multi_description; }
            set { multi_description = value; }
        }

    }
}
