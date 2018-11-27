<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="sortby">lastname</xsl:param>
<xsl:param name="startrecord">1</xsl:param>
<xsl:param name="resultsperpage">5</xsl:param>
<xsl:param name="searchString"/>
<xsl:param name="searchRole"/>
<xsl:param name="searchRegion"/>
<xsl:param name="searchState"/>
<xsl:param name="searchRecent">False</xsl:param>
<xsl:param name="message">132415135135</xsl:param>
<xsl:param name="message2"/>

<xsl:variable name="thispage"><xsl:value-of select="ceiling($startrecord div $resultsperpage)"/></xsl:variable>
<xsl:variable name="lastpage"><xsl:value-of select="ceiling(count(/SAREroot/user) div $resultsperpage)"/></xsl:variable>

<xsl:template match="/">
   <p>
     <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
     <span class="pagetitle">User Search</span><br/>
     <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
     <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
   </p>
   <form action="" method="post" name="userSearch">
     <input type="hidden" name="formID" value="userSearch"/>
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
     <tablebody>
       <tr>
         <td>Search Organization, E-mail, Address, First OR Last Name Fields: </td>
         <td><input name="Query" type="text" size="60" maxlength="255" value="{$searchString}"/></td>
       </tr>
       <tr>
         <td>User Role: </td>
         <td>
           <select name="userRole">
             <option value=""> All Roles </option>
             <xsl:for-each select="/SAREroot/userRoles/userRole">
               <xsl:sort select="@priority" data-type="number" order="ascending"/>
               <xsl:call-template name="option">
                 <xsl:with-param name="selected"><xsl:value-of select="$searchRole"/></xsl:with-param>
                 <xsl:with-param name="value"><xsl:value-of select="@code"/></xsl:with-param>
                 <xsl:with-param name="label"><xsl:value-of select="@description"/></xsl:with-param>
               </xsl:call-template>
             </xsl:for-each>
           </select>
           &#160;
           <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/usersearch.htm#roles" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
         </td>
       </tr>
       <tr>
         <td>Region: </td>
         <td>
           <select name="region">
             <option value=""> All Regions </option>
             <xsl:for-each select="/SAREroot/regions/region">
               <xsl:sort select="name"/>
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
             <xsl:for-each select="/SAREroot/states/state">
               <xsl:sort select="name"/>
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
       <tr>
         <td/>
         <td>
           <xsl:choose>
               <xsl:when test="$searchRecent='True'">
                     <input name="recent" type="checkbox" checked="checked"/>
                     <label for="recent">Search only new or recently changed users</label>
               </xsl:when>
               <xsl:otherwise>
                     <input name="recent" type="checkbox"/>
                     <label for="recent">Search only new or recently changed users</label>
               </xsl:otherwise>
           </xsl:choose>
           <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/usersearch.htm#recent" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
         </td>
       </tr>
     </tablebody>
     </table>
     <input name="Submit" type="submit" value="Search"/>
  </form>
  <br/>
  
  <span class="pagetitledown">Results</span>
  <br/><br/>

  <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
  <tbody>
    <tr class="r2">
      <td>No.</td>
      <td>Name</td>
      <td>Organization</td>
      <td>Position</td>
      <td>Phone</td>
      <td>Email</td>
     </tr>
    <xsl:for-each select="SAREroot/user[@context='searchresult']">
    <xsl:sort select="*[name()=$sortby]"/>
    <xsl:if test="position() &gt; $startrecord+(-1) and position() &lt; $startrecord+$resultsperpage">
    <tr class="r1">
		
	  <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><xsl:value-of select="position()"/></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="position()"/></td>
	  </xsl:if>

	  <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><a href="?do=editUser&amp;user={@username}"><xsl:value-of select="lastname"/>, <xsl:value-of select="firstname"/></a></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 1">
		<td><a href="?do=editUser&amp;user={@username}"><xsl:value-of select="lastname"/>, <xsl:value-of select="firstname"/></a></td>
	  </xsl:if>
		
      <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><xsl:value-of select="organization/@name"/></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="organization/@name"/></td>
	  </xsl:if>
		
      <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><xsl:value-of select="organization/position"/></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="organization/position"/></td>
	  </xsl:if>

	  <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><xsl:value-of select="contact/numPhone"/></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="contact/numPhone"/></td>
	  </xsl:if>
		
	  <xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2"><xsl:value-of select="contact/email"/></td>
	  </xsl:if>

	  <xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="contact/email"/></td>
	  </xsl:if>
		
    </tr>
    </xsl:if>
    </xsl:for-each>
  </tbody>
  </table>
  <br/><center><xsl:call-template name="nav"/></center>
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
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a>
                  <xsl:choose>
                    <xsl:when test="$count &lt; ($thispage - 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="$count &gt; ($thispage - 6)">
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a><xsl:text>&#160;</xsl:text>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a><xsl:text>...</xsl:text>
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
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a>
                </xsl:when>
                <xsl:when test="$count &lt; ($thispage + 6)">
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a>
                  <xsl:if test="$count &lt; ($thispage + 5)">&#160;</xsl:if>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do=userlist&amp;page={$count}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}"><xsl:value-of select="$count"/></a>
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
          <xsl:if test="$thispage &gt; 1"><a href="?do=userlist&amp;page={$thispage - 1}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}">&lt;&lt; Previous</a>&#160;&#160; </xsl:if>
          <xsl:if test="$thispage &lt; $lastpage">&#160;&#160;<a href="?do=userlist&amp;page={$thispage + 1}&amp;userRole={$searchRole}&amp;region={$searchRegion}&amp;state={$searchState}">Next &gt;&gt;</a><xsl:value-of select="$searchRole"/></xsl:if>
        </xsl:otherwise>
      </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
