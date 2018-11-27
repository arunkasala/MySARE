<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="usertype">participant</xsl:param>
<xsl:param name="formaction">editparticipant</xsl:param>

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
    <xsl:choose>
    <xsl:when test="substring($formaction,1,14) = 'addparticipant'">
      <span class="pagetitle">Add Participant</span><br/>
	  <p class="subtitle">Please enter required data for each project participant listed on your proposal.</p> 
	  <p class="subtitle">You should also add or delete participants that have changed since submitting your proposal.</p>
    </xsl:when>
    <xsl:otherwise>
    <span class="pagetitle">Edit Participant</span><br/>
	<p class="subtitle">Please update data for each project participant listed on your proposal.</p>
	<p class="subtitle">You should also add or delete participants that have changed since submitting your proposal.</p>
	</xsl:otherwise>
    </xsl:choose>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
	<strong>Note: Fields marked with an asterisk (*) are required</strong>
  <xsl:for-each select="SAREroot/user[@context='editing']">

  <form method="post" action="sare_main.aspx?do={$formaction}" name="participantDetails">

  <table style="text-align: left; width: 82%;" border="1" cellpadding="2" cellspacing="2">
  <tbody>
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
    <td>*First Name</td>
   <td><input maxlength="255" size="25" name="firstName" value="{firstname}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td>*Last Name</td>
   <td><input maxlength="255" size="25" name="lastName" value="{lastname}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td> Postfix (Jr., III, etc.)</td>
   <td><input size="10" name="namePostfix" value="{namepostfix}"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>*Position</td>
   <td><input maxlength="255" size="25" name="orgPosition" value="{organization/position}" onkeypress="WarnUser()"/>
</td>
</tr>
<tr>
<td>Organization</td>
<td>
   <input maxlength="255" size="25" name="org" value="{organization/@name}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>*Address</td>
   <td><input maxlength="255" size="50" name="addrStreet1" value="{contact/addrStreet1}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td>Address (cont.)</td>
   <td><input maxlength="255" size="50" name="addrStreet2" value="{contact/addrStreet2}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td>*City</td>
   <td><input maxlength="255" size="20" name="addrCity" value="{contact/addrCity}" onkeypress="WarnUser()"/></td>
 </tr>
 <tr>
   <td>*State</td>
   <td>
   <select name="addrState">
     <xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
       <xsl:call-template name="option">
         <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user[@context='editing']/contact/addrState"/></xsl:with-param>
         <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
         <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
       </xsl:call-template>
     </xsl:for-each>
   </select>
   </td>
 </tr>
 <tr>
   <td>*Zip Code</td>
   <td><input onkeypress="return numbersonly(event,false)" maxlength="5" size="5" name="addrZip" value="{contact/addrZip}" onchange="WarnUser()"/></td>
 </tr>
 <tr>
   <td>Zip +4</td>
   <td><input onkeypress="return numbersonly(event,false)" maxlength="4" size="4" name="addrZip4" value="{contact/addrZip4}" onchange="WarnUser()"/>
</td>
</tr>
<tr>
<td/>
<td/>
</tr>
<tr>
<td>*Phone</td>
<td>
   <input maxlength="16" size="16" name="numPhone" value="{contact/numPhone}" onkeypress="WarnUser()" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"/>
	<xsl:choose>
		<xsl:when test="contact/numPhone = '' and substring($formaction,1,14) != 'addparticipant'"><br/>
			<input name="partPhone" type="checkbox" checked="checked"/>This participant does not have a phone
		</xsl:when>
		<xsl:otherwise>
			<br/><input name="partPhone" type="checkbox"/>This participant does not have a phone
		</xsl:otherwise>
	</xsl:choose>
</td>
 </tr>
<tr>
   <td>Fax</td>
   <td><input maxlength="16" size="16" name="numFax" value="{contact/numFax}" onkeypress="WarnUser()" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"/></td>
 </tr>
