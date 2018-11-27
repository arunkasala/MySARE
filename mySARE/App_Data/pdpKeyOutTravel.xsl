<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

	<xsl:param name="message"/>
	<xsl:param name="message2"/>

	<xsl:template match="/">
	<script language="JavaScript" src="./ajax/ts_picker4.js"/>
	<script LANGUAGE="JavaScript">
		<![CDATA[
		
		function toggleDiv(divid)
		{
			if(document.getElementById(divid).style.display == 'none')
			{
				document.getElementById(divid).style.display = 'block';
			}
			else
			{
				document.getElementById(divid).style.display = 'none';
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
			   else
				  return false;
		}
		
		]]>
	</script>

	<script language="JavaScript" src="./tinymce/tinymce.min.js"/>
	<script type="text/javascript">
    tinymce.init({
    selector: "textarea",
    plugins: [
    "advlist lists charmap hr anchor pagebreak ",
    "paste nonbreaking"
    ],

    toolbar1: "bold italic underline | bullist numlist | outdent indent | removeformat | subscript superscript | charmap ",

    menubar: false,
    toolbar_items_size: 'small',
    statusbar : true,
    height: "100",
    width:570,
    force_p_newlines : false,
    force_br_newlines : false,
    forced_root_block : false,
    convert_newlines_to_brs: false,
    remove_linebreaks : true,
    paste_use_dialog: false,
    paste_auto_cleanup_on_paste : true
    });
  </script>
	
	<style type="text/css">

		div.wrapper
		{
		margin-bottom: 1em;
		width: 60em;
		}

		span.option
		{
		float: left;
		width: 20em;  /* accommodate the widest item */
		}

		/* stop the floating after the list */
		br
		{
		clear: left;
		}

		.boxed {
		border: 1px solid black ;
		width: 14em;
		margin: 4em;

		}

		.floatL {
		margin-right:10px; /*change to suit */
		display:block;
		width:80px; /*change to suit */
		float:left;
		line-height:1.5em; /*change to suit */
		}

	</style>

		<xsl:variable name="pdpKeyTravelID" select="/SAREroot/pdpKeyOutTravel/@pdp_key_travelID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutTravel/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutTravel/pdp_initNum"/>
		<xsl:variable name="TravelTitle" select="/SAREroot/pdpKeyOutTravel/travel_title"/>
		<xsl:variable name="TravelDescription" select="/SAREroot/pdpKeyOutTravel/travel_desc"/>
		<xsl:variable name="TravelScholar" select="/SAREroot/pdpKeyOutTravel/travel_scholarship"/>
		<xsl:variable name="TravelIndividual1" select="/SAREroot/pdpKeyOutTravel/travel_individual1"/>
		<xsl:variable name="TravelIndividual2" select="/SAREroot/pdpKeyOutTravel/travel_individual2"/>
		<xsl:variable name="TravelIndividual3" select="/SAREroot/pdpKeyOutTravel/travel_individual3"/>
		<xsl:variable name="TravelIndividual4" select="/SAREroot/pdpKeyOutTravel/travel_individual4"/>
		<xsl:variable name="TravelIndividual5" select="/SAREroot/pdpKeyOutTravel/travel_individual5"/>
		<xsl:variable name="TravelIndividual6" select="/SAREroot/pdpKeyOutTravel/travel_individual6"/>
		<xsl:variable name="TravelIndividual7" select="/SAREroot/pdpKeyOutTravel/travel_individual7"/>
		<xsl:variable name="TravelIndividual8" select="/SAREroot/pdpKeyOutTravel/travel_individual8"/>
		<xsl:variable name="TravelIndividual9" select="/SAREroot/pdpKeyOutTravel/travel_individual9"/>
		<xsl:variable name="TravelIndividual10" select="/SAREroot/pdpKeyOutTravel/travel_individual10"/>
		<xsl:variable name="TravelIndividual11" select="/SAREroot/pdpKeyOutTravel/travel_individual11"/>
		<xsl:variable name="TravelIndividual12" select="/SAREroot/pdpKeyOutTravel/travel_individual12"/>
		<xsl:variable name="TravelIndividualOther" select="/SAREroot/pdpKeyOutTravel/travel_individual_other"/>
		<xsl:variable name="TravelExt" select="/SAREroot/pdpKeyOutTravel/travel_ext"/>
		<xsl:variable name="TravelNRCS" select="/SAREroot/pdpKeyOutTravel/travel_nrcs"/>
		<xsl:variable name="TravelNGO" select="/SAREroot/pdpKeyOutTravel/travel_ngo"/>
		<xsl:variable name="TravelST" select="/SAREroot/pdpKeyOutTravel/travel_st"/>
		<xsl:variable name="TravelPro" select="/SAREroot/pdpKeyOutTravel/travel_pro"/>
		<xsl:variable name="TravelFarm" select="/SAREroot/pdpKeyOutTravel/travel_farm"/>
		<xsl:variable name="TravelOther" select="/SAREroot/pdpKeyOutTravel/travel_other"/>
		<xsl:variable name="TravelReciDesc" select="/SAREroot/pdpKeyOutTravel/travel_reci_desc"/>
		<xsl:variable name="TravelLoc" select="/SAREroot/pdpKeyOutTravel/travel_loc"/>
		<xsl:variable name="TravelState" select="/SAREroot/pdpKeyOutTravel/travel_state"/>
		<xsl:variable name="TravelZip" select="/SAREroot/pdpKeyOutTravel/travel_zip"/>
		<xsl:variable name="TravelMedia" select="/SAREroot/pdpKeyOutTravel/travel_media"/>
		<xsl:variable name="TravelClient" select="/SAREroot/pdpKeyOutTravel/travel_client"/>
		<xsl:variable name="TravelDevel" select="/SAREroot/pdpKeyOutTravel/travel_devel"/>
		<xsl:variable name="TravelIncorp" select="/SAREroot/pdpKeyOutTravel/travel_incorp"/>
		<xsl:variable name="TravelProg" select="/SAREroot/pdpKeyOutTravel/travel_prog"/>
		<xsl:variable name="TravelConsult" select="/SAREroot/pdpKeyOutTravel/travel_consult"/>
		<xsl:variable name="TravelFarmers" select="/SAREroot/pdpKeyOutTravel/travel_farmers"/>
		<xsl:variable name="TravelOutOther" select="/SAREroot/pdpKeyOutTravel/travel_out_other"/>
		<xsl:variable name="TravelOutDesc" select="/SAREroot/pdpKeyOutTravel/travel_out_desc"/>
		
		<p>
			<span class="pagetitle">Travel Scholarships</span>
		</p>
		<p>
			Enter the activities conducted and related outcomes for travel scholarships below:
		</p>
		<xsl:if test="$pdpKeyTravelID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyTravelID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutTravel" name="pdpKeyOutTravel" method="post">
			<table>
				<tr>
					<td>
						<!-- 
						<p>
							<strong>Description&#160;&#160;&#160;</strong>
							<textarea id="TravelDescription" name="TravelDescription" rows="5" cols="70">
								<xsl:value-of disable-output-escaping="yes" select="$TravelDescription"/>
							</textarea>
						</p>-->
						<div>
							<!--
							<h6>
								Scholarship awards&#160;&#160;&#160;
								<li>
									# of scholarships : &#160;&#160;&#160;<INPUT onkeypress="return numbersonly(event,false)" name="TravelScholar" value="{$TravelScholar}" size="6" maxLength="10"/>
								</li>
							</h6>
							-->
							<strong>Title:</strong><br/>
							<!--
							<textarea id="travelTitle" name="travelTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$TravelTitle"/> 
							</textarea>
							-->
							<input name="travelTitle" id="travelTitle" type="text" value="{$TravelTitle}" size="120" maxlength="255"/>
							<br/>
							<strong>
								Start Date:&#160;<input name="StudySDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutTravel/travel_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutTravel.StudySDate', document.pdpKeyOutTravel.StudySDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="StudyEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutTravel/travel_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutTravel.StudyEDate', document.pdpKeyOutTravel.StudyEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								Location:&#160;<INPUT type="text" value="{$TravelLoc}" name="TravelLoc" size="20" maxLength="255"/>
								&#160;&#160;&#160;Location State:&#160;
								<select name="travelState">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$TravelState"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
									</xsl:for-each>
								</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="TravelZip" value="{$TravelZip}" size="3" maxLength="5"/>
							<br/><small>(City, county or region of state)</small>
						  </strong>
							<h6>
								Individual(s) : &#160;&#160;&#160;
								<li>
									<INPUT type="text" name="TravelIndividual1" value="{$TravelIndividual1}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual7" value="{$TravelIndividual7}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>
								<li>
									<INPUT type="text" name="TravelIndividual2" value="{$TravelIndividual2}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual8" value="{$TravelIndividual8}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>
								<li>
									<INPUT type="text" name="TravelIndividual3" value="{$TravelIndividual3}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual9" value="{$TravelIndividual9}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>
								<li>
									<INPUT type="text" name="TravelIndividual4" value="{$TravelIndividual4}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual10" value="{$TravelIndividual10}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>
								<li>
									<INPUT type="text" name="TravelIndividual5" value="{$TravelIndividual5}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual11" value="{$TravelIndividual11}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>
								<li>
									<INPUT type="text" name="TravelIndividual6" value="{$TravelIndividual6}" placeholder="Last, First" size="30" maxLength="255"/>&#160;&#160;&#160; &#160;&#160;&#160;<INPUT type="text" name="TravelIndividual12" value="{$TravelIndividual12}" placeholder="Last, First" size="30" maxLength="255"/>
								</li>															
							</h6>
							<strong>
								<br/>Other:<br/>
							</strong>
							<INPUT type="text" name="TravelIndividualOther" value="{$TravelIndividualOther}" placeholder="Last, First" size="30" maxLength="255"/>
							
							<strong>
								<br/><br/>Recipients(s):<br/>
							</strong>
							<!-- 
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelExt}" name="TravelExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelNRCS}" name="TravelNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelNGO}" name="TravelNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelST}" name="TravelST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelFarm}" name="TravelFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelPro}" name="TravelPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$TravelOther}" name="TravelOther" size="1" maxLength="3"/>&#160;&#160;
							-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="TravelExt" onkeypress="return numbersonly(event,false)" value="{$TravelExt}" name="TravelExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="TravelNRCS" onkeypress="return numbersonly(event,false)" value="{$TravelNRCS}" name="TravelNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="TravelNGO" onkeypress="return numbersonly(event,false)" value="{$TravelNGO}" name="TravelNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="TravelST" onkeypress="return numbersonly(event,false)" value="{$TravelST}" name="TravelST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="TravelFarm" onkeypress="return numbersonly(event,false)" value="{$TravelFarm}" name="TravelFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="TravelPro" onkeypress="return numbersonly(event,false)" value="{$TravelPro}" name="TravelPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="TravelOther" onkeypress="return numbersonly(event,false)" value ="{$TravelOther}" name="TravelOther" size="1" maxLength="3" type="text"/>
							</div>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$TravelReciDesc}" name="TravelReciDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="TravelDescription" name="TravelDescription" style="width:100%">
								<!-- <xsl:value-of disable-output-escaping="yes" select="$TravelDescription"/> -->
								<xsl:call-template name="break">
									<xsl:with-param name="text" select="$TravelDescription"/>
								</xsl:call-template>
							</textarea>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelMedia}" name="TravelMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelProg}" name="TravelProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelClient}" name="TravelClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelConsult}" name="TravelConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelDevel}" name="TravelDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelFarmers}" name="TravelFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelIncorp}" name="TravelIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$TravelOutOther}" name="TravelOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$TravelOutDesc}" name="TravelOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
						</div>
					</td>
				</tr>
				
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyTravelID != 0">
								<input name="cmdPdpKeyOutTravelUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
								<input name="cmdPdpKeyOutTravelDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
								<input type="hidden" name="DeleteID" value="{$pdpKeyTravelID}"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutTravelSave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to update data on this page and return to the Initiative page.
						</xsl:otherwise>
						</xsl:choose>
						<br/>
						<br/>
						<xsl:if test="$initNum != 0">
							<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=pdpinit&amp;pn={$projNum}&amp;initNum={$initNum}'"/>&#160;&#160;&#160;
							Click “Cancel” to return to the Initiative page without saving data on this page.
						</xsl:if>
						<xsl:if test="$initNum = 0">
							<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=pdpinit&amp;pn={$projNum}'"/>&#160;&#160;&#160;
							Click “Cancel” to return to the Initiative page without saving data on this page.
						</xsl:if>
					</td>

				</tr>

				<tr>
					<td>
						<input name="Back To Overview" onclick ="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'" type="button" value="Back To Overview"/>
					</td>
				</tr>

			</table>
		</form>

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
	<xsl:template name="break">
		<xsl:param name="text"/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<br/>
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>
