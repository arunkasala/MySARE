using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

namespace daikon
{
/*
	public class UserRoles
	{
		private Boolean[] roleSet;
		private String[] roleList = new String[] { "General User", "National Admin", "Regional Admin", "Resource Compilation Manager", "Resource Manager", "Project PI", "Project Proposer", "Calendar Submitter", "Resource Author", "Site Admin", "SARE Staff" };
		private String[] roleCodes = new String[] { "genUser", "natAdmin", "regAdmin", "resCompManager", "resManager", "projPI", "projProposer", "calSubmitter", "resAuthor", "admin", "natStaff" };

		public UserRoles()
		{
			roleSet = new Boolean[11];
			roleSet[0] = true;
		}
		public UserRoles(String username)
		{
			roleSet = new Boolean[11];

			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
			
			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;
			userConnection = new SqlConnection(userConnString);

			userSQL = "DaikonUserGetRolesByUser";
			userCommand = new SqlCommand(userSQL, userConnection);
			userCommand.CommandType = CommandType.StoredProcedure;
			userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);

			userCommand.Parameters["@user"].Value = username;

			userConnection.Open();
			userDataReader = userCommand.ExecuteReader();
			while (userDataReader.Read())
			{
				switch (userDataReader["userRole"].ToString())
				{
					case "genUser":
						roleSet[0] = true;
						break;
					case "natAdmin":
						roleSet[1] = true;
						break;
					case "regAdmin":
						roleSet[2] = true;
						break;
					case "resCompManager":
						roleSet[3] = true;
						break;
					case "resManager":
						roleSet[4] = true;
						break;
					case "projPI":
						roleSet[5] = true;
						break;
					case "projProposer":
						roleSet[6] = true;
						break;
					case "calSubmitter":
						roleSet[7] = true;
						break;
					case "resAuthor":
						roleSet[8] = true;
						break;
					case "admin":
						roleSet[9] = true;
						break;
					case "natStaff":
						roleSet[10] = true;
						break;
				}
			}

		}
		public UserRoles(Boolean genUser, Boolean natAdmin, Boolean regAdmin, Boolean resCompManager, Boolean resManager, Boolean projPI, Boolean projProposer, Boolean calSubmitter, Boolean resAuthor, Boolean admin, Boolean natStaff)
		{
			roleSet = new Boolean[] { genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor, admin, natStaff };
		}

		public void SetRoles(Boolean genUser, Boolean natAdmin, Boolean regAdmin, Boolean resCompManager, Boolean resManager, Boolean projPI, Boolean projProposer, Boolean calSubmitter, Boolean resAuthor, Boolean admin, Boolean natStaff)
		{
			roleSet[0] = genUser;
			roleSet[1] = natAdmin;
			roleSet[2] = regAdmin;
			roleSet[3] = resCompManager;
			roleSet[4] = resManager;
			roleSet[5] = projPI;
			roleSet[6] = projProposer;
			roleSet[7] = calSubmitter;
			roleSet[8] = resAuthor;
			roleSet[9] = admin;
			roleSet[10] = natStaff;
		}

		public string roleToString(int role)
		{
			return roleList[role];
		}
		public string roleToCode(int role)
		{
			return roleCodes[role];
		}

		public void saveRolesToDB(string username, int sessionKey, string targetUser)
		{
			string userSQL;
			string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

			SqlConnection userConnection;
			SqlCommand userCommand;
			SqlDataReader userDataReader;
			userConnection = new SqlConnection(userConnString);
			userConnection.Open();

			string roleList = "";
			for (int i = 0; i < roleSet.GetLength(0); i++)
			{
				if (roleSet[i] == true)
				{
					userSQL = "DaikonUserAddRole";
					userCommand = new SqlCommand(userSQL, userConnection);
					userCommand.CommandType = CommandType.StoredProcedure;
					userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@role", SqlDbType.VarChar, 12);

					userCommand.Parameters["@user"].Value = username;
					userCommand.Parameters["@sKey"].Value = sessionKey;
					userCommand.Parameters["@targetUser"].Value = targetUser;
					userCommand.Parameters["@role"].Value = this.roleToCode(i);

					userCommand.ExecuteScalar();
				}
				else
				{
					userSQL = "DaikonUserRemoveRole";
					userCommand = new SqlCommand(userSQL, userConnection);
					userCommand.CommandType = CommandType.StoredProcedure;
					userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
					userCommand.Parameters.Add("@role", SqlDbType.VarChar, 12);

					userCommand.Parameters["@user"].Value = username;
					userCommand.Parameters["@sKey"].Value = sessionKey;
					userCommand.Parameters["@targetUser"].Value = targetUser;
					userCommand.Parameters["@role"].Value = this.roleToCode(i);

					userCommand.ExecuteScalar();
				}
			}
			userConnection.Dispose();
		}

		public string listRoles()
		{
			string roleList = "";
			for (int i = 0; i < roleSet.GetLength(0); i++)
			{
				if (roleSet[i] == true)
				{
					roleList = roleList + this.roleToString(i) + ",";
				}
			}
			return roleList;
		}
		public void toXML(XmlTextWriter xmlOut)
		{
			xmlOut.WriteStartElement("userroles");
			for (int i = 0; i < roleSet.GetLength(0); i++)
			{
				if (roleSet[i] == true)
				{
					xmlOut.WriteStartElement("role");
					xmlOut.WriteAttributeString("code", this.roleToCode(i));
					xmlOut.WriteAttributeString("description", this.roleToString(i));
					xmlOut.WriteEndElement();
				}
			}
			xmlOut.WriteEndElement();
		}
		public String[] getRoleCodes()
		{
			string roleList = "";
			for (int i = 0; i < roleSet.GetLength(0); i++)
			{
				if (roleSet[i] == true)
				{
					roleList = roleList + this.roleToCode(i) + ",";
				}
			}

			String[] roleCodes = roleList.Split(",".ToCharArray());
			return roleCodes;
		}

		public Boolean isGenUser()
		{
			return roleSet[0];
		}
		public Boolean isRoleAdmin()
		{
			return (isAdmin() || isNatAdmin() || isRegAdmin() );
		}
		public Boolean isNatAdmin()
		{
			return roleSet[1];
		}
		public Boolean isRegAdmin()
		{
			return roleSet[2];
		}
		public Boolean isResCompManager()
		{
			return roleSet[3];
		}
		public Boolean isResManager()
		{
			return roleSet[4];
		}
		public Boolean isProjPI()
		{
			return roleSet[5];
		}
		public Boolean isProjProposer()
		{
			return roleSet[6];
		}
		public Boolean isCalSubmitter()
		{
			return roleSet[7];
		}
		public Boolean isResAuthor()
		{
			return roleSet[8];
		}
		public Boolean isAdmin()
		{
			return roleSet[9];
		}
		public Boolean isNatStaff()
		{
			return roleSet[10];
		}

	}
/**/
    public class UserRole
    {
        protected int roleID;
        protected string roleCode;
        protected string forRegion;
        protected string roleDescription;
        protected int rolePriority;
        protected int typeCode;
        protected bool typeAdmin;
        protected bool typeWriter;
        protected bool typeReader;
        protected bool typeApprover;

