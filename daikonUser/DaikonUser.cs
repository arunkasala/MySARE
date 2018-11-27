using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections;

namespace daikon
{
    public class DaikonParticipantCollection : DaikonUserCollection
    {
        public DaikonParticipantCollection(string username, int sessionkey)
		{
        }
        public DaikonParticipantCollection(string projNum)
		{
			userList = new SortedList();

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonNonusercontactGetContactsForProject";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);

			userCommand.Parameters["@proj_num"].Value = projNum;
			
			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();
			
			DaikonParticipant tempParticipant;
            int contactID;

			while (userDataReader.Read())
			{
                contactID = int.Parse(userDataReader["contactID"].ToString());
                tempParticipant = new DaikonParticipant(contactID);
                AddNewUser(tempParticipant);
			}
            userConnection.Dispose();
		}
		public DaikonParticipantCollection(string projNum, bool coords)
		{
			userList = new SortedList();

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonNonusercontactGetPartialContactsForProject";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
			userCommand.Parameters.Add("@coords", SqlDbType.Bit);

			userCommand.Parameters["@proj_num"].Value = projNum;
			userCommand.Parameters["@coords"].Value = coords;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonParticipant tempParticipant;
			int contactID;

			while (userDataReader.Read())
			{
				contactID = int.Parse(userDataReader["contactID"].ToString());
				tempParticipant = new DaikonParticipant(contactID);
				AddNewUser(tempParticipant);
			}
			userConnection.Dispose();
		}

        new public void toXML(XmlTextWriter writer)
        {
            //			writer.WriteStartElement("userlist");
            for (int i = 0; i < userList.Count; i++)
            {
                ((DaikonParticipant)(userList.GetByIndex(i))).toXML(writer);
            }
            //			writer.WriteEndElement();
        }
        new public void toXML(XmlTextWriter writer, string outputcontext)
        {
            //			writer.WriteStartElement("userlist");
            for (int i = 0; i < userList.Count; i++)
            {
                ((DaikonParticipant)(userList.GetByIndex(i))).toXML(writer, outputcontext);
            }
            //			writer.WriteEndElement();
        }
    }

	public class DaikonUserCollection
	{
		protected SortedList userList;
		public SortedList UserList
		{
			get { return userList; }
		}

		public DaikonUserCollection()
		{
			userList = new SortedList();
		}
		public DaikonUserCollection(string username)
		{
			userList = new SortedList();
            string uname;
            string nameTitle;
            string firstName;
            string lastName;
            string namePostfix;
            string org;
            string orgPosition;
            string addrState;
            string numPhone;
            string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetEmailRecipientsByUsername";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);

			userCommand.Parameters["@user"].Value = username;
			
			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();
			
			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
                addrState = userDataReader["addrState"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                email = userDataReader["email"].ToString();

                tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
            userConnection.Dispose();
		}
		public DaikonUserCollection(string username, int sessionkey)
		{
			userList = new SortedList();
            string uname;
            string nameTitle;
            string firstName;
            string lastName;
            string namePostfix;
            string org;
            string orgPosition;
            string addrState;
            string numPhone;
            string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetUsersList";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
			userCommand.Parameters.Add("@sKey", SqlDbType.Int);

			userCommand.Parameters["@user"].Value = username;
			userCommand.Parameters["@sKey"].Value = sessionkey;
			
			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();
			
			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
                addrState = userDataReader["addrState"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                email = userDataReader["email"].ToString();

                tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
            userConnection.Dispose();
		}
        public DaikonUserCollection(string username, int sessionkey, string searchTerms, string searchRole, string searchRegion, string searchState, bool searchRecent)
        {
            userList = new SortedList();

            string uname;
            string nameTitle;
            string firstName;
            string lastName;
            string namePostfix;
            string org;
            string orgPosition;
            string addrState;
            string numPhone;
            string email;

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetUsersSearch";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@searchTerms", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@searchRole", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@searchRegion", SqlDbType.VarChar, 2);
            userCommand.Parameters.Add("@searchState", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@searchRecent", SqlDbType.Bit);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@searchTerms"].Value = searchTerms;
            userCommand.Parameters["@searchRole"].Value = searchRole;
            userCommand.Parameters["@searchRegion"].Value = searchRegion;
            userCommand.Parameters["@searchState"].Value = searchState;
            userCommand.Parameters["@searchRecent"].Value = searchRecent;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();

            DaikonUser tempUser;

            while (userDataReader.Read())
            {
                uname = userDataReader["username"].ToString();
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
                addrState = userDataReader["addrState"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                email = userDataReader["email"].ToString();

                tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);

//                tempUser = new DaikonUser(username);
                AddNewUser(tempUser);
            }
            userConnection.Dispose();
        }
		public DaikonUserCollection(int coreType, int coreSubtype, string region)
		{
			userList = new SortedList();
			string uname;
			string nameTitle;
			string firstName;
			string lastName;
			string namePostfix;
			string org;
			string orgPosition;
			string addrState;
			string numPhone;
			string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetEmailRecipientsByType";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@coreType", SqlDbType.Int);
			userCommand.Parameters.Add("@coreSubtype", SqlDbType.Int);
			userCommand.Parameters.Add("@region", SqlDbType.VarChar, 2);

			userCommand.Parameters["@coreType"].Value = coreType;
			userCommand.Parameters["@coreSubtype"].Value = coreSubtype;
			userCommand.Parameters["@region"].Value = region;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
				nameTitle = userDataReader["nameTitle"].ToString();
				firstName = userDataReader["firstName"].ToString();
				lastName = userDataReader["lastName"].ToString();
				namePostfix = userDataReader["namePostfix"].ToString();
				org = userDataReader["org"].ToString();
				orgPosition = userDataReader["orgPosition"].ToString();
				addrState = userDataReader["addrState"].ToString();
				numPhone = userDataReader["numPhone"].ToString();
				email = userDataReader["email"].ToString();

				tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
				//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
			userConnection.Dispose();
		}
		
		public DaikonUserCollection(string coreSubtype, string region)
		{
			userList = new SortedList();
			string uname;
			string nameTitle;
			string firstName;
			string lastName;
			string namePostfix;
			string org;
			string orgPosition;
			string addrState;
			string numPhone;
			string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetEmailRecipientsByProjectType";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@coreSubtype", SqlDbType.VarChar, 2);
			userCommand.Parameters.Add("@region", SqlDbType.VarChar, 2);

