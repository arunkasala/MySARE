using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

namespace daikon
{
	public class PackagedUserMessage
	{
		protected UserMessage message;

		public UserMessage Message
		{
			get { return message; }
			set { message = value; }
		}
		protected DaikonUserCollection recipients;

		public DaikonUserCollection Recipients
		{
			get { return recipients; }
			set { recipients = value; }
		}
		protected DaikonUserCollection bccRecipients;

		public DaikonUserCollection BccRecipients
		{
			get { return bccRecipients; }
			set { bccRecipients = value; }
		}

        public PackagedUserMessage()
        {
			message = new UserMessage();
			recipients = new DaikonUserCollection();
			bccRecipients = new DaikonUserCollection();
		}
		public PackagedUserMessage(UserMessage message, DaikonUserCollection recipients, DaikonUserCollection bccRecipients)
		{
			this.message = message;
			this.recipients = recipients;
			this.bccRecipients = bccRecipients;
		}

		public void toXML(XmlTextWriter xmlOut)
		{
			xmlOut.WriteStartElement("packagedmessage");

			message.toXML(xmlOut);
			recipients.toXML(xmlOut, "cclist");
			bccRecipients.toXML(xmlOut, "bcclist");

			xmlOut.WriteEndElement();

		}

	}
    public class UserMessage
    {
		protected int msgID;
		protected string rolegroup;
		protected bool isprivate;
		protected string title;
		protected string subject;
		protected string message;

