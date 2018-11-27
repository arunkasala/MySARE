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
<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:variable name="thispage"><xsl:value-of select="ceiling($startrecord div $resultsperpage)"/></xsl:variable>
<xsl:variable name="lastpage"><xsl:value-of select="ceiling($maxrecords div $resultsperpage)"/></xsl:variable>

<xsl:template match="/">
  <html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
  <head>
	<script LANGUAGE="JavaScript">
	<![CDATA[
		//Stolen from http://www.harrymaugans.com/
        function toggleDiv(divid){
            if(document.getElementById(divid).style.display == 'none'){
                  document.getElementById(divid).style.display = 'block';
            }else{
                  document.getElementById(divid).style.display = 'none';
            }
        }
  	]]>
	</script>

  <style type="text/css">

div.wrapper
{
	margin-bottom: 1em;
	width: 60em;
}

span.option
{
	float: left;
	width: 20em;  /* accommodate the widest item */
}

/* stop the floating after the list */
br
{
	clear: left;
}
</style>
</head>

<body>
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span class="pagetitle">Search Projects by Profile</span>
<p class="subtitle">Click the title of each group of profile options to show or hide it.<br/>Even fields in groups that are hidden will be part of the search.</p>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  
  <xsl:apply-templates select="SAREroot/profileoptions"/>
  </body>
  </html>
</xsl:template>

<xsl:template match="profileoptions">
  <form method="post" name="userDetails">
  <div>
     <xsl:for-each select="profilecategory">
       <xsl:call-template name="profilecategory"/>
       <p/>
     </xsl:for-each>
  </div>

  <br/>
  <input type="submit" value="Search" name="profileSearch" ID="profileSearch"/><br/>
  <input type="reset" value="Reset Form" name="cmdReset" ID="cmdReset"/><br/>
  <input type="submit" value="Cancel" name="cmdCancel" ID="cmdCancel"/>
  
  </form>

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
      <td><a href="?do=editProj&amp;pn={@projNum}"><xsl:value-of select="title"/></a></td>
      <td><xsl:value-of select="@regionCode"/></td>
      <td><xsl:value-of select="@year"/></td>
      <td><xsl:value-of select="@typeCode"/></td>
    </tr>
    </xsl:for-each>
  </tbody>
  </table>
  <br/><center><xsl:call-template name="nav"/></center>

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
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:choose>
                    <xsl:when test="$count &lt; ($thispage - 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="$count &gt; ($thispage - 6)">
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>&#160;</xsl:text>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>...</xsl:text>
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
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                </xsl:when>
                <xsl:when test="$count &lt; ($thispage + 6)">
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:if test="$count &lt; ($thispage + 5)">&#160;</xsl:if>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$count}"><xsl:value-of select="$count"/></a>
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
          <xsl:if test="$thispage &gt; 1"><a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$thispage - 1}">&lt;&lt; Previous</a>&#160;&#160; </xsl:if>
          <xsl:if test="$thispage &lt; $lastpage">&#160;&#160;<a href="?do=profilesearch&amp;q={$searchString}&amp;region={$searchRegion}&amp;projType={$searchType}&amp;page={$thispage + 1}">Next &gt;&gt;</a></xsl:if>
        </xsl:otherwise>
      </xsl:choose>
  </xsl:template>

<xsl:template name="profilecategory">
  <xsl:variable name="catname" select="@name"/>
  <xsl:variable name="type" select="@type"/>

      <b><a href="javascript:;" onmousedown="toggleDiv(&apos;{@label}&apos;);"><xsl:value-of select="@label"/></a></b>
      <div class="wrapper" id="{@label}" style="display:none;margin-left:1em">
<!--
      <xsl:if test="@sublabel != ''">
        <i><xsl:value-of select="@sublabel"/></i><br/>
      </xsl:if>
-->
      <xsl:choose>
      <xsl:when test="$type = 'radio'">
        <xsl:for-each select="profileoption">
          <xsl:call-template name="radio">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
          <br/>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>
        <xsl:for-each select="profileoption">
          <xsl:call-template name="option">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
          <br/>
        </xsl:for-each>
        <xsl:for-each select="profilesubcat">
          <xsl:call-template name="profilesubcat">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
        </xsl:for-each>
      </xsl:otherwise>
      </xsl:choose>
      </div>

</xsl:template>

<xsl:template name="profilesubcat">
  <xsl:param name="catname"/>
  <xsl:variable name="subcatname" select="@name"/>
  <b><a href="javascript:;" onmousedown="toggleDiv(&apos;{@name}&apos;);"><xsl:value-of select="@label"/></a></b><br/>
  <div class="wrapper" id="{@name}" style="display:none;margin-left:1em">
  <xsl:for-each select="profileoption">
      <span class="option">
      <xsl:call-template name="optionsub">
        <xsl:with-param name="catname" select="$catname"/>
        <xsl:with-param name="subcatname" select="$subcatname"/>
      </xsl:call-template>
      </span>
  </xsl:for-each>
  </div>
</xsl:template>

<xsl:template name="radio">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="chosen"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@priority='1']/@name"/></xsl:variable>
  <xsl:choose>
  <xsl:when test="$optionname = 'other' and $value !=''">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="@label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value="{$value}"/>
  </xsl:when>
  <xsl:when test="$optionname = 'other'">
    <input type="radio" name="{$catname}" value="{$optionname}"/><xsl:value-of select="@label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value=""/>
  </xsl:when>
  <xsl:when test="$chosen = $optionname">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="@label"/>
  </xsl:when>
  <xsl:otherwise>
    <input type="radio" name="{$catname}" value="{$optionname}"/><xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="option">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$catname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="@label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

<xsl:template name="optionsub">
  <xsl:param name="catname"/>
  <xsl:param name="subcatname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$subcatname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profilesubcat[@name=$subcatname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="@label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

</xsl:stylesheet>