			userCommand.Parameters["@coreSubtype"].Value = coreSubtype;
			userCommand.Parameters["@region"].Value = region;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
				nameTitle = userDataReader["nameTitle"].ToString();
				firstName = userDataReader["firstName"].ToString();
				lastName = userDataReader["lastName"].ToString();
				namePostfix = userDataReader["namePostfix"].ToString();
				org = userDataReader["org"].ToString();
				orgPosition = userDataReader["orgPosition"].ToString();
				addrState = userDataReader["addrState"].ToString();
				numPhone = userDataReader["numPhone"].ToString();
				email = userDataReader["email"].ToString();

				tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
				//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
			userConnection.Dispose();
		}
		public DaikonUserCollection(string coreSubtype, string region, int reportStatus,int startYear, int endYear)
		{
			userList = new SortedList();
			string uname;
			string nameTitle;
			string firstName;
			string lastName;
			string namePostfix;
			string org;
			string orgPosition;
			string addrState;
			string numPhone;
			string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetEmailRecipientsByProjectTypeReportStatusYear";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@coreSubtype", SqlDbType.VarChar, 2);
			userCommand.Parameters.Add("@region", SqlDbType.VarChar, 2);
            userCommand.Parameters.Add("@reportStatus", SqlDbType.Int);
			userCommand.Parameters.Add("@startYear", SqlDbType.Int);
			userCommand.Parameters.Add("@endYear", SqlDbType.Int);

			userCommand.Parameters["@coreSubtype"].Value = coreSubtype;
			userCommand.Parameters["@region"].Value = region;
            userCommand.Parameters["@reportStatus"].Value = reportStatus;
			userCommand.Parameters["@startYear"].Value = startYear;
			userCommand.Parameters["@endYear"].Value = endYear;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
				nameTitle = userDataReader["nameTitle"].ToString();
				firstName = userDataReader["firstName"].ToString();
				lastName = userDataReader["lastName"].ToString();
				namePostfix = userDataReader["namePostfix"].ToString();
				org = userDataReader["org"].ToString();
				orgPosition = userDataReader["orgPosition"].ToString();
				addrState = userDataReader["addrState"].ToString();
				numPhone = userDataReader["numPhone"].ToString();
				email = userDataReader["email"].ToString();

				tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
				//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
			userConnection.Dispose();
		}

		public DaikonUserCollection(int coreID, bool ownersonly)
		{
			userList = new SortedList();
			string uname;
			string nameTitle;
			string firstName;
			string lastName;
			string namePostfix;
			string org;
			string orgPosition;
			string addrStreet1;
			string addrStreet2;
			string addrCity;
			string addrState;
			string addrZip;
			string numPhone;
			string numFax;
			string numCell;
			string email;
            string website;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			if (ownersonly)
			{
				userSQL = "DaikonUserGetOwnersByCoreID";
			}
			else
			{
				userSQL = "DaikonUserGetEmailRecipientsByCoreID";
			}

			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@coreID", SqlDbType.Int);

			userCommand.Parameters["@coreID"].Value = coreID;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
				nameTitle = userDataReader["nameTitle"].ToString();
				firstName = userDataReader["firstName"].ToString();
				lastName = userDataReader["lastName"].ToString();
				namePostfix = userDataReader["namePostfix"].ToString();
				org = userDataReader["org"].ToString();
				orgPosition = userDataReader["orgPosition"].ToString();
                addrStreet1 = userDataReader["addrStreet1"].ToString();
                addrStreet2 = userDataReader["addrStreet2"].ToString();
                addrCity = userDataReader["addrCity"].ToString();
				addrState = userDataReader["addrState"].ToString();
                addrZip = userDataReader["addrZip"].ToString();
				numPhone = userDataReader["numPhone"].ToString();
                numCell = userDataReader["numCell"].ToString();
                numFax = userDataReader["numFax"].ToString();
				email = userDataReader["email"].ToString();
                website = userDataReader["website"].ToString();


                tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, addrStreet1, addrStreet2, addrCity, addrState, addrZip, "", numPhone, numFax, numCell, email, website, false);
				//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
			userConnection.Dispose();
		}
		public void PopulateRegadminList(string username)
		{
			userList = new SortedList();
			string uname;
			string nameTitle;
			string firstName;
			string lastName;
			string namePostfix;
			string org;
			string orgPosition;
			string addrState;
			string numPhone;
			string email;

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;

			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetRegadminsByUsername";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);

			userCommand.Parameters["@user"].Value = username;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();

			DaikonUser tempUser;

			while (userDataReader.Read())
			{
				uname = userDataReader["username"].ToString();
				nameTitle = userDataReader["nameTitle"].ToString();
				firstName = userDataReader["firstName"].ToString();
				lastName = userDataReader["lastName"].ToString();
				namePostfix = userDataReader["namePostfix"].ToString();
				org = userDataReader["org"].ToString();
				orgPosition = userDataReader["orgPosition"].ToString();
				addrState = userDataReader["addrState"].ToString();
				numPhone = userDataReader["numPhone"].ToString();
				email = userDataReader["email"].ToString();

				tempUser = new DaikonUser(uname, nameTitle, firstName, lastName, namePostfix, org, orgPosition, "", "", "", addrState, "", "", numPhone, "", "", email, "", false);
				//                tempUser = new DaikonUser(username);
				AddNewUser(tempUser);
			}
			userConnection.Dispose();
		}

		public void AddNewUser(DaikonUser user)
		{
			//userList.Add(user.Username, user);
            if (userList.ContainsKey(user.LastName + user.FirstName + user.Username))
                userList[user.LastName + user.FirstName + user.Username] = user;
            else
                userList.Add(user.LastName + user.FirstName + user.Username, user);
		}

		public void toXML(XmlTextWriter writer)
		{
//			writer.WriteStartElement("userlist");
			for (int i = 0; i < userList.Count; i++)
			{
				((DaikonUser)(userList.GetByIndex(i))).toXML(writer);
			}
//			writer.WriteEndElement();
		}
        public void toXML(XmlTextWriter writer, string outputcontext)
		{
//			writer.WriteStartElement("userlist");
			for (int i = 0; i < userList.Count; i++)
			{
				((DaikonUser)(userList.GetByIndex(i))).toXML(writer, outputcontext);
			}
//			writer.WriteEndElement();
		}

	}

    public class DaikonParticipant : DaikonUser
    {
        protected int contactID;       

        public DaikonParticipant()
        {
            contactID = 0;
            username = "";
            firstName = "";
            lastName = "";
            org = "";
        }

        public DaikonParticipant(int contactID)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonNonusercontactGetContactPublic";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@nonusercontact", SqlDbType.Int);

            userCommand.Parameters["@nonusercontact"].Value = contactID;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            if (userDataReader.HasRows)
            {
                userDataReader.Read();

//                username = userDataReader["username"].ToString();
                this.contactID = contactID;
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
                addrStreet1 = userDataReader["addrStreet1"].ToString();
                addrStreet2 = userDataReader["addrStreet2"].ToString();
                addrCity = userDataReader["addrCity"].ToString();
                addrState = userDataReader["addrState"].ToString();
                addrZip = userDataReader["addrZip"].ToString();
                addrZip4 = userDataReader["addrZip4"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                numFax = userDataReader["numFax"].ToString();
                numCell = userDataReader["numCell"].ToString();
                email = userDataReader["email"].ToString();
                website = userDataReader["website"].ToString();
                updatedDate = userDataReader["updatedDate"].ToString();
                updatedBy = userDataReader["updatedBy"].ToString();
                submitted = userDataReader["submitted"].ToString();
                approved = userDataReader["approved"].ToString();
            }
            else
            {
            }
            userConnection.Dispose();

        }

        public DaikonParticipant(string vusername)
        {
            
        }
        /*
        public bool claimProject(int sessionkey, string projNum, string claimCode)
        {
            return false;
        }
        */
        public bool saveUserToDB(string vuser, int sessionkey, int contactID)
        {
            string userSQL;
            bool updateSuccess;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonNonusercontactUpdateContact";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@contactID", SqlDbType.Int);