        public UserRole()
        {
            roleCode = "genUser";
            roleDescription = "General User";
            rolePriority = 100;
            typeCode = 0;
            typeAdmin = false;
            typeWriter = false;
            typeReader = true;
            typeApprover = false;
        }
        public UserRole(string roleCode, string forRegion, string roleDescription, int rolePriority, int typeCode, bool typeAdmin, bool typeWriter, bool typeReader, bool typeApprover)
        {
            this.roleCode = roleCode;
            this.forRegion = forRegion;
            this.roleDescription = roleDescription;
            this.rolePriority = rolePriority;
            this.typeCode = typeCode;
            this.typeAdmin = typeAdmin;
            this.typeWriter = typeWriter;
            this.typeReader = typeReader;
            this.typeApprover = typeApprover;
        }
        public UserRole(string roleCode, string forRegion)
        {
            this.roleID = 0;
            this.roleCode = roleCode;
            this.forRegion = forRegion;
        }
        public UserRole(int roleID, string roleCode, string forRegion, string roleDescription, int rolePriority, int typeCode, bool typeAdmin, bool typeWriter, bool typeReader, bool typeApprover)
        {
            this.roleID = roleID;
            this.roleCode = roleCode;
            this.forRegion = forRegion;
            this.roleDescription = roleDescription;
            this.rolePriority = rolePriority;
            this.typeCode = typeCode;
            this.typeAdmin = typeAdmin;
            this.typeWriter = typeWriter;
            this.typeReader = typeReader;
            this.typeApprover = typeApprover;
        }
        public UserRole(string username, int sessionkey, int roleID)
        {
            this.roleID = roleID;

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetRoleByID";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@roleID", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@roleID"].Value = roleID;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();

            userDataReader.Read();

            this.roleCode = userDataReader["roleCode"].ToString();
            this.forRegion = userDataReader["forRegion"].ToString();
            this.roleDescription = userDataReader["roleDescription"].ToString();
            this.rolePriority = (int)userDataReader["rolePriority"];
            this.typeCode = (int)userDataReader["typeCode"];
            this.typeAdmin = (bool)userDataReader["typeAdmin"];
            this.typeWriter = (bool)userDataReader["typeWriter"];
            this.typeReader = (bool)userDataReader["typeReader"];
            this.typeApprover = (bool)userDataReader["typeApprover"];

            userDataReader.Close();
            userConnection.Dispose();
        }

