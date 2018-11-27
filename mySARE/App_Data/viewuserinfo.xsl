<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

	<xsl:param name="message"/>
	<xsl:param name="message2"/>
	<xsl:param name="usertype">user</xsl:param>
	<xsl:param name="projType">PDP</xsl:param>

	<xsl:template match="/">
		<p>
			<span class="pagetitle">
				<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE
			</span>
			<br/>
			<xsl:if test="$projType = 'PDP'">
				<span class="pagetitle">State Coordinator Details</span>
			</xsl:if>
			<xsl:if test="$projType = 'grants'">
				<span class="pagetitle">Project Coordinator Details</span>
			</xsl:if>
			<br/>
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
		<xsl:for-each select="SAREroot/user[@context='viewing']">
			<form method="post">
				<table id="projoverview" style="text-align: left; width: 82%;" border="1" cellpadding="2" cellspacing="2">
					<tbody>
						<tr>
							<td>Username</td>
							<td>
								<xsl:value-of select="@username"/>
							</td>
						</tr>
						<tr>
							<td width="30%">Title</td>
							<td width="70%">
								<select name="nameTitle" disabled="disabled">
									<xsl:call-template name="option">
										<xsl:with-param name="value"/>
										<xsl:with-param name="label"/>
										<xsl:with-param name="selected">
											<xsl:value-of select="nametitle"/>
										</xsl:with-param>
									</xsl:call-template>
									<xsl:call-template name="option">
										<xsl:with-param name="value">Mr</xsl:with-param>
										<xsl:with-param name="label">Mr</xsl:with-param>
										<xsl:with-param name="selected">
											<xsl:value-of select="nametitle"/>
										</xsl:with-param>
									</xsl:call-template>
									<xsl:call-template name="option">
										<xsl:with-param name="value">Ms</xsl:with-param>
										<xsl:with-param name="label">Ms</xsl:with-param>
										<xsl:with-param name="selected">
											<xsl:value-of select="nametitle"/>
										</xsl:with-param>
									</xsl:call-template>
									<xsl:call-template name="option">
										<xsl:with-param name="value">Mrs</xsl:with-param>
										<xsl:with-param name="label">Mrs</xsl:with-param>
										<xsl:with-param name="selected">
											<xsl:value-of select="nametitle"/>
										</xsl:with-param>
									</xsl:call-template>
									<xsl:call-template name="option">
										<xsl:with-param name="value">Dr</xsl:with-param>
										<xsl:with-param name="label">Dr</xsl:with-param>
										<xsl:with-param name="selected">
											<xsl:value-of select="nametitle"/>
										</xsl:with-param>
									</xsl:call-template>
								</select>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="firstname != ''">* First Name</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* First Name</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="25" readonly="readonly" name="firstName" value="{firstname}" style="background-color:#DCC9D0; border: none" onkeypress="WarnUser()"/>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="lastname != ''">* Last Name</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* Last Name</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="25" readonly="readonly" name="lastName" value="{lastname}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td> Postfix (Jr., III, etc.)</td>
							<td>
								<input size="10" name="namePostfix" readonly="readonly" value="{namepostfix}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td/>
							<td/>
						</tr>
						<tr>
							<td>Position</td>
							<td>
								<input maxlength="255" size="25" readonly="readonly" name="orgPosition" value="{organization/position}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="organization[@name != '']">* Organization</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* Organization</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="25" readonly="readonly" name="org" value="{organization/@name}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td/>
							<td/>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/addrStreet1 != ''">* Address</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* Address</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="50" readonly="readonly" name="addrStreet1" value="{contact/addrStreet1}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td> Address (cont.)</td>
							<td>
								<input maxlength="255" size="50" readonly="readonly" name="addrStreet2" value="{contact/addrStreet2}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/addrCity != ''">* City</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* City</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="20" readonly="readonly" name="addrCity" value="{contact/addrCity}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/addrState != ''">* State</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* State</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<select name="addrState" disabled="disabled">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
       <xsl:call-template name="option">
         <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user[@context='viewing']/contact/addrState"/></xsl:with-param>
         <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
         <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
       </xsl:call-template>
     </xsl:for-each>
								</select>
							</td>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/addrZip != ''">* Zip Code</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* Zip Code</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input readonly="readonly" maxlength="5" size="5" name="addrZip" value="{contact/addrZip}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td> Zip +4</td>
							<td>
								<input readonly="readonly" maxlength="4" size="4" name="addrZip4" value="{contact/addrZip4}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td/>
							<td/>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/numPhone != ''">* Phone</xsl:when>
									<xsl:when test="$message">
										<span class="boldred">* Phone</span>
									</xsl:when>
									<xsl:otherwise>
										<span>* Phone</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input readonly="readonly" maxlength="16" size="16" name="numPhone" value="{contact/numPhone}" style="background-color:#DCC9D0; border: none"/>
                <!-- 
								<xsl:choose>
									<xsl:when test="contact/numPhone != ''">
										<input  disabled="disabled" name="phoneCheck" type="checkbox">Does not have phone number</input>
									</xsl:when>
									<xsl:when test="$message">
										<input  disabled="disabled" name="phoneCheck" type="checkbox">Does not have phone number</input>
									</xsl:when>
									<xsl:otherwise>
										<input  disabled="disabled" name="phoneCheck" type="checkbox" checked="checked">Does not have phone number</input>
									</xsl:otherwise>
								</xsl:choose>
                -->
							</td>
						</tr>
						<tr>
							<td>Fax</td>
							<td>
								<input readonly="readonly" maxlength="16" size="16" name="numFax" value="{contact/numFax}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td>Cell</td>
							<td>
								<input readonly="readonly" maxlength="16" size="16" name="numCell" value="{contact/numCell}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td/>
							<td/>
						</tr>
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="contact/email != ''">* email Address</xsl:when>
									<xsl:otherwise>
										<span class="boldred">* email Address</span>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<input maxlength="255" size="50" readonly="readonly" name="email" value="{contact/email}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td>Website</td>
							<td>
								<input maxlength="255" size="50" readonly="readonly" name="website" value="{contact/website}" style="background-color:#DCC9D0; border: none"/>
							</td>
						</tr>
						<tr>
							<td/>
							<td/>
						</tr>		
						
					</tbody>
				</table>
				<br/>
				<xsl:if test="$projType = 'grants'">
					<input type="button" value="Back To Project Overview" onClick="history.go(-1)"/>&#160;
				</xsl:if>
				<xsl:if test="$projType = 'PDP'">
					<input type="button" value="Back To State Report" onClick="history.go(-1)"/>&#160;
				</xsl:if>
				<xsl:if test="/SAREroot/user/userroles/role[@code = 'admin' or @code='natAdmin' or @code='regAdmin']">
					<br>&#160;</br>
					<br>&#160;</br>
					<input name="ConfirmDelete" type="checkbox" value="true"/>Confirm Remove&#160;&#160;&#160;
					<input type="submit" value="Remove Coordinator" name="cmdDeleteCoordinatorDetails" ID="cmdDeleteCoordinatorDetails" onclick="NoPrompt()"/>
					<br/>
				</xsl:if>
			</form>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="option">
		<!-- Generates an option to go in the drop-down list -->
		<xsl:param name="selected"/>
		<!-- value of the currently selected option -->
		<xsl:param name="value"/>
		<!-- value of the option to be created -->
		<xsl:param name="label"/>
		<!-- label of the option to be created -->
		<xsl:choose>
			<xsl:when test="$selected=$value">
				<option value="{$value}" selected="selected">
					<xsl:value-of select="$label"/>
				</option>
			</xsl:when>
			<xsl:otherwise>
				<option value="{$value}">
					<xsl:value-of select="$label"/>
				</option>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>	
	
</xsl:stylesheet>







