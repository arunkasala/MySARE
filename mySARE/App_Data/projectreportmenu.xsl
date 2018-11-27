<?xml version="1.0" encoding="ISO-8859-1"?>
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
<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <p>
    <span class="pagetitle">SARE Project Reports</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>

	<form name="ProjectReport" METHOD="post" action="ProjectReport.aspx">
		<img src="images/men_w_sugarbeets.jpg" width="168" height="252" alt="men in field of sugarbeets" border="0" align="right" hspace="13" vspace="5"></img>
		<p>
			Welcome to SARE's national database of projects, which organizes some
			3,000 projects funded by SARE since the program's inception in 1988. The
			database is searchable by keyword, title and project number.
		</p>
		<p>
			These projects were supported by the Sustainable Agriculture Research and Education (SARE) program, 
			which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). 
			Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.
		</p>
		<blockquote>
			<p>
				<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
					<a href="ProjectReport.aspx?do=search"><span class="SearchDB">Search the database</span></a>
				</img>
			</p>
			<p>
				<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
					<a href="../projects/about.htm">About project reports</a>
				</img>
			</p>
			<p>
				<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
					<a href="../projects/submission.htm">Submit a report</a>
				</img>
			</p>
			<p>
				<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
					<a href="../projects/howtosearch.htm">Database searching tips</a>
				</img>
			</p>
			<p>
				<img src="../images/bullet.gif" width="10" height="10" alt="" border="0">
					<a href="../projects/results.htm">About search results</a>
				</img>
			</p>
		</blockquote>
		<br/>
		<img src="../images/mediumline.gif" width="100%" height="1" alt="" border="0" vspace="7"></img>
		The database features several different types of projects, including:

		<blockquote>
			<p>
				<span class="boldred">
					<strong>Research and Education.</strong>
				</span>
				Involves scientists, producers and others in an interdisciplinary approach.
				All four regions.
			</p>
			<p>
				<strong>
					<span class="boldred">Professional Development Program.</span>
				</strong>
				Allows extension educators and other ag professionals to develop and
				offer various training programs. All four regions.
			</p>
			<p>
				<span class="boldred">
					<strong>Farmer /Rancher.</strong>
				</span> Tests
				practices and systems through on-farm experiments. All four regions.
			</p>
			<p>
				<strong>
					<span class="boldred">Graduate Student.</span>
				</strong> Helps
				support research activities. North Central and Southern regions.
			</p>
			<p>
				<strong>
					<span class="boldred">On Farm Research/Partnership.</span>
				</strong>
				Supports on-farm research by Extension, NRCS, and/or nonprofit organizations.
				Northeast, Southern and Western regions.
			</p>
			<p>
				<strong>
					<span class="boldred">Sustainable Community Innovation.</span>
				</strong>
				Forges connections between sustainable agriculture and rural community
				development. Northeast and Southern regions.
			</p>
		</blockquote>
		<img src="../images/mediumline.gif" width="100%" height="1" alt="" border="0" vspace="7">
			<!--
			<br>
				<p align="right" class="small">
					<a href="#top">
						<img src="../images/toparrow.gif" width="11" height="7" alt="" border="0">
							Top
						</img>
					</a>
				</p>
			</br>-->
		</img>
	</form>
</xsl:template>



</xsl:stylesheet>

