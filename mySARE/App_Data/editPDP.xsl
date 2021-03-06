<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="sortby">projNum</xsl:param>
<xsl:param name="currentYear">2009</xsl:param>
<xsl:param name="grantslist">myProj</xsl:param>
<xsl:param name="deleteProj"/>
<xsl:param name="projectParticipants"/>
<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="useradmin"/>

<xsl:template match="/">
<script language="JavaScript" src="./ajax/ts_picker4.js"/>
<script LANGUAGE="JavaScript">
		<![CDATA[
	
	var varPreviousSelectedID;
	
	var showPrompt = false;
	
	function closeIt()
	{
	  if (showPrompt)
		return "Would you like to save your data before leaving this page?";
	}
	window.onbeforeunload=closeIt;
	
	function toggleDiv(divid)
	{
		if(document.getElementById(divid).style.display == 'none')
		{
			document.getElementById(divid).style.display = 'block';
		}
		else
		{
			document.getElementById(divid).style.display = 'none';
		}	
	}  
	
	function get()
	{
		var get;
		var varCheckboxes = document.getElementsByTagName('input');
 
		for (var loop = 0; loop <=varCheckboxes.length; loop++) {
		if (varCheckboxes(loop).checked == true) {
 
			if (varPreviousSelectedID) {
				if (varPreviousSelectedID == varCheckboxes(loop)) {
					varCheckboxes(loop).checked = false;
			}
			else {
					varPreviousSelectedID.checked = false;
					varPreviousSelectedID = varCheckboxes(loop);
					varCheckboxes(loop).checked = true;
				}
			}
			else {
				varPreviousSelectedID = varCheckboxes(loop);
			}
		}
		}	
	}
	
	function numbersonly(e, format) 
		{
			 var key;
			 var keychar;
			   
			 if (window.event) {
				 key = window.event.keyCode;
			  }
			  else if (e) {
			   key = e.which;
			  }
			  else {
				  return true;
			   }
			  keychar = String.fromCharCode(key);
			   
			  if ((key==null) || (key==0) || (key==8) ||  (key==9) || (key==13) || (key==27) ) {
				  return true;
				}
			   else if ((("0123456789").indexOf(keychar) > -1)) {
				  return true;
			   }
          else if (format && (keychar == ".")) { 
            return true;
          }
         else if (format && (keychar == ",")) { 
            return true;
          }
			   else
				  return false;
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

		.boxed {
		border: 1px solid black ;
		width: 14em;
		margin: 4em;

		}

	</style>

	<script language="JavaScript" src="./tinymce/tinymce.min.js"/>
	<script type="text/javascript">
		tinymce.init({
		selector: "textarea",
		plugins: [
		"advlist lists charmap hr anchor pagebreak ",
		"paste nonbreaking",
		"fullscreen"
		],

		toolbar1: "bold italic underline | bullist numlist | outdent indent | removeformat | subscript superscript | charmap | cut copy paste",

		menubar: false,
		toolbar_items_size: 'small',
		statusbar : true,
		height: "200",
    width:570,
		force_p_newlines : false,
		force_br_newlines : false,
		forced_root_block : false,
		convert_newlines_to_brs: false,
		remove_linebreaks : true,
		paste_use_dialog: false,
		paste_auto_cleanup_on_paste : true,
		theme_advanced_statusbar_location : "none"
		});
	</script>


	<p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <!-- <span class="pagetitle">Edit Project Details</span><br/>-->
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
	<p class="subtitle">
		Enter the details about your project in the fields below, and then click “Submit” to submit the report.
	</p>	
	<xsl:apply-templates select="SAREroot/SAREgrant"/>
</xsl:template>

<xsl:template match="SAREgrant">
	
  <!-- Project Details  -->
  <xsl:variable name="fundsSARE"><xsl:value-of select='format-number(funds/SARE, "###,###.00")'/></xsl:variable>
  <xsl:variable name="fundsFed"><xsl:value-of select='format-number(funds/Fed, "###,###.00")'/></xsl:variable>
  <xsl:variable name="fundsNonFed"><xsl:value-of select='format-number(funds/NonFed, "###,###.00")'/></xsl:variable>
  <xsl:variable name="projSubmitted" select="funds/Submitted"/>
  <xsl:variable name="projApproved" select="funds/Approved"/>	
  <xsl:variable name="reptYears" select="report/@year"/>
  <xsl:variable name="projStartYear" select="@year"/>
  <xsl:variable name="projEndYear" select="@projectedEndYear"/>  
  <xsl:variable name="projNarrative" select="/SAREroot/SAREgrant/report[@type=2]"/>
  <xsl:variable name="projProfile" select="/SAREroot/SAREgrant/profile/@profileID"/>
  <xsl:variable name="projParticipants" select="../nonusercontact[@context='projectparticipants']"/>
  <xsl:variable name="projectType" select="@typeCode"/>
  <xsl:variable name="regionCode" select="@regionCode"/>
  <xsl:variable name ="projNarrativeApproved" select="/SAREroot/SAREgrant/report/@approvedstatus"/>
  <xsl:variable name="addrState" select="/SAREroot/pdpInfoDetails/statePro"/>

	<!-- PDP Details  -->
	<xsl:variable name="pdpid" select="/SAREroot/pdpInfoDetails/@pdp_id"/>
	<xsl:variable name="coordfirst" select="/SAREroot/pdpInfoDetails/coordfirst"/>
	<xsl:variable name="coordlast" select="/SAREroot/pdpInfoDetails/coordlast"/>
	<xsl:variable name="institute" select="/SAREroot/pdpInfoDetails/institute"/>
	<xsl:variable name="institute2" select="/SAREroot/pdpInfoDetails/institute2"/>
	<xsl:variable name="institute3" select="/SAREroot/pdpInfoDetails/institute3"/>
	<xsl:variable name="address" select="/SAREroot/pdpInfoDetails/address"/>
	<xsl:variable name="city" select="/SAREroot/pdpInfoDetails/city"/>
	<xsl:variable name="state" select="/SAREroot/pdpInfoDetails/state"/>
	<xsl:variable name="zip" select="/SAREroot/pdpInfoDetails/zip"/>
	<xsl:variable name="phone" select="/SAREroot/pdpInfoDetails/phone"/>
	<xsl:variable name="fax" select="/SAREroot/pdpInfoDetails/fax"/>
	<xsl:variable name="email" select="/SAREroot/pdpInfoDetails/email"/>
	<xsl:variable name="statePro" select="/SAREroot/pdpInfoDetails/statePro"/>
	<xsl:variable name="advname" select="/SAREroot/pdpInfoDetails/advname"/>
	<xsl:variable name="advaff" select="/SAREroot/pdpInfoDetails/advaff"/>
	<xsl:variable name="advdate" select="/SAREroot/pdpInfoDetails/advdate"/>
	<xsl:variable name="advloc" select="/SAREroot/pdpInfoDetails/advloc"/>
	<xsl:variable name="advname1" select="/SAREroot/pdpInfoDetails/advname1"/>
	<xsl:variable name="advaff1" select="/SAREroot/pdpInfoDetails/advaff1"/>
	<xsl:variable name="advdate1" select="/SAREroot/pdpInfoDetails/advdate1"/>
	<xsl:variable name="advloc1" select="/SAREroot/pdpInfoDetails/advloc1"/>
	<xsl:variable name="advname2" select="/SAREroot/pdpInfoDetails/advname2"/>
	<xsl:variable name="advaff2" select="/SAREroot/pdpInfoDetails/advaff2"/>
	<xsl:variable name="advdate2" select="/SAREroot/pdpInfoDetails/advdate2"/>
	<xsl:variable name="advloc2" select="/SAREroot/pdpInfoDetails/advloc2"/>
	<xsl:variable name="advname3" select="/SAREroot/pdpInfoDetails/advname3"/>
	<xsl:variable name="advaff3" select="/SAREroot/pdpInfoDetails/advaff3"/>
	<xsl:variable name="advdate3" select="/SAREroot/pdpInfoDetails/advdate3"/>
	<xsl:variable name="advloc3" select="/SAREroot/pdpInfoDetails/advloc3"/>
	<xsl:variable name="advname4" select="/SAREroot/pdpInfoDetails/advname4"/>
	<xsl:variable name="advaff4" select="/SAREroot/pdpInfoDetails/advaff4"/>
	<xsl:variable name="advdate4" select="/SAREroot/pdpInfoDetails/advdate4"/>
	<xsl:variable name="advloc4" select="/SAREroot/pdpInfoDetails/advloc4"/>
	<xsl:variable name="advname5" select="/SAREroot/pdpInfoDetails/advname5"/>
	<xsl:variable name="advaff5" select="/SAREroot/pdpInfoDetails/advaff5"/>
	<xsl:variable name="advdate5" select="/SAREroot/pdpInfoDetails/advdate5"/>
	<xsl:variable name="advloc5" select="/SAREroot/pdpInfoDetails/advloc5"/>
	<xsl:variable name="advname6" select="/SAREroot/pdpInfoDetails/advname6"/>
	<xsl:variable name="advaff6" select="/SAREroot/pdpInfoDetails/advaff6"/>
	<xsl:variable name="advdate6" select="/SAREroot/pdpInfoDetails/advdate6"/>
	<xsl:variable name="advloc6" select="/SAREroot/pdpInfoDetails/advloc6"/>
	<xsl:variable name="advname7" select="/SAREroot/pdpInfoDetails/advname7"/>
	<xsl:variable name="advaff7" select="/SAREroot/pdpInfoDetails/advaff7"/>
		<xsl:variable name="advloc7" select="/SAREroot/pdpInfoDetails/advloc7"/>
	<xsl:variable name="AdvLName" select="/SAREroot/pdpInfoDetails/advLName"/>
	<xsl:variable name="AdvType" select="/SAREroot/pdpInfoDetails/advType"/>
	<xsl:variable name="AdvLocationState" select="/SAREroot/pdpInfoDetails/AdvLocationState"/>
	<xsl:variable name="AdvLocationZip" select="/SAREroot/pdpInfoDetails/AdvLocationZip"/>
	<xsl:variable name="AdvLName1" select="/SAREroot/pdpInfoDetails/advLName1"/>
	<xsl:variable name="AdvType1" select="/SAREroot/pdpInfoDetails/advType1"/>
	<xsl:variable name="AdvLocationState1" select="/SAREroot/pdpInfoDetails/AdvLocationState1"/>
	<xsl:variable name="AdvLocationZip1" select="/SAREroot/pdpInfoDetails/AdvLocationZip1"/>
	<xsl:variable name="AdvLName2" select="/SAREroot/pdpInfoDetails/advLName2"/>
	<xsl:variable name="AdvType2" select="/SAREroot/pdpInfoDetails/advType2"/>
	<xsl:variable name="AdvLocationState2" select="/SAREroot/pdpInfoDetails/AdvLocationState2"/>
	<xsl:variable name="AdvLocationZip2" select="/SAREroot/pdpInfoDetails/AdvLocationZip2"/>
	<xsl:variable name="AdvLName3" select="/SAREroot/pdpInfoDetails/advLName3"/>
	<xsl:variable name="AdvType3" select="/SAREroot/pdpInfoDetails/advType3"/>
	<xsl:variable name="AdvLocationState3" select="/SAREroot/pdpInfoDetails/AdvLocationState3"/>
	<xsl:variable name="AdvLocationZip3" select="/SAREroot/pdpInfoDetails/AdvLocationZip3"/>
	<xsl:variable name="AdvLName4" select="/SAREroot/pdpInfoDetails/advLName4"/>
	<xsl:variable name="AdvType4" select="/SAREroot/pdpInfoDetails/advType4"/>
	<xsl:variable name="AdvLocationState4" select="/SAREroot/pdpInfoDetails/AdvLocationState4"/>
	<xsl:variable name="AdvLocationZip4" select="/SAREroot/pdpInfoDetails/AdvLocationZip4"/>
	<xsl:variable name="AdvLName5" select="/SAREroot/pdpInfoDetails/advLName5"/>
	<xsl:variable name="AdvType5" select="/SAREroot/pdpInfoDetails/advType5"/>
	<xsl:variable name="AdvLocationState5" select="/SAREroot/pdpInfoDetails/AdvLocationState5"/>
	<xsl:variable name="AdvLocationZip5" select="/SAREroot/pdpInfoDetails/AdvLocationZip5"/>
	<xsl:variable name="AdvLName6" select="/SAREroot/pdpInfoDetails/advLName6"/>
	<xsl:variable name="AdvType6" select="/SAREroot/pdpInfoDetails/advType6"/>
	<xsl:variable name="AdvLocationState6" select="/SAREroot/pdpInfoDetails/AdvLocationState6"/>
	<xsl:variable name="AdvLocationZip6" select="/SAREroot/pdpInfoDetails/AdvLocationZip6"/>
	<xsl:variable name="AdvLName7" select="/SAREroot/pdpInfoDetails/advLName7"/>
	<xsl:variable name="initOut" select="/SAREroot/pdpInfoDetails/sare_outreach"/>
	<xsl:variable name="advname8" select="/SAREroot/pdpInfoDetails/advname8"/>
	<xsl:variable name="AdvLName8" select="/SAREroot/pdpInfoDetails/advLName8"/>
	<xsl:variable name="advaff8" select="/SAREroot/pdpInfoDetails/advaff8"/>
	<xsl:variable name="advname9" select="/SAREroot/pdpInfoDetails/advname9"/>
	<xsl:variable name="AdvLName9" select="/SAREroot/pdpInfoDetails/advLName9"/>
	<xsl:variable name="advaff9" select="/SAREroot/pdpInfoDetails/advaff9"/>
	<xsl:variable name="advname10" select="/SAREroot/pdpInfoDetails/advname10"/>
	<xsl:variable name="AdvLName10" select="/SAREroot/pdpInfoDetails/advLName10"/>
	<xsl:variable name="advaff10" select="/SAREroot/pdpInfoDetails/advaff10"/>
	<xsl:variable name="advname11" select="/SAREroot/pdpInfoDetails/advname11"/>
	<xsl:variable name="AdvLName11" select="/SAREroot/pdpInfoDetails/advLName11"/>
	<xsl:variable name="advaff11" select="/SAREroot/pdpInfoDetails/advaff11"/>
	<xsl:variable name="advname12" select="/SAREroot/pdpInfoDetails/advname12"/>
	<xsl:variable name="AdvLName12" select="/SAREroot/pdpInfoDetails/advLName12"/>
	<xsl:variable name="advaff12" select="/SAREroot/pdpInfoDetails/advaff12"/>
	<xsl:variable name="advname13" select="/SAREroot/pdpInfoDetails/advname13"/>
	<xsl:variable name="AdvLName13" select="/SAREroot/pdpInfoDetails/advLName13"/>
	<xsl:variable name="advaff13" select="/SAREroot/pdpInfoDetails/advaff13"/>
	<xsl:variable name="advname14" select="/SAREroot/pdpInfoDetails/advname14"/>
	<xsl:variable name="AdvLName14" select="/SAREroot/pdpInfoDetails/advLName14"/>
	<xsl:variable name="advaff14" select="/SAREroot/pdpInfoDetails/advaff14"/>
	<xsl:variable name="advname15" select="/SAREroot/pdpInfoDetails/advname15"/>
	<xsl:variable name="AdvLName15" select="/SAREroot/pdpInfoDetails/advLName15"/>
	<xsl:variable name="advaff15" select="/SAREroot/pdpInfoDetails/advaff15"/>
	<xsl:variable name="InitiativeCount" select="/SAREroot/pdpInfoDetails/initiative_count"/>
	

	<!-- PDP Initiative/Topic and Partners -->
	<xsl:variable name="pdpinitid" select="/SAREroot/pdpInfoDetails/@pdp_init_partners"/>
	<xsl:variable name="pdpinititle" select="/SAREroot/pdpInfoDetails/@pdp_init_title"/>
	<xsl:variable name="pdpinititle1" select="/SAREroot/pdpInfoDetails/@pdp_init_title1"/>
	<xsl:variable name="pdpinititle2" select="/SAREroot/pdpInfoDetails/@pdp_init_title2"/>
	<xsl:variable name="pdpinititle3" select="/SAREroot/pdpInfoDetails/@pdp_init_title3"/>
	<xsl:variable name="pdpinititle4" select="/SAREroot/pdpInfoDetails/@pdp_init_title4"/>
	<xsl:variable name="pdpinititle5" select="/SAREroot/pdpInfoDetails/@pdp_init_title5"/>
	
	
	<!-- PDP Output Narrative -->
	<xsl:variable name="pdpoutid" select="/SAREroot/pdpInfoDetails/@pdp_output_narrative"/>	
	

	<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
	<!-- 
    <tr>
      <td ALIGN="LEFT" VALIGN="TOP">
		<p class="pagetitle">PDP e-Form:
		</p>
		<p><strong>Note: Fields marked with an asterisk (*) are required</strong></p> 
		 
      </td>
     
    </tr>
	-->	
    <tr>
      <td>
      <form name="projDetails" METHOD="post">
		  <!-- <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']"> -->
			  <button type="submit" align="center" name="btnStateReportPDF" value="Submit">Create PDF</button>
		  <!-- </xsl:if> -->
		  <table CLASS="NORM">
			<p>
				<span class="pagetitle">State Professional Development Program Report</span>				
			</p>
			<strong>1) General Information:</strong>
			<!-- 
			<small>
				&#160;&#160;Title, Year, Funds, Project State and Institution Type should be mandatory to submit.
			</small>
			-->			
			<tr>
            <td COLSPAN="2" nowrap="true"><strong>Project Number:</strong>&#160;&#160;<xsl:value-of select="@projNum"/> <font SIZE="-1"><i> (Type: State Report, Region: <xsl:value-of select="@regionText"/>)</i></font></td>
          </tr>
			<tr>
				<td COLSPAN="2" nowrap="true">
					<strong>Project Title:</strong>&#160;&#160;
					<INPUT type="text" name="projectTitle" size="50" maxLength="255" value="{title} " onkeypress="WarnUser()"/>
					<!-- <small>&#160;&#160;Please enter in title format. (e.g., Timing of Cover Crop Plantings.)</small> -->
				</td>
			</tr>
			<tr>
				&#160;&#160;&#160;&#160;
				<td COLSPAN="4" nowrap="true">
					Calendar Year :&#160;&#160;
					<xsl:choose>
						<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
							<INPUT type="text" name="projEndYear" size="5" maxLength="5" value="{$projEndYear}" onchange="WarnUser()" onkeypress="return numbersonly(event, true)"/>
						</xsl:when>
						<xsl:otherwise>
							<INPUT type="text" readonly="readonly" disabled="disabled" name="projEndYear" size="5" maxLength="5" value="{$projEndYear}"/>
						</xsl:otherwise>
					</xsl:choose>
					&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					State/Protectorate:
					<!-- &#160;&#160;<INPUT type="text" name="strStatePro" size="10" maxLength="255" value="{statePro} " onkeypress="WarnUser()"/> -->
					<select name="strStatePro">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
					   <xsl:call-template name="option">
						 <xsl:with-param name="selected"><xsl:value-of select="$statePro"/></xsl:with-param>
						 <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
						 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
					   </xsl:call-template>
					</xsl:for-each>
					</select>
				</td>
			</tr>
			<tr>
				&#160;&#160;&#160;&#160;
				<td COLSPAN="4" nowrap="true">
					SARE Funds :&#160;&#160;$&#160;&#160;
					<xsl:if test="funds/SARE = '0.0'">
						<INPUT type="text" name="fundsSARE" size="12" maxLength="12" value="0" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
						<small>&#160;&#160;Please enter the dollar amount of your grant without a comma or dollar sign. (e.g., 1234.56)</small>

					</xsl:if>
					<xsl:if test="funds/SARE != '0.0'">

						<INPUT type="text" name="fundsSARE" size="12" maxLength="12" value="{$fundsSARE}" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
						<small>&#160;&#160;Please enter the dollar amount of your grant without a comma or dollar sign. (e.g., 1234.56)</small>

					</xsl:if>
				</td>
			</tr>
			<tr>
				<td COLSPAN="2" nowrap="true">					
					<xsl:for-each select="/SAREroot/user[@context='projectpis']">
						<xsl:if test="(position( )) = 1">
							<br/>
							<strong>Coordinator:</strong>&#160;
							<a href="?do=viewstatecoordinator&amp;user={@username}">
								<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
								&#160;&#160;&#160;(View Details)
							</a>&#160;
              <!-- 
              <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
                <a href="?do=addcoordinator&amp;type=grant&amp;pn={@projNum}">Add a Coordinator</a>;&#160;
              </xsl:if>
              -->
              <br/>
							Ethnicity (Optional):
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hispanic = 'True'">
									<input name="ethinicity" value="hispanic" type="radio" checked="checked"/>Hispanic or Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity" value="hispanic" type="radio"/>Hispanic or Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/nothispanic = 'True'">
									<input name="ethinicity" value="nothispanic" type="radio" checked="checked"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity" value="nothispanic" type="radio"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<!-- 
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/nothispanic = 'False' and /SAREroot/pdpInfoDetails/hispanic = 'False'">
									<input name="ethinicity" value="nonchoosen" type="radio" checked="checked"/>No Answer
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity" value="nonchoosen" type="radio"/>No Answer
								</xsl:otherwise>
							</xsl:choose>
							-->
							<br/>
							Race (Optional):&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/asian = 'True'">
									<input name="race" value="asian" type="radio" checked="yes" id="r1"/>Asian&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="asian" type="radio" id="r1"/>Asian&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/white = 'True'">
									<input name="race" value="white" type="radio" checked="yes" id="r2"/>White&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="white" type="radio" id="r2" />White&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hawaiian = 'True'">
									<input name="race" value="hawaiian" type="radio" checked="yes" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="hawaiian" type="radio" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/black = 'True'">
									<input name="race" value="black" type="radio" checked="yes" id="r4"/>Black or African American&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="black" type="radio" id="r4"/>Black or African American&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/american = 'True'">
									<input name="race" value="american" type="radio" checked="yes" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="american" type="radio" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							Institution Name:&#160;&#160;<INPUT type="text" name="instituteName" size="80" maxLength="255" value="{$institute} " onkeypress="WarnUser()"/>
							<br/>
							Institution Type:&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1862 = 'True'">
									<input name="Grant1862" type="checkbox" checked="yes"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1862" type="checkbox"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1890 = 'True'">
									&#160;&#160;<input name="Grant1890" type="checkbox" checked="yes"/>1890 Land Grant Universities
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1890" type="checkbox"/>1890 Land Grant Universities
								</xsl:otherwise>
							</xsl:choose>
							<br/>
						</xsl:if>
						<xsl:if test="(position( )) = 2">
							<br/>
							<strong>Coordinator :</strong>&#160;
							<a href="?do=viewstatecoordinator&amp;user={@username}">
								<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
								&#160;&#160;&#160;(View Details)
							</a>&#160;             	 
							<br/>
							Ethnicity (Optional):
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hispanic2 = 'True'">
									<input name="ethinicity2" value="hispanic" type="radio" checked="checked"/>Hispanic or Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity2" value="hispanic" type="radio"/>Hispanic or Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/nothispanic2 = 'True'">
									<input name="ethinicity2" value="nothispanic" type="radio" checked="checked"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity2" value="nothispanic" type="radio"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							Race (Optional):&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/asian2 = 'True'">
									<input name="race2" value="asian" type="radio" checked="yes" id="r1"/>Asian&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race2" value="asian" type="radio" id="r1"/>Asian&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/white2 = 'True'">
									<input name="race2" value="white" type="radio" checked="yes" id="r2"/>White&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race2" value="white" type="radio" id="r2" />White&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hawaiian2 = 'True'">
									<input name="race2" value="hawaiian" type="radio" checked="yes" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race2" value="hawaiian" type="radio" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/black2 = 'True'">
									<input name="race2" value="black" type="radio" checked="yes" id="r4"/>Black or African American&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race2" value="black" type="radio" id="r4"/>Black or African American&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/american2 = 'True'">
									<input name="race2" value="american" type="radio" checked="yes" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race2" value="american" type="radio" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							Institution Name:&#160;&#160;<INPUT type="text" name="instituteName2" size="80" maxLength="255" value="{$institute2} " onkeypress="WarnUser()"/>
							<br/>
							Institution Type:&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1862_2 = 'True'">
									<input name="Grant1862_2" type="checkbox" checked="yes"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1862_2" type="checkbox"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1890_2 = 'True'">
									&#160;&#160;<input name="Grant1890_2" type="checkbox" checked="yes"/>1890 Land Grant Universities
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1890_2" type="checkbox"/>1890 Land Grant Universities
								</xsl:otherwise>
							</xsl:choose>
							<br/>
						</xsl:if>

						<xsl:if test="(position( )) = 3">
							<br/>
							<strong>Coordinator :</strong>&#160;
							<a href="?do=viewstatecoordinator&amp;user={@username}">
								<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
								&#160;&#160;&#160;(View Details)
							</a>&#160;							
							<br/>
							Ethnicity (Optional):
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hispanic3 = 'True'">
									<input name="ethinicity3" value="hispanic" type="radio" checked="checked"/>Hispanic or Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity3" value="hispanic" type="radio"/>Hispanic or Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/nothispanic3 = 'True'">
									<input name="ethinicity3" value="nothispanic" type="radio" checked="checked"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="ethinicity3" value="nothispanic" type="radio"/>Not-Hispanic or Not-Latino&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							Race (Optional):&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/asian3 = 'True'">
									<input name="race3" value="asian" type="radio" checked="yes" id="r1"/>Asian&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race3" value="asian" type="radio" id="r1"/>Asian&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/white2 = 'True'">
									<input name="race3" value="white" type="radio" checked="yes" id="r2"/>White&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race3" value="white" type="radio" id="r2" />White&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hawaiian3 = 'True'">
									<input name="race3" value="hawaiian" type="radio" checked="yes" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race3" value="hawaiian" type="radio" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/black3 = 'True'">
									<input name="race3" value="black" type="radio" checked="yes" id="r4"/>Black or African American&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race3" value="black" type="radio" id="r4"/>Black or African American&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/american3 = 'True'">
									<input name="race3" value="american" type="radio" checked="yes" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race3" value="american" type="radio" id="r5"/>American Indian or Alaskan Native&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<br/>
							Institution Name:&#160;&#160;<INPUT type="text" name="instituteName3" size="80" maxLength="255" value="{$institute3} " onkeypress="WarnUser()"/>
							<br/>
							Institution Type:&#160;
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1862_3 = 'True'">
									<input name="Grant1862_3" type="checkbox" checked="yes"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1862_3" type="checkbox"/>1862 Land Grant&#160;&#160;&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/Grant1890_3 = 'True'">
									&#160;&#160;<input name="Grant1890_3" type="checkbox" checked="yes"/>1890 Land Grant Universities
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;<input name="Grant1890_3" type="checkbox"/>1890 Land Grant Universities
								</xsl:otherwise>
							</xsl:choose>
						</xsl:if>
						<xsl:if test="(position( )) > 3">
							<br/>
							<strong>Coordinator(s):</strong>&#160;
							<a href="?do=viewstatecoordinator&amp;user={@username}">
								<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
								&#160;&#160;&#160;(View Details)
							</a>;&#160;
						</xsl:if>
					</xsl:for-each>
					<xsl:choose>
						<xsl:when test="not(../nonusercontact[@context='projectpis'])">
						</xsl:when>
						<xsl:otherwise>
							<xsl:for-each select="../nonusercontact[@context='projectpis']">

								<a href="?do=editcoordinator&amp;user={@contactID}">
									<xsl:choose>
										<xsl:when test="firstname != ''">
											<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="organization/@name"/>
										</xsl:otherwise>
									</xsl:choose>
								</a>;&#160;
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
					<!--<a href="?do=addcoordinator&amp;type=grant&amp;pn={@projNum}">Add State Coordinator</a>;&#160;-->
				</td>
			</tr>
			<!-- 
			<tr>
				<td COLSPAN="4" nowrap="true">
					First Name :&#160;&#160;<INPUT type="text" name="coordFirst" size="50" maxLength="255" value="{$coordfirst} " onkeypress="WarnUser()"/>
				</td>
			</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					Last Name :&#160;&#160;<INPUT type="text" name="coordLast" size="80" maxLength="255" value="{$coordlast} " onkeypress="WarnUser()"/>
				</td>
			</tr>
			-->
		 
			<!--
			<tr>
				<td COLSPAN="4" nowrap="true">
					State/Protectorate:
					&#160;&#160;<INPUT type="text" name="strStatePro" size="10" maxLength="255" value="{statePro} " onkeypress="WarnUser()"/>
				</td>
			</tr>
			 
			<tr>
			<td COLSPAN="4" nowrap="true">Project Coordinator Ethnicity (Optional):
			
			<xsl:choose>
				<xsl:when test="/SAREroot/pdpInfoDetails/hispanic = 'True'">
					<input name="ethinicity" value="hispanic" type="radio" checked="checked"/>Hispanic or Latino&#160;&#160;
				</xsl:when>
				<xsl:otherwise>
					<input name="ethinicity" value="hispanic" type="radio"/>Hispanic or Latino&#160;&#160;
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="/SAREroot/pdpInfoDetails/nothispanic = 'True'">
					<input name="ethinicity" value="nothispanic" type="radio" checked="checked"/>Not-Hispanic or Not-Latino&#160;&#160;
				</xsl:when>
				<xsl:otherwise>
					<input name="ethinicity" value="nothispanic" type="radio"/>Not-Hispanic or Not-Latino&#160;&#160;
				</xsl:otherwise>
			</xsl:choose>
				
			</td>
		</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">Project Coordinator Race (Optional):
					&#160;&#160;&#160;&#160;&#160;
					
					<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/asian = 'True'">
									<input name="race" value="asian" type="radio" checked="yes" id="r1"/>Asian&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="asian" type="radio" id="r1"/>Asian&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/white = 'True'">
									<input name="race" value="white" type="radio" checked="yes" id="r2"/>White&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="white" type="radio" id="r2" />White&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="/SAREroot/pdpInfoDetails/hawaiian = 'True'">
									<input name="race" value="hawaiian" type="radio" checked="yes" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:when>
								<xsl:otherwise>
									<input name="race" value="hawaiian" type="radio" id="r3"/>Native Hawaiian or Other Pacific&#160;&#160;
								</xsl:otherwise>
							</xsl:choose>							
						
				</td>
			</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<xsl:choose>
						<xsl:when test="/SAREroot/pdpInfoDetails/black = 'True'">
							<input name="race" value="black" type="radio" checked="yes" id="r4"/>Black or African American&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<input name="race" value="black" type="radio" id="r4"/>Black or African American&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="/SAREroot/pdpInfoDetails/american = 'True'">
							<input name="race" value="american" type="radio" checked="yes" id="r5"/>American Indian or Alaskan Native&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							<input name="race" value="american" type="radio" id="r5"/>American Indian or Alaskan Native&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
				</td>
			</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">Institution Name:
				&#160;&#160;<INPUT type="text" name="instituteName" size="80" maxLength="255" value="{$institute} " onkeypress="WarnUser()"/>
			</td>
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">Institution Type:
					<xsl:choose>
						<xsl:when test="/SAREroot/pdpInfoDetails/Grant1862 = 'True'">
							&#160;&#160;<input name="Grant1862" type="checkbox" checked="yes"/>1862 Land Grant&#160;&#160;&#160;&#160;
						</xsl:when>
						<xsl:otherwise>
							&#160;&#160;<input name="Grant1862" type="checkbox"/>1862 Land Grant&#160;&#160;&#160;&#160;
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="/SAREroot/pdpInfoDetails/Grant1890 = 'True'">
							&#160;&#160;<input name="Grant1890" type="checkbox" checked="yes"/>1890 Land Grant Universities
						</xsl:when>
						<xsl:otherwise>
							&#160;&#160;<input name="Grant1890" type="checkbox"/>1890 Land Grant Universities
						</xsl:otherwise>
					</xsl:choose>
			</td>
		</tr>
		-->
		<!-- 
		<tr>
		<td COLSPAN="4" nowrap="true">Street Address:
					&#160;&#160;<INPUT type="text" name="strAddress" size="80" maxLength="255" value="{$address} " onkeypress="WarnUser()"/>
				</td>
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">City:&#160;&#160;<INPUT type="text" name="strCity" size="30" maxLength="255" value="{$city} " onkeypress="WarnUser()"/>
					State:&#160;&#160;
				<select name="addrState">
					<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
					   <xsl:call-template name="option">
						 <xsl:with-param name="selected"><xsl:value-of select="$state"/></xsl:with-param>
						 <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
						 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
					   </xsl:call-template>
					</xsl:for-each>
				</select>
					Zip Code:&#160;&#160;<INPUT type="text" name="strZip" size="10" maxLength="255" value="{$zip} " onkeypress="WarnUser()"/>
			</td>				
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">Phone:&#160;&#160;<INPUT type="text" name="strPhone" size="30" maxLength="255" value="{$phone} " onkeypress="WarnUser()"/>
					Fax:&#160;&#160;<INPUT type="text" name="strFax" size="30" maxLength="255" value="{$fax} " onkeypress="WarnUser()"/>
			</td>
		</tr>
		<tr>
				<td COLSPAN="4" nowrap="true">
					Email:&#160;&#160;<INPUT type="text" name="strEmail" size="80" maxLength="255" value="{$email} " onkeypress="WarnUser()"/>
				</td>
		</tr>
			
			<br/>
			-->			
        </table>
        
        <p>
        <table CELLSPACING="0" CELLPADDING="2" CLASS="NORM">
          <tr>
            <td COLSPAN="4" nowrap="true">
				<strong>2) Advisory Committee:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</strong>
			</td>
          </tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					&#160;First Name&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Last Name&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Affiliation
				</td>
			</tr>
			<tr>
				<td>
					<INPUT type="text" name="AdvName" size="25" maxLength="255" value="{$advname} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLName" value="{$AdvLName}"   size="25" maxLength="255" onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<!-- <INPUT type="text" name="AdvAff" size="30" maxLength="255" value="{$advaff} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160; -->
					<SELECT name="AdvAff" id="AdvAff" value="{$advaff} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$advaff = 'Agency'">
								<option value="Agency" selected="selected">Agency</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Agency">Agency</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff = 'Extension'">
								<option value="Extension" selected="selected">Extension</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Extension">Extension</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff = 'Farmer/Rancher'">
								<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Farmer/Rancher">Farmer/Rancher</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff = 'NGO'">
								<option value="NGO" selected="selected">NGO</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="NGO">NGO</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff = 'NRCS'">
								<option value="NRCS" selected="selected">NRCS</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="NRCS">NRCS</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff = 'Other'">
								<option value="Other" selected="selected">Other</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Other">Other</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<INPUT type="text" name="AdvName1" size="25" maxLength="255" value="{$advname1} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLName1" size="25" maxLength="255" value="{$AdvLName1} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<!-- <INPUT type="text" name="AdvAff1" size="30" maxLength="255" value="{$advaff1} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;-->
					<SELECT name="AdvAff1" id="AdvAff1" value="{$advaff1} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'Agency'">
								<option value="Agency" selected="selected">Agency</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Agency">Agency</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'Extension'">
								<option value="Extension" selected="selected">Extension</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Extension">Extension</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'Farmer/Rancher'">
								<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Farmer/Rancher">Farmer/Rancher</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'NGO'">
								<option value="NGO" selected="selected">NGO</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="NGO">NGO</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'NRCS'">
								<option value="NRCS" selected="selected">NRCS</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="NRCS">NRCS</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$advaff1 = 'Other'">
								<option value="Other" selected="selected">Other</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Other">Other</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
				</td>
		</tr>
		<tr>
			<td>
				<INPUT type="text" name="AdvName2" size="25" maxLength="255" value="{$advname2} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
				<INPUT type="text" name="AdvLName2" size="25" maxLength="255" value="{$AdvLName2} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
				<!-- <INPUT type="text" name="AdvAff2" size="30" maxLength="255" value="{$advaff2} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;-->
				<SELECT name="AdvAff2" id="AdvAff2" value="{$advaff2} " size="1">
					<OPTION value=""></OPTION>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'Agency'">
							<option value="Agency" selected="selected">Agency</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="Agency">Agency</option>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'Extension'">
							<option value="Extension" selected="selected">Extension</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="Extension">Extension</option>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'Farmer/Rancher'">
							<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="Farmer/Rancher">Farmer/Rancher</option>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'NGO'">
							<option value="NGO" selected="selected">NGO</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="NGO">NGO</option>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'NRCS'">
							<option value="NRCS" selected="selected">NRCS</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="NRCS">NRCS</option>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$advaff2 = 'Other'">
							<option value="Other" selected="selected">Other</option>
						</xsl:when>
						<xsl:otherwise>
							<option value="Other">Other</option>
						</xsl:otherwise>
					</xsl:choose>
				</SELECT>&#160;&#160;&#160;&#160;
			</td>
		</tr>
			<tr>
					<td>
						<INPUT type="text" name="AdvName3" size="25" maxLength="255" value="{$advname3} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName3" size="25" maxLength="255" value="{$AdvLName3} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<!-- <INPUT type="text" name="AdvAff3" size="30" maxLength="255" value="{$advaff3} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160; -->
						<SELECT name="AdvAff3" id="AdvAff3" value="{$advaff3} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff3 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
					</td>
				</tr>
				<tr>
					<td>
						<INPUT type="text" name="AdvName4" size="25" maxLength="255" value="{$advname4} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName4" size="25" maxLength="255" value="{$AdvLName4} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<!-- <INPUT type="text" name="AdvAff4" size="30" maxLength="255" value="{$advaff4} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160; -->
						<SELECT name="AdvAff4" id="AdvAff4" value="{$advaff4} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff4 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
					</td>
				</tr>
				<tr>
					<td>
						<INPUT type="text" name="AdvName5" size="25" maxLength="255" value="{$advname5} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName5" size="25" maxLength="255" value="{$AdvLName5} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<!-- <INPUT type="text" name="AdvAff5" size="30" maxLength="255" value="{$advaff5} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160; -->
						<SELECT name="AdvAff5" id="AdvAff5" value="{$advaff5} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff5 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
					</td>
				</tr>
				<tr>
					<td>
						<INPUT type="text" name="AdvName6" size="25" maxLength="255" value="{$advname6} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName6" size="25" maxLength="255" value="{$AdvLName6} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<!-- <INPUT type="text" name="AdvAff6" size="30" maxLength="255" value="{$advaff6} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160; -->
						<SELECT name="AdvAff6" id="AdvAff6" value="{$advaff6} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff6 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
					</td>
				</tr>

			<tr>
				<td>
					<p>
						<strong>More Advisory Committee(s)</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('mydiv');">+/-</a>
					</p>						
				
					<div class="wrapper" id="mydiv" style="display:none">
						<INPUT type="text" name="AdvName7" size="25" maxLength="255" value="{$advname7} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName7" size="25" maxLength="255" value="{$AdvLName7} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff7" id="AdvAff7" value="{$advaff7} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff7 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName8" size="25" maxLength="255" value="{$advname8} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName8" size="25" maxLength="255" value="{$AdvLName8} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff8" id="AdvAff8" value="{$advaff8} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff8 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName9" size="25" maxLength="255" value="{$advname9} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName9" size="25" maxLength="255" value="{$AdvLName9} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff9" id="AdvAff9" value="{$advaff9} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff9 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName10" size="25" maxLength="255" value="{$advname10} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName10" size="25" maxLength="255" value="{$AdvLName10} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff10" id="AdvAff10" value="{$advaff10} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff10 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName11" size="25" maxLength="255" value="{$advname11} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName11" size="25" maxLength="255" value="{$AdvLName11} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff11" id="AdvAff11" value="{$advaff11} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff11 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName12" size="25" maxLength="255" value="{$advname12} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName12" size="25" maxLength="255" value="{$AdvLName12} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff12" id="AdvAff12" value="{$advaff12} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff12 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName13" size="25" maxLength="255" value="{$advname13} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName13" size="25" maxLength="255" value="{$AdvLName13} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff13" id="AdvAff13" value="{$advaff13} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff13 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName14" size="25" maxLength="255" value="{$advname14} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName14" size="25" maxLength="255" value="{$AdvLName14} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff14" id="AdvAff14" value="{$advaff14} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff14 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
						<br></br>
						<INPUT type="text" name="AdvName15" size="25" maxLength="255" value="{$advname15} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<INPUT type="text" name="AdvLName15" size="25" maxLength="255" value="{$AdvLName15} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
						<SELECT name="advaff15" id="AdvAff15" value="{$advaff15} " size="1">
							<OPTION value=""></OPTION>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'Agency'">
									<option value="Agency" selected="selected">Agency</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Agency">Agency</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'Extension'">
									<option value="Extension" selected="selected">Extension</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Extension">Extension</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'Farmer/Rancher'">
									<option value="Farmer/Rancher" selected="selected">Farmer/Rancher</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Farmer/Rancher">Farmer/Rancher</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'NGO'">
									<option value="NGO" selected="selected">NGO</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NGO">NGO</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'NRCS'">
									<option value="NRCS" selected="selected">NRCS</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="NRCS">NRCS</option>
								</xsl:otherwise>
							</xsl:choose>
							<xsl:choose>
								<xsl:when test="$advaff15 = 'Other'">
									<option value="Other" selected="selected">Other</option>
								</xsl:when>
								<xsl:otherwise>
									<option value="Other">Other</option>
								</xsl:otherwise>
							</xsl:choose>
						</SELECT>&#160;&#160;&#160;&#160;
					</div>
				</td>
			</tr>

			<tr>
				<td colspan="2"/>
			</tr>

			<tr>
				<td COLSPAN="4" nowrap="true">
					<strong>3) Advisory Committee Meetings:</strong>
				</td>
			</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					&#160;&#160;&#160;Date&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Type&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Location-City&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Location-State&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Location-Zip
			</td>
		</tr>
		<tr>
			<td>
				<xsl:if test="$advdate != ''">
					<input name="AdvDate" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate', document.projDetails.AdvDate.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate = ''">
						<input name="AdvDate" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate', document.projDetails.AdvDate.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType" id="AdvType" value="{$AdvType} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation" size="20" maxLength="255" value="{$advloc} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip" value="{$AdvLocationZip}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate1 != ''">
						<input name="AdvDate1" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate1}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate1', document.projDetails.AdvDate1.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate1 = ''">
						<input name="AdvDate1" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate1', document.projDetails.AdvDate1.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType1" id="AdvType1" value="{$AdvType1} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType1 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType1 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation1" size="20" maxLength="255" value="{$advloc1} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState1">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState1"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip1" value="{$AdvLocationZip1}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate2 != ''">
						<input name="AdvDate2" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate2}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate2', document.projDetails.AdvDate2.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate2 = ''">
						<input name="AdvDate2" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate2', document.projDetails.AdvDate2.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType2" id="AdvType2" value="{$AdvType2} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType2 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType2 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation2" size="20" maxLength="255" value="{$advloc2} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState2">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState2"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip2" value="{$AdvLocationZip2}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate3 != ''">
						<input name="AdvDate3" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate3}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate3', document.projDetails.AdvDate3.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate3 = ''">
						<input name="AdvDate3" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate3', document.projDetails.AdvDate3.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType3" id="AdvType3" value="{$AdvType3} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType3 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType3 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation3" size="20" maxLength="255" value="{$advloc3} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState3">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState3"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip3" value="{$AdvLocationZip3}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate4 != ''">
						<input name="AdvDate4" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate4}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate4', document.projDetails.AdvDate4.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate4 = ''">
						<input name="AdvDate4" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate4', document.projDetails.AdvDate4.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType4" id="AdvType4" value="{$AdvType4} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType4 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType4 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation4" size="20" maxLength="255" value="{$advloc4} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState4">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState4"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip4" value="{$AdvLocationZip4}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate5 != ''">
						<input name="AdvDate5" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate5}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate5', document.projDetails.AdvDate5.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate5 = ''">
						<input name="AdvDate5" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate5', document.projDetails.AdvDate5.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType5" id="AdvType5" value="{$AdvType5} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType5 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType5 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation5" size="20" maxLength="255" value="{$advloc5} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState5">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState5"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip5" value="{$AdvLocationZip5}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td>
					<xsl:if test="$advdate6 != ''">
						<input name="AdvDate6" maxlength="12" size="7" value="{/SAREroot/pdpInfoDetails/advdate6}"/>&#160;
						<a href="javascript:show_calendar4('document.projDetails.AdvDate6', document.projDetails.AdvDate6.value);">
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<xsl:if test="$advdate6 = ''">
						<input name="AdvDate6" maxlength="12" size="7" value=""/>
						<a href="javascript:show_calendar4('document.projDetails.AdvDate6', document.projDetails.AdvDate6.value);">&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;
					</xsl:if>
					<SELECT name="AdvType6" id="AdvType6" value="{$AdvType6} " size="1">
						<OPTION value=""></OPTION>
						<xsl:choose>
							<xsl:when test="$AdvType6 = 'Face to face'">
								<option value="Face to face" selected="selected">Face to face</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Face to face">Face to face</option>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:choose>
							<xsl:when test="$AdvType6 = 'Teleconference'">
								<option value="Teleconference" selected="selected">Teleconference</option>
							</xsl:when>
							<xsl:otherwise>
								<option value="Teleconference">Teleconference</option>
							</xsl:otherwise>
						</xsl:choose>
					</SELECT>&#160;&#160;&#160;&#160;
					<INPUT type="text" name="AdvLocation6" size="20" maxLength="255" value="{$advloc6} " onkeypress="WarnUser()"/>&#160;&#160;&#160;&#160;
					<select name="AdvLocationState6">
						<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$AdvLocationState6"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
						</xsl:for-each>
					</select>&#160;&#160;&#160;&#160;
					<INPUT name="AdvLocationZip6" value="{$AdvLocationZip6}" size="5" maxLength="5" onkeypress="return numbersonly(event,false)"/>&#160;&#160;&#160;&#160;
				</td>
			</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					<br/>
					<strong>4) Face of SARE/Outreach:</strong>&#160;&#160;Describe your outreach and promotional efforts of the SARE Program:
				</td>
			</tr>
			<tr>
				<td COLSPAN="4" nowrap="true">
					<textarea style="border:solid 1px BFBCA0;width:100%" id="initOut" name="initOut">
						<!-- <xsl:value-of disable-output-escaping="yes" select="$initOut"/> -->
						<xsl:call-template name="break">
							<xsl:with-param name="text" select="$initOut"/>
						</xsl:call-template>
						</textarea>
				</td>
			</tr>
			<tr>
				<td colspan="2"/>&#160;&#160;&#160;
			</tr>

			<tr>
				<td COLSPAN="3">
					<xsl:choose>
						<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
							<xsl:choose>
								<xsl:when test="$pdpid != '0'">
									<button type="submit" name="btnUpdatePDPBasics" value="Save" onclick="NoPrompt()">Update General Information</button>
								</xsl:when>
								<xsl:otherwise>
									<button type="submit" name="btnSavePDPBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:when>
						<xsl:otherwise>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="True" and /SAREroot/SAREgrant/funds/Submitted="False"'>
								<xsl:choose>
									<xsl:when test="$pdpid != '0'">
										<button type="submit" name="btnUpdatePDPBasics" value="Save" onclick="NoPrompt()">Update General Information</button>
									</xsl:when>
									<xsl:otherwise>
										<button type="submit" name="btnSavePDPBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:if>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="False"'>
								<xsl:choose>
									<xsl:when test="$pdpid != '0'">
										<button type="submit" name="btnUpdatePDPBasics" value="Save" onclick="NoPrompt()">Update General Information</button>
									</xsl:when>
									<xsl:otherwise>
										<button type="submit" name="btnSavePDPBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:if>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="True"'>
								<xsl:choose>
									<xsl:when test="$pdpid != '0'">
										<button type="submit" name="btnUpdatePDPBasics" value="Save" onclick="NoPrompt()">Update General Information</button>
									</xsl:when>
									<xsl:otherwise>
										<button type="submit" name="btnSavePDPBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$pdpid != '0'">
							<small>&#160;&#160;Note: Click “Update General Information” before leaving this page to save edits in the fields above.</small>
						</xsl:when>
						<xsl:otherwise>
							<small>&#160;&#160;Note: Click “Save General Information” before leaving this page to save edits in the fields above.</small>
						</xsl:otherwise>
					</xsl:choose>
				</td>
			</tr>    
			
        </table>
        </p>
		
			
			<table CLASS="NORM">
				<tr>
					<td>
					</td>
				</tr>
			</table>

		  <p>
			  <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">

				  <tr>
					  <td>
						  <p class="pagetitle">Initiatives and Partners</p>
					  </td>
				  </tr>

				  <xsl:choose>
					  <xsl:when test="not(report[@type=2])">

						  <tr>
							  <td>
								  Click the Add Training Initiative link below to add and report project training and educational initiatives.
								  <br/>
								  <xsl:if test="$InitiativeCount = '0'">

									  <xsl:choose>
										  <xsl:when test="$pdpinitid = 'True'">
											  <xsl:if test="$pdpinititle != ''">
												  <a href="?do=pdpinit&amp;pn={@projNum}">
													  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
												  </a>
												  <br/>
											  </xsl:if>
											  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
												  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 1"/> -->
												  Add Training Initiative
											  </a>
										  </xsl:when>
										  <xsl:otherwise>
											  <xsl:if test="$pdpid = '0'">
												  <a href="?do=pdpinit&amp;pn={@projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('You must save the initiative’s general information before creating activities .');return false">
													  Create Initiative
												  </a>
											  </xsl:if>
											  <xsl:if test="$pdpid != '0'">
												  <a href="?do=pdpinit&amp;pn={@projNum}">
													  Create Initiative
												  </a>
											  </xsl:if>
										  </xsl:otherwise>
									  </xsl:choose>

								  </xsl:if>

								  <xsl:if test="$InitiativeCount = '1'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
										  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 2"/> -->
										  Add Training Initiative
									  </a>

								  </xsl:if>
								  <xsl:if test="$InitiativeCount = '2'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle2 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
											  <xsl:value-of select="$pdpinititle2"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=3">
										  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 3"/> -->
										  Add Training Initiative
									  </a>

								  </xsl:if>
								  <xsl:if test="$InitiativeCount = '3'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle2 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
											  <xsl:value-of select="$pdpinititle2"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle3 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=3">
											  <xsl:value-of select="$pdpinititle3"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=4">
										  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 4"/> -->
										  Add Training Initiative
									  </a>

								  </xsl:if>
								  <xsl:if test="$InitiativeCount = '4'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle2 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
											  <xsl:value-of select="$pdpinititle2"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle3 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=3">
											  <xsl:value-of select="$pdpinititle3"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle4 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=4">
											  <xsl:value-of select="$pdpinititle4"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=5">
										  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 5"/> -->
										  Add Training Initiative
									  </a>

								  </xsl:if>
								  <xsl:if test="$InitiativeCount = '5'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle2 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
											  <xsl:value-of select="$pdpinititle2"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle3 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=3">
											  <xsl:value-of select="$pdpinititle3"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle4 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=4">
											  <xsl:value-of select="$pdpinititle4"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle5 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=5">
											  <xsl:value-of select="$pdpinititle5"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=6">
										  <!-- <input name="cmdAddNewInitiative" type="submit" value="Add Initiative 6"/> -->
										  Add Training Initiative
									  </a>

								  </xsl:if>
								  <xsl:if test="$InitiativeCount = '6'">
									  <xsl:if test="$pdpinititle != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}">
											  <xsl:value-of select="$pdpinititle"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle1 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=1">
											  <xsl:value-of select="$pdpinititle1"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle2 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=2">
											  <xsl:value-of select="$pdpinititle2"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle3 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=3">
											  <xsl:value-of select="$pdpinititle3"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle4 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=4">
											  <xsl:value-of select="$pdpinititle4"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <xsl:if test="$pdpinititle5 != ''">
										  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=5">
											  <xsl:value-of select="$pdpinititle5"></xsl:value-of>&#160;&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <br/>
									  </xsl:if>
									  <a href="?do=pdpinit&amp;pn={@projNum}&amp;initNum=6">
										  Edit/View Initiative/Topic(s) - 6&#160;&#160;&#160;&#160;&#160;&#160;
									  </a>

								  </xsl:if>
							  </td>
						  </tr>
					  </xsl:when>
					  <xsl:otherwise>
						  <xsl:for-each select="report[@type=2]">
							  <tr>
								  <td>
									  &#160;&#160;&#160;
									  <xsl:choose>
										  <xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
											  <!-- 
							<a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
								Edit 
							</a>&#160;&#160;|&#160;&#160;
							-->
											  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
												  Preview
											  </a>
										  </xsl:when>
										  <xsl:otherwise>
											  <xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="True"'>
												  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}" onclick="javascript:alert('Your project overview is pending approval. You cannot edit the project until a regional administrator approves your previous submission.'); return false;">
													  Edit
												  </a>&#160;&#160;|&#160;&#160;
												  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
													  Preview
												  </a>
											  </xsl:if>
											  <xsl:if test='/SAREroot/SAREgrant/funds/Approved="True" and /SAREroot/SAREgrant/funds/Submitted="False"'>
												  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
													  Edit
												  </a>&#160;&#160;|&#160;&#160;
												  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
													  Preview
												  </a>
											  </xsl:if>
											  <xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="False"'>
												  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
													  Edit
												  </a>&#160;&#160;|&#160;&#160;
												  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
													  Preview
												  </a>
											  </xsl:if>
										  </xsl:otherwise>
									  </xsl:choose>

								  </td>
							  </tr>
						  </xsl:for-each>
					  </xsl:otherwise>
				  </xsl:choose>
			  </table>
			  </p>

		  <table CLASS="NORM">
			  <tr>
				  <td>
				  </td>
			  </tr>
		  </table>
		  
		  <p>
			  <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
				
			 <tr>
            <td>
				<p class="pagetitle">Report Summary</p>				
			</td>
			</tr>
		
          <tr>
            <td>
				Click the Create Outcome Narrative link below to summarize outcomes for all project activities.
				<br/>
				<xsl:choose>
					<xsl:when test="$pdpoutid = 'True'">
						<a href="?do=pdpoutnarrative&amp;pn={@projNum}">
							Edit/View Report Summary
						</a>
					  </xsl:when>
					  <xsl:otherwise>
						  <xsl:if test="$pdpid = '0'">
							  <a href="?do=pdpoutnarrative&amp;pn={@projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('You must save the initiative’s general information before creating outcome narrative.');return false">
								  Create Report Summary
							  </a>
						  </xsl:if>
						  <xsl:if test="$pdpid != '0'">
							  <a href="?do=pdpoutnarrative&amp;pn={@projNum}">
								  Create Report Summary
							  </a>
						  </xsl:if>
					  </xsl:otherwise>
				  </xsl:choose>
			 
			  
				<br/>				
			</td>
		</tr>
		
			 <p>
				 <tr>
					 <td>
						 <xsl:choose>
							 <xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
								 <xsl:choose>
									 <xsl:when test='funds/Submitted="True" or $useradmin="myprojectslist" or $projNarrativeApproved="True"'>
										 <button type="submit" align="center" name="btnPDPDetailsApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Approve</button>&#160;&#160;&#160;&#160;&#160;
										 <button type="submit" align="center" name="btnPDPDetailsNotApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Not Approve</button>
									 </xsl:when>
									 <xsl:when test='(funds/Submitted="False" or funds/Submitted="") and $useradmin="" and ($projNarrativeApproved="False" or $projNarrativeApproved="")'>
										 <button type="submit" align="center" disabled="disabled">Approve</button>&#160;&#160;&#160;&#160;&#160;
										 <button type="submit" align="center" disabled="disabled">Not Approve</button>
										 &#160;&#160;<button type="submit"  name="btnPDPDetailsApprove" value="Submit" align="center">Submit and Approve</button>
									 </xsl:when>
									 <xsl:otherwise>
										 <button type="submit" align="center" disabled="disabled">Approve</button>&#160;&#160;&#160;&#160;&#160;
										 <button type="submit" align="center" disabled="disabled">Not Approve</button>
										 &#160;&#160;<button type="submit"  name="btnPDPDetailsApprove" value="Submit" align="center">Submit and Approve</button>
									 </xsl:otherwise>
								 </xsl:choose>
								 <!-- 
						<xsl:if test='funds/Submitted="True" or $useradmin="myprojectslist" or $projNarrativeApproved="True"'>
							<button type="submit" align="center" name="btnProjectDetailsApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Approve</button>&#160;&#160;&#160;&#160;&#160;
							<button type="submit" align="center" name="btnProjectDetailsNotApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Not Approve</button>
						</xsl:if>
						<xsl:if test='(funds/Submitted="False" or funds/Submitted="") and $useradmin="" and ($projNarrativeApproved="False" or $projNarrativeApproved="")'>
							<button type="submit" align="center" disabled="disabled">Approve</button>&#160;&#160;&#160;&#160;&#160;
							<button type="submit" align="center" disabled="disabled">Not Approve</button>
						</xsl:if>
						-->
							 </xsl:when>
							 <xsl:otherwise>
								 <xsl:if test='funds/Approved="False" and funds/Submitted="True"'>
									 <button type="submit" align="center" disabled="disabled">Submit</button>
								 </xsl:if>
								 <xsl:if test='funds/Submitted="False" or funds/Submitted=""'>
									 <button type="submit" align="center" name="btnPDPDetailsSubmit" value="Submit">Submit</button>
								 </xsl:if>
								 <xsl:if test='funds/Approved="True" and funds/Submitted="True"'>
									 <button type="submit" align="center" name="btnPDPDetailsSubmit" value="Submit">Submit</button>
								 </xsl:if>
							 </xsl:otherwise>
						 </xsl:choose>
						 &#160;&#160;&#160;
						 <xsl:choose>
							 <xsl:when test='funds/Approved="True" and funds/Submitted="False"'>(Approved - Can be resubmitted for approval after edit)</xsl:when>
							 <xsl:when test='funds/Approved="False" and funds/Submitted="True"'>(Pending Approval - Cannot be edited until approved)</xsl:when>
							 <xsl:otherwise>(Working Draft – Has not been submitted)</xsl:otherwise>
						 </xsl:choose>
					 </td>
				 </tr>
			 </p>
        </table>

			  <table CLASS="NORM">
				  <tr>
					  <td>
					  </td>
				  </tr>
			  </table>
			  
        </p>

		  <p>
			  <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
				  <tr>
					  <td>
						  <p class="pagetitle">Project Information Products</p>
					  </td>
				  </tr>
				  <tr>
					  <td>
						  Share books, bulletins, fliers or other resources produced as part of your grant! Click the <a href="?do=infoproddetail&amp;type=grant&amp;pn={@projNum}">Add Information Product</a> link below to enter descriptive information and upload the entire electronic file.
					  </td>
				  </tr>
				  <tr>
					  <xsl:choose>
						  <xsl:when test="not(/SAREroot/productInfo)">
							  <tr>
								  <td>
									  <i>&#160;&#160;&#160;(none)</i>
								  </td>
							  </tr>
						  </xsl:when>
						  <xsl:otherwise>
							  <xsl:for-each select="/SAREroot/productInfo/resource">
								  <tr>
									  <td>
										  <a href="?do=infoproddetail&amp;type=pdp&amp;pn={@projNum}&amp;resourceID={@resourceID}&amp;uploadID={uploadID}">
											  <xsl:value-of select="title"/>&#160;&#160;&#160;&#160;&#160;
										  </a>
										  <xsl:choose>
											  <xsl:when test="uploadID !=''">
												  &#160;&#160;:&#160;&#160;File Uploaded: <xsl:value-of select="file_name_orig"/>
											  </xsl:when>
											  <xsl:otherwise>
												  &#160;&#160;:&#160;&#160;No File Uploaded
											  </xsl:otherwise>
										  </xsl:choose>
										  <!--	
								<xsl:if test="uploadID !=''">
								&#160;&#160;:&#160;&#160;File Uploaded: <xsl:value-of select="file_name"/>
									
								<a href="javascript:openWindow('fileUpload.aspx?fileid={uploadID}','fileupload','640','480','scrollbars','resizable');">
									<xsl:value-of select="file_caption"/>
								</a>
									
								<a href="javascript:void(0);" onclick="window.open(unescape('./assocfiles/{file_name}'),'fileupload','400','300','scrollbars','resizable');">
									<xsl:value-of select="file_caption"/>
								</a>
								</xsl:if>-->&#160;&#160;
										  <xsl:choose>
											  <xsl:when test="submittedstatus = 'True'">
												  (Pending Approval)
											  </xsl:when>
											  <xsl:when test="approvedstatus = 'True'">
												  (Approved)
											  </xsl:when>
											  <xsl:otherwise>
												  (Not Yet Submitted)
											  </xsl:otherwise>
										  </xsl:choose>

									  </td>
								  </tr>
							  </xsl:for-each>
						  </xsl:otherwise>
					  </xsl:choose>


				  </tr>
				  <tr>
					  <td>
						  <xsl:if test="$pdpid = '0'">
							  <a href="?do=infoproddetail&amp;type=pdp&amp;pn={@projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('You must save the initiative’s general information before adding information product.');return false">
								  Add Information Product
							  </a>
						  </xsl:if>
						  <xsl:if test="$pdpid != '0'">
							  <a href="?do=infoproddetail&amp;type=pdp&amp;pn={@projNum}">Add Information Product</a>
						  </xsl:if>
						  <br/>
					  </td>
				  </tr>
			  </table>
		  </p>
			
			
		<xsl:if test="$deleteProj != ''">
			<input name="confDel" type="checkbox" value="true"/>Confirm Delete<br/><br/>
			<INPUT type="submit" name="cmdDeleteProj" id="cmdDeleteProj" value="Delete Project"/>&#160;&#160;&#160;&#160;&#160;&#160;
			<INPUT type="submit" name="btnCancelDelete" id="btnCancelDelete" value="Cancel Delete"/>
		</xsl:if>		
			
       </form>
      </td>
    </tr>
  </table>	
	
	<p>
		<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
			<form name="PDPAssign" METHOD="post">
				<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
					<tr>
						<td>
							<p class="pagetitle">Assign Project Codes:</p>
						</td>
					</tr>
					<tr>

						<td>
							To allow a PI or Co-PI access to this project, enter their email address below and click "Assign Project Code".

							<span class="tooltiptext">
								<a href="/mysare/help/editRept.htm#assign" target="_blank">
									<h3>Assign Project Code</h3>
								</a>
								<p>
									&#160;
								</p>
								<p>
									Use this feature to assign a new project code to a pi or co-pi that has not yet claimed his or her project. Persons who claim a project will be listed as a coordinator in the general information section. Do NOT assign new project codes to pis that have already claimed their project- they can access the project by logging into their MySARE account and clicking My Projects.
								</p>
							</span>
							<br/>
							<input type="text" name="claimRecipient" size="50" maxLength="255"/>&#160;&#160;
							<button type="submit" name="btnAssignClaimCode" value="Assign" onclick="NoPrompt()">Assign Project Code</button>
						</td>

					</tr>
				</xsl:if>
			</form>
		</table>
	</p>
	
