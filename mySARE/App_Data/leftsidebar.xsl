<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="currentpage">sare_main.aspx</xsl:param>

<xsl:template match="/">

<table width="159" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td colspan="2"><img src="../images/x.gif" width="159" height="20" alt="" border="0"/></td>

</tr>
<tr>
	<TD width="10"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>
	<td class="leftnav"><a href="../index.htm"><b>Home</b></a><br/>
	<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/></td>
</tr>
<tr>
	<td colspan="2"><img src="../images/x.gif" width="159" height="20" alt="" border="0"/></td>
</tr>
<tr>
	<TD width="12"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>

	      <td class="leftnav">
	      <b>MySARE</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
            <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>

            <xsl:choose>
              <xsl:when test="$currentpage!=''">
				  &#160;&#160;<a href="./sare_main.aspx"><b>My Main Page</b></a><br/>
              </xsl:when>
              <xsl:otherwise>
                &#160;&#160;<b>My Main Page</b><br/>
              </xsl:otherwise>
            </xsl:choose>
            <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
			  <xsl:if test="SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin']">
				  <xsl:choose>
					  <xsl:when test="$currentpage!='userlist'">
						  <a href="./sare_main.aspx?do=userlist">
							  &#160;&#160;<b>User Search</b>
						  </a>
						  <br/>
					  </xsl:when>
					  <xsl:otherwise>
						  &#160;&#160;<b>User Search</b>
						  <br/>
					  </xsl:otherwise>
				  </xsl:choose>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
			  </xsl:if><br/>

		  <xsl:choose>
            <xsl:when test="SAREroot/user/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin']">
              <xsl:choose>
                <xsl:when test="$currentpage!='adminProj'">
                  <a href="?do=adminProj"><b>Admin Projects and Reports</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=MyProj"><b>My Projects and Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=newgrant"><b>Create Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				 &#160;&#160;<a href="?do=newpdp"><b>Create State Report</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=deleteProj"><b>Delete Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				   &#160;&#160;<a href="?do=MyProj"><b>Submit a Project Report</b></a><br/>
                </xsl:when>
                <xsl:otherwise>
                  <b>Admin Projects and Reports</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=MyProj"><b>My Projects and Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=newgrant"><b>Create Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				&#160;&#160;<a href="?do=newpdp"><b>Create State Report</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=deleteProj"><b>Delete Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				   &#160;&#160;<a href="?do=MyProj"><b>Submit a Project Report</b></a><br/>
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				<br/>
                         
              <xsl:choose>
                <xsl:when test="$currentpage!='searchProj' and $currentpage!='searchprojprofile'">
                  <a href="./sare_main.aspx?do=searchProj"><b>Search Projects</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/about.htm"><b>About Project Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/howtosearch.htm"><b>Database Searching Tips</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/results.htm"><b>About Search Results</b></a><br/>
				  
                </xsl:when>
                <xsl:otherwise>
                  <b>Project Search</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/about.htm"><b>About Project Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/howtosearch.htm"><b>Database Searching Tips</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/results.htm"><b>About Search Results</b></a><br/>
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				<br/>
			  <xsl:choose>
                <xsl:when test="$currentpage!='adminevents'">
                  <a href="./sare_main.aspx?do=adminevents"><b>Admin Events</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="./sare_main.aspx?do=searchevents"><b>Events Search</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!--
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>-->
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  
                </xsl:when>
				
                <xsl:otherwise>
                  <b>Admin Events</b><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="./sare_main.aspx?do=searchevents"><b>Events Search</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!--
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>-->
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  
                </xsl:otherwise>
              </xsl:choose>
              <img src="../imges/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				<br/>		
              
            </xsl:when>
			<xsl:when test="SAREroot/user/userroles/role[@code='projPI']">
              <xsl:choose>
                <xsl:when test="$currentpage!='myProj'">
                  <a href="./sare_main.aspx?do=myProj"><b>My Projects and Reports</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=claimProj"><b>Retrieve New Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=MyProj"><b>Submit a Project Report</b></a><br/>
                </xsl:when>
                <xsl:otherwise>
                  <b>My Projects and Reports</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=claimProj"><b>Retrieve New Project</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=MyProj"><b>Submit a Project Report</b></a><br/>
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
			  <br/>
			<!--	
			<xsl:choose>
                <xsl:when test="$currentpage!='searchProj' and $currentpage!='searchprojprofile'">
                  <b>Project Search</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/about.htm"><b>About Project Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/howtosearch.htm"><b>Database Searching Tips</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/results.htm"><b>About Search Results</b></a><br/>
				  
                </xsl:when>
                <xsl:otherwise>
                  <b>Project Search</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/about.htm"><b>About Project Reports</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/howtosearch.htm"><b>Database Searching Tips</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/projects/results.htm"><b>About Search Results</b></a><br/>
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				<br/>
			-->
			<xsl:choose>
                <xsl:when test="$currentpage!='addevent'">
                  <a href="./sare_main.aspx?do=myevents"><b>Events</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!-- 
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>
				  -->
				</xsl:when>
                <xsl:otherwise>
                  <b>Events</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!--
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>
				  -->
				  </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				<br/>
            </xsl:when>

            <xsl:when test="SAREroot/user/userroles/role[@code='calSubmitter']">
              <xsl:choose>
                <xsl:when test="$currentpage!='addevent'">
                  <a href="./sare_main.aspx?do=myevents"><b>Events</b></a><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!--
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>-->
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  
                </xsl:when>
                <xsl:otherwise>
                  <b>Events</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;<br/>
				<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=myevents"><b>My Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="?do=addevent"><b>Add Calendar Events</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/instructions.html"><b>Calendar Instructions</b></a><br/>
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="/events/support.html"><b>Apply for Support</b></a><br/>
				  <!--
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
				  &#160;&#160;<a href="#"><b>Disclaimer</b></a><br/>-->
				  <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
                  
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
            </xsl:when>

            <xsl:when test="SAREroot/user/userroles/role[@code='calSubmitter' or @code='genUser']">
              <xsl:choose>
                <xsl:when test="$currentpage!='addevent'">
                  <a href="./sare_main.aspx?do=addevent"><b>Add Calendar Event</b></a><br/>
                </xsl:when>
                <xsl:otherwise>
                  <b>Add Calendar Event</b><br/>
                </xsl:otherwise>
              </xsl:choose>
              <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
            </xsl:when>				
			</xsl:choose>
            <a href="./sare_main.aspx?do=logout"><b>Log Out</b></a><br/>
            <img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/>

            <br/>
          </td>
