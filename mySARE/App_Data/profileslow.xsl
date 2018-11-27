<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
  <head>
	<script LANGUAGE="JavaScript">
		<![CDATA[
		  document.onkeydown = function(e)		  
		  {
			  e = e? e : window.event;
			  var k = e.keyCode? e.keyCode : e.which? e.which : null;

			  if (k == 13 && document.cmdSubmit.value == false)
			  {
			  
				  if (e.preventDefault)
					e.preventDefault();
				  return false;
			  }
			  return true;
		  };
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
    <span class="pagetitle">Project Profile: Page 2</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>

  <xsl:apply-templates select="SAREroot/profileoptions"/>
  </body>
  </html>
</xsl:template>

<xsl:template match="profileoptions">
  <xsl:variable name="catachoice"><xsl:value-of select="/SAREroot/profile/profilecategory[@name='cata']/profileoption[@value='True']/@name"/></xsl:variable>
  <xsl:variable name="catbchoice2"><xsl:value-of select="/SAREroot/profile/profilecategory[@name='catb']/profileoption[@value='True']/@name"/></xsl:variable>
  <xsl:variable name="catbchoice"><xsl:value-of select="/SAREroot/profileoptions/profilecategory[@name='catb']/profileoption[@name=$catbchoice2]/@map"/></xsl:variable>
  <form method="post" name="userDetails">
  
  <table border="1"><tablebody>
     <tr><td>
     <!--<b>Selection Refinement</b><br/>
     <i>Please refine your selection from categories A and B from the previous page. </i><br/><br/>-->
     <xsl:for-each select="profilecategory">
       <xsl:if test="@name='practices' or @name='commodities'">
         <xsl:for-each select="profilesubcat">
           <xsl:if test="@name=$catachoice or @name=$catbchoice">
             <xsl:call-template name="profilesubcat"/><br/>
           </xsl:if>
         </xsl:for-each>
       </xsl:if>
     </xsl:for-each>
     </td></tr>
     <xsl:for-each select="profilecategory">
       <xsl:if test="@name='practices' or @name='commodities'">
         <xsl:call-template name="profilecategory"/>
       </xsl:if>
     </xsl:for-each>
  </tablebody></table>

  <br/>
  <input type="submit" value="Save and Back To My Project" name="cmdSubmit" ID="cmdSubmit"/>&#160;&#160;
  <!-- <input type="button" value="Save and Return to Page 1" onClick="history.go(-1)"/>&#160;&#160; -->
  <input type="submit" value="Save and Return to Page 1" name="cmdSubmit" ID="cmdSubmit"/>&#160;&#160;
  <input type="reset" value="Reset Form" name="cmdReset" ID="cmdReset"/>&#160;&#160;
  <input type="submit" value="Cancel" name="cmdCancel" ID="cmdCancel"/>

  </form>
</xsl:template>

<xsl:template name="profilecategory">
  <xsl:variable name="catachoice"><xsl:value-of select="/SAREroot/profile/profilecategory[@name='cata']/profileoption[@value='True']/@name"/></xsl:variable>
  <xsl:variable name="catbchoice2"><xsl:value-of select="/SAREroot/profile/profilecategory[@name='catb']/profileoption[@value='True']/@name"/></xsl:variable>
  <xsl:variable name="catbchoice"><xsl:value-of select="/SAREroot/profileoptions/profilecategory[@name='catb']/profileoption[@name=$catbchoice2]/@map"/></xsl:variable>
  <xsl:variable name="catname" select="@name"/>
  <xsl:variable name="type" select="@type"/>
    <tr><td>
      <b><xsl:value-of select="@label"/></b><br/>
      <xsl:if test="@sublabel != ''">
        <i><xsl:value-of select="@sublabel"/></i><br/>
      </xsl:if>
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
          <xsl:if test="@name!=$catachoice and @name!=$catbchoice">
          <br/>
          <xsl:call-template name="profilesubcat">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
          </xsl:if>
        </xsl:for-each>
      </xsl:otherwise>
      </xsl:choose>
    <br/></td></tr>
</xsl:template>

<xsl:template name="profilesubcat">
  <xsl:param name="catname"/>
  <xsl:variable name="subcatname" select="@name"/>
  <b><xsl:value-of select="@label"/></b><br/>
  <div class="wrapper">
  <xsl:for-each select="profileoption">
      <span class="option">
      <xsl:call-template name="optionsub">
        <xsl:with-param name="catname" select="$catname"/>
        <xsl:with-param name="subcatname" select="$subcatname"/>
      </xsl:call-template>
      </span>
  </xsl:for-each>
  </div>
  <br/>
</xsl:template>

<xsl:template name="radio">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:choose>
  <xsl:when test="$optionname = 'other' and $value !=''">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="@label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value="{$value}"/>
  </xsl:when>
  <xsl:when test="$optionname = 'other'">
    <input type="radio" name="{$catname}" value="{$optionname}"/><xsl:value-of select="@label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value=""/>
  </xsl:when>
  <xsl:when test="$value = 'True'">
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
        <!--<input type="checkbox" name="{$fieldname}"/>-->other:&#160;
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


