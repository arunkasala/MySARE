<?xml version="1.0" encoding="utf-8"?>

<!-- DWXMLSource="testProject.xml" -->

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

	<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"/>

	<xsl:param name="reptsection">0</xsl:param>

	<xsl:param name="reptsubsection">0</xsl:param>

	<xsl:param name="reptisnew">0</xsl:param>

	<xsl:param name="formreferrer">sare_main.aspx?do=mygrants</xsl:param>

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

function checkfiles(filesize, text) 
		{
			if (filesize == 0)
				return true;
			else
			{
				if (text.length == 0)
				{
					alert('This section must include text that describes the uploaded files.');
					return false;
				}
				else
				{
					return true;
				}				
			}
		}

]]>

		</script>

		<!-- <script src="//tinymce.cachefly.net/4.0/tinymce.min.js"></script>-->

		<script language="JavaScript" src="./tinymce/tinymce.min.js"/>

		<script type="text/javascript">

			tinymce.init({

			selector: "textarea",

			plugins: [

			"advlist lists charmap hr anchor pagebreak ",

			"searchreplace paste nonbreaking"

			],

			toolbar1: "bold italic underline | bullist numlist | outdent indent | removeformat | subscript superscript | charmap | cut copy paste",

			menubar: false,

			toolbar_items_size: 'small',

			statusbar : true,

			height: "200",

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

		<xsl:choose>

			<xsl:when test="$reptsection=0">

				<xsl:apply-templates mode="full" select="SAREroot"/>

			</xsl:when>

			<xsl:otherwise>

				<xsl:apply-templates mode="partial" select="SAREroot"/>

			</xsl:otherwise>

		</xsl:choose>

	</xsl:template>

	<xsl:template match="/SAREroot" mode="full">

		<xsl:apply-templates mode="full" select="SAREgrant">

		</xsl:apply-templates>

	</xsl:template>

	<xsl:template match="/SAREroot" mode="partial">

		<xsl:apply-templates mode="partial" select="SAREgrant"/>

	</xsl:template>

	<xsl:template match="textTypes" mode="list">

		<xsl:param name="chosenType">2</xsl:param>

		<xsl:param name="sectionID">16</xsl:param>

		<xsl:param name="subheadingID">1</xsl:param>

		<select name="listParagraphType{$sectionID}subtype{$subheadingID}" id="listParagraphType{$sectionID}subtype{$subheadingID}" size="1">

			<xsl:apply-templates mode="list" select="textType">

				<xsl:sort data-type="number" order="ascending" select="typeCode"/>

				<xsl:with-param name="chosenType" select="$chosenType"/>

			</xsl:apply-templates>

		</select>

	</xsl:template>

	<xsl:template match="textType" mode="list">

		<xsl:param name="chosenType">1</xsl:param>

		<xsl:variable name="thisType" select="typeCode"/>

		<xsl:choose>

			<xsl:when test="$chosenType=$thisType">

				<option selected="selected" value="{typeCode}">
					<xsl:value-of select="name"/>
				</option>

			</xsl:when>

			<xsl:otherwise>

				<option value="{typeCode}">
					<xsl:value-of select="name"/>
				</option>

			</xsl:otherwise>

		</xsl:choose>

	</xsl:template>

	<xsl:template match="SAREgrant" mode="full">

		<span class="pagetitle">
			<xsl:value-of select="@projNum"/>: <xsl:value-of select="title"/>
		</span>
		<br/>

		<span class="pagetitle">

			<xsl:if test="report[@type = 2]"> Proposal Overview</xsl:if>

			<xsl:if test="report[@type = 0]">
				<xsl:value-of select="report/@year"/> Annual Report
			</xsl:if>

			<xsl:if test="report[@type = 1]">
				<xsl:value-of select="report/@year"/> Final Report
			</xsl:if>

		</span>

		<br/>
		<br/>

		<xsl:choose>

			<xsl:when test="report[@type = 2]">

				<!--

			<xsl:text disable-output-escaping="yes"><![CDATA[

				<a href="help/editRept.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )">Report Editor Instructions <img
				src="./images/help.png" border="0" /></a>

				<div class="highslide-html-content" id="highslide-html" style="width: 300px">

   				  <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">

					<a href="#" onclick="return hs.close(this)" class="control">Close</a>

  				  </div>

				<div class="highslide-body"></div>

				</div>

			]]></xsl:text>

			-->

				<b>Report Editor Instructions</b> &#160;

				<span class="tooltiptext">

					<a href="/mysare/help/editRept.htm#instructions" target="_blank">

						<h3>Report Editor Instructions</h3>

					</a>

					<p>

						&#160;

					</p>

					<p>

						<b>Overview</b><br/><br/>

						This editor is designed to act as an easy-to-use interface for creating or modifying a SARE report.

					</p>

					<p>

						<b>Submission Options</b>

						<br/>

						<br/>

						<ul>

							<li>

								<b>Save</b> - Save your current changes

							</li>

							<li>

								<b>Save and Preview</b> - Save your changes and preview them in the report viewer

							</li>

							<li>

								<b>Cancel</b> - Return to the project overview page without saving current changes

							</li>

						</ul>

					</p>

					<p>

						<b>Upload Files</b><br/><br/>

						<p>Maximum upload size is 30 Mb for documents and 140 Mb for media files. <a href="http://bit.ly/1wsd7MG" target="_blank">Tips for reducing image and file size.</a></p>
						<p><b>Allowable File Types:</b> Documents(.doc,.docx,.pdf,.rtf)  Figures (ppsx,.ppt,.pptx) Tables (.xls,.xlsx), Images (.gif,.jpeg,.jpg,.png)  Video (.asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt) and audio (.au,.mp3)</p>


					</p>

				</span>

			</xsl:when>

			<xsl:otherwise>

				<!--

			<xsl:text disable-output-escaping="yes"><![CDATA[

				<a href="help/editreport.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )">Report Editor Instructions <img
				src="./images/help.png" border="0" /></a>

				<div class="highslide-html-content" id="highslide-html" style="width: 400px">

				<div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">

					<a href="#" onclick="return hs.close(this)" class="control">Close</a>

				</div>

				<div class="highslide-body"></div>

				</div><br/>

			]]></xsl:text>

			-->

				<b>Report Editor Instructions</b> &#160;

				<span class="tooltiptext">

					<a href="/mysare/help/editreport.htm#instructions" target="_blank">

						<h3>Report Editor Instructions</h3>

					</a>

					<p>

						&#160;

					</p>

					<p>

						<b>Overview</b><br/><br/>

						This editor is designed to act as an easy-to-use interface for creating or modifying a SARE report. Based on the current project details and report type, the editor will
						automatically create an outline suitable for your specific report. The editor provides  multiple controls for modifying the order and display type of subsections within
						these headings.

					</p>

				</span>

			</xsl:otherwise>

		</xsl:choose>

		<form method="post" action="{$formreferrer}" name="reportform">

			<xsl:choose>

				<xsl:when test="$reptisnew = 1">

					<xsl:variable name="formID" select="'createreport'"/>

					<input type="hidden" name="formID" value="{$formID}"/>

					<p class="subtitle">You can create new reports for a project by entering all required fields in form. You have options like Submit for Approval, Save Without Submitting, Save and Preview.</p>

				</xsl:when>

				<xsl:otherwise>

					<xsl:variable name="formID" select="'editreport'"/>

					<input type="hidden" name="formID" value="{$formID}"/>

					<xsl:if test="report[@type = 2]">

						<p class="subtitle">
							Use this page to describe your project. Simply cut and paste the text from your grant proposal into the appropriate boxes below. You can also upload files (tables,
							figures, etc.) to support your text.
						</p>

					</xsl:if>

					<xsl:if test="report[@type = 0]">

						<p class="subtitle">
							Use this page to submit your annual project report. Simply cut and paste the text from your word processor into the appropriate boxes below. You can also upload files
							(tables, figures, etc.) to support your text.
						</p>

					</xsl:if>

					<xsl:if test="report[@type = 1]">

						<p class="subtitle">
							Use this page to submit your final project report. Simply cut and paste the text from your word processor into the appropriate boxes below. You can also upload files
							(tables, figures, etc.) to support your text.
						</p>

					</xsl:if>

				</xsl:otherwise>

			</xsl:choose>

			<!--

  <form action="" method="post" name="reportform">

  <input type="hidden" name="formID" value="reportform"/>

 -->

			<br/>

			<table>

				<xsl:apply-templates mode="full" select="report">

				</xsl:apply-templates>

				<tr>

					<xsl:if test="/SAREroot/SAREgrant/report[@type = 1 or @type = 0]">

						<td>

							<input name="btnSubmit" id="btnSubmit" type="submit" value="Submit"/>

						</td>

					</xsl:if>

					<td>

						<xsl:if test="/SAREroot/SAREgrant/report[@type = 1 or @type = 0]">

							<input type="submit" name="btnSave" id="btnSave" value="Save Without Submitting"/>

						</xsl:if>

						<xsl:if test="/SAREroot/SAREgrant/report[@type = 2]">

							<input type="submit" name="btnSave" id="btnSave" value="Save"/>

						</xsl:if>

					</td>

					<td nowrap="true">

						<button type="submit" name="saveandpreview" id="saveandpreview" value="saveandpreview">Save and Preview</button>

					</td>

					<!-- <input name="Reset" type="reset" value="Undo most recent changes"/>  -->

					<td>

						<input name="main" onclick ="window.location.href='sare_main.aspx?do=editProj&amp;pn={/SAREroot/SAREgrant/@projNum}'" type="button" value="Cancel"/>

					</td>

					<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">

						<td>

							<INPUT type="submit" name="cmdDeleteReport" id="cmdDeleteReport" value="Delete Report"/>

						</td>

					</xsl:if>

					<td/>

				</tr>
				
				
			</table>

			<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/editreport.htm#submit" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img
    src="../images/help.png" border="0" /></a>]]></xsl:text> -->
			Note: Submitting or saving a report will delete all files uploaded to sections with no text. Each section must include text that describes related uploaded files.
		</form>

	</xsl:template>

	<xsl:template match="report" mode="full">

		<tr>

			<td colspan="5">

				<xsl:apply-templates mode="full" select="section">

					<xsl:sort select="@order" data-type="number" order="ascending"/>

				</xsl:apply-templates>

				<p/>

			</td>

		</tr>

		<tr>

			<xsl:if test="/SAREroot/user/userroles/role[@code='admin' or @code='natAdmin' or @code='regAdmin']">

				<td width="10%">

					<xsl:choose>

						<xsl:when test="@approvedstatus = 'True'">

							<input name="approved" type="checkbox" checked="true" value="true"/>

						</xsl:when>

						<xsl:otherwise>

							<input name="approved" type="checkbox" value="true"/>

						</xsl:otherwise>

					</xsl:choose>

					Approved<br/>

				</td>

				<td colspan="3" width="20%"/>

				<td width="10%">

					<input name="confDel" type="checkbox" value="true"/>

					Confirm Delete

				</td>

				<td/>

			</xsl:if>

		</tr>

	</xsl:template>

	<xsl:template match="section" mode="full">

		<xsl:variable name="sectionname" select="name"/>

		<xsl:variable name="sectionID" select="@ID"/>

		<b>
			<!--<xsl:value-of select="@order" />: -->
			<xsl:value-of select="$sectionname"/>
			<!--(<xsl:value-of select="$sectionID" />)-->
		</b>
		<br/>

		<xsl:apply-templates mode="full" select="subsection">

			<xsl:sort select="@order" data-type="number" order="ascending"/>

		</xsl:apply-templates>

	</xsl:template>

	<xsl:template match="subsection" mode="full">

		<xsl:variable name="sectionname" select="../name"/>

		<xsl:variable name="sectionID" select="../@ID"/>

		<xsl:variable name="subheading" select="heading"/>

		<xsl:variable name="subheadingID" select="@order"/>

		<xsl:variable name="text" select="text"/>

		<!--<xsl:value-of select="@order" />-->

		<xsl:if test="/SAREroot/SAREgrant/report[@type = 1 or @type = 0]">

			<p/>Subsection Header (Optional)<br/>

			<input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>

			<br/>

			<p/>

			<!--

		  <xsl:apply-templates mode="list" select="/SAREroot/textTypes">

			  <xsl:with-param name="chosenType" select="@type"/>

			  <xsl:with-param name="sectionID" select="$sectionID"/>

			  <xsl:with-param name="subheadingID" select="$subheadingID"/>

		  </xsl:apply-templates>&#160;&#160;-->

			<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/editreport.htm#texttypes" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img
		  src="./images/help.png" border="0" /></a>]]></xsl:text> -->

			<!--

		  <span class="tooltiptext">

			  <a href="/mysare/help/editreport.htm#texttypes" target="_blank">

				  <h3>Subsection Types</h3>

			  </a>

			  <p>

				  &#160;

			  </p>

			  <p>

				  The subsection type dropdown box controls how the section's text will be displayed when the report

				  is converted to a printable format.  Each text section can only support one format, so you may need to create additional text blocks to enter separate lists, paragraphs, etc.

				  The available display modes and examples of their use are as follows.

				  <ul>

					  <li>

						  <b>Paragraph</b>

					  </li>

					  <li>

						  <b>Bulleted List</b>

					  </li>

					  <li>

						  <b>Numbered List</b>

					  </li>

					  <li>

						  <b>Quote Block</b>

					  </li>

					  <li>

						  <b>Unindented Paragraph</b>

					  </li>

				  </ul>

			  </p>

		  </span>

		  <br/>

		  -->

		</xsl:if>

		<table>
			<tablebody>
				<tr>

					<td>

						<textarea name="section{$sectionID}subtext{$subheadingID}" style="width:100%">

							<xsl:choose>

								<xsl:when test="@type = '1'">

									<ul>

										<xsl:call-template name="splitByLine">

											<xsl:with-param name="str" select="$text"/>

											<xsl:with-param name="type" select="@type"/>

										</xsl:call-template>

									</ul>

								</xsl:when>

								<xsl:when test="@type='2'">

									<ol>

										<xsl:call-template name="splitByLine">

											<xsl:with-param name="str" select="$text"/>

											<xsl:with-param name="type" select="@type"/>

										</xsl:call-template>

									</ol>

								</xsl:when>

								<xsl:otherwise>

									<!-- <xsl:value-of disable-output-escaping="yes" select="$text"/> -->
									<xsl:apply-templates select="text">
										<xsl:with-param name="textType" select="@type"/>
										<!-- pass param "title" to matching templates -->
									</xsl:apply-templates>

								</xsl:otherwise>

							</xsl:choose>

						</textarea>

					</td>

					<xsl:if test="/SAREroot/SAREgrant/report[@type = 1 or @type = 0]">

						<td nowrap="true">

							<!--

				<button type="submit" name="section{$sectionID}moveup{$subheadingID}" value="section{$sectionID}moveup{$subheadingID}">Move This Up</button><br/>

				<button type="submit" name="section{$sectionID}movedown{$subheadingID}" value="section{$sectionID}movedown{$subheadingID}">Move This Down</button><br/>

				 -->

							<!--   <button type="submit" name="section{$sectionID}insert{$subheadingID}" value="section{$sectionID}insert{$subheadingID}">Insert Subsection Below</button><br/> -->

							<!-- To allow delete only for new created subsection but not for default subsections -->

							<xsl:if test="$subheadingID &gt; 1 and $subheadingID &lt; 100">

								<!-- <button type="submit" name="section{$sectionID}delete{$subheadingID}" value="section{$sectionID}delete{$subheadingID}">Delete Subsection</button> -->

								<br/>

								<br/>

							</xsl:if>

						</td>

					</xsl:if>

				</tr>
			</tablebody>
		</table>

		<button type="submit" name="saveandstay" id="saveandstay" value="saveandstay">Save Text</button>

		&#160;&#160;Save all changes on this page.<br/>

		<xsl:choose>

			<xsl:when test="@uid=0">

				Enter text above and click "Save Text" to upload files for this section.

			</xsl:when>

			<xsl:otherwise>

				<button type="submit" name="fileUp" id="fileUp" value="fileUp" onclick="javascript:openWindow('fileUpload.aspx?suid={@uid}&amp;order={./fileset/@size +
				  1}','fileupload','600','300','scrollbars','resizable');">Upload File</button>&#160;&#160;Upload tables, graphs, photos, audio and/or video files to support your text. Links to
				the files will be displayed in your report at the end of each section. (Once a file is uploaded, click the file name to view the file or click Edit/Delete File to delete the
				file or edit the file caption.)

				<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/editreport.htm#upload" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType:
				  'ajax'} )"><img src="./images/help.png" border="0" /></a>]]></xsl:text> -->

				<span class="tooltiptext">

					<a href="/mysare/help/editreport.htm#upload" target="_blank">

						<h3>Upload Files</h3>

					</a>

					<p>

						&#160;

					</p>

					<p>Maximum upload size is 30 Mb for documents and 140 Mb for media files. <a href="http://bit.ly/1wsd7MG" target="_blank">Tips for reducing image and file size.</a></p>
					<p><b>Allowable File Types:</b> Documents(.doc,.docx,.pdf,.rtf)  Figures (ppsx,.ppt,.pptx) Tables (.xls,.xlsx), Images (.gif,.jpeg,.jpg,.png)  Video (.asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt) and audio (.au,.mp3)</p>

				</span>

			</xsl:otherwise>

		</xsl:choose>

		<!--

        <a href="javascript:openWindow('fileUpload.aspx?suid={@uid}&amp;order={./fileset/@size + 1}','fileupload','600','300','scrollbars','resizable');">Upload file</a>

