<?xml version="1.0" encoding="iso-8859-1"?><!-- DWXMLSource="testReport.xml" --><!DOCTYPE xsl:stylesheet  [
	<!ENTITY nbsp   "&#160;">
	<!ENTITY copy   "&#169;">
	<!ENTITY reg    "&#174;">
	<!ENTITY trade  "&#8482;">
	<!ENTITY mdash  "&#8212;">
	<!ENTITY ldquo  "&#8220;">
	<!ENTITY rdquo  "&#8221;"> 
	<!ENTITY pound  "&#163;">
	<!ENTITY yen    "&#165;">
	<!ENTITY euro   "&#8364;">
]>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="iso-8859-1" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>
<xsl:template match="/">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
<title><xsl:value-of select="report/@year" /> Report</title>
</head>

<body>
<form action="classtest3.aspx" method="post" name="reportform">
	<xsl:for-each select="report/section">
	<xsl:variable name="sectionname" select="name" />
	<xsl:variable name="sectionID" select="@ID" />
	<b><xsl:value-of select="$sectionname" /></b><br />
		<xsl:for-each select="subsection">
		<xsl:variable name="subheading" select="heading" />
		<xsl:variable name="subheadingID" select="@order" />
		<xsl:variable name="text" select="text" />
			<input
				name="section{$sectionID}subheading{$subheadingID}"
				type="text"
				value="{$subheading}"
				size="50" maxlength="255" />
		<br/>
			<textarea
				name="section{$sectionID}subtext{$subheadingID}"
				rows="15"
				cols="50"
				>
				<xsl:value-of select="$text" />
			</textarea>
				<p />
		</xsl:for-each>
	</xsl:for-each>
	<p />
<input name="Submit" type="submit" value="Submit" />
</form>
</body>
</html>

</xsl:template>
</xsl:stylesheet>
