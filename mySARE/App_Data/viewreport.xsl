<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  version="1.0"
>
<xsl:param name="context">view</xsl:param>
<xsl:output method="html" encoding="UTF-8"/>

<xsl:param name="mytitle"/>

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

function show_prompt()
{
       var inputVal = prompt('Please enter your reason for not approving report:');
       document.getElementById('oHidden').value = inputVal;

}


]]>
</script>

<xsl:apply-templates select="SAREroot/SAREgrant"/>

</xsl:template>

<xsl:template match="SAREgrant">
	<div id="printDiv">
<form id="viewReportsForm" name="viewReports" method="post">
		<xsl:for-each select="report">
			<xsl:sort select="@type" order="ascending"/>
			<xsl:call-template name="report"/>
		</xsl:for-each>
	</form>
	<small>This project and all associated reports and support materials were supported by the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.</small>
	</div>
</xsl:template>


	
<xsl:template name="report">
<table CELLSPACING="0" CELLPADDING="6" CLASS="NORM">

<tr>
<td VALIGN="TOP" WIDTH="75%">
<p class="pagetitle"><xsl:value-of select="../title"/></p>
</td>
</tr>
<tr>
<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin' or @code='projPI']">
	<xsl:choose>
		<xsl:when test="@type = 2">
			<td VALIGN="TOP" WIDTH="75%">
				<xsl:if test="/SAREroot/SAREgrant/report[@submittedstatus='False']">
					<span class="evDate">
						After previewing your project report, click "Edit this Report" to make further changes, or click “Project Overview” to return to the Project Overview Page and submit the report for approval.
					</span>
					<xsl:choose>
						<xsl:when test="$context=editing">
							<input name="Back To Editing" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Back To Editing"/>&#160;&#160;&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<input name="Edit This Report" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Edit This Report"/>&#160;&#160;&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
					<input name="Project Overview" onclick ="window.location.href='sare_main.aspx?do=editProj&amp;pn={../@projNum}'" type="button" value="Project Overview"/>
				</xsl:if>
				<xsl:if test="/SAREroot/SAREgrant/report[@submittedstatus='True'] and (/SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin'])">
					<span class="evDate">
						After previewing your project report, click "Edit this Report" to make further changes, or click “Project Overview” to return to the Project Overview Page to approve or not approve report.
					</span>
					<xsl:choose>
						<xsl:when test="$context=editing">
							<input name="Back To Editing" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Back To Editing"/>&#160;&#160;&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<input name="Edit This Report" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Edit This Report"/>&#160;&#160;&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
					<input name="Project Overview" onclick ="window.location.href='sare_main.aspx?do=editProj&amp;pn={../@projNum}'" type="button" value="Project Overview"/>
				</xsl:if>
			</td>
			</xsl:when>

		<xsl:otherwise>
			<td VALIGN="TOP" WIDTH="75%">
				<xsl:if test="/SAREroot/SAREgrant/report[@submittedstatus='False']">
				<span class="evDate">
					After previewing your project report, click Edit this Report to make further changes, or click “Submit” to submit the report for approval.
				</span>
				<xsl:choose>
					<xsl:when test="$context=editing">
						<input name="Back To Editing" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Back To Editing"/>&#160;&#160;&#160;&#160;
					</xsl:when>
					<xsl:otherwise>						
						<input name="Edit This Report" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Edit This Report"/>&#160;&#160;&#160;&#160;
					</xsl:otherwise>
				</xsl:choose>
				<xsl:choose>
					<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin']">
						&#160;
					</xsl:when>
					<xsl:otherwise>
						<!-- <input name="Submit" onclick ="window.location.href='sare_main.aspx?do=editProj&amp;pn={../@projNum}'" type="button" value="Submit"/> -->
						<button type="submit" align="center" name="btnSubmit" value="Submit">Submit</button>
					</xsl:otherwise>
				</xsl:choose>
			   </xsl:if>

				<xsl:if test="/SAREroot/SAREgrant/report[@submittedstatus='True'] and (/SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin'])">
					<span class="evDate">
						After previewing your project report, click Edit this Report to make further changes, or click “Approve” or "Not Approve" to approval report or not.
					</span>
					<xsl:choose>
						<xsl:when test="$context=editing">
							<input name="Back To Editing" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Back To Editing"/>&#160;&#160;&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<input name="Edit This Report" onclick ="window.location.href='sare_main.aspx?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}'" type="button" value="Edit This Report"/>&#160;&#160;&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>					
				</xsl:if>
			</td>			
		</xsl:otherwise>
	</xsl:choose>
	
