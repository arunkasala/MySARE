<?xml version="1.0" encoding="iso-8859-1"?><!-- DWXMLSource="testProject.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="iso-8859-1"/>

	<xsl:param name="mytitle"/>
	
<xsl:template match="/">

<!-- <title><xsl:value-of select="SAREgrant/@projNum"/>:<xsl:value-of select="SAREgrant/title"/></title> -->
	<title><xsl:value-of select="$mytitle"/></title>

<xsl:apply-templates mode="toc" select="SAREroot/SAREgrant"/>
	
	
	<br/>
	<small>This project was supported by the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.</small>
</xsl:template>
<xsl:template match="SAREgrant" mode="toc">
	<p class="pagetitle">
	<xsl:value-of select="title"/>
	</p>
	<table CELLSPACING="0" CELLPADDING="2" CLASS="NORM" WIDTH="100%">
    <tr>
    <td VALIGN="TOP">

    <b>Project Number:</b>&#160;<xsl:value-of select="@projNum"/>
	<br/>

	<b>Year:</b>&#160;<xsl:value-of select="@year"/>
	<br/>
	<b>Region:</b>&#160;<xsl:value-of select="@regionText"/>
	<br/>
	<b>Type:</b>&#160;<xsl:value-of select="@typeText"/>
	<xsl:apply-templates mode="toc" select="./report"/>
		<br/>
		<br/>
		<xsl:if test="/SAREroot/productInfo/resource">
			<b>Information Product(s):</b>
			<br/>
			<xsl:for-each select="/SAREroot/productInfo/resource">
				<a href="?do=infoproddetail&amp;type=grant&amp;pn={../@projNum}&amp;resourceID={@resourceID}&amp;uploadID={uploadID}">
					<xsl:value-of select="title"/>
					<br/>
				</a>
				<!-- 
									<xsl:choose>
										<xsl:when test="uploadID !=''">
											&#160;&#160;:&#160;&#160;File Uploaded: <xsl:value-of select="file_name_orig"/>
										</xsl:when>
										<xsl:otherwise>
											&#160;&#160;:&#160;&#160;No File Uploaded
										</xsl:otherwise>
									</xsl:choose>
									-->
			</xsl:for-each>
		</xsl:if>
	</td>
    <td>

<xsl:if test="/*/user[@context='projectpis'] or ../nonusercontact[@context='projectpis']">
	<b CLASS="TITLE">Coordinator: </b><br/>
</xsl:if>
<xsl:for-each select="/*/user[@context='projectpis']">
	<xsl:if test="firstname != ''">
		<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	</xsl:if>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/><br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/><br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>	
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>
		<xsl:if test="contact/addrState != ''">
			,&#160;<xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>		
	</xsl:if>	
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}">
			<xsl:value-of select="contact/email"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}">
			<xsl:value-of select="contact/website"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>
		
<!-- This is added to have project coordinators -->

<xsl:for-each select="../nonusercontact[@context='projectpis']">
	<br/>
	<xsl:if test="firstname != ''">
		<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	</xsl:if>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/><br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/><br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>	
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>,
		<xsl:if test="contact/addrState != ''"><xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>		
	</xsl:if>	
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}">
			<xsl:value-of select="contact/email"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}">
			<xsl:value-of select="contact/website"/>
		</a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>

<xsl:if test="/*/nonusercontact[@context='projectparticipants']">
	<br/><b CLASS="TITLE">Participant: </b>
	<br/>
</xsl:if>
<xsl:for-each select="/*/nonusercontact[@context='projectparticipants']">
	<xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/><br/>
	<xsl:if test="organization/position != ''">
		<xsl:value-of select="organization/position"/>
		<br/>
	</xsl:if>
	<xsl:if test="organization/@name != ''">
		<xsl:value-of select="organization/@name"/>
		<br/>
	</xsl:if>
	<xsl:if test="contact/addrStreet1 != ''">
		<xsl:value-of select="contact/addrStreet1"/>
		<xsl:if test="contact/addrStreet2 != ''">,&#160;<xsl:value-of select="contact/addrStreet2"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrStreet2 = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/addrCity != ''">
		<xsl:value-of select="contact/addrCity"/>,
		<xsl:if test="contact/addrState != ''"><xsl:value-of select="contact/addrState"/>&#160;<xsl:value-of select="contact/addrZip"/><br/>
		</xsl:if>
		<xsl:if test="contact/addrState = ''">
			<br/>
		</xsl:if>
	</xsl:if>
	<xsl:if test="contact/numPhone != ''">
		Phone:&#160;<xsl:value-of select="contact/numPhone"/><br/>
	</xsl:if>
	<xsl:if test="contact/email != ''">
		E-mail:&#160;<a href="mailto:{contact/email}"><xsl:value-of select="contact/email"/></a><br/>
	</xsl:if>
	<xsl:if test="contact/website != ''">
		Website:&#160;<a href="{contact/website}"><xsl:value-of select="contact/website"/></a><br/>
	</xsl:if>
	<xsl:if test="position()!=last()"><br/></xsl:if>
</xsl:for-each>

<p/>
SARE Grant
&#160;&#160;$
<xsl:value-of select='format-number(funds/SARE, "#")'/>
<br/>
<!-- 
Matching Federal Funds
&#160;&#160;$
<xsl:value-of select='format-number(funds/Fed, "#")'/>
<br/>
Matching Non-Federal Funds
&#160;&#160;$
<xsl:value-of select='format-number(funds/NonFed, "#")'/>
<br/>
-->
<p/>
    </td>
	</tr>
	</table>
</xsl:template>

	<xsl:template match="SAREgrant/report" mode="toc">
	<xsl:variable name="projNum" select="../@projNum"/>
	<br/>
		<xsl:if test='@approvedstatus = "True"'>
			<a href="?do=viewRept&amp;pn={$projNum}&amp;y={@year}&amp;t={@type}">			
				<xsl:if test='@type = 2 and @approvedstatus="True"'><xsl:value-of select="@year"/>&#160;Project Overview</xsl:if>
				<xsl:if test='@type = 0 and @approvedstatus="True"'><xsl:value-of select="@year"/>&#160;Annual Report</xsl:if>
				<xsl:if test='@type = 1 and @approvedstatus="True"'><xsl:value-of select="@year"/>&#160;Final Report</xsl:if>
			</a>
		</xsl:if>		
	</xsl:template>

</xsl:stylesheet>

