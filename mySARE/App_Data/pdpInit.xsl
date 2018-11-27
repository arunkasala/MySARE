<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">	
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">

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

	</style>

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
	
	<xsl:variable name="pdpinitID" select="/SAREroot/pdpInitPartners/@pdp_init_id"/>
	<xsl:variable name="projNum" select="/SAREroot/pdpInitPartners/@proj_num"/>
	<xsl:variable name="initOut" select="/SAREroot/pdpInitPartners/sare_outreach"/>
	<xsl:variable name="initDesc" select="/SAREroot/pdpInitPartners/init_topic"/>
	<xsl:variable name="initObj" select="/SAREroot/pdpInitPartners/training_obj"/>
	<xsl:variable name="partExt" select="/SAREroot/pdpInitPartners/part_ext"/>
	<xsl:variable name="partNRCS" select="/SAREroot/pdpInitPartners/part_nrcs"/>
	<xsl:variable name="partNGO" select="/SAREroot/pdpInitPartners/part_ngo"/>
	<xsl:variable name="partState" select="/SAREroot/pdpInitPartners/part_state"/>
	<xsl:variable name="partFarmer" select="/SAREroot/pdpInitPartners/part_farmer"/>
	<xsl:variable name="partOther" select="/SAREroot/pdpInitPartners/part_other"/>
	<xsl:variable name="trainExt" select="/SAREroot/pdpInitPartners/train_ext"/>
	<xsl:variable name="trainNRCS" select="/SAREroot/pdpInitPartners/train_nrcs"/>
	<xsl:variable name="trainNGO" select="/SAREroot/pdpInitPartners/train_ngo"/>
	<xsl:variable name="trainState" select="/SAREroot/pdpInitPartners/train_state"/>
	<xsl:variable name="trainFarmer" select="/SAREroot/pdpInitPartners/train_farmer"/>
	<xsl:variable name="trainOther" select="/SAREroot/pdpInitPartners/train_other"/>
	<xsl:variable name="devExt" select="/SAREroot/pdpInitPartners/dev_ext"/>
	<xsl:variable name="devNRCS" select="/SAREroot/pdpInitPartners/dev_nrcs"/>
	<xsl:variable name="devNGO" select="/SAREroot/pdpInitPartners/dev_ngo"/>
	<xsl:variable name="devState" select="/SAREroot/pdpInitPartners/dev_state"/>
	<xsl:variable name="devFarmer" select="/SAREroot/pdpInitPartners/dev_farmer"/>
	<xsl:variable name="devOther" select="/SAREroot/pdpInitPartners/dev_other"/>
	<xsl:variable name="invExt" select="/SAREroot/pdpInitPartners/inv_ext"/>
	<xsl:variable name="invNRCS" select="/SAREroot/pdpInitPartners/inv_nrcs"/>
	<xsl:variable name="invNGO" select="/SAREroot/pdpInitPartners/inv_ngo"/>
	<xsl:variable name="invState" select="/SAREroot/pdpInitPartners/inv_state"/>
	<xsl:variable name="invFarmer" select="/SAREroot/pdpInitPartners/inv_farmer"/>
	<xsl:variable name="invOther" select="/SAREroot/pdpInitPartners/inv_other"/>
	<xsl:variable name="initiativeNum" select="/SAREroot/pdpInitPartners/initiative_num"/>
	<xsl:variable name="studySessionNum" select="/SAREroot/pdpInitPartners/@key_out_study_sessions"/>
	<xsl:variable name="studyTitles1" select="/SAREroot/pdpInitPartners/@key_out_study_title1"/>
	<xsl:variable name="studyTitles2" select="/SAREroot/pdpInitPartners/@key_out_study_title2"/>
	<xsl:variable name="studyTitles3" select="/SAREroot/pdpInitPartners/@key_out_study_title3"/>
	<xsl:variable name="studyTitles4" select="/SAREroot/pdpInitPartners/@key_out_study_title4"/>
	<xsl:variable name="studyTitles5" select="/SAREroot/pdpInitPartners/@key_out_study_title5"/>
	<xsl:variable name="studyTitles6" select="/SAREroot/pdpInitPartners/@key_out_study_title6"/>
	<xsl:variable name="workSessionNum" select="/SAREroot/pdpInitPartners/@key_out_work_sessions"/>
	<xsl:variable name="workTitles1" select="/SAREroot/pdpInitPartners/@key_out_work_titles1"/>
	<xsl:variable name="workTitles2" select="/SAREroot/pdpInitPartners/@key_out_work_titles2"/>
	<xsl:variable name="workTitles3" select="/SAREroot/pdpInitPartners/@key_out_work_titles3"/>
	<xsl:variable name="workTitles4" select="/SAREroot/pdpInitPartners/@key_out_work_titles4"/>
	<xsl:variable name="workTitles5" select="/SAREroot/pdpInitPartners/@key_out_work_titles5"/>
	<xsl:variable name="workTitles6" select="/SAREroot/pdpInitPartners/@key_out_work_titles6"/>
	<xsl:variable name="fieldSessionNum" select="/SAREroot/pdpInitPartners/@key_out_field_sessions"/>
	<xsl:variable name="fieldTitles1" select="/SAREroot/pdpInitPartners/@key_out_field_titles1"/>
	<xsl:variable name="fieldTitles2" select="/SAREroot/pdpInitPartners/@key_out_field_titles2"/>
	<xsl:variable name="fieldTitles3" select="/SAREroot/pdpInitPartners/@key_out_field_titles3"/>
	<xsl:variable name="fieldTitles4" select="/SAREroot/pdpInitPartners/@key_out_field_titles4"/>
	<xsl:variable name="fieldTitles5" select="/SAREroot/pdpInitPartners/@key_out_field_titles5"/>
	<xsl:variable name="fieldTitles6" select="/SAREroot/pdpInitPartners/@key_out_field_titles6"/>
	<xsl:variable name="webSessionNum" select="/SAREroot/pdpInitPartners/@key_out_web_sessions"/>
	<xsl:variable name="webTitles1" select="/SAREroot/pdpInitPartners/@key_out_web_titles1"/>
	<xsl:variable name="webTitles2" select="/SAREroot/pdpInitPartners/@key_out_web_titles2"/>
	<xsl:variable name="webTitles3" select="/SAREroot/pdpInitPartners/@key_out_web_titles3"/>
	<xsl:variable name="webTitles4" select="/SAREroot/pdpInitPartners/@key_out_web_titles4"/>
	<xsl:variable name="webTitles5" select="/SAREroot/pdpInitPartners/@key_out_web_titles5"/>
	<xsl:variable name="webTitles6" select="/SAREroot/pdpInitPartners/@key_out_web_titles6"/>
	<xsl:variable name="grantSessionNum" select="/SAREroot/pdpInitPartners/@key_out_grant_sessions"/>
	<xsl:variable name="grantTitles1" select="/SAREroot/pdpInitPartners/@key_out_grant_titles1"/>
	<xsl:variable name="grantTitles2" select="/SAREroot/pdpInitPartners/@key_out_grant_titles2"/>
	<xsl:variable name="grantTitles3" select="/SAREroot/pdpInitPartners/@key_out_grant_titles3"/>
	<xsl:variable name="grantTitles4" select="/SAREroot/pdpInitPartners/@key_out_grant_titles4"/>
	<xsl:variable name="grantTitles5" select="/SAREroot/pdpInitPartners/@key_out_grant_titles5"/>
	<xsl:variable name="grantTitles6" select="/SAREroot/pdpInitPartners/@key_out_grant_titles6"/>
	<xsl:variable name="travelSessionNum" select="/SAREroot/pdpInitPartners/@key_out_travel_sessions"/>
	<xsl:variable name="travelTitles1" select="/SAREroot/pdpInitPartners/@key_out_travel_titles1"/>
	<xsl:variable name="travelTitles2" select="/SAREroot/pdpInitPartners/@key_out_travel_titles2"/>
	<xsl:variable name="travelTitles3" select="/SAREroot/pdpInitPartners/@key_out_travel_titles3"/>
	<xsl:variable name="travelTitles4" select="/SAREroot/pdpInitPartners/@key_out_travel_titles4"/>
	<xsl:variable name="travelTitles5" select="/SAREroot/pdpInitPartners/@key_out_travel_titles5"/>
	<xsl:variable name="travelTitles6" select="/SAREroot/pdpInitPartners/@key_out_travel_titles6"/>
	<xsl:variable name="travelTitles7" select="/SAREroot/pdpInitPartners/@key_out_travel_titles7"/>
	<xsl:variable name="travelTitles8" select="/SAREroot/pdpInitPartners/@key_out_travel_titles8"/>
	<xsl:variable name="travelTitles9" select="/SAREroot/pdpInitPartners/@key_out_travel_titles9"/>
	<xsl:variable name="travelTitles10" select="/SAREroot/pdpInitPartners/@key_out_travel_titles10"/>
	<xsl:variable name="travelTitles11" select="/SAREroot/pdpInitPartners/@key_out_travel_titles11"/>
	<xsl:variable name="travelTitles12" select="/SAREroot/pdpInitPartners/@key_out_travel_titles12"/>
	<xsl:variable name="travelTitles13" select="/SAREroot/pdpInitPartners/@key_out_travel_titles13"/>
	<xsl:variable name="travelTitles14" select="/SAREroot/pdpInitPartners/@key_out_travel_titles14"/>
	<xsl:variable name="travelTitles15" select="/SAREroot/pdpInitPartners/@key_out_travel_titles15"/>
	<xsl:variable name="travelTitles16" select="/SAREroot/pdpInitPartners/@key_out_travel_titles16"/>
	<xsl:variable name="travelTitles17" select="/SAREroot/pdpInitPartners/@key_out_travel_titles17"/>
	<xsl:variable name="travelTitles18" select="/SAREroot/pdpInitPartners/@key_out_travel_titles18"/>
	<xsl:variable name="travelTitles19" select="/SAREroot/pdpInitPartners/@key_out_travel_titles19"/>
	<xsl:variable name="travelTitles20" select="/SAREroot/pdpInitPartners/@key_out_travel_titles20"/>
	<xsl:variable name="otherSessionNum" select="/SAREroot/pdpInitPartners/@key_out_other_sessions"/>
	<xsl:variable name="otherTitles1" select="/SAREroot/pdpInitPartners/@key_out_other_titles1"/>
	<xsl:variable name="otherTitles2" select="/SAREroot/pdpInitPartners/@key_out_other_titles2"/>
	<xsl:variable name="otherTitles3" select="/SAREroot/pdpInitPartners/@key_out_other_titles3"/>
	<xsl:variable name="otherTitles4" select="/SAREroot/pdpInitPartners/@key_out_other_titles4"/>
	<xsl:variable name="otherTitles5" select="/SAREroot/pdpInitPartners/@key_out_other_titles5"/>
	<xsl:variable name="otherTitles6" select="/SAREroot/pdpInitPartners/@key_out_other_titles6"/>
	
	<p>
		<span class="pagetitle">Training Initiative</span>
		<xsl:if test="$message">
			<br/>
			<b>
				<i>
					<span style="color:#FF0000;">
						<xsl:value-of select="$message"/>
					</span>
				</i>
			</b>
		</xsl:if>
		<xsl:if test="$message2">
			<br/>
			<i>
				<xsl:value-of select="$message2"/>
			</i>
		</xsl:if>
	</p>
	<p>
		Use the fields below to describe a training or educational initiative undertaken as part of your project.
	</p>
	<form id="pdpinit" name="pdpinit" method="post">
	<table>		
		<tr>
			<td COLSPAN="4" nowrap="true"><strong>Title: </strong>
				<small>&#160;&#160;(140 character limit)</small>
			</td>
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">
				<!-- 
				<textarea id="initDesc" name="initDesc" rows="2" cols="70">
					<xsl:value-of disable-output-escaping="yes" select="$initDesc"/>					
				</textarea>
				-->
				<input name="initDesc" id="initDesc" type="text" value="{$initDesc}" size="120" maxlength="140"/>
				<!-- &#160;&#160;&#160;<input name="cmdRetrievePass" type="submit" value="Add Initiative"/> -->
			</td>						
		</tr>

		<tr>
			<td COLSPAN="4">
				<strong>&#160;</strong>
			</td>
		</tr>
	<tr>
		<td COLSPAN="4">
			<strong>Objectives:</strong>
			<small>&#160;&#160;Describe the training initiative, objectives and intended outcomes. Include information on initiative’s topic, format or educational approach, and what needs it is intended to address. Describe the intended target audience, including the expected number of participants and the anticipated behavioral changes of the audience.</small>
		</td>
	</tr>
	<tr>
		<td COLSPAN="4" nowrap="true">
			<textarea id="initObj" name="initObj" style="width:100%">
				<!-- <xsl:value-of disable-output-escaping="yes" select="$initObj"/> -->
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="$initObj"/>
				</xsl:call-template>
			</textarea>
		</td>
	</tr>
	<!-- 
	<tr>
		<td colspan="2"/>&#160;&#160;&#160;
	</tr>		
	<tr>
			<td COLSPAN="4" nowrap="true"><strong>Partners:</strong><br/>
			<small>Please give your best estimate for the number of people (by occupation) involved in the implementation of this project in any of the following ways other than as trainees</small></td>			
	</tr>
	-->	
	</table>
		<br/>
		<br/>
		<p>
			<strong>Partners:</strong>
			<small>&#160;&#160;Please indicate what people (by occupation) where involved in the following ways.</small>
			<table width="100%">				
				<tr>
					<th scope="col"></th>
					<th scope="col">Extension</th>
					<th scope="col">NRCS</th>
					<th scope="col">NGO</th>
					<th scope="col">Agency*</th>
					<th scope="col">Farmer/Rancher</th>
					<th scope="col">&#160;Other</th>
				</tr>
				<tr>
					<td>Participated on planning team</td>
					<td>
						<xsl:choose>
							<xsl:when test="$partExt != '0'">
								<input name="partExtCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partExtCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partExt" size="3" maxLength="3" value="{$partExt}"/>&#160;&#160;&#160; -->
					</td>
					
					<td>
						<xsl:choose>
							<xsl:when test="$partNRCS != '0'">
								<input name="partNRCSCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partNRCSCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partNRCS" size="3" maxLength="3" value="{$partNRCS}"/>&#160;&#160;&#160; -->
					</td>
					
					<td>
						<xsl:choose>
							<xsl:when test="$partNGO != '0'">
								<input name="partNGOCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partNGOCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partNGO" size="3" maxLength="3" value="{$partNGO}"/>&#160;&#160;&#160; -->
					</td>
					
					<td>
						<xsl:choose>
							<xsl:when test="$partState != '0'">
								<input name="partStateCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partStateCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partState" size="3" maxLength="3" value="{$partState}"/>&#160;&#160;&#160; -->
					</td>
					
					<td>
						<xsl:choose>
							<xsl:when test="$partFarmer != '0'">
								<input name="partFarmerCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partFarmerCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partFarmer" size="3" maxLength="3" value="{$partFarmer}"/>&#160;&#160;&#160; -->
					</td>
					
					<td>
						<xsl:choose>
							<xsl:when test="$partOther != '0'">
								<input name="partOtherCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="partOtherCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="partOther" size="3" maxLength="3" value="{$partOther}"/>&#160;&#160;&#160; -->
					</td>
				</tr>
				<tr>
					<!-- <td>Actively involved at training sessions</td>-->
					<td>Participated as trainer</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainExt != '0'">
								<input name="trainExtCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainExtCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainExt" size="3" maxLength="3" value="{$trainExt}"/>&#160;&#160;&#160; -->
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainNRCS != '0'">
								<input name="trainNRCSCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainNRCSCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainNRCS" size="3" maxLength="3" value="{$trainNRCS}"/>&#160;&#160;&#160; -->
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainNGO != '0'">
								<input name="trainNGOCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainNGOCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainNGO" size="3" maxLength="3" value="{$trainNGO}"/>&#160;&#160;&#160; -->
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainState != '0'">
								<input name="trainStateCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainStateCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainState" size="3" maxLength="3" value="{$trainState}"/>&#160;&#160;&#160; -->
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainFarmer != '0'">
								<input name="trainFarmerCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainFarmerCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainFarmer" size="3" maxLength="3" value="{$trainFarmer}"/>&#160;&#160;&#160; -->
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="$trainOther != '0'">
								<input name="trainOtherCBox" type="checkbox" checked="yes"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="trainOtherCBox" type="checkbox"/>
							</xsl:otherwise>
						</xsl:choose>
						<!-- <INPUT onkeypress="return numbersonly(event,false)" name="trainOther" size="3" maxLength="3" value="{$trainOther}"/>&#160;&#160;&#160; -->
					</td>
				</tr>
				<!-- 
				<tr>
					<td>Developed outreach materials</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devExt" size="3" maxLength="3" value="{$devExt}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devNRCS" size="3" maxLength="3" value="{$devNRCS}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devNGO" size="3" maxLength="3" value="{$devNGO}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devState" size="3" maxLength="3" value="{$devState}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devFarmer" size="3" maxLength="3" value="{$devFarmer}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="devOther" size="3" maxLength="3" value="{$devOther}"/>&#160;&#160;&#160;</td>
				</tr>
				<tr>
					<td>Involved in any other ways</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invExt" size="3" maxLength="3" value="{$invExt}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invNRCS" size="3" maxLength="3" value="{$invNRCS}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invNGO" size="3" maxLength="3" value="{$invNGO}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invState" size="3" maxLength="3" value="{$invState}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invFarmer" size="3" maxLength="3" value="{$invFarmer}"/>&#160;&#160;&#160;</td>
					<td><INPUT onkeypress="return numbersonly(event,false)" name="invOther" size="3" maxLength="3" value="{$invOther}"/>&#160;&#160;&#160;</td>			
				</tr>
				-->
				<tr>
					<td>* State, federal, or tribal agency</td>
				</tr>
				<tr>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
					<td>&#160;&#160;</td>
				</tr>
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpinitID != 0">
								<input name="cmdPdpInitUpate" type="submit" value="Update"/>&#160;&#160;&#160;&#160;&#160;&#160;
								<input name="Cancel" onclick ="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'" type="button" value="Cancel"/>
							</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpInitSave" type="submit" value="Save"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<input name="Cancel" onclick ="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'" type="button" value="Cancel"/>
							</xsl:otherwise>							
						</xsl:choose>
					</td>
				</tr>
				<tr>
					<td COLSPAN="4">
						<xsl:choose>
							<xsl:when test="$pdpinitID != 0">
								Click “Update” to save edits in the fields above before entering content in the section below.
							</xsl:when>
							<xsl:otherwise>
								Click “Save” to save edits in the fields above before entering content in the section below.
							</xsl:otherwise>
						</xsl:choose>
					</td>					
				</tr>
				
			</table>
		</p>
		<p>
			<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
				<tr>
					<td>
						<p class="pagetitle">
							Key Activities and Outcomes&#160;&#160;&#160;<!-- <a href="javascript:;" onmousedown="toggleDiv('mydiv');">+/-</a> -->
						</p>
						<p>
							Please describe the activities performed as part of this initiative. To add an activity to your report, click the links below and provide detail for the activity on the following page.
						</p>
						<!-- <div class="wrapper" id="mydiv" style="display:none;margin-left:1em"> -->
							
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyout&amp;pn={$projNum}">Add Workshops</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Workshops</a>
								</xsl:if>
								--><br/>
								<xsl:choose>
									<xsl:when test="$workSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=2">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=3">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=4">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=4">Workshop 5</a>
										:&#160;<xsl:value-of select="$workTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=5">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=4">Workshop 5</a>
										:&#160;<xsl:value-of select="$workTitles5"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;sessNum=5">Workshop 6</a>
										:&#160;<xsl:value-of select="$workTitles6"/>
									</xsl:when>
									<xsl:when test="$workSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/><a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Workshop 5</a>
										:&#160;<xsl:value-of select="$workTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Workshop</a>
									</xsl:when>
									<xsl:when test="$workSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Workshop 1</a>
										:&#160;<xsl:value-of select="$workTitles1"/>
										<br/>
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Workshop 2</a>
										:&#160;<xsl:value-of select="$workTitles2"/>
										<br/>
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Workshop 3</a>
										:&#160;<xsl:value-of select="$workTitles3"/>
										<br/>
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Workshop 4</a>
										:&#160;<xsl:value-of select="$workTitles4"/>
										<br/>
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Workshop 5</a>
										:&#160;<xsl:value-of select="$workTitles5"/>
										<br/>
										<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Workshop 6</a>
										:&#160;<xsl:value-of select="$workTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">											
											<a href="?do=pdpkeyout&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Workshop');return false">Add Workshop</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyout&amp;pn={$projNum}">Add Workshop</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyout&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Workshop');return false">Add Workshop</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyout&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Workshop</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
								<br/><br/>
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyoutfield&amp;pn={$projNum}">Add Field Day/Tours</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Field Day/Tours</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$fieldSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=2">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=3">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=4">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=4">Field Day/Tour 5</a>
										:&#160;<xsl:value-of select="$fieldTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=5">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=4">Field Day/Tour 5</a>
										:&#160;<xsl:value-of select="$fieldTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;sessNum=5">Field Day/Tour 6</a>
										:&#160;<xsl:value-of select="$fieldTitles6"/>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/><a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Field Day/Tour 5</a>
										:&#160;<xsl:value-of select="$fieldTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Field Day/Tour</a>
									</xsl:when>
									<xsl:when test="$fieldSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Field Day/Tour 1</a>
										:&#160;<xsl:value-of select="$fieldTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Field Day/Tour 2</a>
										:&#160;<xsl:value-of select="$fieldTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Field Day/Tour 3</a>
										:&#160;<xsl:value-of select="$fieldTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Field Day/Tour 4</a>
										:&#160;<xsl:value-of select="$fieldTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Field Day/Tour 5</a>
										:&#160;<xsl:value-of select="$fieldTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Field Day/Tour 6</a>
										:&#160;<xsl:value-of select="$fieldTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutfield&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Field Day/Tour');return false">Add Field Day/Tour</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutfield&amp;pn={$projNum}">Add Field Day/Tour</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutfield&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Field Day/Tour');return false">Add Field Day/Tour</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutfield&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Field Day/Tour</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
								<br/><br/>
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}">Study Circle/Focus Group</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Study Circle/Focus Group</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$studySessionNum = '1' and $initiativeNum = '0'">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '2' and $initiativeNum = '0'">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=2">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=3">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=4">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=4">Study Circle/Focus Group 5</a>:&#160;<xsl:value-of select="$studyTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=5">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=4">Study Circle/Focus Group 5</a>:&#160;<xsl:value-of select="$studyTitles5"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;sessNum=5">Study Circle/Focus Group 6</a>:&#160;<xsl:value-of select="$studyTitles6"/>
									</xsl:when>
									<xsl:when test="$studySessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
											<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
											<br/>&#160;&#160;&#160;&#160;&#160;&#160;
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Study Circle/Focus Group 5</a>:&#160;<xsl:value-of select="$studyTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Study Circle/Focus Group</a>
									</xsl:when>
									<xsl:when test="$studySessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Study Circle/Focus Group 1</a>:&#160;<xsl:value-of select="$studyTitles1"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Study Circle/Focus Group 2</a>:&#160;<xsl:value-of select="$studyTitles2"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Study Circle/Focus Group 3</a>:&#160;<xsl:value-of select="$studyTitles3"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Study Circle/Focus Group 4</a>:&#160;<xsl:value-of select="$studyTitles4"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Study Circle/Focus Group 5</a>:&#160;<xsl:value-of select="$studyTitles5"/>
										<br/><a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Study Circle/Focus Group 6</a>:&#160;<xsl:value-of select="$studyTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Study Circle/Focus Group');return false">Add Study Circle/Focus Group</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}">Add Study Circle/Focus Group</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Study Circle/Focus Group');return false">Add Study Circle/Focus Group</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutstudy&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Study Circle/Focus Group</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
								<br/>
								<br/>
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyoutweb&amp;pn={$projNum}">Add Web-base Curriculum</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Web-base Curriculum</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$webSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=2">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=3">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=4">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=4">Webinars 5</a>
										:&#160;<xsl:value-of select="$webTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=5">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=4">Webinars 5</a>
										:&#160;<xsl:value-of select="$webTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;sessNum=5">Webinars 6</a>
										:&#160;<xsl:value-of select="$webTitles6"/>
									</xsl:when>
									<xsl:when test="$webSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/><a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Webinars 5</a>
										:&#160;<xsl:value-of select="$webTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Webinars</a>
									</xsl:when>
									<xsl:when test="$webSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Webinars 1</a>
										:&#160;<xsl:value-of select="$webTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Webinars 2</a>
										:&#160;<xsl:value-of select="$webTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Webinars 3</a>
										:&#160;<xsl:value-of select="$webTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Webinars 4</a>
										:&#160;<xsl:value-of select="$webTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Webinars 5</a>
										:&#160;<xsl:value-of select="$webTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Webinars 6</a>
										:&#160;<xsl:value-of select="$webTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutweb&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Webinars.');return false">Add Webinars</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutweb&amp;pn={$projNum}">Add Webinars</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutweb&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Webinars.');return false">Add Webinars</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutweb&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Webinars</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
						        <br/><br/>
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}">Add Mini-Grants</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Mini-Grants</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$grantSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=2">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=3">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=4">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=4">Curricula 5</a>
										:&#160;<xsl:value-of select="$grantTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=5">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=4">Curricula 5</a>
										:&#160;<xsl:value-of select="$grantTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;sessNum=5">Curricula 6</a>
										:&#160;<xsl:value-of select="$grantTitles6"/>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/><a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Curricula 5</a>
										:&#160;<xsl:value-of select="$grantTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Curricula</a>
									</xsl:when>
									<xsl:when test="$grantSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Curricula 1</a>
										:&#160;<xsl:value-of select="$grantTitles1"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Curricula 2</a>
										:&#160;<xsl:value-of select="$grantTitles2"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Curricula 3</a>
										:&#160;<xsl:value-of select="$grantTitles3"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Curricula 4</a>
										:&#160;<xsl:value-of select="$grantTitles4"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Curricula 5</a>
										:&#160;<xsl:value-of select="$grantTitles5"/>
										<br/>
										<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Curricula 6</a>
										:&#160;<xsl:value-of select="$grantTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Curricula');return false">Add Curricula</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}">Add Curricula</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Curricula');return false">Add Curricula</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutgrants&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Curricula</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
								<br/>
								<br/>
								<!-- 
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyouttravel&amp;pn={$projNum}">Add Travel</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Travel</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$travelSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '7' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '8' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '9' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '10' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '11' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '12' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '13' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '14' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '15' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '16' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=16">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '17' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=17">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '18' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/>
										<br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/>
										<br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=18">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '19' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=18">Travel Scholarships 19</a>
										:&#160;<xsl:value-of select="$travelTitles19"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=19">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '20' and $initiativeNum = '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=18">Travel Scholarships 19</a>
										:&#160;<xsl:value-of select="$travelTitles19"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;sessNum=19">Travel Scholarships 20</a>
										:&#160;<xsl:value-of select="$travelTitles20"/><br/>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/><a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '7' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '8' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '9' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '10' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '11' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '12' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '13' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '14' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '15' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '16' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=16">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '17' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=17">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '18' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=18">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '19' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=18">Travel Scholarships 19</a>
										:&#160;<xsl:value-of select="$travelTitles19"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=19">Add Travel Scholarships</a>
									</xsl:when>
									<xsl:when test="$travelSessionNum = '20' and $initiativeNum != '0'">
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Travel Scholarships 1</a>
										:&#160;<xsl:value-of select="$travelTitles1"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Travel Scholarships 2</a>
										:&#160;<xsl:value-of select="$travelTitles2"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Travel Scholarships 3</a>
										:&#160;<xsl:value-of select="$travelTitles3"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Travel Scholarships 4</a>
										:&#160;<xsl:value-of select="$travelTitles4"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Travel Scholarships 5</a>
										:&#160;<xsl:value-of select="$travelTitles5"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Travel Scholarships 6</a>
										:&#160;<xsl:value-of select="$travelTitles6"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=6">Travel Scholarships 7</a>
										:&#160;<xsl:value-of select="$travelTitles7"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=7">Travel Scholarships 8</a>
										:&#160;<xsl:value-of select="$travelTitles8"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=8">Travel Scholarships 9</a>
										:&#160;<xsl:value-of select="$travelTitles9"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=9">Travel Scholarships 10</a>
										:&#160;<xsl:value-of select="$travelTitles10"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=10">Travel Scholarships 11</a>
										:&#160;<xsl:value-of select="$travelTitles11"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=11">Travel Scholarships 12</a>
										:&#160;<xsl:value-of select="$travelTitles12"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=12">Travel Scholarships 13</a>
										:&#160;<xsl:value-of select="$travelTitles13"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=13">Travel Scholarships 14</a>
										:&#160;<xsl:value-of select="$travelTitles14"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=14">Travel Scholarships 15</a>
										:&#160;<xsl:value-of select="$travelTitles15"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=15">Travel Scholarships 16</a>
										:&#160;<xsl:value-of select="$travelTitles16"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=16">Travel Scholarships 17</a>
										:&#160;<xsl:value-of select="$travelTitles17"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=17">Travel Scholarships 18</a>
										:&#160;<xsl:value-of select="$travelTitles18"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=18">Travel Scholarships 19</a>
										:&#160;<xsl:value-of select="$travelTitles19"/><br/>
										<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=19">Travel Scholarships 20</a>
										:&#160;<xsl:value-of select="$travelTitles20"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyouttravel&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Travel');return false">Add Travel Scholarships</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyouttravel&amp;pn={$projNum}">Add Travel Scholarships</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyouttravel&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Travel');return false">Add Travel Scholarships</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyouttravel&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Travel Scholarships</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
						        <br/><br/>
								<!--
								<xsl:if test="$initiativeNum = '0'">
									<a href="?do=pdpkeyoutother&amp;pn={$projNum}">Add Other Activity</a>
								</xsl:if>
								<xsl:if test="$initiativeNum != '0'">
									<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Other Activity</a>
								</xsl:if>
								-->
								<xsl:choose>
									<xsl:when test="$otherSessionNum = '1' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '2' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=2">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '3' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=3">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '4' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=4">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '5' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=4">Other Activity 5</a>
										:&#160;<xsl:value-of select="$otherTitles5"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=5">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '6' and $initiativeNum = '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=4">Other Activity 5</a>
										:&#160;<xsl:value-of select="$otherTitles5"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;sessNum=5">Other Activity 6</a>
										:&#160;<xsl:value-of select="$otherTitles6"/>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '1' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '2' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '3' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '4' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '5' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/><a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Other Activity 5</a>
										:&#160;<xsl:value-of select="$otherTitles5"/><br/>&#160;&#160;&#160;&#160;&#160;&#160;
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Add Other Activity</a>
									</xsl:when>
									<xsl:when test="$otherSessionNum = '6' and $initiativeNum != '0'">
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=0">Other Activity 1</a>
										:&#160;<xsl:value-of select="$otherTitles1"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=1">Other Activity 2</a>
										:&#160;<xsl:value-of select="$otherTitles2"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=2">Other Activity 3</a>
										:&#160;<xsl:value-of select="$otherTitles3"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=3">Other Activity 4</a>
										:&#160;<xsl:value-of select="$otherTitles4"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=4">Other Activity 5</a>
										:&#160;<xsl:value-of select="$otherTitles5"/><br/>
										<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}&amp;sessNum=5">Other Activity 6</a>
										:&#160;<xsl:value-of select="$otherTitles6"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutother&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Other Activity');return false">Add Other Activity</a>
										</xsl:if>
										<xsl:if test="$initiativeNum = '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutother&amp;pn={$projNum}">Add Other Activity</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID = 0">
											<a href="?do=pdpkeyoutother&amp;pn={$projNum}" style='text-decoration:none;cursor: auto;' onClick="alert('Enter Training Initiative and Partners before adding Other Activity');return false">Add Other Activity</a>
										</xsl:if>
										<xsl:if test="$initiativeNum != '0' and $pdpinitID != 0">
											<a href="?do=pdpkeyoutother&amp;pn={$projNum}&amp;initNum={$initiativeNum}">Add Other Activity</a>
										</xsl:if>
									</xsl:otherwise>
								</xsl:choose>
							
						<!-- </div> -->
					</td>
				</tr>
			</table>
		</p>

		<p>
			<table>
				<tr>
					<td>
						<xsl:if test="$pdpinitID != 0">
							<input name="confDel" type="checkbox" value="true"/>Confirm Delete<br/><br/>
							<INPUT type="submit" name="cmdPDPInitDelete" id="cmdPDPInitDelete" value="Delete PDP Initiative"/>&#160;&#160;&#160;&#160;&#160;&#160;							
						</xsl:if>
						<input name="Back To Overview" onclick ="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'" type="button" value="Back To Overview"/>
					</td>
				</tr>
			</table>
		</p>
		
	</form>

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