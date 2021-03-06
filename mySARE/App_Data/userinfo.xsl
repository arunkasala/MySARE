<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:variable name="empty"/>

<xsl:template match="/">
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span>
    <span>Welcome to MySARE. Use this page to 
	  
		  <xsl:choose>
			  <xsl:when test="/SAREroot/user/userroles/role[@code = 'admin' or @code='natAdmin']">:
				  <ul>
					  <li>Administer SARE grants in all regions</li>
					  <li>Manage MySARE user accounts in all regions</li>
					  <li>Add calendar events</li>
				  </ul>
			  </xsl:when>
			  <xsl:when test="/SAREroot/user/userroles/role[@code='regAdmin']">:
				  <ul>
					  <li>Administer SARE grants in your region</li>
					  <li>Manage MySARE user accounts in your region</li>
					  <li>Add calendar events</li>
				  </ul>				  
			  </xsl:when>			  
			  <xsl:otherwise>
				  submit SARE grant project reports, information products and events.<br/><br/>
				  If you received an email from MySARE with a project number and retrieval code:
				  <ul>
				  <li>Grant Recipients: Click <a href="?do=claimProj">"Retrieve New Project"</a> to open a new project report</li>
				  <li>SARE State Coordinators: Click <a href="?do=claimPdp">"Retrieve New State Report"</a> to open a new state report</li>
			  </ul>
				  If you have previously opened this project report online, use the "My Projects" link to access all of your grant reports.<br/>
			  </xsl:otherwise>
		  </xsl:choose>
		<b>Note</b>: For security purposes, MySARE will automatically log you out if the system is idle for more than 30 minutes. <i>Save your work frequently to avoid loss of data</i>.<br/>
	</span>
	  <xsl:text disable-output-escaping="yes">
    <![CDATA[
      <br/><span style="text-align: left;"><a href="help/main_general.htm#intro" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )">Click here for help information</a></span><br/>
    ]]>
    </xsl:text>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><div><xsl:value-of select="$message2"/></div></i></xsl:if>
  </p>
  <xsl:apply-templates select="SAREroot/user"/>
</xsl:template>

<xsl:template match="user">

  <!-- <span class="pagetitle"><xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>'s SARE Content</span> -->
  
 <!--  <span class="pagetitledown">User Info</span>&#160;
  <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_general.htm#userinfo" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text> -->
  <span class="pagetitledown"><b>User Info</b></span>&#160;
  <span class="tooltiptext">
	  <a href="/mysare/help/main_general.htm#userinfo" target="_blank">
		  <h3>User Information</h3>
	  </a>
	  <p>&#160;</p>
	  <p>This section displays some basic information about your MySARE account.</p>
	  <p>
		  Use the <i>Edit User Info and Change Password</i> link to modify your information.
	  </p>				  
  </span>

  <br/>
  <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
  <tbody>
    <tr class="r1">
      <td><xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/></td>
      <td>User ID:  <i><xsl:value-of select="@username"/></i></td>
    </tr>
    <tr class="r2">
      <td><xsl:value-of select="organization/position"/></td>
      <td><xsl:value-of select="contact/numPhone"/></td>
    </tr>
    <tr class="r1">
      <td><xsl:value-of select="organization/@name"/></td>
      <td><xsl:value-of select="contact/email"/></td>
    </tr>
    <tr class="r2">
      <td><xsl:value-of select="contact/addrStreet1"/><br/>
      <xsl:if test="contact/addrStreet2 != $empty"><xsl:value-of select="contact/addrStreet2"/><br/></xsl:if>
      <xsl:value-of select="contact/addrCity"/>,
      <xsl:value-of select="contact/addrState"/>&#160;
      <xsl:value-of select="contact/addrZip"/></td>
      <td><xsl:value-of select="contact/website"/></td>
    </tr>
  </tbody>
  </table>
  <a href="?do=editUser">Edit User Info and Change Password</a><br/>
  <br/>

