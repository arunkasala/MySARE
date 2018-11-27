using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
//using System.Collections.Generic;
//using System.Text;

namespace daikon
{
    public class DaikonFile : IComparable
    {
        protected int fileID;
        protected string name;
        protected string nameOriginal;
        protected string caption;
        protected string mimetype;
        protected int order;
        protected int category;
        protected string categoryName;
        protected int displayMode;

        public int CompareTo(object obj)
        {
            if (obj is DaikonFile)
            {
                DaikonFile tempFile = (DaikonFile)obj;
                
                return order.CompareTo(tempFile.order);
            }

            throw new ArgumentException("object is not a DaikonFile");
        }

        public DaikonFile()
        {
            fileID = 0;
            name = "";
            nameOriginal = "";
            caption = "";
            mimetype = "";
            order = 0;
            category = 0;
            categoryName = "";
            displayMode = 0;
        }
        public DaikonFile(int fileID)
        {
            string fileSQL;
            string fileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection fileConnection;
            SqlCommand fileCommand;
            SqlDataReader fileDataReader;

            fileConnection = new SqlConnection(fileConnString);

            fileSQL = "DaikonFilesGetFilePublic";
            fileCommand = new SqlCommand(fileSQL, fileConnection);
            fileCommand.CommandType = CommandType.StoredProcedure;
            fileCommand.Parameters.Add("@fileID", SqlDbType.Int);

            fileCommand.Parameters["@fileID"].Value = fileID;

            fileConnection.Open();
            fileDataReader = fileCommand.ExecuteReader();
            if (fileDataReader.HasRows)
            {
                fileDataReader.Read();

                this.fileID = fileID;
                name = fileDataReader["file_name"].ToString();
                nameOriginal = fileDataReader["file_name_orig"].ToString();
                caption = fileDataReader["file_caption"].ToString();
                mimetype = fileDataReader["file_mimetype"].ToString();
                if (fileDataReader["file_order"].ToString() == "")
                    order = 0;
                else
                    order = Convert.ToInt32(fileDataReader["file_order"]);
                category = Convert.ToInt32(fileDataReader["file_cat"]);
                categoryName = fileDataReader["file_cat_name"].ToString();
                displayMode = Convert.ToInt32(fileDataReader["display_mode"]);
            }
            else
            {
            }
            fileConnection.Dispose();

        }
        public DaikonFile(string username, int sessionkey, int fileID)
        {

        }

        public int FileID
        {
            get
            {
                return fileID;
            }
            set
            {
                fileID = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string NameOriginal
        {
            get
            {
                return nameOriginal;
            }
            set
            {
                nameOriginal = value;
            }
        }
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }
        public string Mimetype
        {
            get
            {
                return mimetype;
            }
            set
            {
                mimetype = value;
            }
        }
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }
        public int Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public void toXml(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("file");
            xmlOut.WriteAttributeString("fileID", fileID.ToString());
            xmlOut.WriteAttributeString("mimetype", mimetype.ToString());
            xmlOut.WriteAttributeString("order", order.ToString());
            xmlOut.WriteAttributeString("category", category.ToString());
            xmlOut.WriteAttributeString("categoryname", categoryName.ToString());
            xmlOut.WriteAttributeString("displaymode", displayMode.ToString());
            xmlOut.WriteStartElement("name");
            xmlOut.WriteAttributeString("original", nameOriginal.ToString());
            xmlOut.WriteString(name.ToString());
            xmlOut.WriteEndElement();
            xmlOut.WriteElementString("caption", caption.ToString());
            xmlOut.WriteEndElement();
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

    }

    public class DaikonReportImage : DaikonFile
    {
        protected int groupedOrder;

        public DaikonReportImage()
            : base()
        {
            groupedOrder = 0;
        }

        public DaikonReportImage(int fileID) : base(fileID)
        {
            groupedOrder = 0;
        }
        public DaikonReportImage(int fileID, int groupedOrder)
            : base(fileID)
        {
            this.groupedOrder = groupedOrder;
        }

        public bool saveNewReportImageToDB(string username, int sessionkey, int subsectionUID)
        {
            
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
            
            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonReportingImageInsert";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_name", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_name_orig", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_caption", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_mimetype", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_order", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_cat", SqlDbType.TinyInt);
            daikonCommand.Parameters.Add(keyOutput);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@in_subsection_uid"].Value = subsectionUID;
            daikonCommand.Parameters["@in_file_name"].Value = dbNullify(name);
            daikonCommand.Parameters["@in_file_name_orig"].Value = dbNullify(nameOriginal);
            daikonCommand.Parameters["@in_file_caption"].Value = dbNullify(caption);
            daikonCommand.Parameters["@in_file_mimetype"].Value = dbNullify(mimetype);
            daikonCommand.Parameters["@in_file_order"].Value = order;
            daikonCommand.Parameters["@in_file_cat"].Value = category;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();
            fileID = (int)keyOutput.Value;

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            if (fileID > 0)
                return true;
            else
                return false;
        }

