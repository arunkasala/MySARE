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
	<script LANGUAGE="JavaScript">
		<![CDATA[
var showPrompt = false;
	
	function checkAllParts(projtype, narrative, participants, profile)
	{
		var warning = false;
		
		if (narrative.length == 0)
			warning = true;
		else if (participants.length == 0 && (projtype == 1 || projtype = 2 || projtype == 4 || projtype == 5 || projtype = 6))
			warning = true;
		else if (profile.length == 0)
			warning = true;
		
		if (warning)
		{
			alert('All 4 parts in Project Overview are required before setting this project for Approval.');
			return false;
		}
		else
			return true;		
	}
	
	function checkForApproval(submitted, approved)
	{
		var warning = false;
		
		if (submitted == "False" && approved == "False")
			warning = true;
			
		if (warning)
		{
			alert('Cannot Approve because project is not submitted yet.');	
			return false;
		}
		else
			return true;
	}
	
	function checkForOverview(submitted, approved)
	{
		var warning = false;
		
		if (submitted == "False" && approved == "False")
			warning = true;
					
		if (warning)
		{
			alert('Cannot Create New Report because project overview is not submitted yet.');	
			return false;
		}
		else
			return true;	
	}
	
	function closeIt()
	{
	  if (showPrompt)
		return "Would you like to save your data before leaving this page?";
	}
	window.onbeforeunload=closeIt;
	
	function WarnUser()
	{
		showPrompt = true;
	}
	
	function NoPrompt()
	{
		showPrompt = false;
	}
	
function numbersonly(e, decimal) {
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
   
  else if (decimal && (keychar == ".")) { 
     return true;
   }
   
   else if (decimal && (keychar == ",")) { 
     return true;
   }
  else
      return false;
  }
  
function CommaFormatted(amount)
{
	var delimiter = ","; // replace comma if desired
	var a = amount.split('.',2)
	var d = a[1];
	var i = parseInt(a[0]);
	if(isNaN(i)) { return ''; }
	var minus = '';
	if(i < 0) { minus = '-'; }
	i = Math.abs(i);
	var n = new String(i);
	var a = [];
	while(n.length > 3)
	{
		var nn = n.substr(n.length-3);
		a.unshift(nn);
		n = n.substr(0,n.length-3);
	}
	if(n.length > 0) { a.unshift(n); }
	n = a.join(delimiter);
	if(d.length < 1) { amount = n; }
	else { amount = n + '.' + d; }
	amount = minus + amount;
	return amount;
}

function openWindow(url, name) {
	alert("test");
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

	<p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <!-- <span class="pagetitle">Edit Project Details</span>--><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
	<p class="subtitle">There are three online reporting requirements:
		<ul>
			<li>Project Overview: Must be submitted when you receive notification of the award and prior to receiving grant funds. You must fill in all four sections of the overview, then submit.</li>
			<li>Annual Reports: Must be submitted according to regional reporting requirements.</li>
			<li>Final Report: Must be submitted according to regional reporting requirements at the conclusion of your project.</li>
		</ul>
	</p>
	<xsl:apply-templates select="SAREroot/SAREgrant"/>
</xsl:template>

<xsl:template match="SAREgrant">
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
	<xsl:variable name="projectNumber" select="@projNum"/>
  <xsl:variable name="regionCode" select="@regionCode"/>
  <xsl:variable name ="projNarrativeApproved" select="/SAREroot/SAREgrant/report/@approvedstatus"/>
	<xsl:variable name="statePro" select="/SAREroot/SAREgrant/@projectState"/>
 
 
	
  <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
    <tr>
      <td ALIGN="LEFT" VALIGN="TOP">
		<p class="pagetitle">Project Overview:
		</p>
		<!-- <p><strong>Note: Fields marked with an asterisk (*) are required</strong></p> -->
		 
      </td>
     
    </tr>
    <tr>
      <td>
      <form onsubmit="document.getElementById('addrState').disabled = false;" name="projBasics" METHOD="post">
        <table CLASS="NORM">
			<br/><strong>1) General Information:</strong><br/>
          <tr>
            <td COLSPAN="2" nowrap="true">Project Number</td>
            <td><xsl:value-of select="@projNum"/> <font SIZE="-1"><i> (Type: <xsl:value-of select="@typeText"/>, Region: <xsl:value-of select="@regionText"/>)</i></font></td>
          </tr>
			<tr>
				<td COLSPAN="2" nowrap="true">State</td>
				<td>
					<xsl:choose>
						<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin'] or $statePro = ''">
							<select name="addrState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
								   <xsl:call-template name="optionState">
									 <xsl:with-param name="selected"><xsl:value-of select="$statePro"/></xsl:with-param>
									 <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
									 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
								   </xsl:call-template>
								 </xsl:for-each>
							</select>
						</xsl:when>
						<xsl:otherwise>
							<select id="addrState" name="addrState" disabled="disabled">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
								   <xsl:call-template name="optionState">
									 <xsl:with-param name="selected"><xsl:value-of select="$statePro"/></xsl:with-param>
									 <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
									 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
								   </xsl:call-template>
								 </xsl:for-each>
							</select>
						</xsl:otherwise>
					</xsl:choose>
				</td>
			</tr>
		  <tr>
			  <td COLSPAN="2" nowrap="true">Project Coordinators</td>
			  <td>
			  <xsl:for-each select="../user[@context='projectpis']">
				  
					  <!-- <xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>;&#160; -->
					  <a href="?do=viewstatecoordinator&amp;user={@username}&amp;projType=grants&amp;pn={$projectNumber}">
						<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
             <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">&#160;&#160;&#160;(View Details)</xsl:if>						 
					</a>&#160;
				  
			  </xsl:for-each>
			  <xsl:choose>
				  <xsl:when test="not(../nonusercontact[@context='projectpis'])">
					  <!--
						<td>
							<i>&#160;&#160;&#160;(none)</i>
						</td>
					-->
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
          
				  <xsl:if test="$projectType = 3 or ($projectType = 7 and $regionCode = 'NC') or (($projectType = 8 and $regionCode = 'NC'))">
            <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
              <a href="?do=addcoordinator&amp;type=grant&amp;pn={@projNum}">Add a Coordinator</a>;&#160;            
            </xsl:if>					  
				  </xsl:if>
          
			  </td>
		  </tr>
			<!-- 
		  <tr COLSPAN="2">
				
				<td>
					Non-User Coordinators
				</td>	
					
			<xsl:choose>
				<xsl:when test="not(../nonusercontact[@context='projectpis'])">
					
						<td>
							<i>&#160;&#160;&#160;(none)</i>
						</td>
					
				</xsl:when>
				<xsl:otherwise>
					<xsl:for-each select="../nonusercontact[@context='projectpis']">
							<td>
								<a href="?do=editparticipant&amp;user={@contactID}">
									<xsl:choose>
										<xsl:when test="firstname != ''">
											<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="organization/@name"/>
										</xsl:otherwise>
									</xsl:choose>
								</a>
							</td>
						
					</xsl:for-each>
				</xsl:otherwise>
			</xsl:choose>	
			</tr>-->
			
			<br/>
			<tr>
				<td COLSPAN="2" nowrap="true">Project Title</td>
				<td>
					<INPUT type="text" name="projectTitle" size="80" maxLength="255" value="{title} " onkeypress="WarnUser()"/>
					<small>&#160;&#160;Please use title format. (e.g., Planting Cover Crops)</small>
				</td>
			</tr>
			<tr>
				<td COLSPAN="2" nowrap="true">Projected End Year</td>
				<td>
					<xsl:choose>
						<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
							<INPUT type="text" name="projEndYear" size="5" maxLength="5" value="{$projEndYear}" onchange="WarnUser()" onkeypress="return numbersonly(event, true)"/>
						</xsl:when>
						<xsl:otherwise>
							<INPUT type="text" readonly="readonly" disabled="disabled" name="projEndYear" size="5" maxLength="5" value="{$projEndYear}"/>
						</xsl:otherwise>
					</xsl:choose>
				</td>
			</tr>
			<tr>
				<td>SARE Funds</td>
				<td>&#160;&#160;$</td>
				<xsl:if test="funds/SARE = '0.0'">
					<td>
						<INPUT type="text" name="fundsSARE" size="12" maxLength="12" value="0" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
						<small>&#160;&#160;Please enter the dollar amount of your grant without a comma or dollar sign. (e.g., 1234.56)</small>
					</td>
				</xsl:if>
				<xsl:if test="funds/SARE != '0.0'">
					<td>
						<INPUT type="text" name="fundsSARE" size="12" maxLength="12" value="{$fundsSARE}" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
						<small>&#160;&#160;Please enter the dollar amount of your grant without a comma or dollar sign. (e.g., 1234.56)</small>
					</td>
				</xsl:if>				
			</tr>
			<!--
          <tr>
            <td>*Matching Federal Funds</td>
            <td>&#160;&#160;$</td>			
			<xsl:if test="funds/Fed = '0.0'">
			  <td>
				  <INPUT type="text" name="fundsMatchingFed" size="12" maxLength="12" value="0" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
			  </td>
		  </xsl:if>
		  <xsl:if test="funds/Fed != '0.0'">
			  <td>
				  <INPUT type="text" name="fundsMatchingFed" size="12" maxLength="12" value="{$fundsFed}" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
			  </td>
		  </xsl:if>
          </tr>
          <tr>
            <td>*Matching Non-Federal Funds</td>
            <td>&#160;&#160;$</td>
			  <xsl:if test="funds/NonFed = '0.0'">
				  <td>
					  <INPUT type="text" name="fundsMatchingNonfed" size="12" maxLength="12" value="0" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
				  </td>
			  </xsl:if>
			  <xsl:if test="funds/NonFed != '0.0'">
				  <td>
					  <INPUT type="text" name="fundsMatchingNonfed" size="12" maxLength="12" value="{$fundsFed}" onchange="WarnUser()" onKeyPress="return numbersonly(event, true)"/>
				  </td>
			  </xsl:if>           
          </tr>
		  -->
			<tr>
				<td COLSPAN="3">
					<xsl:choose>
						<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
							<button type="submit" name="btnSaveBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
						</xsl:when>
						<xsl:otherwise>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="True" and /SAREroot/SAREgrant/funds/Submitted="False"'>
								<button type="submit" name="btnSaveBasics" value="Save" onclick="NoPrompt()">Save General Information</button>
							</xsl:if>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="False"'>
								<button type="submit" name="btnSaveBasics" value="Save" onsubmit="this.dropdown.disabled = false;" onclick="NoPrompt()">Save General Information</button>
							</xsl:if>
							<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="True"'>
								<button type="submit" name="btnSaveBasics" value="Save" disabled="disabled">Save General Information</button>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose><small>&#160;&#160;Note: Click “Save General Information” before leaving this page to save edits in the fields above.</small>					
				</td>
          </tr>
        </table>
        </form>
        <form name="projDetails" method="post">
			<p>
				<table CELLSPACING="0" CELLPADDING="2" CLASS="NORM">
					<tr>
						<td>
							<strong>2) Participants:</strong>&#160;&#160;(List project participants here - not the project coordinators.)
						</td>
					</tr>
					<xsl:choose>
						<xsl:when test="not(../nonusercontact[@context='projectparticipants'])">
							<tr>
								<td>
									<i>&#160;&#160;&#160;(none)</i>
								</td>
							</tr>
						</xsl:when>
						<xsl:otherwise>
							<xsl:for-each select="../nonusercontact[@context='projectparticipants']">
								<tr>
									<td>
										<xsl:choose>
											<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
												<a href="?do=editparticipant&amp;user={@contactID}">
													<xsl:choose>
														<xsl:when test="firstname != ''">
															&#160;&#160;&#160;<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
														</xsl:when>
														<xsl:otherwise>
															&#160;&#160;&#160;<xsl:value-of select="organization/@name"/>
														</xsl:otherwise>
													</xsl:choose>
												</a>
											</xsl:when>
											<xsl:otherwise>
												<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="True"'>
													<a href="?do=editparticipant&amp;user={@contactID}" onclick="javascript:alert('Your project overview is pending approval. You cannot edit the project until a regional administrator approves your previous submission.'); return false;">
														<xsl:choose>
															<xsl:when test="firstname != ''">
																&#160;&#160;&#160;<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
															</xsl:when>
															<xsl:otherwise>
																&#160;&#160;&#160;<xsl:value-of select="organization/@name"/>
															</xsl:otherwise>
														</xsl:choose>
													</a>
												</xsl:if>
												<xsl:if test='/SAREroot/SAREgrant/funds/Approved="True" and /SAREroot/SAREgrant/funds/Submitted="False"'>
													<a href="?do=editparticipant&amp;user={@contactID}">
														<xsl:choose>
															<xsl:when test="firstname != ''">
																&#160;&#160;&#160;<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
															</xsl:when>
															<xsl:otherwise>
																&#160;&#160;&#160;<xsl:value-of select="organization/@name"/>
															</xsl:otherwise>
														</xsl:choose>
													</a>
												</xsl:if>
												<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="False"'>
													<a href="?do=editparticipant&amp;user={@contactID}">
														<xsl:choose>
															<xsl:when test="firstname != ''">
																&#160;&#160;&#160;<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>
															</xsl:when>
															<xsl:otherwise>
																&#160;&#160;&#160;<xsl:value-of select="organization/@name"/>
															</xsl:otherwise>
														</xsl:choose>
													</a>
												</xsl:if>
											</xsl:otherwise>
										</xsl:choose>
									</td>
								</tr>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
					<tr>
						<td>
							<a href="?do=addparticipant&amp;type=grant&amp;pn={@projNum}">Add a Participant</a>
							<br/>
						</td>
					</tr>
					
					<tr>
						<td>
							<br/><strong>3) Project Profile:</strong><br/>
							&#160;&#160;&#160;
							<span class="boldred">
								<xsl:choose>
									<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
										<a href="?do=addProfile&amp;type={@typeCode}&amp;pn={@projNum}">Add/Modify</a>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test='/SAREroot/SAREgrant/funds/Approved="True" and /SAREroot/SAREgrant/funds/Submitted="False"'>
											<a href="?do=addProfile&amp;type={@typeCode}&amp;pn={@projNum}">Add/Modify</a>
										</xsl:if>
										<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="False"'>
											<a href="?do=addProfile&amp;type={@typeCode}&amp;pn={@projNum}">Add/Modify</a>
										</xsl:if>
										<xsl:if test='/SAREroot/SAREgrant/funds/Approved="False" and /SAREroot/SAREgrant/funds/Submitted="True"'>
											<a href="?do=addProfile&amp;type={@typeCode}&amp;pn={@projNum}" onclick="javascript:alert('Your project overview is pending approval. You cannot edit the project until a regional administrator approves your previous submission.'); return false;">Add/Modify Project Profile</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
								
							</span>
							<!-- 
							<xsl:choose>
								<xsl:when test="not(profile)">
									&#160;&#160;&#160;<span class="boldred"><a href="?do=addProfile&amp;type=grant&amp;pn={@projNum}">Add Project Profile</a></span>
								</xsl:when>
								<xsl:otherwise>
									&#160;&#160;&#160;<a href="?do=addProfile&amp;type=grant&amp;pn={@projNum}">Update Project Profile</a>
								</xsl:otherwise>
							</xsl:choose>
							-->
						</td>
					</tr>
				</table>
			</p>		
			
        <p>
        <table CELLSPACING="0" CELLPADDING="2" CLASS="NORM">
          <tr>
            <td>
				<strong>4) Proposal Narrative: </strong></td>
          </tr>
          <xsl:choose>
            <xsl:when test="not(report[@type=2])">
            
              <tr><td>&#160;&#160;&#160;
				<!-- This was commented becuase for New Project we only show Year link to edit 
                <select name="addProposalYear">
                  <option value="{$projStartYear}"><xsl:value-of select="$projStartYear"/></option>
                </select>&#160;
                <input type="button" name="btnCreateFinalReport" value="Create New"/>
				-->
				  <a href="?do=editRept&amp;pn={@projNum}&amp;y={@year}&amp;t=2">
					  Create New Proposal Narrative (<xsl:value-of select="@year"/>)
				  </a>&#160;
				  
              </td></tr>
            </xsl:when>
            <xsl:otherwise>
              <xsl:for-each select="report[@type=2]">
              <tr>
                <td>&#160;&#160;&#160;
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
					<!--
                  <xsl:choose>
                    <xsl:when test='@approvedstatus="True"'>(Approved)</xsl:when>
                    <xsl:otherwise>(Not Approved)</xsl:otherwise>
                  </xsl:choose>-->
                </td>
              </tr>
              </xsl:for-each>
            </xsl:otherwise>
          </xsl:choose>
        </table>
        </p>
		<p>
		<tr>
			<td>
				<xsl:choose>
					<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
						<xsl:choose>
							<xsl:when test='funds/Submitted="True" or $useradmin="myprojectslist" or $projNarrativeApproved="True"'>
								<button type="submit" align="center" name="btnProjectDetailsApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Approve</button>&#160;&#160;&#160;&#160;&#160;
								<button type="submit" align="center" name="btnProjectDetailsNotApprove" value="Submit" onclick="return checkForApproval('{$projSubmitted}','{$projApproved}')">Not Approve</button>
								<xsl:if test="$projStartYear &gt; 2000 and $projStartYear &lt; 2007">
									&#160;&#160;<button type="submit"  name="btnProjectDetailsApprove" value="Submit" onclick="return checkAllParts('{$projectType}','{$projNarrative}','{$projParticipants}','{$projProfile}')" align="center">Submit and Approve</button>
								</xsl:if>
							</xsl:when>
							<xsl:when test='(funds/Submitted="False" or funds/Submitted="") and $useradmin="" and ($projNarrativeApproved="False" or $projNarrativeApproved="")'>
								<button type="submit" align="center" disabled="disabled">Approve</button>&#160;&#160;&#160;&#160;&#160;
								<button type="submit" align="center" disabled="disabled">Not Approve</button>
								&#160;&#160;<button type="submit"  name="btnProjectDetailsApprove" value="Submit" onclick="return checkAllParts('{$projectType}','{$projNarrative}','{$projParticipants}','{$projProfile}')" align="center">Submit and Approve</button>
							</xsl:when>
							<xsl:otherwise>
								<button type="submit" align="center" disabled="disabled">Approve</button>&#160;&#160;&#160;&#160;&#160;
								<button type="submit" align="center" disabled="disabled">Not Approve</button>
								&#160;&#160;<button type="submit"  name="btnProjectDetailsApprove" value="Submit" onclick="return checkAllParts('{$projectType}','{$projNarrative}','{$projParticipants}','{$projProfile}')" align="center">Submit and Approve</button>
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
							<button type="submit" align="center" disabled="disabled">Submit Project Overview for Approval</button>
						</xsl:if>
						<xsl:if test='funds/Submitted="False" or funds/Submitted=""'>
							<button type="submit" align="center" name="btnProjectDetailsSubmit" value="Submit" onclick="return checkAllParts('{$projectType}','{$projNarrative}','{$projParticipants}','{$projProfile}')">Submit Project Overview for Approval</button>
						</xsl:if>
						<xsl:if test='funds/Approved="True" and funds/Submitted="True"'>
							<button type="submit" align="center" name="btnProjectDetailsSubmit" value="Submit" onclick="return checkAllParts('{$projectType}','{$projNarrative}','{$projParticipants}','{$projProfile}')">Submit Project Overview for Approval</button>
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
			
			<table CLASS="NORM">
				<tr>
					<td>
					</td>
				</tr>
			</table>
			<p>
				<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
					<!-- <tr> 
						<p> -->
							<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
								<tr>
									<td>
										<p class="pagetitle">Assign Project Codes:</p>
									</td>
								</tr>
								<tr>

									<td>
										To allow a PI or Co-PI access to this project, enter their email address below and click "Assign Project Code".
										<!-- 
										<xsl:text disable-output-escaping="yes"><![CDATA[
									<a href="help/editRept.htm#assign" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>
									<div class="highslide-html-content" id="highslide-html" style="width: 300px">
   									  <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
										<a href="#" onclick="return hs.close(this)" class="control">Close</a>
  									  </div>
									<div class="highslide-body"></div>
									</div>
								]]></xsl:text>-->
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
						<!-- 
						</p>
					</tr>-->
				</table>
			</p>
			<p>
				<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
          <tr>
            <td>
				<p class="pagetitle">Annual Reports:</p>
			</td>
          </tr>
          <xsl:choose>
            <xsl:when test="not(report[@type=0])">
              <!-- <tr><td><i>&#160;&#160;&#160;(none)</i></td></tr> -->
              <xsl:call-template name="addAnnualRepts">
                <xsl:with-param name="startYear"><xsl:value-of select="$projStartYear"/></xsl:with-param>
                <xsl:with-param name="endYear">
                  <xsl:choose>
                    <xsl:when test="$projEndYear &lt; $currentYear">
                      <xsl:value-of select="$projEndYear"/>
                    </xsl:when>
					<xsl:when test="$projEndYear &gt; $currentYear">
						<xsl:value-of select="$projEndYear"/>
					</xsl:when>
                    <xsl:otherwise>
                      <xsl:value-of select="$currentYear"/>
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:with-param>
              </xsl:call-template>
            </xsl:when>
            <xsl:otherwise>
              <xsl:for-each select="report[@type=0]">
              <tr>
				  <xsl:choose>
					  <xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
						  <td>
							  &#160;&#160;&#160;
							  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
								  View/Approve&#160;
								  <xsl:value-of select="@year"/>
							  </a>&#160;
							  <xsl:choose>
								  <xsl:when test='@approvedstatus="True"'>(Approved)</xsl:when>
								  <xsl:when test='@submittedstatus="True"'>(Pending Approval)</xsl:when>
								  <xsl:otherwise>(Not Yet Submitted)</xsl:otherwise>
							  </xsl:choose>
						  </td>						  
					  </xsl:when>
					  <xsl:otherwise>
						  <td>
							  <!-- <xsl:if test="@submittedstatus='False'"> -->
								  &#160;&#160;&#160;
								  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
									  Edit
								  </a>&#160;&#160;|&#160;&#160;
								  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
									  Preview&#160;
									  <xsl:value-of select="@year"/>
								  </a>&#160;
							  <!--</xsl:if>
							  
							  <xsl:if test="@submittedstatus='True'">
								  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
									  View&#160;
									  <xsl:value-of select="@year"/>
								  </a>&#160;
							  </xsl:if>
							  -->
							  <xsl:choose>
								  <xsl:when test='@approvedstatus="True"'>(Approved)</xsl:when>
								  <xsl:when test='@submittedstatus="True"'>(Pending Approval)</xsl:when>
								  <xsl:otherwise>(Not Yet Submitted)</xsl:otherwise>
							  </xsl:choose>
						  </td>
					  </xsl:otherwise>
				  </xsl:choose>                
              </tr>
              </xsl:for-each>
				<xsl:call-template name="addAnnualRepts">
					<xsl:with-param name="startYear">
						<xsl:choose>
							<xsl:when test="$projStartYear = @year">
								<xsl:value-of select="@year+1"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="$projStartYear"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:with-param>
					<xsl:with-param name="endYear">
						<xsl:choose>
							<xsl:when test="$projEndYear &lt; @year">
								<xsl:value-of select="$projEndYear"/>
							</xsl:when>
							<xsl:when test="$projEndYear &gt; @year">
								<xsl:value-of select="$projEndYear"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="$currentYear"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:with-param>
				</xsl:call-template>
            </xsl:otherwise>
          </xsl:choose>
        </table>
        </p>
        <p>
         <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
          <tr>
            <td>
				<p class="pagetitle">Final Report: </p>
			</td>
          </tr>
          <xsl:choose>
            <xsl:when test="not(report[@type=1])">
              <!-- <tr><td><i>&#160;&#160;&#160;(none)</i></td></tr> -->
              <tr><td>&#160;&#160;&#160;
                <select name="addFinalReportYear">
                  <xsl:call-template name="option2">					  
                    <xsl:with-param name="startYear"><xsl:value-of select="($reptYears[not($reptYears &gt; .)])"/></xsl:with-param>
                    <xsl:with-param name="endYear"><xsl:value-of select="$projEndYear"/></xsl:with-param>					
                  </xsl:call-template>
                </select>&#160;
                <input type="submit" name="btnCreateFinalReport" value="Create New" onclick="return checkForOverview('{$projSubmitted}','{$projApproved}')"/>&#160;&#160;Click the arrow to select the year the project was completed.
			  </td></tr>
            </xsl:when>
            <xsl:otherwise>
              <xsl:for-each select="report[@type=1]">
              <tr>
				  <xsl:choose>
					  <xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
						  <td>
							  &#160;&#160;&#160;
							  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
								  View/Approve&#160;
								  <xsl:value-of select="@year"/>
							  </a>&#160;
							  <xsl:choose>
								  <xsl:when test='@approvedstatus="True"'>(Approved)</xsl:when>
								  <xsl:when test='@submittedstatus="True"'>(Pending Approval)</xsl:when>
								  <xsl:otherwise>(Not Yet Submitted)</xsl:otherwise>
							  </xsl:choose>
						  </td>
					  </xsl:when>
					  <xsl:otherwise>
						  <td>
							  &#160;&#160;&#160;
							  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
								  Edit
							  </a>&#160;&#160;|&#160;&#160;
							  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
								  Preview&#160;
								  <xsl:value-of select="@year"/>
							  </a>&#160;
							  <xsl:choose>
								  <xsl:when test='@approvedstatus="True"'>(Approved)</xsl:when>
								  <xsl:when test='@submittedstatus="True"'>(Pending Approval)</xsl:when>
								  <xsl:otherwise>(Not Yet Submitted)</xsl:otherwise>
							  </xsl:choose>
						  </td>
					  </xsl:otherwise>
				  </xsl:choose>
              </tr>
              </xsl:for-each>
            </xsl:otherwise>
          </xsl:choose>
        </table>
        </p>
			
	<p>
         <table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
          <tr>
            <td>
				<p class="pagetitle">Project Information Products: </p>				
			</td>
          </tr>
			 <tr>
				 <td>Click the <a href="?do=infoproddetail&amp;type=grant&amp;pn={@projNum}">Add Information Product</a> link below to share educational resources produced by your grant.</td>
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
								<a href="?do=infoproddetail&amp;type=grant&amp;pn={@projNum}&amp;resourceID={@resourceID}&amp;uploadID={uploadID}">
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
              <a href="?do=infoproddetail&amp;type=grant&amp;pn={@projNum}">Add Information Product</a>
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
			
        <p><a href="?do={$grantslist}">Back to My Projects and Reports</a><br/><br/>
        <!-- <small>Note: Be sure to save your information by clicking on the “Save General Information” button before navigating away from this page.</small>--></p> 
        </form>
      </td>
    </tr>
  </table>

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
    <input type="submit" name="btnCreateAnnualReport" value="Create New" onclick ="return checkForOverview('{$submittedOverview}','{$approvedOverview}')"/>&#160;&#160;Click the arrow to select the correct report year.
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
<!-- creates options for all years between start and end that do not have reports -->
  <xsl:param name="startYear"/>
  <xsl:param name="endYear"/>
  <xsl:if test="$startYear &lt; ($endYear+1)">
    <xsl:if test="not(report[@year=$startYear and @type=0])">
      <option value="{$startYear}"><xsl:value-of select="$startYear"/></option>
    </xsl:if>
    <xsl:call-template name="option">
      <xsl:with-param name="startYear" select="$startYear + 1"/>
      <xsl:with-param name="endYear" select="$endYear"/>
    </xsl:call-template>
  </xsl:if>
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

	<xsl:template name="optionState">
		<!-- Generates an option to go in the drop-down list -->
		<xsl:param name="selected"/>
		<!-- value of the currently selected option -->
		<xsl:param name="value"/>
		<!-- value of the option to be created -->
		<xsl:param name="label"/>
		<!-- label of the option to be created -->
		<xsl:choose>
			<xsl:when test="$selected=$value">
				<option value="{$value}" selected="selected">
					<xsl:value-of select="$label"/>
				</option>
			</xsl:when>
			<xsl:otherwise>
				<option value="{$value}">
					<xsl:value-of select="$label"/>
				</option>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

</xsl:stylesheet>