<xsl:if test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
    <span class="pagetitledown"><b>User Accounts</b></span>&#160;
	<!--
    <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_admin.htm#accounts" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text><br/>
    -->
	<span class="tooltiptext">
		<a href="/mysare/help/main_admin.htm#accounts" target="_blank">
			<h3>User Accounts</h3>
		</a>
		<p>&#160;</p>
		<ul>
			<li>
				<b>Search and Manage User Accounts, Roles, and Data Ownership</b> - View account information through a powerful search feature
			</li>
			<!-- <li><b>Export user information</b> - Export account information to an external file format</li>
	     <li><b>Create New Account</b> - Create a new account</li> -->
			<li>
				<b>Send a Message to Another MySARE User</b> - Logged in User can send message to another MySare User about projects, reports, proposals and calendar events
			</li>
		</ul>
	</span>
	<br/>
	<a href="?do=userlist">Search and Manage User Accounts, Roles, and Data Ownership</a><br/>
    <a href="?do=sendmessage">Send a Message to Another MySARE User</a><br/>
<!--
    <span class="boldblue">Export user information</span><br/>
    <span class="boldblue">Create New Account</span><br/>
-->
<br/>
</xsl:if>

<xsl:if test="userroles/role[@code='projProposer' or @code='projPI' or @code='genUser']">
     <span class="pagetitledown"><b>My SARE-Funded Projects</b></span>&#160;
	 <!--
     <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_general.htm#projects" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
	 -->
	<span class="tooltiptext">
		<a href="/mysare/help/main_general.htm#projects" target="_blank">
			<h3>MySARE Funded Projects</h3>
		</a>
		<p>
			&#160;
		</p>
		<p>You must be a grant recipient or administrator to use this function.</p>
		<ul>
			<li>
				<b>Retrieve New Project</b> - Add an existing project to your account using the project number and claim code you received by email from MySARE
			</li>
			<li>
				<b>View/Edit My Reports and Projects</b> - View the reports and projects that are linked to your account
			</li>			
		</ul>
	</span>
	<br/>
</xsl:if>
<xsl:if test="userroles/role[@code='genUser']">
	<a href="?do=claimProj">Retrieve New Project</a>&#160;(For grant recipients)
	<br/>	
	<a href="?do=claimPdp">Retrieve New State Report</a>&#160;(For state coordinators only)
	<br/>
</xsl:if>
<xsl:if test="userroles/role[@code='projProposer']">
     <a href="?do=myProj">Submit/Edit My Proposals</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='projPI']">
     <a href="?do=myProj">Submit/Edit My Projects and Reports</a><br/><br/>
</xsl:if>
<!--
<xsl:if test="userroles/role[@code='genUser']">
     <span class="boldblue">Propose New Project</span><br/>
</xsl:if>
-->


<xsl:if test="userroles/role[@code='regAdmin' or @code='admin' or @code='natAdmin']">
     <span class="pagetitledown"><b>Administer SARE-Funded Projects</b></span>&#160;
	 <!-- 
     <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_admin.htm#adminprojects" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
	 -->
	<span class="tooltiptext">
		<a href="/mysare/help/main_admin.htm#adminprojects" target="_blank">
			<h3>Admin SARE Funded Projects</h3>
		</a>
		<p>
			&#160;
		</p>
		<ul>
			<li>
				<b>View/Edit/Approve Reports, Projects, and Proposals</b> - View all available reports, projects, and proposals
			</li>
			<li>
				<b>Send Call for Reports to PIs</b> - PIs can send message to target PI group, individuals
			</li>
			<li>
				<b>Search Projects</b> - Search for specific projects based on a number of fields
			</li>
			<li>
				<b>Create Project</b> - Create a new project
			</li>
			<li>
				<b>Delete Project</b> - Delete a existing project
			</li>
		</ul>
	</span>
     <br/>
	<a href="?do=newgrant">Create Project</a><br/>
	<a href="?do=newpdp">Create State Report</a><br/>
	<a href="?do=deleteProj">Delete Project</a><br/>
	<a href="?do=searchProj">Search Projects</a><br/>
	<a href="?do=searchUnclaimProj">Find Unretrieved Projects</a><br/>
	<a href="?do=searchprojoverviewnosubmit">Find Projects with Unsubmitted Overviews</a><br/>
	<a href="?do=searchprojnoreports">Find Projects with Missing Reports</a><br/>	
	<a href="?do=sendpicall">Send Call for Reports and Other Messages to PIs</a><br/>
	