<tr>
   <td>Cell</td>
   <td><input maxlength="16" size="16" name="numCell" value="{contact/numCell}" onkeypress="WarnUser()" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>*Email Address</td>
   <td><input maxlength="255" size="50" name="email" value="{contact/email}" onkeypress="WarnUser()"/>
	<xsl:choose>
	   <xsl:when test="contact/email = '' and substring($formaction,1,14) != 'addparticipant'"><br/>
			<input name="partEmail" type="checkbox" checked="checked"/>This participant does not have an e-mail address
	   </xsl:when>
	   <xsl:otherwise>
		   <br/><input name="partEmail" type="checkbox"/>This participant does not have an e-mail address
	   </xsl:otherwise>
	</xsl:choose>
   </td>
</tr>
<tr>
<td>Website</td>
<td>
   <input maxlength="255" size="50" name="website" value="{contact/website}" onkeypress="WarnUser()"/></td>
</tr>
<tr><td/><td/></tr>

</tbody>
</table>
<br/>

	  <table BORDER="0" CELLPADDING="2" CELLSPACING="2">
		  <tr>
			  
<td colspan="1">
	<xsl:if test="substring($formaction,1,14) != 'addparticipant'">
		<input name="ConfirmDelete" type="checkbox" value="true"/>Confirm Delete
	</xsl:if>
</td>
		  </tr>		 

      <tr>
		  <td>
			  <xsl:choose>
			  <xsl:when test="substring($formaction,1,14) = 'addparticipant'">
				  <input type="submit" value="Save and Add Next Participant" name="cmdAddNextParticipant" ID="cmdAddNextParticipant" onclick="NoPrompt()"/>&#160;&#160;
				  <input type="submit" value="Save Participant" name="cmdChangeParticipantDetails" ID="cmdChangeParticipantDetails" onclick="NoPrompt()"/>
				  <br/>
			  </xsl:when>
			  <xsl:otherwise>
				  
					  <input type="submit" value="Delete Participant" name="cmdDeleteParticipantDetails" ID="cmdDeleteParticipantDetails" onclick="NoPrompt()"/>
					  <br/>
				  
				  <td>
					  <input type="submit" value="Update Participant" name="cmdChangeParticipantDetails" ID="cmdChangeParticipantDetails" onclick="NoPrompt()"/>
					  <br/>
				  </td>
			  </xsl:otherwise>
			  </xsl:choose>
		</td>  
		<td>
			<input type="reset" value="Reset Form" name="cmdResetChangeParticipantDetails" ID="cmdResetChangeParticipantDetails" onclick="NoPrompt()"/><br/>
		</td>
		<td>
			<input type="submit" value="Cancel Changes" name="cmdCancelChangeParticipantDetails" ID="cmdCancelChangeParticipantDetails" onclick="NoPrompt()"/>
		</td>
		<td>
			<input type="submit" value="Back To Overview" name="cmdBackToOverview" ID="cmdBackToOverview" onclick="NoPrompt()"/>
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
    <xsl:when test="/SAREroot/user/userroles/role[@code=$value]">
      <input name="{$value}" type="checkbox" checked="checked"/>
      <label for="{$value}"><xsl:value-of select="$label"/></label>
    </xsl:when>
    <xsl:otherwise>
      <input name="{$value}" type="checkbox"/>
      <label for="{$value}"><xsl:value-of select="$label"/></label>
    </xsl:otherwise>
  </xsl:choose>
  <xsl:if test="$value='regAdmin'">
    &#160;
    <select name="regAdminRegion">
      <xsl:for-each select="/SAREroot/regions/region">
        <xsl:call-template name="option">
          <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/user/userroles/role[@code='regadmin']/@region"/></xsl:with-param>
          <xsl:with-param name="value"><xsl:value-of select="regionCode"/></xsl:with-param>
          <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
        </xsl:call-template>
      </xsl:for-each>
    </select>
  </xsl:if>
  <br/>
</xsl:template>

</xsl:stylesheet>