        protected void Refresh(string username, int sessionkey)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetRoleByID";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@roleID", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@roleID"].Value = roleID;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();

            userDataReader.Read();

            this.roleCode = userDataReader["userRole"].ToString();
            this.forRegion = userDataReader["forRegion"].ToString();
            this.roleDescription = userDataReader["roleDescription"].ToString();
            this.rolePriority = (int)userDataReader["rolePriority"];
            this.typeCode = (int)userDataReader["typeCode"];
            this.typeAdmin = (bool)userDataReader["typeAdmin"];
            this.typeWriter = (bool)userDataReader["typeWriter"];
            this.typeReader = (bool)userDataReader["typeReader"];
            this.typeApprover = (bool)userDataReader["typeApprover"];

            userDataReader.Close();
            userConnection.Dispose();
        }

        public void SaveRoleToDB (string username, int sessionkey, string targetUser)
        {
            int newRoleID;
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);
            userConnection.Open();

            if (this.RoleID == 0)
            {
                userSQL = "DaikonUserAddRole";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;
                userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
                userCommand.Parameters.Add("@sKey", SqlDbType.Int);
                userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
                userCommand.Parameters.Add("@role", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@forRegion", SqlDbType.VarChar, 2);

                userCommand.Parameters["@user"].Value = username;
                userCommand.Parameters["@sKey"].Value = sessionkey;
                userCommand.Parameters["@targetUser"].Value = targetUser;
                userCommand.Parameters["@role"].Value = this.RoleCode;
                userCommand.Parameters["@forRegion"].Value = dbNullify(this.forRegion);

                newRoleID = (int)userCommand.ExecuteScalar();
                if (newRoleID > 0)
                {
                    this.roleID = newRoleID;
                    this.Refresh(username, sessionkey);
                }
            }
            userConnection.Dispose();
        }
        public void RemoveRoleFromDB (string username, int sessionkey)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            
            userConnection = new SqlConnection(userConnString);
            userConnection.Open();

