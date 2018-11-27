<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="ncregadminlist"/>
<xsl:param name="neregadminlist"/>
<xsl:param name="sregadminlist"/>
<xsl:param name="wregadminlist"/>

<xsl:template match="/">
<script LANGUAGE="JavaScript">
	<![CDATA[
	function TriggerOutlook(region,emails)
    {        

        var body = "To " + region + " Regional Admin," + escape(String.fromCharCode(13) + String.fromCharCode(13)) + 
				   "I cannot find the information needed to add my new SARE project to my account. Can you please send my project number and code?"  + escape(String.fromCharCode(13)) + 
				   "My Name:" + escape(String.fromCharCode(13) + String.fromCharCode(13)) + "City and State:" + escape(String.fromCharCode(13) + String.fromCharCode(13)) +
				   "Proposal Title:" + escape(String.fromCharCode(13) + String.fromCharCode(13)) + "My e-mail address:" + escape(String.fromCharCode(13) + String.fromCharCode(13)) + 
				   "[Regional administrator, navigate to http://mysare.sare.org/mySARE/sare_main.aspx?do=searchUnclaimProj to find this project. Then, paste the PI e-mail address into the box below the project narrative to assign a new project code.]";

        var subject = "MySARE PI's request for project number and code";
        
		window.location.href = "mailto:"+emails+"?body="+body+"&subject="+subject;               

	}  
	
	function isStateAbbreviation(projectNum)
	{
		
		var states = /AL/AK/AS/AZ/AR/CA/CO/CT/DE/DC/FM/FL/GA/GU/HI/ID/IL/IN/IA/KS/KY/LA/ME/MH/MD/MA/MI/MN/MS/MO/MT/NE/NV/NH/NJ/NM/NY/NC/ND/MP/OH/OK/OR/PW/PA/PR/RI/SC/SD/TN/TX/UT/VT/VI/VA/WA/WV/WI/WY;
		
		var state = "";
		
		//if (projectNum.length == 10)
		//	state = projectNum.substr(2,2);
		
		if (projectNum.length == 9)
		{
			var regions = projectNum.substr(0,1);
			if (regions == 'E' || regions == 'S' || regions == 'L' || regions == 'F' || regions == 'G' || regions == 'O' || regions == 'C' || regions == 'M' || regions == 'Y') 
				projectNum = "";
			//else
			//	state = projectNum.substr(1,2);
		}		
		//alert(projectNum);
		//alert(projectNum.match(states));
		if (projectNum.match(states) == null)
		{
			alert("This is not state report.");
			return false;			
		}
		else
		{
			return true;			
		}
	}
	]]>
</script>


<p>
	<span class="pagetitle">
		<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE <br/>Retrieve a New State Report
	</span>	
	<p class="subtitle">Use MySARE to submit your State Report to the SARE program and share results with the administrators. Copy and paste the project number and project code that you received via email into the fields below. Then click Retrieve State Report. Retrieving a project gives you access to the MySARE system, where you will enter information and reports about your grant.</p>
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
		<i>
			<xsl:value-of select="$message2"/>
		</i>
	</xsl:if>
</p>

<form id="claimProject" name="claimProject" method="post">
	<table>
		<tr>
			<td>Project Number: </td>
			<td>
				<input id="projNum" maxlength="16" size="25" name="projNum" />
				<script type="text/javascript" language="JavaScript">
					document.forms['claimProject'].elements['projNum'].focus();
				</script>
			</td>
    </tr>
    <tr>
      <td>Project Code: </td>
      <td>
        <input maxlength="50" size="25" name="claimCode"/>
	  </td>		
    </tr>
    <tr>
      <td>
        <input name="ClaimPDP" type="submit" value="Retrieve State Report" onclick="return isStateAbbreviation(claimProject.projNum.value)"/>
      </td>
    </tr>
    </table>
  </form>
  <br/>
<!-- 
  If you cannot locate your project number and code or it does not work, contact your SARE regional administrator by clicking below.<br/>
	<a href="#" onclick="TriggerOutlook('NC','{$ncregadminlist}');">North Central</a><br/>
	<a href="#" onclick="TriggerOutlook('NE','{$neregadminlist}');">Northeast</a><br/>
	<a href="#" onclick="TriggerOutlook('South','{$sregadminlist}');">South</a><br/>
	<a href="#" onclick="TriggerOutlook('West','{$wregadminlist};kristi.jensen@usu.edu');">West</a><br/><br/><br/>
	<a href="?do=myProj">Submit/View My Projects and Reports</a><br/><br/><br/>
  If you have not received a grant from SARE, then you are in the wrong place. To search the SARE project database, see <a href="http://mysare.sare.org/MySare/ProjectReport.aspx">Project Reports</a> 
-->
</xsl:template>

</xsl:stylesheet>


