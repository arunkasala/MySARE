<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="editprojectprodinfo"/>
<xsl:param name="granttype"/>
<xsl:param name="publicview"/>
<xsl:param name="mytitle"/>
<xsl:param name="projectType"/>
<xsl:param name="projectRegion"/>
<xsl:param name="projectTitle"/>
<xsl:param name="sareGrant"/>

<xsl:template match="/">
	<title>
		<xsl:value-of select="$mytitle"/>
	</title>
	
	<script LANGUAGE="JavaScript">
		<![CDATA[
function openWindow(url, name) {
	var l = openWindow.arguments.length;
	var w = "";
	var h = "";
	var features = "";

	for (i=2; i<l; i++) {
		var param = openWindow.arguments[i];

		if ( (parseInt(param) == 0) ||
(isNaN(parseInt(param))) ) {
			features += param + ',';
		}
		else {
			(w == "") ? w = "width=" + param + "," : h =
"height=" + param;
		}
	}

	features += w + h;
	var code = "popupWin = window.open(url, name";
	if (l > 2) code += ", '" + features;
	code += "')";
	eval(code);
	popupWin.focus();
}
function check(box) 
{ 
 var val = box.value/1 
 // limit to 2 dec places (rounding up, if needed) 
 box.value = Math.round(val*100)/100 
 // check <7 after dec point 
 if(!(val<1000000)) 
 {
	alert("Amount should be numeric");
	box.value = 0.00
 }

} 

function show_prompt()
{
       var inputVal = prompt('Please enter your reason for not approving report:');
       document.getElementById('oHidden').value = inputVal;

}

function chText(elementId)
{
    var str=document.getElementById(elementId);
    var regex=/[^A-Za-z0-9 .]/gi;
    str.value=str.value.replace(regex ,"");
}
]]>
	</script>

	

<form id="infoproduct" name="infoproduct" method="post">
	<xsl:variable name="submitted" select="/SAREroot/productInfoDetails/@submittedstatus"/>
	<xsl:variable name="approved" select="/SAREroot/productInfoDetails/@approvedstatus"/>
	<xsl:variable name="resourceID" select="/SAREroot/productInfoDetails/resourceID"/>
	<xsl:variable name="uploadID" select="/SAREroot/productInfoDetails/uploadID"/>
	<xsl:variable name="prodTitle" select="/SAREroot/productInfoDetails/title"/>
	<xsl:variable name="proj_num" select="/SAREroot/productInfoDetails/@proj_num"/>
