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

		<xsl:variable name="pdpKeyOtherID" select="/SAREroot/pdpKeyOutOther/@pdp_key_otherID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutOther/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutOther/pdp_initnum"/>
		<xsl:variable name="OtherTitle" select="/SAREroot/pdpKeyOutOther/other_title"/>
		<xsl:variable name="OtherDescription" select="/SAREroot/pdpKeyOutOther/other_desc"/>
		<xsl:variable name="OtherNum" select="/SAREroot/pdpKeyOutOther/other_num"/>
		<xsl:variable name="OtherExt" select="/SAREroot/pdpKeyOutOther/other_ext"/>
		<xsl:variable name="OtherNRCS" select="/SAREroot/pdpKeyOutOther/other_nrcs"/>
		<xsl:variable name="OtherNGO" select="/SAREroot/pdpKeyOutOther/other_ngo"/>
		<xsl:variable name="OtherST" select="/SAREroot/pdpKeyOutOther/other_st"/>
		<xsl:variable name="OtherPro" select="/SAREroot/pdpKeyOutOther/other_pro"/>
		<xsl:variable name="OtherFarm" select="/SAREroot/pdpKeyOutOther/other_farm"/>
		<xsl:variable name="OtherOther" select="/SAREroot/pdpKeyOutOther/other_other"/>
		<xsl:variable name="OtherReciDesc" select="/SAREroot/pdpKeyOutOther/other_reci_desc"/>
		<xsl:variable name="OtherLoc" select="/SAREroot/pdpKeyOutOther/other_loc"/>
		<xsl:variable name="OtherState" select="/SAREroot/pdpKeyOutOther/other_state"/>
		<xsl:variable name="OtherZip" select="/SAREroot/pdpKeyOutOther/other_zip"/>
		<xsl:variable name="OtherMedia" select="/SAREroot/pdpKeyOutOther/other_media"/>
		<xsl:variable name="OtherClient" select="/SAREroot/pdpKeyOutOther/other_client"/>
		<xsl:variable name="OtherDevel" select="/SAREroot/pdpKeyOutOther/other_devel"/>
		<xsl:variable name="OtherIncorp" select="/SAREroot/pdpKeyOutOther/other_incorp"/>
		<xsl:variable name="OtherProg" select="/SAREroot/pdpKeyOutOther/other_prog"/>
		<xsl:variable name="OtherConsult" select="/SAREroot/pdpKeyOutOther/other_consult"/>
		<xsl:variable name="OtherFarmers" select="/SAREroot/pdpKeyOutOther/other_farmers"/>
		<xsl:variable name="OtherOutOther" select="/SAREroot/pdpKeyOutOther/other_out_other"/>
		<xsl:variable name="OtherOutDesc" select="/SAREroot/pdpKeyOutOther/other_out_desc"/>
		
		<p>
			<span class="pagetitle">Other Activities</span>
		</p>
		<p>
			Describe up to additional activities associated with this initiative and their related outcomes below.
		</p>
		<xsl:if test="$pdpKeyOtherID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyOtherID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutOther" name="pdpKeyOutOther" method="post">
			<table>
				<tr>
					<td>
						<!-- 
						<p>
							<strong>Description</strong>&#160;&#160;&#160;
							<textarea id="OtherDescription" name="OtherDescription" rows="5" cols="70">
								<xsl:value-of disable-output-escaping="yes" select="$OtherDescription"/>
							</textarea>
						</p>-->
						<div id="mdiv">
							<!--
							<h6>
								# of other : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" value="{$OtherNum}" name="OtherNum" size="6" maxLength="10"/>
							</h6> 
							-->
							<strong>Title:</strong><br/>
							<!-- 
							<textarea id="otherTitle" name="otherTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$OtherTitle"/> 
							</textarea>
							-->
							<input name="otherTitle" id="otherTitle" type="text" value="{$OtherTitle}" size="120" maxlength="255"/>
							<br/><br/>
							<strong>
								Start Date:&#160;<input name="OtherSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutOther/other_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutOther.OtherSDate', document.pdpKeyOutOther.OtherSDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="OtherEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutOther/other_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutOther.OtherEDate', document.pdpKeyOutOther.OtherEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								Location:&#160;<INPUT type="text" value="{$OtherLoc}" name="OtherLoc" size="20" maxLength="255"/>
								&#160;&#160;&#160;Location State:&#160;
								<select name="OtherState">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$OtherState"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
									</xsl:for-each>
								</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
								<INPUT onkeypress="return numbersonly(event,false)" name="OtherZip" value="{$OtherZip}" size="3" maxLength="5"/>
								<br/><small>(City, county or region of state)</small>
	  						</strong>
							<strong>
								<br/><br/>Recipients:<br/>
							</strong>
							<!-- 
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherExt}" name="OtherExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherNRCS}" name="OtherNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherNGO}" name="OtherNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherST}" name="OtherST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherFarm}" name="OtherFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherPro}" name="OtherPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$OtherOther}" name="OtherOther" size="1" maxLength="3"/>&#160;&#160;
							-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="OtherExt" onkeypress="return numbersonly(event,false)" value="{$OtherExt}" name="OtherExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="OtherNRCS" onkeypress="return numbersonly(event,false)" value="{$OtherNRCS}" name="OtherNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="OtherNGO" onkeypress="return numbersonly(event,false)" value="{$OtherNGO}" name="OtherNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="OtherST" onkeypress="return numbersonly(event,false)" value="{$OtherST}" name="OtherST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="OtherFarm" onkeypress="return numbersonly(event,false)" value="{$OtherFarm}" name="OtherFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="OtherPro" onkeypress="return numbersonly(event,false)" value="{$OtherPro}" name="OtherPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="OtherOther" onkeypress="return numbersonly(event,false)" value ="{$OtherOther}" name="OtherOther" size="1" maxLength="3" type="text"/>
							</div>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$OtherReciDesc}" name="OtherReciDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="OtherDescription" name="OtherDescription" rows="5" cols="70">
								<!-- <xsl:value-of disable-output-escaping="yes" select="$OtherDescription"/> -->
								<xsl:call-template name="break">
									<xsl:with-param name="text" select="$OtherDescription"/>
								</xsl:call-template>
							</textarea>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherMedia}" name="OtherMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherProg}" name="OtherProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherClient}" name="OtherClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherConsult}" name="OtherConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherDevel}" name="OtherDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherFarmers}" name="OtherFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherIncorp}" name="OtherIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$OtherOutOther}" name="OtherOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$OtherOutDesc}" name="OtherOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
							
						</div>
					</td>
				</tr>
				<!--
				<tr>
					<td>
						<p class="pagetitle">
							More Other(s)&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('modiv');">+/-</a>							
						</p>
						<div class="wrapper" id="modiv" style="display:none;margin-left:1em">
							<p>
								<strong>Description</strong>
								<br/>
								<textarea id="initOut" name="initOut" rows="5" cols="70">
								</textarea>
							</p>
							 
							<h6>
								# of other : &#160;&#160;&#160;<INPUT type="text" name="other1Session" size="6" maxLength="10"/>
							</h6>
							
							<h6>
								Location City:&#160;&#160;&#160;<INPUT type="text" name="OtherLoc" size="20" maxLength="255"/>&#160;&#160;&#160;&#160;&#160;&#160;
								&#160;&#160;&#160;Location State:&#160;&#160;&#160;
								<select name="OtherState">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$OtherState"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
									</xsl:for-each>
								</select>
							</h6>
							<h6>
								Recipients : &#160;&#160;&#160;								
							</h6>
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1Ext" size="1" maxLength="3"/>Extension&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1NRCS" size="1" maxLength="3"/>NRCS&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1NGO" size="1" maxLength="3"/>NGO&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1ST" size="1" maxLength="3"/>Agency*&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1Farm" size="1" maxLength="3"/>Farmer/Rancher&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1Pro" size="1" maxLength="3"/>For Profit&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="Other1Other" size="1" maxLength="3"/>Other&#160;&#160;
							<br/>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" name="OtherReciDesc" size="50" maxLength="50"/>

							<h6>
								Outcome(s):&#160;&#160;&#160;								
							</h6>
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherMedia1" size="1" maxLength="3"/>Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherIncorp1" size="1" maxLength="3"/>Incorporated new ideas or info into regular
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherClient1" size="1" maxLength="3"/>Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherProg1" size="1" maxLength="3"/>Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherDevel1" size="1" maxLength="3"/>Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherConsult1" size="1" maxLength="3"/>Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" name="OtherFarmers1" size="1" maxLength="3"/>Number of farmers reached&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT type="text" name="OtherOutOther1" size="1" maxLength="3"/>Other
							<br/><br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" name="OtherOutDesc1" size="50" maxLength="50"/>
							<br/><br/>
						</div>
					</td>
				</tr>

				<tr>
					<td colspan="2"/>&#160;&#160;&#160;
				</tr>
				-->				
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyOtherID != 0">
								<input name="cmdPdpKeyOutOtherUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
							<input name="cmdPdpKeyOutOtherDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
							<input type="hidden" name="DeleteID" value="{$pdpKeyOtherID}"/>
						</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutOtherSave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to update data on this page and return to the Initiative page.
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
