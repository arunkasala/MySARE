<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="projType"/>

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
    <span class="pagetitle">Project Profile: Page 1 of 2</span><br/>	  
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  <p>This form allows people to find information about your grant. There are two pages; please fill them out as completely as possible.</p>
  <xsl:apply-templates select="SAREroot/profileoptions"/>
  </body>
  </html>
</xsl:template>

<xsl:template match="profileoptions">
  <form method="post" name="userDetails">
  <table border="1"><tablebody>
     <xsl:for-each select="profilecategory">
       <xsl:call-template name="profilecategory"/>
     </xsl:for-each>
  </tablebody></table>
  <br/>
  <input type="submit" value="Save and Continue To Page 2" name="cmdSubmit" ID="cmdSubmit"/>&#160;&#160;
  <input type="reset" value="Reset Form" name="cmdReset" ID="cmdReset"/>&#160;&#160;
  <input type="button" value="Cancel" name="cmdCancel" onClick="history.go(-1)"/>
  </form>
</xsl:template>

<xsl:template name="profilecategory">
  <xsl:variable name="catname" select="@name"/>
  <xsl:variable name="type" select="@type"/>
  <xsl:if test="$catname!='practices' and $catname!='commodities'">
    <tr>
		<xsl:choose>
			<xsl:when test="$projType = 3">
				<xsl:if test="@label != 'Farmer Involvement'">
					<td>
						<b>
							<xsl:value-of select="@label"/>
						</b>
						<br/>
						<xsl:if test="@sublabel != ''">
							<i>
								<xsl:value-of select="@sublabel"/>
							</i>
							<br/>
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
									<br/>
									<xsl:call-template name="profilesubcat">
										<xsl:with-param name="catname" select="$catname"/>
									</xsl:call-template>
								</xsl:for-each>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
					</td>
				</xsl:if>				
			</xsl:when>
			<xsl:otherwise>
				<td>
					<b>
						<xsl:value-of select="@label"/>
					</b>
					<br/>
					<xsl:if test="@sublabel != ''">
						<i>
							<xsl:value-of select="@sublabel"/>
						</i>
						<br/>
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
								<br/>
								<xsl:call-template name="profilesubcat">
									<xsl:with-param name="catname" select="$catname"/>
								</xsl:call-template>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
					<br/>
				</td>
			</xsl:otherwise>
		</xsl:choose>
		
	</tr>
 </xsl:if>
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
  <xsl:variable name="chosen"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@priority='1']/@name"/></xsl:variable>
  <xsl:choose>
  <xsl:when test="$optionname = 'other' and $value !=''">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="@label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value="{$value}"/>
  </xsl:when>
  <xsl:when test="$optionname = 'other'">
    <input type="radio" name="{$catname}" value="{$optionname}" onClick="javascript:alert('Enter text for other');document.getElementById('{$catname}_{$optionname}').focus();"/><xsl:value-of select="@label"/>&#160;
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
        <input onkeyup="this.value=this.value.replace(/[^\d]/,'')" type="text" name="{$fieldname}" value="{$value}"/>
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


