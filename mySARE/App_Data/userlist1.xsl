<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- DWXMLSource="userlist.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/">

	<xsl:apply-templates mode="toc" select="userlist"/>

</xsl:template>

<xsl:template match="/userlist" mode="toc">

	<p class="pagetitle">
  Click user to edit
	</p>
	<xsl:apply-templates mode="toc" select="user"/>

</xsl:template>

<xsl:template match="user" mode="toc">
		<a href="?do=editUser&amp;user={@username}">
		<xsl:value-of select="lastname"/>, <xsl:value-of select="firstname"/> (<xsl:value-of select="@username"/>)
		</a>
	<br/>
</xsl:template>

</xsl:stylesheet>
