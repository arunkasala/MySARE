<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- DWXMLSource="testProject.xml" -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>
<xsl:param name="reptsection">0</xsl:param>
<xsl:param name="reptsubsection">0</xsl:param>
      
<xsl:template match="/">
  <xsl:choose>
  <xsl:when test="$reptsection=0">
    <xsl:apply-templates mode="full" select="SAREroot"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:apply-templates mode="partial" select="SAREroot"/>
  </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template match="/SAREroot" mode="full">
  
    <xsl:apply-templates mode="full" select="SAREgrant">
      
    </xsl:apply-templates>
  
</xsl:template>
<xsl:template match="/SAREroot" mode="partial">
  
  <xsl:apply-templates mode="partial" select="SAREgrant"/>
  
</xsl:template>

<xsl:template match="textTypes" mode="list">
<xsl:param name="chosenType">2</xsl:param>
  <select name="listParagraphType" id="listParagraphType" size="1">
    <xsl:apply-templates mode="list" select="textType">
      <xsl:sort data-type="number" order="ascending" select="typeCode"/>
      <xsl:with-param name="chosenType" select="$chosenType"/>
    </xsl:apply-templates>
  </select>  
</xsl:template>

<xsl:template match="textType" mode="list">
<xsl:param name="chosenType">1</xsl:param>
<xsl:variable name="thisType" select="typeCode"/>
<xsl:choose>
  <xsl:when test="$chosenType=$thisType">
    <option selected="selected" value="{typeCode}"><xsl:value-of select="name"/></option>
  </xsl:when>
  <xsl:otherwise>
    <option value="{typeCode}"><xsl:value-of select="name"/></option>
  </xsl:otherwise>
</xsl:choose>
    
</xsl:template>


  <xsl:template match="SAREgrant" mode="full">
    <span class="pagetitle"><xsl:value-of select="@projNum"/>: <xsl:value-of select="title"/></span>

  <form action="" method="post" name="reportform">
  <input type="hidden" name="formID" value="reportform"/>
  <br/>
      <xsl:apply-templates mode="full" select="report">
      </xsl:apply-templates>
    <p/>
    <input name="Submit" type="submit" value="Submit"/>
    <input name="Cancel" type="reset" value="Undo most recent changes"/>
  </form>
  </xsl:template>

  <xsl:template match="report" mode="full">
   <xsl:apply-templates mode="full" select="section">
        <xsl:sort select="@order" data-type="number" order="ascending"/>
      </xsl:apply-templates>
    <p/>
    <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
    <xsl:choose>
    <xsl:when test="@approvedstatus = 'True'">
    <input name="approved" type="checkbox" checked="true" value="true"/>
    </xsl:when>
    <xsl:otherwise>
        <input name="approved" type="checkbox" value="true"/>
    </xsl:otherwise>
    </xsl:choose>
    Approved<br/>
    </xsl:if>

  </xsl:template>
  
  <xsl:template match="section" mode="full">
      <xsl:variable name="sectionname" select="name"/>
      <xsl:variable name="sectionID" select="@ID"/>
      <b><!--<xsl:value-of select="@order" />: --><xsl:value-of select="$sectionname"/><!--(<xsl:value-of select="$sectionID" />)--></b><br/>
      <xsl:apply-templates mode="full" select="subsection">
        <xsl:sort select="@order" data-type="number" order="ascending"/>
      </xsl:apply-templates>
  </xsl:template>
  
  <xsl:template match="subsection" mode="full">
      <xsl:variable name="sectionname" select="../name"/>
      <xsl:variable name="sectionID" select="../@ID"/>
        <xsl:variable name="subheading" select="heading"/>
        <xsl:variable name="subheadingID" select="@order"/>
        <!--<xsl:value-of select="@order" />-->
        <p/>Subsection Header (Optional)<br/>
        <xsl:variable name="text" select="text"/>
        <input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>
        <br/>
        <p/>
          <xsl:apply-templates mode="list" select="/SAREroot/textTypes">
          <xsl:with-param name="chosenType" select="@type"/>
        </xsl:apply-templates>
        <br/>
        <table><tablebody><tr>
          <td>
          <textarea name="section{$sectionID}subtext{$subheadingID}" rows="12" cols="70">
            <xsl:value-of select="$text"/>
          </textarea>
          </td>
          <td>
            <button type="submit" name="section{$sectionID}moveup{$subheadingID}" value="section{$sectionID}moveup{$subheadingID}">Move This Up</button><br/>
            <button type="submit" name="section{$sectionID}movedown{$subheadingID}" value="section{$sectionID}movedown{$subheadingID}">Move This Down</button><br/>
            <button type="submit" name="section{$sectionID}insert{$subheadingID}" value="section{$sectionID}insert{$subheadingID}">Insert Subsection Below</button><br/>
            <button type="submit" name="section{$sectionID}delete{$subheadingID}" value="section{$sectionID}delete{$subheadingID}">Delete Subsection</button>
          </td>
        </tr></tablebody></table>
        <p/>
  </xsl:template>

  <xsl:template match="SAREgrant" mode="partial">
    <span class="pagetitle"> <xsl:value-of select="title"/></span>
<br/>
    <xsl:value-of select="@projNum"/>
  <form action="?do=submitRept" method="post" name="reportform">
      <xsl:apply-templates mode="partial" select="report/section">
      </xsl:apply-templates>
    <p/>
    <input name="Submit" type="submit" value="Submit"/>
    <input name="Cancel" type="reset" value="Undo most recent changes"/>
  </form>
  </xsl:template>

  <xsl:template match="section" mode="partial">
      <xsl:if test="@ID=$reptsection">
      <xsl:variable name="sectionname" select="name"/>
      <xsl:variable name="sectionID" select="@ID"/>
        <b><!--<xsl:value-of select="@order" />: --><xsl:value-of select="$sectionname"/><!--(<xsl:value-of select="$sectionID" />)--></b><br/>
          <xsl:choose>
        <xsl:when test="$reptsubsection=0">
        <xsl:apply-templates mode="full" select="subsection">
          <xsl:sort select="@order" data-type="number" order="descending"/>
        </xsl:apply-templates>
        </xsl:when>
        <xsl:otherwise>
        <xsl:apply-templates mode="partial" select="subsection">
          <xsl:sort select="@order" data-type="number" order="descending"/>
        </xsl:apply-templates>
        </xsl:otherwise>
      </xsl:choose>
      </xsl:if>
  </xsl:template>
  
  <xsl:template match="subsection" mode="partial">
      <xsl:if test="@order=$reptsubsection">
      <xsl:variable name="sectionname" select="../name"/>
      <xsl:variable name="sectionID" select="../@ID"/>
        <xsl:variable name="subheading" select="heading"/>
        <xsl:variable name="subheadingID" select="@order"/>
        <!--<xsl:value-of select="@order" />-->
        <xsl:variable name="text" select="text"/>
        <p/>Header (Optional)<br/>
        <input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>
        <br/>
        <p/>Text<br/>
        <textarea name="section{$sectionID}subtext{$subheadingID}" rows="15" cols="50">
          <xsl:value-of select="$text"/>
        </textarea>
        <p/>
        </xsl:if>
  </xsl:template>
  
  </xsl:stylesheet>

