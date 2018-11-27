<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">	
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="message"/>
<xsl:param name="message2"/>

<xsl:template match="/">

	<script LANGUAGE="JavaScript">
		<![CDATA[
			function openWindow(url, name) {
				var l = openWindow.arguments.length;
				var w = "";
				var h = "";
				var features = "";

				for (i=2; i<l; i++) {
					var param = openWindow.arguments[i];

					if ( (parseInt(param) == 0) ||
			(isNaN(parseInt(param))) ) {
						features += param + ',';
					}
					else {
						(w == "") ? w = "width=" + param + "," : h =
			"height=" + param;
					}
				}

				features += w + h;
				var code = "popupWin = window.open(url, name";
				if (l > 2) code += ", '" + features;
				code += "')";
				eval(code);
				popupWin.focus();
			}
			
			function limitWords(id) {
				var maxWords=300;
				var d=document.getElementById(id);
				if ( d.value.split(' ').length > maxWords ) {
					t=d.value.substring(0,d.value.lastIndexOf(' '));
					d.value=t.substring(0,t.lastIndexOf(' ')+1);
				}
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
	
	<xsl:variable name="pdpOutID" select="/SAREroot/pdpOutNarr/@pdp_out_id"/>
	<xsl:variable name="projNum" select="/SAREroot/pdpOutNarr/@proj_num"/>
	<xsl:variable name="OutNarrSummary" select="/SAREroot/pdpOutNarr/out_summary"/>
	<xsl:variable name="OutNarrDesc" select="/SAREroot/pdpOutNarr/out_desc"/>
	<xsl:variable name="OutNarrOther" select="/SAREroot/pdpOutNarr/out_other"/>
	
	
	<p>
		<span class="pagetitle">Report Summary</span>
	</p>
	<p>Use the boxes below to summarize your activities and results.   Include examples of project outcomes :
		<blockquote><li>If we want to provide an example with percents, can we please define the percentage, and maybe give examples that are a bit more robust?<br/>E.g. 75 of the 100 trainees (75%) increased their knowledge of cover crop species and mixtures of species, their contributions to soil fertility and soil health, suitability in row crops and vegetable plantings, and techniques for establishment and management.</li></blockquote>
		<blockquote><li>15 of the 30 participants subsequently held their own trainings, reaching 125 farmers.</li></blockquote>
	</p>
	<form id="pdpinit" name="pdpinit" method="post">
	<table>
		<tr>
			<td colspan="2"/>
		</tr>

		<tr>
			<td COLSPAN="4" nowrap="true">
				Provide a summary of how things have gone during the reporting period (300 word limit) :
			</td>
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">
				<textarea id="outNarrSum" name="outNarrSum" style="width:100%"  onkeyup="limitWords(this.id)">
					<!-- <xsl:value-of disable-output-escaping="yes" select="$OutNarrSummary"/> -->
					<xsl:call-template name="break">
						<xsl:with-param name="text" select="$OutNarrSummary"/>
					</xsl:call-template>
				</textarea>
			</td>
		</tr>
		
		<tr>
			<td COLSPAN="4" nowrap="true">
				<br/><br/>Were/are there any unanticipated outcomes/issues that resulted from this SARE funded project so far? (Please list them):</td>
		</tr>
		<tr>
			<td COLSPAN="4" nowrap="true">
				<textarea id="outNarrOutcomes" name="outNarrOutcomes" style="width:100%">
					<!-- <xsl:value-of disable-output-escaping="yes" select="$OutNarrDesc"/> -->
					<xsl:call-template name="break">
						<xsl:with-param name="text" select="$OutNarrDesc"/>
					</xsl:call-template>
				</textarea>
			</td>						
		</tr>
		
	<tr>
		<td COLSPAN="4" nowrap="true">
			<br/><br/>Other comments: 
		</td>
	</tr>
	<tr>
		<td COLSPAN="4" nowrap="true">
			<textarea id="ourNarrOther" name="ourNarrOther" style="width:100%">
				<!-- <xsl:value-of disable-output-escaping="yes" select="$OutNarrOther"/> -->
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="$OutNarrOther"/>
				</xsl:call-template>
			</textarea>
		</td>
	</tr>

		<tr>
			<xsl:choose>
				<xsl:when test="$pdpOutID != 0">
					<td>
						Click “Update” to update your report and return to the overview page.  Click Cancel to return to the overview page without saving.
					</td>
				</xsl:when>
				<xsl:otherwise>
					<td>
						Click “Save” to save your report and return to the overview page.  Click Cancel to return to the overview page without saving.
					</td>
				</xsl:otherwise>
			</xsl:choose>
		</tr>
		<tr>
			<xsl:choose>
				<xsl:when test="$pdpOutID != 0">
					<td COLSPAN="4" nowrap="true">
						<input name="cmdPdpOurNarrUpdate" type="submit" value="Update"/>&#160;&#160;
						<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'"/>
					</td>
				</xsl:when>
				<xsl:otherwise>
					<td COLSPAN="4" nowrap="true">
						<input name="cmdPdpOurNarrSave" type="submit" value="Save"/>
						&#160;&#160;
						<INPUT type="button" name="btnCancel" id="btnCancel" value="Cancel" onClick="window.location.href='sare_main.aspx?do=editPdp&amp;pn={$projNum}'"/>
					</td>
				</xsl:otherwise>
			</xsl:choose>							
		</tr>
	</table>

		<p>
			<table BORDER="5" id="projoverview" bgcolor="#EEE8AA" WIDTH="100%">
				
					<tr>
						<td>
							<p class="pagetitle">Project Attachments:</p>
						</td>
					</tr>
					<tr>

						<td>
							Use this section to upload additional information about the initiative such as photos; flyers, agendas, participant surveys and results from activities/milestone events; travel scholarship and mini-grant follow-up reports. Note: Do not upload educational publications or training materials produced here.  Those items belong in the Information Products section.
							<!--
							<span class="tooltiptext">
								<a href="/mysare/help/editRept.htm#assign" target="_blank">
									<h3>Assign Project Code</h3>
								</a>
								<p>
									&#160;
								</p>
								<p>
									Use this feature to assign a new project code to a pi or co-pi that has not yet claimed his or her project. Persons who claim a project will be listed as a coordinator in the general information section. Do NOT assign new project codes to pis that have already claimed their project- they can access the project by logging into their MySARE account and clicking My Projects.
								</p>
							</span>-->
							<br/>
							<xsl:for-each select="/SAREroot/pdpAttachments/list">
								<br/>
								<a href="javascript:openWindow(unescape('./assocfiles/{$pdpOutID}{attachment_title}'),'fileupload','400','300','scrollbars','resizable');">
									<xsl:value-of select="attachment_caption" disable-output-escaping="yes"/>
								</a>&#160;&#160;&#160;&#160;
								<input type="button" value="Delete File" onclick="javascript:openWindow('fileUpload.aspx?projNum=$projNum&amp;fileid={attachment_id}&amp;order=777','fileupload','640','480','scrollbars','resizable');"/>
							</xsl:for-each>
							<br/>
							<button type="submit" name="fileUp" id="fileUp" value="fileUp" onclick="javascript:openWindow('fileUpload.aspx?suid={$pdpOutID}&amp;projNum={$projNum}&amp;order=777&amp;title=','fileupload','600','300','scrollbars','resizable');">Add Attachment</button>
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