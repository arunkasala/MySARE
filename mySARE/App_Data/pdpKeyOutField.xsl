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

		<xsl:variable name="pdpKeyFieldID" select="/SAREroot/pdpKeyOutField/@pdp_key_fieldID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutField/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutField/pdp_initNum"/>
		<xsl:variable name="InterTitle" select="/SAREroot/pdpKeyOutField/inter_title"/>
		<xsl:variable name="InterExt" select="/SAREroot/pdpKeyOutField/inter_ext"/>
		<xsl:variable name="InterNRCS" select="/SAREroot/pdpKeyOutField/inter_nrcs"/>
		<xsl:variable name="InterNGO" select="/SAREroot/pdpKeyOutField/inter_ngo"/>
		<xsl:variable name="InterST" select="/SAREroot/pdpKeyOutField/inter_st"/>
		<xsl:variable name="InterPro" select="/SAREroot/pdpKeyOutField/inter_pro"/>
		<xsl:variable name="InterFarm" select="/SAREroot/pdpKeyOutField/inter_farm"/>
		<xsl:variable name="InterAttOther" select="/SAREroot/pdpKeyOutField/inter_att_other"/>
		<xsl:variable name="InterAttDesc" select="/SAREroot/pdpKeyOutField/inter_att_desc"/>
		<xsl:variable name="InterLoc" select="/SAREroot/pdpKeyOutField/inter_loc"/>
		<xsl:variable name="InterState" select="/SAREroot/pdpKeyOutField/inter_state"/>
		<xsl:variable name="InterZip" select="/SAREroot/pdpKeyOutField/inter_zip"/>
		<xsl:variable name="InterMedia" select="/SAREroot/pdpKeyOutField/inter_media"/>
		<xsl:variable name="InterClient" select="/SAREroot/pdpKeyOutField/inter_client"/>
		<xsl:variable name="InterDevel" select="/SAREroot/pdpKeyOutField/inter_devel"/>
		<xsl:variable name="InterIncorp" select="/SAREroot/pdpKeyOutField/inter_incorp"/>
		<xsl:variable name="InterProg" select="/SAREroot/pdpKeyOutField/inter_prog"/>
		<xsl:variable name="InterConsult" select="/SAREroot/pdpKeyOutField/inter_consult"/>
		<xsl:variable name="InterFarmers" select="/SAREroot/pdpKeyOutField/inter_farmers"/>
		<xsl:variable name="InterOutOther" select="/SAREroot/pdpKeyOutField/inter_out_other"/>
		<xsl:variable name="InterOutDesc" select="/SAREroot/pdpKeyOutField/inter_out_desc"/>
		<xsl:variable name="InterDescription" select="/SAREroot/pdpKeyOutField/inter_description"/>
		<xsl:variable name="MultiSess" select="/SAREroot/pdpKeyOutField/multi_session"/>
		<xsl:variable name="MultiTitle" select="/SAREroot/pdpKeyOutField/multi_title"/>
		<xsl:variable name="MultiExt" select="/SAREroot/pdpKeyOutField/multi_ext"/>
		<xsl:variable name="MultiNRCS" select="/SAREroot/pdpKeyOutField/multi_nrcs"/>
		<xsl:variable name="MultiNGO" select="/SAREroot/pdpKeyOutField/multi_ngo"/>
		<xsl:variable name="MultiST" select="/SAREroot/pdpKeyOutField/multi_st"/>
		<xsl:variable name="MultiPro" select="/SAREroot/pdpKeyOutField/multi_pro"/>
		<xsl:variable name="MultiFarm" select="/SAREroot/pdpKeyOutField/multi_farm"/>
		<xsl:variable name="MultiAttOther" select="/SAREroot/pdpKeyOutField/multi_att_other"/>
		<xsl:variable name="MultiAttDesc" select="/SAREroot/pdpKeyOutField/multi_att_desc"/>
		<xsl:variable name="MultiLoc" select="/SAREroot/pdpKeyOutField/multi_loc"/>
		<xsl:variable name="MultiState" select="/SAREroot/pdpKeyOutField/multi_state"/>
		<xsl:variable name="MultiZip" select="/SAREroot/pdpKeyOutField/multi_zip"/>
		<xsl:variable name="MultiMedia" select="/SAREroot/pdpKeyOutField/multi_media"/>
		<xsl:variable name="MultiClient" select="/SAREroot/pdpKeyOutField/multi_client"/>
		<xsl:variable name="MultiDevel" select="/SAREroot/pdpKeyOutField/multi_devel"/>
		<xsl:variable name="MultiIncorp" select="/SAREroot/pdpKeyOutField/multi_incorp"/>
		<xsl:variable name="MultiProg" select="/SAREroot/pdpKeyOutField/multi_prog"/>
		<xsl:variable name="MultiConsult" select="/SAREroot/pdpKeyOutField/multi_consult"/>
		<xsl:variable name="MultiFarmers" select="/SAREroot/pdpKeyOutField/multi_farmers"/>
		<xsl:variable name="MultiOutOther" select="/SAREroot/pdpKeyOutField/multi_out_other"/>
		<xsl:variable name="MultiOutDesc" select="/SAREroot/pdpKeyOutField/multi_out_desc"/>
		<xsl:variable name="MultiDescription" select="/SAREroot/pdpKeyOutField/multi_description"/>
		<xsl:variable name="ExtendSess" select="/SAREroot/pdpKeyOutField/extend_session"/>
		<xsl:variable name="ExtendTitle" select="/SAREroot/pdpKeyOutField/extend_title"/>
		<xsl:variable name="ExtendExt" select="/SAREroot/pdpKeyOutField/extend_ext"/>
		<xsl:variable name="ExtendNRCS" select="/SAREroot/pdpKeyOutField/extend_nrcs"/>
		<xsl:variable name="ExtendNGO" select="/SAREroot/pdpKeyOutField/extend_ngo"/>
		<xsl:variable name="ExtendST" select="/SAREroot/pdpKeyOutField/extend_st"/>
		<xsl:variable name="ExtendPro" select="/SAREroot/pdpKeyOutField/extend_pro"/>
		<xsl:variable name="ExtendFarm" select="/SAREroot/pdpKeyOutField/extend_farm"/>
		<xsl:variable name="ExtendAttOther" select="/SAREroot/pdpKeyOutField/extend_att_other"/>
		<xsl:variable name="ExtendAttDesc" select="/SAREroot/pdpKeyOutField/extend_att_desc"/>
		<xsl:variable name="ExtendLoc" select="/SAREroot/pdpKeyOutField/extend_loc"/>
		<xsl:variable name="ExtendState" select="/SAREroot/pdpKeyOutField/extend_state"/>
		<xsl:variable name="ExtendZip" select="/SAREroot/pdpKeyOutField/extend_zip"/>
		<xsl:variable name="ExtendMedia" select="/SAREroot/pdpKeyOutField/extend_media"/>
		<xsl:variable name="ExtendClient" select="/SAREroot/pdpKeyOutField/extend_client"/>
		<xsl:variable name="ExtendDevel" select="/SAREroot/pdpKeyOutField/extend_devel"/>
		<xsl:variable name="ExtendIncorp" select="/SAREroot/pdpKeyOutField/extend_incorp"/>
		<xsl:variable name="ExtendProg" select="/SAREroot/pdpKeyOutField/extend_prog"/>
		<xsl:variable name="ExtendConsult" select="/SAREroot/pdpKeyOutField/extend_consult"/>
		<xsl:variable name="ExtendFarmers" select="/SAREroot/pdpKeyOutField/extend_farmers"/>
		<xsl:variable name="ExtendOutOther" select="/SAREroot/pdpKeyOutField/extend_out_other"/>
		<xsl:variable name="ExtendOutDesc" select="/SAREroot/pdpKeyOutField/extend_out_desc"/>
		<xsl:variable name="ExtendDescription" select="/SAREroot/pdpKeyOutField/extend_description"/>
		
		<p>
			<span class="pagetitle">Field Days/Tour</span>
		</p>
		<p>
			Enter the activities conducted and related outcomes for field days and farm tours below:
		</p>
		<xsl:if test="$pdpKeyFieldID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyFieldID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutField" name="pdpKeyOutField" method="post">
			<table>
				<tr>
					<td>
						<p>
							<strong>1) Single Field Day/Tour</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('idiv');">+/-</a>&#160;&#160;<xsl:value-of select="$InterTitle"/> 
						</p>
						<div class="wrapper" id="idiv" style="display:none;margin-left:1em">
						<!-- 
							<h6>
								# of workshops/sessions/etc : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" name="interSession" value="{$InterSess}" size="6" maxLength="10"/>
							</h6>
							-->
						<strong>Title:</strong><br/>
						<!-- 
						<textarea id="interTitle" name="interTitle" rows="2" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$InterTitle"/> 
						</textarea>
						-->
						<input name="interTitle" id="interTitle" type="text" value="{$InterTitle}" size="120" maxlength="255"/>
						<br/>
						<strong>
							Start Date:&#160;<input name="InterSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/inter_start_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutField.InterSDate', document.pdpKeyOutField.InterSDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							End Date (Optional):&#160;<input name="InterEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/inter_end_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutField.InterEDate', document.pdpKeyOutField.InterEDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						</strong>
						<br/>
						<br/>
						<strong>
							Location:&#160;<INPUT type="text" value="{$InterLoc}" name="interLoc" size="20" maxLength="255"/>
							&#160;&#160;&#160;State:&#160;
							<select name="interState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
											<xsl:call-template name="option">
												<xsl:with-param name="selected"><xsl:value-of select="$InterState"/></xsl:with-param>
												<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
												<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
											</xsl:call-template>
										</xsl:for-each>
							</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="interZip" value="{$InterZip}" size="3" maxLength="5" onBlur="validZip(interZip.value)"/>
							<br/><small>(City, county or region of state)</small>
						</strong>
						<strong>
							<br/><br/>Attendance:
						</strong><br/>
						<!-- 
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterExt}" name="InterExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterNRCS}" name="InterNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterNGO}" name="InterNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterST}" name="InterST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterFarm}" name="InterFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterPro}" name="InterPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$InterAttOther}" name="InterAttOther" size="1" maxLength="3"/>&#160;&#160;
						-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="InterExt" onkeypress="return numbersonly(event,false)" value="{$InterExt}" name="InterExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="InterNRCS" onkeypress="return numbersonly(event,false)" value="{$InterNRCS}" name="InterNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="InterNGO" onkeypress="return numbersonly(event,false)" value="{$InterNGO}" name="InterNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="InterST" onkeypress="return numbersonly(event,false)" value="{$InterST}" name="InterST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="InterFarm" onkeypress="return numbersonly(event,false)" value="{$InterFarm}" name="InterFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="InterPro" onkeypress="return numbersonly(event,false)" value="{$InterPro}" name="InterPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="InterAttOther" onkeypress="return numbersonly(event,false)" value ="{$InterAttOther}" name="InterAttOther" size="1" maxLength="3" type="text"/>
							</div>
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$InterAttDesc}" name="InterAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="interDescription" name="interDescription" sytle="width:100%">
							<!-- <xsl:value-of disable-output-escaping="yes" select="$InterDescription"/> -->
							<xsl:call-template name="break">
								<xsl:with-param name="text" select="$InterDescription"/>
							</xsl:call-template>
						</textarea>
						<strong>
							<br/><br/>Action Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterMedia}" name="InterMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterProg}" name="InterProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area

						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterClient}" name="InterClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterConsult}" name="InterConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterDevel}" name="InterDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterFarmers}" name="InterFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterIncorp}" name="InterIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$InterOutOther}" name="InterOutOther" size="1" maxLength="3"/>&#160;Other
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$InterOutDesc}" name="InterOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
						</div>
					</td>
				</tr>

				<tr>
					<td>
						<p>
							<strong>2) Multiday Field Day/Tour (>1 day)</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('mdiv');">+/-</a>&#160;&#160;<xsl:value-of select="$MultiTitle"/>
						</p>
						<div class="wrapper" id="mdiv" style="display:none;margin-left:1em">
							<!--<h6>
								# of workshops/sessions/etc : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" name="multiSession" value="{$MultiSess}" size="6" maxLength="10"/>
							</h6>
						-->
						<strong>Title:</strong><br/>
						<!-- 
						<textarea id="multiTitle" name="multiTitle" rows="2" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$MultiTitle"/> 
						</textarea>
						-->
						<input name="multiTitle" id="multiTitle" type="text" value="{$MultiTitle}" size="120" maxlength="255"/>
						<br/>
						<strong>
							Start Date:&#160;<input name="MultiSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/multi_start_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutField.MultiSDate', document.pdpKeyOutField.MultiSDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							End Date (Optional):&#160;<input name="MultiEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/multi_end_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutField.MultiEDate', document.pdpKeyOutField.MultiEDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						</strong>
						<br/>
						<br/>
						<strong>
							Location:&#160;<INPUT type="text" value="{$MultiLoc}" name="multiLoc" size="20" maxLength="255"/>
							&#160;&#160;&#160;Location State:&#160;
							<select name="multiState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
												<xsl:call-template name="option">
													<xsl:with-param name="selected"><xsl:value-of select="$MultiState"/></xsl:with-param>
													<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
													<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
												</xsl:call-template>
											</xsl:for-each>
							</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
						<INPUT onkeypress="return numbersonly(event,false)" name="multiZip" value="{$MultiZip}" size="3" maxLength="5"/>
						<br/><small>(City, county or region of state)</small>
						</strong>
						<strong>
							<br/><br/>Attendance:<br/>
						</strong>
							<!-- 
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiExt}" name="MultiExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiNRCS}" name="MultiNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiNGO}" name="MultiNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiST}" name="MultiST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiFarm}" name="MultiFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiPro}" name="MultiPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$MultiAttOther}" name="MultiAttOther" size="1" maxLength="3"/>&#160;&#160;
						-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="MultiExt" onkeypress="return numbersonly(event,false)" value="{$MultiExt}" name="MultiExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="MultiNRCS" onkeypress="return numbersonly(event,false)" value="{$MultiNRCS}" name="MultiNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="MultiNGO" onkeypress="return numbersonly(event,false)" value="{$MultiNGO}" name="MultiNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="MultiST" onkeypress="return numbersonly(event,false)" value="{$MultiST}" name="MultiST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="MultiFarm" onkeypress="return numbersonly(event,false)" value="{$MultiFarm}" name="MultiFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="MultiPro" onkeypress="return numbersonly(event,false)" value="{$MultiPro}" name="MultiPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="MultiAttOther" onkeypress="return numbersonly(event,false)" value ="{$MultiAttOther}" name="MultiAttOther" size="1" maxLength="3" type="text"/>
							</div>
							<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$MultiAttDesc}" name="MultiAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="multiDescription" name="multiDescription" style="width:100%">
							<!-- <xsl:value-of disable-output-escaping="yes" select="$MultiDescription"/> -->
							<xsl:call-template name="break">
								<xsl:with-param name="text" select="$MultiDescription"/>
							</xsl:call-template>
						</textarea>
						<strong>
							<br/><br/>Action Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiMedia}" name="MultiMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiProg}" name="MultiProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area

						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiClient}" name="MultiClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiConsult}" name="MultiConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiDevel}" name="MultiDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiFarmers}" name="MultiFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiIncorp}" name="MultiIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$MultiOutOther}" name="MultiOutOther" size="1" maxLength="3"/>&#160;Other
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$MultiOutDesc}" name="MultiOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
					</div>
				</td>
			</tr>

			<tr>
				<td>
					<p>
						<strong>3) Multiday Field Day/Tour Over an Extended Period of Time</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('mmdiv');">+/-</a>&#160;&#160;<xsl:value-of select="$ExtendTitle"/>
					</p>
					 <div class="wrapper" id="mmdiv" style="display:none;margin-left:1em">
						<!--<h6>
							# of workshops/sessions/etc : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" name="extendSession" value="{$ExtendSess}" size="6" maxLength="10"/>
						</h6>
						-->
					<strong>Title:</strong><br/>
					<!-- 
					<textarea id="extendTitle" name="extendTitle" rows="2" cols="80">
						<xsl:value-of disable-output-escaping="yes" select="$ExtendTitle"/> 
					</textarea>
					-->
					<input name="extendTitle" id="extendTitle" type="text" value="{$ExtendTitle}" size="120" maxlength="255"/>
					<br/>
					<strong>
						Start Date:&#160;<input name="ExtendSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/extend_start_date}"/>
						<a href="javascript:show_calendar4('document.pdpKeyOutField.ExtendSDate', document.pdpKeyOutField.ExtendSDate.value);">
							&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						End Date (Optional):&#160;<input name="ExtendEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutField/extend_end_date}"/>
						<a href="javascript:show_calendar4('document.pdpKeyOutField.ExtendEDate', document.pdpKeyOutField.ExtendEDate.value);">
							&#160;
							<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
						</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					</strong>
					<br/>
					<br/>
					<strong>
						Location:&#160;<INPUT type="text" value="{$ExtendLoc}" name="extendLoc" size="20" maxLength="255"/>
						&#160;&#160;&#160;Location State:&#160;
						<select name="extendState">
							<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
												<xsl:call-template name="option">
													<xsl:with-param name="selected"><xsl:value-of select="$ExtendState"/></xsl:with-param>
													<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
													<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
												</xsl:call-template>
											</xsl:for-each>
						</select>
						&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
						<INPUT onkeypress="return numbersonly(event,false)" name="extendZip" value="{$ExtendZip}" size="3" maxLength="5"/>
						<br/><small>(City, county or region of state)</small>
					</strong>
					<strong>
						<br/><br/>Attendance:<br/>
					</strong>
						 <!--
					Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendExt}" name="ExtendExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendNRCS}" name="ExtendNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendNGO}" name="ExtendNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendST}" name="ExtendST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendFarm}" name="ExtendFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendPro}" name="ExtendPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value ="{$ExtendAttOther}" name="ExtendAttOther" size="1" maxLength="3"/>&#160;&#160;
					 -->
						 <div class="floatL">
							 <span>Extension</span>
							 <br />
							 <input id="ExtendExt" onkeypress="return numbersonly(event,false)" value="{$ExtendExt}" name="ExtendExt" size="1" maxLength="3" type="text"/>
						 </div>
						 <div class="floatL">
							 <span>NRCS</span>
							 <br />
							 <input id="ExtendNRCS" onkeypress="return numbersonly(event,false)" value="{$ExtendNRCS}" name="ExtendNRCS" size="1" maxLength="3" type="text"/>
						 </div>
						 <div class="floatL">
							 <span>NGO</span>
							 <br />
							 <input id="ExtendNGO" onkeypress="return numbersonly(event,false)" value="{$ExtendNGO}" name="ExtendNGO" size="1" maxLength="3" type="text" />
						 </div>
						 <div class="floatL">
							 <span>Agency*</span>
							 <br />
							 <input id="ExtendST" onkeypress="return numbersonly(event,false)" value="{$ExtendST}" name="ExtendST" size="1" maxLength="3" type="text" />
						 </div>
						 <div class="floatL">
							 <span>Farmer/Rancher</span>
							 <br />
							 <input id="ExtendFarm" onkeypress="return numbersonly(event,false)" value="{$ExtendFarm}" name="ExtendFarm" size="1" maxLength="3" type="text"/>
						 </div>
						 <div class="floatL">
							 <span>For Profit</span>
							 <br />
							 <input id="ExtendPro" onkeypress="return numbersonly(event,false)" value="{$ExtendPro}" name="ExtendPro" size="1" maxLength="3" type="text"/>
						 </div>
						 <div class="floatL">
							 <span>Other</span>
							 <br />
							 <input id="ExtendAttOther" onkeypress="return numbersonly(event,false)" value ="{$ExtendAttOther}" name="ExtendAttOther" size="1" maxLength="3" type="text"/>
						 </div>
						 <br/>
					If you entered "Other" please describe :&#160;<INPUT type="text" value="{$ExtendAttDesc}" name="ExtendAttDesc" size="50" maxLength="50"/>
					<br/><small>* State, federal, or tribal agency</small>
					<br/><br/>
					<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="extendDescription" name="extendDescription" style="width:100%">
							<!-- <xsl:value-of disable-output-escaping="yes" select="$ExtendDescription"/> -->
							<xsl:call-template name="break">
								<xsl:with-param name="text" select="$ExtendDescription"/>
							</xsl:call-template>
						</textarea>
					<strong>
						<br/><br/>Action Outcome(s):<br/>
					</strong>
					<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendMedia}" name="ExtendMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendProg}" name="ExtendProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area

					<br/>
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendClient}" name="ExtendClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendConsult}" name="ExtendConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<br/>
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendDevel}" name="ExtendDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendFarmers}" name="ExtendFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
					<br/>
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendIncorp}" name="ExtendIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
					<INPUT onkeypress="return numbersonly(event,false)" value="{$ExtendOutOther}" name="ExtendOutOther" size="1" maxLength="3"/>&#160;Other
					<br/>
					&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
					<br/>
					If you entered "Other" please describe :&#160;<INPUT type="text" value="{$ExtendOutDesc}" name="ExtendOutDesc" size="50" maxLength="50"/>
					<br/><br/><br/>
						</div>
					</td>
				</tr>
				
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyFieldID != 0">
								<input name="cmdPdpKeyOutFieldUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
							<input name="cmdPdpKeyOutFieldDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
							<input type="hidden" name="DeleteID" value="{$pdpKeyFieldID}"/>
						</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutFieldSave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to update data on this page and return to the Initiative page.
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
