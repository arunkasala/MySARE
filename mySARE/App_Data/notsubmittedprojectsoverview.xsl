<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="sortby">year</xsl:param>
<xsl:param name="startrecord">1</xsl:param>
<xsl:param name="maxrecords">5</xsl:param>
<xsl:param name="resultsperpage">5</xsl:param>
<xsl:param name="searchString"/>
<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:variable name="thispage"><xsl:value-of select="ceiling($startrecord div $resultsperpage)"/></xsl:variable>
<xsl:variable name="lastpage"><xsl:value-of select="ceiling($maxrecords div $resultsperpage)"/></xsl:variable>

<xsl:template match="/">
   <p>
     <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
     <span class="pagetitle">Projects with Unsubmitted Overviews</span><br/>	  
     <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
     <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
   </p>	
  <span class="pagetitledown">Results</span>
  <br/><br/>
	<a href="?do=sendpicall&amp;reportStatus=2">Send Call for Reports to PIs</a>
	<br/>Click project number or title to edit project information.
	<br/>
	<table class="sortable" id="reports" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
		<tbody>
			<tr>
				<th style="text-align: left;">Project No.</th>
				<th style="text-align: center; width: 50%;">Title</th>
				<th style="text-align: center; width: 10%;">Region</th>
				<th style="text-align: center; width: 8%;">Year</th>
				<th style="text-align: center; width: 15%;">Type</th>
			</tr>
			<xsl:for-each select="/SAREroot/SAREgrant">
				<xsl:call-template name="SAREgrant"/>				
			</xsl:for-each>
			
		</tbody>
	</table>
</xsl:template>


	<xsl:template name="SAREgrant">
		<xsl:variable name="projNum" select="@projNum"/>
		<xsl:variable name="projTitle" select="title"/>		
		<tr class="r1">

			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2">
					<a href="?do=editProj&amp;pn={$projNum}">
						<xsl:value-of select="$projNum"/>
					</a>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 1">				
				<td>
					<a href="?do=editProj&amp;pn={$projNum}">
						<xsl:value-of select="$projNum"/>
					</a>
				</td>
			</xsl:if>


			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2">
					<xsl:value-of select="$projTitle"/>
				</td>
			</xsl:if>
			
			<xsl:if test="position() mod 2 = 1">
				<td>
					<xsl:value-of select="$projTitle"/>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2">
					<xsl:value-of select="@regionText"/>
				</td>
			</xsl:if>
			
			<xsl:if test="position() mod 2 = 1">
				<td>
					<xsl:value-of select="@regionText"/>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2">
					<xsl:if test="@year != '0'">
						<xsl:value-of select="@year"/>
					</xsl:if>
				</td>
			</xsl:if>
			
			<xsl:if test="position() mod 2 = 1">
				<td>
					<xsl:if test="@year != '0'">
						<xsl:value-of select="@year"/>
					</xsl:if>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2">
					<xsl:value-of select="@typeText"/>
				</td>
			</xsl:if>
			
			<xsl:if test="position() mod 2 = 1">
				<td>
					<xsl:value-of select="@typeText"/>
				</td>
			</xsl:if>
		</tr>

	</xsl:template>

</xsl:stylesheet>