//            userCommand.Parameters.Add("@password", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);

            userCommand.Parameters["@user"].Value = vuser;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@contactID"].Value = contactID;
//            userCommand.Parameters["@password"].Value = dbNullify(null);
            userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            userCommand.Parameters["@org"].Value = dbNullify(org);
            userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            userCommand.Parameters["@email"].Value = dbNullify(email);
            userCommand.Parameters["@website"].Value = dbNullify(website);

            userConnection.Open();
            updateSuccess = (bool)userCommand.ExecuteScalar();

            //				UserRoles newTestRoleSet = new UserRoles(username);
            //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
            //				userRoles = newTestRoleSet;

            userConnection.Dispose();

            //			updateSuccess = (bool)updateSuccessRaw;
            return updateSuccess;

        }        

        new public bool saveUserToDB(string vuser, int sessionkey, string vusername, string vpassword)
        {
            return false;
        }
        new public bool saveNewUserToDB(string authKey, string password, string confpassword)
        {
            return false;
        }
        
        public bool saveNewEventContactToDB(string vuser, int sessionkey, int evNum)
        {
            bool writeSuccess;

                string userWriteSQL;
                string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                
                SqlConnection userConnection;
                SqlCommand userCommand;
                SqlDataReader userDataReader;

                userConnection = new SqlConnection(userConnString);

                userWriteSQL = "DaikonNonusercontactCreateContactForEvent";

                userCommand = new SqlCommand(userWriteSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;

                userCommand.Parameters.Add("@user", SqlDbType.VarChar, 25);
                userCommand.Parameters.Add("@sKey", SqlDbType.Int);
                userCommand.Parameters.Add("@evNum", SqlDbType.Int);
                userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
                userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
                userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 25);
                userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
                userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
                userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);

                userCommand.Parameters["@user"].Value = vuser;
                userCommand.Parameters["@sKey"].Value = sessionkey;
                userCommand.Parameters["@evNum"].Value = evNum;
                userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
                userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
                userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
                userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
                userCommand.Parameters["@org"].Value = dbNullify(org);
                userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
                userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
                userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
                userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
                userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
                userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
                userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
                userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
                userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
                userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
                userCommand.Parameters["@email"].Value = dbNullify(email);
                userCommand.Parameters["@website"].Value = dbNullify(website);

                userConnection.Open();
                //writeSuccess = (bool)userCommand.ExecuteScalar();
                userDataReader = userCommand.ExecuteReader();
                writeSuccess = userDataReader.HasRows;

                userConnection.Close();
                userCommand.Dispose();
                userConnection.Dispose();
                //				UserRoles newTestRoleSet = new UserRoles(username);
                //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                //				userRoles = newTestRoleSet;
                return writeSuccess;
        }

        new public void toXML(XmlTextWriter xmlOut, string outputcontext)
        {
            if (username != "")
            {
                xmlOut.WriteStartElement("nonusercontact");
                xmlOut.WriteAttributeString("contactID", contactID.ToString());
                xmlOut.WriteAttributeString("context", outputcontext);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
                xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                xmlOut.WriteElementString("website", website);
                xmlOut.WriteEndElement();

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
            else
            {
                xmlOut.WriteStartElement("nonusercontact");
                xmlOut.WriteAttributeString("contactID", contactID.ToString());
                xmlOut.WriteAttributeString("context", outputcontext);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
                xmlOut.WriteElementString("submitted", submitted);
                xmlOut.WriteElementString("approved", approved);
                xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                xmlOut.WriteElementString("website", website);                
                xmlOut.WriteEndElement();                

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
        }
    }

    public class DaikonUser : IComparable
    {
        protected string username;
        //		protected UserRole[] userRoles;
        protected UserRoles userRoles;
        protected DaikonGrantCollection sareGrants;
        protected DaikonGrantCollection grantSearchResults;
        protected string nameTitle;
        protected string firstName;
        protected string lastName;
        protected string namePostfix;
        protected string org;
        protected string orgPosition;
		protected string region;
		protected string addrStreet1;
        protected string addrStreet2;
        protected string addrCity;
        protected string addrState;
        protected string addrZip;
        protected string addrZip4;
        protected string numPhone;
        protected string numFax;
        protected string numCell;
        protected string email;
        protected string website;
        protected bool onEmailList;
        protected string updatedDate;
        protected string updatedBy;
        protected string firstRegisteredDate;
        protected string logInCount;
        protected string lastLogInDate;
        protected string submitted;
        protected string approved;

        public int CompareTo(object obj)
        {
            if (obj is DaikonUser)
            {
                DaikonUser tempUser = (DaikonUser)obj;
                string fullname = LastName + FirstName;
                string tuFullname = tempUser.LastName + tempUser.FirstName;

                return fullname.CompareTo(tuFullname);
            }

            throw new ArgumentException("object is not a DaikonUser");
        }

        public DaikonUser(string vusername, int vsessionKey, string vtargetUser)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetUserBySessionKey";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);

            userCommand.Parameters["@user"].Value = vusername;
            userCommand.Parameters["@sKey"].Value = vsessionKey;
            userCommand.Parameters["@targetUser"].Value = vtargetUser;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            if (userDataReader.HasRows)
            {
                userDataReader.Read();

                username = userDataReader["username"].ToString();
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
				region = userDataReader["region_code"].ToString();
                addrStreet1 = userDataReader["addrStreet1"].ToString();
                addrStreet2 = userDataReader["addrStreet2"].ToString();
                addrCity = userDataReader["addrCity"].ToString();
                addrState = userDataReader["addrState"].ToString();
                addrZip = userDataReader["addrZip"].ToString();
                addrZip4 = userDataReader["addrZip4"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                numFax = userDataReader["numFax"].ToString();
                numCell = userDataReader["numCell"].ToString();
                email = userDataReader["email"].ToString();
                website = userDataReader["website"].ToString();
                onEmailList = (bool)userDataReader["onEmailList"];
                updatedDate = userDataReader["updatedDate"].ToString();
                updatedBy = userDataReader["updatedBy"].ToString();
                firstRegisteredDate = userDataReader["firstRegisteredDate"].ToString();
                logInCount = userDataReader["logInCount"].ToString();
                lastLogInDate = userDataReader["lastLogInDate"].ToString();

                sareGrants = new DaikonGrantCollection();
                sareGrants.populateByUsername(username, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());
              
                UserRoles roleSet = new UserRoles(vusername, vsessionKey, vtargetUser);
                //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                userRoles = roleSet;
            }
            else
            {
                string userSQL1;
                string userConnString1 = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                SqlConnection userConnection1;
                SqlCommand userCommand1;
                SqlDataReader userDataReader1;

                userConnection1 = new SqlConnection(userConnString1);

                userSQL1 = "DaikonUserGetUserPublic";
                userCommand1 = new SqlCommand(userSQL1, userConnection1);
                userCommand1.CommandType = CommandType.StoredProcedure;
                userCommand1.Parameters.Add("@user", SqlDbType.VarChar, 12);

                userCommand1.Parameters["@user"].Value = vtargetUser;
               

                userConnection1.Open();
                userDataReader1 = userCommand1.ExecuteReader();

                if (userDataReader1.HasRows)
                {
                    userDataReader1.Read();

                    username = userDataReader1["username"].ToString();
                    nameTitle = userDataReader1["nameTitle"].ToString();
                    firstName = userDataReader1["firstName"].ToString();
                    lastName = userDataReader1["lastName"].ToString();
                    namePostfix = userDataReader1["namePostfix"].ToString();
                    org = userDataReader1["org"].ToString();
                    orgPosition = userDataReader1["orgPosition"].ToString();
                    region = userDataReader1["region_code"].ToString();
                    addrStreet1 = userDataReader1["addrStreet1"].ToString();
                    addrStreet2 = userDataReader1["addrStreet2"].ToString();
                    addrCity = userDataReader1["addrCity"].ToString();
                    addrState = userDataReader1["addrState"].ToString();
                    addrZip = userDataReader1["addrZip"].ToString();
                    addrZip4 = userDataReader1["addrZip4"].ToString();
                    numPhone = userDataReader1["numPhone"].ToString();
                    numFax = userDataReader1["numFax"].ToString();
                    numCell = userDataReader1["numCell"].ToString();
                    email = userDataReader1["email"].ToString();
                    website = userDataReader1["website"].ToString();
                    onEmailList = (bool)userDataReader1["onEmailList"];

                    UserRoles roleSet1 = new UserRoles(vtargetUser);
                    //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                    userRoles = roleSet1;
                }

                userConnection.Dispose();
                
            }
            userConnection.Dispose();

        }

        public DaikonUser(string vusername)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetUserPublic";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);

            userCommand.Parameters["@user"].Value = vusername;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            if (userDataReader.HasRows)
            {
                userDataReader.Read();

                username = userDataReader["username"].ToString();
                nameTitle = userDataReader["nameTitle"].ToString();
                firstName = userDataReader["firstName"].ToString();
                lastName = userDataReader["lastName"].ToString();
                namePostfix = userDataReader["namePostfix"].ToString();
                org = userDataReader["org"].ToString();
                orgPosition = userDataReader["orgPosition"].ToString();
				region = userDataReader["region_code"].ToString();
				addrStreet1 = userDataReader["addrStreet1"].ToString();
                addrStreet2 = userDataReader["addrStreet2"].ToString();
                addrCity = userDataReader["addrCity"].ToString();
                addrState = userDataReader["addrState"].ToString();
                addrZip = userDataReader["addrZip"].ToString();
                addrZip4 = userDataReader["addrZip4"].ToString();
                numPhone = userDataReader["numPhone"].ToString();
                numFax = userDataReader["numFax"].ToString();
                numCell = userDataReader["numCell"].ToString();
                email = userDataReader["email"].ToString();
                website = userDataReader["website"].ToString();
                onEmailList = (bool)userDataReader["onEmailList"];
                /*
                 *				updatedDate = userDataReader["updatedDate"].ToString();
                                updatedBy = userDataReader["updatedBy"].ToString();
                                firstRegisteredDate = userDataReader["firstRegisteredDate"].ToString();
                                logInCount = userDataReader["logInCount"].ToString();
                                lastLogInDate = userDataReader["lastLogInDate"].ToString();
                */
                sareGrants = new DaikonGrantCollection();
                sareGrants.populateByUsername(username, ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());
               
                UserRoles newTestRoleSet = new UserRoles();
                //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                userRoles = newTestRoleSet;
            }
            else
            {
            }
            userConnection.Dispose();

        }

        public DaikonUser(string vusername, string vnameTitle, string vfirstName, string vlastName, string vnamePostfix, string vorg, string vorgPosition, string vaddrStreet1, string vaddrStreet2, string vaddrCity, string vaddrState, string vaddrZip, string vaddrZip4, string vnumPhone, string vnumFax, string vnumCell, string vemail, string vwebsite, bool vonEmailList)
        {
            username = vusername;
            nameTitle = vnameTitle;
            firstName = vfirstName;
            lastName = vlastName;
            namePostfix = vnamePostfix;
            org = vorg;
            orgPosition = vorgPosition;
            addrStreet1 = vaddrStreet1;
            addrStreet2 = vaddrStreet2;
            addrCity = vaddrCity;
            addrState = vaddrState;
            addrZip = vaddrZip;
            addrZip4 = vaddrZip4;
            numPhone = vnumPhone;
            numFax = vnumFax;
            numCell = vnumCell;
            email = vemail;
            website = vwebsite;
            onEmailList = vonEmailList;
			region = "";

            userRoles = new UserRoles();

            //			userRoles = new UserRole[1];
            //			userRoles[0] = new UserRole();
        }
        public DaikonUser()
        {
            username = "";
			nameTitle = "";
            firstName = "";
            lastName = "";
			namePostfix = "";
            org = "";
			orgPosition = "";
			addrCity = "";
			addrState = "";
			addrStreet1 = "";
			addrStreet2 = "";
			addrZip = "";
			addrZip4 = "";
			numPhone = "";
			numCell = "";
			numFax = "";
			email = "";
			website = "";

			region = "";

            userRoles = new UserRoles();

            //			userRoles = new UserRole[1];
            //			userRoles[0] = new UserRole();
        }
        public DaikonGrantCollection Grants
        {
            get
            {
                return sareGrants;
            }
            set
            {
                sareGrants = value;
            }
        }
        
        public void changesXML(XmlTextWriter xmlOut)
        {

        }


        public int claimProject(int sessionkey, string projNum, string claimCode)
        {
            string userSQL;
            int updateSuccess = 0;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserClaimGrantOwnership_CheckClaimCode";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@claimSuccess", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@claimKey", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add(keyOutput);

            userCommand.Parameters["@user"].Value = this.username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@projNum"].Value = dbNullify(projNum);
            userCommand.Parameters["@claimKey"].Value = dbNullify(claimCode);

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
           
            if (keyOutput.Value.ToString().Length > 0)
                updateSuccess = (int)keyOutput.Value;

            //UserRoles newTestRoleSet = new UserRoles(username);
            //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
            //userRoles = newTestRoleSet;

            userConnection.Dispose();
            
            return updateSuccess;

        }

        public bool saveUserToDB(string vuser, int sessionkey, string vusername)
        {
            string userSQL;
            bool updateSuccess;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserUpdateUser";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@username", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@password", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@onEmailList", SqlDbType.Bit);

            userCommand.Parameters["@user"].Value = vuser;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@username"].Value = vusername;
            userCommand.Parameters["@password"].Value = dbNullify(null);
            userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            userCommand.Parameters["@org"].Value = dbNullify(org);
            userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            userCommand.Parameters["@email"].Value = dbNullify(email);
            userCommand.Parameters["@website"].Value = dbNullify(website);
            userCommand.Parameters["@onEmailList"].Value = onEmailList;

            userConnection.Open();
            updateSuccess = (bool)userCommand.ExecuteScalar();

            //				UserRoles newTestRoleSet = new UserRoles(username);
            //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
            //				userRoles = newTestRoleSet;

            userConnection.Dispose();

            userRoles.saveRolesToDB(vuser, sessionkey, vusername);

            //			updateSuccess = (bool)updateSuccessRaw;
            return updateSuccess;

        }
        public bool saveUserToDB(string vuser, int sessionkey, string vusername, string vpassword)
        {
            string userSQL;
            bool updateSuccess;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserUpdateUser";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@username", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@password", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@onEmailList", SqlDbType.Bit);

            userCommand.Parameters["@user"].Value = vuser;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@username"].Value = vusername;
            userCommand.Parameters["@password"].Value = dbNullify(vpassword);
            userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            userCommand.Parameters["@org"].Value = dbNullify(org);
            userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            userCommand.Parameters["@email"].Value = dbNullify(email);
            userCommand.Parameters["@website"].Value = dbNullify(website);
            userCommand.Parameters["@onEmailList"].Value = onEmailList;

            userConnection.Open();
            updateSuccess = (bool)userCommand.ExecuteScalar();

            //				UserRoles newTestRoleSet = new UserRoles(username);
            //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
            //				userRoles = newTestRoleSet;

            userConnection.Dispose();

            userRoles.saveRolesToDB(vuser, sessionkey, vusername);

            //			updateSuccess = (bool)updateSuccessRaw;
            return updateSuccess;

        }
        public bool saveNewUserToDBx(string authKey, string password, string confpassword)
        {
            if (string.Compare(password, confpassword, false) == 0)
                return false;
            else
            {
                string userSQL;
                string userWriteSQL;
                int userRowCount;
                string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                
                SqlConnection userConnection;
                SqlCommand userCommand;
                SqlDataReader userDataReader;

                userConnection = new SqlConnection(userConnString);

                userSQL = "Select top 1 * from users where username like '" + username + "'";
                userCommand = new SqlCommand(userSQL, userConnection);
                userConnection.Open();
                userDataReader = userCommand.ExecuteReader();
                if (userDataReader.HasRows == false)
                {
                    userConnection.Dispose();
                    userCommand.Dispose();
                    userWriteSQL = "INSERT INTO users (username, password, nameTitle, firstName, lastName, namePostfix, org, orgPosition, addrStreet1, addrStreet2, addrCity, addrState, addrZip, addrZip4, numPhone, numFax, numCell, email, website) " +
                        "Values (@username, @password, @nameTitle, @firstName, @lastName, @namePostfix, @org, @orgPosition, @addrStreet1, @addrStreet2, @addrCity, @addrState, @addrZip, @addrZip4, @numPhone, @numFax, @numCell, @email, @website) " +
                        "INSERT INTO userRoles (username, userRole) VALUES (@username, 'genUser')";

                    userCommand = new SqlCommand(userWriteSQL, userConnection);

                    userCommand.Parameters.Add("@username", SqlDbType.VarChar, 25);
                    userCommand.Parameters.Add("@password", SqlDbType.VarChar, 25);
                    userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
                    userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
                    userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
                    userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
                    userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 25);
                    userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
                    userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
                    userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
                    userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
                    userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
                    userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
                    userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);

                    userCommand.Parameters["@username"].Value = username;
                    userCommand.Parameters["@password"].Value = password;
                    userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
                    userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
                    userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
                    userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
                    userCommand.Parameters["@org"].Value = dbNullify(org);
                    userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
                    userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
                    userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
                    userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
                    userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
                    userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
                    userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
                    userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
                    userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
                    userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
                    userCommand.Parameters["@email"].Value = dbNullify(email);
                    userCommand.Parameters["@website"].Value = dbNullify(website);

                    userConnection.Open();
                    userRowCount = userCommand.ExecuteNonQuery();

                    userConnection.Close();
                    userCommand.Dispose();
                    userConnection.Dispose();
                    //				UserRoles newTestRoleSet = new UserRoles(username);
                    //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                    //				userRoles = newTestRoleSet;
                    return true;
                }
                else
                {
                    userConnection.Dispose();
                    return false;
                }
            }
        }
        public bool saveNewUserToDB(string authKey, string password, string confpassword)
        {
            bool writeSuccess;

            if (string.Compare(password, confpassword, false) == 0)
                return false;
            else
            {
                string userWriteSQL;
                string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                
                SqlConnection userConnection;
                SqlCommand userCommand;
                
                userConnection = new SqlConnection(userConnString);

                userWriteSQL = "DaikonUserCreateUser";

                userCommand = new SqlCommand(userWriteSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;

                userCommand.Parameters.Add("@username", SqlDbType.VarChar, 25);
                userCommand.Parameters.Add("@password", SqlDbType.VarChar, 25);
                userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
                userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
                userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 25);
                userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
                userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
                userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);
                userCommand.Parameters.Add("@onEmailList", SqlDbType.Bit);

                userCommand.Parameters["@username"].Value = username;
                userCommand.Parameters["@password"].Value = password;
                userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
                userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
                userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
                userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
                userCommand.Parameters["@org"].Value = dbNullify(org);
                userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
                userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
                userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
                userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
                userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
                userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
                userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
                userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
                userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
                userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
                userCommand.Parameters["@email"].Value = dbNullify(email);
                userCommand.Parameters["@website"].Value = dbNullify(website);
                userCommand.Parameters["@onEmailList"].Value = onEmailList;

                userConnection.Open();
                writeSuccess = (bool)userCommand.ExecuteScalar();

                userConnection.Close();
                userCommand.Dispose();
                userConnection.Dispose();
                //				UserRoles newTestRoleSet = new UserRoles(username);
                //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
                //				userRoles = newTestRoleSet;
                return writeSuccess;
            }
        }

        public bool saveNewParticipantToDB(string vuser, int sessionkey, string projNum)
        {
            bool writeSuccess;

            string nonuserWriteSQL;
            string nonuserConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection nonuserConnection;
            SqlCommand nonuserCommand;
            SqlDataReader nonuserDataReader;

            nonuserConnection = new SqlConnection(nonuserConnString);

            nonuserWriteSQL = "DaikonNonusercontactCreateContactForProject";

            nonuserCommand = new SqlCommand(nonuserWriteSQL, nonuserConnection);
            nonuserCommand.CommandType = CommandType.StoredProcedure;

            nonuserCommand.Parameters.Add("@user", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@sKey", SqlDbType.Int);
            nonuserCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            nonuserCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            nonuserCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@addrCountry", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            nonuserCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            nonuserCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);

            nonuserCommand.Parameters["@user"].Value = vuser;
            nonuserCommand.Parameters["@sKey"].Value = sessionkey;
            nonuserCommand.Parameters["@projNum"].Value = projNum;
            nonuserCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            nonuserCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            nonuserCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            nonuserCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            nonuserCommand.Parameters["@org"].Value = dbNullify(org);
            nonuserCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            nonuserCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            nonuserCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            nonuserCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            nonuserCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            nonuserCommand.Parameters["@addrCountry"].Value = "USA";
            nonuserCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            nonuserCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            nonuserCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            nonuserCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            nonuserCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            nonuserCommand.Parameters["@email"].Value = dbNullify(email);
            nonuserCommand.Parameters["@website"].Value = dbNullify(website);

            nonuserConnection.Open();
            nonuserDataReader = nonuserCommand.ExecuteReader();
            writeSuccess = nonuserDataReader.HasRows;

            nonuserConnection.Close();
            nonuserCommand.Dispose();
            nonuserConnection.Dispose();

            return writeSuccess;
        }

        public bool saveNewCoordinatorToDB(string vuser, int sessionkey, int coreID)
        {
            bool writeSuccess;

            string nonuserWriteSQL;
            string nonuserConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection nonuserConnection;
            SqlCommand nonuserCommand;
            SqlDataReader nonuserDataReader;

            nonuserConnection = new SqlConnection(nonuserConnString);

            nonuserWriteSQL = "DaikonNonusercontactCreateContactForCoreNoreturn";

            nonuserCommand = new SqlCommand(nonuserWriteSQL, nonuserConnection);
            nonuserCommand.CommandType = CommandType.StoredProcedure;

            nonuserCommand.Parameters.Add("@user", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@sKey", SqlDbType.Int);
            nonuserCommand.Parameters.Add("@coreID", SqlDbType.BigInt);
            nonuserCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            nonuserCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            nonuserCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@addrCountry", SqlDbType.VarChar, 25);
            nonuserCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            nonuserCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            nonuserCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            nonuserCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);
            nonuserCommand.Parameters.Add("@ownershipType", SqlDbType.Int);

            nonuserCommand.Parameters["@user"].Value = vuser;
            nonuserCommand.Parameters["@sKey"].Value = sessionkey;
            nonuserCommand.Parameters["@coreID"].Value = coreID;
            nonuserCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            nonuserCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            nonuserCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            nonuserCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            nonuserCommand.Parameters["@org"].Value = dbNullify(org);
            nonuserCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            nonuserCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            nonuserCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            nonuserCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            nonuserCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            nonuserCommand.Parameters["@addrCountry"].Value = "USA";
            nonuserCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            nonuserCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            nonuserCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            nonuserCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            nonuserCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            nonuserCommand.Parameters["@email"].Value = dbNullify(email);
            nonuserCommand.Parameters["@website"].Value = dbNullify(website);
            // ownershipType = 1 becuase we need to add project pi (coordinator)
            nonuserCommand.Parameters["@ownershipType"].Value = 1;

            nonuserConnection.Open();
            nonuserDataReader = nonuserCommand.ExecuteReader();
            writeSuccess = nonuserDataReader.HasRows;

            nonuserConnection.Close();
            nonuserCommand.Dispose();
            nonuserConnection.Dispose();

            return writeSuccess;
        }

        public bool updateParticipantToDB(string vuser, int sessionkey, int contactID)
        {
            string userSQL;
            bool updateSuccess;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonNonusercontactUpdateContact";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@contactID", SqlDbType.Int);
            //            userCommand.Parameters.Add("@password", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@nameTitle", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@lastName", SqlDbType.VarChar, 120);
            userCommand.Parameters.Add("@namePostfix", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@org", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@orgPosition", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet1", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrStreet2", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrCity", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@addrState", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@addrZip", SqlDbType.VarChar, 5);
            userCommand.Parameters.Add("@addrZip4", SqlDbType.VarChar, 4);
            userCommand.Parameters.Add("@numPhone", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numFax", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@numCell", SqlDbType.VarChar, 50);
            userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);
            userCommand.Parameters.Add("@website", SqlDbType.VarChar, 255);

            userCommand.Parameters["@user"].Value = vuser;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@contactID"].Value = contactID;
            //            userCommand.Parameters["@password"].Value = dbNullify(null);
            userCommand.Parameters["@nameTitle"].Value = dbNullify(nameTitle);
            userCommand.Parameters["@firstName"].Value = dbNullify(firstName);
            userCommand.Parameters["@lastName"].Value = dbNullify(lastName);
            userCommand.Parameters["@namePostfix"].Value = dbNullify(namePostfix);
            userCommand.Parameters["@org"].Value = dbNullify(org);
            userCommand.Parameters["@orgPosition"].Value = dbNullify(orgPosition);
            userCommand.Parameters["@addrStreet1"].Value = dbNullify(addrStreet1);
            userCommand.Parameters["@addrStreet2"].Value = dbNullify(addrStreet2);
            userCommand.Parameters["@addrCity"].Value = dbNullify(addrCity);
            userCommand.Parameters["@addrState"].Value = dbNullify(addrState);
            userCommand.Parameters["@addrZip"].Value = dbNullify(addrZip);
            userCommand.Parameters["@addrZip4"].Value = dbNullify(addrZip4);
            userCommand.Parameters["@numPhone"].Value = dbNullify(numPhone);
            userCommand.Parameters["@numFax"].Value = dbNullify(numFax);
            userCommand.Parameters["@numCell"].Value = dbNullify(numCell);
            userCommand.Parameters["@email"].Value = dbNullify(email);
            userCommand.Parameters["@website"].Value = dbNullify(website);

            userConnection.Open();
            updateSuccess = (bool)userCommand.ExecuteScalar();

            //				UserRoles newTestRoleSet = new UserRoles(username);
            //UserRoles newTestRoleSet = new UserRoles(genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor);
            //				userRoles = newTestRoleSet;

            userConnection.Dispose();

            //			updateSuccess = (bool)updateSuccessRaw;
            return updateSuccess;

        }
        public bool deleteParticipantFromDB(string vuser, int sessionkey, int contactID)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonNonusercontactDelete";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@contactID", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = vuser;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@contactID"].Value = contactID;

            userConnection.Open();
            userCommand.ExecuteScalar();

            userConnection.Dispose();

            return true;
        }

        public bool deleteCoordinatorFromDB(string vuser, int coreID)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonProjectCoordinatorDelete";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@username", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@coreID", SqlDbType.Int);

            userCommand.Parameters["@username"].Value = vuser;
            userCommand.Parameters["@coreID"].Value = coreID;

            userConnection.Open();
            userCommand.ExecuteScalar();

            userConnection.Dispose();

            return true;
        }
        public bool deleteUserFromDB(string user, int sessionkey, string targetUser)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserDelete";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;

            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
            
            userCommand.Parameters["@user"].Value = user;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@targetUser"].Value = targetUser;
            
            userConnection.Open();
            userCommand.ExecuteScalar();

            userConnection.Dispose();

            return true;
        }

        public object dbNullify(object o)
        {
            if (o == null)
                o = DBNull.Value;
            else if (string.Compare((string)(o), "") == 0)
                o = DBNull.Value;
            else if (string.Compare((string)(o), "--") == 0)
                o = DBNull.Value;

            return o;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string NameTitle
        {
            get
            {
                return nameTitle;
            }
            set
            {
                nameTitle = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string NamePostfix
        {
            get { return namePostfix; }
            set { namePostfix = value; }
        }
        public string FullName
        {
            get { return firstName + " " + lastName + " " + namePostfix; }
        }
        public string Org
        {
            get { return org; }
            set { org = value; }
        }
        public string OrgPosition
        {
            get { return orgPosition; }
            set { orgPosition = value; }
        }
		public string Region
		{
			get { return region; }
			set { region = value; }
		}
		public string AddrStreet1
        {
            get { return addrStreet1; }
            set { addrStreet1 = value; }
        }
        public string AddrStreet2
        {
            get { return addrStreet2; }
            set { addrStreet2 = value; }
        }
        public string AddrCity
        {
            get { return addrCity; }
            set { addrCity = value; }
        }
        public string AddrState
        {
            get { return addrState; }
            set { addrState = value; }
        }
        public string AddrZip
        {
            get { return addrZip; }
            set { addrZip = value; }
        }
        public string AddrZip4
        {
            get { return addrZip4; }
            set { addrZip4 = value; }
        }
        public string NumPhone
        {
            get { return numPhone; }
            set { numPhone = value; }
        }
        public string NumPhone1()
        {
            string[] phoneArr = numPhone.Split("-() #".ToCharArray());
            if (phoneArr.GetUpperBound(0) >= 0)
                return phoneArr[0];
            else
                return null;
        }
        public string NumPhone2()
        {
            string[] phoneArr = numPhone.Split("-() #".ToCharArray());
            if (phoneArr.GetUpperBound(0) >= 1)
                return phoneArr[1];
            else
                return null;
        }
        public string NumPhone3()
        {
            string[] phoneArr = numPhone.Split("-() #".ToCharArray());
            if (phoneArr.GetUpperBound(0) >= 2)
                return phoneArr[2];
            else
                return null;
        }
        public string NumFax
        {
            get { return numFax; }
            set { numFax = value; }
        }
        public string NumFax1()
        {
            string[] FaxArr = numFax.Split("-() #".ToCharArray());
            if (FaxArr.GetUpperBound(0) >= 0)
                return FaxArr[0];
            else
                return null;
        }
        public string NumFax2()
        {
            string[] FaxArr = numFax.Split("-() #".ToCharArray());
            if (FaxArr.GetUpperBound(0) >= 1)
                return FaxArr[1];
            else
                return null;
        }
        public string NumFax3()
        {
            string[] FaxArr = numFax.Split("-() #".ToCharArray());
            if (FaxArr.GetUpperBound(0) >= 2)
                return FaxArr[2];
            else
                return null;
        }
        public string NumCell
        {
            get { return numCell; }
            set { numCell = value; }
        }
        public string NumCell1()
        {
            string[] CellArr = numCell.Split("-() #".ToCharArray());
            if (CellArr.GetUpperBound(0) >= 0)
                return CellArr[0];
            else
                return null;
        }
        public string NumCell2()
        {
            string[] CellArr = numCell.Split("-() #".ToCharArray());
            if (CellArr.GetUpperBound(0) >= 1)
                return CellArr[1];
            else
                return null;
        }
        public string NumCell3()
        {
            string[] CellArr = numCell.Split("-() #".ToCharArray());
            if (CellArr.GetUpperBound(0) >= 2)
                return CellArr[2];
            else
                return null;
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        public bool OnEmailList
        {
            get { return onEmailList; }
            set { onEmailList = value; }
        }
        /*
        public String[] RoleCodes
        {
            get { return userRoles.getRoleCodes(); }
        }
        */
        public UserRoles Roles
        {
            get { return this.userRoles; }
            set { userRoles = value; }
        }

        /*		public void addRole(UserRole addRole)
                {
                    int oldArrSize = userRoles.GetUpperBound(0) + 1;
                    UserRole[] newRoleArr = new UserRole[oldArrSize + 1];
                    Array.Copy(userRoles, userRoles.GetLowerBound(0), newRoleArr, userRoles.GetLowerBound(0), oldArrSize);
                    newRoleArr[oldArrSize] = addRole;

                    userRoles = newRoleArr;
                }
        */

        public void setRoles(UserRoles userRoleSet)
        {
            this.userRoles = userRoleSet;
        }

        public void toXML(XmlTextWriter xmlOut)
        {
            if (username != "")
            {
                xmlOut.WriteStartElement("user");
                xmlOut.WriteAttributeString("username", username);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
				xmlOut.WriteElementString("region", region);
				xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                xmlOut.WriteElementString("website", website);
                xmlOut.WriteElementString("onEmailList", onEmailList.ToString());
                xmlOut.WriteEndElement();

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
            else
            {
                xmlOut.WriteStartElement("user");
                xmlOut.WriteAttributeString("username", username);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
				xmlOut.WriteElementString("region", region);
				xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                xmlOut.WriteElementString("website", website);
                xmlOut.WriteElementString("onEmailList", onEmailList.ToString());
                xmlOut.WriteEndElement();

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
        }
        public void toXML(XmlTextWriter xmlOut, string outputcontext)
        {
            if (username != "")
            {
                xmlOut.WriteStartElement("user");
                xmlOut.WriteAttributeString("username", username);
                xmlOut.WriteAttributeString("context", outputcontext);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
				xmlOut.WriteElementString("region", region);
				xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (website != null)
                {
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                }
                xmlOut.WriteElementString("website", website);
                xmlOut.WriteElementString("onEmailList", onEmailList.ToString());
                xmlOut.WriteEndElement();

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
            else
            {
                xmlOut.WriteStartElement("user");
                xmlOut.WriteAttributeString("username", username);
                xmlOut.WriteAttributeString("context", outputcontext);
                xmlOut.WriteElementString("nametitle", nameTitle);
                xmlOut.WriteElementString("firstname", firstName);
                xmlOut.WriteElementString("lastname", lastName);
                xmlOut.WriteElementString("namepostfix", namePostfix);
                xmlOut.WriteStartElement("organization");
                xmlOut.WriteAttributeString("name", org);
                xmlOut.WriteElementString("position", orgPosition);
                xmlOut.WriteEndElement();
				xmlOut.WriteElementString("region", region);
				xmlOut.WriteStartElement("contact");
                xmlOut.WriteElementString("addrStreet1", addrStreet1);
                xmlOut.WriteElementString("addrStreet2", addrStreet2);
                xmlOut.WriteElementString("addrCity", addrCity);
                xmlOut.WriteElementString("addrState", addrState);
                xmlOut.WriteElementString("addrZip", addrZip);
                xmlOut.WriteElementString("addrZip4", addrZip4);
                xmlOut.WriteElementString("numPhone", numPhone);
                xmlOut.WriteElementString("numFax", numFax);
                xmlOut.WriteElementString("numCell", numCell);
                xmlOut.WriteElementString("email", email);
                if (!website.Contains("http://") && website.Length != 0)
                    website = "http://" + website;
                xmlOut.WriteElementString("website", website);
                xmlOut.WriteElementString("onEmailList", onEmailList.ToString());
                xmlOut.WriteEndElement();

                userRoles.toXML(xmlOut);

                xmlOut.WriteEndElement();
            }
        }
    }
}