            userSQL = "DaikonUserRemoveRoleByID";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@roleID", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@roleID"].Value = this.RoleID;

            userCommand.ExecuteScalar();
            userConnection.Dispose();
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

 		public int RoleID
		{
			get { return roleID; }
		}
        public string RoleCode
        {
            get { return roleCode; }
            set { roleCode = value; }
        }
        public string ForRegion
        {
            get { return forRegion; }
            set { forRegion = value; }
        }
        public string RoleDescription
        {
            get { return roleDescription; }
        }
        public int RolePriority
        {
            get { return rolePriority; }
        }
        public int TypeCode
        {
            get { return typeCode; }
        }
        public bool TypeAdmin
        {
            get { return typeAdmin; }
        }
        public bool TypeWriter
        {
            get { return typeWriter; }
        }
        public bool TypeReader
        {
            get { return typeReader; }
        }
        public bool TypeApprover
        {
            get { return typeApprover; }
        }

        public void toXML(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("role");
            xmlOut.WriteAttributeString("ID", this.RoleID.ToString());
            xmlOut.WriteAttributeString("code", this.RoleCode);
            xmlOut.WriteAttributeString("description", this.RoleDescription);
            xmlOut.WriteAttributeString("region", this.ForRegion);
            xmlOut.WriteAttributeString("priority", this.RolePriority.ToString());

            xmlOut.WriteEndElement();
        }

    }

    public class UserRoles
    {
        protected List<UserRole> roleSet;
        
        public UserRoles()
        {
            roleSet = new List<UserRole>();
            roleSet.Add(new UserRole());
        }
        public UserRoles(String username, int sessionKey, string targetUsername)
        {
            roleSet = new List<UserRole>();

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetRolesByAuthUser";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);
            userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionKey;
            userCommand.Parameters["@targetUser"].Value = targetUsername;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            while (userDataReader.Read())
            {
                roleSet.Add(new UserRole((int)userDataReader["roleID"], (string)userDataReader["userRole"], (string)userDataReader["forRegion"].ToString(), (string)userDataReader["roleDescription"].ToString(), (int)userDataReader["rolePriority"], (int)userDataReader["typeCode"], (bool)userDataReader["typeAdmin"], (bool)userDataReader["typeWriter"], (bool)userDataReader["typeReader"], (bool)userDataReader["typeApprover"]));
            }
            userConnection.Dispose();
        }
        public UserRoles(String username)
        {
            roleSet = new List<UserRole>();

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetRolesByUser";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);         

            userCommand.Parameters["@user"].Value = username;
            
            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            while (userDataReader.Read())
            {
                roleSet.Add(new UserRole((int)userDataReader["roleID"], (string)userDataReader["userRole"], (string)userDataReader["forRegion"].ToString(), (string)userDataReader["roleDescription"].ToString(), (int)userDataReader["rolePriority"], (int)userDataReader["typeCode"], (bool)userDataReader["typeAdmin"], (bool)userDataReader["typeWriter"], (bool)userDataReader["typeReader"], (bool)userDataReader["typeApprover"]));
            }
            userConnection.Dispose();
        }
        public void AddRole(String username, int sessionKey, string targetUsername, string roleCode, string forRegion)
        {
            UserRole tempRole = new UserRole(roleCode, forRegion);
            tempRole.SaveRoleToDB(username, sessionKey, targetUsername);
            roleSet.Add(tempRole);
        }
        public void RemoveRole(String username, int sessionKey, string targetUsername, int roleID)
        {
            UserRole tempRole;
            tempRole = roleSet.Find(delegate(UserRole role) { return role.RoleID == roleID; });
            if (tempRole != null)
            {
                tempRole.RemoveRoleFromDB(username, sessionKey);
                roleSet.Remove(tempRole);
            }
        }
        public void RemoveRole(String username, int sessionKey, string targetUsername, string roleCode, string forRegion)
        {
            UserRole tempRole;
            tempRole = roleSet.Find(delegate(UserRole role) { return role.RoleCode == roleCode && role.ForRegion == forRegion; });
            if (tempRole != null)
            {
                tempRole.RemoveRoleFromDB(username, sessionKey);
                roleSet.Remove(tempRole);
            }
        }
        public List<UserRole> RoleSet
        {
            get { return roleSet; }
        }

/*
        public UserRoles(Boolean genUser, Boolean natAdmin, Boolean regAdmin, Boolean resCompManager, Boolean resManager, Boolean projPI, Boolean projProposer, Boolean calSubmitter, Boolean resAuthor, Boolean admin, Boolean natStaff)
        {
            roleSet = new Boolean[] { genUser, natAdmin, regAdmin, resCompManager, resManager, projPI, projProposer, calSubmitter, resAuthor, admin, natStaff };
        }

        public void SetRoles(Boolean genUser, Boolean natAdmin, Boolean regAdmin, Boolean resCompManager, Boolean resManager, Boolean projPI, Boolean projProposer, Boolean calSubmitter, Boolean resAuthor, Boolean admin, Boolean natStaff)
        {
            roleSet[0] = genUser;
            roleSet[1] = natAdmin;
            roleSet[2] = regAdmin;
            roleSet[3] = resCompManager;
            roleSet[4] = resManager;
            roleSet[5] = projPI;
            roleSet[6] = projProposer;
            roleSet[7] = calSubmitter;
            roleSet[8] = resAuthor;
            roleSet[9] = admin;
            roleSet[10] = natStaff;
        }

        public string roleToString(int role)
        {
            return roleList[role];
        }
        public string roleToCode(int role)
        {
            return roleCodes[role];
        }
*/
        public void saveRolesToDB(string username, int sessionKey, string targetUser)
        {
            foreach (UserRole tempRole in roleSet)
            {
                tempRole.SaveRoleToDB(username, sessionKey, targetUser);
            }
        }
/*
        public void saveRolesToDB(string username, int sessionKey, string targetUser)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);
            userConnection.Open();

            List<string> roleList;

            userSQL = "DaikonReportingReturnStaticValues";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userDataReader = userCommand.ExecuteReader();
            userDataReader.NextResult();
            userDataReader.NextResult();
            userDataReader.NextResult();
            userDataReader.NextResult();
            userDataReader.NextResult();
            while (userDataReader.Read())
            {
                roleList.Add((string)userDataReader["userRole"]);
            }
            userDataReader.Close();

            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleSet.Find(roleList[i], IsRole) != null)
                {
                    userSQL = "DaikonUserAddRole";
                    userCommand = new SqlCommand(userSQL, userConnection);
                    userCommand.CommandType = CommandType.StoredProcedure;
                    userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@role", SqlDbType.VarChar, 12);

                    userCommand.Parameters["@user"].Value = username;
                    userCommand.Parameters["@sKey"].Value = sessionKey;
                    userCommand.Parameters["@targetUser"].Value = targetUser;
                    userCommand.Parameters["@role"].Value = this.roleToCode(i);

                    userCommand.ExecuteScalar();
                }
                else
                {
                    userSQL = "DaikonUserRemoveRole";
                    userCommand = new SqlCommand(userSQL, userConnection);
                    userCommand.CommandType = CommandType.StoredProcedure;
                    userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@targetUser", SqlDbType.VarChar, 12);
                    userCommand.Parameters.Add("@role", SqlDbType.VarChar, 12);

                    userCommand.Parameters["@user"].Value = username;
                    userCommand.Parameters["@sKey"].Value = sessionKey;
                    userCommand.Parameters["@targetUser"].Value = targetUser;
                    userCommand.Parameters["@role"].Value = this.roleToCode(i);

                    userCommand.ExecuteScalar();
                }
            }
            userConnection.Dispose();
        }
*/
/*
        public string listRoles()
        {
            string roleList = "";
            for (int i = 0; i < roleSet.GetLength(0); i++)
            {
                if (roleSet[i] == true)
                {
                    roleList = roleList + this.roleToString(i) + ",";
                }
            }
            return roleList;
        }
 * */

        public void toXML(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("userroles");

            foreach (UserRole tempRole in roleSet)
            {
                tempRole.toXML(xmlOut);
            }

            xmlOut.WriteEndElement();
        }
/*
        public String[] getRoleCodes()
        {
            string roleList = "";
            for (int i = 0; i < roleSet.GetLength(0); i++)
            {
                if (roleSet[i] == true)
                {
                    roleList = roleList + this.roleToCode(i) + ",";
                }
            }

            String[] roleCodes = roleList.Split(",".ToCharArray());
            return roleCodes;
        }
*/
        public bool HasRole(string roleCode)
        {
            return (roleSet.Find(delegate(UserRole role) { return role.RoleCode == roleCode; }) != null);
        }
        public bool HasRole(string roleCode, string region)
        {
            return (roleSet.Find(delegate(UserRole role) { return ((role.RoleCode == roleCode) && (role.ForRegion == region)); }) != null);
        }
        public UserRole GetRole(string roleCode)
        {
            return (roleSet.Find(delegate(UserRole role) { return role.RoleCode == roleCode; }));
        }
        public UserRole GetRole(string roleCode, string region)
        {
            return (roleSet.Find(delegate(UserRole role) { return ((role.RoleCode == roleCode) && (role.ForRegion == region)); }));
        }
        public bool IsAdmin()
        {
            return (roleSet.Find(delegate(UserRole role) { return role.TypeAdmin == true; }) != null);
        }
/*
        public Boolean isGenUser()
        {
            return roleSet[0];
        }
        public Boolean isRoleAdmin()
        {
            return (isAdmin() || isNatAdmin() || isRegAdmin());
        }
        public Boolean isNatAdmin()
        {
            return roleSet[1];
        }
        public Boolean isRegAdmin()
        {
            return roleSet[2];
        }
        public Boolean isResCompManager()
        {
            return roleSet[3];
        }
        public Boolean isResManager()
        {
            return roleSet[4];
        }
        public Boolean isProjPI()
        {
            return roleSet[5];
        }
        public Boolean isProjProposer()
        {
            return roleSet[6];
        }
        public Boolean isCalSubmitter()
        {
            return roleSet[7];
        }
        public Boolean isResAuthor()
        {
            return roleSet[8];
        }
        public Boolean isAdmin()
        {
            return roleSet[9];
        }
        public Boolean isNatStaff()
        {
            return roleSet[10];
        }
*/
    }

}