        public bool saveNewInfoProductImageToDB(string username, int sessionkey, int subsectionUID)
        {
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
            
            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonInfoProductImageInsert";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_name", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_name_orig", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_caption", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_mimetype", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_order", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_cat", SqlDbType.TinyInt);
            daikonCommand.Parameters.Add(keyOutput);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@in_subsection_uid"].Value = subsectionUID;
            daikonCommand.Parameters["@in_file_name"].Value = dbNullify(name);
            daikonCommand.Parameters["@in_file_name_orig"].Value = dbNullify(nameOriginal);
            daikonCommand.Parameters["@in_file_caption"].Value = dbNullify(caption);
            daikonCommand.Parameters["@in_file_mimetype"].Value = dbNullify(mimetype);
            daikonCommand.Parameters["@in_file_order"].Value = order;
            daikonCommand.Parameters["@in_file_cat"].Value = category;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();
            fileID = (int)keyOutput.Value;

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            if (fileID > 0)
                return true;
            else
                return false;
        }

        public bool savePDPAttachmentToDB(string username, int sessionkey, string projNum)
        {
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;

            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonPDPAttachmentInsert";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);
            daikonCommand.Parameters.Add("@in_file_name", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_name_orig", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_caption", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_mimetype", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_order", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_cat", SqlDbType.TinyInt);
            daikonCommand.Parameters.Add(keyOutput);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@proj_num"].Value = projNum;
            daikonCommand.Parameters["@in_file_name"].Value = dbNullify(name);
            daikonCommand.Parameters["@in_file_name_orig"].Value = dbNullify(nameOriginal);
            daikonCommand.Parameters["@in_file_caption"].Value = dbNullify(caption);
            daikonCommand.Parameters["@in_file_mimetype"].Value = dbNullify(mimetype);
            daikonCommand.Parameters["@in_file_order"].Value = order;
            daikonCommand.Parameters["@in_file_cat"].Value = category;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();
            fileID = (int)keyOutput.Value;

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            if (fileID > 0)
                return true;
            else
                return false;
        }

        public bool deleteInfoProductImageFromDB(string username, int sessionkey, int resourceID, int fileID)
        {
            
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
            

            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonInfoProductImageDelete";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@fileID", SqlDbType.Int);
            daikonCommand.Parameters.Add("@resourceID", SqlDbType.Int);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@resourceID"].Value = resourceID;
            daikonCommand.Parameters["@fileID"].Value = fileID;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            return true;
        }

        public bool deletePDPAttachmentFromDB(string username, int sessionkey, string projNum, int fileID)
        {
            
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
          

            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonPDPAttachmentDelete";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@fileID", SqlDbType.Int);
            daikonCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@fileID"].Value = fileID;
            daikonCommand.Parameters["@proj_num"].Value = projNum;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            return true;
        }


        public bool saveReportImageToDB(string username, int sessionkey, int subsectionUID)
        {
            
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
         
            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonReportingImageUpdate";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_fileID", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_name", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_name_orig", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_caption", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_mimetype", SqlDbType.VarChar);
            daikonCommand.Parameters.Add("@in_file_order", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_cat", SqlDbType.TinyInt);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@in_fileID"].Value = fileID;
            daikonCommand.Parameters["@in_subsection_uid"].Value = subsectionUID;
            daikonCommand.Parameters["@in_file_name"].Value = dbNullify(name);
            daikonCommand.Parameters["@in_file_name_orig"].Value = dbNullify(nameOriginal);
            daikonCommand.Parameters["@in_file_caption"].Value = dbNullify(caption);
            daikonCommand.Parameters["@in_file_mimetype"].Value = dbNullify(mimetype);
            daikonCommand.Parameters["@in_file_order"].Value = order;
            daikonCommand.Parameters["@in_file_cat"].Value = category;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            return true;
        }

