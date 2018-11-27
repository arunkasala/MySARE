<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">

  <p>
    <span class="pagetitle">Retrieve your Username or Password</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
<p>
	To retrieve your password, enter your username. A new password will be sent to the email account on file for your account.
	<br/>If you don't remember your username, enter the email address on file for your account and your username will be sent to you.
</p>
  <form id="userInfo" name="userInfo" method="post">
    <table>
    <tr><td colspan="2"/></tr>
    <tr>
      <td>Username or Email Address: </td>
      <td>
        <input maxlength="255" size="25" id="userName" name="userName"/>
		<script type="text/javascript" language="JavaScript">
			document.forms['userInfo'].elements['userName'].focus();
		</script>
	  </td>
    </tr>
    <tr>
      <td>
        <input name="cmdRetrievePass" type="submit" value="Retrieve Username or Password"/>
      </td>
      <td/>
    </tr>
    </table>
  </form>

</xsl:template>

</xsl:stylesheet>
