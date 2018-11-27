<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileUpload.aspx.cs" Inherits="daikon.fileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>mySARE File Upload</title>
		<link rel="STYLESHEET" type="text/css" href="http://www.sare.org/css/stylens.css" />
<script language="JavaScript">

function onUnload() {

    if (window.opener && (document.getElementById("success").value == "true"))
    {
	    window.opener.location.reload();
	    window.close();    
    }  
      
    switch (document.getElementById("DropDownList1").value)
    {
        case "1":
            document.getElementById('fileTypeLabel').innerHTML = ".gif,.jpeg,.jpg,.png";
            break;

        case "2":
            document.getElementById('fileTypeLabel').innerHTML = ".ppsx,.ppt,.pptx";
            break;

        case "3":
            document.getElementById('fileTypeLabel').innerHTML = ".xls,.xlsx";
            break;

        case "4":
            document.getElementById('fileTypeLabel').innerHTML = ".doc,.docx,.pdf,.rtf";
            break;

        case "5":
            document.getElementById('fileTypeLabel').innerHTML = ".asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt";
            break;

        case "6":
            document.getElementById('fileTypeLabel').innerHTML = ".au,.mp3";
            break;
    }
}

function uploadFile_onclick() {

    var fileSize = document.getElementById("<%=UploadAssocFile.ClientID%>").files[0].size;
    var fileType = document.getElementById("DropDownList1").value;

    if (document.getElementById('TextBox1').value == "")
    {
        alert ("Caption field is required");
        return false;
    }
    else if (document.getElementById('UploadAssocFile').value.indexOf('#')>-1)
    {
         alert("Please select file with valid name");
         return false;
    }
    else if (fileSize > 31457280 || fileSize > 146800640)
    {
        var fileLimitMessage = "";

        if (fileType == "5") {
            fileLimitMessage = "Maximum File Size limit 140 MB. But you are uploading " + Number((fileSize / 1048576).toFixed(2)) + " MB";
            alert(fileLimitMessage);
            return false;
        }
        else
        {
            fileLimitMessage = "Maximum File Size limit 30 MB. But you are uploading " + Number((fileSize / 1048576).toFixed(2)) + " MB";
            alert(fileLimitMessage);
            return false;
        }
    }
    else
        return true;
}

function Submit1_onclick() {
    if (document.getElementById('Confirm').checked == false)
    {
        alert ("To delete file confirm should be checked.");
        return false;
    }
    else
        return true;
}

function deleteFile_onclick() {
    if (document.getElementById('Confirm1').checked == false)
    {
        alert ("To delete file confirm should be checked.");
        return false;
    }
    else
        return true;
}


</script>

<!-- Google Analytic Code -->
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-9112638-1']);
  _gaq.push(['_setDomainName', 'sare.org']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>


</head>
<body onLoad="javascript:onUnload();" class="copy">
    <form id="form1" runat="server">
		<asp:HiddenField ID="fileExists" runat="server" Value="false" />
        <asp:HiddenField ID="success" runat="server" Value="false" />
        <asp:HiddenField ID="productInfo" runat="server" Value="false" />
        <%if (productInfo.Value == "false"){ %>
        <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Upload files to support your project report text."
            Width="510px"></asp:Label><br />
         <% } %>
        <%if (productInfo.Value == "true" && fileExists.Value == "false"){ %>
        <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="Upload educational materials such as books, factsheets, newsletters or audio/video files that were produced as part of your grant."
            Width="510px"></asp:Label><br />
         <% } %>
        <%if ((Image1.ImageUrl != "" || fileExists.Value == "true") && productInfo.Value == "false"){ %>
        <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Use this dialog box to modify or delete your information product file."
            Width="510px"></asp:Label><br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="• To delete the file, click the Confirm checkbox, then click Delete File."
            Width="510px"></asp:Label><br />
        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="• To modify the file title, enter the new title in the field below then click Save Details."
            Width="510px"></asp:Label><br />
        <% } %>
         <%if ((Image1.ImageUrl != "" || fileExists.Value == "true") && productInfo.Value == "true"){ %>
        <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Use this dialog box to delete your supporting file or modify its caption."
            Width="510px"></asp:Label><br />
        <asp:Label ID="Label10" runat="server" Font-Bold="False" Text="• To delete the file, click the Confirm checkbox, then click Delete File."
            Width="510px"></asp:Label><% } %><br />
        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>&nbsp;<%if (Image1.ImageUrl != "") { %><asp:Image ID="Image1"
            runat="server" /><% } %><br />
    <div>
        <table style="width: 515px">
            <%if (productInfo.Value == "false"){ %>
            <tr>
                <td style="width: 145px">
                    File Category</td>
                <td>
                    <asp:SqlDataSource ID="fileUploadDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sareDaikonConnectionString %>"
                        SelectCommand="DaikonFilesReturnStaticValues" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="fileUploadDataSource" 
                        AutoPostBack="True" DataTextField="file_cat_name" DataValueField="file_cat_num" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                    </asp:DropDownList>Allowable file types:<asp:Label ID="fileTypeLabel" runat="server" Width="119px"></asp:Label></td>
            </tr>
            <% } %>
            <tr>
                <td style="width: 145px">
                    File</td>
                <td>
                    <asp:FileUpload ID="UploadAssocFile" runat="server"/>
                </td>
            </tr>
            <tr>
                <%if (productInfo.Value == "false"){ %>
                <td style="width: 145px">
                    Title</td><% } %>
                 <%if (productInfo.Value == "true"){ %>
                <td style="width: 145px">
                    Title</td><% } %>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox></td>
            </tr>
        </table>
        <%if (fileExists.Value == "false") { %><input type="submit" id="uploadFile" name="uploadFile" value="Upload File" onclick="return uploadFile_onclick()" /><% } %>
        <%if (fileExists.Value == "true" && productInfo.Value == "true") { %>        
        <input type="submit" id="cancel" onclick="window.close()" value="Cancel" />
        <input type="submit" id="deleteFile" name="deleteFile" value="Delete File" onclick="return deleteFile_onclick()"/>
        <asp:CheckBox ID="Confirm1" runat="server" Text="Confirm" Width="73px" />
        <% } %>
         <%if (fileExists.Value == "true" && productInfo.Value == "false") { %>
        <input type="submit" id="changeDetails" name="changeDetails" value="Save Details" /> 
        <input type="submit" id="Submit1" name="deleteFile" value="Delete File" onclick="return Submit1_onclick()" />
        <asp:CheckBox ID="Confirm" runat="server" Text="Confirm" Width="73px" /><% } %></div><br />
        <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Maximum upload size is 30 Mb for documents and 140 Mb for media files. Large files may take several minutes to upload. This window will close when the upload is complete." Width="542px" Font-Size="Smaller"></asp:Label><br />
        <asp:label runat="server" id="linksPart" Width="541px" Font-Size="Smaller"><b>Note: </b>By uploading images you grant SARE and USDA nonexclusive rights and permissions to use them in all current and future information products. If a photograph contains human subjects who are under 18 years of age, you certify that you have obtained appropriate authorization from a parent or legal guardian, and have submitted a <a href="http://www.sare.org/index.php/content/download/3844/36460/file/photo_release.pdf">Photograph release and authorization forms</a> to SARE.</asp:label>&nbsp;
       
    </form>
</body>
</html>
