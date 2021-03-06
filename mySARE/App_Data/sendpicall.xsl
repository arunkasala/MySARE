<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="currentYear">2009</xsl:param>
<xsl:param name="msgID"/>
<xsl:param name="reptStatus"/>

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
	<xsl:if test="/SAREroot/user[@context='current']/firstname"><span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/></xsl:if>
    <span class="pagetitle">Send Call for Reports and Other Messages to PIs</span>	
    <p class="subtitle">Use this page to create and send messages to grant recipients.</p>
	  <ul>
		  <li>Create a template: Choose “New Message” from the “Saved Messages” drop down menu, enter the message subject and body text in the fields below, then click “Save Message.” Your saved message will then be available from the “Saved Messages” drop down menu.</li>
		  <li>Send a message: Choose one of the saved messages from the “Saved Messages” drop down menu OR choose “New Message” and write your own text in the message body and subject fields. Select your message recipient(s) by specifying project type, report status, region, and years to automatically select pis that meet those criteria , then click “Preview and Send Message.”</li>
	  </ul>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>

   <form action="?do=confirm" method="post" name="sendpicall">
     <input type="hidden" name="msgID" value="{$msgID}"/>
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0"><tablebody>
       <tr>
         <td width="20%">Saved Messages: </td>
         <td>

           <select name="titles" onChange="changepage(this)" id="select">
           <xsl:choose>
             <xsl:when test="/SAREroot/usermessages/message">
               <option value="?do=sendpicall">New Message</option>
             <xsl:for-each select="/SAREroot/usermessages/message">
               <xsl:call-template name="option">
                 <xsl:with-param name="selected">?do=sendpicall&amp;msg=<xsl:value-of select="$msgID"/></xsl:with-param>
                 <xsl:with-param name="value">?do=sendpicall&amp;msg=<xsl:value-of select="@ID"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="title"/></xsl:with-param>
               </xsl:call-template>
             </xsl:for-each>
             </xsl:when>
             <xsl:otherwise>
               <option value="?do=sendpicall">No Saved Messages</option>
             </xsl:otherwise>
           </xsl:choose>
           </select><br/>
		 </td>
       </tr>
       <tr>
         <td>Project Type: </td>
         <td>
           <select name="projType">
             <option value="">All Types</option>
             <xsl:for-each select="/SAREroot/projTypes/projType">
               <xsl:call-template name="option">
                 <xsl:with-param name="value"><xsl:value-of select="typeCode"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
               </xsl:call-template>
             </xsl:for-each>
           </select>
         </td>
       </tr>
	   <tr>
         <td>Report Status: </td>
         <td>
			 <select id="reportStatus" size="1" name="reportStatus">
				 <xsl:if test="$reptStatus = 4">
					 <option value="4" selected ="$reptStatus">All Recipients</option>
					 <option  value="0">Missing Annual Report</option>
					 <option  value="1">Missing Final Report</option>
					 <option  value="2">Missing Overview</option>
					 <option  value="3">No Reports Submitted</option>
				 </xsl:if>
				 <xsl:if test="$reptStatus = 0">
					 <option value="4">All Recipients</option>
					 <option  value="0" selected ="$reptStatus">Missing Annual Report</option>
					 <option  value="1">Missing Final Report</option>
					 <option  value="2">Missing Overview</option>
					 <option  value="3">No Reports Submitted</option>
				 </xsl:if>
				 <xsl:if test="$reptStatus = 1">
					 <option value="4" selected ="$reptStatus">All Recipients</option>
					 <option  value="0">Missing Annual Report</option>
					 <option  value="1">Missing Final Report</option>
					 <option  value="2">Missing Overview</option>
					 <option  value="3">No Reports Submitted</option>
				 </xsl:if>
				 <xsl:if test="$reptStatus = 2">
					 <option value="4">All Recipients</option>
					 <option  value="0">Missing Annual Report</option>
					 <option  value="1">Missing Final Report</option>
					 <option  value="2" selected ="$reptStatus">Missing Overview</option>
					 <option  value="3">No Reports Submitted</option>
				 </xsl:if>
				 <xsl:if test="$reptStatus = 3">
					 <option value="4">All Recipients</option>
					 <option  value="0">Missing Annual Report</option>
					 <option  value="1">Missing Final Report</option>
					 <option  value="2">Missing Overview</option>
					 <option  value="3"  selected ="$reptStatus">No Reports Submitted</option>
				 </xsl:if>
			 </select>
		 </td>
	 </tr>
	 <tr>
		 <td>Region: </td>
		 <td>
			 <xsl:choose>