</xsl:template>

<xsl:template name="addAnnualRepts">
  <xsl:param name="startYear"/>
  <xsl:param name="endYear"/>
  <xsl:param name="tempYear"><xsl:value-of select="$startYear"/></xsl:param>
  <xsl:param name="needed">false</xsl:param>
  <xsl:param name="submittedOverview"><xsl:value-of select="funds/Submitted"/></xsl:param>
  <xsl:param name="approvedOverview"><xsl:value-of select="funds/Approved"/></xsl:param>
  
  <xsl:choose>
  <xsl:when test="$needed='true'">
    <tr><td>&#160;&#160;&#160;
    <select name="addAnnualReportYear">
      <xsl:call-template name="option">
        <xsl:with-param name="startYear"><xsl:value-of select="$startYear"/></xsl:with-param>
        <xsl:with-param name="endYear"><xsl:value-of select="$endYear"/></xsl:with-param>
      </xsl:call-template>
    </select>
    &#160;
    <input type="submit" name="btnCreateAnnualReport" value="Create New" onclick ="return checkForOverview('{$submittedOverview}','{$approvedOverview}')"/>
    </td></tr>
  </xsl:when>
  <xsl:otherwise>
    <xsl:if test="$tempYear &lt; ($endYear+1)">
      <xsl:choose>
      <xsl:when test="not(report[@year=$tempYear])">
        <xsl:call-template name="addAnnualRepts">
          <xsl:with-param name="startYear"><xsl:value-of select="$startYear"/></xsl:with-param>
          <xsl:with-param name="endYear"><xsl:value-of select="$endYear"/></xsl:with-param>
          <xsl:with-param name="needed">true</xsl:with-param>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="addAnnualRepts">
          <xsl:with-param name="startYear" select="$startYear"/>
          <xsl:with-param name="endYear" select="$endYear"/>
          <xsl:with-param name="tempYear" select="$tempYear + 1"/>
        </xsl:call-template>
      </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:otherwise>
  </xsl:choose>

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

