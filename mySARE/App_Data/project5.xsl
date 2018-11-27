<?xml version="1.0" encoding="iso-8859-1"?>
<!-- DWXMLSource="project_test.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/">

<xsl:apply-templates select="SAREroot"/>

</xsl:template>

<xsl:template match="SAREroot">

	<span class="pagetitle">
		Your SARE-Funded Projects
	</span><br/>
	<span style="font-weight: bold;"><br/>
		Click report links to View and Edit reports<br/>
	</span>
	<table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
		<tbody>
<!--		<xsl:apply-templates mode="projlist" select="SAREgrant" />
-->
			<xsl:if test="SAREgrant/report[@type = 2]">
			<tr class="pagetitledown">
				<td colspan="3" rowspan="1">Proposals</td>
			</tr>
			<tr>
				<td style="text-align: center;">Proposal ID</td>
				<td style="text-align: center;">Title</td>
				<td style="text-align: center;" width="20%">Approval Status</td>
			</tr>
			<xsl:apply-templates mode="match" select="SAREgrant/report">
				<xsl:with-param name="matchtype" select="2">
				</xsl:with-param>
			</xsl:apply-templates>
			</xsl:if>
						
			<tr class="pagetitledown">
				<td colspan="3" rowspan="1">View and Edit Your Reports</td>
			</tr>
			<tr>
				<td style="text-align: center;">Project Number</td>
				<td style="text-align: center;">Title</td>
				<td style="text-align: center;">Approval Status</td>
			</tr>
			<xsl:apply-templates mode="match" select="SAREgrant/report">
				<xsl:with-param name="matchtype" select="0">
				</xsl:with-param>
			</xsl:apply-templates>
			<xsl:apply-templates mode="match" select="SAREgrant/report">
				<xsl:with-param name="matchtype" select="1">
				</xsl:with-param>
			</xsl:apply-templates>
		</tbody>
	</table>
	
</xsl:template>

<xsl:template match="SAREgrant" mode="projlist">
	<p class="pagetitle">
	<xsl:value-of select="@projNum"/>: <xsl:value-of select="title"/>
	</p>
	<p class="normal">
	<xsl:value-of select="@year"/>
	<br/>
	<xsl:value-of select="@regionText"/>
	<br/>
	<xsl:value-of select="@typeText"/>
	<br/>

		<tr class="pagetitledown">
			<td colspan="3" rowspan="1">Proposals</td>
		</tr>
		<tr>
			<td style="text-align: center;">Proposal ID</td>
			<td style="text-align: center;">Title</td>
			<td style="text-align: center;">Approval Status</td>
		</tr>
		<xsl:apply-templates mode="match" select="report">
			<xsl:with-param name="matchtype" select="2">
			</xsl:with-param>
		</xsl:apply-templates>
		
		<tr class="pagetitledown">
			<td colspan="3" rowspan="1">View and Edit Your Reports</td>
		</tr>
		<tr>
			<td style="text-align: center;">Proposal ID</td>
			<td style="text-align: center;">Title</td>
			<td style="text-align: center;">Approval Status</td>
		</tr>
		<xsl:apply-templates mode="match" select="report">
			<xsl:with-param name="matchtype" select="0">
			</xsl:with-param>
		</xsl:apply-templates>
		<xsl:apply-templates mode="match" select="report">
			<xsl:with-param name="matchtype" select="1">
			</xsl:with-param>
		</xsl:apply-templates>
	</p>
</xsl:template>
<xsl:template match="SAREgrant/funds" mode="toc">
</xsl:template>
<xsl:template match="SAREgrant/report" mode="match">
	<xsl:param name="matchtype" select="0"/>
	<xsl:choose>
		<xsl:when test="@type = $matchtype">
		<xsl:variable name="projNum" select="../@projNum"/>
		<xsl:variable name="projTitle" select="../title"/>
			<tr class="r1">
				<td><a href="?do=editProj&amp;pn={$projNum}"><xsl:value-of select="$projNum"/></a></td>
				<td>
					<a href="?do=editRept&amp;pn={$projNum}&amp;y={@year}&amp;t={@type}">
						
						<xsl:if test="@type = 2"><xsl:value-of select="$projTitle"/></xsl:if>
						<xsl:if test="@type = 0"><xsl:value-of select="@year"/> Annual Report</xsl:if>
						<xsl:if test="@type = 1"><xsl:value-of select="@year"/> Final Report</xsl:if>
					</a>
				</td>
				<td style="text-align: right;">
    <xsl:choose>
    <xsl:when test="@approvedstatus = 'True'">
    Approved
    </xsl:when>
    <xsl:otherwise>
        Pending Approval
    </xsl:otherwise>
    </xsl:choose>

				</td>
				</tr>
		</xsl:when>
	</xsl:choose>
</xsl:template>
</xsl:stylesheet>