<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin']">
           <select name="region">
             <option value="">All Regions</option>
             <xsl:for-each select="/SAREroot/regions/region">
               <xsl:call-template name="option">
                 <xsl:with-param name="value"><xsl:value-of select="regionCode"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
               </xsl:call-template>
             </xsl:for-each>
           </select>
</xsl:when>
<xsl:when test="/SAREroot/user/userroles/role[@code='regAdmin' and @code!='admin' and @code!='natAdmin']">
  <input type="hidden" name="region" value="{/SAREroot/user/userroles/role[@code='regAdmin']/@region}"/><xsl:value-of select="/SAREroot/user/userroles/role[@code='regAdmin']/@region"/>
</xsl:when>
</xsl:choose>
         </td>
       </tr>
       <tr>
         <td>Project Years: </td>
         <td>
           <select name="startYear">
             <option value="0">All Years</option>
               <xsl:call-template name="yearList">
                 <xsl:with-param name="startYear">1988</xsl:with-param>
                 <xsl:with-param name="endYear"><xsl:value-of select="$currentYear + 2"/></xsl:with-param>
               </xsl:call-template>
           </select>
         Start Year
         <br/>
           <select name="endYear">
             <option value="10000">All Years</option>
               <xsl:call-template name="yearList">
                 <xsl:with-param name="startYear">1988</xsl:with-param>
                 <xsl:with-param name="endYear"><xsl:value-of select="$currentYear + 2"/></xsl:with-param>
               </xsl:call-template>
           </select>
         End Year
         </td>
       </tr>
       <tr>
         <td>Additional Recipients: </td>
         <td>

           CC:&#160;&#160;&#160;<input type="text" name="cclist" size="75" value=""/>
           <br/>
           BCC:&#160;<input type="text" name="bcclist" size="75" value=""/>
           <br/>
			 Enter the email addresses of additional recipients in the appropriate field. Multiple addresses should be comma-separated. (<em>email1@host.com, email2@host.com, email3@hos...</em>) Administrators will automatically be CC’d.
		 </td>
       </tr>
       <tr>
         <td>Message Subject: </td>
         <td>

           <input type="text" name="msgsubject" size="80" value="{/SAREroot/usermessages/message[@ID=$msgID]/subject}"/>

         </td>
       </tr>
       <tr>
         <td>Message Body: </td>
         <td>
            <textarea name="callmsg" rows="10" cols="62"><xsl:if test="$msgID"><xsl:value-of select="/SAREroot/usermessages/message[@ID=$msgID]/message"/></xsl:if>&#160;</textarea>
         </td>
       </tr>
       <tr>
         <td>Message Name: </td>
         <td>

           <input type="text" name="msgtitle" size="80" value="{/SAREroot/usermessages/message[@ID=$msgID]/title}"/>
           <br/>(This name will show up in your saved messages list but will not be shown to recipients)

         </td>
       </tr>
     </tablebody></table>
     <input name="picall" type="submit" value="Preview and Send Message"/>&#160;
     <input name="savepicall" type="submit" value="Save Message"/>
  </form>

  </body>
  </html>
</xsl:template>

<xsl:template name="option">
<!-- Generates an option to go in the drop-down list -->
  <xsl:param name="selected"/> <!-- value of the currently selected option -->
  <xsl:param name="value"/>  <!-- value of the option to be created -->
  <xsl:param name="label"/> <!-- label of the option to be created -->
  <xsl:choose>
    <xsl:when test="$selected=$value">
     <option value="{$value}" selected="selected"><xsl:value-of select="$label"/></option>
    </xsl:when>
    <xsl:otherwise>
      <option value="{$value}"><xsl:value-of select="$label"/></option>
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="profoption">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$catname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="$label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

<xsl:template name="optionsub">
  <xsl:param name="catname"/>
  <xsl:param name="subcatname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$subcatname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profilesubcat[@name=$subcatname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="$label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

<xsl:template name="yearList">
<!-- creates options for all years between start and end that do not have reports -->
  <xsl:param name="startYear"/>
  <xsl:param name="endYear"/>
  <xsl:if test="$startYear &lt; ($endYear+1)">
    <xsl:if test="not(report[@year=$startYear])">
      <option value="{$startYear}"><xsl:value-of select="$startYear"/></option>
    </xsl:if>
    <xsl:call-template name="yearList">
      <xsl:with-param name="startYear" select="$startYear + 1"/>
      <xsl:with-param name="endYear" select="$endYear"/>
    </xsl:call-template>
  </xsl:if>
</xsl:template>

</xsl:stylesheet>



