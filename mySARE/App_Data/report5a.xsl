<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- DWXMLSource="testProject.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>
<xsl:param name="reptsection">1</xsl:param>
      
<xsl:template match="/">

          <xsl:choose>
        <xsl:when test="$reptsection=0">
          <xsl:apply-templates mode="full" select="root">
                
                <xsl:sort select="root/SAREgrant/report/section/subsection/@order" data-type="number" order="descending"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:otherwise>
          <xsl:apply-templates mode="partial" select="root"/>
        </xsl:otherwise>
      </xsl:choose>
  
</xsl:template>

<xsl:template match="/root" mode="full">
  
    <xsl:apply-templates mode="full" select="SAREgrant">
      
    </xsl:apply-templates>
  
</xsl:template>
<xsl:template match="/root" mode="partial">
  
  <xsl:apply-templates mode="partial" select="SAREgrant"/>
  
</xsl:template>

  <xsl:template match="SAREgrant" mode="full">
    <span class="pagetitle"> <xsl:value-of select="title"/></span>
<br/>
    <xsl:value-of select="@projNum"/>
  <form action="?do=submitRept" method="post" name="reportform">
    <xsl:for-each select="report/section">
      <xsl:variable name="sectionname" select="name"/>
      <xsl:variable name="sectionID" select="@ID"/>
      <b><xsl:value-of select="$sectionname"/></b><br/>
      <xsl:for-each select="subsection">
        <xsl:variable name="subheading" select="heading"/>
        <xsl:variable name="subheadingID" select="@order"/>
        <xsl:variable name="text" select="text"/>
        <input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>
        <br/>
        <textarea name="section{$sectionID}subtext{$subheadingID}" rows="15" cols="50">
          <xsl:value-of select="$text"/>
        </textarea>
        <p/>
      </xsl:for-each>
    </xsl:for-each>
    <p/>
    <input name="Submit" type="submit" value="Submit"/>
    <input name="Cancel" type="reset" value="Undo most recent changes"/>
  </form>
  </xsl:template>
  
  <xsl:template match="SAREgrant" mode="partial">
    <span class="pagetitle"> <xsl:value-of select="title"/></span>
<br/>
    <xsl:value-of select="@projNum"/>
    <xsl:value-of select="$reptsection"/>
  <form action="?do=submitRept" method="post" name="reportform">

    <xsl:for-each select="report/section">
      <xsl:variable name="sectionname" select="name"/>
      <xsl:variable name="sectionID" select="@ID"/>
    <xsl:if test="$sectionID=$reptsection">
      <b><xsl:value-of select="$sectionname"/></b><br/>
      <xsl:for-each select="subsection">
        <xsl:variable name="subheading" select="heading"/>
        <xsl:variable name="subheadingID" select="@order"/>
        <xsl:variable name="text" select="text"/>
        <input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>
        <br/>
        <textarea name="section{$sectionID}subtext{$subheadingID}" rows="15" cols="50">
          <xsl:value-of select="$text"/>
        </textarea>
        <p/>
        </xsl:for-each>  
        </xsl:if>
      </xsl:for-each>  
  
    <input name="Submit" type="submit" value="Submit"/>
    <input name="Cancel" type="reset" value="Undo most recent changes"/>
  </form>
    </xsl:template>
  </xsl:stylesheet>
