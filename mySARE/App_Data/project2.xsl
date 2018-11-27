<?xml version="1.0" encoding="iso-8859-1"?><!-- DWXMLSource="testProject.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="iso-8859-1" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/root">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
<title><xsl:value-of select="SAREgrant/@projNum" />:<xsl:value-of select="SAREgrant/title" /></title>
  <link rel="stylesheet" type="text/css" href="http://www.sare.org/events/calendar.css" />
  <link href="includes/stylens.css" rel="stylesheet" type="text/css" />
  <link href="includes/calendar.css" rel="stylesheet" type="text/css" />
</head>

<body class="copy">

<xsl:apply-templates mode="toc" select="SAREgrant" />

<p />

</body>
</html>

</xsl:template>
<xsl:template match="SAREgrant" mode="toc">
	<p class="pagetitle">
	<xsl:value-of select="@projNum" />: <xsl:value-of select="title" />
	</p>
	<xsl:value-of select="@year" />
	<br />
	<xsl:value-of select="@regionText" />
	<br />
	<xsl:value-of select="@typeText" />
	<br />
	<xsl:apply-templates mode="toc" select="./report" />
</xsl:template>

	<xsl:template match="SAREgrant/funds" mode="toc">
	</xsl:template>
	<xsl:template match="SAREgrant/report" mode="toc">
	<xsl:variable name="projNum" select="../@projNum" />
	<br />
		<a href="?do=editRept&amp;pn={$projNum}&amp;y={@year}&amp;t={@type}">
			<xsl:value-of select="@year" />
			<xsl:if test="@type = 2"> Project Proposal</xsl:if>
			<xsl:if test="@type = 0"> Annual Report</xsl:if>
			<xsl:if test="@type = 1"> Final Report</xsl:if>
		</a>
	</xsl:template>

</xsl:stylesheet>