-->

		<br/>

		<xsl:apply-templates mode="full" select="fileset"/>

		<p/>

	</xsl:template>

	<xsl:template match="fileset" mode="full">

		<xsl:apply-templates mode="full" select="file">

			<xsl:sort select="@order" order="ascending"/>

		</xsl:apply-templates>

	</xsl:template>

	<xsl:template match="file" mode="full">

		<br/>

		<!--

  <a href="javascript:openWindow(unescape('./assocfiles/{name}'),'fileupload','400','300','scrollbars','resizable');">

  <xsl:choose>

    <xsl:when test="(@displaymode = 1 or @displaymode = 2) and @mimetype = 'image/jpeg'">

      <img src="./assocfiles/tn_{name}" border="1"/>

      <br/>

    </xsl:when>

  </xsl:choose>

  <xsl:value-of select="position()"/>: <xsl:value-of select="caption"/>&#160;&#160;<xsl:value-of select="name/@original" disable-output-escaping="yes"/>

  </a>

  -->

		<xsl:choose>

			<xsl:when test="@mimetype = 'audio/wav'">
				<img src="./images/audio.png" border="1"/>
				<br/>
				<a href="javascript:openWindow(unescape('http://media.ifas.ufl.edu/sare/{name}'),'fileupload','400','300','scrollbars','resizable');">

					<xsl:value-of select="position()"/>: <xsl:value-of select="caption"/>&#160;&#160;<xsl:value-of select="name/@original" disable-output-escaping="yes"/>

				</a>

			</xsl:when>

			<xsl:when test="@mimetype = 'video/x-ms-asf' or @mimetype = 'video/x-msvideo' or @mimetype = 'video/quicktime' or @mimetype = 'video/mp4' or @mimetype = 'video/mpeg' or @mimetype =
		  'video/quicktime'">
				<img src="./images/video.png" border="1"/>
				<br/>
				<a href="javascript:openWindow(unescape('http://ifasgallery.ifas.ufl.edu/sare/{name}'),'fileupload','400','300','scrollbars','resizable');">

					<xsl:value-of select="position()"/>: <xsl:value-of select="caption"/>&#160;&#160;<xsl:value-of select="name/@original" disable-output-escaping="yes"/>

				</a>

			</xsl:when>

			<xsl:otherwise>

				<a href="javascript:openWindow(unescape('./assocfiles/{name}'),'fileupload','400','300','scrollbars','resizable');">

					<xsl:choose>

						<xsl:when test="(@displaymode = 1 or @displaymode = 2) and @mimetype = 'image/jpeg'">

							<img src="./assocfiles/tn_{name}" border="1"/>

							<br/>

						</xsl:when>
						<xsl:otherwise>
							<img src="./images/document.png" border="1"/>
							<br/>
						</xsl:otherwise>

					</xsl:choose>

					<!-- <xsl:value-of select="position()"/>: --><xsl:value-of select="caption"/>&#160;&#160;<xsl:value-of select="name/@original" disable-output-escaping="yes"/>

				</a>

			</xsl:otherwise>

		</xsl:choose>

		<!--

	  <a href="javascript:openWindow('fileUpload.aspx?suid={../../@uid}&amp;fileid={@fileID}&amp;order={@order}','fileupload','640','480','scrollbars','resizable');">

		  &#160;&#160;Edit/Delete File

	  </a>-->&#160;&#160;<input type="button" value="Edit/Delete File" onclick="javascript:openWindow('fileUpload.aspx?suid={../../@uid}&amp;fileid={@fileID}&amp;order=
	  {@order}','fileupload','640','480','scrollbars','resizable');"/>

		<!--

	  <xsl:choose>

	  <xsl:when test="position() = 1">

		  &#160;&#160;&#160;&#8681;<a href="javascript:openWindow('fileUpload.aspx?move=true&amp;suid={../../@uid}&amp;fileid={@fileID}&amp;order={position() +
		  1}','fileupload','640','480','scrollbars','resizable');">Down</a>

	  </xsl:when>

	  <xsl:when test="position() = last()">

		  &#160;&#160;&#160;&#8679;<a href="javascript:openWindow('fileUpload.aspx?move=true&amp;suid={../../@uid}&amp;fileid={@fileID}&amp;order={position() -
		  1}','fileupload','640','480','scrollbars','resizable');">Up</a>

	  </xsl:when>

	  <xsl:when test="position() > 1 and position() != last()">

		  &#160;&#160;&#160;&#8679;<a href="javascript:openWindow('fileUpload.aspx?move=true&amp;suid={../../@uid}&amp;fileid={@fileID}&amp;order={position() -
		  1}','fileupload','640','480','scrollbars','resizable');">Up</a>

		  &#160;&#160;&#160;&#8681;<a href="javascript:openWindow('fileUpload.aspx?move=true&amp;suid={../../@uid}&amp;fileid={@fileID}&amp;order={position() +
		  1}','fileupload','640','480','scrollbars','resizable');">Down</a>

	  </xsl:when>

	  </xsl:choose>

	  -->

	</xsl:template>

	<xsl:template match="SAREgrant" mode="partial">

		<span class="pagetitle">
			<xsl:value-of select="title"/>
		</span>
		<br/>
		<br/>

		<xsl:choose>

			<xsl:when test="report[@type = 2]">

				<!--

			  <xsl:text disable-output-escaping="yes"><![CDATA[

				<a href="help/editRept.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )">Report Editor Instructions <img
				src="./images/help.png" border="0" /></a>

				<div class="highslide-html-content" id="highslide-html" style="width: 300px">

   				  <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">

					<a href="#" onclick="return hs.close(this)" class="control">Close</a>

  				  </div>

				<div class="highslide-body"></div>

				</div>

			]]></xsl:text>

			-->

				<b>Report Editor Instructions</b> &#160;

				<span class="tooltiptext">

					<a href="/mysare/help/editRept.htm#instructions" target="_blank">

						<h3>Report Editor Instructions</h3>

					</a>

					<p>

						&#160;

					</p>

					<p>

						<b>Overview</b><br/><br/>

						This editor is designed to act as an easy-to-use interface for creating or modifying a SARE report.

					</p>

					<p>

						<b>Submission Options</b>

						<br/>

						<br/>

						<ul>

							<li>

								<b>Save</b> - Save your current changes

							</li>

							<li>

								<b>Save and Preview</b> - Save your changes and preview them in the report viewer

							</li>

							<li>

								<b>Cancel</b> - Return to the project overview page without saving current changes

							</li>

						</ul>

					</p>

					<p>

						<b>Upload Files</b><br/><br/>

						<p>Maximum upload size is 30 Mb for documents and 140 Mb for media files. <a href="http://bit.ly/1wsd7MG" target="_blank">Tips for reducing image and file size.</a></p>
						<p><b>Allowable File Types:</b> Documents(.doc,.docx,.pdf,.rtf)  Figures (ppsx,.ppt,.pptx) Tables (.xls,.xlsx), Images (.gif,.jpeg,.jpg,.png)  Video (.asf,.asx,.avi,.mov,.mp4,.mpeg,.mpg,.qt) and audio (.au,.mp3)</p>


					</p>

				</span>

			</xsl:when>

			<xsl:otherwise>

				<!--

			  <xsl:text disable-output-escaping="yes"><![CDATA[

				<a href="help/editreport.htm#instructions" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )">Report Editor Instructions <img
				src="./images/help.png" border="0" /></a>

				<div class="highslide-html-content" id="highslide-html" style="width: 400px">

				<div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">

					<a href="#" onclick="return hs.close(this)" class="control">Close</a>

				</div>

				<div class="highslide-body"></div>

				</div><br/>

			]]></xsl:text>

			-->

				<b>Report Editor Instructions</b> &#160;

				<span class="tooltiptext">

					<a href="/mysare/help/editreport.htm#instructions" target="_blank">

						<h3>Report Editor Instructions</h3>

					</a>

					<p>

						&#160;

					</p>

					<p>

						<b>Overview</b><br/><br/>

						This editor is designed to act as an easy-to-use interface for creating or modifying a SARE report. Based on the current project details and report type, the editor
						will automatically create an outline suitable for your specific report. The editor provides  multiple controls for modifying the order and display type of subsections
						within these headings.

					</p>

				</span>

			</xsl:otherwise>

		</xsl:choose>

		<br/>

		<xsl:value-of select="@projNum"/>

		<form action="?do=submitRept" method="post" name="reportform">

			<xsl:apply-templates mode="partial" select="report/section">

			</xsl:apply-templates>

			<p/>

			<input name="Submit" type="submit" value="Submit"/>

			<input name="Save" type="submit" value="Save Without Submitting"/>

			<input name="Cancel" type="button" value="Cancel Changes"/>

			<!-- <xsl:text disable-output-escaping="yes"><![CDATA[<a href="help/editreport.htm#submit" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'ajax'} )"><img
    src="../images/help.png" border="0" /></a>]]></xsl:text> -->

		</form>

	</xsl:template>

	<xsl:template match="section" mode="partial">

		<xsl:if test="@ID=$reptsection">

			<xsl:variable name="sectionname" select="name"/>

			<xsl:variable name="sectionID" select="@ID"/>

			<b>
				<!--<xsl:value-of select="@order" />: -->

				<xsl:value-of select="$sectionname"/>
				<!--(<xsl:value-of select="$sectionID" />)-->
			</b>
			<br/>

			<xsl:choose>

				<xsl:when test="$reptsubsection=0">

					<xsl:apply-templates mode="full" select="subsection">

						<xsl:sort select="@order" data-type="number" order="descending"/>

					</xsl:apply-templates>

				</xsl:when>

				<xsl:otherwise>

					<xsl:apply-templates mode="partial" select="subsection">

						<xsl:sort select="@order" data-type="number" order="descending"/>

					</xsl:apply-templates>

				</xsl:otherwise>

			</xsl:choose>

		</xsl:if>

	</xsl:template>

	<xsl:template match="subsection" mode="partial">

		<xsl:if test="@order=$reptsubsection">

			<xsl:variable name="sectionname" select="../name"/>

			<xsl:variable name="sectionID" select="../@ID"/>

			<xsl:variable name="subheading" select="heading"/>

			<xsl:variable name="subheadingID" select="@order"/>

			<!--<xsl:value-of select="@order" />-->

			<xsl:variable name="text" select="text"/>

			<p/>Header (Optional)<br/>

			<input name="section{$sectionID}subheading{$subheadingID}" type="text" value="{$subheading}" size="50" maxlength="255"/>

			<br/>

			<p/>Text<br/>

			<textarea name="section{$sectionID}subtext{$subheadingID}" style="width:100%">

				<xsl:value-of disable-output-escaping="yes" select="$text"/>

			</textarea>

			<p/>

		</xsl:if>

	</xsl:template>

	<xsl:template name="splitByLine">

		<xsl:param name="str"/>

		<xsl:param name="type"/>

		<xsl:param name="count">1</xsl:param>

		<xsl:variable name="strLength">

			<xsl:value-of select="string-length($str)"/>

		</xsl:variable>

		<xsl:variable name="strTrimmed">

			<!-- trim the extra line breaks for the next iteration -->

			<xsl:choose>

				<xsl:when test="substring($str, $strLength, 1) = '&#10;'">

					<xsl:value-of select="substring($str, 1, ($strLength - 1))"/>

					<br/>

				</xsl:when>

				<xsl:otherwise>

					<xsl:value-of disable-output-escaping="yes" select="substring($str, 1, $strLength)"/>

					<br/>

				</xsl:otherwise>

			</xsl:choose>

		</xsl:variable>

		<xsl:variable name="thisText">

			<!-- set the text to be used on this iteration, depends on if it is the last time -->

			<xsl:choose>

				<xsl:when test="contains($str,'&#10;')">

					<xsl:value-of disable-output-escaping="yes" select="substring-before($str,'&#10;')"/>

					<br/>

				</xsl:when>

				<xsl:otherwise>

					<xsl:value-of select="$str"/>

					<br/>

				</xsl:otherwise>

			</xsl:choose>

		</xsl:variable>

		<xsl:choose>

			<xsl:when test="$type='0'">

				<xsl:if test="string-length($thisText) &gt; 1">

					&#160; &#160; &#160; <xsl:value-of select="$thisText"/>&#160;<br/>

				</xsl:if>

			</xsl:when>

			<xsl:when test="$type='1'">

				<xsl:if test="string-length($thisText) &gt; 1">

					<li>

						<xsl:value-of select="$thisText"/>

					</li>

				</xsl:if>

			</xsl:when>

			<xsl:when test="$type='2'">

				<xsl:if test="string-length($thisText) &gt; 1">

					<li>

						<xsl:value-of disable-output-escaping="yes" select="$thisText"/>

					</li>

				</xsl:if>

				<!--       <xsl:value-of select="$count"/>.&#160; &#160;  &#160; <xsl:value-of select="$thisText"/><br/> -->

			</xsl:when>

			<xsl:when test="$type='3'">

				<xsl:if test="string-length($thisText) &gt; 1">

					<blockquote>

						<xsl:value-of select="$thisText"/>

					</blockquote>

				</xsl:if>

			</xsl:when>

			<xsl:when test="$type='4'">

				<xsl:if test="string-length($thisText) &gt; 1">

					<xsl:value-of select="$thisText"/>&#160;<br/>

				</xsl:if>

			</xsl:when>

		</xsl:choose>

		<xsl:if test="contains($str,'&#10;')">

			<xsl:call-template name="splitByLine">

				<xsl:with-param name="str">

					<xsl:choose>

						<!-- eliminate double line breaks -->

						<xsl:when test="substring-before($strTrimmed,'&#10;') = substring-before($strTrimmed,'&#10;&#10;')">

							<xsl:value-of select="substring-after($strTrimmed, '&#10;&#10;')"/>

							<br/>

						</xsl:when>

						<xsl:otherwise>

							<xsl:value-of disable-output-escaping="yes" select="substring-after($strTrimmed, '&#10;')"/>

							<br/>

						</xsl:otherwise>

					</xsl:choose>

				</xsl:with-param>

				<xsl:with-param name="type" select="$type"/>

				<xsl:with-param name="count" select="$count+1"/>

			</xsl:call-template>

		</xsl:if>

	</xsl:template>

	<xsl:template match="text">
		<xsl:param name="textType"/>
		<xsl:choose>
			<xsl:when test="$textType = '0'">
				<xsl:call-template name="break">
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:call-template name="break_new">
				</xsl:call-template>
			</xsl:otherwise>
		</xsl:choose>

	</xsl:template>

	<xsl:template name="break">
		<xsl:param name="text" select="."/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<!--<br/> This is commented to fix extra break adding for html data tinymce -->
				<xsl:call-template name="break">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="break_new">
		<xsl:param name="text" select="."/>
		<xsl:choose>
			<xsl:when test="contains($text, '&#xa;')">
				<xsl:value-of disable-output-escaping="yes" select="substring-before($text, '&#xa;')"/>
				<br/>
				<!--This is commented to fix extra break adding for html data tinymce -->
				<xsl:call-template name="break_new">
					<xsl:with-param name="text" select="substring-after($text,'&#xa;')"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of disable-output-escaping="yes" select="$text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

</xsl:stylesheet>

