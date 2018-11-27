<?xml version="1.0" encoding="iso-8859-1"?><!-- DWXMLSource="project_test.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/">

	<xsl:apply-templates mode="toc" select="root" />

</xsl:template>

<xsl:template match="/root">

	<xsl:apply-templates mode="toc" select="SAREgrant" />

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
	<xsl:apply-templates mode="toc" select="./report" >
		<xsl:with-param name="type" select="attribute::type = 2">
		</xsl:with-param>
		</xsl:apply-templates>
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