</xsl:if>
<xsl:if test="userroles/role[@code='regAdmin']">
     <a href="?do=adminProj">View/Edit/Approve Reports and Projects In My Region</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='admin' or @code='natAdmin']">
     <a href="?do=adminProj">View/Edit/Approve Reports and Projects</a><br/>
</xsl:if>

<!-- This is commented becuase RESOURCES will be relased in version 2

<br/>
<xsl:if test="userroles/role[@code='projPI' or @code='resAuthor' or @code='resManager' or @code='admin' or @code='regAdmin' or @code='natAdmin']">
  <span class="pagetitledown">Administer SARE-Product Information Resources</span>&#160;
  <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_resources.htm#resources" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
  <br/>
</xsl:if>
	<xsl:if test="userroles/role[@code='resCompManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
		<a href="?do=adminResource">View/Edit/Approve Product Information Resources</a>
		<br/>
	</xsl:if>
	<xsl:if test="userroles/role[@code='resManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
		<a href="?do=searchResource">Search Product Information Resources</a>
		<br/>		
	</xsl:if>
-->
<!--
<xsl:if test="userroles/role[@code='resAuthor']">
     <span class="boldblue">View/Edit My Resources</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resManager' or @code='admin' or @code='regAdmin' or @code='natAdmin']">
     <span class="boldblue">View/Edit/Approve Resource Entries</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resCompManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
     <span class="boldblue">View/Edit/Approve Resource Compilations</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='projPI' or @code='resAuthor' or @code='resManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
     <span class="boldblue">Create Resource</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resCompManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
     <span class="boldblue">Create Resource Compilation</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
     <span class="boldblue">Search Resources</span><br/>
     <span class="boldblue">Search Resources by Profile</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resManager']">
     <span class="boldblue">List All Resources You Manage</span><br/>
</xsl:if>
-->

<xsl:if test="userroles/role[@code='calSubmitter' or @code='genUser']">
  <br/>
  <span class="pagetitledown"><b>Calendar Events</b></span>&#160;
  <!--
  <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/main_general.htm#calendar" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text>
  -->
	<span class="tooltiptext">
		<a href="/mysare/help/main_general.htm#calendar" target="_blank">
			<h3>Calendar</h3>
		</a>
		<p>
			&#160;
		</p>
		<ul>
			<li>
				<b>Add New Event</b> - Submit a new event to the SARE events calendar
			</li>
		</ul>
	</span>
  <br/>
</xsl:if>
<xsl:if test="userroles/role[@code='calSubmitter' or @code='genUser']">
   <a href="http://www.sare.org/Events/Event-Calendar">Add New Event</a><br/>
</xsl:if>
<!-- 
<xsl:if test="userroles/role[@code='calSubmitter']">
   <a href="?do=myevents">View/Edit My Events</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
   <a href="?do=adminevents">View/Edit/Approve Events</a><br/>
</xsl:if>
<xsl:choose>
	<xsl:when test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
		<a href="?do=searchevents">Search Events</a><br/>
	</xsl:when>
	<xsl:otherwise>
		<a href="?do=searchevents">Search My Events</a>
		<br/>
	</xsl:otherwise>
</xsl:choose>
-->

	<!-- Calling Sending for PI's Reporting
	<br/>
	<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
		<a href="?do=sendpicall">Send Call for Reports to PIs</a>
	</xsl:if>
-->
 <br/><br/>
<a href="?do=logout">Log Out</a>
  <br/>
  <!-- 
  <xsl:text disable-output-escaping="yes">
  <![CDATA[
  <div class="highslide-html-content" id="highslide-html" style="width: 300px">
	<div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
      <a href="#" onclick="return hs.close(this)" class="control">Close</a>
	</div>
	<div class="highslide-body"></div>
  </div>
  ]]>
  </xsl:text>
  -->
</xsl:template>

</xsl:stylesheet>





