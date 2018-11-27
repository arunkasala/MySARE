<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="usertype">user</xsl:param>

<xsl:template match="/">
	<script LANGUAGE="JavaScript">
		<![CDATA[
			var showPrompt = false;

			
			function closeIt()
			{
			  if (showPrompt)
				return "Would you like to save your data before leaving this page?";
			}
			window.onbeforeunload=closeIt;

			function WarnUser()
			{
				showPrompt = true;
			}

			function NoPrompt()
			{
				showPrompt = false;
			}
			function NoAction()
			{
				if (showPrompt)
				{
					showPrompt = false;
					return true;		
					
				}
				else
				{
					alert ("No change was made to the user data. Please enter changes before clicking 'Change Details'");
					return false;					
				}
			}

		function numbersonly(e, format)
		{
			 var key;
			 var keychar;

			 if (window.event) {
				 key = window.event.keyCode;
			  }
			  else if (e) {
			   key = e.which;
			  }
			  else {
				  return true;
			   }
			  keychar = String.fromCharCode(key);

			  if ((key==null) || (key==0) || (key==8) ||  (key==9) || (key==13) || (key==27) ) {
				  return true;
				}
			   else if ((("0123456789").indexOf(keychar) > -1)) {
				  return true;
			   }
			   else if (format && (keychar == "-")) {
				 return true;
			   }
			   else if (format && (keychar == "(")) {
				 return true;
			   }
			   else if (format && (keychar == ")")) {
				 return true;
			   }
			   else
				  return false;
		}

		var zChar = new Array(' ', '(', ')', '-', '.');
		var maxphonelength = 13;
		var phonevalue1;
		var phonevalue2;
		var cursorposition;

		function ParseForNumber1(object)
		{
			phonevalue1 = ParseChar(object.value, zChar);
		}

		function ParseForNumber2(object)
		{
			phonevalue2 = ParseChar(object.value, zChar);
		}

		function backspacerUP(object,e)
		{
			if(e)
			{
				e = e
			}
			else
			{
				e = window.event
			}

			if(e.which)
			{
				var keycode = e.which
			}
			else
			{
				var keycode = e.keyCode
			}

			ParseForNumber1(object)

			if(keycode >= 48)
			{
				ValidatePhone(object)
			}
		}

		function backspacerDOWN(object,e)
		{
			if(e)
			{
				e = e
			}
			else
			{
				e = window.event
			}

			if(e.which)
			{
				var keycode = e.which
			}
			else
			{
				var keycode = e.keyCode
			}

			ParseForNumber2(object)
		}

		function GetCursorPosition()
		{
			var t1 = phonevalue1;
			var t2 = phonevalue2;
			var bool = false

			for (i=0; i<t1.length; i++)
			{
				if (t1.substring(i,1) != t2.substring(i,1))
				{
					if(!bool)
					{
						cursorposition=i
						bool=true
					}
				}
			}
		}

		function ValidatePhone(object)
		{
			var p = phonevalue1

			p = p.replace(/[^\d]*/gi,"")

			if (p.length < 3)
			{
				object.value=p
			}
			else if(p.length==3)
			{
				pp=p;
				d4=p.indexOf('(')
				d5=p.indexOf(')')

				if(d4==-1)
				{
					pp="("+pp;
				}

				if(d5==-1)
				{
					pp=pp+")";
				}
				object.value = pp;
			}
			else if(p.length>3 && p.length < 7)
			{
				p ="(" + p;
				l30=p.length;
				p30=p.substring(0,4);
				p30=p30+")"

				p31=p.substring(4,l30);
				pp=p30+p31;

				object.value = pp;

			}
			else if(p.length >= 7)
			{
				p ="(" + p;
				l30=p.length;
				p30=p.substring(0,4);
				p30=p30+")"

				p31=p.substring(4,l30);
				pp=p30+p31;

				l40 = pp.length;
				p40 = pp.substring(0,8);
				p40 = p40 + "-"

				p41 = pp.substring(8,l40);
				ppp = p40 + p41;

				object.value = ppp.substring(0, maxphonelength);
			}

			GetCursorPosition()

			if(cursorposition >= 0)
			{
				if (cursorposition == 0)
				{
					cursorposition = 2
				}
				else if (cursorposition <= 2)
				{
					cursorposition = cursorposition + 1
				}
				else if (cursorposition <= 5)
				{
					cursorposition = cursorposition + 2
				}
				else if (cursorposition == 6)
				{
					cursorposition = cursorposition + 2
				}
				else if (cursorposition == 7)
				{
					cursorposition = cursorposition + 4
					e1=object.value.indexOf(')')
					e2=object.value.indexOf('-')

					if (e1>-1 && e2>-1)
					{
						if (e2-e1 == 4)
						{
							cursorposition = cursorposition - 1
						}
					}
				}
				else if (cursorposition < 11)
				{
					cursorposition = cursorposition + 3
				}
				else if (cursorposition == 11)
				{
					cursorposition = cursorposition + 1
				}
				else if (cursorposition >= 12)
				{
					cursorposition = cursorposition
				}

				var txtRange = object.createTextRange();
				txtRange.moveStart( "character", cursorposition);
				txtRange.moveEnd( "character", cursorposition - object.value.length);
				txtRange.select();
			}

		}

		function ParseChar(sStr, sChar)
		{
			if (sChar.length == null)
			{
				zChar = new Array(sChar);
			}
			else zChar = sChar;

			for (i=0; i<zChar.length; i++)
			{
				sNewStr = "";

				var iStart = 0;
				var iEnd = sStr.indexOf(sChar[i]);

				while (iEnd != -1)
				{
					sNewStr += sStr.substring(iStart, iEnd);
					iStart = iEnd + 1;
					iEnd = sStr.indexOf(sChar[i], iStart);
				}
				sNewStr += sStr.substring(sStr.lastIndexOf(sChar[i]) + 1, sStr.length);

				sStr = sNewStr;
		}

		return sNewStr;

		}
	]]>
	</script>

  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span class="pagetitle">Edit User Account</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  <p class="subtitle">To edit your user account change the fields in the form below and "Change Details."</p>
	<xsl:if test="/SAREroot/user[@context='current']/userroles/role[@code='admin' or @code='natAdmin']">
		<p>Your role allows you to edit other user accounts, to assign user role(s), and delete users.</p>
	</xsl:if>
  <strong>Note: Fields marked with an asterisk (*) are required</strong>
  <xsl:for-each select="SAREroot/user[@context='editing']">
  <form method="post" action="sare_main.aspx?do=editUser" name="userDetails">
  <table id="projoverview" style="text-align: left; width: 82%;" border="1" cellpadding="2" cellspacing="2">
  <tbody>
  <tr>
    <td>Username</td>
    <td><xsl:value-of select="@username"/></td>
  </tr>
  <tr>
    <td width="30%">Title</td>
    <td width="70%"><select name="nameTitle">
      <xsl:call-template name="option"><xsl:with-param name="value"/><xsl:with-param name="label"/><xsl:with-param name="selected"><xsl:value-of select="nametitle"/></xsl:with-param></xsl:call-template>
      <xsl:call-template name="option"><xsl:with-param name="value">Mr</xsl:with-param><xsl:with-param name="label">Mr</xsl:with-param><xsl:with-param name="selected"><xsl:value-of select="nametitle"/></xsl:with-param></xsl:call-template>
      <xsl:call-template name="option"><xsl:with-param name="value">Ms</xsl:with-param><xsl:with-param name="label">Ms</xsl:with-param><xsl:with-param name="selected"><xsl:value-of select="nametitle"/></xsl:with-param></xsl:call-template>
      <xsl:call-template name="option"><xsl:with-param name="value">Mrs</xsl:with-param><xsl:with-param name="label">Mrs</xsl:with-param><xsl:with-param name="selected"><xsl:value-of select="nametitle"/></xsl:with-param></xsl:call-template>
      <xsl:call-template name="option"><xsl:with-param name="value">Dr</xsl:with-param><xsl:with-param name="label">Dr</xsl:with-param><xsl:with-param name="selected"><xsl:value-of select="nametitle"/></xsl:with-param></xsl:call-template>
    </select></td>
  </tr>
  <tr>
    <td><xsl:choose>
      <xsl:when test="firstname != ''">* First Name</xsl:when>
      <xsl:otherwise><span class="boldred">* First Name</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="25" name="firstName" value="{firstname}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="lastname != ''">* Last Name</xsl:when>
      <xsl:otherwise><span class="boldred">* Last Name</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="25" name="lastName" value="{lastname}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td> Postfix (Jr., III, etc.)</td>
   <td><input size="10" name="namePostfix" value="{namepostfix}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>Position</td>
   <td><input maxlength="255" size="25" name="orgPosition" value="{organization/position}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="organization[@name != '']">* Organization</xsl:when>
      <xsl:otherwise><span class="boldred">* Organization</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="25" name="org" value="{organization/@name}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="contact/addrStreet1 != ''">* Address</xsl:when>
      <xsl:otherwise><span class="boldred">* Address</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="50" name="addrStreet1" value="{contact/addrStreet1}" onkeypress="WarnUser()"/>