        public bool reorderReportImageInDB(string username, int sessionkey, int subsectionUID, int newOrder)
        {
            this.order = newOrder;
          
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
           

            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonReportingImageMove";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_fileID", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int);
            daikonCommand.Parameters.Add("@in_file_order", SqlDbType.Int);

            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@in_fileID"].Value = fileID;
            daikonCommand.Parameters["@in_subsection_uid"].Value = subsectionUID;
            daikonCommand.Parameters["@in_file_order"].Value = order;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            return true;
        }

        public bool deleteReportImageFromDB(string username, int sessionkey)
        {
            
            string daikonWriteSQL;
            string daikonConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection daikonConnection;
            SqlCommand daikonCommand;
           

            daikonConnection = new SqlConnection(daikonConnString);

            daikonWriteSQL = "DaikonReportingImageDelete";

            daikonCommand = new SqlCommand(daikonWriteSQL, daikonConnection);
            daikonCommand.CommandType = CommandType.StoredProcedure;

            daikonCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
            daikonCommand.Parameters.Add("@sKey", SqlDbType.Int);
            daikonCommand.Parameters.Add("@fileID", SqlDbType.Int);
            
            daikonCommand.Parameters["@user"].Value = dbNullify(username);
            daikonCommand.Parameters["@sKey"].Value = sessionkey;
            daikonCommand.Parameters["@fileID"].Value = fileID;

            daikonConnection.Open();
            daikonCommand.ExecuteScalar();

            daikonConnection.Close();
            daikonCommand.Dispose();
            daikonConnection.Dispose();

            return true;
        }

        
        
        new public void toXml(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("file");
            xmlOut.WriteAttributeString("fileID", fileID.ToString());
            xmlOut.WriteAttributeString("mimetype", mimetype.ToString());
            xmlOut.WriteAttributeString("order", order.ToString());
            xmlOut.WriteAttributeString("groupedorder", groupedOrder.ToString());
            xmlOut.WriteAttributeString("category", category.ToString());
            xmlOut.WriteAttributeString("categoryname", categoryName.ToString());
            xmlOut.WriteAttributeString("displaymode", displayMode.ToString());
            xmlOut.WriteStartElement("name");
            xmlOut.WriteAttributeString("original", nameOriginal.ToString());
            string strName = name.ToString();
            strName = strName.Replace("'", "\\'");
            xmlOut.WriteString(strName);
            xmlOut.WriteEndElement();
            xmlOut.WriteElementString("caption", caption.ToString());
            xmlOut.WriteEndElement();
        }

    }

    public class DaikonReportImageCollection : System.Collections.Generic.SortedDictionary<int, DaikonReportImage>
    {
        protected int subsectionUID;

        public DaikonReportImageCollection()
        {
            subsectionUID = 0;
        }

        public DaikonReportImageCollection(int subsectionUID)
        {
            string fileSQL;
            string fileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection fileConnection;
            SqlCommand fileCommand;
            SqlDataReader fileDataReader;

            this.subsectionUID = subsectionUID;

            fileConnection = new SqlConnection(fileConnString);

            fileSQL = "DaikonReportingGetImagesBySubsection";
            fileCommand = new SqlCommand(fileSQL, fileConnection);
            fileCommand.CommandType = CommandType.StoredProcedure;
            fileCommand.Parameters.Add("@subsection_uid", SqlDbType.Int);

            fileCommand.Parameters["@subsection_uid"].Value = subsectionUID;

            fileConnection.Open();
            fileDataReader = fileCommand.ExecuteReader();

            DaikonReportImage tempFile;
            int fileID;
            int suborder;

            while (fileDataReader.Read())
            {
                fileID = Convert.ToInt32(fileDataReader["fileID"]);
                if (fileDataReader["file_order"].ToString()== "")
                    suborder = 0;
                else
                    suborder = Convert.ToInt32(fileDataReader["file_order"]);
                tempFile = new DaikonReportImage(fileID, suborder);
                if (this.ContainsKey(fileID) == false)
                    Add(fileID, tempFile);
            }
            fileConnection.Dispose();
        }

        public void Refresh()
        {
            this.Clear();

            string fileSQL;
            string fileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection fileConnection;
            SqlCommand fileCommand;
            SqlDataReader fileDataReader;

            fileConnection = new SqlConnection(fileConnString);

            fileSQL = "DaikonReportingGetImagesBySubsection";
            fileCommand = new SqlCommand(fileSQL, fileConnection);
            fileCommand.CommandType = CommandType.StoredProcedure;
            fileCommand.Parameters.Add("@subsection_uid", SqlDbType.Int);

            fileCommand.Parameters["@subsection_uid"].Value = subsectionUID;

            fileConnection.Open();
            fileDataReader = fileCommand.ExecuteReader();

            DaikonReportImage tempFile;
            int fileID;
            int suborder;

            while (fileDataReader.Read())
            {
                fileID = Convert.ToInt32(fileDataReader["fileID"]);
                suborder = Convert.ToInt32(fileDataReader["suborder"]);
                tempFile = new DaikonReportImage(fileID, suborder);
                if (this.ContainsKey(fileID) == false)
                    Add(fileID, tempFile);
            }
            fileConnection.Dispose();            
        }

        public int SubsectionUID
        {
            get
            {
                return subsectionUID;
            }
        }

        public void toXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("fileset");
            writer.WriteAttributeString("size", this.Count.ToString());
            foreach (DaikonReportImage tempImage in this.Values)
            {
                tempImage.toXml(writer);
            }
            writer.WriteEndElement();
        }

    }

}
