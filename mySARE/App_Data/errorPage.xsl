<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="errorCode">Unknown</xsl:param>
<xsl:param name="errorText">An unexpected error has occured.</xsl:param>

<xsl:template match="/">
  <p class="pagetitle">Error</p>
  <hr/>
  Code: <xsl:value-of select="errorCode"/>
  <br/><br/>
  <xsl:value-of select="errorText"/>
  <br/>
  <hr/>
  Please contact <a href="mailto:san@sare.org">san@sare.org</a> to report this issue.
  <br/>

</xsl:template>

</xsl:stylesheet>