<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="currentMonth">October</xsl:param>
<xsl:param name="currentDay">19</xsl:param>
<xsl:param name="currentYear">2007</xsl:param>
<xsl:param name="optionMonths">4</xsl:param>
<xsl:param name="optionView">PartialDescriptions</xsl:param>
<xsl:param name="optionRegion"/>
<xsl:param name="optionGeoscope">All</xsl:param>
<xsl:param name="optionInternational">yes</xsl:param>
<xsl:param name="searchString"/>
<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <p>
    <span class="pagetitle">Search the SARE Website</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>

	<form name="SearchWebsite" METHOD="post" action="SearchWebsite.aspx">
		<p>
			There are several ways to search the SARE website. Each method will search a different subset of information on the site.
		</p>
		<p>
			<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
			<span class="boldred">
				<strong>Search the SARE Website</strong>
			</span><br/>
				Use this box to search SARE publications and to find other information about SARE and a host of sustainable agriculture topics on this website.<br/>
				<input name="Query" type="text" size="60" maxlength="255" value="{$searchString}"/>
				<input name="SearchWebsiteBtn" type="submit" value="Search Now"/>	
			</img>
		</p>
		<p>
			<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
				<span class="boldred">
					<strong>Search the SARE project database</strong>
				</span><br/>
				<a href="ProjectReport.aspx?do=search">
					<span class="SearchDB">The SARE project database</span>
				</a>&#160;contains about 4,500 projects funded by SARE since the program’s inception in 1988. The database is searchable by keyword, title, project number, organization and project summary.
			</img>
		</p>
		<p>
			<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
				<span class="boldred">
					<strong>Search SANET-MG</strong>
				</span><br/>
				<a href="http://lists.sare.org/archives/sanet-mg.html">
					<span class="SearchDB">SANET-MG</span>
				</a>&#160;is a discussion group sponsored by SARE Outreach to facilitate information exchange about sustainable agriculture. The archives contain thousands of messages about every facet of sustainable agriculture since 1991. Because of changes in technology, the list archives are maintained in two different databases.
			</img>
		</p>
		<p>
			<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
				See also the list of resources by topic on the left side of this page.
			</img>
		</p>
		<br/>
		<img src="../images/mediumline.gif" width="100%" height="1" alt="" border="0" vspace="7"></img>		
	</form>
</xsl:template>

</xsl:stylesheet>