</xsl:if>

</tr>
<tr>
<td VALIGN="TOP" WIDTH="75%">
	 <xsl:apply-templates select="section">
        <xsl:sort select="@order" data-type="number" order="ascending"/>
      </xsl:apply-templates>
	<br/>
	<br/>
	<xsl:if test="/SAREroot/productInfo/resource">
		<b>Information Product(s):</b>
		<br/>
		<xsl:for-each select="/SAREroot/productInfo/resource">
			<a href="?do=infoproddetail&amp;type=grant&amp;pn={../@projNum}&amp;resourceID={@resourceID}&amp;uploadID={uploadID}">
				<xsl:value-of select="title"/>
				<br/>
			</a>
		</xsl:for-each>
	</xsl:if>
	<br/>
		<input type="hidden" id="oHidden" NAME="oHidden" value="{../title}"></input>
		<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin'] and not(@type=2)">
			<button type="submit" align="center" name="btnProjectDetailsApprove" value="Submit">Approve</button>&#160;&#160;&#160;&#160;&#160;
			
			<button type="submit" align="center" name="btnProjectDetailsNotApprove" value="Submit" onclick="show_prompt()">Not Approve</button>
		</xsl:if>

</td>

<td VALIGN="TOP" WIDTH="25%">
	<button type="submit" align="center" name="btnPDF" value="Submit">Create PDF</button>
	<br/>
	<br/>
	<xsl:choose>
		<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin' or @code='projPI']">
			<a href="sare_main.aspx?do=editProj&amp;pn={../@projNum}">Project Content Page</a>
		</xsl:when>
		<xsl:otherwise>
			<a href="ProjectReport.aspx?do=viewProj&amp;pn={../@projNum}">Project Content Page</a>
		</xsl:otherwise>
	</xsl:choose>
	<h3 CLASS="TITLE">
<xsl:value-of select="@year"/>
<xsl:if test="@type=0">
Annual Report
</xsl:if>
<xsl:if test="@type=1">
Final Report
</xsl:if>
<xsl:if test="@type=2">
Proposal
</xsl:if>
</h3>
<b CLASS="TITLE">Project Number: </b><xsl:value-of select="../@projNum"/>
<br/>
<b CLASS="TITLE">Type: </b><xsl:value-of select="../@typeText"/>
<br/>
<b CLASS="TITLE">Region: </b><xsl:value-of select="../@regionText"/>
<br/>
<xsl:if test="../funds/SARE &gt; 0">
<b CLASS="TITLE">SARE Grant: </b>$<xsl:value-of select="format-number(../funds/SARE, '###,###,###')"/>
<br/>
</xsl:if>
<!-- 
<xsl:if test="../funds/Fed &gt; 0">
<b CLASS="TITLE">Federal Matching Funds: </b>$<xsl:value-of select="format-number(../funds/Fed, '###,###,###')"/>
<br/>
</xsl:if>
<xsl:if test="../funds/NonFed &gt; 0">
<b CLASS="TITLE">Non-Federal Matching Funds: </b>$<xsl:value-of select="format-number(../funds/NonFed, '###,###,###')"/>
<br/>
</xsl:if>
-->
<br/>
<xsl:if test="/*/user[@context='projectpis'] or /*/nonusercontact[@context='projectpis']">
	<b CLASS="TITLE">Coordinator<xsl:if test="count(/*/user[@context='projectpis']) &gt; 1">s</xsl:if>: </b><br/>
</xsl:if>
<xsl:for-each select="/*/user[@context='projectpis']">
	<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/>
		<br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/>
		<br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">
			,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>,
		<xsl:if test="contact/addrState != ''"><xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}"><xsl:value-of select="contact/email"/></a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}"><xsl:value-of select="contact/website"/></a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>
	
<!-- This is added to have project coordinators -->

<xsl:for-each select="/*/nonusercontact[@context='projectpis']">
	<br/>
	<xsl:if test="firstname != ''">
		<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	</xsl:if>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/><br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/><br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">
			,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>	
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>,
		<xsl:if test="contact/addrState != ''"><xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>		
	</xsl:if>	
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}">
			<xsl:value-of select="contact/email"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}">
			<xsl:value-of select="contact/website"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>
	
<xsl:if test="/*/nonusercontact[@context='projectparticipants']">
	<br/><b CLASS="TITLE">Participant<xsl:if test="count(/*/nonusercontact[@context='projectparticipants']) &gt; 1">s</xsl:if>: </b><br/>
