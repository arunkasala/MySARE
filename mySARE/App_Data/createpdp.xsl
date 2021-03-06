<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

	<xsl:param name="message"/>
	<xsl:param name="message2"/>
	<xsl:param name="projectType"/>
	<xsl:param name="projectRegion"/>

	<xsl:template match="/">
		<script LANGUAGE="JavaScript">
			<![CDATA[
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
   /*
  else if (decimal && (keychar == ".")) { 
     return true;
   }
   */
   else if (decimal && (keychar == ",")) { 
     return true;
   }
  else
      return false;
  }
  
  function isRegionStateCorrect(projectNum)
  {
	alert (projectNum);
	
	var nc_states = /SD/WI/IA/IL/IN/KS/MI/MN/MO/ND/NE/OH;

	var ne_states = /NH/NJ/MA/MD/ME/CT/DC/DE/WV/NY/VT/RI/PA;

	var s_states = /PR/SC/TN/TX/VA/VI/FL/AL/AR/KY/LA/GA/MS/OK/NC;

	var w_states = /AK/OR/NM/NV/MT/MP/GU/HI/ID/AS/AZ/CA/CO/FM/WA/WY/UT;
	
	var state = "";
		
	if (projectNum.length == 10)
		state = projectNum.substr(2,2);
		
	if (projectNum.length == 9)
		state = projectNum.substr(1,2);	
	
	if (state.match(nc_states) != null)
	{
			return true;			
	}
	else if (state.match(ne_states) != null)
	{
		return true;			
	}
	else if (state.match(s_states) != null)
	{
		return true;			
	}
	else if (state.match(w_states) != null)
	{
		return true;			
	}
	else
	{
		alert("Region and State does not match");
		return false;
	}

  }

]]>
		</script>
		<p>
			<span class="pagetitle">
				<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE
			</span>
			<br/>
			<span class="pagetitle">Create New State Report</span>
			<br/>
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
						<i>
							<div>
								<xsl:value-of select="$message2"/>
							</div>
						</i>
					</span>
				</b>
			</xsl:if>
		</p>
		<table>
			<tr>
				<td ALIGN="LEFT" VALIGN="TOP">
					<p class="subtitle">Project can be created in two ways:</p>
					<p>1. Manual: Enter the project number using the defined format, then enter the email address of the PI and click "Create State Report" or "Create and Edit". Click on "?" for information.</p>
					<p>2. Automatic PDP Generator: Fill in all the options under “Automatic Project Number Generator” including the sequence number, then enter the email address of the PI and click “Create PDP” or “Create and Edit."</p>
				</td>
			</tr>
		</table>

		<form name="thisForm" id="createpdp" METHOD="post">

			<p class="pagetitle">Create State Reports:</p>
			<!-- <p><strong>Note: Fields marked with an asterisk (*) are required</strong></p> -->
			<table CELLSPACING="0" CELLPADDING="2">
				<tr>
					<td WIDTH="50%" VALIGN="TOP">
						<table CELLSPACING="0" CELLPADDING="2">
							<tr>
								<th COLSPAN="2">
									Manual Project Number Entry: &#160;
									<!-- <xsl:text disable-output-escaping="yes">
			<![CDATA[<a href="help/createproject.htm#manual" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text> -->
									<span class="tooltiptext">
										<a href="/mysare/help/createproject.htm#manual" target="_blank">
											<h3>Manual PDP Number Entry</h3>
										</a>
										<p>
											&#160;
										</p>
										<p>
											If you prefer to manually enter your project number, rather than letting the reporting tool automatically construct one for you, you
											may enter it in the field provided.
										</p>
										Project numbers should use the following format: Region|State Abbreviation|Year-ProjectSequence. Here are some examples, where XXX equals the number sequence you’d like to assign to the project:
										<ul>
											<li>2010 South State Report: SFL10-XXX</li>
											<li>2008 Northeast State Report: NEVA08-XXX</li>
										</ul>
									</span>
								</th>
							</tr>
							<tr>
								<td>PDP Number</td>
								<td>
									<INPUT type="text" id="projNum" name="projNum" size="20" maxLength="20" value=""/>
									&#160; (<i>XXX00-000</i>)
								</td>
							</tr>
						</table>
					</td>
					<td WIDTH="50%">
						<table CELLSPACING="0" CELLPADDING="2">
							<tr>
								<th COLSPAN="2">
									Automatic PDP Number Generator: &#160;
									<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/createproject.htm#auto" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text> -->
									<span class="tooltiptext">
										<a href="/mysare/help/createproject.htm#auto" target="_blank">
											<h3>Automatic PDP Number Generator</h3>
										</a>
										<p>
											&#160;
										</p>
										<p>If you do not have a project number, use the automatic	project number generator to provide one for you.</p>
									</span>
								</th>
							</tr>
							<tr>
								<td>State</td>
								<td>
									<select name="addrState">
										<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
       <xsl:call-template name="option">
         <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user[@context='editing']/contact/addrState"/></xsl:with-param>
         <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
         <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
       </xsl:call-template>
     </xsl:for-each>
									</select>
								</td>
							</tr>
							<tr>
								<td>Region</td>
								<td>
									<SELECT name="projRegion" id="projRegion" size="1">
										<xsl:for-each select="/SAREroot/regions/region">
											<xsl:sort select="name"/>
											<xsl:if test="regionCode = $projectRegion">
												<OPTION value="{regionCode}" selected="{regionCode}">
													<xsl:value-of select="name"/>
												</OPTION>
											</xsl:if>
											<xsl:if test="regionCode != $projectRegion">
												<OPTION value="{regionCode}">
													<xsl:value-of select="name"/>
												</OPTION>
											</xsl:if>
										</xsl:for-each>
									</SELECT>
								</td>
							</tr>
							<tr>
								<td>Year Funded</td>
								<td>
									<SELECT name="projYear" id="projYear" size="1">
										<OPTION value="2014">2014</OPTION>
										<OPTION value="2013">2013</OPTION>
										<OPTION value="2012">2012</OPTION>
										<OPTION value="2011">2011</OPTION>
										<OPTION value="2010">2010</OPTION>
										<OPTION value="2009">2009</OPTION>
										<OPTION value="2008">2008</OPTION>
										<OPTION value="2007">2007</OPTION>
										<OPTION value="2006">2006</OPTION>
										<OPTION value="2005">2005</OPTION>
										<OPTION value="2004">2004</OPTION>
										<OPTION value="2003">2003</OPTION>
										<OPTION value="2002">2002</OPTION>
										<OPTION value="2001">2001</OPTION>
										<OPTION value="2000">2000</OPTION>

										<OPTION value="1999">1999</OPTION>
										<OPTION value="1998">1998</OPTION>
										<OPTION value="1997">1997</OPTION>
										<OPTION value="1996">1996</OPTION>
										<OPTION value="1995">1995</OPTION>
										<OPTION value="1994">1994</OPTION>
										<OPTION value="1993">1993</OPTION>
										<OPTION value="1992">1992</OPTION>
										<OPTION value="1991">1991</OPTION>

										<OPTION value="1990">1990</OPTION>
										<OPTION value="1989">1989</OPTION>
										<OPTION value="1988">1988</OPTION>
									</SELECT>
								</td>
							</tr>
							<tr>
								<td>Sequence Number</td>
								<td>
									<INPUT type="text" id="sequenceNum" name="sequenceNum" size="5" onKeyPress="return numbersonly(event, false)" maxLength="3" value=""/>Sequence number for the project
								</td>
							</tr>
							<tr>
								<td>Projected End Date</td>
								<td>
									<SELECT name="projEndYear" id="projEndYear" size="1">
										<OPTION value="2018">2018</OPTION>
										<OPTION value="2017">2017</OPTION>
										<OPTION value="2016">2016</OPTION>
										<OPTION value="2015">2015</OPTION>
										<OPTION value="2014" selected="2014">2014</OPTION>
										<OPTION value="2013">2013</OPTION>
										<OPTION value="2012">2012</OPTION>
										<OPTION value="2011">2011</OPTION>
										<OPTION value="2010">2010</OPTION>
										<OPTION value="2009">2009</OPTION>
										<OPTION value="2008">2008</OPTION>
										<OPTION value="2007">2007</OPTION>
										<OPTION value="2006">2006</OPTION>
										<OPTION value="2005">2005</OPTION>
										<OPTION value="2004">2004</OPTION>
										<OPTION value="2003">2003</OPTION>
										<OPTION value="2002">2002</OPTION>
										<OPTION value="2001">2001</OPTION>
										<OPTION value="2000">2000</OPTION>

										<OPTION value="1999">1999</OPTION>
										<OPTION value="1998">1998</OPTION>
										<OPTION value="1997">1997</OPTION>
										<OPTION value="1996">1996</OPTION>
										<OPTION value="1995">1995</OPTION>
										<OPTION value="1994">1994</OPTION>
										<OPTION value="1993">1993</OPTION>
										<OPTION value="1992">1992</OPTION>
										<OPTION value="1991">1991</OPTION>

										<OPTION value="1990">1990</OPTION>
										<OPTION value="1989">1989</OPTION>
										<OPTION value="1988">1988</OPTION>
									</SELECT>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<br/>
					</td>
				</tr>

				<tr/>
			</table>

			<p>
				PI Email Address&#160;<INPUT type="text" id="projEmail" name="projEmail" size="20" maxLength="255" value=""/>
			</p>
			<p>
				Enter the PI’s email address and click "Create State Report" or "Create and Edit" to create a project and automatically send an email to the PI with their project number and project retrieval code. <b>
					<i>You must enter the PI email address to allow PI to log in, retrieve the project, and manage their grant.</i>
				</b>
				<b> Note:</b> If you are creating a series of projects, use the <i>"Create State Report"</i> button. If you are creating a project and want to enter project data now, use the <i>"Create and Edit"</i> button.
			</p>
			<p>
				Leave the PI email address field blank if you will be entering project data or reports on behalf of the PI or do not want the PI to enter report data at this time. (You can assign the PI a project retrieval code and allow them to enter project reports at a later date if desired.)
			</p>
			<p>
				<INPUT type="submit" name="cmdCreatePDP" value="Create State Report"/>&#160;&#160;
				<INPUT type="submit" name="btnAdminCreatePDPConfirm" value="Create and Edit" onclick=""/>
				<br/>
			</p>




			<p/>
			<!-- <INPUT type="submit" name="btnAdminCreateProjBack" value="Cancel"/>  -->

		</form>

		<xsl:text disable-output-escaping="yes">
  <![CDATA[
  <div class="highslide-html-content" id="highslide-html" style="width: 300px">
	<div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
      <a href="#" onclick="return hs.close(this)" class="control">Close</a>
	</div>
	<div class="highslide-body"></div>
  </div>
  ]]>
  </xsl:text>

	</xsl:template>

	<xsl:template name="option">
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
