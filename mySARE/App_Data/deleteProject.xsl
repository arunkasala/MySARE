<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

	<xsl:param name="message"/>
	<xsl:param name="message2"/>

	<xsl:template match="/">



		<p>
			<span class="pagetitle">
				<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE
			</span>
			<br/>
			<span class="pagetitle">Delete an Existing Project</span>
			<br/>
			<p>
				You can delete a project by entering the project number in the field below and then clicking on the Preview Delete button.  This will allow you to preview the project before deleting it.
			</p>
			<xsl:if test="$message">
				<br/>
				<b>
					<i>
						<span style="color:#FF0000;">
							<xsl:value-of select="$message"/>
						</span>
					</i>
				</b>
			</xsl:if>
			<xsl:if test="$message2">
				<br/>
				<i>
					<xsl:value-of select="$message2"/>
				</i>
			</xsl:if>
		</p>
		<form id="deleteProject" name="deleteProject" method="post">
			<table>
				<tr>
					<td>Project Number: </td>
					<td>
						<input id="projNum" maxlength="16" size="25" name="projNum" />
						<script type="text/javascript" language="JavaScript">
							document.forms['deleteProject'].elements['projNum'].focus();
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<input name="PreviewDelete" type="submit" value="Preview Delete"/>
					</td>
				</tr>
			</table>
		</form>

	</xsl:template>

</xsl:stylesheet>


