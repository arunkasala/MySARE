<?xml version="1.0" encoding="iso-8859-1"?>
<!-- DWXMLSource="project_test.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

<xsl:param name="useradmin"/>
	
<xsl:template match="/">

<xsl:apply-templates select="SAREroot"/>

</xsl:template>

<xsl:template match="SAREroot">
	<xsl:choose>
		<xsl:when test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
			<span class="pagetitle">
				My Region SARE-Funded Projects
			</span>
			<br/>
			<p class="subtitle"><b><a>View/Edit/Approve Reports and Projects</a></b></p>
			<p class="subtitle">Below is a list of project(s) with Overviews, Annual and/or Final Reports pending approval.</p>
			<a href="?do=sendpicall">Send Call for Reports to PIs</a>
			<br/>
		</xsl:when>
		<xsl:otherwise>
			<span class="pagetitle">
				My SARE-Funded Projects
			</span>
			<p class="subtitle">Submit/View Projects list.</p>
		</xsl:otherwise>
	</xsl:choose>
    
	<!--<span style="font-weight: bold;"><br/>
		Click report links to View and Edit reports
        <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/projectlist.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="../images/help.png" border="0" /></a>]]></xsl:text>
        <br/>
	</span>-->
<!--
    <xsl:if test="SAREgrant/report[@type = 2]">
	  <span class="pagetitledown">Proposals</span><br/>
      <table class="sortable" id="proposals" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
	      <tbody>
            <tr>
				<th style="text-align: center;">Proposal ID</th>
				<th style="text-align: center;">Title</th>
				<th style="text-align: center;" width="20%">Approval Status</th>
			</tr>
			<xsl:choose>
            <xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='admin']">
			  <xsl:for-each select="SAREgrant/report[@type = 2]">
                <xsl:sort select="@submitteddate"/>
                <xsl:call-template name="report"/>
              </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
              <xsl:for-each select="SAREgrant/report[@type = 2]">
                <xsl:sort select="@year"/>
                <xsl:call-template name="report"/>
              </xsl:for-each>
            </xsl:otherwise>
            </xsl:choose>
           </tbody>
      </table>
    </xsl:if>
 
    <br/><span class="pagetitledown">Reports</span>
    <br/>Click button to Submit/View Reports.-->
    
    <table class="sortable" id="reports" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
        <tbody>			
			<tr>
				<th style="text-align: left; width: 20%">Project Number</th>
				<th style="text-align: left; width: 50%;">Project Title</th>
				<!--
                <th style="text-align: center; width: 20%;">Report Year and Type</th>
				<th style="text-align: center; width: 15%;">Approval Status and Date</th>
				-->
			</tr>

			<xsl:choose>
            <xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='natAdmin' or @code='admin'] and $useradmin = ''">

<!--		  <xsl:for-each select="SAREgrant/report[@type = 0 or @type = 1]"> -->
			  <xsl:for-each select="SAREgrant">
              <xsl:sort select="@updateddate" order="ascending"/>
			 <xsl:for-each select="report[@submittedstatus = 'True']">
			        <xsl:call-template name="report"/>
              </xsl:for-each>
				  <xsl:if test="resource">
					  <xsl:call-template name="res"/>
				  </xsl:if>
                <xsl:if test="not(report)">
                  <xsl:call-template name="SAREgrant"/>
                </xsl:if>
              </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>

<!--          <xsl:for-each select="SAREgrant/report[@type = 0 or @type = 1]"> -->

              <xsl:for-each select="/SAREroot/SAREgrant/@projNum">
              <xsl:sort select="@year"/>
              <xsl:call-template name="report"/>

            </xsl:for-each>
            </xsl:otherwise>
            </xsl:choose>

		</tbody>
	</table>
	<xsl:choose>
		<xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='natAdmin' or @code='admin']">
		</xsl:when>
		<xsl:otherwise>
			<a href="?do=claimProj">Retrieve New Project</a><br/>
		</xsl:otherwise>			
	</xsl:choose>
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
	
</xsl:template>

<!--
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
-->