</td>
</tr>
<tr>
<td> Address (cont.)</td>
<td>
   <input maxlength="255" size="50" name="addrStreet2" value="{contact/addrStreet2}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="contact/addrCity != ''">* City</xsl:when>
      <xsl:otherwise><span class="boldred">* City</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="20" name="addrCity" value="{contact/addrCity}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="contact/addrState != ''">* State</xsl:when>
      <xsl:otherwise><span class="boldred">* State</span></xsl:otherwise>
   </xsl:choose></td>
   <td>
   <select name="addrState">
     <xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
       <xsl:if test="abbr != '' and abbr != 'BC' and abbr != 'MP' and abbr != 'NP' and abbr != 'QA'">
         <xsl:call-template name="option">
           <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user[@context='editing']/contact/addrState"/></xsl:with-param>
           <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
           <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
         </xsl:call-template>
       </xsl:if>
     </xsl:for-each>
   </select>
   </td>
 </tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="contact/addrZip != ''">* Zip Code</xsl:when>
      <xsl:otherwise><span class="boldred">* Zip Code</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input onkeypress="return numbersonly(event,false)" maxlength="5" size="5" name="addrZip" value="{contact/addrZip}" onchange="WarnUser()"/>
</td>
</tr>
<tr>
<td> Zip +4</td>
<td>
   <input onkeypress="return numbersonly(event,false)" maxlength="4" size="4" name="addrZip4" value="{contact/addrZip4}" onchange="WarnUser()"/></td></tr>
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
   <input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numPhone" value="{contact/numPhone}" onchange="WarnUser()"/>
	<xsl:choose>
		<xsl:when test="contact/numPhone != ''">
			<input name="phoneCheck" type="checkbox">Does not have phone number</input>
		</xsl:when>
		<xsl:when test="$message">
			<input name="phoneCheck" type="checkbox">Does not have phone number</input>
		</xsl:when>
		<xsl:otherwise>
			<input name="phoneCheck" type="checkbox" checked="checked">Does not have phone number</input>
		</xsl:otherwise>
	</xsl:choose>
	
