<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>

<xsl:param name="sortby">1</xsl:param>
<xsl:param name="startrecord">1</xsl:param>
<xsl:param name="maxrecords">5</xsl:param>
<xsl:param name="resultsperpage">5</xsl:param>
<xsl:param name="searchMode">searchprojprofile</xsl:param>
<xsl:param name="searchString"/>
<xsl:param name="searchType"/>
<xsl:param name="searchRegion"/>
<xsl:param name="searchState"/>
<xsl:param name="message"/>
<xsl:param name="message2"/>
<xsl:param name="searchmethod"/>
<xsl:variable name="thispage"><xsl:value-of select="ceiling($startrecord div $resultsperpage)"/></xsl:variable>
<xsl:variable name="lastpage"><xsl:value-of select="ceiling($maxrecords div $resultsperpage)"/></xsl:variable>

<xsl:template match="/">
  <html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
  <head>
	<script LANGUAGE="JavaScript">
	<![CDATA[
		//Stolen from http://www.harrymaugans.com/
        function toggleDiv(divid){
            if(document.getElementById(divid).style.display == 'none'){
                  document.getElementById(divid).style.display = 'block';	
				  document.getElementById(divid + '_label').innerHTML = '[-]';
            }else{
                  document.getElementById(divid).style.display = 'none';
				  document.getElementById(divid + '_label').innerHTML = '[+] (Search dialog collapses to display search results. Click  [+] to expand the search dialog fields and conduct a search.)';
            }
        }
		function myformaction()
		{
			document.projectSearch.action = '?do=searchcoord';
			document.projectSearch.submit();
		}
		function checkonload(divid)
		{
			var myval = window.location.href;
			if (myval.indexOf("q") == -1)
				return;
			else
				toggleDiv(divid);
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
</head>

<body  onLoad="javascript:checkonload('fulltextoptions');">
	<p>
		<xsl:if test="/SAREroot/user[@context='current']/firstname">
			<span class="pagetitle">
				<xsl:value-of select="/SAREroot/user[@context='current']/firstname"/>&#160;<xsl:value-of select="/SAREroot/user[@context='current']/lastname"/>'s MySARE
			</span>
			<br/>
			<br/>
		</xsl:if>
		<span class="pagetitle">Search Projects - Coordinator's Name</span>
		<P>
			<B>Search Options: </B><a href="?do=searchProj"> Full Text </a>| <a href="?do=searchprojprofile"> Advanced Keyword</a> | Coordinator Name
		</P>
		<p class="subtitle">
			Enter the project coordinator’s last name only and click Search.
		</p>
		<!-- 
		<table>
			<tablebody>
				<tr>
					<td>
						<p class="subtitle">
							For a search by the coordinator’s name, enter the project coordinator’s last name in the field below and click Search.
						</p>
					</td>
					<td>
						<div class="boxed" style="padding-left:12px;">
							<p>
								<b>Search Options</b>
							</p>
							<p>
								<li>
									<a href="?do=searchProj">Full Text</a>
								</li>
								<li>
									<a href="?do=searchprojprofile">Advanced Keyword</a>
								</li>
								<li>
									Coordinator Name
								</li>
							</p>
						</div>
					</td>
				</tr>
			</tablebody>
		</table>
		-->
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
		
		<a href="javascript:;" onmousedown="toggleDiv('fulltextoptions');toggleDiv('profileoptions');">
			<b>
				&#160;&#160;&#160;Search By Coordinator's Name<label id="fulltextoptions_label">[-]</label>
			</b>
		</a> 
		<p/>
		<div class="wrapper" id="fulltextoptions" style="margin-left:1em">
			<form action="javascript:myformaction();" method="post" name="projectSearch">
				
     <table style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0"><tablebody>		
       <tr>
         <td>Last Name Only: </td>
         <td><input name="Query" type="text" size="60" maxlength="255" value="{$searchString}"/></td>
       </tr>     
     </tablebody></table>
     <input name="projectSearch" type="submit" value="Search"/>&#160;&#160;&#160;&#160;&#160;
	 <xsl:if test="$searchString">
		<input type="button" value="Back" onclick="location.href='?do=searchProj'"/>
	 </xsl:if><br/><br/><!--
	 <b><a href="?do=searchprojprofile">Advanced Keyword Search</a></b><br/>
		<br/><a href="?do=searchProj"><b>Full Text Search</b></a>-->
  </form>
</div>
	<xsl:if test="$searchString">

		<span class="pagetitledown">Results</span>
		<br/>
		<br/>

		<table class="sortable" id="reports" style="text-align: left; width: 100%;" border="0" cellpadding="4" cellspacing="0">
  <tbody>
	
	  <tr>
		  <th style="text-align: left;">No.</th>
		  <th style="text-align: left; width: 15%;">Name</th>
		  <th style="text-align: left; width: 15%;">Project No.</th>
		  <th style="text-align: center; width: 35%;">Title</th>
		  <th style="text-align: left; width: 10%;">Region</th>
		  <th style="text-align: left; width: 8%;">Year</th>
		  <th style="text-align: left; width: 10%;">Type</th>
	  </tr>
	  
    <xsl:for-each select="/SAREroot/SAREgrant">
    <xsl:sort select="*[name()=$sortby]"/>
    <tr class="r1">
		<xsl:if test="position() mod 2 = 0">
			<td bgcolor="#D9D9F2">
				<xsl:value-of select="$startrecord + position() + (-1)"/>
			</td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 1">
			<td>
				<xsl:value-of select="$startrecord + position() + (-1)"/>
			</td>
		</xsl:if>

		
		<xsl:if test="position() mod 2 = 0">
			<td bgcolor="#D9D9F2">
				<xsl:value-of select="@regionText"/>, <xsl:value-of select="@typeText"/>
			</td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 1">
			<td>
				<xsl:value-of select="@regionText"/>, <xsl:value-of select="@typeText"/>
			</td>
		</xsl:if>
		
		<!-- <td><xsl:value-of select="$startrecord + position() + (-1)"/></td> -->
	  <xsl:if test="position() mod 2 = 0">
		  <td nowrap="true" bgcolor="#D9D9F2">
			  <xsl:choose>
				  <xsl:when test="/SAREroot/user">
					  <xsl:if test="@typeCode != '10'">
						  <a href="?do=editProj&amp;pn={@projNum}">
							  <xsl:value-of select="@projNum"/>
						  </a>
					  </xsl:if>
					  <xsl:if test="@typeCode = '10'">
						  <a href="?do=editPDP&amp;pn={@projNum}">
							  <xsl:value-of select="@projNum"/>
						  </a>
					  </xsl:if>
				  </xsl:when>
				  <xsl:otherwise>
					  <a href="?do=viewProj&amp;pn={@projNum}">
						  <xsl:value-of select="@projNum"/>
					  </a>
				  </xsl:otherwise>
			  </xsl:choose>			  
		  </td>
	  </xsl:if>

	  <xsl:if test="position() mod 2 = 1">
		  <td nowrap="true">
			  <xsl:choose>
				  <xsl:when test="/SAREroot/user">
					  <xsl:if test="@typeCode != '10'">
						  <a href="?do=editProj&amp;pn={@projNum}">
							  <xsl:value-of select="@projNum"/>
						  </a>
					  </xsl:if>
					  <xsl:if test="@typeCode = '10'">
						  <a href="?do=editPDP&amp;pn={@projNum}">
							  <xsl:value-of select="@projNum"/>
						  </a>
					  </xsl:if>
				  </xsl:when>
				  <xsl:otherwise>
					  <a href="?do=viewProj&amp;pn={@projNum}">
						  <xsl:value-of select="@projNum"/>
					  </a>
				  </xsl:otherwise>
			  </xsl:choose>
		  </td>
	  </xsl:if>

		<xsl:if test="position() mod 2 = 0">
		<td bgcolor="#D9D9F2">
      
		  <xsl:choose>
			  <xsl:when test="/SAREroot/user">
				  <xsl:if test="@typeCode != '10'">
					  <a href="?do=editProj&amp;pn={@projNum}">
						  <xsl:value-of select="title"/>
					  </a>
				  </xsl:if>
				  <xsl:if test="@typeCode = '10'">
					  <a href="?do=editPDP&amp;pn={@projNum}">
						  <xsl:value-of select="title"/>
					  </a>
				  </xsl:if>
			  </xsl:when>
			  <xsl:otherwise>
				  <a href="?do=viewProj&amp;pn={@projNum}">
					  <xsl:value-of select="title"/>
				  </a>
			  </xsl:otherwise>
		  </xsl:choose>
		  
      <xsl:if test="report"><br/></xsl:if>
      <xsl:for-each select="report">
      <xsl:sort select="@type"/>
      <xsl:if test="position()&gt;1">; </xsl:if>		  
		  <xsl:choose>
			  <xsl:when test="/SAREroot/user">
				  <a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">

					  <xsl:if test="@type=0">
						  <xsl:value-of select="@year"/> Annual Report
					  </xsl:if>
					  <xsl:if test="@type=1"> Final Report</xsl:if>
					  <xsl:if test="@type=2"> Proposal</xsl:if>
				  </a>
			  </xsl:when>
			  <xsl:otherwise>
				  <a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">

					  <xsl:if test="@type=0">
						  <xsl:value-of select="@year"/> Annual Report
					  </xsl:if>
					  <xsl:if test="@type=1"> Final Report</xsl:if>
					  <xsl:if test="@type=2"> Proposal</xsl:if>
				  </a>
			  </xsl:otherwise>
		  </xsl:choose>
      </xsl:for-each>
      </td>
	</xsl:if>


		<xsl:if test="position() mod 2 = 1">
		<td>
					<xsl:choose>
						<xsl:when test="/SAREroot/user">
							<xsl:if test="@typeCode != '10'">
								<a href="?do=editProj&amp;pn={@projNum}">
									<xsl:value-of select="title"/>
								</a>
							</xsl:if>
							<xsl:if test="@typeCode = '10'">
								<a href="?do=editPDP&amp;pn={@projNum}">
									<xsl:value-of select="title"/>
								</a>
							</xsl:if>
						</xsl:when>
						<xsl:otherwise>
							<a href="?do=viewProj&amp;pn={@projNum}">
								<xsl:value-of select="title"/>
							</a>
						</xsl:otherwise>
					</xsl:choose>

					<xsl:if test="report">
						<br/>
					</xsl:if>
					<xsl:for-each select="report">
						<xsl:sort select="@type"/>
						<xsl:if test="position()&gt;1">; </xsl:if>
						<xsl:choose>
							<xsl:when test="/SAREroot/user">
								<a href="?do=editRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">

									<xsl:if test="@type=0">
										<xsl:value-of select="@year"/> Annual Report
									</xsl:if>
									<xsl:if test="@type=1"> Final Report</xsl:if>
									<xsl:if test="@type=2"> Proposal</xsl:if>
								</a>
							</xsl:when>
							<xsl:otherwise>
								<a href="?do=viewRept&amp;pn={../@projNum}&amp;y={@year}&amp;t={@type}">

									<xsl:if test="@type=0">
										<xsl:value-of select="@year"/> Annual Report
									</xsl:if>
									<xsl:if test="@type=1"> Final Report</xsl:if>
									<xsl:if test="@type=2"> Proposal</xsl:if>
								</a>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</td>
			</xsl:if>		
		
  <xsl:variable name="regionCode" select="@regionCode"/>
		<xsl:if test="position() mod 2 = 0">
			<td bgcolor="#D9D9F2">
				<xsl:value-of select="/SAREroot/regions/region[regionCode = $regionCode]/name"/>
			</td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 1">
			<td><xsl:value-of select="/SAREroot/regions/region[regionCode = $regionCode]/name"/></td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 0">
			<td bgcolor="#D9D9F2">
				<xsl:value-of select="@year"/>
			</td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 1">
			<td><xsl:value-of select="@year"/></td>
		</xsl:if>
  <xsl:variable name="typeCode" select="@typeCode"/>
		<xsl:if test="position() mod 2 = 0">
			<td bgcolor="#D9D9F2">
				<xsl:value-of select="/SAREroot/projTypes/projType[typeCode = $typeCode]/name"/>
			</td>
		</xsl:if>
		<xsl:if test="position() mod 2 = 1">
		<td><xsl:value-of select="/SAREroot/projTypes/projType[typeCode = $typeCode]/name"/></td>
		</xsl:if>
    </tr>
    </xsl:for-each>
  </tbody>
  </table>
	
  <br/><center><xsl:call-template name="nav"/></center>
  </xsl:if>
  </body>
  </html>
</xsl:template>

<xsl:template match="profileoptions">
  <form method="post" name="profilesearch" action="?do=searchProjProfile">
  <div>
     <xsl:for-each select="profilecategory[@name='cata' or @name='catb' or @name='practices' or @name='commodities']">
       <xsl:call-template name="profilecategory"/>
       <p/>
     </xsl:for-each>
     <xsl:for-each select="profilecategory[@name='inv' or @name='aud' or @name='techlvl']">
       <xsl:call-template name="profilecategory"/>
       <p/>
     </xsl:for-each>
  </div>

  <br/>
  <input type="submit" value="Search by Keyword" name="profileSearch" ID="profileSearch"/><br/>
  <input type="reset" value="Reset Form" name="cmdReset" ID="cmdReset"/><br/>
  <input type="submit" value="Cancel" name="cmdCancel" ID="cmdCancel"/>
  
  </form>

</xsl:template>

<xsl:template name="nav">
      <xsl:param name="count">1</xsl:param>
      <xsl:choose>
        <xsl:when test="$count &lt; ($lastpage + 1)">
          <xsl:choose>
            <xsl:when test="($count=$thispage) and ($lastpage != 1)">
              <b><xsl:value-of select="$count"/></b><xsl:text>&#160;</xsl:text>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
            <xsl:when test="$count &lt; $thispage">
              <xsl:choose>
                <xsl:when test="$count=1">
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:choose>
                    <xsl:when test="$count &lt; ($thispage - 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:when test="$count &gt; ($thispage - 6)">
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>&#160;</xsl:text>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a><xsl:text>...</xsl:text>
                </xsl:when>
              </xsl:choose>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
            <xsl:when test="$count &gt; $thispage">
              <xsl:choose>
                <xsl:when test="$count=$lastpage">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                </xsl:when>
                <xsl:when test="$count &lt; ($thispage + 6)">
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                  <xsl:if test="$count &lt; ($thispage + 5)">&#160;</xsl:if>
                </xsl:when>
                <xsl:when test="($count mod 10) = 0">
                  <xsl:choose>
                    <xsl:when test="$count &gt; ($thispage + 5)">...</xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$count}"><xsl:value-of select="$count"/></a>
                </xsl:when>
              </xsl:choose>
              <xsl:call-template name="nav">
                <xsl:with-param name="count" select="$count + 1"/>
              </xsl:call-template>
            </xsl:when>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
          <br/>
          <xsl:if test="$thispage &gt; 1"><a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$thispage - 1}">&lt;&lt; Previous</a>&#160;&#160; </xsl:if>
          <xsl:if test="$thispage &lt; $lastpage">&#160;&#160;<a href="?do={$searchMode}&amp;q={$searchString}&amp;amp;searchmethod={$searchmethod}&amp;region={$searchRegion}&amp;state={$searchState}&amp;projType={$searchType}&amp;sortby={$sortby}&amp;page={$thispage + 1}">Next &gt;&gt;</a></xsl:if>
        </xsl:otherwise>
      </xsl:choose>
  </xsl:template>

<xsl:template name="profilecategory">
  <xsl:variable name="catname" select="@name"/>
  <xsl:variable name="type" select="@type"/>

  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

      <b><a href="javascript:;" onmousedown="toggleDiv(&apos;{$label}&apos;);">Search on <xsl:value-of select="$label"/>&#160;<label id="{$label}_label">[+]</label></a></b>
      <div class="wrapper" id="{$label}" style="display:none;margin-left:1em">
<!--
      <xsl:if test="@sublabel != ''">
        <i><xsl:value-of select="@sublabel"/></i><br/>
      </xsl:if>
-->
      <xsl:choose>
      <xsl:when test="$type = 'radio'">
        <xsl:for-each select="profileoption">
          <xsl:call-template name="radio">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
          <br/>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>
        <xsl:for-each select="profileoption">
          <xsl:call-template name="profoption">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
          <br/>
        </xsl:for-each>
        <xsl:for-each select="profilesubcat">
          <xsl:call-template name="profilesubcat">
            <xsl:with-param name="catname" select="$catname"/>
          </xsl:call-template>
        </xsl:for-each>
      </xsl:otherwise>
      </xsl:choose>
      </div>

</xsl:template>

<xsl:template name="profilesubcat">
  <xsl:param name="catname"/>
  <xsl:variable name="subcatname" select="@name"/>

  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

  <b><a href="javascript:;" onmousedown="toggleDiv(&apos;{@name}&apos;);"><xsl:value-of select="$label"/>&#160;<label id="{@name}_label">[+]</label></a></b><br/>
  <div class="wrapper" id="{@name}" style="display:none;margin-left:1em">
  <xsl:for-each select="profileoption">
      <span class="profoption">
      <xsl:call-template name="optionsub">
        <xsl:with-param name="catname" select="$catname"/>
        <xsl:with-param name="subcatname" select="$subcatname"/>
      </xsl:call-template>
      </span>
  </xsl:for-each>
  </div>
</xsl:template>

<xsl:template name="radio">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="chosen"><xsl:value-of select="/SAREroot/profile/profilecategory[@name = $catname]/profileoption[@priority='1']/@name"/></xsl:variable>

  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

  <xsl:choose>
  <xsl:when test="$optionname = 'other' and $value !=''">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="$label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value="{$value}"/>
  </xsl:when>
  <xsl:when test="$optionname = 'other'">
    <input type="radio" name="{$catname}" value="{$optionname}"/><xsl:value-of select="$label"/>&#160;
    <input type="text" name="{$catname}_{$optionname}" value=""/>
  </xsl:when>
  <xsl:when test="$chosen = $optionname">
    <input type="radio" name="{$catname}" value="{$optionname}" checked="'checked'"/><xsl:value-of select="$label"/>
  </xsl:when>
  <xsl:otherwise>
    <input type="radio" name="{$catname}" value="{$optionname}"/><xsl:value-of select="$label"/>
  </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="option">
<!-- Generates an option to go in the drop-down list -->
  <xsl:param name="selected"/> <!-- value of the currently selected option -->
  <xsl:param name="value"/>  <!-- value of the option to be created -->
  <xsl:param name="label"/> <!-- label of the option to be created -->
  <xsl:choose>
    <xsl:when test="$selected=$value">
     <option value="{$value}" selected="selected"><xsl:value-of select="$label"/></option>
    </xsl:when>
    <xsl:otherwise>
      <option value="{$value}"><xsl:value-of select="$label"/></option>
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="profoption">
  <xsl:param name="catname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$catname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="$label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

<xsl:template name="optionsub">
  <xsl:param name="catname"/>
  <xsl:param name="subcatname"/>
  <xsl:variable name="optionname" select="@name"/>
  <xsl:variable name="fieldname"><xsl:value-of select="$subcatname"/>_<xsl:value-of select="$optionname"/></xsl:variable>
  <xsl:variable name="value"><xsl:value-of select="/SAREroot/profile/profilecategory[@name=$catname]/profilesubcat[@name=$subcatname]/profileoption[@name=$optionname]/@value"/></xsl:variable>
  <xsl:variable name="label">
  <xsl:choose>
  <xsl:when test="@searchlabel">
    <xsl:value-of select="@searchlabel"/>
  </xsl:when>
  <xsl:otherwise>
    <xsl:value-of select="@label"/>
  </xsl:otherwise>
  </xsl:choose>
  </xsl:variable>

    <xsl:choose>
      <xsl:when test="@type='other'">
        <!-- <input type="checkbox" name="{$fieldname}"/> -->other:&#160;
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
      <xsl:when test="@type='bit' and $value='True'">
        <input type="checkbox" name="{$fieldname}" checked="yes"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="(@type='bit') and ($value!='True')">
        <input type="checkbox" name="{$fieldname}"/>
        <xsl:value-of select="$label"/>&#160;
      </xsl:when>
      <xsl:when test="@type='int' or @type='string'">
        <xsl:value-of select="$label"/>&#160;:
        <input type="text" name="{$fieldname}" value="{$value}"/>
      </xsl:when>
    </xsl:choose>
</xsl:template>

</xsl:stylesheet>









