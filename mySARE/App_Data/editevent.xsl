<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="formreferrer">sare_main.aspx?do=myevents</xsl:param>

<xsl:template match="/">
<script language="JavaScript" src="./ajax/ts_picker4.js"/>

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
  <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE: Event Editor</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>

  <xsl:apply-templates select="SAREroot/calendarEvent"/>
	<br/>
	<small>
		This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/><br/>If you click on an event website, you will leave the SARE website.
	</small>
</xsl:template>

<xsl:template match="calendarEvent">
  
<!--
<xsl:choose>
<xsl:when test="@number = 0"><xsl:variable name="formaction" select="'sare_main.aspx?do=addevent'"/></xsl:when>
<xsl:otherwise><xsl:variable name="formaction" select="'sare_main.aspx?do=editevent'"/></xsl:otherwise>
</xsl:choose>

  <form method="post" action="{formaction}" name="eventDetails">
  <form method="post" action="{$formreferrer}" name="eventDetails">
 -->
  <form method="post" action="{$formreferrer}" name="eventDetails">

  <xsl:choose>
	  <xsl:when test="@number=0">
		  <xsl:variable name="formID" select="'createevent'"/>
		  <input type="hidden" name="formID" value="{$formID}"/>
		  <p class="subtitle">
			  Use this page to submit an event to SARE’s <a href="Events.aspx">Calendar of Events.</a>  Appropriate postings include workshops, tours, conferences, or other educational events that may be of interest to sustainable producers, educators, or consumers. Events should be regional or statewide in scope, and address issues of agricultural and food systems sustainability. If you have questions about whether your event is appropriate, please contact <a href="mailto:outreach@sare.org">outreach@sare.org.</a><br/>
		  </p>
		  <p class="subtitle">
			Before submitting your event, check the <a href="Events.aspx">Calendar</a> to make sure it isn’t already posted. Submit a new event by entering the requested information in all of the required fields below and clicking the “Submit Event” button. Be sure to remove any breaks or returns in the text if pasting text from another document.<br/>
		  </p>
		  <p class="subtitle">
			  An email will automatically be sent to the calendar administrator to request approval and posting of your event. Your event will not be posted until it has been approved by the administrator. To contact the administrator directly, please send an email to <a href="mailto:tech@sare.org">tech@sare.org.</a><br/>
		  </p>
	  </xsl:when>
  <xsl:otherwise>
    <xsl:variable name="formID" select="'editevent'"/>
    <input type="hidden" name="formID" value="{$formID}"/>
	<p class="subtitle">You can edit calendar event by changing fields in the form and clicking Update Event button. You can also delete a calendar event by clicking Delete Event.</p>
  </xsl:otherwise>
  </xsl:choose>

<!--
  <input type="hidden" name="@number" value=""/>
 -->
  <strong>Note: Fields marked with an asterisk (*) are required</strong>
  <p>
    <strong>* Event Name</strong>
    <blockquote><input id="boxName" maxLength="255" size="60" name="boxName" value="{name}" onkeypress ="WarnUser()"/></blockquote>
  </p>
  <p>
    <strong>* Event Location--City</strong> (For events within the United States, enter the city only in this field (e.g. Seattle).  For international events, enter city and country (e.g. London, England).  Please enter a series of events that span state or national boundaries as separate entries.)
    <blockquote><input id="boxLocation" maxLength="80" size="60" name="boxLocation" value="{location}" onkeypress ="WarnUser()"/></blockquote>
  </p>
  <p>
    <strong>* Event Location--State</strong> (Select "National" for events with no specific location, such as a virtual conference. Select "International" for events located outside the United States)
    <blockquote>
      <select id="listState" size="1" name="listState">
        <xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
          <xsl:call-template name="option">
            <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/calendarEvent/state"/></xsl:with-param>
            <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
            <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
          </xsl:call-template>
        </xsl:for-each>
	    <option value="">----------</option>
		<option  value="00">International</option>
		<option  value="01">National</option>
      </select>
    </blockquote>
  </p>
  <p>
    <strong>* Geographical or Audience Scope:</strong> (Please select the appropriate area of geographical relevance. For example, select "International" for a conference that will draw participants from multiple nations to discuss trade policy or other issues of international scope.  Select "Statewide" for a field day or workshop that plans to demonstrate farming or ranching production systems with specific relevance at the statewide level.)
    <blockquote>
      <select id="listScope" size="1" name="listScope">
        <xsl:for-each select="/SAREroot/geoscopes/geoscope">
          <xsl:call-template name="option">
            <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/calendarEvent/geoscope"/></xsl:with-param>
            <xsl:with-param name="value"><xsl:value-of select="code"/></xsl:with-param>
            <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
          </xsl:call-template>
        </xsl:for-each>
      </select>
    </blockquote>
  </p>
  <p>
    <strong>* Event Type:</strong>
    <blockquote>
      <select id="listType" size="1" name="listType">
	    <xsl:for-each select="/SAREroot/eventtypes/eventtype">
          <xsl:call-template name="option">
            <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/calendarEvent/type/name"/></xsl:with-param>
            <xsl:with-param name="value"><xsl:value-of select="code"/></xsl:with-param>
            <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
          </xsl:call-template>
        </xsl:for-each>
      </select>
      &#160; Other: <input type="text" size="30" maxlength="50" id="boxOtherType" name="boxOtherType"/><br/>
      <SMALL>If your event doesn't fit into any of the listed categories, please use the box marked "Other" to input a new category for this event.</SMALL>
    </blockquote>
  </p>
  <p>
    <strong>* Event Description:</strong>
    <blockquote><textarea id="boxDescription" name="boxDescription" rows="12" cols="70" onkeypress ="WarnUser()"><xsl:value-of disable-output-escaping="yes" select="description"/></textarea></blockquote>
  </p>
  <p>
    <strong>* Event Dates: </strong>Enter the start date as the end date for one day events.
	  <blockquote>Start Date:
      <br/>
      <input name="boxEvStartDate" maxlength="12" size="12" value="{times/startDateTime}" onkeypress ="WarnUser()"/>
