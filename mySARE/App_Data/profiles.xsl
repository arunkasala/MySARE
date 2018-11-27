<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span class="pagetitle">Edit Project Details</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  <xsl:apply-templates select="SAREroot/profileoptions"/>
</xsl:template>

<xsl:template match="profileoptions">
  <form method="post" name="userDetails">
  <table><tablebody>

     <xsl:apply-templates select="profilecategory"/>

  </tablebody></table>
  
  <input type="submit" value="Submit Profile" name="cmdSubmit" ID="cmdSubmit"/><br/>
  <input type="reset" value="Reset Form" name="cmdReset" ID="cmdReset"/><br/>
  <input type="submit" value="Cancel " name="cmdCancel" ID="cmdCancel"/>
  
  </form>
  

</xsl:template>

<xsl:template match="profilecategory">
  <xsl:param name="value"/> <!-- value of the field -->
  <div id="@name">
    <td>
      <b><xsl:value-of select="@label"/><br/></b>
      <xsl:for-each select="profilesubcat">
        <xsl:call-template name="profilesubcat">
          <xsl:with-param name="catname"><xsl:value-of select="@name"/></xsl:with-param>
        </xsl:call-template>
      </xsl:for-each>
    </td>
  </div>
</xsl:template>

<xsl:template name="profilesubcat">
<!-- Generates an option to go in the drop-down list -->
  <xsl:param name="catname"/>
  <xsl:variable name="subcatname" select="@name"/>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/SAREgrant/profiles/profilecategory/profilesubcat[@name=$subcatname]/@value"/></xsl:variable>

  <!--  <xsl:if test="/SAREroot/profileoptions/profilecategory[$catname]/profilesubcat[1]/@name = $subcatname">
    test
  </xsl:if> -->

  <div id="name">
    <tr><td>
      <xsl:choose>
      <xsl:when test="@type='other'">
        <input type="checkbox" name="@name"/>&#160;Other:&#160;
        <input type="text" name="@name" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='checked'">
        <input type="checkbox" name="@name" checked="yes"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='checked')">
        <input type="checkbox" name="@name"/>
        <xsl:value-of select="@label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="@label"/>&#160;:
        <input type="text" name="@name" value="{$value}"/>
      </xsl:when>
      </xsl:choose>
    <br/>
    </td></tr>
  </div>
  
  
</xsl:template>

</xsl:stylesheet>