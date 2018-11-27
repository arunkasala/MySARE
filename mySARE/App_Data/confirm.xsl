<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="confirmtype">message</xsl:param>
<xsl:param name="nextstep"/>
<xsl:param name="backpage"/>
<xsl:param name="reporttype"/>
<xsl:param name="currentYear">2009</xsl:param>
<xsl:param name="msgID"/>
<xsl:param name="event"/>
<xsl:param name="upload"/>
<xsl:param name="resourceID"/>

<xsl:template match="/">
  <html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
  <head>
	<script LANGUAGE="JavaScript">
	<![CDATA[
		//Stolen from http://www.harrymaugans.com/
        function toggleDiv(divid){
            if(document.getElementById(divid).style.display == 'none'){
                  document.getElementById(divid).style.display = 'block';
                  document.getElementById(divid + '_label').innerHTML = '[-]';
            }else{
                  document.getElementById(divid).style.display = 'none';
                  document.getElementById(divid + '_label').innerHTML = '[+]';
            }
        }
		
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
  	]]>
	</script>

  <style type="text/css">

div.wrapper
{
	margin-bottom: 1em;
	width: 60em;
}

span.option
{
	float: left;
	width: 20em;  /* accommodate the widest item */
}

/* stop the floating after the list */
br
{
	clear: left;
}
</style>
</head>

<body>
  <p>
	<xsl:if test="/SAREroot/user[@context='current']/firstname"><span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/><br/></xsl:if>
    <span class="pagetitle">Confirmation</span>
    <p class="subtitle"/>
    <p class="subtitle"/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <!--<xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>-->
  </p>

    <xsl:choose>
		<xsl:when test="$confirmtype = 'event'">
          <xsl:apply-templates select="SAREroot/calendarEvent"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'message'">
          <xsl:apply-templates select="*/*/message"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'delete'">
			<xsl:call-template name="delete"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'deleteuser'">
			<xsl:call-template name="deleteuser"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'update'">
			<xsl:call-template name="update"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'submit'">
			<xsl:call-template name="submit"/>
		</xsl:when>
		<xsl:when test="$confirmtype = 'register'">
			<xsl:call-template name="register"/>
		</xsl:when>
		<xsl:otherwise>
   Nothing to confirm.<br/>
			<a href="?do=sendpicall">Back to Send Message Page</a><br/>
		</xsl:otherwise>
	</xsl:choose>

	<xsl:if test="$event != ''">
		<br/>
		<br/>
		<small>
			This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.</small>
	</xsl:if>

</body>
</html>
</xsl:template>
	
<xsl:template name="update">
	<p>
		<span class="evDate">
			<xsl:value-of select="$message2"/>
		</span><br/><br/>		
		<input name="back" onclick ="window.location.href='{$backpage}'" type="submit" value="Back"/>&#160;
		<input name="main" onclick ="window.location.href='sare_main.aspx'" type="submit" value="My Main Page"/>
	</p>
</xsl:template>
	
<xsl:template name="delete">
	<p>
		<span class="evDate">
			<xsl:value-of select="$message2"/>
		</span><br/><br/>
		<xsl:if test="$backpage != '' and $resourceID = ''">
			<input name="back" onclick ="window.location.href='sare_main.aspx?do={$backpage}'" type="submit" value="Back"/>&#160;
		</xsl:if>
		<xsl:if test="$backpage != '' and $resourceID != ''">
			<input name="back" onclick ="window.location.href='sare_main.aspx?do={$backpage}'" type="submit" value="Back to Project Overview"/>&#160;
		</xsl:if>
		<input name="main" onclick ="window.location.href='sare_main.aspx'" type="submit" value="My Main Page"/>
	</p>
</xsl:template>
	
<xsl:template name="deleteuser">
	<p>
		<span class="evDate">
			<xsl:value-of select="$message2"/>
		</span><br/><br/>
		<input name="back" onclick ="window.location.href='sare_main.aspx?do=userlist'" type="submit" value="Back"/>&#160;
		<input name="main" onclick ="window.location.href='sare_main.aspx'" type="submit" value="My Main Page"/>
	</p>
</xsl:template>
	
<xsl:template name="submit">
	<p>
		<span class="evDate">
			<xsl:value-of select="$message2"/>
		</span><br/><br/>
		<xsl:if test="$upload = '0'">
			<!-- <input type="submit" name="fileUp" id="fileUp" value="Upload File" onclick="window.location.href=javascript:openWindow('fileUpload.aspx?suid={$resourceID}&amp;order=999','fileupload','600','300','scrollbars','resizable');"></input>&#160;&#160; 
			<xsl:if test="$message2 != 'File Uploaded.'">
				<input type="submit" value="Upload File"  onclick="window.open('fileUpload.aspx?suid={$resourceID}&amp;order=999','fileupload','width=600,height=300,scrollbars=yes,resizable=yes')"></input>&#160;
			</xsl:if>
			-->
			<input name="saveadd" type="submit" value="Add Another Information Product" onclick ="window.location.href='sare_main.aspx?do=infoproddetail'"/>&#160;
		</xsl:if>
		<xsl:if test="$reporttype != ''">
			<input name="back" onclick ="window.location.href='sare_main.aspx?do={$backpage}'" type="submit" value="{$reporttype}"/>&#160;
		</xsl:if>
		<xsl:if test="$reporttype = ''">
			<input name="back" onclick ="window.location.href='sare_main.aspx?do={$backpage}'" type="submit" value="Back to Project Overview Page"/>&#160;
		</xsl:if>
		<input name="main" onclick ="window.location.href='sare_main.aspx'" type="submit" value="Back to My Main Page"/>
	</p>
