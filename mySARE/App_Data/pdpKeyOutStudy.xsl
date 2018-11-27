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

		<xsl:variable name="pdpKeyStudyID" select="/SAREroot/pdpKeyOutStudy/@pdp_key_studyID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutStudy/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutStudy/pdp_initNum"/>
		<xsl:variable name="StudySess" select="/SAREroot/pdpKeyOutStudy/study_session"/>
		<xsl:variable name="StudyTitle" select="/SAREroot/pdpKeyOutStudy/study_title"/>
		<xsl:variable name="StudyExt" select="/SAREroot/pdpKeyOutStudy/study_ext"/>
		<xsl:variable name="StudyNRCS" select="/SAREroot/pdpKeyOutStudy/study_nrcs"/>
		<xsl:variable name="StudyNGO" select="/SAREroot/pdpKeyOutStudy/study_ngo"/>
		<xsl:variable name="StudyST" select="/SAREroot/pdpKeyOutStudy/study_st"/>
		<xsl:variable name="StudyPro" select="/SAREroot/pdpKeyOutStudy/study_pro"/>
		<xsl:variable name="StudyFarm" select="/SAREroot/pdpKeyOutStudy/study_farm"/>
		<xsl:variable name="StudyAttOther" select="/SAREroot/pdpKeyOutStudy/study_att_other"/>
		<xsl:variable name="StudyAttDesc" select="/SAREroot/pdpKeyOutStudy/study_att_desc"/>
		<xsl:variable name="StudyLoc" select="/SAREroot/pdpKeyOutStudy/study_loc"/>
		<xsl:variable name="StudyState" select="/SAREroot/pdpKeyOutStudy/study_state"/>
		<xsl:variable name="StudyZip" select="/SAREroot/pdpKeyOutStudy/study_zip"/>
		<xsl:variable name="StudyMedia" select="/SAREroot/pdpKeyOutStudy/study_media"/>
		<xsl:variable name="StudyClient" select="/SAREroot/pdpKeyOutStudy/study_client"/>
		<xsl:variable name="StudyDevel" select="/SAREroot/pdpKeyOutStudy/study_devel"/>
		<xsl:variable name="StudyIncorp" select="/SAREroot/pdpKeyOutStudy/study_incorp"/>
		<xsl:variable name="StudyProg" select="/SAREroot/pdpKeyOutStudy/study_prog"/>
		<xsl:variable name="StudyConsult" select="/SAREroot/pdpKeyOutStudy/study_consult"/>
		<xsl:variable name="StudyFarmers" select="/SAREroot/pdpKeyOutStudy/study_farmers"/>
		<xsl:variable name="StudyOutOther" select="/SAREroot/pdpKeyOutStudy/study_out_other"/>
		<xsl:variable name="StudyOutDesc" select="/SAREroot/pdpKeyOutStudy/study_out_desc"/>
		<xsl:variable name="StudyDescription" select="/SAREroot/pdpKeyOutStudy/study_description"/>
		
		<p>
			<span class="pagetitle">Study Circle/Focus Group</span>
		</p>
		<p>
			Enter the activities conducted and related outcomes for study circles below:
		</p>
		<xsl:if test="$pdpKeyStudyID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyStudyID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutStudy" name="pdpKeyOutStudy" method="post">
			<table>				
				<tr>
					<td>
						<div>
							<!-- 
							<h6>
								# of study circles : &#160;&#160;&#160;<INPUT readonly="readonly" disabled="disabled" name="studySession" value="{$StudySess}" size="6" maxLength="10"/>
							</h6>
							-->
							<strong>Title:</strong><br/>
							<!-- 
							<textarea id="studyTitle" name="studyTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$StudyTitle"/>
							</textarea>
							-->
							<input name="studyTitle" id="studyTitle" type="text" value="{$StudyTitle}" size="120" maxlength="255"/>
							<br/>
							<strong>
								Start Date:&#160;<input name="StudySDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutStudy/study_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutStudy.StudySDate', document.pdpKeyOutStudy.StudySDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="StudyEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutStudy/study_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutStudy.StudyEDate', document.pdpKeyOutStudy.StudyEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								Location:&#160;<INPUT type="text" value="{$StudyLoc}" name="studyLoc" size="20" maxLength="255"/>
								&#160;&#160;&#160;Location State:&#160;
								<select name="studyState">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
										<xsl:call-template name="option">
											<xsl:with-param name="selected"><xsl:value-of select="$StudyState"/></xsl:with-param>
											<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
											<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
										</xsl:call-template>
									</xsl:for-each>
								</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
								<INPUT onkeypress="return numbersonly(event,false)" name="studyZip" value="{$StudyZip}" size="3" maxLength="5"/>
								<br/><small>(City, county or region of state)</small>
							</strong>
							<strong>
								<br/><br/>Attendance:<br/>
							</strong>
							<!-- 
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyExt}" name="StudyExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyNRCS}" name="StudyNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyNGO}" name="StudyNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyST}" name="StudyST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyFarm}" name="StudyFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyPro}" name="StudyPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$StudyAttOther}" name="StudyAttOther" size="1" maxLength="3"/>&#160;&#160;
							-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="StudyExt" onkeypress="return numbersonly(event,false)" value="{$StudyExt}" name="StudyExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="StudyNRCS" onkeypress="return numbersonly(event,false)" value="{$StudyNRCS}" name="StudyNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="StudyNGO" onkeypress="return numbersonly(event,false)" value="{$StudyNGO}" name="StudyNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="StudyST" onkeypress="return numbersonly(event,false)" value="{$StudyST}" name="StudyST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="StudyFarm" onkeypress="return numbersonly(event,false)" value="{$StudyFarm}" name="StudyFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="StudyPro" onkeypress="return numbersonly(event,false)" value="{$StudyPro}" name="StudyPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="StudyAttOther" onkeypress="return numbersonly(event,false)" value ="{$StudyAttOther}" name="StudyAttOther" size="1" maxLength="3" type="text"/>
							</div>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$StudyAttDesc}" name="StudyAttDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="studyDescription" name="studyDescription" style="width:100%">
								<!-- <xsl:value-of disable-output-escaping="yes" select="$StudyDescription"/> -->
								<xsl:call-template name="break">
									<xsl:with-param name="text" select="$StudyDescription"/>
								</xsl:call-template>
							</textarea>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyMedia}" name="StudyMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyProg}" name="StudyProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyClient}" name="StudyClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyConsult}" name="StudyConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyDevel}" name="StudyDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyFarmers}" name="StudyFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyIncorp}" name="StudyIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$StudyOutOther}" name="StudyOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$StudyOutDesc}" name="StudyOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
						</div>
					</td>
				</tr>
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyStudyID != 0">
								<input name="cmdPdpKeyOutStudyUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
							<input name="cmdPdpKeyOutStudyDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
							<input type="hidden" name="DeleteID" value="{$pdpKeyStudyID}"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutStudySave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to save new data on this page and return to the Initiative page.
							</xsl:otherwise>
						</xsl:choose>
						<br/><br/>
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
