<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:variable name="empty"/>
<xsl:param name="js1">
  <![CDATA[return hs.htmlExpand(this, { contentId: 'highslide-html-1', objectType: 'ajax'} )]]>
</xsl:param>
<xsl:param name="js2">
  <![CDATA[border: 0; height: 18px; padding: 2px; cursor: default]]>
</xsl:param>
<xsl:param name="js3">
  <![CDATA[return hs.close(this)]]>
</xsl:param>


<xsl:template match="/">
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span>Welcome to your personal SARE content management page. Use this page to submit proposal information and project reports. In addition, you can submit information products from your SARE grant, add events to the calendar and/or edit this information.</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><div><xsl:value-of select="$message2"/></div></i></xsl:if>
  </p>
  <xsl:apply-templates select="SAREroot/user"/>
</xsl:template>

<xsl:template match="user">

  <span class="pagetitle"><xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/>'s SARE Content</span>
  <br/>
  <br/>
  <a href="help.htm#help1" onclick="{$js1}">HELP1!</a>
  <a href="help.htm#help2" onclick="$js1">HELP2!</a>
  <div class="highslide-html-content" id="highslide-html" width="300">
	<div class="highslide-move" style="{$js2}">
	    <a href="#" onclick="$js3" class="control">Close</a>
	</div>
	<div class="highslide-body"/>
  </div>
  <br/>
  <br/>
  <span class="pagetitledown">User Info</span>
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
  <a href="?do=editUser">Edit User Info</a><br/>
  <br/>

<xsl:if test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
    <span class="pagetitledown">User Accounts</span><br/>
    <a href="?do=userlist">Search and Manage User Accounts, Roles, and Data Ownership</a><br/>
    <span class="boldblue">Export user information</span><br/>
    <span class="boldblue">Create New Account</span><br/><br/>
</xsl:if>

<xsl:if test="userroles/role[@code='projProposer' or @code='projPI' or @code='genUser']">
     <span class="pagetitledown">My SARE-Funded Projects</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='projProposer']">
     <a href="?do=myProj">View/Edit My Proposals</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='projPI']">
     <a href="?do=myProj">View/Edit My Reports and Projects</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='genUser']">
     <span class="boldblue">Propose New Project</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='genUser']">
     <a href="?do=claimProj">Claim Existing Project</a><br/><br/>
</xsl:if>

<xsl:if test="userroles/role[@code='regAdmin' or @code='natAdmin' or @code='admin']">
     <span class="pagetitledown">Administer SARE-Funded Projects</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='regAdmin']">
     <a href="?do=adminProj">View/Edit/Approve Reports, Projects, and Proposals In My Region</a><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='admin' or @code='natAdmin']">
     <a href="?do=adminProj">View/Edit/Approve Reports, Projects, and Proposals</a><br/>
</xsl:if>

<xsl:if test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
     <a href="?do=searchProj">Search Projects</a><br/>
     <span class="boldblue">Search Projects by Profile</span><br/>
     <a href="?do=newgrant">Create Project</a><br/><br/>
</xsl:if>

<xsl:if test="userroles/role[@code='projPI' or @code='resAuthor' or @code='resManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
<span class="pagetitledown">Resources</span><br/>
</xsl:if>

<xsl:if test="userroles/role[@code='resAuthor']">
     <span class="boldblue">View/Edit My Resources</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='resManager' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
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

<xsl:if test="userroles/role[@code='calSubmitter' or @code='genUser']">
<br/><span class="pagetitledown">Calendar Events</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='calSubmitter']">
   <span class="boldblue">View/Edit My Events</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
   <span class="boldblue">View/Edit/Approve Events</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='calSubmitter' or @code='admin' or @code='natAdmin' or @code='regAdmin']">
   <span class="boldblue">Search Events</span><br/>
</xsl:if>
<xsl:if test="userroles/role[@code='calSubmitter' or @code='genUser']">
   <span class="boldblue">Add New Event</span><br/>
</xsl:if>

 <br/><br/>
<a href="?do=logout">Log Out</a>
  <br/>

</xsl:template>

</xsl:stylesheet>