<p>
	<span class="pagetitle">
		<xsl:choose>
			<xsl:when test="$publicview"></xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE
				<br/><br/>
			</xsl:otherwise>
		</xsl:choose>		
	</span>
	
	<xsl:choose>
		<xsl:when test="$publicview">
			<span class="pagetitle">MySARE Information Product Details&#160;&#160;&#160;&#160;<!-- <input type="button" value="Back to Project Overview" onClick="history.go(-1)"/> -->
		</span>&#160;&#160;&#160;&#160;
			<br/><br/>
			<a href="ProjectReport.aspx?do=viewProj&amp;pn={$proj_num}"><xsl:value-of select="$projectTitle"/></a>
			<br/>
			<b CLASS="TITLE">Project Number: </b><xsl:value-of select="$proj_num"/>
			<br/>
			<b CLASS="TITLE">Type: </b><xsl:value-of select="$projectType"/>
			<br/>
			<b CLASS="TITLE">Region: </b><xsl:value-of select="$projectRegion"/>
			<br/>
			<b CLASS="TITLE">SARE Grant: </b>$<xsl:value-of select="format-number($sareGrant, '###,###,###')"/>
			<br/>
			<br/>
		</xsl:when>
		<xsl:otherwise>
			<span class="pagetitle">Add Information Product</span>
			&#160;&#160;
			<!-- 
			<xsl:text disable-output-escaping="yes"><![CDATA[
				<a href="help/editreport.htm#infoprod" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>
				<div class="highslide-html-content" id="highslide-html" style="width: 400px">
				<div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
					<a href="#" onclick="return hs.close(this)" class="control">Close</a>
				</div>
				<div class="highslide-body"></div>
				</div><br/>
			]]></xsl:text>
			-->
			<!-- 
			<span class="tooltiptext">
				<a href="/mysare/help/editreport.htm#infoprod" target="_blank">
					<h3>Upload Files</h3>
				</a>
				<p>
					&#160;
				</p>
				<p>MySARE can display fact sheets, manuals, newsletters, journal articles, photos, audio and video. To use this feature, upload a description of your product and/or the resource in electronic format. Please use Acrobat (.PDF) or PowerPoint (.PPT) files for tables and figures so your data will retain its original format. Maximum upload file size is 240 megabytes. </p>
				<p>
					<b>Allowable File Types:</b> Documents(.doc,.docx,.pdf,.rtf)  Figures (ppsx,.ppt,.pptx) Tables (.xls,.xlsx), Images (.gif,.jpeg,.jpg,.png)  Video (.asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt) and audio (.au,.mp3)
				</p>
			</span>
			-->
			<br/>
		</xsl:otherwise>
	</xsl:choose>

	<xsl:if test="$message">
		<br/>
		<b>
			<i>
				<span style="color:#FF0000;">
					<xsl:value-of select="$message"/>
				</span>
			</i>
		</b>
	</xsl:if>
	<xsl:if test="$message2">
		<br/>
		<b>
			<span style="color:#008000;">
				<div>
					<i>
						<xsl:value-of select="$message2"/>
					</i>
				</div>
			</span>
		</b>
	</xsl:if>
	<p class="subtitle">
		<xsl:choose>
			<xsl:when test="$resourceID and $uploadID = '0'">
				<xsl:if test="$publicview != 'True'">
				<ul>
					<xsl:if test="$submitted = 'True'">
						<li>
							<button type="submit" align="center" disable="disable" name="updprodinfo" value="Save" onclick="alert('You cannot edit the information product or upload a file while the information product is pending approval.'); return false;">Upload File</button>&#160;You must save this form before you can upload a file.
						</li>
						</xsl:if>
						<xsl:if test="$submitted = 'False'">
							<li>
							<button type="submit" name="fileUp" id="fileUp" value="fileUp" onclick="javascript:openWindow('fileUpload.aspx?suid={$resourceID}&amp;order=999&amp;title={$prodTitle}','fileupload','600','300','scrollbars','resizable');">Upload File</button>&#160;&#160;Upload the information product file.&#160;&#160;
							<span class="tooltiptext">
								<a href="/mysare/help/editreport.htm#infoprod" target="_blank">
									<h3>Upload Files</h3>
								</a>
								<p>
									&#160;
								</p>
								<p>MySARE can display fact sheets, manuals, newsletters, journal articles, photos, audio and video. To use this feature, upload a description of your product and/or the resource in electronic format. Please use Acrobat (.PDF) or PowerPoint (.PPT) files for tables and figures so your data will retain its original format. Maximum upload size is 30 Mb for documents and 140 Mb for media files. <a href="http://bit.ly/1wsd7MG" target="_blank">Tips for reducing image and file size.</a></p>
								<p>
									<b>Allowable File Types:</b> Documents(.doc,.docx,.pdf,.rtf)  Figures (ppsx,.ppt,.pptx) Tables (.xls,.xlsx), Images (.gif,.jpeg,.jpg,.png)  Video (.asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt) and audio (.au,.mp3)
								</p>
							</span>
							</li>
						</xsl:if>	
						<xsl:if test="$submitted = 'False' and $approved = 'False'">
						<li>	
							<input name="submitprodinfo" type="submit" value="Submit for Approval"/>&#160;Submit the information product description for approval without uploading a file.
							Note: You cannot edit the information product or upload a file while it is pending approval. To edit before submitting, change the text below, then click "Save".
						</li>
						</xsl:if>
						<xsl:if test="$submitted = 'True' and /SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
							<li>
								<input name="approveprodinfo" type="submit" value="Approve"/>&#160;Approve the information product.
							</li>
							<li>
								<input type="hidden" id="oHidden" NAME="oHidden" value="{$prodTitle}"></input>
								<input name="notapproveprodinfo" type="submit" onclick="show_prompt()" value="Not Approve"/>&#160;Not Approve the information product.
							</li>
						</xsl:if>
					
				</ul>
				</xsl:if>
			</xsl:when>
			<xsl:when test="$uploadID != '0'">
				<xsl:if test="$publicview != 'True'">
					<ul>
						<xsl:if test="$submitted = 'False' and $approved = 'False'">
								<li><input name="submitprodinfo" type="submit" value="Submit for Approval"/>&#160;Submit the information product for approval.
								Note: You cannot edit the information product or upload a file while it is pending approval. To edit before submitting, change the text below, then click "Save".
								</li>
							</xsl:if>
							<xsl:if test="$submitted = 'True' and /SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
								<li>
									<input name="approveprodinfo" type="submit" value="Approve"/>&#160;Approve the information product.
								</li>
							</xsl:if>
					</ul>
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				Describe and upload fact sheets, manuals, newsletters, journal articles and video generated by your grant. Use the form below then click “Save.”
				<!-- 
				<ol>
					<li>Use the form below to provide a description and ordering information for the product, then click “Save.”</li>
					<li>If you have a digital file of the product (e.g. a PDF), upload it on the following page.</li>
					<li>Submit the product for approval and public posting.</li>
				</ol>
				-->
			</xsl:otherwise>
		</xsl:choose>		
	</p>	