</xsl:template>
	
<xsl:template name="register">
	<p>
		<span class="evDate">
			<xsl:value-of select="$message2"/>
		</span><br/><br/>		
		<input name="main" onclick ="window.location.href='sare_main.aspx'" type="submit" value="Go To MySARE"/>
	</p>
</xsl:template>

<xsl:template match="calendarEvent">
	<p>
		<b>Dates:</b>&#160;<!--<xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>-<xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/><br/><br/>-->
	  <span class="evDate">
		  <xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>
		  <xsl:if test="times/startDateOrder != times/endDateOrder">
			  &#160;-&#160;
			  <xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/>
		  </xsl:if>
	  </span><br/><br/>
    <b>Location:</b>&#160;<xsl:value-of select="location"/>,&#160;<xsl:value-of select="state"/><br/><br/>
    <b>Scope:</b>

		<xsl:choose>
		<xsl:when test="geoscope = 'INT'">
			&#160;International<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'REG'">
			&#160;Regional<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'US'">
			&#160;National<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'USST'">
			&#160;Statewide<br/><br/>
		</xsl:when>
		<xsl:otherwise>
			&#160;<xsl:value-of select="geoscope"/><br/><br/>
		</xsl:otherwise>
	</xsl:choose>

	<b>Type:</b>&#160;<xsl:value-of select="type/code"/><br/><br/>
	<b>Description:</b>&#160;<xsl:value-of select="description"/><br/><br/>
	  <xsl:if test="url/urlAddress != ''">
		<b>Websites:</b><br/><br/>
		  <xsl:if test="url/@order = '1'">
			&#160;&#160;&#160;<b>1.&#160;<a href="{url/urlAddress}"><xsl:value-of select="url/urlAddress"/></a></b><br/><br/>
		  </xsl:if>
		  <xsl:if test="url/@order = '2'">
			&#160;&#160;&#160;<b>2.&#160;<a href="{url/urlAddress}"><xsl:value-of select="url/urlAddress"/></a></b><br/><br/>
		  </xsl:if>
	  </xsl:if>
	<b>Contact:</b><br/><br/>
	 &#160;&#160;&#160;<b><xsl:value-of select="/SAREroot/nonusercontact/nametitle"/>&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/firstname"/>&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/lastname"/></b><br/>
	 &#160;&#160;&#160;<b><xsl:value-of select="/SAREroot/nonusercontact/organization/@name"/></b><br/>
	  <xsl:if test="/SAREroot/nonusercontact/contact/addrState != ''">
		&#160;&#160;&#160;Address:<br/>

		  <xsl:if test="/SAREroot/nonusercontact/contact/addrStreet1 != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrStreet1"/><br/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrStreet2 != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrStreet2"/><br/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrCity != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrCity"/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrState != ''">
			  ,&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrState"/>
		  </xsl:if><br/>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrZip != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrZip"/>
		  </xsl:if><br/><br/>

	  </xsl:if>

	  <xsl:if test="/SAREroot/nonusercontact/contact/numPhone != ''">
		  &#160;&#160;&#160;Phone:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/numPhone"/><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/numFax != ''">
		  &#160;&#160;&#160;Fax:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/numFax"/><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/email != ''">
		  &#160;&#160;&#160;Email:&#160;<a href="mailto:{/SAREroot/nonusercontact/contact/email}"><xsl:value-of select="/SAREroot/nonusercontact/contact/email"/></a><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/website != ''">
		  &#160;&#160;&#160;Website:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/website"/><br/>
	  </xsl:if>
	<br/><br/>
  </p>
</xsl:template>

<xsl:template match="message">
   <form action="?do=confirm" method="post" name="sendpicall">
     <input type="hidden" name="msgID" value="{$msgID}"/>
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0"><tablebody>
       <tr>
         <td>CC List: </td>
         <td>
<xsl:for-each select="/*/*/user[@context='cclist']">
    <xsl:choose>
		<xsl:when test="firstname!=''">
<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
		</xsl:when>
		<xsl:otherwise>
<xsl:value-of select="contact/email"/>
        </xsl:otherwise>
    </xsl:choose>
    <xsl:if test="position() != last()">, </xsl:if>
</xsl:for-each>
         </td>
       </tr>
       <tr>
         <td>BCC List: </td>
         <td>
			 <textarea id="boxDescription" name="boxDescription" rows="2" cols="60" wrap="virtual">
				 <xsl:for-each select="/*/*/user[@context='bcclist']">
					 <xsl:choose>
						 <xsl:when test="firstname!=''">
							 <xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
						 </xsl:when>
						 <xsl:otherwise>
							 <xsl:value-of select="contact/email"/>
						 </xsl:otherwise>
					 </xsl:choose>
					 <xsl:if test="position() != last()">, </xsl:if>
				 </xsl:for-each>
			 </textarea>
         </td>
       </tr>
       <tr>
         <td>Message Subject: </td>
         <td>
            <xsl:value-of select="/*/*/message/subject"/>
         </td>
       </tr>
       <tr>
         <td>Message Body: </td>
         <td>
            <xsl:value-of select="/*/*/message/message"/>
         </td>
       </tr>
     </tablebody></table>
     <input name="sendmail" type="submit" value="Send Message"/>&#160;
	 <input type="button" value="Back" onClick="history.go(-1)"/>&#160;
     <input name="main" onclick ="window.location.href='sare_main.aspx'" type="button" value="Cancel"/>
  </form>



</xsl:template>
</xsl:stylesheet>