</xsl:if>
<xsl:for-each select="/*/nonusercontact[@context='projectparticipants']">
	<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/>
		<br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/>
		<br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">
			,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>
		<xsl:if test="contact/addrState != ''">
			,&#160;<xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}"><xsl:value-of select="contact/email"/></a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}"><xsl:value-of select="contact/website"/></a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>


<xsl:if test="@startdate &gt; 0">
<b CLASS="TITLE">Reporting Period: </b>
        <xsl:value-of select="@startdate"/>&#160;-&#160;
        <xsl:value-of select="@enddate"/>
<br/>
</xsl:if>
</td>
</tr>
</table>
</xsl:template>

<xsl:template match="section">
  <xsl:if test="subsection/text != ''">
    <h3><xsl:value-of select="name"/></h3>
      <xsl:apply-templates select="subsection">
        <xsl:sort select="@order" data-type="number" order="ascending"/>
      </xsl:apply-templates>
  </xsl:if>
</xsl:template>

<xsl:template match="subsection">
  <xsl:if test="text!=''">
    <h3><xsl:value-of select="heading"/></h3>
  <xsl:choose>
  <xsl:when test="@type='0' or @type='3' or @type='4'">
	  <!-- 
    <xsl:call-template name="splitByLine">
      <xsl:with-param name="str" select="text"/>
      <xsl:with-param name="type" select="@type"/>
    </xsl:call-template> 
	  <xsl:apply-templates select="text"/>-->
	  <xsl:apply-templates select="text">
		  <xsl:with-param name="textType" select="@type"/>
		  <!-- pass param "title" to matching templates -->
	  </xsl:apply-templates>
	  
  </xsl:when>
	  <!-- 
  <xsl:when test="@type='3' or @type='4'">
	   <xsl:call-template name="splitByLine">
      <xsl:with-param name="str" select="text"/>
      <xsl:with-param name="type" select="@type"/>
    </xsl:call-template>
  </xsl:when>
		-->
  <xsl:when test="@type='1'">
<ul>
      <xsl:call-template name="splitByLine">
      <xsl:with-param name="str" select="text"/>
      <xsl:with-param name="type" select="@type"/>
    </xsl:call-template>
</ul>
</xsl:when>
  <xsl:when test="@type='2'">
<ol>
      <xsl:call-template name="splitByLine">
      <xsl:with-param name="str" select="text"/>
      <xsl:with-param name="type" select="@type"/>
    </xsl:call-template>
</ol>
  </xsl:when>
  </xsl:choose>
  </xsl:if>
  <xsl:apply-templates mode="full" select="fileset"/>
</xsl:template>

<xsl:template name="splitByLine">
  <xsl:param name="str"/>
  <xsl:param name="type"/>
  <xsl:param name="count">1</xsl:param>
  <xsl:variable name="strLength"><xsl:value-of select="string-length($str)"/></xsl:variable>
  <xsl:variable name="strTrimmed"> <!-- trim the extra line breaks for the next iteration -->
    <xsl:choose>
      <xsl:when test="substring($str, $strLength, 1) = '&#10;'">
        <xsl:value-of select="substring($str, 1, ($strLength - 1))"/><br/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of disable-output-escaping="yes" select="substring($str, 1, $strLength)"/><br/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:variable>
  <xsl:variable name="thisText"> <!-- set the text to be used on this iteration, depends on if it is the last time -->
    <xsl:choose>
      <xsl:when test="contains($str,'&#10;')">
        <xsl:value-of disable-output-escaping="yes" select="substring-before($str,'&#10;')"/><br/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$str"/><br/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:variable>
  <xsl:choose>
    <xsl:when test="$type='0'">
      <xsl:if test="string-length($thisText) &gt; 1">
        &#160; &#160; &#160; <xsl:value-of select="$thisText"/>&#160;<br/>
      </xsl:if>
    </xsl:when>
    <xsl:when test="$type='1'">
      <xsl:if test="string-length($thisText) &gt; 1">
      <li> <xsl:value-of select="$thisText"/></li>
      </xsl:if>
    </xsl:when>
    <xsl:when test="$type='2'">
      <xsl:if test="string-length($thisText) &gt; 1">
      <li> <xsl:value-of disable-output-escaping="yes" select="$thisText"/></li>
      </xsl:if>
