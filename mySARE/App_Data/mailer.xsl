<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- DWXMLSource="testProject.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="text" encoding="UTF-8"/>
<xsl:param name="mailtype">submitreport</xsl:param>

<xsl:template match="/">
<xsl:apply-templates select="*/user"/><xsl:text>
</xsl:text>
<xsl:choose>
<xsl:when test="$mailtype='submitreport'"><xsl:apply-templates select="*/SAREgrant"/></xsl:when>
<xsl:when test="$mailtype='submitevent'"><xsl:apply-templates select="*/SAREevent"/></xsl:when>
<xsl:otherwise><xsl:apply-templates select="*/changeduser"/></xsl:otherwise>
</xsl:choose>
</xsl:template>

<xsl:template match="SAREgrant">
	<p>This is an automated message to inform you that your account has been used to submit or modify a project report on MySARE. Submissions are subject to the approval of site administrators. Visit http://mysare.sare.org/mySARE to add new or modify existing project reports. Please contact coordinator@sare.org if these changes were made without your permission.</p>
<xsl:text>
</xsl:text>
<xsl:text>
</xsl:text>
<xsl:value-of select="@projNum"/>: <xsl:value-of select="@title"/>	
<xsl:text>
</xsl:text>
Project changes:
<xsl:text>
</xsl:text>
<xsl:apply-templates select="change"/>
<xsl:text>
</xsl:text>
Report changes:
<xsl:text>
</xsl:text>
<xsl:apply-templates select="report">
</xsl:apply-templates>
</xsl:template>

<xsl:template match="report">
<xsl:value-of select="@year"/>
<xsl:if test="@type = 2"> Proposal Overview</xsl:if>
<xsl:if test="@type = 0"> Annual Report</xsl:if>
<xsl:if test="@type = 1"> Final Report</xsl:if>
<xsl:text>
</xsl:text>
<xsl:apply-templates select="change"/>
</xsl:template>

<xsl:template match="SAREevent">
	<p>This is an automated message to inform you that your account has been used to submit a new or modify an existing event on the MySARE events calendar. Submissions are subject to the approval of site administrators. Visit http://mysare.sare.org/mySARE to add new or modify existing events. Please contact coordinator@sare.org if these changes were made without your permission.</p>
<xsl:text>
</xsl:text>
<xsl:text>
</xsl:text>
Event: <xsl:value-of select="@evnum"/>: <xsl:value-of select="@title"/><xsl:text>
</xsl:text>
<xsl:apply-templates select="change"/>
</xsl:template>

<xsl:template match="changeduser">
<p>This is an automated message to inform you that your account was modified. Please contact coordinator@sare.org if these changes were made without your permission.</p>
<xsl:text>
</xsl:text>
<xsl:text>
</xsl:text>
Username of edited user: <xsl:value-of select="@username"/><xsl:text>
</xsl:text><xsl:apply-templates select="change"/>
</xsl:template>

<xsl:template match="user">
The following changes were made by <xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>&#160;(<xsl:value-of select="@username"/>):<xsl:text>
</xsl:text>
</xsl:template>

<xsl:template match="change">
<xsl:choose>
<xsl:when test="@type = 'Approval Status'">
<xsl:choose>
<xsl:when test="@currentval = 'Approved'">
This item has been approved and can now be viewed by the public.
</xsl:when>
<xsl:otherwise>
This item is no longer approved for public view--please contact your regional communications specialist to find out what changes are required.
</xsl:otherwise>
</xsl:choose>
</xsl:when>
</xsl:choose>

<xsl:choose>
<xsl:when test="@type = 'Submission Status'">
<xsl:choose>
<xsl:when test="@currentval = 'Submitted'">
This item has been submitted for approval.  Please review and either approve it or provide the user with guidelines for changes that will further the approval process.
</xsl:when>
<xsl:otherwise>
</xsl:otherwise>
</xsl:choose>
</xsl:when>
</xsl:choose>
	
<xsl:if test="@type">
Item changed: <xsl:value-of select="."/><xsl:text>
</xsl:text>
</xsl:if>
	
<xsl:if test="@type">Type of edit: <xsl:value-of select="@type"/><xsl:text>
</xsl:text></xsl:if>
<xsl:if test="@section">Section: <xsl:if test="@sectionName"><xsl:value-of select="@sectionName"/></xsl:if> (<xsl:value-of select="@section"/>)<xsl:text>
</xsl:text></xsl:if>
<xsl:if test="@subsection">Subsection: <xsl:value-of select="@subsection"/><xsl:text>
</xsl:text></xsl:if>
<xsl:if test="@previousval">Previous value: <xsl:value-of select="@previousval"/><xsl:text>
</xsl:text></xsl:if>
<xsl:if test="@currentval">New value: <xsl:value-of select="@currentval"/><xsl:text>
</xsl:text></xsl:if>
</xsl:template>

</xsl:stylesheet>
