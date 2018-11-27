using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace daikonProdInfo
{
    public class ProductInfo
    {
        protected int resource_id;
        protected string res_projNum;
        protected string title;
        protected string desc;

        protected bool book;
        protected bool video;
        protected bool extpub;
        protected bool handbook;
        protected bool factsheet;
        protected bool software;
        protected bool workbook;
        protected bool manual;
        protected bool website;
        protected bool cdrom;
        protected bool newsletter;
        protected bool journal;
        protected bool other;
        protected string othertxt;

        protected bool beg;
        protected bool inter;
        protected bool adv;

        protected bool farmers;
        protected bool edu;
        protected bool res;
        protected bool consumers;

        protected string authoreditor;
        protected string authoreditorLast;
        protected string author2;
        protected string author2Last;
        protected string author3;
        protected string author3Last;
        protected string author4;
        protected string author4Last;
        protected string author5;
        protected string author5Last;
        protected string website_url;
        protected string website_pdf;


        protected string orderfirst;
        protected string orderlast;
        protected string orderorg;
        protected string orderaddress;
        protected string ordercity;
        protected string orderstate;
        protected string orderzip;
        protected string orderphone;
        protected string orderfax;
        protected string orderemail;
        protected string orderwebsite;
        protected string orderproductID;
        protected string orderreleasedate;
        protected bool avalqty;
        protected decimal ordercost;
        protected decimal ordershipping;
        protected string ordercomments;
        protected string proddescription;
        protected int uploadID;
        protected bool submitted;
        protected bool approved;
        

        public ProductInfo()
        {
            res_projNum = "";
            title = "";
            desc = "";

            book = false;
            video = false;
            extpub = false;
            handbook = false;
            factsheet = false;
            software = false;
            workbook = false;
            manual = false;
            website = false;
            cdrom = false;
            newsletter = false;
            journal = false;
            other = false;
            othertxt = "";

            beg = false;
            inter = false;
            adv = false;

            farmers = false;
            edu = false;
            res = false;
            consumers = false;

            authoreditor = "";
            authoreditorLast = "";
            author2 = "";
            author2Last = "";
            author3 = "";
            author3Last = "";
            author4 = "";
            author4Last = "";
            author5 = "";
            author5Last = "";
            website_url = "";
            website_pdf = "";


            orderfirst = "";
            orderlast = "";
            orderorg = "";
            orderaddress = "";
            ordercity = "";
            orderstate = "";
            orderzip = "";
            orderphone = "";
            orderfax = "";
            orderemail = "";
            orderwebsite = "";
            orderproductID = "";
            orderreleasedate = "";
            avalqty = false;
            ordercost = 0;
            ordershipping = 0;
            ordercomments = "";
            proddescription = "";
            submitted = false;
            approved = false;

        }
       
        public ProductInfo(string res_projnum)
		{
			string productInfoSQL;
            string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection productInfoConnection;
            SqlCommand productInfoCommand;
            SqlDataReader productInfoDataReader;

            prodInfoList = new SortedList();

            productInfoConnection = new SqlConnection(productInfoConnString);

            productInfoSQL = "DaikonProjectProductInfoListByResProjNum";
            productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
            productInfoCommand.CommandType = CommandType.StoredProcedure;
            productInfoCommand.Parameters.Add("@res_projnum", SqlDbType.VarChar, 12);

            productInfoCommand.Parameters["@res_projnum"].Value = res_projnum;

            productInfoConnection.Open();
            productInfoDataReader = productInfoCommand.ExecuteReader();

            
            while (productInfoDataReader.Read())
			{
                AddProdInfo(productInfoDataReader["Resource_ID"].ToString(), productInfoDataReader["Title"].ToString());
			}
            productInfoConnection.Dispose();
		}

        protected SortedList prodInfoList;
        public SortedList ProdInfoList
        {
            get { return prodInfoList; }
        }

        public void AddProdInfo(string resID, string ProjNum)
        {
           prodInfoList.Add(resID, ProjNum);
        }

        public int ResourceID
        {
            get { return resource_id; }
            set { resource_id = value; }
        }

        public string ResourceProjNum
        {
            get { return res_projNum; }
            set { res_projNum = value; }
        }
        public string Title
        {
            get { return title;}
            set { title = value;}
        }
        public string Description
        {
            get { return desc;}
            set { desc = value;}
        }
        public string AuthorEditor
        {
            get { return authoreditor;}
            set { authoreditor = value;}
        }
        public string AuthorEditorLast
        {
            get { return authoreditorLast;}
            set { authoreditorLast = value;}
        }
        public string Author2
        {
            get { return author2;}
            set { author2 = value;}
        }
        public string Author2Last
        {
            get { return author2Last;}
            set { author2Last = value;}
        }
        public string Author3
        {
            get { return author3;}
            set { author3 = value;}
        }
        public string Author3Last
        {
            get { return author3Last;}
            set { author3Last = value;}
        }
        public string Author4
        {
            get { return author4;}
            set { author4 = value;}
        }
        public string Author4Last
        {
            get { return author4Last;}
            set { author4Last = value;}
        }
        public string Author5
        {
            get { return author5;}
            set { author5 = value;}
        }
        public string Author5Last
        {
            get { return author5Last;}
            set { author5Last = value;}
        }
        public string WebsiteURL
        {
            get { return website_url;}
            set { website_url = value;}
        }
        public string WebsitePDF
        {
            get { return website_pdf;}
            set { website_pdf = value; }
        }
        public string OrderFirst
        {
            get { return orderfirst; }
            set { orderfirst = value; }
        }
        public string OrderLast
        {
            get { return orderlast; }
            set { orderlast = value; }
        }
        public string OrderOrg
        {
            get { return orderorg; }
            set { orderorg = value; }
        }
        public string OrderAddress
        {
            get { return orderaddress; }
            set { orderaddress = value; }
        }
        public string OrderCity
        {
            get { return ordercity; }
            set { ordercity = value; }
        }
        public string OrderState
        {
            get { return orderstate; }
            set { orderstate = value; }
        }
        public string OrderZip
        {
            get { return orderzip; }
            set { orderzip = value; }
        }
        public string OrderPhone
        {
            get { return orderphone; }
            set { orderphone = value; }
        }
        public string OrderFax
        {
            get { return orderfax; }
            set { orderfax = value; }
        }
        public string OrderEmail
        {
            get { return orderemail; }
            set { orderemail = value; }
        }
        public string OrderWebsite
        {
            get { return orderwebsite; }
            set { orderwebsite = value; }
        }
        public string OrderProductID
        {
            get { return orderproductID; }
            set { orderproductID = value; }
        }
        public string OrderReleasedate
        {
            get { return orderreleasedate; }
            set { orderreleasedate = value; }
        }
        public decimal OrderCost
        {
            get { return ordercost; }
            set { ordercost = value; }
        }
        public decimal OrderShipping
        {
            get { return ordershipping; }
            set { ordershipping = value; }
        }
        public string OrderComments
        {
            get { return ordercomments; }
            set { ordercomments = value; }
        }
        public string ProdDescription
        {
            get { return proddescription; }
            set { proddescription = value; }
        }
        public int UploadID
        {
            get { return uploadID; }
            set { uploadID = value; }
        }
        public bool Book
        {
            get { return book; }
            set { book = value; }
        }
        public bool Video
        {
            get { return video; }
            set { video = value; }
        }
        public bool ExtPub
        {
            get { return extpub; }
            set { extpub = value; }
        }
        public bool Handbook
        {
            get { return handbook; }
            set { handbook = value; }
        }
        public bool Factsheet
        {
            get { return factsheet; }
            set { factsheet = value; }
        }
        public bool Software
        {
            get { return software; }
            set { software = value; }
        }
        public bool Workbook
        {
            get { return workbook; }
            set { workbook = value; }
        }
        public bool Manual
        {
            get { return manual; }
            set { manual = value; }
        }
        public bool Website
        {
            get { return website; }
            set { website = value; }
        }
        public bool CDRom
        {
            get { return cdrom; }
            set { cdrom = value; }
        }
        public bool Newsletter
        {
            get { return newsletter; }
            set { newsletter = value; }
        }
        public bool Journal
        {
            get { return journal; }
            set { journal = value; }
        }
        public bool Other
        {
            get { return other; }
            set { other = value; }
        }
        public bool Beg
        {
            get { return beg; }
            set { beg = value; }
        }
        public bool Inter
        {
            get { return inter; }
            set { inter = value; }
        }
        public bool Adv
        {
            get { return adv; }
            set { adv = value; }
        }
        public bool Farmers
        {
            get { return farmers; }
            set { farmers = value; }
        }
        public bool Edu
        {
            get { return edu; }
            set { edu = value; }
        }
        public bool Res
        {
            get { return res; }
            set { res = value; }
        }
        public bool Consumers
        {
            get { return consumers; }
            set { consumers = value; }
        }
        public bool AvalQty
        {
            get { return avalqty; }
            set { avalqty = value; }
        }
        public bool Submitted
        {
            get { return submitted; }
            set { submitted = value; }
        }
        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }
        public string OtherTxt
        {
            get { return othertxt; }
            set { othertxt = value; }
        }

       
        public bool getProdInfoDetailsByUploadID(int upload_id)
        {
            string productInfoSQL;
            string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection productInfoConnection;
            SqlCommand productInfoCommand;
            SqlDataReader productInfoDataReader;

            prodInfoList = new SortedList();

            productInfoConnection = new SqlConnection(productInfoConnString);

            productInfoSQL = "DaikonProjectProductInfoByUploadID";
            productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
            productInfoCommand.CommandType = CommandType.StoredProcedure;
            productInfoCommand.Parameters.Add("@upload_id", SqlDbType.Int);

            productInfoCommand.Parameters["@upload_id"].Value = upload_id;
            
            productInfoConnection.Open();
            productInfoDataReader = productInfoCommand.ExecuteReader();

            if (productInfoDataReader.HasRows)
            {
                productInfoDataReader.Read();

                resource_id = upload_id;
                res_projNum = productInfoDataReader["Res_ProjectNumber"].ToString();
                title = productInfoDataReader["Title"].ToString();

                book = (bool)productInfoDataReader["Book"];
                handbook = (bool)productInfoDataReader["Handbook"];
                workbook = (bool)productInfoDataReader["Workbook"];
                cdrom = (bool)productInfoDataReader["CD_ROM"];
                video = (bool)productInfoDataReader["Video"];
                factsheet = (bool)productInfoDataReader["FactSheet"];
                manual = (bool)productInfoDataReader["Manual"];
                newsletter = (bool)productInfoDataReader["Newsletter"];
                extpub = (bool)productInfoDataReader["ExtensionPub"];
                software = (bool)productInfoDataReader["Software"];
                website = (bool)productInfoDataReader["Website"];
                journal = (bool)productInfoDataReader["Article"];
                other = (bool)productInfoDataReader["Other"];

                beg = (bool)productInfoDataReader["Beginner"];
                inter = (bool)productInfoDataReader["Intermediate"];
                adv = (bool)productInfoDataReader["Advanced"];

                farmers = (bool)productInfoDataReader["Farmers_Ranchers"];
                edu = (bool)productInfoDataReader["Educators"];
                res = (bool)productInfoDataReader["Researchers"];
                consumers = (bool)productInfoDataReader["Consumers"];
                avalqty = (bool)productInfoDataReader["Aval_Qty"];

                authoreditor = productInfoDataReader["AuthorEditor"].ToString();
                authoreditorLast = productInfoDataReader["AuthorEditorLast"].ToString();
                author2 = productInfoDataReader["Author2"].ToString();
                author2Last = productInfoDataReader["Author2Last"].ToString();
                author3 = productInfoDataReader["Author3"].ToString();
                author3Last = productInfoDataReader["Author3Last"].ToString();
                author4 = productInfoDataReader["Author4"].ToString();
                author4Last = productInfoDataReader["Author4Last"].ToString();
                author5 = productInfoDataReader["Author5"].ToString();
                author5Last = productInfoDataReader["Author5Last"].ToString();
                website_url = productInfoDataReader["Doc_URL"].ToString();
                website_pdf = productInfoDataReader["Doc_PDF"].ToString();
                orderfirst = productInfoDataReader["Order_Name"].ToString();
                orderlast = productInfoDataReader["Order_Name_Last"].ToString();
                orderorg = productInfoDataReader["Order_Org"].ToString();
                orderaddress = productInfoDataReader["Order_Address"].ToString();
                ordercity = productInfoDataReader["Order_City"].ToString();
                orderstate = productInfoDataReader["Order_State"].ToString();
                orderzip = productInfoDataReader["Order_Zip"].ToString();
                orderphone = productInfoDataReader["Order_Phone"].ToString();
                orderfax = productInfoDataReader["Order_Fax"].ToString();
                orderemail = productInfoDataReader["Order_Email"].ToString();
                orderwebsite = productInfoDataReader["Order_Web"].ToString();
                orderproductID = productInfoDataReader["PubID_ISBN"].ToString();
                orderreleasedate = productInfoDataReader["Release_Revision_Date"].ToString();
                ordercomments = productInfoDataReader["Comments"].ToString();
                proddescription = productInfoDataReader["Description"].ToString();
                if (productInfoDataReader["uploadID"] != null && productInfoDataReader["uploadID"].ToString() != "")
                    uploadID = int.Parse(productInfoDataReader["uploadID"].ToString());
                if (productInfoDataReader["submitted"] != null && productInfoDataReader["submitted"].ToString() != "")
                    submitted = (bool)productInfoDataReader["submitted"];
                if (productInfoDataReader["approved"] != null && productInfoDataReader["approved"].ToString() != "")
                    approved = (bool)productInfoDataReader["approved"];
                othertxt = productInfoDataReader["OtherText"].ToString();
                if (productInfoDataReader["Cost"].ToString() != "")
                    ordercost = decimal.Parse(productInfoDataReader["Cost"].ToString());
                if (productInfoDataReader["Shipping"].ToString() != "")
                    ordershipping = decimal.Parse(productInfoDataReader["Shipping"].ToString());
            }
            else
            {
            }
            productInfoConnection.Dispose();

            return true;
        }
        public bool getProdInfoDetails(int res_id)
        {

            string productInfoSQL;
            string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection productInfoConnection;
            SqlCommand productInfoCommand;
            SqlDataReader productInfoDataReader;

            prodInfoList = new SortedList();

            productInfoConnection = new SqlConnection(productInfoConnString);

            productInfoSQL = "DaikonProjectProductInfoByResID";
            productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
            productInfoCommand.CommandType = CommandType.StoredProcedure;
            productInfoCommand.Parameters.Add("@res_id", SqlDbType.Int);
            productInfoCommand.Parameters.Add("@upload_id", SqlDbType.Int);
            
            productInfoCommand.Parameters["@res_id"].Value = res_id;
            productInfoCommand.Parameters["@upload_id"].Value = GetUploadID(res_id);
            
            productInfoConnection.Open();
            productInfoDataReader = productInfoCommand.ExecuteReader();

            if (productInfoDataReader.HasRows)
            {
                productInfoDataReader.Read();

                resource_id = res_id;
                res_projNum = productInfoDataReader["Res_ProjectNumber"].ToString();
                title = productInfoDataReader["Title"].ToString();

                book = (bool)productInfoDataReader["Book"];
                handbook = (bool)productInfoDataReader["Handbook"];
                workbook = (bool)productInfoDataReader["Workbook"];
                cdrom = (bool)productInfoDataReader["CD_ROM"];
                video = (bool)productInfoDataReader["Video"];
                factsheet = (bool)productInfoDataReader["FactSheet"];
                manual = (bool)productInfoDataReader["Manual"];
                newsletter = (bool)productInfoDataReader["Newsletter"];
                extpub = (bool)productInfoDataReader["ExtensionPub"];
                software = (bool)productInfoDataReader["Software"];
                website = (bool)productInfoDataReader["Website"];
                journal = (bool)productInfoDataReader["Article"];
                other = (bool)productInfoDataReader["Other"];

                beg = (bool)productInfoDataReader["Beginner"];
                inter = (bool)productInfoDataReader["Intermediate"];
                adv = (bool)productInfoDataReader["Advanced"];

                farmers = (bool)productInfoDataReader["Farmers_Ranchers"];
                edu = (bool)productInfoDataReader["Educators"];
                res = (bool)productInfoDataReader["Researchers"];
                consumers = (bool)productInfoDataReader["Consumers"];
                avalqty = (bool)productInfoDataReader["Aval_Qty"];

                authoreditor = productInfoDataReader["AuthorEditor"].ToString();
                authoreditorLast = productInfoDataReader["AuthorEditorLast"].ToString();
                author2 = productInfoDataReader["Author2"].ToString();
                author2Last = productInfoDataReader["Author2Last"].ToString();
                author3 = productInfoDataReader["Author3"].ToString();
                author3Last = productInfoDataReader["Author3Last"].ToString();
                author4 = productInfoDataReader["Author4"].ToString();
                author4Last = productInfoDataReader["Author4Last"].ToString();
                author5 = productInfoDataReader["Author5"].ToString();
                author5Last = productInfoDataReader["Author5Last"].ToString();
                website_url = productInfoDataReader["Doc_URL"].ToString();
                website_pdf = productInfoDataReader["Doc_PDF"].ToString();
                orderfirst = productInfoDataReader["Order_Name"].ToString();
                orderlast = productInfoDataReader["Order_Name_Last"].ToString();
                orderorg = productInfoDataReader["Order_Org"].ToString();
                orderaddress = productInfoDataReader["Order_Address"].ToString();
                ordercity = productInfoDataReader["Order_City"].ToString();
                orderstate = productInfoDataReader["Order_State"].ToString();
                orderzip = productInfoDataReader["Order_Zip"].ToString();
                orderphone = productInfoDataReader["Order_Phone"].ToString();
                orderfax = productInfoDataReader["Order_Fax"].ToString();
                orderemail = productInfoDataReader["Order_Email"].ToString();
                orderwebsite = productInfoDataReader["Order_Web"].ToString();
                orderproductID = productInfoDataReader["PubID_ISBN"].ToString();
                orderreleasedate = productInfoDataReader["Release_Revision_Date"].ToString();
                ordercomments = productInfoDataReader["Comments"].ToString();
                if (productInfoDataReader["Description"] != null)
                    proddescription = productInfoDataReader["Description"].ToString();
                uploadID = int.Parse(productInfoDataReader["uploadID"].ToString());
                if (productInfoDataReader["submitted"] != null && productInfoDataReader["submitted"].ToString() != "")
                    submitted = (bool)productInfoDataReader["submitted"];
                if (productInfoDataReader["approved"] != null && productInfoDataReader["approved"].ToString() != "")
                    approved = (bool)productInfoDataReader["approved"];
                othertxt = productInfoDataReader["OtherText"].ToString();
                if (productInfoDataReader["Cost"] != null && productInfoDataReader["Cost"].ToString() != "")
                    ordercost = decimal.Parse(productInfoDataReader["Cost"].ToString());
                if (productInfoDataReader["Shipping"] != null && productInfoDataReader["Shipping"].ToString() != "")
                    ordershipping = decimal.Parse(productInfoDataReader["Shipping"].ToString());
            }
            else
            {
            }
            productInfoConnection.Dispose();

            return true;

        }

        public void toXmlProdInfoDetails(XmlTextWriter xmlOut)
        {
            string productInfoSQL;
            string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection productInfoConnection;
            SqlCommand productInfoCommand;
            SqlDataReader productInfoDataReader;

            xmlOut.WriteStartElement("productInfoDetails");
            xmlOut.WriteAttributeString("proj_num", res_projNum);
            xmlOut.WriteAttributeString("submittedstatus", submitted.ToString());
            xmlOut.WriteAttributeString("approvedstatus", approved.ToString());
            xmlOut.WriteAttributeString("resourceID", resource_id.ToString());

                xmlOut.WriteElementString("title", title);
                xmlOut.WriteElementString("book", book.ToString());
                xmlOut.WriteElementString("handbook", handbook.ToString());
                xmlOut.WriteElementString("workbook", workbook.ToString());
                xmlOut.WriteElementString("cdrom", cdrom.ToString());
                xmlOut.WriteElementString("video", video.ToString());
                xmlOut.WriteElementString("factsheet", factsheet.ToString());
                xmlOut.WriteElementString("manual", manual.ToString());
                xmlOut.WriteElementString("newsletter", newsletter.ToString());
                xmlOut.WriteElementString("extensionpub", extpub.ToString());
                xmlOut.WriteElementString("software", software.ToString());
                xmlOut.WriteElementString("website", website.ToString());
                xmlOut.WriteElementString("article", journal.ToString());
                xmlOut.WriteElementString("other", other.ToString());

                xmlOut.WriteElementString("beginner", beg.ToString());
                xmlOut.WriteElementString("intermediate", inter.ToString());
                xmlOut.WriteElementString("advanced", adv.ToString());

                xmlOut.WriteElementString("farmers", farmers.ToString());
                xmlOut.WriteElementString("educators", edu.ToString());
                xmlOut.WriteElementString("researchers", res.ToString());
                xmlOut.WriteElementString("consumers", consumers.ToString());

                xmlOut.WriteElementString("authoreditor", authoreditor);
                xmlOut.WriteElementString("authoreditorLast", authoreditorLast);
                xmlOut.WriteElementString("author2", author2);
                xmlOut.WriteElementString("author2Last", author2Last);
                xmlOut.WriteElementString("author3", author3);
                xmlOut.WriteElementString("author3Last", author3Last);
                xmlOut.WriteElementString("author4", author4);
                xmlOut.WriteElementString("author4Last", author4Last);
                xmlOut.WriteElementString("author5", author5);
                xmlOut.WriteElementString("author5Last", author5Last);
                xmlOut.WriteElementString("website_url", website_url);
                xmlOut.WriteElementString("website_pdf", website_pdf);

                xmlOut.WriteElementString("orderfirst", orderfirst);
                xmlOut.WriteElementString("orderlast", orderlast);
                xmlOut.WriteElementString("orderorg", orderorg);
                xmlOut.WriteElementString("orderaddress", orderaddress);
                xmlOut.WriteElementString("ordercity", ordercity);
                xmlOut.WriteElementString("orderstate", orderstate);
                xmlOut.WriteElementString("orderzip", orderzip);
                xmlOut.WriteElementString("orderphone", orderphone);
                xmlOut.WriteElementString("orderfax", orderfax);
                xmlOut.WriteElementString("orderemail", orderemail);
                xmlOut.WriteElementString("orderwebsite", orderwebsite);
                xmlOut.WriteElementString("orderproductID", orderproductID);
                xmlOut.WriteElementString("orderreleasedate", orderreleasedate);
                xmlOut.WriteElementString("avalqty", avalqty.ToString());
                xmlOut.WriteElementString("ordercomments", ordercomments);
                xmlOut.WriteElementString("resourceID", resource_id.ToString());
                xmlOut.WriteElementString("description", proddescription);
                xmlOut.WriteElementString("uploadID", uploadID.ToString());
                xmlOut.WriteElementString("othertxt", othertxt);
                xmlOut.WriteElementString("cost", ordercost.ToString());
                xmlOut.WriteElementString("shipping", ordershipping.ToString());

                if (resource_id > 0)
                {
                    productInfoConnection = new SqlConnection(productInfoConnString);

                    productInfoSQL = "DaikonProjectProductInfoByResID";
                    productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
                    productInfoCommand.CommandType = CommandType.StoredProcedure;
                    productInfoCommand.Parameters.Add("@res_id", SqlDbType.Int);
                    productInfoCommand.Parameters.Add("@upload_id", SqlDbType.Int);

                    productInfoCommand.Parameters["@res_id"].Value = resource_id;
                    productInfoCommand.Parameters["@upload_id"].Value = GetUploadID(resource_id);

                    productInfoConnection.Open();
                    productInfoDataReader = productInfoCommand.ExecuteReader();


                    while (productInfoDataReader.Read())
                    {
                        if (productInfoDataReader["uploadID"] != null && productInfoDataReader["uploadID"].ToString() != "")
                        {
                            if (productInfoDataReader["uploadID"].ToString() != "0")
                            {
                                xmlOut.WriteElementString("uploadID", productInfoDataReader["uploadID"].ToString());
                                xmlOut.WriteElementString("file_name", productInfoDataReader["file_name"].ToString());
                                xmlOut.WriteElementString("file_name_orig", productInfoDataReader["file_name_orig"].ToString());
                                xmlOut.WriteElementString("icon_name", productInfoDataReader["icon_name"].ToString());
                                xmlOut.WriteElementString("file_caption", productInfoDataReader["file_caption"].ToString());
                                xmlOut.WriteElementString("file_mimetype", productInfoDataReader["file_mimetype"].ToString());
                            }
                        }
                    }
                    productInfoConnection.Dispose();
                }
              
           xmlOut.WriteEndElement();
        }       

        public int saveNewProdInfoToDB(string username, int sessionkey)
        {
           
            string prodInfoSQL;
            string prodInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection prodInfoConnection;
            SqlCommand prodInfoCommand;

            prodInfoConnection = new SqlConnection(prodInfoConnString);

            prodInfoSQL = "DaikonProjectResourceInsert";
            prodInfoCommand = new SqlCommand(prodInfoSQL, prodInfoConnection);
            prodInfoCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter keyOutput = new SqlParameter("@ID", SqlDbType.Int);
            keyOutput.Direction = ParameterDirection.Output;

            prodInfoCommand.Parameters.Add("@Res_ProjectNumber", SqlDbType.VarChar, 12);
            prodInfoCommand.Parameters.Add("@Book", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Handbook", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Workbook", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@CDROM", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Video", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@FactSheet", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Manual", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Newsletter", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@ExtensionPub", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Software", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Website", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Article", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Other", SqlDbType.Bit);

            prodInfoCommand.Parameters.Add("@Beginner", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Intermediate", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Advanced", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Farmers_Ranchers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Educators", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Researchers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Consumers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Aval_Qty", SqlDbType.Bit);

            prodInfoCommand.Parameters.Add("@Title", SqlDbType.VarChar, 200);
            prodInfoCommand.Parameters.Add("@AuthorEditor", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@AuthorEditorLast", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author2", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author2Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author3", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author3Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author4", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author4Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author5", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author5Last", SqlDbType.VarChar, 100);

            prodInfoCommand.Parameters.Add("@DocURL", SqlDbType.NText);
            prodInfoCommand.Parameters.Add("@DocPDF", SqlDbType.NText);

            prodInfoCommand.Parameters.Add("@Order_Name", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Name_Last", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Org", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Address", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_City", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_State", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Zip", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Phone", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Fax", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Email", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Web", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@PubID", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@RelaseDate", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Comments", SqlDbType.NText);
            prodInfoCommand.Parameters.Add("@Description", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@uploadID", SqlDbType.Int);
            prodInfoCommand.Parameters.Add("@submitted", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@approved", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@OtherText", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Cost", SqlDbType.Money);
            prodInfoCommand.Parameters.Add("@Shipping", SqlDbType.Money);
            prodInfoCommand.Parameters.Add(keyOutput);

            prodInfoCommand.Parameters["@Res_ProjectNumber"].Value = res_projNum;
            prodInfoCommand.Parameters["@Book"].Value = book;
            prodInfoCommand.Parameters["@Handbook"].Value = handbook;
            prodInfoCommand.Parameters["@Workbook"].Value = workbook;
            prodInfoCommand.Parameters["@CDROM"].Value = cdrom;
            prodInfoCommand.Parameters["@Video"].Value = video;
            prodInfoCommand.Parameters["@FactSheet"].Value = factsheet;
            prodInfoCommand.Parameters["@Manual"].Value = manual;
            prodInfoCommand.Parameters["@Newsletter"].Value = newsletter;
            prodInfoCommand.Parameters["@ExtensionPub"].Value = extpub;
            prodInfoCommand.Parameters["@Software"].Value = software;
            prodInfoCommand.Parameters["@Website"].Value = website;
            prodInfoCommand.Parameters["@Article"].Value = journal;
            prodInfoCommand.Parameters["@Other"].Value = other;
            prodInfoCommand.Parameters["@Beginner"].Value = beg;
            prodInfoCommand.Parameters["@Intermediate"].Value = inter;
            prodInfoCommand.Parameters["@Advanced"].Value = adv;
            prodInfoCommand.Parameters["@Farmers_Ranchers"].Value = farmers;
            prodInfoCommand.Parameters["@Educators"].Value = edu;
            prodInfoCommand.Parameters["@Researchers"].Value = res;
            prodInfoCommand.Parameters["@Consumers"].Value = consumers;
            prodInfoCommand.Parameters["@Aval_Qty"].Value = avalqty;
            prodInfoCommand.Parameters["@Title"].Value = title;
            prodInfoCommand.Parameters["@AuthorEditor"].Value = (authoreditor);
            prodInfoCommand.Parameters["@AuthorEditorLast"].Value = (authoreditorLast);
            prodInfoCommand.Parameters["@Author2"].Value = (author2);
            prodInfoCommand.Parameters["@Author2Last"].Value = (author2Last);
            prodInfoCommand.Parameters["@Author3"].Value = (author3);
            prodInfoCommand.Parameters["@Author3Last"].Value = (author3Last);
            prodInfoCommand.Parameters["@Author4"].Value = (author4);
            prodInfoCommand.Parameters["@Author4Last"].Value = (author4Last);
            prodInfoCommand.Parameters["@Author5"].Value = (author5);
            prodInfoCommand.Parameters["@Author5Last"].Value = (author5Last);
            prodInfoCommand.Parameters["@DocURL"].Value = (website_url);
            prodInfoCommand.Parameters["@DocPDF"].Value = (website_pdf);
            prodInfoCommand.Parameters["@Order_Name"].Value = (orderfirst);
            prodInfoCommand.Parameters["@Order_Name_Last"].Value = (orderlast);
            prodInfoCommand.Parameters["@Order_Org"].Value = (orderorg);
            prodInfoCommand.Parameters["@Order_Address"].Value = (orderaddress);
            prodInfoCommand.Parameters["@Order_City"].Value = (ordercity);
            prodInfoCommand.Parameters["@Order_State"].Value = (orderstate);
            prodInfoCommand.Parameters["@Order_Zip"].Value = (orderzip);
            prodInfoCommand.Parameters["@Order_Phone"].Value = (orderphone);
            prodInfoCommand.Parameters["@Order_Fax"].Value = (orderfax);
            prodInfoCommand.Parameters["@Order_Email"].Value = (orderemail);
            prodInfoCommand.Parameters["@Order_Web"].Value = (orderwebsite);
            prodInfoCommand.Parameters["@PubID"].Value = (orderproductID);
            prodInfoCommand.Parameters["@RelaseDate"].Value = (orderreleasedate);
            prodInfoCommand.Parameters["@Comments"].Value = (ordercomments);
            prodInfoCommand.Parameters["@Description"].Value = proddescription;
            prodInfoCommand.Parameters["@uploadID"].Value = 0;
            prodInfoCommand.Parameters["@submitted"].Value = submitted;
            prodInfoCommand.Parameters["@approved"].Value = approved;
            prodInfoCommand.Parameters["@OtherText"].Value = othertxt;
            prodInfoCommand.Parameters["@Cost"].Value = ordercost;
            prodInfoCommand.Parameters["@Shipping"].Value = ordershipping;

            prodInfoConnection.Open();
            prodInfoCommand.ExecuteScalar();

            int key = Convert.ToInt32(keyOutput.Value);

            prodInfoConnection.Close();
            prodInfoCommand.Dispose();
            prodInfoConnection.Dispose();



            return key;
        }

        public bool UpdateProdInfoToDB(string username, int sessionkey)
        {
            string prodInfoSQL;
            string prodInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection prodInfoConnection;
            SqlCommand prodInfoCommand;

            prodInfoConnection = new SqlConnection(prodInfoConnString);

            prodInfoSQL = "DaikonProjectResourceUpdate";
            prodInfoCommand = new SqlCommand(prodInfoSQL, prodInfoConnection);
            prodInfoCommand.CommandType = CommandType.StoredProcedure;

            prodInfoCommand.Parameters.Add("@ResourceID", SqlDbType.Int);
            prodInfoCommand.Parameters.Add("@Book", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Handbook", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Workbook", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@CDROM", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Video", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@FactSheet", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Manual", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Newsletter", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@ExtensionPub", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Software", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Website", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Article", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Other", SqlDbType.Bit);

            prodInfoCommand.Parameters.Add("@Beginner", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Intermediate", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Advanced", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Farmers_Ranchers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Educators", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Researchers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Consumers", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@Aval_Qty", SqlDbType.Bit);

            prodInfoCommand.Parameters.Add("@Title", SqlDbType.VarChar, 200);
            prodInfoCommand.Parameters.Add("@AuthorEditor", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@AuthorEditorLast", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author2", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author2Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author3", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author3Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author4", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author4Last", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author5", SqlDbType.VarChar, 100);
            prodInfoCommand.Parameters.Add("@Author5Last", SqlDbType.VarChar, 100);

            prodInfoCommand.Parameters.Add("@DocURL", SqlDbType.NText);
            prodInfoCommand.Parameters.Add("@DocPDF", SqlDbType.NText);

            prodInfoCommand.Parameters.Add("@Order_Name", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Name_Last", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Org", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Order_Address", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_City", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_State", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Zip", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Phone", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Fax", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Email", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Order_Web", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@PubID", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@RelaseDate", SqlDbType.VarChar, 50);
            prodInfoCommand.Parameters.Add("@Comments", SqlDbType.NText);
            prodInfoCommand.Parameters.Add("@Description", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@uploadID", SqlDbType.Int);
            prodInfoCommand.Parameters.Add("@submitted", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@approved", SqlDbType.Bit);
            prodInfoCommand.Parameters.Add("@OtherText", SqlDbType.VarChar, 255);
            prodInfoCommand.Parameters.Add("@Cost", SqlDbType.Money);
            prodInfoCommand.Parameters.Add("@Shipping", SqlDbType.Money);

            prodInfoCommand.Parameters["@ResourceID"].Value = resource_id;
            prodInfoCommand.Parameters["@Book"].Value = book;
            prodInfoCommand.Parameters["@Handbook"].Value = handbook;
            prodInfoCommand.Parameters["@Workbook"].Value = workbook;
            prodInfoCommand.Parameters["@CDROM"].Value = cdrom;
            prodInfoCommand.Parameters["@Video"].Value = video;
            prodInfoCommand.Parameters["@FactSheet"].Value = factsheet;
            prodInfoCommand.Parameters["@Manual"].Value = manual;
            prodInfoCommand.Parameters["@Newsletter"].Value = newsletter;
            prodInfoCommand.Parameters["@ExtensionPub"].Value = extpub;
            prodInfoCommand.Parameters["@Software"].Value = software;
            prodInfoCommand.Parameters["@Website"].Value = website;
            prodInfoCommand.Parameters["@Article"].Value = journal;
            prodInfoCommand.Parameters["@Other"].Value = other;
            prodInfoCommand.Parameters["@Beginner"].Value = beg;
            prodInfoCommand.Parameters["@Intermediate"].Value = inter;
            prodInfoCommand.Parameters["@Advanced"].Value = adv;
            prodInfoCommand.Parameters["@Farmers_Ranchers"].Value = farmers;
            prodInfoCommand.Parameters["@Educators"].Value = edu;
            prodInfoCommand.Parameters["@Researchers"].Value = res;
            prodInfoCommand.Parameters["@Consumers"].Value = consumers;
            prodInfoCommand.Parameters["@Aval_Qty"].Value = avalqty;
            prodInfoCommand.Parameters["@Title"].Value = title;
            prodInfoCommand.Parameters["@AuthorEditor"].Value = dbNullify(authoreditor);
            prodInfoCommand.Parameters["@AuthorEditorLast"].Value = dbNullify(authoreditorLast);
            prodInfoCommand.Parameters["@Author2"].Value = dbNullify(author2);
            prodInfoCommand.Parameters["@Author2Last"].Value = dbNullify(author2Last);
            prodInfoCommand.Parameters["@Author3"].Value = dbNullify(author3);
            prodInfoCommand.Parameters["@Author3Last"].Value = dbNullify(author3Last);
            prodInfoCommand.Parameters["@Author4"].Value = dbNullify(author4);
            prodInfoCommand.Parameters["@Author4Last"].Value = dbNullify(author4Last);
            prodInfoCommand.Parameters["@Author5"].Value = dbNullify(author5);
            prodInfoCommand.Parameters["@Author5Last"].Value = dbNullify(author5Last);
            prodInfoCommand.Parameters["@DocURL"].Value = dbNullify(website_url);
            prodInfoCommand.Parameters["@DocPDF"].Value = dbNullify(website_pdf);
            prodInfoCommand.Parameters["@Order_Name"].Value = dbNullify(orderfirst);
            prodInfoCommand.Parameters["@Order_Name_Last"].Value = dbNullify(orderlast);
            prodInfoCommand.Parameters["@Order_Org"].Value = dbNullify(orderorg);
            prodInfoCommand.Parameters["@Order_Address"].Value = dbNullify(orderaddress);
            prodInfoCommand.Parameters["@Order_City"].Value = dbNullify(ordercity);
            prodInfoCommand.Parameters["@Order_State"].Value = dbNullify(orderstate);
            prodInfoCommand.Parameters["@Order_Zip"].Value = dbNullify(orderzip);
            prodInfoCommand.Parameters["@Order_Phone"].Value = dbNullify(orderphone);
            prodInfoCommand.Parameters["@Order_Fax"].Value = dbNullify(orderfax);
            prodInfoCommand.Parameters["@Order_Email"].Value = dbNullify(orderemail);
            prodInfoCommand.Parameters["@Order_Web"].Value = dbNullify(orderwebsite);
            prodInfoCommand.Parameters["@PubID"].Value = dbNullify(orderproductID);
            prodInfoCommand.Parameters["@RelaseDate"].Value = dbNullify(orderreleasedate);
            prodInfoCommand.Parameters["@Comments"].Value = dbNullify(ordercomments);
            prodInfoCommand.Parameters["@Description"].Value = proddescription;
            prodInfoCommand.Parameters["@uploadID"].Value = uploadID;
            prodInfoCommand.Parameters["@submitted"].Value = submitted;
            prodInfoCommand.Parameters["@approved"].Value = approved;
            prodInfoCommand.Parameters["@OtherText"].Value = othertxt;
            prodInfoCommand.Parameters["@Cost"].Value = ordercost;
            prodInfoCommand.Parameters["@Shipping"].Value = ordershipping;


            prodInfoConnection.Open();
            prodInfoCommand.ExecuteScalar();
            prodInfoConnection.Close();
            prodInfoCommand.Dispose();
            prodInfoConnection.Dispose();

            return true;
        }

        public bool DeleteProdInfoFromDB(int resourceID, int uploadID)
        {
            string prodInfoSQL;
            string prodInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection prodInfoConnection;
            SqlCommand prodInfoCommand;

            prodInfoConnection = new SqlConnection(prodInfoConnString);

            prodInfoSQL = "DaikonProjectResourceDelete";
            prodInfoCommand = new SqlCommand(prodInfoSQL, prodInfoConnection);
            prodInfoCommand.CommandType = CommandType.StoredProcedure;

            prodInfoCommand.Parameters.Add("@resourceID", SqlDbType.Int);
            prodInfoCommand.Parameters.Add("@uploadID", SqlDbType.Int);

            prodInfoCommand.Parameters["@resourceID"].Value = resourceID;
            prodInfoCommand.Parameters["@uploadID"].Value = uploadID;

            prodInfoConnection.Open();
            prodInfoCommand.ExecuteScalar();
            prodInfoConnection.Close();
            prodInfoCommand.Dispose();
            prodInfoConnection.Dispose();

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

        public void toXml(XmlTextWriter xmlOut)
        {
            xmlOut.WriteStartElement("productInfo");
            for (int i = 0; i < prodInfoList.Count; i++)
            {
                //xmlOut.WriteAttributeString("proj_num", res_projNum);
                //xmlOut.WriteAttributeString("approvedstatus", "false");
                xmlOut.WriteStartElement("resource");
                xmlOut.WriteAttributeString("resourceID", prodInfoList.GetKey(i).ToString());
                xmlOut.WriteElementString("title", prodInfoList[prodInfoList.GetKey(i)].ToString());

                int resource_id = Int32.Parse(prodInfoList.GetKey(i).ToString());
                string productInfoSQL;
                string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                SqlConnection productInfoConnection;
                SqlCommand productInfoCommand;
                SqlDataReader productInfoDataReader;

                productInfoConnection = new SqlConnection(productInfoConnString);

                productInfoSQL = "DaikonProjectProductInfoByResID";
                productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
                productInfoCommand.CommandType = CommandType.StoredProcedure;
                productInfoCommand.Parameters.Add("@res_id", SqlDbType.Int);
                productInfoCommand.Parameters.Add("@upload_id", SqlDbType.Int);

                productInfoCommand.Parameters["@res_id"].Value = resource_id;
                productInfoCommand.Parameters["@upload_id"].Value = GetUploadID(resource_id);

                productInfoConnection.Open();
                productInfoDataReader = productInfoCommand.ExecuteReader();


                while (productInfoDataReader.Read())
                {
                    if (productInfoDataReader["uploadID"] != null && productInfoDataReader["uploadID"].ToString() != "")
                    {
                        if (productInfoDataReader["uploadID"].ToString() != "0")
                        {
                            xmlOut.WriteElementString("uploadID", productInfoDataReader["uploadID"].ToString());
                            xmlOut.WriteElementString("file_name", productInfoDataReader["file_name"].ToString());
                            xmlOut.WriteElementString("file_name_orig", productInfoDataReader["file_name_orig"].ToString());
                            xmlOut.WriteElementString("icon_name", productInfoDataReader["icon_name"].ToString());
                            xmlOut.WriteElementString("file_caption", productInfoDataReader["file_caption"].ToString());
                            xmlOut.WriteElementString("file_mimetype", productInfoDataReader["file_mimetype"].ToString());
                        }
                    }
                    xmlOut.WriteElementString("submittedstatus", productInfoDataReader["submitted"].ToString());
                    xmlOut.WriteElementString("approvedstatus", productInfoDataReader["approved"].ToString());
                }
                productInfoConnection.Dispose();

                //xmlOut.WriteElementString("desc", desc);
                xmlOut.WriteEndElement();
               
            }
            xmlOut.WriteEndElement();
        }

        public int GetUploadID(int resource_id)
        {
            int uploadId = 0;
            string productInfoSQL;
            string productInfoConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
            SqlConnection productInfoConnection;
            SqlCommand productInfoCommand;
            SqlDataReader productInfoDataReader;            

            productInfoConnection = new SqlConnection(productInfoConnString);

            productInfoSQL = "DaikonProjectProductInfoGetUploadID";
            productInfoCommand = new SqlCommand(productInfoSQL, productInfoConnection);
            productInfoCommand.CommandType = CommandType.StoredProcedure;
            productInfoCommand.Parameters.Add("@res_id", SqlDbType.Int);

            productInfoCommand.Parameters["@res_id"].Value = resource_id;

            productInfoConnection.Open();
            productInfoDataReader = productInfoCommand.ExecuteReader();


            while (productInfoDataReader.Read())
            {
                if (productInfoDataReader["uploadID"] != null && productInfoDataReader["uploadID"].ToString() != "")
                {
                    uploadId = Int32.Parse(productInfoDataReader["uploadID"].ToString());
                }               
            }
            productInfoConnection.Dispose();

            return uploadId;

        }
       
        
    }
}
