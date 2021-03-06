<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="sortby">year</xsl:param>
<xsl:param name="startrecord">1</xsl:param>
<xsl:param name="maxrecords">5</xsl:param>
<xsl:param name="resultsperpage">5</xsl:param>
<xsl:param name="searchString"/>
<xsl:param name="searchType"/>
<xsl:param name="searchRegion"/>
<xsl:param name="searchState"/>	
<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:variable name="thispage"><xsl:value-of select="ceiling($startrecord div $resultsperpage)"/></xsl:variable>
<xsl:variable name="lastpage"><xsl:value-of select="ceiling($maxrecords div $resultsperpage)"/></xsl:variable>

<xsl:template match="/">
   <p>
	 <xsl:if test="/SAREroot/user[@context='current']/firstname != ''">
		<span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
	 </xsl:if>
     <span class="pagetitle">Events Search</span><br/>
     <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
     <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
   </p>
   <p class="subtitle">You can search your MySARE events by string, event type, region and (or) state. Visit SARE’s <font color="blue">Calendar of Events</font> to search or browse the entire public calendar.</p>
   <form action="?do=searchEvents" method="post" name="eventsSearch">
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0"><tablebody>
       <tr>
         <td>Search string: </td>
         <td><input name="Query" type="text" size="60" maxlength="255" value="{$searchString}"/></td>
       </tr>
	   <tr>
		<td>Event Type: </td>
		<td>
			<select name="eventType">
			<option value=""> All Types </option>
			<xsl:for-each select="/SAREroot/eventtypes/eventtype">
				 <xsl:call-template name="option">
					 <xsl:with-param name="selected">
						 <xsl:value-of select="/SAREroot/calendarEvent/type/code"/>
					 </xsl:with-param>
					 <xsl:with-param name="value">
						 <xsl:value-of select="code"/>
					 </xsl:with-param>
					 <xsl:with-param name="label">
						 <xsl:value-of select="name"/>
					 </xsl:with-param>
				 </xsl:call-template>
			 </xsl:for-each>
			</select>
		</td>
	   </tr>	
       <tr>
         <td>Region: </td>
         <td>
           <select name="region">
             <option value=""> All Regions </option>
             <xsl:for-each select="/SAREroot/regions/region">
               <xsl:call-template name="option">
                 <xsl:with-param name="selected"><xsl:value-of select="$searchRegion"/></xsl:with-param>
                 <xsl:with-param name="value"><xsl:value-of select="regionCode"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
               </xsl:call-template>
             </xsl:for-each>
           </select>
         </td>
       </tr>
	   <tr>
         <td>State: </td>
         <td>
           <select name="state">
             <option value=""> All States </option>
			 <xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
			   <xsl:if test="abbr != ''">
			   <xsl:call-template name="option">
				 <xsl:with-param name="selected"><xsl:value-of select="$searchState"/></xsl:with-param>
				 <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
				 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
			   </xsl:call-template>
			   </xsl:if>
			 </xsl:for-each>			  
           </select>
         </td>
       </tr>
     </tablebody></table>
     <input name="Submit" type="submit" value="Search"/>
  </form>
  <br/>
  
  <span class="pagetitledown">Results</span>
	<span style="font-weight: bold;">
		<br/>
		Click event links to view and edit your MySARE events.
		<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/projectlist.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="../images/help.png" border="0" /></a>]]></xsl:text> -->
		<br/>
	</span>
  <br/><br/>

  <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
  <tbody>
    <tr class="r2">
		<th style="text-align: left; width: 20%;">Event Dates</th>
		<th style="text-align: center; width: 50%;">Title</th>
		<th style="text-align: center; width: 15%;">Location and Scope</th>
		<th style="text-align: right; width: 15%;">Approval Status</th>		
     </tr>
	  <xsl:apply-templates select="SAREroot"/>
	  <br/>
	  <br/>
	  <small>
		  This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.
	  </small>
  </tbody>
</table>
<br/>

<center>
  <xsl:call-template name="nav"/>
</center>