</tr>
<tr>
	<td colspan="2"><img src="../images/linedk.gif" alt="" width="159" height="1" vspace="12" border="0"/></td>
</tr>
<tr><form action="#">

	<TD width="12"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>
	<td class="leftnav"><b class="leftbold">Topics:</b><br/>
	<img src="../images/x.gif" alt="" width="1" height="3" border="0"/><br/>
<select onChange="changepage(this)" id="select" name="formchange" class="formselect">
                  <option>Select a Topic</option>
				  <option value="../coreinfo/animals.htm">Animal Production</option>
	<option value="../coreinfo/crops.htm">Crop Production</option>

	<option value="../coreinfo/marketing.htm">Economics/Marketing</option>
	<option value="../coreinfo/education.htm">Education &amp; Training</option>
	<option value="../coreinfo/systems.htm">Integrated Systems</option>
	<option value="../coreinfo/pests.htm">Pest Management</option>
	<option value="../coreinfo/soil.htm">Soil Management</option>
	<option value="../coreinfo/success.htm">Success Stories</option>					
	<option value="../coreinfo/fruitandvegetable.htm">Vegetables/Fruit</option>	

</select></td></form>
</tr>
<tr>
	<td colspan="2"><img src="../images/x.gif" width="159" height="20" alt="" border="0"/></td>
</tr>
<tr>
	<TD width="12"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>
	<td class="leftnav">
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../coreinfo/farmers.htm">For <b>Farmers &amp; Ranchers</b></a><br/>

<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../coreinfo/educators.htm">For <b>Educators</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../coreinfo/researchers.htm">For <b>Researchers</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../coreinfo/consumers.htm">For <b>Consumers</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../publications/press.htm">For <b>Media</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/></td>
</tr>
<tr>
	<td colspan="2"><img src="../images/x.gif" width="159" height="20" alt="" border="0"/></td>

</tr>
<tr>
	<TD width="12"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>
	<td class="leftnav">
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../about/contacts.htm"><b>Contact</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="/search/"><b>Search</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/>
<a href="../coreinfo/sitemap.htm"><b>Site Map</b></a><br/>
<img src="../images/line.gif" width="135" height="1" alt="" border="0" vspace="3"/><br/></td>
</tr>

<tr>
	<td colspan="2"><img src="../images/x.gif" width="159" height="20" alt="" border="0"/></td>
</tr>
<tr>
	<TD width="12"><img src="../images/x.gif" alt="" width="12" height="1" border="0"/></TD>
	<td class="leftnav">
<a href="http://lists.sare.org/archives/sanet-mg.html"><b>Join the Discussion</b></a><br/>
SANET-MG discussion</td>
</tr>
</table>

</xsl:template>

</xsl:stylesheet>