</td>
 </tr>
<tr>
   <td>Fax</td>
   <td><input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numFax" value="{contact/numFax}" onchange="WarnUser()"/></td>
 </tr>
<tr>
   <td>Cell</td>
   <td><input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numCell" value="{contact/numCell}" onchange="WarnUser()"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td><xsl:choose>
      <xsl:when test="contact/email != ''">* email Address</xsl:when>
      <xsl:otherwise><span class="boldred">* email Address</span></xsl:otherwise>
   </xsl:choose></td>
   <td><input maxlength="255" size="50" name="email" value="{contact/email}" onkeypress="WarnUser()"/>
</td>
</tr>
<tr>
<td>Website</td>
<td>
   <input maxlength="255" size="50" name="website" value="{contact/website}" onkeypress="WarnUser()"/></td>
</tr>
<tr><td/><td/></tr>

<xsl:if test="/SAREroot/user[@context='current']/userroles/role[@code='admin' or @code='regAdmin' or @code='natAdmin']">
<tr>
   <td><a href="help/usersearch.htm">Roles</a>
	   &#160;<!--<xsl:text disable-output-escaping="yes"><![CDATA[
									<a href="help/usersearch.htm#roles" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="./images/help.png" border="0" /></a>
									<div class="highslide-html-content" id="highslide-html" style="width: 300px">
   									  <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
										<a href="#" onclick="return hs.close(this)" class="control">Close</a>
  									  </div>
									<div class="highslide-body"></div>
									</div>
								]]></xsl:text>-->
	   <span class="tooltiptext">
		   <a href="/mysare/help/usersearch.htm#roles" target="_blank">
			   <h3>User Roles</h3>
		   </a>
		   <p>
			   &#160;
		   </p>
		   

				   <ul>
					   <li>
						   <b>Site Admin (admin)</b> -
						   This role grants full access to data control within the reporting, calendar, and resource systems, including override of regional approval; the ability to create, delete, and modify user accounts, including full role and ownership management
					   </li>

					   <li>
						   <b>Regional Admin (reg.admin)</b> -
						   This role grants access to all approval/editing functions for data
						   in their regions within the reporting, calendar, and resource systems,
						   but can be overridden by a national administrator; the ability to create,
						   delete, and modify user accounts, including role and ownership management,
						   but not the ability to modify or delete users with administrative roles
						   (regional or national) nor to assign these roles to other users
					   </li>

					   <li>
						   <b>National Admin (admin)</b> -
						   This role grants full access to data control within the reporting,
						   calendar, and resource systems, including override of regional approval;
						   the ability to create, delete, and modify user accounts, including full
						   role and ownership management
					   </li>

					   <li>
						   <b>Project PI (proj.pi)</b> -
						   This role allows the user to edit projects, reports, and
						   profiles of projects for which they're PI
					   </li>

					   <li>
						   <b>Calendar Submitter (cal.submitter)</b> -
						   This role is automatically assigned to users who submit a
						   calendar event, and allows them to edit their events
					   </li>





				   </ul>

			  
		  </span>
   </td>
   <td>
     <xsl:for-each select="/SAREroot/userRoles/userRole[@code!='genUser' and @code!='lockAcct' and @code != 'projProposer' and @code != 'resAuthor' and @code != 'resCompManager' and @code !='resManager' and @code !='natStaff']">
       <xsl:sort select="@priority"/>
       <xsl:call-template name="option2">
         <xsl:with-param name="value"><xsl:value-of select="@code"/></xsl:with-param>
         <xsl:with-param name="label"><xsl:value-of select="@description"/></xsl:with-param>
       </xsl:call-template>
     </xsl:for-each>
   </td>