<!--       <xsl:value-of select="$count"/>.&#160; &#160;  &#160; <xsl:value-of select="$thisText"/><br/> -->
    </xsl:when>
    <xsl:when test="$type='3'">
      <xsl:if test="string-length($thisText) &gt; 1">
        <blockquote><xsl:value-of select="$thisText"/></blockquote>
      </xsl:if>
    </xsl:when>
    <xsl:when test="$type='4'">
      <xsl:if test="string-length($thisText) &gt; 1">
        <xsl:value-of select="$thisText"/>&#160;<br/><br/>
      </xsl:if>
    </xsl:when>
  </xsl:choose>

  <xsl:if test="contains($str,'&#10;')">
    <xsl:call-template name="splitByLine">
      <xsl:with-param name="str">
        <xsl:choose> <!-- eliminate double line breaks -->
          <xsl:when test="substring-before($strTrimmed,'&#10;') = substring-before($strTrimmed,'&#10;&#10;')">
            <xsl:value-of select="substring-after($strTrimmed, '&#10;&#10;')"/><br/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of disable-output-escaping="yes" select="substring-after($strTrimmed, '&#10;')"/><br/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="type" select="$type"/>
      <xsl:with-param name="count" select="$count+1"/>
    </xsl:call-template>
  </xsl:if>
</xsl:template>

  <xsl:template match="fileset" mode="full">
    <xsl:apply-templates mode="full" select="file">
      <xsl:sort select="@order" order="ascending"/>
    </xsl:apply-templates>
  </xsl:template>

	<xsl:template match="text">
		<xsl:param name="textType"/>
		<xsl:choose>
			<xsl:when test="$textType = '0'">
				<xsl:call-template name="break">
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:call-template name="break_new">
				</xsl:call-template>
			</xsl:otherwise>
		</xsl:choose>
		
	</xsl:template>

	<xsl:template name="break">
		<xsl:param name="text" select="."/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				 <!--<br/> This is commented to fix extra break adding for html data tinymce -->
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="break_new">
		<xsl:param name="text" select="."/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<br/> <!--This is commented to fix extra break adding for html data tinymce -->
				<xsl:call-template name="break_new">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
  <xsl:template match="file" mode="full">
  <br/>
	  <xsl:choose>
		  <xsl:when test="@mimetype = 'audio/wav'">
			  <img src="./images/audio.png" border="1"/>
			  <br/>
			  <a href="javascript:openWindow(unescape('http://media.ifas.ufl.edu/sare/{name}'),'fileupload','400','300','scrollbars','resizable');" onclick="_gaq.push(['_trackEvent', 'Audio', 'Download', 'http://media.ifas.ufl.edu/sare/{name}']);">
				  <!-- <xsl:value-of select="@categoryname"/>&#160;<xsl:value-of select="@groupedorder"/> <xsl:value-of select="position()"/>:--> <xsl:value-of select="caption"/>
			  </a>
		  </xsl:when>
		  <xsl:when test="@mimetype = 'video/x-ms-asf' or @mimetype = 'video/x-msvideo' or @mimetype = 'video/quicktime' or @mimetype = 'video/mp4' or @mimetype = 'video/mpeg' or @mimetype = 'video/quicktime'">
			  <img src="./images/video.png" border="1"/>
			  <br/>
			  <a href="javascript:openWindow(unescape('http://ifasgallery.ifas.ufl.edu/sare/{name}'),'fileupload','400','300','scrollbars','resizable');" onclick="_gaq.push(['_trackEvent', 'Video', 'Download', 'http://ifasgallery.ifas.ufl.edu/sare/{name}']);">
				  <!-- <xsl:value-of select="@categoryname"/>&#160;<xsl:value-of select="position()"/>:--> <xsl:value-of select="name/@original" disable-output-escaping="yes"/>
			  </a>
		  </xsl:when>
		  <xsl:otherwise>			 
			  <a href="javascript:openWindow(unescape('./assocfiles/{name}'),'fileupload','400','300','scrollbars','resizable');" onclick="_gaq.push(['_trackEvent', 'Document', 'Download', './assocfiles/{name}']);"> 
				  <xsl:choose>
					  <!-- <xsl:when test="@displaymode = 1 or @displaymode = 2"> -->
					  <xsl:when test="@categoryname = 'Image'">
						  <img src="http://mysare.sare.org/MySARE/assocfiles/tn_{name}" border="1"/>
						  <br/>
					  </xsl:when>
					  <xsl:otherwise>
						  <img src="./images/document.png" border="1"/><br/>
					  </xsl:otherwise>
				  </xsl:choose>
				  <!--<xsl:value-of select="@categoryname"/>&#160; <xsl:value-of select="@groupedorder"/> <xsl:value-of select="position()"/>:--> <xsl:value-of select="caption"/>
			  </a>
		  </xsl:otherwise>
	  </xsl:choose>
  </xsl:template>

</xsl:stylesheet>