<xsl:template name="report">
		<xsl:variable name="projNum" select="../@projNum"/>
		<xsl:variable name="projTitle" select="../title"/>
		<xsl:variable name="projType" select="../@typeCode"/>
			<tr class="r1">
				<td nowrap="true"><!-- <a href="?do=editProj&amp;pn={$projNum}"><xsl:value-of select="$projNum"/></a> -->
					<b><xsl:value-of select="$projNum"/></b></td>
				<td><!-- <a href="?do=editProj&amp;pn={$projNum}"><xsl:value-of select="$projTitle"/></a> -->
					<b><xsl:value-of select="$projTitle"/></b>
			</td>				
				<xsl:choose>
					<xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='natAdmin' or @code='admin']">
						<td>
							<xsl:if test="$projType != 10">
								<input type="button" value="Approve/View Reports" onclick="location.href='?do=editProj&amp;pn={$projNum}'"/>
							</xsl:if>
							<xsl:if test="$projType = 10">
								<input type="button" value="Approve/View Reports" onclick="location.href='?do=editPdp&amp;pn={$projNum}'"/>
							</xsl:if>
						</td>
					</xsl:when>
					<xsl:otherwise>
						<td>
							<xsl:if test="$projType != 10">
								<input type="button" value="Submit/View Reports" onclick="location.href='?do=editProj&amp;pn={$projNum}'"/>
							</xsl:if>
							<xsl:if test="$projType = 10">
								<input type="button" value="Submit/View Reports" onclick="location.href='?do=editPdp&amp;pn={$projNum}'"/>
							</xsl:if>
						</td>
					</xsl:otherwise>
				</xsl:choose>						
				<!-- 
				<td>
					<a href="?do=editRept&amp;pn={$projNum}&amp;y={@year}&amp;t={@type}">
						<xsl:if test="@type = 2">Edit <xsl:value-of select="@year"/> Proposal Narrative</xsl:if> 
						<xsl:if test="@type = 0">Edit <xsl:value-of select="@year"/> Annual Report</xsl:if>
						<xsl:if test="@type = 1">Edit <xsl:value-of select="@year"/> Final Report</xsl:if>
					</a>
					<br/>
					<a href="?do=viewRept&amp;pn={$projNum}&amp;y={@year}&amp;t={@type}">
                    	<xsl:if test="@type = 2">Preview <xsl:value-of select="@year"/> Proposal Narrative</xsl:if>
						<xsl:if test="@type = 0">Preview <xsl:value-of select="@year"/> Annual Report</xsl:if>
						<xsl:if test="@type = 1">Preview <xsl:value-of select="@year"/> Final Report</xsl:if>
                    </a>

				</td>
				
				<td style="text-align: right;">
    <xsl:choose>
    <xsl:when test="/SAREroot/SAREgrant/report[@approvedstatus = 'True' and @submittedstatus = 'False']">
    Approved
    </xsl:when>
    <xsl:otherwise>
    Pending Approval <br/>
        <xsl:choose>
        <xsl:when test="/SAREroot/SAREgrant/report[@submittedstatus = 'True']">
        Submitted: <xsl:value-of select="@updateddate"/>
        </xsl:when>
        <xsl:otherwise>
        Updated: <xsl:value-of select="@updateddate"/>
        </xsl:otherwise>
        </xsl:choose>
    </xsl:otherwise>
    </xsl:choose>

				</td>-->
				</tr>
</xsl:template>

	<xsl:template name="res">
		<xsl:variable name="projNum" select="/SAREroot/SAREgrant/resource/@projNum"/>
		<xsl:variable name="projTitle" select="/SAREroot/SAREgrant/resource/title"/>
		<xsl:variable name="projType" select="/SAREroot/SAREgrant/resource/@typeCode"/>
		<tr class="r1">
			<td nowrap="true">
				<b>
					<xsl:value-of select="$projNum"/>
				</b>
			</td>
			<td>
				<b>
					<xsl:value-of select="$projTitle"/>
				</b>
			</td>
			<xsl:choose>
				<xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='natAdmin' or @code='admin']">
					<td>
						<xsl:choose>
							<xsl:when test="$projType != 10">
								<input type="button" value="Approve/View Reports and Products" onclick="location.href='?do=editProj&amp;pn={$projNum}'"/>
							</xsl:when>
							<xsl:otherwise>
								<input type="button" value="Approve/View Reports and Products" onclick="location.href='?do=editPdp&amp;pn={$projNum}'"/>
							</xsl:otherwise>
						</xsl:choose>
					</td>
				</xsl:when>
				<xsl:otherwise>
					<td>
						<xsl:choose>
							<xsl:when test="$projType = 10">
								<input type="button" value="Submit/View Reports and Products" onclick="location.href='?do=editPdp&amp;pn={$projNum}'"/>
							</xsl:when>
							<xsl:otherwise>
								<input type="button" value="Submit/View Reports and Products" onclick="location.href='?do=editProj&amp;pn={$projNum}'"/>
							</xsl:otherwise>
						</xsl:choose>
					</td>
				</xsl:otherwise>
			</xsl:choose>
		</tr>
	</xsl:template>
	
			<xsl:template name="SAREgrant">
		<xsl:variable name="projNum" select="@projNum"/>
		<xsl:variable name="projTitle" select="title"/>
			<tr class="r1">
<!--				<td><a href="?do=editProj&amp;pn={$projNum}"><xsl:value-of select="$projNum"/></a></td>
				<td><xsl:value-of select="$projTitle"/></td>
				<td>
No Reports Submitted
				</td>
				
				<td style="text-align: right;">
	
        <xsl:choose>
        <xsl:when test="@submittedstatus = 'True'">
        Submitted: <xsl:value-of select="@updateddate"/>
        </xsl:when>
        <xsl:otherwise>
        Updated: <xsl:value-of select="@updateddate"/>
        </xsl:otherwise>
        </xsl:choose>

				</td>-->
				</tr>
		
</xsl:template>

</xsl:stylesheet>