</tr>
</xsl:if>

<tr>
   <td>New Password</td>
   <td><input type="password" size="10" name="password" onkeypress="WarnUser()"/></td>
</tr>
<tr>
   <td>Confirm New Password</td><td><input type="password" size="10" name="passconf" onkeypress="WarnUser()"/></td>
</tr>
</tbody>
</table>
<br/>
<table>
<!--
<tr>
  <td><xsl:choose>
      <xsl:when test="contact/onEmailList = 'True'"><input name="sareMailList" type="checkbox" checked="checked"/></xsl:when>
      <xsl:otherwise><input name="sareMailList" type="checkbox"/></xsl:otherwise>
      </xsl:choose>
    I'd like to be on the SARE mailing list
  </td>
</tr>

<tr><td>
  <small>We will use your e-mail address to contact you about your SARE projects, resources and/or calendar events. This box will not affect those messages. Rather, SARE occasionally sends information about new books and bulletins. If you want to receive these mailings, check the box. We do NOT share our mailing list.</small>
</td></tr>
-->
<tr>
<td colspan="2">
	<br/>
	<li>
		To change user information, modify the text in the appropriate field above and click 'Change Details'.
	</li>
	<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
		<li>
			To disable/enable user, click the "User can log in" box below and then click 'Change Details'.
		</li>
		<li>
			To delete user, click the "Confirm Delete" box and then click 'Delete User'.
		</li>
	</xsl:if>	
</td>
<br/>
</tr>
</table>
<br/>

  <xsl:if test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin' or @code='admin' or @code='natAdmin']">
	  <!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/useredit.htm#disable" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="../images/help.png" border="0" /></a>]]></xsl:text> -->
       <xsl:call-template name="option2">
         <xsl:with-param name="value">genUser</xsl:with-param>
         <xsl:with-param name="label">User can log in (un-check to disable user)
	 </xsl:with-param>
       </xsl:call-template>	  
  </xsl:if>


  <input type="hidden" value="{username}" name="targetUser" ID="targetUser"/>
<table>
<!-- 
<td>
  <xsl:if test="/SAREroot/user[@context='current']/userroles/role[@code='admin' or @code='natAdmin']">
	  <input name="ConfirmDelete" type="checkbox"/>Confirm Delete&#160;<xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/useredit.htm#delete" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img src="../images/help.png" border="0" /></a>]]></xsl:text>
  </xsl:if>
