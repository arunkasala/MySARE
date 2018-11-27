<?xml version="1.0" encoding="ISO-8859-1"?>
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
     <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
     <span class="pagetitle">Project Search</span><br/>
     <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
     <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
   </p>
   <form action="?do=searchProj" method="post" name="projectSearch">
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0"><tablebody>
       <tr>
         <td>Search string: </td>
         <td><input name="Query" type="text" size="60" maxlength="255" value="{$searchString}"/></td>
       </tr>
       <tr>
         <td>Project Type: </td>
         <td>
           <select name="projType">
             <option value=""> All Types </option>
             <xsl:for-each select="/SAREroot/projTypes/projType">
               <xsl:call-template name="option">
                 <xsl:with-param name="selected"><xsl:value-of select="$searchType"/></xsl:with-param>
                 <xsl:with-param name="value"><xsl:value-of select="typeCode"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
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
  <br/><br/>

  <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
  <tbody>
    <tr class="r2">
      <td>No.</td>
      <td>Project No.</td>
      <td>Title</td>
      <td>Region</td>
      <td>Year</td>
      <td>Type</td>
     </tr>
    <xsl:for-each select="/SAREroot/SAREgrant">
    <xsl:sort select="*[name()=$sortby]"/>
    <tr class="r1">
      <td><xsl:value-of select="$startrecord + position() + (-1)"/></td>
      <td><a href="?do=editProj&amp;pn={@projNum}"><xsl:value-of select="@projNum"/></a></td>
      <td><a href="?do=editProj&amp;pn={@projNum}"><xsl:value-of select="title"/></a>
      <xsl:for-each select="report">
        <br/><a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">
        <xsl:if test="@type=0">
          <xsl:value-of select="@year"/> Annual Report
        </xsl:if>
        <xsl:if test="@type=1">
          Final Report
        </xsl:if>
        <xsl:if test="@type=2">
          Proposal
        </xsl:if>
        </a>
      </xsl:for-each>
      </td>
      <td><xsl:value-of select="@regionCode"/></td>
      <td><xsl:value-of select="@year"/></td>
      <td><xsl:value-of select="@typeCode"/></td>
    </tr>
    </xsl:for-each>
  </tbody>
  </table>
  <br/><center><xsl:call-template name="nav"/></center>
</xsl:template>

<xsl:template name="option">
<!-- Generates an option to go in the drop-down list -->
  <xsl:param name="selected"/> <!-- value of the currently selected option -->
  <xsl:param name="value"/>  <!-- value of the option to be created -->
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
