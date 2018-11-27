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

		<xsl:variable name="pdpKeyWebID" select="/SAREroot/pdpKeyOutWeb/@pdp_key_webID"/>
		<xsl:variable name="projNum" select="/SAREroot/pdpKeyOutWeb/@proj_num"/>
		<xsl:variable name="initNum" select="/SAREroot/pdpKeyOutWeb/pdp_initNum"/>
		<xsl:variable name="WebCurricula" select="/SAREroot/pdpKeyOutWeb/web_curricula"/>
		<xsl:variable name="WebTitle" select="/SAREroot/pdpKeyOutWeb/web_title"/>
		<xsl:variable name="WebExt" select="/SAREroot/pdpKeyOutWeb/web_ext"/>
		<xsl:variable name="WebNRCS" select="/SAREroot/pdpKeyOutWeb/web_nrcs"/>
		<xsl:variable name="WebNGO" select="/SAREroot/pdpKeyOutWeb/web_ngo"/>
		<xsl:variable name="WebST" select="/SAREroot/pdpKeyOutWeb/web_st"/>
		<xsl:variable name="WebPro" select="/SAREroot/pdpKeyOutWeb/web_pro"/>
		<xsl:variable name="WebFarm" select="/SAREroot/pdpKeyOutWeb/web_farm"/>
		<xsl:variable name="WebAttOther" select="/SAREroot/pdpKeyOutWeb/web_att_other"/>
		<xsl:variable name="WebAttDesc" select="/SAREroot/pdpKeyOutWeb/web_att_desc"/>
		<xsl:variable name="WebMedia" select="/SAREroot/pdpKeyOutWeb/web_media"/>
		<xsl:variable name="WebClient" select="/SAREroot/pdpKeyOutWeb/web_client"/>
		<xsl:variable name="WebDevel" select="/SAREroot/pdpKeyOutWeb/web_devel"/>
		<xsl:variable name="WebIncorp" select="/SAREroot/pdpKeyOutWeb/web_incorp"/>
		<xsl:variable name="WebProg" select="/SAREroot/pdpKeyOutWeb/web_prog"/>
		<xsl:variable name="WebConsult" select="/SAREroot/pdpKeyOutWeb/web_consult"/>
		<xsl:variable name="WebFarmers" select="/SAREroot/pdpKeyOutWeb/web_farmers"/>
		<xsl:variable name="WebOutOther" select="/SAREroot/pdpKeyOutWeb/web_out_other"/>
		<xsl:variable name="WebOutDesc" select="/SAREroot/pdpKeyOutWeb/web_out_desc"/>
		<xsl:variable name="WebDescription" select="/SAREroot/pdpKeyOutWeb/web_description"/>
		<xsl:variable name="WebSeriesTitle" select="/SAREroot/pdpKeyOutWeb/webseries_title"/>
		<xsl:variable name="WebSeriesExt" select="/SAREroot/pdpKeyOutWeb/webseries_ext"/>
		<xsl:variable name="WebSeriesNRCS" select="/SAREroot/pdpKeyOutWeb/webseries_nrcs"/>
		<xsl:variable name="WebSeriesNGO" select="/SAREroot/pdpKeyOutWeb/webseries_ngo"/>
		<xsl:variable name="WebSeriesST" select="/SAREroot/pdpKeyOutWeb/webseries_st"/>
		<xsl:variable name="WebSeriesPro" select="/SAREroot/pdpKeyOutWeb/webseries_pro"/>
		<xsl:variable name="WebSeriesFarm" select="/SAREroot/pdpKeyOutWeb/webseries_farm"/>
		<xsl:variable name="WebSeriesAttOther" select="/SAREroot/pdpKeyOutWeb/webseries_att_other"/>
		<xsl:variable name="WebSeriesAttDesc" select="/SAREroot/pdpKeyOutWeb/webseries_att_desc"/>
		<xsl:variable name="WebSeriesMedia" select="/SAREroot/pdpKeyOutWeb/webseries_media"/>
		<xsl:variable name="WebSeriesClient" select="/SAREroot/pdpKeyOutWeb/webseries_client"/>
		<xsl:variable name="WebSeriesDevel" select="/SAREroot/pdpKeyOutWeb/webseries_devel"/>
		<xsl:variable name="WebSeriesIncorp" select="/SAREroot/pdpKeyOutWeb/webseries_incorp"/>
		<xsl:variable name="WebSeriesProg" select="/SAREroot/pdpKeyOutWeb/webseries_prog"/>
		<xsl:variable name="WebSeriesConsult" select="/SAREroot/pdpKeyOutWeb/webseries_consult"/>
		<xsl:variable name="WebSeriesFarmers" select="/SAREroot/pdpKeyOutWeb/webseries_farmers"/>
		<xsl:variable name="WebSeriesOutOther" select="/SAREroot/pdpKeyOutWeb/webseries_out_other"/>
		<xsl:variable name="WebSeriesOutDesc" select="/SAREroot/pdpKeyOutWeb/webseries_out_desc"/>
		<xsl:variable name="WebSeriesDescription" select="/SAREroot/pdpKeyOutWeb/webseries_description"/>
		<xsl:variable name="WebCurTitle" select="/SAREroot/pdpKeyOutWeb/webcur_title"/>
		<xsl:variable name="WebCurExt" select="/SAREroot/pdpKeyOutWeb/webcur_ext"/>
		<xsl:variable name="WebCurNRCS" select="/SAREroot/pdpKeyOutWeb/webcur_nrcs"/>
		<xsl:variable name="WebCurNGO" select="/SAREroot/pdpKeyOutWeb/webcur_ngo"/>
		<xsl:variable name="WebCurST" select="/SAREroot/pdpKeyOutWeb/webcur_st"/>
		<xsl:variable name="WebCurPro" select="/SAREroot/pdpKeyOutWeb/webcur_pro"/>
		<xsl:variable name="WebCurFarm" select="/SAREroot/pdpKeyOutWeb/webcur_farm"/>
		<xsl:variable name="WebCurAttOther" select="/SAREroot/pdpKeyOutWeb/webcur_att_other"/>
		<xsl:variable name="WebCurAttDesc" select="/SAREroot/pdpKeyOutWeb/webcur_att_desc"/>
		<xsl:variable name="WebCurMedia" select="/SAREroot/pdpKeyOutWeb/webcur_media"/>
		<xsl:variable name="WebCurClient" select="/SAREroot/pdpKeyOutWeb/webcur_client"/>
		<xsl:variable name="WebCurDevel" select="/SAREroot/pdpKeyOutWeb/webcur_devel"/>
		<xsl:variable name="WebCurIncorp" select="/SAREroot/pdpKeyOutWeb/webcur_incorp"/>
		<xsl:variable name="WebCurProg" select="/SAREroot/pdpKeyOutWeb/webcur_prog"/>
		<xsl:variable name="WebCurConsult" select="/SAREroot/pdpKeyOutWeb/webcur_consult"/>
		<xsl:variable name="WebCurFarmers" select="/SAREroot/pdpKeyOutWeb/webcur_farmers"/>
		<xsl:variable name="WebCurOutOther" select="/SAREroot/pdpKeyOutWeb/webcur_out_other"/>
		<xsl:variable name="WebCurOutDesc" select="/SAREroot/pdpKeyOutWeb/webcur_out_desc"/>
		<xsl:variable name="WebCurDescription" select="/SAREroot/pdpKeyOutWeb/webcur_description"/>
		
		<p>
			<!-- <span class="pagetitle">Web-Based Curricula – Web-Based Programming</span>-->
			<span class="pagetitle">Webinars</span>
		</p>
		<p>
			Enter the activities conducted and related outcomes for webinars below:
		</p>
		<xsl:if test="$pdpKeyWebID != 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Update” button.</b>
			</p>
		</xsl:if>
		<xsl:if test="$pdpKeyWebID = 0">
			<p>
				<b>All non-optional fields must be filled in before clicking “Save” button.</b>
			</p>
		</xsl:if>
		<form id="pdpKeyOutWeb" name="pdpKeyOutWeb" method="post">
			<table>				
				<tr>
					<td>
						<!--<div>
							 
							<h6>
								# of curricula : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" value="{$WebCurricula}" name="WebCurricula" size="6" maxLength="10"/>
							</h6>
							-->
							<p>
								<strong>1) Webinars</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('idiv');">+/-</a>&#160;&#160;<xsl:value-of select="$WebTitle"/>
						</p>
							<div class="wrapper" id="idiv" style="display:none;margin-left:1em">
							<strong>Title:</strong><br/>
							<!-- 
							<textarea id="webTitle" name="webTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$WebTitle"/>
							</textarea>
							-->
							<input name="webTitle" id="webTitle" type="text" value="{$WebTitle}" size="120" maxlength="255"/>
							<br/>
							<strong>
								Start Date:&#160;<input name="StudySDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/web_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.StudySDate', document.pdpKeyOutWeb.StudySDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="StudyEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/web_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.StudyEDate', document.pdpKeyOutWeb.StudyEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								<br/><br/>Attendance:<br/>
							</strong>
								<small>If you don't have a breakdown of attendees put total in Other category.</small><br/><br/>
							<!-- 
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebExt}" name="WebExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebNRCS}" name="WebNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebNGO}" name="WebNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebST}" name="WebST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebFarm}" name="WebFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebPro}" name="WebPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$WebAttOther}" name="WebAttOther" size="1" maxLength="3"/>&#160;&#160;
							-->
								<div class="floatL">
									<span>Extension</span>
									<br />
									<input id="WebExt" onkeypress="return numbersonly(event,false)" value="{$WebExt}" name="WebExt" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>NRCS</span>
									<br />
									<input id="WebNRCS" onkeypress="return numbersonly(event,false)" value="{$WebNRCS}" name="WebNRCS" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>NGO</span>
									<br />
									<input id="WebNGO" onkeypress="return numbersonly(event,false)" value="{$WebNGO}" name="WebNGO" size="1" maxLength="3" type="text" />
								</div>
								<div class="floatL">
									<span>Agency*</span>
									<br />
									<input id="WebST" onkeypress="return numbersonly(event,false)" value="{$WebST}" name="WebST" size="1" maxLength="3" type="text" />
								</div>
								<div class="floatL">
									<span>Farmer/Rancher</span>
									<br />
									<input id="WebFarm" onkeypress="return numbersonly(event,false)" value="{$WebFarm}" name="WebFarm" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>For Profit</span>
									<br />
									<input id="WebPro" onkeypress="return numbersonly(event,false)" value="{$WebPro}" name="WebPro" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>Other</span>
									<br />
									<input id="WebAttOther" onkeypress="return numbersonly(event,false)" value ="{$WebAttOther}" name="WebAttOther" size="1" maxLength="3" type="text"/>
								</div>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebAttDesc}" name="WebAttDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="webDescription" name="webDescription" style="width:100%">
								<!-- <xsl:value-of disable-output-escaping="yes" select="$WebDescription"/> -->
								<xsl:call-template name="break">
									<xsl:with-param name="text" select="$WebDescription"/>
								</xsl:call-template>
							</textarea><br/>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebMedia}" name="WebMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebProg}" name="WebProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebClient}" name="WebClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebConsult}" name="WebConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebDevel}" name="WebDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebFarmers}" name="WebFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebIncorp}" name="WebIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebOutOther}" name="WebOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebOutDesc}" name="WebOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
						</div>
					</td>
				</tr>

				<tr>
					<td>
						<!--<div>
							 
							<h6>
								# of curricula : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" value="{$WebCurricula}" name="WebCurricula" size="6" maxLength="10"/>
							</h6>
							-->
							<p>
								<strong>2) Webinars Series</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('sdiv');">+/-</a>&#160;&#160;<xsl:value-of select="$WebSeriesTitle"/>
							</p>
							<div class="wrapper" id="sdiv" style="display:none;margin-left:1em">
							<strong>Title:</strong><br/>
							<!-- 
							<textarea id="webseriesTitle" name="webseriesTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$WebSeriesTitle"/>
							</textarea>
							-->
							<input name="webseriesTitle" id="webseriesTitle" type="text" value="{$WebSeriesTitle}" size="120" maxlength="255"/>
							<br/>
							<strong>
								Start Date:&#160;<input name="ShortSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/webseries_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.ShortSDate', document.pdpKeyOutWeb.ShortSDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="ShortEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/webseries_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.ShortEDate', document.pdpKeyOutWeb.ShortEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								<br/><br/>Attendance:<br/>
							</strong>
								<small>If you don't have a breakdown of attendees put total in Other category.</small><br/><br/>
							<!-- 
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesExt}" name="WebSeriesExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesNRCS}" name="WebSeriesNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesNGO}" name="WebSeriesNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesST}" name="WebSeriesST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesFarm}" name="WebSeriesFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesPro}" name="WebSeriesPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$WebSeriesAttOther}" name="WebSeriesAttOther" size="1" maxLength="3"/>&#160;&#160;
							-->
								<div class="floatL">
									<span>Extension</span>
									<br />
									<input id="WebSeriesExt" onkeypress="return numbersonly(event,false)" value="{$WebSeriesExt}" name="WebSeriesExt" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>NRCS</span>
									<br />
									<input id="WebSeriesNRCS" onkeypress="return numbersonly(event,false)" value="{$WebSeriesNRCS}" name="WebSeriesNRCS" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>NGO</span>
									<br />
									<input id="WebSeriesNGO" onkeypress="return numbersonly(event,false)" value="{$WebSeriesNGO}" name="WebSeriesNGO" size="1" maxLength="3" type="text" />
								</div>
								<div class="floatL">
									<span>Agency*</span>
									<br />
									<input id="WebSeriesST" onkeypress="return numbersonly(event,false)" value="{$WebSeriesST}" name="WebSeriesST" size="1" maxLength="3" type="text" />
								</div>
								<div class="floatL">
									<span>Farmer/Rancher</span>
									<br />
									<input id="WebSeriesFarm" onkeypress="return numbersonly(event,false)" value="{$WebSeriesFarm}" name="WebSeriesFarm" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>For Profit</span>
									<br />
									<input id="WebSeriesPro" onkeypress="return numbersonly(event,false)" value="{$WebSeriesPro}" name="WebSeriesPro" size="1" maxLength="3" type="text"/>
								</div>
								<div class="floatL">
									<span>Other</span>
									<br />
									<input id="WebSeriesAttOther" onkeypress="return numbersonly(event,false)" value ="{$WebSeriesAttOther}" name="WebSeriesAttOther" size="1" maxLength="3" type="text"/>
								</div>
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebSeriesAttDesc}" name="WebSeriesAttDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="webseriesDescription" name="webseriesDescription" style="width:100%">
								<!-- <xsl:value-of disable-output-escaping="yes" select="$WebSeriesDescription"/> -->
								<xsl:call-template name="break">
									<xsl:with-param name="text" select="$WebSeriesDescription"/>
								</xsl:call-template>
							</textarea><br/>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesMedia}" name="WebSeriesMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesProg}" name="WebSeriesProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesClient}" name="WebSeriesClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesConsult}" name="WebSeriesConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesDevel}" name="WebSeriesDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesFarmers}" name="WebSeriesFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesIncorp}" name="WebSeriesIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebSeriesOutOther}" name="WebSeriesOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebSeriesOutDesc}" name="WebSeriesOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
						</div>
					</td>
				</tr>
