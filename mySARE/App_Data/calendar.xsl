<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="currentMonth">October</xsl:param>
<xsl:param name="currentDay">19</xsl:param>
<xsl:param name="currentYear">2007</xsl:param>
<xsl:param name="optionMonths">4</xsl:param>
<xsl:param name="optionView">PartialDescriptions</xsl:param>
<xsl:param name="optionRegion"/>
<xsl:param name="optionGeoscope">All</xsl:param>
<xsl:param name="optionInternational">yes</xsl:param>
<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">
  <p>
    <span class="pagetitle"><xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE</span><br/>
    <span class="pagetitle">Calendar of Sustainable Agriculture Events</span><br/>
    <xsl:if test="$message"><br/><b><i><span style="color:#FF0000;"><xsl:value-of select="$message"/></span></i></b></xsl:if>
    <xsl:if test="$message2"><br/><i><xsl:value-of select="$message2"/></i></xsl:if>
  </p>
  <ul>
    <li>Click on event title for more information</li>
    <li><a href="#options">View more months or change display options</a></li>
    <li><a href="#options">Sort by state, region, or scope</a></li>
    <li>Submit an event to <a href="mailto:san@sare.org">san@sare.org</a></li>
    <li><a href="edit_events.asp">Input your event</a></li>
    <li><a href="#disclaimer">Disclaimer</a></li>
  </ul>
  <p class="outlined padded">Click <a href="/2008conference/">here</a> for information on the 2008 SARE Conference.</p>
  <p><span class="listMonthsHead">Events for the next 4 months:</span></p>

  <xsl:apply-templates select="SAREroot/calendarEvents/calendarEvent"/>

  <form name="thisForm" METHOD="post">
  
  <table BORDER="0" CELLSPACING="0" CELLPADDING="4" BGCOLOR="#FFFFE6" class="optionpanel">
    <tr>
      <th colspan="2">
        <A name="options">Calendar Options</A>
      </th>
    </tr>
    <tr>
      <td width="50%" VALIGN="MIDDLE" ALIGN="left">Show Next
        <SELECT name="boxNumMonths" id="boxNumMonths" size="1">
          <OPTION value="1">1</OPTION>

            <OPTION value="2">2</OPTION>
            <OPTION value="3">3</OPTION>
            <OPTION value="4">4</OPTION>
            <OPTION value="5">5</OPTION>
            <OPTION value="6">6</OPTION>
            <OPTION value="7">7</OPTION>
            <OPTION value="8">8</OPTION>
            <OPTION value="9">9</OPTION>
            <OPTION value="10">10</OPTION>

            <OPTION value="11">11</OPTION>
            <OPTION value="12">12</OPTION>
        </SELECT>
        Months
      </td>
      <td width="50%">
        <div class="alleft">State/Region&#160;</div>
        <div class="alright">
          <select id="boxState" size="1" name="boxState">
            <option value="">All</option>

            <option  value="NEregion">Northeast Region</option>
            <option  value="NCregion">North Central Region</option>
            <option  value="Sregion">Southern Region</option>
            <option  value="Wregion">Western Region</option>
            <option value="">----------</option>
            <option  value="00">International</option>
            <option  value="01">National</option>
            <option value="">----------</option>
            <option value="01">National</option>

            <option value="AL">Alabama</option>
            <option value="AK">Alaska</option>
            <option value="AS">American Samoa</option>
            <option value="AZ">Arizona</option>
            <option value="AR">Arkansas</option>
            <option value="CA">California</option>
            <option value="CO">Colorado</option>
            <option value="CT">Connecticut</option>
            <option value="DE">Delaware</option>

            <option value="DC">District of Columbia</option>
            <option value="FL">Florida</option>
            <option value="GA">Georgia</option>
            <option value="GU">Guam</option>
            <option value="HI">Hawaii</option>
            <option value="ID">Idaho</option>
            <option value="IL">Illinois</option>
            <option value="IN">Indiana</option>
            <option value="IA">Iowa</option>

            <option value="KS">Kansas</option>
            <option value="KY">Kentucky</option>
            <option value="LA">Louisiana</option>
            <option value="ME">Maine</option>
            <option value="MD">Maryland</option>
            <option value="MA">Massachusetts</option>
            <option value="MI">Michigan</option>
            <option value="FM">Micronesia</option>
            <option value="MN">Minnesota</option>

            <option value="MS">Mississippi</option>
            <option value="MO">Missouri</option>
            <option value="MT">Montana</option>
            <option value="NE">Nebraska</option>
            <option value="NV">Nevada</option>
            <option value="NH">New Hampshire</option>
            <option value="NJ">New Jersey</option>
            <option value="NM">New Mexico</option>
            <option value="NY">New York</option>

            <option value="NC">North Carolina</option>
            <option value="ND">North Dakota</option>
            <option value="MP">Northern Mariana Islands</option>
            <option value="OH">Ohio</option>
            <option value="OK">Oklahoma</option>
            <option value="OR">Oregon</option>
            <option value="PA">Pennsylvania</option>
            <option value="PR">Puerto Rico</option>
            <option value="RI">Rhode Island</option>

            <option value="SC">South Carolina</option>
            <option value="SD">South Dakota</option>
            <option value="TN">Tennessee</option>
            <option value="TX">Texas</option>
            <option value="UT">Utah</option>
            <option value="VT">Vermont</option>
            <option value="VI">Virgin Islands</option>
            <option value="VA">Virginia</option>
            <option value="WA">Washington</option>

            <option value="WV">West Virginia</option>
            <option value="WI">Wisconsin</option>
            <option value="WY">Wyoming</option>
          </select>
        </div>
      </td>
    </tr>
    <tr>
      <td ALIGN="left" rowspan="2">
        <TABLE id="optViewStyle" name="optViewStyle" border="0" cellpadding="2" cellspacing="2">
            <TR><TD><INPUT name="optViewStyle" value="0" type="radio"/><LABEL for="optViewStyle" htmlfor="optViewStyle">View Titles Only</LABEL></TD></TR>
            <TR><TD><INPUT name="optViewStyle" value="1" type="radio"/><LABEL for="optViewStyle" htmlfor="optViewStyle">View Partial Descriptions</LABEL></TD></TR>
            <TR><TD><INPUT name="optViewStyle" value="2" type="radio"/><LABEL for="optViewStyle" htmlfor="optViewStyle">View Full Descriptions</LABEL></TD></TR>
        </TABLE>
      </td>
      <td>
        <div class="alleft">Geographic Scope</div>
        <div class="alright">
          <select id="boxScope" size="1" name="boxScope">
            <option value="">All</option>
            <option value="USST">Statewide</option>
            <option value="REG">Regional</option>
            <option value="US">National</option>
          </select>
        </div>
      </td>
    </tr>
    <tr>
      <td>
        <div class="alleft">Include International Events</div>
        <div class="alright">
          <INPUT type="checkbox" id="chkInternational" name="chkInternational"/>
        </div>
      </td>
    </tr>
    <tr>
      <td ALIGN="CENTER" colspan="2">
        <p>
          <INPUT type="button" name="btnChangeView" id="btnChangeView" value="Change Calendar View" onclick="thisPage._fireEvent('btnChangeView','onclick'); return false;"/>
        </p>
      </td>
    </tr>
  </table>
  
  </form>
  
  <br/>
  <small>This calendar is maintained with support from the Sustainable Agriculture Research and Education (SARE) program, which is funded by the U.S. Department of Agriculture- National Institute of Food and Agriculture (USDA-NIFA). Any opinions, findings, conclusions or recommendations expressed within do not necessarily reflect the view of the SARE program or the U.S. Department of Agriculture. USDA is an equal opportunity provider and employer.<br/>If you click on an event website, you will leave the SARE website.</small>
  
</xsl:template>

<xsl:template match="calendarEvent">
  <p>
    <span class="evDate">
      <xsl:value-of select="times/startMonth"/>&#160;<xsl:value-of select="times/startDay"/>,&#160;<xsl:value-of select="times/startYear"/>&#160;-&#160;
      <xsl:value-of select="times/endMonth"/>&#160;<xsl:value-of select="times/endDay"/>,&#160;<xsl:value-of select="times/endYear"/>
    </span><br/>
    <a href="show_events.asp?event={@number}"><span class="evTitle"><xsl:value-of select="name"/></span></a><br/>
    <xsl:value-of select="description"/><br/>
    <b>Location:</b>&#160;<xsl:value-of select="location"/><xsl:if test="state != ''">,&#160;<xsl:value-of select="state"/></xsl:if><br/>
    <b>Scope:</b>&#160;<xsl:value-of select="geoscope/areaName"/><br/>
    <b>Website:</b>&#160;<a href="{url/urlAddress}"><xsl:value-of select="url/urlName"/></a><br/>
  </p>
</xsl:template>

</xsl:stylesheet>