        public UserMessage()
        {
			msgID = 0;
            rolegroup = "genUser";
			isprivate = true;
			title = "";
			subject = "";
			message = "";
		}
		public UserMessage(string rolegroup, bool isprivate, string title, string subject, string message)
        {
			this.rolegroup = rolegroup;
			this.isprivate = isprivate;
			this.title = title;
			this.subject = subject;
			this.message = message;
		}
		public UserMessage(int msgID, string rolegroup, bool isprivate, string title, string subject, string message)
		{
			this.msgID = msgID;
			this.rolegroup = rolegroup;
			this.isprivate = isprivate;
			this.title = title;
			this.subject = subject;
			this.message = message;
		}
 		public int MsgID
		{
			get { return msgID; }
		}
        public string RoleGroup
        {
            get { return rolegroup; }
            set { rolegroup = value; }
        }
        public bool IsPrivate
        {
            get { return isprivate; }
			set { isprivate = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}
		public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public void SaveToDB(string username, int sessionkey)
        {
            int newMsgID;
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;

            userConnection = new SqlConnection(userConnString);
            userConnection.Open();

            if (this.msgID == 0)
            {
				SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
				keyOutput.Direction = ParameterDirection.Output;

				userSQL = "DaikonUserMessageInsert";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;
                userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
                userCommand.Parameters.Add("@sKey", SqlDbType.Int);
				userCommand.Parameters.Add("@rolegroup", SqlDbType.VarChar, 50);
                userCommand.Parameters.Add("@private", SqlDbType.Bit);
                userCommand.Parameters.Add("@title", SqlDbType.VarChar, 255);
				userCommand.Parameters.Add("@subject", SqlDbType.VarChar, 255);
				userCommand.Parameters.Add("@message", SqlDbType.NText);
				userCommand.Parameters.Add(keyOutput);

                userCommand.Parameters["@user"].Value = username;
                userCommand.Parameters["@sKey"].Value = sessionkey;
				userCommand.Parameters["@rolegroup"].Value = this.rolegroup;
				userCommand.Parameters["@private"].Value = this.isprivate;
				userCommand.Parameters["@title"].Value = this.title;
				userCommand.Parameters["@subject"].Value = this.subject;
				userCommand.Parameters["@message"].Value = this.message;

				userCommand.ExecuteScalar();
				newMsgID = (int)keyOutput.Value;

				if (newMsgID > 0)
                {
					this.msgID = newMsgID;
                }
            }
			else
			{
				userSQL = "DaikonUserMessageUpdate";
				userCommand = new SqlCommand(userSQL, userConnection);
				userCommand.CommandType = CommandType.StoredProcedure;
				userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
				userCommand.Parameters.Add("@sKey", SqlDbType.Int);
				userCommand.Parameters.Add("@msgID", SqlDbType.Int);
				userCommand.Parameters.Add("@rolegroup", SqlDbType.VarChar, 50);
				userCommand.Parameters.Add("@private", SqlDbType.Bit);
				userCommand.Parameters.Add("@title", SqlDbType.VarChar, 255);
				userCommand.Parameters.Add("@subject", SqlDbType.VarChar, 255);
				userCommand.Parameters.Add("@message", SqlDbType.NText);

				userCommand.Parameters["@user"].Value = username;
				userCommand.Parameters["@sKey"].Value = sessionkey;
				userCommand.Parameters["@msgID"].Value = this.msgID;
				userCommand.Parameters["@rolegroup"].Value = this.rolegroup;
				userCommand.Parameters["@private"].Value = this.isprivate;
				userCommand.Parameters["@title"].Value = this.title;
				userCommand.Parameters["@subject"].Value = this.subject;
				userCommand.Parameters["@message"].Value = this.message;

				userCommand.ExecuteScalar();
			}
			userConnection.Dispose();
        }
        public void RemoveFromDB(string username, int sessionkey)
        {
            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
//            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);
            userConnection.Open();

            userSQL = "DaikonUserMessageDelete";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@msgID", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionkey;
            userCommand.Parameters["@msgID"].Value = this.msgID;

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

        public void toXML(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("message");
            xmlOut.WriteAttributeString("ID", this.msgID.ToString());
            xmlOut.WriteAttributeString("rolegroup", this.rolegroup);
            xmlOut.WriteAttributeString("isprivate", this.isprivate.ToString());
            xmlOut.WriteElementString("title", this.title.ToString());
			xmlOut.WriteElementString("subject", this.subject.ToString());
			xmlOut.WriteElementString("message", this.message.ToString());
            xmlOut.WriteEndElement();
        }
    }

    public class UserMessages
    {
        protected List<UserMessage> messageSet;
        
        public UserMessages()
        {
			messageSet = new List<UserMessage>();
//			messageSet.Add(new UserMessage());
        }
		public UserMessages(String username, int sessionKey)
        {
			messageSet = new List<UserMessage>();

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;
            userConnection = new SqlConnection(userConnString);

            userSQL = "DaikonUserGetMessageListByUser";
            userCommand = new SqlCommand(userSQL, userConnection);
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            userCommand.Parameters.Add("@sKey", SqlDbType.Int);

            userCommand.Parameters["@user"].Value = username;
            userCommand.Parameters["@sKey"].Value = sessionKey;

            userConnection.Open();
            userDataReader = userCommand.ExecuteReader();
            while (userDataReader.Read())
            {
				messageSet.Add(new UserMessage((int)userDataReader["messagekey"], (string)userDataReader["rolegroup"].ToString(), (bool)(userDataReader["private"]), (string)userDataReader["title"].ToString(), (string)userDataReader["subject"].ToString(), (string)userDataReader["message"].ToString()));
            }
            userConnection.Dispose();
        }

		public List<UserMessage> MessageSet
        {
            get { return messageSet; }
        }

		public void saveToDB(string username, int sessionKey, string targetUser)
        {
			foreach (UserMessage tempMessage in messageSet)
            {
                tempMessage.SaveToDB(username, sessionKey);
            }
        }

        public void toXML(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("usermessages");

			foreach (UserMessage tempMessage in messageSet)
            {
                tempMessage.toXML(xmlOut);
            }

            xmlOut.WriteEndElement();
        }

		public bool HasMessage(int msgID)
        {
            return (messageSet.Find(delegate(UserMessage userMessage) { return userMessage.MsgID == msgID; }) != null);
        }
		public UserMessage GetMessage(int msgID)
        {
			return (messageSet.Find(delegate(UserMessage userMessage) { return userMessage.MsgID == msgID; }));
        }

	}
}
