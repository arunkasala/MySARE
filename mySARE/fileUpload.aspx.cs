using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace daikon
{
    public partial class fileUpload : System.Web.UI.Page
    {

        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        
        WindowsImpersonationContext impersonationContext;
        [DllImport("advapi32.dll")]

        public static extern int LogonUserA(String lpszUserName,
                                            String lpszDomain,
                                            String lpszPassword,
                                            int dwLogonType,
                                            int dwLogonProvider,
                                            ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        
        public static extern int DuplicateToken(IntPtr hToken,
                                                int impersonationLevel,
                                                ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]

        public static extern bool CloseHandle(IntPtr handle);

        private bool ImpersonateUser(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
            return false;
        }

        private void UndoImpersonation()
        {
            impersonationContext.Undo();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int order;
            int subsectionUID;
            string projNum;
            DaikonReportImage upFile;
            bool fileLimit = true;
            int fileSizeActual = 0;
            string fileLimitMessage = "";
                       
            if (IsPostBack)
            {
                String currUser = ((DaikonUser)(Session["currUser"])).Username;
                int sessionKey = Convert.ToInt32((int)Session["sessionkey"]);
                Boolean fileOK = false;
                String mimeType = "";
                Boolean isScalable = false;
                System.Drawing.Image scaledImage;
                String path = "";//(@"\\if-srvv-media.ad.ufl.edu\websites$\ifasgallery.ifas.ufl.edu\sare\"); //Server.MapPath("~/assocfiles/");
                String fileExtension = "";

                if (Request.Params["suid"] != null)
                    subsectionUID = Convert.ToInt32(Request.Params["suid"]);
                else
                    subsectionUID = 0;
                order = Convert.ToInt32(Request.Params["order"]);

                if (Request.Params["projNum"] != null)
                    projNum = Request.Params["projNum"];
                else
                    projNum = "";

                if (UploadAssocFile.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(UploadAssocFile.FileName).ToLower();
                    //[DaikonFilesGetTypeForExtension]
                    string fileSQL;
                    string fileConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                    SqlConnection fileConnection;
                    SqlCommand fileCommand;
                    SqlDataReader fileDataReader;
                    // Get the size in bytes of the file to upload.
                    int fileSize = UploadAssocFile.PostedFile.ContentLength;                    

                    fileConnection = new SqlConnection(fileConnString);

                    fileSQL = "DaikonFilesGetTypeForExtension";
                    fileCommand = new SqlCommand(fileSQL, fileConnection);
                    fileCommand.CommandType = CommandType.StoredProcedure;
                    fileCommand.Parameters.Add("@extension", SqlDbType.VarChar, 6);

                    fileCommand.Parameters["@extension"].Value = fileExtension;

                    if (fileExtension == ".wma")
                        path = (@"\\if-srv-video.ad.ufl.edu\video\sare\");
                    else if (fileExtension == ".asf" || fileExtension == ".asx" || fileExtension == ".avi" || fileExtension == ".mov" ||
                             fileExtension == ".mp4" || fileExtension == ".mpeg" || fileExtension == "mpg" || fileExtension == ".qt")
                    {
                        path = (@"\\if-srvv-media.ad.ufl.edu\websites$\ifasgallery.ifas.ufl.edu\sare\");
                        //string loc = (@"\\if-srv-video.ad.ufl.edu\video\sare\ /USER:If-svc-sare-media zZyYXyTkAO");
                        //System.Diagnostics.Process.Start("net.exe", "use G: " + loc);
                        if (fileSize > 146800640)
                        {
                            fileLimit = false;
                            fileSizeActual = fileSize / 1048576;
                            fileLimitMessage = "Maximum File Size limit 140 MB. But you are uploading " + fileSizeActual.ToString() + " MB";
                        }
                    }
                    else
                    {
                        if (fileSize > 31457280)
                        {
                            fileLimit = false;
                            fileSizeActual = fileSize / 1048576;
                            fileLimitMessage = "Maximum File Size limit 30 MB. But you are uploading " + fileSizeActual.ToString() + " MB";
                        }
                        else
                            path = Server.MapPath("~/assocfiles/");
                    }

                    fileConnection.Open();
                    fileDataReader = fileCommand.ExecuteReader();
                    
                    if (fileDataReader.HasRows && fileLimit)
                    {
                        fileDataReader.Read();
                        fileOK = (bool)(fileDataReader["allowed"]);
                        mimeType = fileDataReader["mimetype"].ToString();
                        isScalable = (bool)(fileDataReader["is_scalable"]);
                    }
                    else
                    {
                        fileOK = false;
                    }
                    fileDataReader.Dispose();
                    fileConnection.Dispose();

                }

/*
                    String[] allowedExtensions = 
                { ".gif", ".png", ".jpeg", ".jpg", ".pdf", ".doc", ".ppt", ".mp3", ".mpg", ".mp4", ".xls" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                            switch (fileExtension)
                            {
                                case ".pdf":
                                    mimeType = "application/pdf";
                                    isScalable = false;
                                    break;
                                case ".gif":
                                    mimeType = "image/gif";
                                    isScalable = true;
                                    break;
                                case ".jpg":
                                    mimeType = "image/jpeg";
                                    isScalable = true;
                                    break;
                                case ".jpeg":
                                    mimeType = "image/jpeg";
                                    isScalable = true;
                                    break;
                                case ".png":
                                    mimeType = "image/png";
                                    isScalable = true;
                                    break;
                                case ".doc":
                                    mimeType = "application/msword";
                                    break;
                                case ".xls":
                                    mimeType = "application/vnd.ms-excel";
                                    break;
                                case ".ppt":
                                    mimeType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".mpg":
                                    mimeType = "video/mpeg";
                                    break;
                                case ".mp4":
                                    mimeType = "video/mp4";
                                    break;
                                case ".mp3":
                                    mimeType = "audio/mpeg";
                                    break;
                                default:
                                    mimeType = "";
                                    break;
                            }
                        }
                    }
                }
*/

                if (fileOK)
                {
//                    try
//                    {
                        upFile = new DaikonReportImage();
                            
                        if (subsectionUID > 0)
                        {
                            if (fileExtension == ".asf" || fileExtension == ".asx" || fileExtension == ".avi" || fileExtension == ".mov" ||
                             fileExtension == ".mp4" || fileExtension == ".mpeg" || fileExtension == "mpg" || fileExtension == ".qt")
                            {
                                if (ImpersonateUser("If-svc-sare-media", "", "zZyYXyTkAO"))
                                {
                                    UploadAssocFile.PostedFile.SaveAs(path
                                   + subsectionUID.ToString()
                                   + CleanupFileName(UploadAssocFile.FileName));
                                   
                                }
                               
                            }
                            else
                            {
                                UploadAssocFile.PostedFile.SaveAs(path
                                   + subsectionUID.ToString()
                                   + CleanupFileName(UploadAssocFile.FileName));
                            }

                            if (isScalable)
                            {
                                scaledImage = new System.Drawing.Bitmap(UploadAssocFile.PostedFile.InputStream);
                                scaledImage.GetThumbnailImage(40, 40, null, System.IntPtr.Zero).Save(path + "tn_" + subsectionUID.ToString() + CleanupFileName(UploadAssocFile.FileName));
                            }

                            upFile.Name = subsectionUID.ToString() + CleanupFileName(UploadAssocFile.FileName);
                            upFile.NameOriginal = CleanupFileName(UploadAssocFile.FileName);
                            upFile.Order = order;
                            upFile.Category = Convert.ToInt32(DropDownList1.SelectedValue);
                            upFile.Caption = TextBox1.Text;
                            upFile.Mimetype = mimeType;

                            //impersonationContext.Dispose();
                            //Re-Casting failed repeatedly--not sure why
                            // DaikonReportImage upFile2 = (DaikonReportImage)(upFile);
                            //This order 999 to differentiate between Report and Resource upload
                            if (order == 999)
                                upFile.saveNewInfoProductImageToDB(currUser, sessionKey, subsectionUID);
                            else if (order == 777)
                                upFile.savePDPAttachmentToDB(currUser, sessionKey, projNum);
                            else
                                upFile.saveNewReportImageToDB(currUser, sessionKey, subsectionUID);
                            
                            Label3.Text = "File Data Saved. Close this window to continue.";
							Session["statusMessage2"] = "File Data Saved.";
							success.Value = "true";
							fileExists.Value = "true";

                            if (fileExtension == ".asf" || fileExtension == ".asx" || fileExtension == ".avi" || fileExtension == ".mov" ||
                            fileExtension == ".mp4" || fileExtension == ".mpeg" || fileExtension == "mpg" || fileExtension == ".qt")
                                UndoImpersonation();
						}
                        else if (subsectionUID == 0)
                        {
                            Label3.Text = "Data Not Saved. Please enter text into the subsection this file is to be attached to and save the report before uploading files.";
                        }
                        else
                        {
                            UploadAssocFile.PostedFile.SaveAs(path
                               + CleanupFileName(UploadAssocFile.FileName));

                            Label3.Text = "Data Not Saved. Files not related to reports are not yet supported, but will still be stored.";
                        }
                        Label1.Text = "File uploaded!";

                        //System.Diagnostics.Process.Start("net.exe", "use /delete G:");

						Session["statusMessage2"] = "File Uploaded.";
                        Session["fileID"] = upFile.FileID.ToString();
						success.Value = "true";
/*
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "File could not be uploaded.";
                    }
*/
                }
                else if (Request.Params["fileid"] != null)
                {
                    if (Request.Form["changeDetails"] != null)
                    {
                        upFile = new DaikonReportImage(Convert.ToInt32(Request.Params["fileid"]), Convert.ToInt32(Request.Params["order"]));
                        upFile.Category = Convert.ToInt32(DropDownList1.SelectedValue);
                        upFile.Caption = TextBox1.Text;
                        upFile.saveReportImageToDB(currUser, sessionKey, subsectionUID);
                        Label3.Text = "File data updated! Close this window to continue.";
						Session["statusMessage2"] = "File Data Saved.";
						success.Value = "true";
					}
                    else if (Request.Form["deleteFile"] != null)
                    {
                        if (Request.Form["confirm"] != null || Request.Form["confirm1"] != null)
                        {
                            upFile = new DaikonReportImage(Convert.ToInt32(Request.Params["fileid"]), Convert.ToInt32(Request.Params["order"]));
                            //This order 999 to differentiate between Report and Resource upload
                            if (order == 999)
                                upFile.deleteInfoProductImageFromDB(currUser, sessionKey, subsectionUID, Convert.ToInt32(Request.Params["fileid"]));
                            else if (order == 777)
                                upFile.deletePDPAttachmentFromDB(currUser, sessionKey, projNum, Convert.ToInt32(Request.Params["fileid"]));
                            else
                                upFile.deleteReportImageFromDB(currUser, sessionKey);
                            //                        form1.Controls.Clear();
                            Label1.Text = "File Deleted! Close this window to continue.";
                            Session["statusMessage2"] = "File Deleted.";
                            success.Value = "true";
                            /*
                            string completePath = (@"\\if-srvv-media.ad.ufl.edu\websites$\ifasgallery.ifas.ufl.edu\sare\");
                            completePath += upFile.Name;
                            if (System.IO.File.Exists(completePath))
                            {

                                System.IO.File.Delete(completePath);

                            }
                            */

                        }
                        else
                        {
                            Label3.Text = "File can be deleted only with confirm checked.";
                            Session["statusMessage2"] = "File is not deleted.";
                        }
					}
                }
                else
                {
                    string fileTypesAllow = fileTypeLabel.Text.ToString();

                    if (fileExtension.Length > 0 && fileTypesAllow.IndexOf(fileExtension) == -1)
                        Label1.Text = "Cannot accept files of this type.";
                    else
                    {
                        if (fileLimit)
                            Label1.Text = "";
                        else
                        {
                            Label1.Text = fileLimitMessage;
                            Label1.ForeColor = Color.Red;
                            Label1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                if (Request.Params["suid"] != null)
                    subsectionUID = Convert.ToInt32(Request.Params["suid"]);
                else
                    subsectionUID = 0;
                
                order = Convert.ToInt32(Request.Params["order"]);

                if (Request.Params["move"] != null)
                {
                    upFile = new DaikonReportImage(Convert.ToInt32(Request.Params["fileid"]));
                    upFile.reorderReportImageInDB(((DaikonUser)(Session["currUser"])).Username, Convert.ToInt32((int)Session["sessionkey"]), subsectionUID, Convert.ToInt32(Request.Params["order"]));
                    Label3.Text = "File data updated! Close this window to continue.";
                    Session["statusMessage2"] = "File Data Saved.";
                    success.Value = "true";
                    return;
                }
                if (Request.Params["fileid"] != null)
                {
                    upFile = new DaikonReportImage(Convert.ToInt32(Request.Params["fileid"]), order);
                    TextBox1.Text = upFile.Caption;
                    DropDownList1.SelectedValue = upFile.Category.ToString();
					if (upFile.Category < 3)
					{
						Image1.ImageUrl = "./assocfiles/" + upFile.Name;

                        //Image1.ImageUrl = "http://ifasgallery.ifas.ufl.edu/sare/" + upFile.Name;
					}

					Label1.Text = "Update Details for: " + upFile.NameOriginal;
                    UploadAssocFile.Enabled = false;
					fileExists.Value = "true";
                }
                else
                    DropDownList1.SelectedValue = DefaultDropDownSelect();


                if (Request.Params["order"] != null && Request.Params["order"] == "999")
                {
                    productInfo.Value = "true";
                    if (Request.Params["title"] != null)
                        TextBox1.Text = Request.Params["title"].ToString();
                }
                else
                    Label2.Text = "Order: " + order.ToString();
                
                    
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileCategory = DropDownList1.SelectedValue;

            displayFileExtensions(fileCategory);
                           
        }   

        protected string DefaultDropDownSelect()
        {
            // Document
            return "4";
        }


        private void displayFileExtensions(string fileCategory)
        {
            
            switch (fileCategory)
            {
                case "1":
                    this.fileTypeLabel.Text = ".gif,.jpeg,.jpg,.png";
                    break;

                case "2":
                    this.fileTypeLabel.Text = ".ppsx,.ppt,.pptx";
                    break;

                case "3":
                    this.fileTypeLabel.Text = ".xls,.xlsx";
                    break;

                case "4":
                    this.fileTypeLabel.Text = ".doc,.docx,.pdf,.rtf";
                    break;

                case "5":
                    this.fileTypeLabel.Text = ".asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt";
                    break;

                case "6":
                    this.fileTypeLabel.Text = ".au,.mp3";
                    break;
            }

        }

        public static string CleanupFileName(string fileName)
        {
            //Special Characters Not Allowed: ~ " # % & * : < > ? / \ { | }      
            if (!string.IsNullOrEmpty(fileName))
            {
                //Regex to Replace the Special Character
                fileName = Regex.Replace(fileName, @"[~#'%&*:<>?/\{|}\n]", "-");

                if (fileName.Contains("\""))
                {
                    fileName = fileName.Replace("\"", "");
                }

                if (fileName.StartsWith(".", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = fileName.TrimStart(new char[] { '.' });
                }
                if (fileName.IndexOf("..", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    fileName = fileName.Replace("..", "");
                }
                fileName = fileName.Replace("/n", string.Empty);
            }
            return fileName;
        }



    }
}
