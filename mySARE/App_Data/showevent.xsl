<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="currentMonth">October</xsl:param>
<xsl:param name="currentDay">19</xsl:param>
<xsl:param name="currentYear">2007</xsl:param>
<xsl:param name="optionMonths">4</xsl:param>
<xsl:param name="optionView">PartialDescriptions</xsl:param>
<xsl:param name="optionRegion"/>
<xsl:param name="optionGeoscope">All</xsl:param>
<xsl:param name="optionInternational">yes</xsl:param>
<xsl:param name="message"/>
<xsl:param name="message2"/>


<xsl:template match="/">
	
	<script LANGUAGE="JavaScript">
		<![CDATA[
	
	function closeIt()
	{
	  return "Would you like to save your data before leaving this page?";
	}
	]]>

	</script>
		
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/calendarEvent/name"/></span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>

  <xsl:apply-templates select="SAREroot/calendarEvent"/>
	
  <br/>
  <small>
	  This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.
  </small>
  
</xsl:template>

<xsl:template match="calendarEvent">
  <p>
	<b>Dates:</b>&#160;<!--<xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>-<xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/><br/><br/>-->
	  <span class="evDate">
		  <xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>
		  <xsl:if test="times/startDateOrder != times/endDateOrder">
			  &#160;-&#160;
			  <xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/>
		  </xsl:if>
	  </span><br/><br/>
    <b>Location:</b>&#160;<xsl:value-of select="location"/><xsl:if test="state != '00' and state != '01' and state != ''">,&#160;<xsl:value-of select="state"/></xsl:if><br/><br/>
    <b>Scope:</b>
	  
		<xsl:choose>
		<xsl:when test="geoscope = 'INT'">
			&#160;International<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'REG'">
			&#160;Regional<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'US'">
			&#160;National<br/><br/>
		</xsl:when>
		<xsl:when test="geoscope = 'USST'">
			&#160;Statewide<br/><br/>
		</xsl:when>
		<xsl:otherwise>
			&#160;<xsl:value-of select="geoscope"/><br/><br/>
		</xsl:otherwise>
	</xsl:choose>
	  
	<b>Type:</b>&#160;<xsl:value-of select="type/code"/><br/><br/>
	<b>Description:</b>&#160;<!-- <xsl:value-of select="description"/><br/><br/> -->	 
	  <xsl:apply-templates select="description"/><br/><br/>
	  <xsl:if test="url/urlAddress != ''">
		<b>Websites:</b><br/><br/>
		  <xsl:if test="url/@order = '1'">
			&#160;&#160;&#160;<b>1.&#160;<a href="{url/urlAddress}"><xsl:value-of select="url/urlAddress"/></a></b><br/><br/>
		  </xsl:if>
		  <xsl:if test="url/@order = '2' and url[@order = '2']/urlAddress != ''">
			&#160;&#160;&#160;<b>2.&#160;<a href="{url[@order = '2']/urlAddress}"><xsl:value-of select="url[@order = '2']/urlAddress"/></a></b><br/><br/>
		  </xsl:if>
	  </xsl:if>
	<b>Contact:</b><br/><br/>
	 &#160;&#160;&#160;<b><xsl:value-of select="/SAREroot/nonusercontact/nametitle"/>&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/firstname"/>&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/lastname"/></b><br/>
	 &#160;&#160;&#160;<b><xsl:value-of select="/SAREroot/nonusercontact/organization/@name"/></b><br/>
	  <xsl:if test="/SAREroot/nonusercontact/contact/addrState != ''">
		&#160;&#160;&#160;Address:<br/>
	  
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrStreet1 != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrStreet1"/><br/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrStreet2 != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrStreet2"/><br/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrCity != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrCity"/>
		  </xsl:if>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrState != ''">
			  ,&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrState"/>
		  </xsl:if><br/>
		  <xsl:if test="/SAREroot/nonusercontact/contact/addrZip != ''">
			  &#160;&#160;&#160;&#160;&#160;&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/addrZip"/>
		  </xsl:if><br/><br/>
		  
	  </xsl:if>
	  
	  <xsl:if test="/SAREroot/nonusercontact/contact/numPhone != ''">
		  &#160;&#160;&#160;Phone:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/numPhone"/><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/numFax != ''">
		  &#160;&#160;&#160;Fax:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/numFax"/><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/email != ''">
		  &#160;&#160;&#160;Email:&#160;<a href="mailto:{/SAREroot/nonusercontact/contact/email}"><xsl:value-of select="/SAREroot/nonusercontact/contact/email"/></a><br/>
	  </xsl:if>
	  <xsl:if test="/SAREroot/nonusercontact/contact/website != ''">
		  &#160;&#160;&#160;Website:&#160;<xsl:value-of select="/SAREroot/nonusercontact/contact/website"/><br/>
	  </xsl:if>
	<br/><br/>
  </p>
</xsl:template>

	<xsl:template match="description">
		<xsl:call-template name="break">
		</xsl:call-template>
		</xsl:template>

	<xsl:template name="break">
		<xsl:param name="text" select="."/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<br/>
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="substring-after($text,
'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>



</xsl:stylesheet>
