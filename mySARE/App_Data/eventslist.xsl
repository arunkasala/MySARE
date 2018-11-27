<?xml version="1.0" encoding="iso-8859-1"?>
<!-- DWXMLSource="project_test.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:template match="/">

<xsl:apply-templates select="SAREroot"/>

</xsl:template>

<xsl:template match="SAREroot">

	<span class="pagetitle">
		Sustainable Agriculture Events
	</span><br/>
	<span style="font-weight: bold;"><br/>
		Click event links to view and edit your MySARE events.
		<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/projectlist.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="../images/help.png" border="0" /></a>]]></xsl:text> -->
        <br/>
	</span>

    <br/><span class="pagetitledown">Events</span><br/>
    <table class="sortable" id="events" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
        <tbody>			
			<tr>
                <th style="text-align: left; width: 20%;">Dates</th>
				<th style="text-align: center; width: 50%;">Title</th>
                <th style="text-align: center; width: 15%;">Location and Scope</th>
				<th style="text-align: right; width: 15%;">Approval Status</th>
			</tr>
			<xsl:choose>
            <xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='admin' or @code='natAdmin']">
			  <xsl:for-each select="calendarEvents/calendarEvent">
              <xsl:sort select="times/startDateOrder" order="ascending"/>
              <xsl:call-template name="calendarEvent"/>
            </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
			  <xsl:for-each select="calendarEvents/calendarEvent">
              <xsl:sort select="times/startDateOrder" order="ascending"/>
              <xsl:call-template name="calendarEvent"/>
            </xsl:for-each>
            </xsl:otherwise>
            </xsl:choose>
		</tbody>
	</table>
	<br/>
	<strong><a href="?do=addevent">Add New Event</a></strong><br/>
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
	<br/>
	<small>
		This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.
	</small>
</xsl:template>

<xsl:template name="calendarEvent">
		<xsl:variable name="evNum" select="@number"/>
		<xsl:variable name="evName" select="name"/>
			<tr class="r1">
				<xsl:if test="position() mod 2 = 0">
					<td bgcolor="#D9D9F2" style="text-align: left;">
						<xsl:value-of select="times/startDateTime"/>
						<xsl:if test="times/startDateTime != times/endDateTime">
							--<xsl:value-of select="times/endDateTime"/>
						</xsl:if>
					</td>
				</xsl:if>

				<xsl:if test="position() mod 2 = 1">
					<td style="text-align: left;">
						<xsl:value-of select="times/startDateTime"/>
						<xsl:if test="times/startDateTime != times/endDateTime">
							--<xsl:value-of select="times/endDateTime"/>
						</xsl:if>
					</td>
				</xsl:if>

				<xsl:if test="position() mod 2 = 0">
					<td bgcolor="#D9D9F2" style="text-align: left;">
						<a href="?do=editevent&amp;ev={$evNum}">
							<xsl:value-of select="$evName"/>
						</a>
					</td>
				</xsl:if>

				<xsl:if test="position() mod 2 = 1">
					<td style="text-align: left;">
						<a href="?do=editevent&amp;ev={$evNum}">
							<xsl:value-of select="$evName"/>
						</a>
					</td>
				</xsl:if>

				<xsl:if test="position() mod 2 = 0">
					<td bgcolor="#D9D9F2" style="text-align: center;">
						<xsl:value-of select="location"/>
						<xsl:if test="state != '00'">
							,&#160;<xsl:value-of select="state"/>
						</xsl:if>
						<xsl:if test="state = '00'">
							&#160;(International)
						</xsl:if>
						<br/>Scope:<xsl:value-of select="geoscope"/>
					</td>
				</xsl:if>

				<xsl:if test="position() mod 2 = 1">
					<td style="text-align: center;"><xsl:value-of select="location"/>
						<xsl:if test="state != '00'">
							,&#160;<xsl:value-of select="state"/>
						</xsl:if>
						<xsl:if test="state = '00'">
							&#160;(International)
						</xsl:if>
					<br/>Scope:<xsl:value-of select="geoscope"/></td>
					</xsl:if>

				<xsl:if test="position() mod 2 = 0">
					<td bgcolor="#D9D9F2" style="text-align: right;">
						<xsl:choose>
							<xsl:when test="@approvedstatus = 'True'">
								Approved
							</xsl:when>
							<xsl:otherwise>
								Pending Approval <br/>
								Updated: <xsl:value-of select="@updateddate"/>
							</xsl:otherwise>
						</xsl:choose>
					</td>
				</xsl:if>
				
				<xsl:if test="position() mod 2 = 1">
					<td style="text-align: right;">
						<xsl:choose>
							<xsl:when test="@approvedstatus = 'True'">
								Approved
							</xsl:when>
							<xsl:otherwise>
								Pending Approval <br/>
								Updated: <xsl:value-of select="@updateddate"/>
							</xsl:otherwise>
						</xsl:choose>
					</td>
				</xsl:if>
				</tr>
</xsl:template>

</xsl:stylesheet>