</p>

	<xsl:variable name="authFName" select="/SAREroot/productInfoDetails/authoreditor"/>
	<xsl:variable name="authLName" select="/SAREroot/productInfoDetails/authoreditorLast"/>
	<xsl:variable name="authFName2" select="/SAREroot/productInfoDetails/author2"/>
	<xsl:variable name="authLName2" select="/SAREroot/productInfoDetails/author2Last"/>
	<xsl:variable name="authFName3" select="/SAREroot/productInfoDetails/author3"/>
	<xsl:variable name="authLName3" select="/SAREroot/productInfoDetails/author3Last"/>
	<xsl:variable name="authFName4" select="/SAREroot/productInfoDetails/author4"/>
	<xsl:variable name="authLName4" select="/SAREroot/productInfoDetails/author4Last"/>
	<xsl:variable name="authFName5" select="/SAREroot/productInfoDetails/author5"/>
	<xsl:variable name="authLName5" select="/SAREroot/productInfoDetails/author5Last"/>
	<xsl:variable name="website_url" select="/SAREroot/productInfoDetails/website_url"/>
	<xsl:variable name="website_pdf" select="/SAREroot/productInfoDetails/website_pdf"/>
	<xsl:variable name="orderFName" select="/SAREroot/productInfoDetails/orderfirst"/>
	<xsl:variable name="orderLName" select="/SAREroot/productInfoDetails/orderlast"/>
	<xsl:variable name="orderOrg" select="/SAREroot/productInfoDetails/orderorg"/>
	<xsl:variable name="orderAddress" select="/SAREroot/productInfoDetails/orderaddress"/>
	<xsl:variable name="orderCity" select="/SAREroot/productInfoDetails/ordercity"/>
	<xsl:variable name="orderState" select="/SAREroot/productInfoDetails/orderstate"/>
	<xsl:variable name="orderZip" select="/SAREroot/productInfoDetails/orderzip"/>
	<xsl:variable name="orderPhone" select="/SAREroot/productInfoDetails/orderphone"/>
	<xsl:variable name="orderFax" select="/SAREroot/productInfoDetails/orderfax"/>
	<xsl:variable name="orderEmail" select="/SAREroot/productInfoDetails/orderemail"/>
	<xsl:variable name="orderWebsite" select="/SAREroot/productInfoDetails/orderwebsite"/>
	<xsl:variable name="orderReleaseDate" select="/SAREroot/productInfoDetails/orderreleasedate"/>
	<xsl:variable name="orderproductID" select="/SAREroot/productInfoDetails/orderproductID"/>
	<xsl:variable name="orderComments" select="/SAREroot/productInfoDetails/ordercomments"/>
	<xsl:variable name="description" select="/SAREroot/productInfoDetails/description"/>
	<xsl:variable name="file_name" select="/SAREroot/productInfoDetails/file_name"/>
	<xsl:variable name="file_mimetype" select="/SAREroot/productInfoDetails/file_mimetype"/>
	<xsl:variable name="othertxt" select="/SAREroot/productInfoDetails/othertxt"/>
	<xsl:variable name="ordercost" select="/SAREroot/productInfoDetails/cost"/>
	<xsl:variable name="ordershipping" select="/SAREroot/productInfoDetails/shipping"/>

	<table>
		<xsl:if test="$publicview != 'True'">
			Fields with an asterisk (*) are required.<br/><br/>
		</xsl:if>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<b>1. Title:</b>&#160;&#160;
					</xsl:when>
					<xsl:otherwise>
						<b>1. *Title:</b>&#160;&#160;
					</xsl:otherwise>
				</xsl:choose>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:if test='string-length($prodTitle) &gt; 90'>
							<textarea id="desctxt" name="desctxt" rows="2" cols="90" readonly="readonly" style="overflow:hidden; border:none" wrap="virtual">
								<xsl:value-of select="$prodTitle"/>
							</textarea>
						</xsl:if>
						<xsl:if test='string-length($prodTitle) &lt; 90'>
							<input maxlength="255" size="90" name="titletxt" readonly="readonly" style="border:none" type="text" value="{$prodTitle}"/>
						</xsl:if>
					</xsl:when>
					<xsl:otherwise>
						<input maxlength="255" size="55" id="titletxt" name="titletxt" type="text" onKeyUp="chText('titletxt')" onKeyDown="chText('titletxt')" value="{$prodTitle}"/>
					</xsl:otherwise>
				</xsl:choose>
				
				<xsl:if test="$uploadID != '0'">
					<br/>
					<xsl:choose>
						<xsl:when test="$publicview">
							<b>Download Product :</b>&#160;&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<b>Uploaded File :</b>&#160;&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
					
					<!-- <a href="javascript:openWindow('fileUpload.aspx?suid={$resourceID}&amp;fileid={$uploadID}&amp;order=1','fileupload','640','480','scrollbars','resizable');"> -->
					
					<!-- 
					<a href="javascript:void(0);" onclick="window.open(unescape('./assocfiles/{$file_name}'),'fileupload','400','300','scrollbars','resizable');">					
						<xsl:value-of select="/SAREroot/productInfoDetails/file_caption" disable-output-escaping="yes"/>
					</a>
					-->

					<xsl:choose>
						<xsl:when test="$file_mimetype = 'audio/wav'">
							<a href="javascript:void(0);" onclick="window.open(unescape('http://media.ifas.ufl.edu/sare/{$file_name}'),'fileupload','400','300','scrollbars','resizable');">
								<xsl:value-of select="/SAREroot/productInfoDetails/file_caption" disable-output-escaping="yes"/>
							</a>
						</xsl:when>
						<xsl:when test="$file_mimetype = 'video/x-ms-asf' or $file_mimetype = 'video/x-msvideo' or $file_mimetype = 'video/quicktime' or $file_mimetype = 'video/mp4' or $file_mimetype = 'video/mpeg' or $file_mimetype = 'video/quicktime'">
							<a href="javascript:openWindow(unescape('http://ifasgallery.ifas.ufl.edu/sare/{$file_name}'),'fileupload','400','300','scrollbars','resizable');">
								<xsl:value-of select="position()"/>: <xsl:value-of select="SAREroot/productInfoDetails/file_caption"/>&#160;&#160;<xsl:value-of select="name/@original" disable-output-escaping="yes"/>
							</a>
						</xsl:when>
						<xsl:otherwise>
							<a href="javascript:openWindow(unescape('./assocfiles/{$file_name}'),'fileupload','400','300','scrollbars','resizable');">
								<xsl:value-of select="/SAREroot/productInfoDetails/file_caption" disable-output-escaping="yes"/>
							</a>
						</xsl:otherwise>
					</xsl:choose>
					
					&#160;(<xsl:value-of select="SAREroot/productInfoDetails/file_name_orig" disable-output-escaping="yes"/>)
					<xsl:if test="$publicview != 'True' and $submitted = 'True' and /SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
						<a href="javascript:openWindow('fileUpload.aspx?suid={$resourceID}&amp;fileid={$uploadID}&amp;order=999','fileupload','640','480','scrollbars','resizable');">
							&#160;&#160;Delete File
						</a>
					</xsl:if>
					<xsl:if test="$publicview != 'True' and $submitted = 'False'">
						<a href="javascript:openWindow('fileUpload.aspx?suid={$resourceID}&amp;fileid={$uploadID}&amp;order=999','fileupload','640','480','scrollbars','resizable');">
							&#160;&#160;Delete File
						</a>
					</xsl:if>
				</xsl:if>
			</td>
		</tr>
		<tr>
			<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<b>2. Description:</b>
					</xsl:when>
					<xsl:otherwise>
						<b>2. *Description:</b> (500 character limit)
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:if test='string-length($description) &gt; 90'>
							<textarea id="desctxt" name="desctxt" rows="2" cols="90" readonly="readonly" style="overflow:hidden; border:none" wrap="virtual">
								<xsl:value-of select="$description"/>
							</textarea>
						</xsl:if>
						<xsl:if test='string-length($description) &lt; 90'>
							<input maxlength="500" size="90" style="border:none" name="desctxt" readonly="readonly" type="text" value="{$description}"/>
						</xsl:if>
					</xsl:when>
					<xsl:otherwise>
						<input maxlength="500" size="75" id="desctxt" name="desctxt" type="text" onKeyUp="chText('desctxt')" onKeyDown="chText('desctxt')" value="{$description}"/>
					</xsl:otherwise>
				</xsl:choose>				
			</td>
		</tr>
		<tr><td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td></tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<b>3. Format of publication or information product:</b>
					</xsl:when>
					<xsl:otherwise>
						<b>3. *Format of publication or information product (check only one) :</b>
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/book = 'True'">
								<input name="Book" type="radio" style="border:none" disabled="disabled" checked="yes"/>Book&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Book" disabled="disabled" style="border:none" type="radio"/>Book&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/video = 'True'">
								<input name="Video" type="radio" style="border:none" disabled="disabled" checked="yes"/>Video&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Video" disabled="disabled" style="border:none" type="radio"/>Video&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/extensionpub = 'True'">
								<input name="extPub" type="radio" style="border:none" disabled="disabled" checked="yes"/>Extension Pub&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="extPub" disabled="disabled" style="border:none" type="radio"/>Extension Pub&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/handbook = 'True'">
								<input name="HandBook" type="radio" style="border:none" disabled="disabled" checked="yes"/>Hand Book&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="HandBook" disabled="disabled" style="border:none" type="radio"/>Hand Book&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
            <fieldset>
              <legend></legend> 
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/book = 'True'">
								<input name="format" id="Book" value="Book" type="radio" checked="checked"/>Book&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="Book" value="Book" type="radio"/>Book&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/video = 'True'">
								<input name="format" id="Video" value="Video" type="radio" checked="checked"/>Video&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="Video" value="Video" type="radio"/>Video&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/extensionpub = 'True'">
								<input name="format" id="extPub" value="extPub" type="radio" checked="checked"/>Extension Pub&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="extPub" value="extPub" type="radio"/>Extension Pub&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/handbook = 'True'">
								<input name="format" id="HandBook" value="HandBook" type="radio" checked="checked"/>Hand Book&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="HandBook" value="HandBook" type="radio"/>Hand Book&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
            </fieldset>
					</xsl:otherwise>
				</xsl:choose>				
			</td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/factsheet = 'True'">
								<input name="factSheet" type="radio" disabled="disabled" checked="yes"/>Fact Sheet&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="factSheet" disabled="disabled" type="radio"/>Fact Sheet&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/software = 'True'">
								<input name="software" type="radio" disabled="disabled" checked="yes"/>Software&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="software" disabled="disabled" type="radio"/>Software&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/workbook = 'True'">
								<input name="WorkBook" type="radio" disabled="disabled" checked="yes"/>Work Book&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="WorkBook" disabled="disabled" type="radio"/>Work Book&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/manual = 'True'">
								<input name="manual" type="radio" disabled="disabled" checked="yes"/>Manual&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="manual" disabled="disabled" type="radio"/>Manual&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
            <fieldset>
              <legend></legend>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/factsheet = 'True'">
								<input name="format" id="factSheet" value="factSheet" type="radio" checked="checked"/>Fact Sheet&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="factSheet" value="factSheet" type="radio"/>Fact Sheet&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/software = 'True'">
								<input name="format" id="software" value="software" type="radio" checked="checked"/>Software&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="software" value="software" type="radio"/>Software&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/workbook = 'True'">
								<input name="format" id="WorkBook" value="WorkBook" type="radio" checked="checked"/>Work Book&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="WorkBook" value="WorkBook" type="radio"/>Work Book&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/manual = 'True'">
								<input name="format" id="manual" value="manual" type="radio" checked="checked"/>Manual&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="format" id="manual" value="manual" type="radio"/>Manual&#160;&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
            </fieldset>
					</xsl:otherwise>
				</xsl:choose>						
			</td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/website = 'True'">
								<input name="Websitecheck" type="radio" disabled="disabled" checked="yes"/>Website&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Websitecheck" disabled="disabled" type="radio"/>Website&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/cdrom = 'True'">
								<input name="CD-ROM" type="radio" rdisabled="disabled" checked="yes"/>CD-ROM&#160;&#160;&#160;&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="CD-ROM" disabled="disabled" type="radio"/>CD-ROM&#160;&#160;&#160;&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/newsletter = 'True'">
								<input name="Newsletter&#160;&#160;" type="radio" disabled="disabled" checked="yes"/>Newsletter&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Newsletter" disabled="disabled" type="radio"/>Newsletter&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/article = 'True'">
								<input name="Journal" type="radio" disabled="disabled" checked="yes"/>Journal Article&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Journal" disabled="disabled" type="radio"/>Journal Article&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
            <fieldset>
              <legend></legend>
              <xsl:choose>
                <xsl:when test="/SAREroot/productInfoDetails/website = 'True'">
                  <input name="format" id="Websitecheck" value="Websitecheck" type="radio" checked="checked"/>Website&#160;&#160;
                </xsl:when>
                <xsl:otherwise>
                  <input name="format" id="Websitecheck" value="Websitecheck" type="radio"/>Website&#160;&#160;
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test="/SAREroot/productInfoDetails/cdrom = 'True'">
                  <input name="format" id="CD-ROM" value="CD-ROM" type="radio" checked="checked"/>CD-ROM&#160;&#160;&#160;&#160;&#160;
                </xsl:when>
                <xsl:otherwise>
                  <input name="format" id="CD-ROM" value="CD-ROM" type="radio"/>CD-ROM&#160;&#160;&#160;&#160;&#160;
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test="/SAREroot/productInfoDetails/newsletter = 'True'">
                  <input name="format" id="Newsletter" value="Newsletter" type="radio" checked="checked"/>Newsletter&#160;&#160;
                </xsl:when>
                <xsl:otherwise>
                  <input name="format" id="Newsletter" value="Newsletter" type="radio"/>Newsletter&#160;&#160;
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
                <xsl:when test="/SAREroot/productInfoDetails/article = 'True'">
                  <input name="format" id="Journal" value="Journal" type="radio" checked="checked"/>Journal Article&#160;&#160;
                </xsl:when>
                <xsl:otherwise>
                  <input name="format" id="Journal" value="Journal" type="radio"/>Journal Article&#160;&#160;
                </xsl:otherwise>
              </xsl:choose>
            </fieldset>
					</xsl:otherwise>
				</xsl:choose>				
			</td>
		</tr>		
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/other = 'True'or $othertxt != ''">
								<input name="Other" disabled="disabled" type="radio" checked="yes"/>Other&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Other" disabled="disabled" type="radio"/>Other&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<input maxlength="255" size="25" style="border:none" readonly="readonly" value="{$othertxt}" name="othertxt" type="text"/>
					</xsl:when>
					<xsl:otherwise>
            <fieldset>
              <legend></legend>
              <xsl:choose>
                <xsl:when test="/SAREroot/productInfoDetails/other = 'True'">
                  <input name="format" id="Other" value="Other" type="radio" checked="checked"/>Other&#160;&#160;
                </xsl:when>
                <xsl:otherwise>
                  <input name="format" id="Other" value="Other" type="radio"/>Other&#160;&#160;
                </xsl:otherwise>
              </xsl:choose>
              <input maxlength="255" size="25" value="{$othertxt}" name="othertxt" type="text"/>
            </fieldset>
					</xsl:otherwise>
				</xsl:choose>				
			</td>			
		</tr>
		<tr><td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td></tr>
		<tr>
			<td><b>4. How would you characterize the technical level of this publication? (check all that apply) :</b></td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/beginner = 'True'">
								<input name="beg" type="checkbox" disabled="disabled" checked="yes"/>Beginner&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="beg" disabled="disabled" type="checkbox"/>Beginner&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/intermediate = 'True'">
								<input name="int" type="checkbox" disabled="disabled" checked="yes"/>Intermediate&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="int" disabled="disabled" type="checkbox"/>Intermediate&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/advanced = 'True'">
								<input name="Adv" type="checkbox" disabled="disabled" checked="yes"/>Advanced&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Adv" disabled="disabled" type="checkbox"/>Advanced&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/beginner = 'True'">
								<input name="beg" type="checkbox" checked="yes"/>Beginner&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="beg" type="checkbox"/>Beginner&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/intermediate = 'True'">
								<input name="int" type="checkbox" checked="yes"/>Intermediate&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="int" type="checkbox"/>Intermediate&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/advanced = 'True'">
								<input name="Adv" type="checkbox" checked="yes"/>Advanced&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="Adv" type="checkbox"/>Advanced&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:otherwise>
				</xsl:choose>				
			</td>
		</tr>
		<tr>
			<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>
		</tr>
		<tr>
			<td><b>5. Who is the target audience? (check all that apply) :</b></td>
		</tr>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="$publicview">
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/farmers = 'True'">
								<input name="farmers" type="checkbox" disabled="disabled" checked="yes"/>Farmers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="farmers" disabled="disabled" type="checkbox"/>Farmers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/educators = 'True'">
								<input name="edu" type="checkbox" disabled="disabled" checked="yes"/>Educators&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="edu" disabled="disabled" type="checkbox"/>Educators&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/researchers = 'True'">
								<input name="res" type="checkbox" disabled="disabled" checked="yes"/>Researchers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="res" disabled="disabled" type="checkbox"/>Researchers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/consumers = 'True'">
								<input name="consumers" type="checkbox" disabled="disabled" checked="yes"/>Consumers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="consumers" disabled="disabled" type="checkbox"/>Consumers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/farmers = 'True'">
								<input name="farmers" type="checkbox" checked="yes"/>Farmers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="farmers" type="checkbox"/>Farmers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/educators = 'True'">
								<input name="edu" type="checkbox" checked="yes"/>Educators&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="edu" type="checkbox"/>Educators&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/researchers = 'True'">
								<input name="res" type="checkbox" checked="yes"/>Researchers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="res" type="checkbox"/>Researchers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="/SAREroot/productInfoDetails/consumers = 'True'">
								<input name="consumers" type="checkbox" checked="yes"/>Consumers&#160;&#160;
							</xsl:when>
							<xsl:otherwise>
								<input name="consumers" type="checkbox"/>Consumers&#160;&#160;
							</xsl:otherwise>
						</xsl:choose>
					</xsl:otherwise>
				</xsl:choose>			
					
			</td>
		</tr>
		<tr>
			<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>
		</tr>
		<tr>
			<td>
				<b>6. Authors</b>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$publicview = 'True'">
					&#160;&#160;&#160;&#160;1) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName}" style="border:none" readonly="readonly" name="firstxt1" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName}" style="border:none" readonly="readonly" name="lasttxt1" type="text"/>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					&#160;&#160;&#160;&#160;1) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName}" name="firstxt1" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName}" name="lasttxt1" type="text"/>
				</xsl:if>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$publicview = 'True'">
					&#160;&#160;&#160;&#160;2) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName2}" style="border:none" readonly="readonly" name="firstxt2" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName2}" style="border:none" readonly="readonly"  name="lasttxt2" type="text"/>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					&#160;&#160;&#160;&#160;2) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName2}" name="firstxt2" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName2}" name="lasttxt2" type="text"/>
				</xsl:if>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$publicview = 'True'">
					&#160;&#160;&#160;&#160;3) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName3}" style="border:none" readonly="readonly" name="firstxt3" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName3}" style="border:none" readonly="readonly" name="lasttxt3" type="text"/>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					&#160;&#160;&#160;&#160;3) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName3}" name="firstxt3" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName3}" name="lasttxt3" type="text"/>
				</xsl:if>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$publicview = 'True'">
					&#160;&#160;&#160;&#160;4) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName4}" name="firstxt4" style="border:none" readonly="readonly" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName4}" style="border:none" readonly="readonly" name="lasttxt4" type="text"/>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					&#160;&#160;&#160;&#160;4) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName4}" name="firstxt4" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName4}" name="lasttxt4" type="text"/>
				</xsl:if>
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$publicview = 'True'">
					&#160;&#160;&#160;&#160;5) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName5}" name="firstxt5" style="border:none" readonly="readonly" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName5}" style="border:none" readonly="readonly" name="lasttxt5" type="text"/>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					&#160;&#160;&#160;&#160;5) Author First:&#160;&#160;<input maxlength="255" size="25" value="{$authFName5}" name="firstxt5" type="text"/>&#160;&#160;Last:&#160;&#160;<input maxlength="255" size="25" value="{$authLName5}" name="lasttxt5" type="text"/>
				</xsl:if>					
			</td>
		</tr>
			<tr>
				<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>
			</tr>
			<tr>
				<td>
					<b>7. Online Access (Links in this section may lead to non-SARE sites. SARE cannot be responsible for offsite content.)</b><br/>
					<xsl:if test="$publicview != 'True'">
						You must include <i>http://</i> for the website to display; for example: <I>http://www.sare.org/</I>. Click on the “Check Address” button to verify the address is entered correctly.
					</xsl:if>
			</td>
			</tr>
			<tr>
				<td>
					Website   :&#160;&#160;
					<xsl:if test="$publicview != 'True'">
						<input maxlength="255" size="50" value="{$website_url}" name="url" type="text"/>
					</xsl:if>
					<xsl:if test="$publicview = 'True'">
						<a href="javascript:void(0);" onclick="javascript:window.open('{$website_url}');">
							<xsl:value-of select="$website_url"/>
						</a>
					</xsl:if>
					&#160;&#160;
					<xsl:if test="$publicview != 'True'">
						<INPUT type="button" value="Check Address" onclick="javascript:window.open(document.infoproduct.url.value);" id="siteTest1" name="siteTest1"/>
					</xsl:if>
				</td>
			</tr>
			<tr>
				<td>
					Website (PDF)  :&#160;&#160;
					<xsl:if test="$publicview != 'True'">
						<input maxlength="255" size="50" value="{$website_pdf}" name="pdf" type="text"/>
					</xsl:if>
					<xsl:if test="$publicview = 'True'">
						<a href="javascript:void(0);" onclick="javascript:window.open('{$website_pdf}');">
							<xsl:value-of select="$website_pdf"/>
						</a>
					</xsl:if>
					&#160;&#160;
					<xsl:if test="$publicview != 'True'">
						<INPUT type="button" value="Check Address" onclick="javascript:window.open(document.infoproduct.pdf.value);" id="siteTest2" name="siteTest2"/>
					</xsl:if>
				</td>
			</tr>
		<tr>
			<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>
		</tr>
		<tr>
			<td><b>8. Ordering Information :</b></td>
		</tr>
		<xsl:choose>
			<xsl:when test="$publicview">
				<tr><td>Contact : First Name :&#160;&#160;<input maxlength="255" size="25" value="{$orderFName}" name="contfirstxt" type="text" style="border:none" readonly="readonly"/>&#160;&#160;Last Name:&#160;&#160;<input maxlength="255" size="25" value="{$orderLName}" name="contlasttxt" type="text" style="border:none" readonly="readonly"/></td></tr>
				<tr><td>Organization	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderOrg}" style="border:none" readonly="readonly" name="org" type="text"/>&#160;&#160;</td></tr>
				<tr><td>Address     	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderAddress}" name="address" style="border:none" readonly="readonly" type="text"/>&#160;&#160;</td></tr>
				<tr><td>City			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderCity}" name="city" style="border:none" readonly="readonly" type="text"/>&#160;&#160;State :&#160;<input maxlength="2" size="5" value="{$orderState}" style="border:none" readonly="readonly" name="state" type="text"/>&#160;Zip Code :&#160;<input maxlength="5" size="5" style="border:none" readonly="readonly" value ="{$orderZip}" name="zip" type="text"/></td></tr>
				<tr><td>Phone			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderPhone}" name="phone" style="border:none" readonly="readonly" type="text"/>&#160;&#160;Phone Ext:&#160;<input maxlength="255" size="25" name="phExt" style="border:none" readonly="readonly" type="text"/>&#160;Fax :&#160;<input maxlength="255" size="25" value="{$orderFax}" name="fax" style="border:none" readonly="readonly" type="text"/></td></tr>
				<tr><td>Email			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderEmail}" name="email" style="border:none" readonly="readonly" type="text"/>&#160;&#160;Website:&#160;<input maxlength="255" size="25" value="{$orderWebsite}" style="border:none" readonly="readonly" name="website" type="text"/></td></tr>
				<tr><td>Publication/Product ID (if applicable) :&#160;&#160;<input maxlength="255" size="25" style="border:none" readonly="readonly" value ="{$orderproductID}" name="productID" type="text"/>&#160;&#160;Release date:&#160;<input maxlength="255" size="25" value="{$orderReleaseDate}" name="releaseDate" style="border:none" readonly="readonly" type="text"/>&#160;
					<br/>
					<xsl:choose>
						<xsl:when test="/SAREroot/productInfoDetails/avalqty = 'True'">
							<input name="qty" type="checkbox" disabled="disabled" checked="yes"/>Check here if available in bulk qty.
						</xsl:when>
						<xsl:otherwise>
							<input name="qty" disabled="disabled" type="checkbox"/>Check here if available in bulk qty.
						</xsl:otherwise>
					</xsl:choose>
				</td>
				</tr>
				<tr><td>Cost			     :&#160;&#160;<input maxlength="255" value="{$ordercost}" size="25" name="cost" style="border:none" readonly="readonly" type="text" onblur="check(this)" />&#160;&#160;Shipping/Handling:&#160;<input maxlength="255" size="25" value="{$ordershipping}" name="shipping" style="border:none" readonly="readonly" type="text" onblur="check(this)"/>
			</td>
		</tr>
		<tr>
			<td>Order comments	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderComments}" style="border:none" readonly="readonly" name="comments" type="text"/></td></tr>			
			</xsl:when>
			<xsl:otherwise>
				<tr><td>Contact : First Name :&#160;&#160;<input maxlength="255" size="25" value="{$orderFName}" name="contfirstxt" type="text"/>&#160;&#160;Last Name:&#160;&#160;<input maxlength="255" size="25" value="{$orderLName}" name="contlasttxt" type="text"/></td></tr>
				<tr><td>Organization	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderOrg}" name="org" type="text"/>&#160;&#160;</td></tr>
				<tr><td>Address     	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderAddress}" name="address" type="text"/>&#160;&#160;</td></tr>
				<tr><td>City			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderCity}" name="city" type="text"/>&#160;&#160;State :&#160;<input maxlength="2" size="5" value="{$orderState}" name="state" type="text"/>&#160;Zip Code :&#160;<input maxlength="5" size="5" value ="{$orderZip}" name="zip" type="text"/></td></tr>
				<tr><td>Phone			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderPhone}" name="phone" type="text"/>&#160;&#160;Phone Ext:&#160;<input maxlength="255" size="25" name="phExt" type="text"/>&#160;Fax :&#160;<input maxlength="255" size="25" value="{$orderFax}" name="fax" type="text"/></td></tr>
				<tr><td>Email			     :&#160;&#160;<input maxlength="255" size="25" value="{$orderEmail}" name="email" type="text"/>&#160;&#160;Website:&#160;<input maxlength="255" size="25" value="{$orderWebsite}" name="website" type="text"/></td></tr>
				<tr><td>Publication/Product ID (if applicable) :&#160;&#160;<input maxlength="255" size="25" value ="{$orderproductID}" name="productID" type="text"/>&#160;&#160;Release date:&#160;<input maxlength="255" size="25" value="{$orderReleaseDate}" name="releaseDate" type="text"/>&#160;
					<br/>
					<xsl:choose>
						<xsl:when test="/SAREroot/productInfoDetails/avalqty = 'True'">
							<input name="qty" type="checkbox" checked="yes"/>Check here if available in bulk qty.
						</xsl:when>
						<xsl:otherwise>
							<input name="qty" type="checkbox"/>Check here if available in bulk qty.
						</xsl:otherwise>
					</xsl:choose>
				</td>
				</tr>
				<tr><td>Cost			     :&#160;&#160;<input maxlength="255" value="{$ordercost}" size="25" name="cost" type="text" onblur="check(this)" />&#160;&#160;Shipping/Handling:&#160;<input maxlength="255" size="25" value="{$ordershipping}" name="shipping" type="text" onblur="check(this)"/></td></tr>
				<tr><td>Order comments	     :&#160;&#160;<input maxlength="255" size="25" value="{$orderComments}" name="comments" type="text"/></td></tr>			
			</xsl:otherwise>
		</xsl:choose>		
		<tr>
			<td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</td>			
		</tr>
		<tr>
			<td>
			<p>
				<small>This project and all associated information products were supported by the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.</small>
			</p>
			</td>
		</tr>
		<xsl:choose>
			<xsl:when test="$resourceID">
				<xsl:if test="$publicview != 'True'">
					<tr>
						<td>
							<!-- <b>9. Upload Resource to MySARE :</b> -->
							<!-- <input name="updprodinfo" type="submit" value="Save"/>&#160;You must save this form before you can upload a file. -->
							<xsl:if test="$submitted = 'True'">
								<button type="submit" align="center" disable="disable" name="updprodinfo" value="Save" onclick="alert('You cannot edit the information product or upload a file while the information product is pending approval.'); return false;">Save</button>&#160;You must save this form before you can upload a file.
							</xsl:if>
							<xsl:if test="$submitted = 'False'">
								<button type="submit" align="center" name="updprodinfo" value="Save">Save</button>&#160;You must save this form before you can upload a file.
							</xsl:if>
							
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin' or @code='PI']">
					<tr>
						<td>
							<input name="deleteprodinfo" type="submit" value="Delete"/>&#160;To delete an information product, check “Confirm Delete”, then click “Delete.”&#160;<input name="ConfirmDelete" type="checkbox" value="true"/>Confirm Delete
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="$publicview != 'True'">
					<tr>
						<td>
							<!-- 
							Upload electronic versions of books, factsheets, or other information projects produced as part of your SARE grant. Uploaded resources will be made available to the public as part of your final report.
							<xsl:text disable-output-escaping="yes">
						<![CDATA[
										<a href="help/editreport.htm#upload" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>
										<div class="highslide-html-content" id="highslide-html" style="width: 300px">
   										  <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
											<a href="#" onclick="return hs.close(this)" class="control">Close</a>
  										  </div>
										<div class="highslide-body"></div>
										</div>
						]]>
					</xsl:text> -->
							<xsl:choose>
								<xsl:when test="$granttype = 'pdp'">
									<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$proj_num}'"/>&#160;Return to PDP Overview page.{$granttype}
                </xsl:when>
								<xsl:otherwise>
									<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editProj&amp;pn={$proj_num}'"/>&#160;Return to Project Overview page.
								</xsl:otherwise>
							</xsl:choose>							
						</td>
					</tr>
				</xsl:if>
			</xsl:when>				
				<xsl:otherwise>
				<tr>
					<td>
						<input name="saveprodinfo" type="submit" value="Save"/>&#160;You must save this form before you can upload a file.
					</td>
				</tr>
				<tr>
					<td>
						<xsl:choose>
							<xsl:when test="$granttype = 'pdp'">
                <xsl:choose>
                <xsl:when test="$proj_num !=''">
								  <INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$proj_num}'"/>&#160;Return to PDP Overview page.
                </xsl:when>
                  <xsl:otherwise>
                  <INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="history.go(-1)"/>&#160;Return to PDP Overview page.
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:when>
							<xsl:otherwise>
                <xsl:choose>
                  <xsl:when test="$proj_num !=''">
								    <INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editProj&amp;pn={$proj_num}'"/>&#160;Return to Project Overview page.
                  </xsl:when>
                  <xsl:otherwise>
                    <INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="history.go(-1)"/>&#160;Return to Project Overview page.
                  </xsl:otherwise>
                </xsl:choose>
							</xsl:otherwise>
						</xsl:choose>
					</td>
				</tr>
					<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin' or @code='PI']">
						<tr>
							<td>
								<input name="deleteprodinfo" type="submit" value="Delete"/>&#160;Delete information product.
							</td>
						</tr>
					</xsl:if>
			</xsl:otherwise>
		</xsl:choose>		
    
    </table>
  </form>
 
</xsl:template>

</xsl:stylesheet>