<!--
				<tr>
					<td>
						<div>
							 
							<h6>
								# of curricula : &#160;&#160;&#160;<INPUT type="text" onkeypress="return numbersonly(event,false)" value="{$WebCurricula}" name="WebCurricula" size="6" maxLength="10"/>
							</h6>
							
							<p>
								<strong>3) Web-Based Curricula</strong>&#160;&#160;&#160;<a href="javascript:;" onmousedown="toggleDiv('cdiv');">+/-</a>
							</p>
							<div class="wrapper" id="cdiv" style="display:none;margin-left:1em">
							<strong>Title:</strong><br/>
							<textarea id="webcurTitle" name="webcurTitle" rows="2" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$WebCurTitle"/>
							</textarea><br/>
							<strong>
								Start Date:&#160;<input name="InterSDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/webcur_start_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.InterSDate', document.pdpKeyOutWeb.InterSDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
								End Date (Optional):&#160;<input name="InterEDate" maxlength="12" size="7" value="{/SAREroot/pdpKeyOutWeb/webcur_end_date}"/>
								<a href="javascript:show_calendar4('document.pdpKeyOutWeb.InterEDate', document.pdpKeyOutWeb.InterEDate.value);">
									&#160;
									<img src="./images/cal.gif" border="0" alt="Click here to pick the date." align="absmiddle" WIDTH="16" HEIGHT="16"/>
								</a>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							</strong>
							<br/>
							<br/>
							<strong>
								<br/><br/>Attendance:<br/>
							</strong>
							Extension&#160;&#160;&#160;&#160;NRCS&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;NGO&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Agency*&#160;&#160;&#160;&#160;&#160;&#160;Farmer/Rancher&#160;For Profit&#160;&#160;&#160;&#160;&#160;&#160;Other<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurExt}" name="WebCurExt" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurNRCS}" name="WebCurNRCS" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurNGO}" name="WebCurNGO" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurST}" name="WebCurST" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurFarm}" name="WebCurFarm" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurPro}" name="WebCurPro" size="1" maxLength="3"/>&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value ="{$WebCurAttOther}" name="WebCurAttOther" size="1" maxLength="3"/>&#160;&#160;
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebCurAttDesc}" name="WebCurAttDesc" size="50" maxLength="50"/>
							<br/><small>* State, federal, or tribal agency</small>
							<br/><br/>
							<strong>Description of Activity and Learning Outcomes</strong><br/>
							<textarea id="webcurDescription" name="webcurDescription" rows="4" cols="80">
								<xsl:value-of disable-output-escaping="yes" select="$WebCurDescription"/>
							</textarea><br/>
							<strong>
								<br/><br/>Action Outcome(s):<br/>
							</strong>
							<small>Provide the number of educators and ag professionals that extended content from this activity in each of the following ways. “Number of farmers reached” refers to all producers who were reached as a result of this activity, and is requested for Northeast SARE reports only.</small><br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurMedia}" name="WebCurMedia" size="1" maxLength="3"/>&#160;Used this info in newsletters or other media outlets&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurProg}" name="WebCurProg" size="1" maxLength="3"/>&#160;Delivered new programming in this area
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurClient}" name="WebCurClient" size="1" maxLength="3"/>&#160;Used information to answer client question&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurConsult}" name="WebCurConsult" size="1" maxLength="3"/>&#160;Conducted individual consultation&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurDevel}" name="WebCurDevel" size="1" maxLength="3"/>&#160;Developed new contacts and partners for work&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurFarmers}" name="WebCurFarmers" size="1" maxLength="3"/>&#160;Number of farmers reached&#160;&#160;
							<br/>
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurIncorp}" name="WebCurIncorp" size="1" maxLength="3"/>&#160;Incorporated new ideas or info into regular&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
							<INPUT onkeypress="return numbersonly(event,false)" value="{$WebCurOutOther}" name="WebCurOutOther" size="1" maxLength="3"/>&#160;Other
							<br/>
							&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;programming or events
							<br/>
							If you entered "Other" please describe :&#160;<INPUT type="text" value="{$WebCurOutDesc}" name="WebCurOutDesc" size="50" maxLength="50"/>
							<br/><br/><br/>
						</div>
					</td>
				</tr>
-->				
				<tr>
					<td COLSPAN="4" nowrap="true">
						<xsl:choose>
							<xsl:when test="$pdpKeyWebID != 0">
								<input name="cmdPdpKeyOutWebUpdate" type="submit" value="Update"/>&#160;&#160;&#160;Click “Update” to update data on this page and return to the Initiative page.
								<br/><br/>
							<input name="cmdPdpKeyOutWebDelete" type="submit" value="Delete"/>&#160;&#160;&#160;Click “Delete” to delete data on this page and return to the Initiative page.
							<input type="hidden" name="DeleteID" value="{$pdpKeyWebID}"/>
						</xsl:when>
							<xsl:otherwise>
								<input name="cmdPdpKeyOutWebSave" type="submit" value="Save"/>&#160;&#160;&#160;Click “Save” to update data on this page and return to the Initiative page.
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

					<tr>
						<td>
							<input name="Back To Overview" onclick ="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'" type="button" value="Back To Overview"/>
						</td>
					</tr>
					
				</tr>

			</table>
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
