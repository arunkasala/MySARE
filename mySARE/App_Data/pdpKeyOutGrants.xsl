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
		<xsl:variable name="pdpKeyGrantID" select="/SAREroot/pdpKeyOutGrants/@pdp_key_grantID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutGrants/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutGrants/pdp_initNum"/>
		<xsl:variable name="DemoSess" select="/SAREroot/pdpKeyOutGrants/demo_session"/>
		<xsl:variable name="DemoTitle" select="/SAREroot/pdpKeyOutGrants/demo_title"/>
		<xsl:variable name="DemoDescription" select="/SAREroot/pdpKeyOutGrants/demo_description"/>
		<xsl:variable name="DemoExt" select="/SAREroot/pdpKeyOutGrants/demo_ext"/>
		<xsl:variable name="DemoNRCS" select="/SAREroot/pdpKeyOutGrants/demo_nrcs"/>
		<xsl:variable name="DemoNGO" select="/SAREroot/pdpKeyOutGrants/demo_ngo"/>
		<xsl:variable name="DemoST" select="/SAREroot/pdpKeyOutGrants/demo_st"/>
		<xsl:variable name="DemoPro" select="/SAREroot/pdpKeyOutGrants/demo_pro"/>
		<xsl:variable name="DemoFarm" select="/SAREroot/pdpKeyOutGrants/demo_farm"/>
		<xsl:variable name="DemoAttOther" select="/SAREroot/pdpKeyOutGrants/demo_att_other"/>
		<xsl:variable name="DemoAttDesc" select="/SAREroot/pdpKeyOutGrants/demo_att_desc"/>
		<xsl:variable name="DemoLoc" select="/SAREroot/pdpKeyOutGrants/demo_loc"/>
		<xsl:variable name="DemoState" select="/SAREroot/pdpKeyOutGrants/demo_state"/>
		<xsl:variable name="DemoZip" select="/SAREroot/pdpKeyOutGrants/demo_zip"/>
		<xsl:variable name="DemoMedia" select="/SAREroot/pdpKeyOutGrants/demo_media"/>
		<xsl:variable name="DemoClient" select="/SAREroot/pdpKeyOutGrants/demo_client"/>
		<xsl:variable name="DemoDevel" select="/SAREroot/pdpKeyOutGrants/demo_devel"/>
		<xsl:variable name="DemoIncorp" select="/SAREroot/pdpKeyOutGrants/demo_incorp"/>
		<xsl:variable name="DemoProg" select="/SAREroot/pdpKeyOutGrants/demo_prog"/>
		<xsl:variable name="DemoConsult" select="/SAREroot/pdpKeyOutGrants/demo_consult"/>
		<xsl:variable name="DemoFarmers" select="/SAREroot/pdpKeyOutGrants/demo_farmers"/>
		<xsl:variable name="DemoOutOther" select="/SAREroot/pdpKeyOutGrants/demo_out_other"/>
		<xsl:variable name="DemoOutDesc" select="/SAREroot/pdpKeyOutGrants/demo_out_desc"/>
		<xsl:variable name="WorkSess" select="/SAREroot/pdpKeyOutGrants/work_session"/>
		<xsl:variable name="WorkTitle" select="/SAREroot/pdpKeyOutGrants/work_title"/>
		<xsl:variable name="WorkDescription" select="/SAREroot/pdpKeyOutGrants/work_description"/>
		<xsl:variable name="WorkExt" select="/SAREroot/pdpKeyOutGrants/work_ext"/>
		<xsl:variable name="WorkNRCS" select="/SAREroot/pdpKeyOutGrants/work_nrcs"/>
		<xsl:variable name="WorkNGO" select="/SAREroot/pdpKeyOutGrants/work_ngo"/>
		<xsl:variable name="WorkST" select="/SAREroot/pdpKeyOutGrants/work_st"/>
		<xsl:variable name="WorkPro" select="/SAREroot/pdpKeyOutGrants/work_pro"/>
		<xsl:variable name="WorkFarm" select="/SAREroot/pdpKeyOutGrants/work_farm"/>
		<xsl:variable name="WorkAttOther" select="/SAREroot/pdpKeyOutGrants/work_att_other"/>
		<xsl:variable name="WorkAttDesc" select="/SAREroot/pdpKeyOutGrants/work_att_desc"/>
		<xsl:variable name="WorkLoc" select="/SAREroot/pdpKeyOutGrants/work_loc"/>
		<xsl:variable name="WorkState" select="/SAREroot/pdpKeyOutGrants/work_state"/>
		<xsl:variable name="WorkZip" select="/SAREroot/pdpKeyOutGrants/work_zip"/>
		<xsl:variable name="WorkMedia" select="/SAREroot/pdpKeyOutGrants/work_media"/>
		<xsl:variable name="WorkClient" select="/SAREroot/pdpKeyOutGrants/work_client"/>
		<xsl:variable name="WorkDevel" select="/SAREroot/pdpKeyOutGrants/work_devel"/>
		<xsl:variable name="WorkIncorp" select="/SAREroot/pdpKeyOutGrants/work_incorp"/>
		<xsl:variable name="WorkProg" select="/SAREroot/pdpKeyOutGrants/work_prog"/>
		<xsl:variable name="WorkConsult" select="/SAREroot/pdpKeyOutGrants/work_consult"/>
		<xsl:variable name="WorkFarmers" select="/SAREroot/pdpKeyOutGrants/work_farmers"/>
		<xsl:variable name="WorkOutOther" select="/SAREroot/pdpKeyOutGrants/work_out_other"/>
		<xsl:variable name="WorkOutDesc" select="/SAREroot/pdpKeyOutGrants/work_out_desc"/>
		<xsl:variable name="TourSess" select="/SAREroot/pdpKeyOutGrants/tour_session"/>
		<xsl:variable name="TourTitle" select="/SAREroot/pdpKeyOutGrants/tour_title"/>
		<xsl:variable name="TourDescription" select="/SAREroot/pdpKeyOutGrants/tour_description"/>
		<xsl:variable name="TourExt" select="/SAREroot/pdpKeyOutGrants/tour_ext"/>
		<xsl:variable name="TourNRCS" select="/SAREroot/pdpKeyOutGrants/tour_nrcs"/>
		<xsl:variable name="TourNGO" select="/SAREroot/pdpKeyOutGrants/tour_ngo"/>
		<xsl:variable name="TourST" select="/SAREroot/pdpKeyOutGrants/tour_st"/>
		<xsl:variable name="TourPro" select="/SAREroot/pdpKeyOutGrants/tour_pro"/>
		<xsl:variable name="TourFarm" select="/SAREroot/pdpKeyOutGrants/tour_farm"/>
		<xsl:variable name="TourAttOther" select="/SAREroot/pdpKeyOutGrants/tour_att_other"/>
		<xsl:variable name="TourAttDesc" select="/SAREroot/pdpKeyOutGrants/tour_att_desc"/>
		<xsl:variable name="TourLoc" select="/SAREroot/pdpKeyOutGrants/tour_loc"/>
		<xsl:variable name="TourState" select="/SAREroot/pdpKeyOutGrants/tour_state"/>
		<xsl:variable name="TourZip" select="/SAREroot/pdpKeyOutGrants/tour_zip"/>
		<xsl:variable name="TourMedia" select="/SAREroot/pdpKeyOutGrants/tour_media"/>
		<xsl:variable name="TourClient" select="/SAREroot/pdpKeyOutGrants/tour_client"/>
		<xsl:variable name="TourDevel" select="/SAREroot/pdpKeyOutGrants/tour_devel"/>
		<xsl:variable name="TourIncorp" select="/SAREroot/pdpKeyOutGrants/tour_incorp"/>
		<xsl:variable name="TourProg" select="/SAREroot/pdpKeyOutGrants/tour_prog"/>
		<xsl:variable name="TourConsult" select="/SAREroot/pdpKeyOutGrants/tour_consult"/>
		<xsl:variable name="TourFarmers" select="/SAREroot/pdpKeyOutGrants/tour_farmers"/>
		<xsl:variable name="TourOutOther" select="/SAREroot/pdpKeyOutGrants/tour_out_other"/>
		<xsl:variable name="TourOutDesc" select="/SAREroot/pdpKeyOutGrants/tour_out_desc"/>
		<xsl:variable name="CurSess" select="/SAREroot/pdpKeyOutGrants/cur_session"/>
		<xsl:variable name="CurTitle" select="/SAREroot/pdpKeyOutGrants/cur_title"/>
		<xsl:variable name="CurDescription" select="/SAREroot/pdpKeyOutGrants/cur_description"/>
		<xsl:variable name="CurExt" select="/SAREroot/pdpKeyOutGrants/cur_ext"/>
		<xsl:variable name="CurNRCS" select="/SAREroot/pdpKeyOutGrants/cur_nrcs"/>
		<xsl:variable name="CurNGO" select="/SAREroot/pdpKeyOutGrants/cur_ngo"/>
		<xsl:variable name="CurST" select="/SAREroot/pdpKeyOutGrants/cur_st"/>
		<xsl:variable name="CurPro" select="/SAREroot/pdpKeyOutGrants/cur_pro"/>
		<xsl:variable name="CurFarm" select="/SAREroot/pdpKeyOutGrants/cur_farm"/>
		<xsl:variable name="CurAttOther" select="/SAREroot/pdpKeyOutGrants/cur_att_other"/>
		<xsl:variable name="CurAttDesc" select="/SAREroot/pdpKeyOutGrants/cur_att_desc"/>
		<xsl:variable name="CurLoc" select="/SAREroot/pdpKeyOutGrants/cur_loc"/>
		<xsl:variable name="CurState" select="/SAREroot/pdpKeyOutGrants/cur_state"/>
		<xsl:variable name="CurZip" select="/SAREroot/pdpKeyOutGrants/cur_zip"/>
		<xsl:variable name="CurMedia" select="/SAREroot/pdpKeyOutGrants/cur_media"/>
		<xsl:variable name="CurClient" select="/SAREroot/pdpKeyOutGrants/cur_client"/>
		<xsl:variable name="CurDevel" select="/SAREroot/pdpKeyOutGrants/cur_devel"/>
		<xsl:variable name="CurIncorp" select="/SAREroot/pdpKeyOutGrants/cur_incorp"/>
		<xsl:variable name="CurProg" select="/SAREroot/pdpKeyOutGrants/cur_prog"/>
		<xsl:variable name="CurConsult" select="/SAREroot/pdpKeyOutGrants/cur_consult"/>
		<xsl:variable name="CurFarmers" select="/SAREroot/pdpKeyOutGrants/cur_farmers"/>
		<xsl:variable name="CurOutOther" select="/SAREroot/pdpKeyOutGrants/cur_out_other"/>
		<xsl:variable name="CurOutDesc" select="/SAREroot/pdpKeyOutGrants/cur_out_desc"/>
		<p>
			<span class="pagetitle">Curricula</span>
		</p>
		<p>
			Enter the activities conducted and related outcomes for each of the four mini-grant types below:
			<li>Web-based</li>
			<li>Print-based</li>
			<!-- 
			<li>Tour</li>
			<li>Curriculum Development</li>
			-->
		</p>
		<xsl:if test="$pdpKeyGrantID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyGrantID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutGrants" name="pdpKeyOutGrants" method="post">
			<table>
				<tr>
					<td>
						<p>
							<strong>1) Web-based</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('ddiv');">+/-</a>&#160;&#160;<xsl:value-of select="$DemoTitle"/>
						</p>
						<div class="wrapper" id="ddiv" style="display:none;margin-left:1em"> 
							
							<strong>Title:</strong><br/>
							<!-- 
							<textarea id="demoTitle" name="demoTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$DemoTitle"/> 
							</textarea>
							-->
							<input name="demoTitle" id="demoTitle" type="text" value="{$DemoTitle}" size="120" maxlength="255"/>
							<br/>
							<strong>
								Start Date:&#160;<input name="DemoSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/demo_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutGrants.DemoSDate', document.pdpKeyOutGrants.DemoSDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="DemoEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/demo_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutGrants.DemoEDate', document.pdpKeyOutGrants.DemoEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<!--
							<strong>
								Location:&#160;<INPUT type="text" value="{$DemoLoc}" name="demoLoc" size="20" maxLength="255"/>
								&#160;&#160;&#160;Location State:&#160;
								<select name="demoState">
									<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
													<xsl:call-template name="option">
														<xsl:with-param name="selected"><xsl:value-of select="$DemoState"/></xsl:with-param>
														<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
														<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
													</xsl:call-template>
												</xsl:for-each>
								</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
							<INPUT onkeypress="return numbersonly(event,false)" name="demoZip" value="{$DemoZip}" size="3" maxLength="5"/>
							<br/><small>(City, county or region of state)</small>
						</strong>
						-->
						<strong>
							<br/><br/>Attendance:<br/>
						</strong>
						<!-- 
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Demo<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoExt}" name="DemoExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoNRCS}" name="DemoNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoNGO}" name="DemoNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoST}" name="DemoST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoFarm}" name="DemoFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoPro}" name="DemoPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$DemoAttOther}" name="DemoAttOther" size="1" maxLength="3"/>&#160;&#160;
						-->
							<div class="floatL">
								<span>Extension</span>
								<br />
								<input id="DemoExt" onkeypress="return numbersonly(event,false)" value="{$DemoExt}" name="DemoExt" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NRCS</span>
								<br />
								<input id="DemoNRCS" onkeypress="return numbersonly(event,false)" value="{$DemoNRCS}" name="DemoNRCS" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>NGO</span>
								<br />
								<input id="DemoNGO" onkeypress="return numbersonly(event,false)" value="{$DemoNGO}" name="DemoNGO" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Agency*</span>
								<br />
								<input id="DemoST" onkeypress="return numbersonly(event,false)" value="{$DemoST}" name="DemoST" size="1" maxLength="3" type="text" />
							</div>
							<div class="floatL">
								<span>Farmer/Rancher</span>
								<br />
								<input id="DemoFarm" onkeypress="return numbersonly(event,false)" value="{$DemoFarm}" name="DemoFarm" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>For Profit</span>
								<br />
								<input id="DemoPro" onkeypress="return numbersonly(event,false)" value="{$DemoPro}" name="DemoPro" size="1" maxLength="3" type="text"/>
							</div>
							<div class="floatL">
								<span>Other</span>
								<br />
								<input id="DemoAttOther" onkeypress="return numbersonly(event,false)" value ="{$DemoAttOther}" name="DemoAttOther" size="1" maxLength="3" type="text"/>
							</div>
						<br/>
						If you entered "Demo" please describe :&#160;<INPUT type="text" value="{$DemoAttDesc}" name="DemoAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="demoDescription" name="demoDescription" style="width:100%">
							<!-- <xsl:value-of disable-output-escaping="yes" select="$DemoDescription"/> -->
							<xsl:call-template name="break">
								<xsl:with-param name="text" select="$DemoDescription"/>
							</xsl:call-template>
						</textarea>
						<strong>
							<br/><br/>Action Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoMedia}" name="DemoMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or Demo media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoProg}" name="DemoProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoClient}" name="DemoClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoConsult}" name="DemoConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoDevel}" name="DemoDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoFarmers}" name="DemoFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoIncorp}" name="DemoIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$DemoOutOther}" name="DemoOutOther" size="1" maxLength="3"/>&#160;Demo
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$DemoOutDesc}" name="DemoOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
					</div>
				</td>
			</tr>

			<tr>
				<td>
					<p>
						<strong>2) Print-based</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('wdiv');">+/-</a>&#160;&#160;<xsl:value-of select="$WorkTitle"/>
					</p>
					<div class="wrapper" id="wdiv" style="display:none;margin-left:1em">

						<strong>Title</strong><br/>
						<!-- 
						<textarea id="workTitle" name="workTitle" rows="2" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$WorkTitle"/>
						</textarea>
						-->
						<input name="workTitle" id="workTitle" type="text" value="{$WorkTitle}" size="120" maxlength="255"/>
						<br/>
						<strong>
							Start Date:&#160;<input name="WorkSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/work_start_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutGrants.WorkSDate', document.pdpKeyOutGrants.WorkSDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							End Date (Optional):&#160;<input name="WorkEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/work_end_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutGrants.WorkEDate', document.pdpKeyOutGrants.WorkEDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						</strong>
						<br/>
						<br/>
						<!-- 
						<strong>
							Location:&#160;<INPUT type="text" value="{$WorkLoc}" name="workLoc" size="20" maxLength="255"/>
							&#160;&#160;&#160;Location State:&#160;
							<select name="workState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
													<xsl:call-template name="option">
														<xsl:with-param name="selected"><xsl:value-of select="$WorkState"/></xsl:with-param>
														<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
														<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
													</xsl:call-template>
												</xsl:for-each>
							</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
						<INPUT onkeypress="return numbersonly(event,false)" name="workZip" value="{$WorkZip}" size="3" maxLength="5"/>
						<br/><small>(City, county or region of state)</small>
						</strong>
						-->
						<strong>
							<br/><br/>Attendance:<br/>
						</strong>
						<!-- 
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkExt}" name="WorkExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkNRCS}" name="WorkNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkNGO}" name="WorkNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkST}" name="WorkST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkFarm}" name="WorkFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkPro}" name="WorkPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$WorkAttOther}" name="WorkAttOther" size="1" maxLength="3"/>&#160;&#160;
						-->
						<div class="floatL">
							<span>Extension</span>
							<br />
							<input id="WorkExt" onkeypress="return numbersonly(event,false)" value="{$WorkExt}" name="WorkExt" size="1" maxLength="3" type="text"/>
						</div>
						<div class="floatL">
							<span>NRCS</span>
							<br />
							<input id="WorkNRCS" onkeypress="return numbersonly(event,false)" value="{$WorkNRCS}" name="WorkNRCS" size="1" maxLength="3" type="text"/>
						</div>
						<div class="floatL">
							<span>NGO</span>
							<br />
							<input id="WorkNGO" onkeypress="return numbersonly(event,false)" value="{$WorkNGO}" name="WorkNGO" size="1" maxLength="3" type="text" />
						</div>
						<div class="floatL">
							<span>Agency*</span>
							<br />
							<input id="WorkST" onkeypress="return numbersonly(event,false)" value="{$WorkST}" name="WorkST" size="1" maxLength="3" type="text" />
						</div>
						<div class="floatL">
							<span>Farmer/Rancher</span>
							<br />
							<input id="WorkFarm" onkeypress="return numbersonly(event,false)" value="{$WorkFarm}" name="WorkFarm" size="1" maxLength="3" type="text"/>
						</div>
						<div class="floatL">
							<span>For Profit</span>
							<br />
							<input id="WorkPro" onkeypress="return numbersonly(event,false)" value="{$WorkPro}" name="WorkPro" size="1" maxLength="3" type="text"/>
						</div>
						<div class="floatL">
							<span>Other</span>
							<br />
							<input id="WorkAttOther" onkeypress="return numbersonly(event,false)" value ="{$WorkAttOther}" name="WorkAttOther" size="1" maxLength="3" type="text"/>
						</div>
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WorkAttDesc}" name="WorkAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="workDescription" name="workDescription" style="width:100%">
							<!-- <xsl:value-of disable-output-escaping="yes" select="$WorkDescription"/> -->
							<xsl:call-template name="break">
								<xsl:with-param name="text" select="$WorkDescription"/>
							</xsl:call-template>
						</textarea>
						<strong>
							<br/><br/>Action Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkMedia}" name="WorkMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkProg}" name="WorkProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkClient}" name="WorkClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkConsult}" name="WorkConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkDevel}" name="WorkDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkFarmers}" name="WorkFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkIncorp}" name="WorkIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$WorkOutOther}" name="WorkOutOther" size="1" maxLength="3"/>&#160;Other
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WorkOutDesc}" name="WorkOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
						</div>
					</td>
				</tr>
				<!--
				<tr>
					<td>
						<p>
							<strong>3) Tour</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('tdiv');">+/-</a> 
						</p>
						<div class="wrapper" id="tdiv" style="display:none;margin-left:1em"> 
							
						<strong>Title:</strong><br/>
						<textarea id="tourTitle" name="tourTitle" rows="2" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$TourTitle"/>
						</textarea><br/>
						<strong>
							Start Date:&#160;<input name="TourSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/tour_start_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutGrants.TourSDate', document.pdpKeyOutGrants.TourSDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							End Date (Optional):&#160;<input name="TourEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/tour_end_date}"/>
							<a href="javascript:show_calendar4('document.pdpKeyOutGrants.TourEDate', document.pdpKeyOutGrants.TourEDate.value);">
								&#160;
								<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
							</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						</strong>
						<br/>
						<br/>
						<strong>
							Location:&#160;<INPUT type="text" value="{$TourLoc}" name="tourLoc" size="20" maxLength="255"/>
							&#160;&#160;&#160;Location State:&#160;
							<select name="tourState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
													<xsl:call-template name="option">
														<xsl:with-param name="selected"><xsl:value-of select="$TourState"/></xsl:with-param>
														<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
														<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
													</xsl:call-template>
												</xsl:for-each>
							</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
						<INPUT onkeypress="return numbersonly(event,false)" name="tourZip" value="{$TourZip}" size="3" maxLength="5"/>
						<br/><small>(City, county or region of state)</small>
						</strong>
						<strong>
							<br/><br/>Recipients:<br/>
						</strong>
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourExt}" name="TourExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourNRCS}" name="TourNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourNGO}" name="TourNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourST}" name="TourST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourFarm}" name="TourFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourPro}" name="TourPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$TourAttOther}" name="TourAttOther" size="1" maxLength="3"/>&#160;&#160;
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$TourAttDesc}" name="TourAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="tourDescription" name="tourDescription" rows="4" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$TourDescription"/>
						</textarea>
						<strong>
							<br/><br/>Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourMedia}" name="TourMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourProg}" name="TourProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourClient}" name="TourClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourConsult}" name="TourConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourDevel}" name="TourDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourFarmers}" name="TourFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourIncorp}" name="TourIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$TourOutOther}" name="TourOutOther" size="1" maxLength="3"/>&#160;Other
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$TourOutDesc}" name="TourOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
						</div>
					</td>
				</tr>

				<tr>
					<td>
						<p>
							<strong>4) Curriculum Development</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('cdiv');">+/-</a>
						</p>
						<div class="wrapper" id="cdiv" style="display:none;margin-left:1em"> 
							
						<strong>Title:</strong><br/>
						<textarea id="curTitle" name="curTitle" rows="2" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$CurTitle"/>
						</textarea><br/>
						<strong>
								Start Date:&#160;<input name="CurSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/cur_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutGrants.CurSDate', document.pdpKeyOutGrants.CurSDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="CurEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutGrants/cur_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutGrants.CurEDate', document.pdpKeyOutGrants.CurEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
						<strong>
							Location:&#160;<INPUT type="text" value="{$CurLoc}" name="curLoc" size="20" maxLength="255"/>
							&#160;&#160;&#160;Location State:&#160;
							<select name="curState">
								<xsl:for-each select="/SAREroot/states/state" xml:space="preserve">
													<xsl:call-template name="option">
														<xsl:with-param name="selected"><xsl:value-of select="$CurState"/></xsl:with-param>
														<xsl:with-param name="value"><xsl:value-of select="abbr"/></xsl:with-param>
														<xsl:with-param name="label"><xsl:value-of select="name"/></xsl:with-param>
													</xsl:call-template>
												</xsl:for-each>
							</select>&#160;&#160;&#160;Zip <small>(Optional)</small>:&#160;
						<INPUT onkeypress="return numbersonly(event,false)" name="curZip" value="{$CurZip}" size="3" maxLength="5"/>
						<br/><small>(City, county or region of state)</small>
						</strong>
						<strong>
							<br/><br/>Recipients:<br/>
						</strong>
						Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurExt}" name="CurExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurNRCS}" name="CurNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurNGO}" name="CurNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurST}" name="CurST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurFarm}" name="CurFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurPro}" name="CurPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value ="{$CurAttOther}" name="CurAttOther" size="1" maxLength="3"/>&#160;&#160;
						<br/>
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$CurAttDesc}" name="CurAttDesc" size="50" maxLength="50"/>
						<br/><small>* State, federal, or tribal agency</small>
						<br/><br/>
						<strong>Description of Activity and Learning Outcomes</strong><br/>
						<textarea id="curDescription" name="curDescription" rows="4" cols="80">
							<xsl:value-of disable-output-escaping="yes" select="$CurDescription"/>
						</textarea>
						<strong>
							<br/><br/>Outcome(s):<br/>
						</strong>
						<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurMedia}" name="CurMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurProg}" name="CurProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurClient}" name="CurClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurConsult}" name="CurConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurDevel}" name="CurDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurFarmers}" name="CurFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
						<br/>
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurIncorp}" name="CurIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
						<INPUT onkeypress="return numbersonly(event,false)" value="{$CurOutOther}" name="CurOutOther" size="1" maxLength="3"/>&#160;Other
						<br/>
						&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
						<br/>
						If you entered "Other" please describe :&#160;<INPUT type="text" value="{$CurOutDesc}" name="CurOutDesc" size="50" maxLength="50"/>
						<br/><br/><br/>
						</div>
					</td>
				</tr>
				-->
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyGrantID != 0">
								<input name="cmdPdpKeyOutGrantsUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
								<input name="cmdPdpKeyOutGrantsDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
								<input type="hidden" name="DeleteID" value="{$pdpKeyGrantID}"/>
						</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutGrantsSave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to update data on this page and return to the Initiative page.
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