</xsl:template>

	<xsl:template match="SAREroot">

		
		<table id="events" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
			<tbody>
				
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

	<xsl:template name="calendarEvent">
		<xsl:variable name="evNum" select="@number"/>
		<xsl:variable name="evName" select="name"/>
		<tr class="r1">
			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2" style="text-align: left;">			
				<xsl:value-of select="times/startDateTime"/>
				<xsl:if test="times/startDateOrder != times/endDateOrder">
					-<xsl:value-of select="times/endDateTime"/>
				</xsl:if>
			</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 1">
				<td style="text-align: left;">
						<xsl:value-of select="times/startDateTime"/>
						<xsl:if test="times/startDateOrder != times/endDateOrder">
							-<xsl:value-of select="times/endDateTime"/>
						</xsl:if>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 0">
				<td bgcolor="#D9D9F2" style="text-align: center;">					
				<a href="?do=editevent&amp;ev={$evNum}">
					<xsl:value-of select="$evName"/>
				</a>
			</td>			
			</xsl:if>

			<xsl:if test="position() mod 2 = 1">
				<td style="text-align: center;">
						<a href="?do=editevent&amp;ev={$evNum}">
							<xsl:value-of select="$evName"/>
						</a>					
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 =0">
				<td bgcolor="#D9D9F2" style="text-align: left;">
					<xsl:value-of select="location"/>
					<xsl:choose>
						<xsl:when test="state = '00'">
							(International)
						</xsl:when>
						<xsl:when test="state = '01'">
							(National)
						</xsl:when>
						<xsl:otherwise>,&#160;<xsl:value-of select="state"/>
						</xsl:otherwise>
					</xsl:choose>
					<br/>Scope:<xsl:value-of select="geoscope"/>
				</td>
			</xsl:if>

			<xsl:if test="position() mod 2 = 1">
				<td style="text-align: left;">
					<xsl:value-of select="location"/>
					<xsl:choose>
						<xsl:when test="state = '00'">
							(International)
						</xsl:when>
						<xsl:when test="state = '01'">
							(National)
						</xsl:when>
						<xsl:otherwise>,&#160;<xsl:value-of select="state"/>
						</xsl:otherwise>
					</xsl:choose>
				<br/>Scope:<xsl:value-of select="geoscope"/>
				</td>				
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
	
<xsl:template name="option">
<!-- Generates an option to go in the drop-down list -->
<xsl:param name="selected"/>
<!-- value of the currently selected option -->
<xsl:param name="value"/>
<!-- value of the option to be created -->
<xsl:param name="label"/> <!-- label of the option to be created -->
  <xsl:choose>
    <xsl:when test="$selected=$value">
     <option value="{$value}" selected="selected"><xsl:value-of select="$label"/></option>
    </xsl:when>
    <xsl:otherwise>
      <option value="{$value}"><xsl:value-of select="$label"/></option>
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="nav">
      <xsl:param name="count">1</xsl:param>
      <xsl:choose>
        <xsl:when test="$count &lt; ($lastpage + 1)">
          <xsl:choose>
            <xsl:when test="($count=$thispage) and ($lastpage != 1)">
              <b><xsl:value-of select="$count"/></b><xsl:text>&#160;</xsl:text>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
            <xsl:when test="$count &lt; $thispage">
              <xsl:choose>
                <xsl:when test="$count=1">
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:choose>
                    <xsl:when test="$count &lt; ($thispage - 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="$count &gt; ($thispage - 6)">
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>&#160;</xsl:text>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>...</xsl:text>
                </xsl:when>
              </xsl:choose>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
            <xsl:when test="$count &gt; $thispage">
              <xsl:choose>
                <xsl:when test="$count=$lastpage">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                </xsl:when>
                <xsl:when test="$count &lt; ($thispage + 6)">
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:if test="$count &lt; ($thispage + 5)">&#160;</xsl:if>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                </xsl:when>
              </xsl:choose>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
          <br/>
          <xsl:if test="$thispage &gt; 1"><a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$thispage - 1}">&lt;&lt; Previous</a>&#160;&#160; </xsl:if>
          <xsl:if test="$thispage &lt; $lastpage">&#160;&#160;<a href="?do=searchProj&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$thispage + 1}">Next &gt;&gt;</a></xsl:if>
        </xsl:otherwise>
      </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