<!--
       <input name="boxEvStartDate" maxlength="12" size="12" value="{times/startMonth}/{times/startDay}/{times/startYear}"/>
 -->
       &#160;&#160;
<a href="javascript:show_calendar4('document.eventDetails.boxEvStartDate', document.eventDetails.boxEvStartDate.value);WarnUser();" onmousedown="NoPrompt();">
<img src="./images/cal.gif" border="0" alt="Click here to pick the first day of the event." align="absmiddle" WIDTH="16" HEIGHT="16"/></a>
       &#160;&#160;(mm/dd/yyyy)
      <br/>End Date: <small>(optional)</small><br/>
		  <xsl:choose>
			  <xsl:when test="times/startDateTime != times/endDateTime">
				  <input name="boxEvEndDate" maxlength="12" size="12" value="{times/endDateTime}" onkeypress ="WarnUser()"/>
			  </xsl:when>
			  <xsl:otherwise>
				  <input name="boxEvEndDate" maxlength="12" size="12" value=""/>
			  </xsl:otherwise>
		  </xsl:choose>
      
<!--
      <input name="boxEvEndDate" maxlength="12" size="12" value="{times/endMonth}/{times/endDay}/{times/endYear}"/>
 -->
       &#160;&#160;
<a href="javascript:show_calendar4('document.eventDetails.boxEvEndDate', document.eventDetails.boxEvEndDate.value);WarnUser();" onmousedown="NoPrompt();">
<img src="./images/cal.gif" border="0" alt="Click here to pick the last day of the event." align="absmiddle" WIDTH="16" HEIGHT="16"/></a>
      &#160;&#160;(mm/dd/yyyy)
    </blockquote>
  </p>
  <p>
    <strong>Event Websites:</strong>
    <blockquote>
      <strong>Primary Website:</strong>
      <br/>Website Address: You must include <i>http://</i> for the website to display; for example: <I>http://www.sare.org/</I>. Click on the “Check Address” button to verify the address is entered correctly.
		<br/><input id="boxUrlAddress1" size="60" maxlength="255" name="boxUrlAddress1" value="{url[@order=1]/urlAddress}" onkeypress ="WarnUser()"/>
      <INPUT type="button" value="Check Address" onclick="javascript:window.open(document.eventDetails.boxUrlAddress1.value);" id="siteTest1" name="siteTest1"/>
      <!--URL Description used to go here-->
    </blockquote>
    <blockquote>
      <strong>Secondary Website</strong> (If necessary):
      <br/>Website Address:
      <br/><input id="boxUrlAddress2" size="60" maxlength="255" name="boxUrlAddress2" value="{url[@order=2]/urlAddress}" onkeypress ="WarnUser()"/>
      <INPUT type="button" value="Check Address" onclick="javascript:window.open(document.eventDetails.boxUrlAddress2.value);" id="siteTest2" name="siteTest2"/>
      <!--URL Description used to go here-->
    </blockquote>
  </p>
  <p>
  <xsl:for-each select="/SAREroot/nonusercontact[@context='eventcontact']">
  <strong>Event Contact Information</strong>
  <br/>
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
    <td>First Name</td>
   <td><input maxlength="255" size="25" name="firstName" value="{firstname}"/></td>
 </tr>
 <tr>
   <td>Last Name</td>
   <td><input maxlength="255" size="25" name="lastName" value="{lastname}"/></td>
 </tr>
 <tr>
   <td>Postfix (Jr., III, etc.)</td>
   <td><input size="10" name="namePostfix" value="{namepostfix}"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>Position</td>
   <td><input maxlength="255" size="25" name="orgPosition" value="{organization/position}"/></td>
 </tr>
 <tr>
   <td>Organization</td>
   <td><input maxlength="255" size="25" name="org" value="{organization/@name}"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>Address</td>
   <td><input maxlength="255" size="50" name="addrStreet1" value="{contact/addrStreet1}"/></td>
 </tr>
 <tr>
   <td>Address (cont.)</td>
   <td><input maxlength="255" size="50" name="addrStreet2" value="{contact/addrStreet2}"/></td>
 </tr>
 <tr>
   <td>City</td>
   <td><input maxlength="255" size="20" name="addrCity" value="{contact/addrCity}"/></td>
 </tr>
 <tr>
   <td>State</td>
   <td>
   <select name="addrState">
     <xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
       <xsl:call-template name="option">
         <xsl:with-param name="selected"><xsl:value-of select="/SAREroot/nonusercontact[@context='eventcontact']/contact/addrState"/></xsl:with-param>
         <xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
         <xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
       </xsl:call-template>
     </xsl:for-each>
   </select>
   </td>
 </tr>
 <tr>
   <td>Zip Code</td>
   <td><input onkeypress="return numbersonly(event,false)" maxlength="5" size="5" name="addrZip" value="{contact/addrZip}"/></td>
 </tr>
 <tr>
   <td>Zip +4</td>
   <td><input onkeypress="return numbersonly(event,false)" maxlength="4" size="4" name="addrZip4" value="{contact/addrZip4}"/></td>
 </tr>
 <tr><td/><td/></tr>
