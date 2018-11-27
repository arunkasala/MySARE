<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="currentMonth">October</xsl:param>
<xsl:param name="currentDay">19</xsl:param>
<xsl:param name="currentYear">2007</xsl:param>
<xsl:param name="eventNumber">0123</xsl:param>
<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <xsl:apply-templates select="SAREroot/calendarEvents/calendarEvent[@number=$eventNumber]"/>
</xsl:template>

<xsl:template match="calendarEvent">
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span class="pagetitle">Event Detail: <xsl:value-of select="name"/></span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  <p>
    <b>Dates:</b>&#160;
    <span class="evDate">
      <xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>&#160;-&#160;
      <xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/>
    </span><br/><br/>
    <b>Location:</b>&#160;<xsl:value-of select="location"/>,&#160;<xsl:value-of select="state"/><br/><br/>
    <b>Scope:</b>&#160;<xsl:value-of select="geoscope/areaName"/><br/><br/>
    <b>Type:</b>&#160;<xsl:value-of select="type/type"/><br/><br/>
    <b>Description:</b>&#160;<xsl:value-of select="description"/><br/><br/>
    <b>Website:</b>&#160;<blockquote><b><a href="{url/urlAddress}" target="_blank"><xsl:value-of select="url/urlName"/></a></b></blockquote>
    <b>Contact:</b>&#160;
    <blockquote>
      <xsl:value-of select="contact/name"/><br/>
      <xsl:value-of select="contact/addrStreet1"/><br/>
      <xsl:value-of select="contact/addrStreet12"/><br/>
      <xsl:value-of select="contact/addrCity"/>,&#160;<xsl:value-of select="contact/addrState"/>&#160;&#160;<xsl:value-of select="contact/addrZip"/><br/>
      <xsl:value-of select="contact/numPhone"/><br/>
    </blockquote>
  </p>
  <small>
	  This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.
  </small>
</xsl:template>

</xsl:stylesheet>