</td>
-->
	<tr>
		<br/>
		<td>
			<input type="submit" value="Change Details" name="cmdChangeUserDetails" ID="cmdChangeUserDetails" onclick="NoPrompt()"/>
			<br/>
		</td>
	</tr>
<!--   <input type="reset" value="Reset Form" name="cmdResetChangeUserDetails" ID="cmdResetChangeUserDetails" onclick="NoPrompt()"/><br/> -->
	<tr>
		<td>
			<input type="submit" value="Cancel Changes" name="cmdCancelChangeUserDetails" ID="cmdCancelChangeUserDetails" onclick="NoPrompt()"/>
			<br/>			
		</td>
	</tr>
	<tr>
		<td>
		  <xsl:if test="/SAREroot/user[@context='current']/userroles/role[@code='admin' or @code='natAdmin']">
			  <input type="submit" value="Delete User" name="cmdDeleteUser" ID="cmdDeleteUser" onclick="NoPrompt()"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;<input name="ConfirmDelete" type="checkbox"/>Confirm Delete
		  <br/>
		  </xsl:if>
		</td>
	</tr>
</table>
  </form>
  </xsl:for-each>
</xsl:template>

<xsl:template name="option">
<!-- Generates an option to go in the drop-down list -->
  <xsl:param name="selected"/> <!-- value of the currently selected option -->
  <xsl:param name="value"/>  <!-- value of the option to be created -->
  <xsl:param name="label"/> <!-- label of the option to be created -->
  <xsl:choose>
    <xsl:when test="$selected=$value">
     <option value="{$value}" selected="selected"><xsl:value-of select="$label"/></option>
    </xsl:when>
    <xsl:otherwise>
      <option value="{$value}"><xsl:value-of select="$label"/></option>
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="option2">
<!-- Generates a checkbox that is checked if a matching user role exists-->
  <xsl:param name="value"/>  <!-- value of the option to be created -->
  <xsl:param name="label"/> <!-- label of the option to be created -->
  
  <xsl:choose>
    <xsl:when test="/SAREroot/user[@context='editing']/userroles/role[@code=$value]">
	  <input name="{$value}" type="checkbox" checked="checked" onClick="WarnUser()"/>
      <label for="{$value}"><xsl:value-of select="$label"/></label>		
    </xsl:when>
	<xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='admin' or @code='natAdmin']">
	  <input name="{$value}" type="checkbox" onClick="WarnUser()"/>
	  <label for="{$value}"><xsl:value-of select="$label"/></label>			  
	</xsl:when>
	<xsl:when test="/SAREroot/user[@context='current']/userroles/role[@code='regAdmin']">
		<xsl:choose>
			<xsl:when test="$value='regAdmin'">
				<input name="{$value}" type="checkbox" onClick="WarnUser()"/>
				<label for="{$value}">
					<xsl:value-of select="$label"/>
				</label>
			</xsl:when>
			<xsl:otherwise>
				<input name="{$value}" type="checkbox" disabled="disabled" onClick="WarnUser()"/>
				<label for="{$value}">
					<xsl:value-of select="$label"/>
				</label>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:when>
    <xsl:otherwise>
	  <input name="{$value}" type="checkbox" disabled="disabled" onClick="WarnUser()"/>
      <label for="{$value}"><xsl:value-of select="$label"/></label>		
    </xsl:otherwise>
  </xsl:choose>
  <xsl:if test="$value='regAdmin'">
    &#160;
    <select name="regAdminRegion" onchange="WarnUser()">
      <xsl:for-each select="/SAREroot/regions/region">
        <xsl:call-template name="option">
          <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user[@context='editing']/userroles/role[@code='regAdmin']/@region"/></xsl:with-param>
          <xsl:with-param name="value"><xsl:value-of select="regionCode"/></xsl:with-param>
          <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
        </xsl:call-template>
      </xsl:for-each>
    </select>
  </xsl:if>
  <xsl:if test="$value='projPI'">
	  &#160;
	  <xsl:value-of select="/SAREroot/user[@context='editing']/userroles/role[@code='projPI']/@region"/>
  </xsl:if>
  <br/>
</xsl:template>

</xsl:stylesheet>