<tr>
  <td>Phone</td>
   <td><input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numPhone" value="{contact/numPhone}"/></td>
 </tr>
<tr>
   <td>Fax</td>
   <td><input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numFax" value="{contact/numFax}"/></td>
 </tr>
<tr>
   <td>Cell</td>
   <td><input onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" maxlength="16" size="16" name="numCell" value="{contact/numCell}"/></td>
 </tr>
 <tr><td/><td/></tr>
 <tr>
   <td>Email Address</td>
   <td><input maxlength="255" size="50" name="email" value="{contact/email}"/></td>
 </tr>
<tr>
   <td>Website</td>
   <td><input maxlength="255" size="50" name="website" value="{contact/website}"/></td>
</tr>
<tr><td/><td/></tr>

</tbody>
</table>
</xsl:for-each>
  </p>
  <p>
    <table BORDER="0" CELLPADDING="2" CELLSPACING="2">
<tr>
<td colspan="2">
	<xsl:if test="@number != 0">
		<li>
			To update the content of an event, enter the modified text in the appropriate field above, and click Update Event.
		</li>
		<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
			<li>
				To approve a pending event, click the Approved box, and then click Update Event
			</li>
		</xsl:if>
		<li>
			To delete an event, click the Confirm Delete box, and then Click Delete Event
		</li>
	</xsl:if>
</td>
<br/>
</tr>
      <tr>
        <td>

        <xsl:choose>
          <xsl:when test="@number = 0"><INPUT type="submit" name="cmdSubmitNewEvent" id="cmdSubmitNewEvent" value="Submit Event" onclick="NoPrompt()"/>
			  <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
				  &#160;&#160;
				  <xsl:choose>
					  <xsl:when test="@approvedstatus = 'True'">
						  <input name="approved" type="checkbox" checked="true" value="true"/>
					  </xsl:when>
					  <xsl:otherwise>
						  <input name="approved" type="checkbox" value="true"/>
					  </xsl:otherwise>
				  </xsl:choose>
				  Approved
			  </xsl:if>
			  <br/>
		  </xsl:when>
          <xsl:otherwise><INPUT type="submit" name="cmdUpdateEvent" id="cmdUpdateEvent" value="Update Event" onclick="NoPrompt()"/>&#160;&#160;
			  <xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">
				  <xsl:choose>
					  <xsl:when test="@approvedstatus = 'True'">
						  <input name="approved" type="checkbox" checked="true" value="true"/>
					  </xsl:when>
					  <xsl:otherwise>
						  <input name="approved" type="checkbox" value="true"/>
					  </xsl:otherwise>
				  </xsl:choose>
				  Approved
			  </xsl:if>
			<br/></xsl:otherwise>
        </xsl:choose>

        </td>
		</tr>
		<tr>
		<td>        
			<xsl:if test="@number != 0">
				<INPUT type="submit" name="cmdDeleteEvent" id="cmdDeleteEvent" value="Delete Event" onclick="NoPrompt()"/>&#160;&#160;&#160;&#160;<input name="confDel" type="checkbox"/>Confirm Delete</xsl:if><br/>
        </td>
		</tr>
		<tr>
        <td>
          <INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="history.go(-1)"/><br/>
        </td>        
      </tr>
    </table>

  </p>
  </form>
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

</xsl:stylesheet>