<xsl:template name="option2">
<!-- standard option template - creates options for all years from start to end -->
  <xsl:param name="startYear"/>
  <xsl:param name="endYear"/>
  <xsl:variable name="projStartYear" select="@year + 1"/>	
	
  <!-- This Year population for Existing Projects -->	
  <xsl:if test="string($startYear)">
		<xsl:if test="$startYear &lt; ($endYear+1)">
			<option value="{$startYear}">
				<xsl:value-of select="$startYear"/>
			</option>
			<xsl:call-template name="option">
				<xsl:with-param name="startYear" select="$startYear + 1"/>
				<xsl:with-param name="endYear" select="$endYear"/>
			</xsl:call-template>
		</xsl:if>
  </xsl:if>
  
  <!-- This Year population for New Projects Created -->
  <xsl:if test="not(string($startYear))">	  
	  <option value="{$projStartYear}">
		  <xsl:value-of select="@year + 1"/>
	  </option>
		<xsl:call-template name="option">
		  <xsl:with-param name="startYear" select="$projStartYear + 1"/>
		  <xsl:with-param name="endYear" select="$endYear"/>
		</xsl:call-template>	  
  </xsl:if>
	
</xsl:template>

	<xsl:template name="break">
		<xsl:param name="text"/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<!-- <br/> commented becuase going an adding this -->
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
</xsl:stylesheet>







