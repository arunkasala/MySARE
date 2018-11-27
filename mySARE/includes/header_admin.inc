<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en-US" lang="en-US"> 
<head> 
																																				
  <style type="text/css">
        .style
        {
            border-color: Black;
            border-width: 1px;
            border-spacing: 2px;
            border-style: outset;
            border-collapse: separate;
            background-color: #AAC9FC;
            font-family: Verdana;
            font-size: 10px;
        }
</style>

<script language="javascript" type="text/javascript">
    var checkTimerID;
    var clockID = 0;
    function UpdateClock() {
        var lblValue;
        if (clockID) {
            clearTimeout(clockID);
            clockID = 0;
        }
        if (document.getElementById('divSessionExpirationPopUp').style.display == 'inline') {
            if (navigator.appName == 'Netscape') {
                document.getElementById('lblTime').innerHTML = document.getElementById('lblTime').innerHTML - 1;
                lblValue = document.getElementById('lblTime').innerHTML;
            }
            else {
                document.getElementById('lblTime').innerText = document.getElementById('lblTime').innerText - 1;
                lblValue = document.getElementById('lblTime').innerText;
            }
        }
        if ((lblValue == -1) && (document.getElementById('divSessionExpirationPopUp').style.display == 'inline')) {
            document.getElementById('divSessionExpirationPopUp').style.display = 'none';
            var urlString = unescape(window.location);
            window.location = urlString
        }
        clockID = setTimeout('UpdateClock()', 1000);
    }
    function StartClock() {
        document.getElementById('divOpacity').style.display = 'inline';
        document.getElementById('divSessionExpirationPopUp').style.display = 'inline';
        clockID = setTimeout('UpdateClock()', 0);
    }
 
    function SignOut() {
        window.location = 'login.aspx';
    }
   
    function GetExtendedSessionMessageUsingCallBack()
    {
        document.getElementById('divOpacity').style.display = 'none';
        document.getElementById('divSessionExpirationPopUp').style.display = 'none';
        document.getElementById('lblTime').innerHTML = 10;
        var checkTimerID;
        checkTimerID = setTimeout('StartClock()', (60000));  //60 minutes
       
    }

</script>

<script language="javascript" type="text/javascript">


    var http;
    try {
        http = new ActiveXObject("Microsoft.XMLHTTP");
    }
    catch (e) {
        http = new XMLHttpRequest();
    }
    function updateData()
     {
         var myurl = "http://sare.org/MySare/refesh_session.aspx";

        http.open("GET", myurl, true);
        http.onreadystatechange = useHttpResponse;
        http.send(null);
     
    }
    function useHttpResponse() {
        if (http.readyState == 4) {
            var textout = http.responseText;
            GetExtendedSessionMessageUsingCallBack();

        }
    }

</script>

					
<style type="text/css"> 
.limitdisplay-user { display: none; }.limitdisplay-user-10 { display: inline; }.limitdisplay-user-block-10 { display: block; }</style> 
                      
    <title>MySARE</title>
 
    
    
                <meta name="Content-Type" content="text/html; charset=utf-8" /> 
 
            <meta name="Content-language" content="en-US" /> 
 
    
            <meta name="author" content="eZ Systems" /> 
                <meta name="copyright" content="eZ Systems" /> 
                <meta name="description" content="Content Management System" /> 
                <meta name="keywords" content="cms, publish, e-commerce, content management, development framework" /> 
        
    <meta name="MSSmartTagsPreventParsing" content="TRUE" /> 
    <meta name="generator" content="eZ Publish" /> 
    
<link rel="Home" href="http://www.sare.org/index.php" title="SARE front page" /> 
<link rel="Index" href="http://www.sare.org/index.php" /> 
<link rel="Top"  href="http://www.sare.org/index.php" title="Project Reports / SARE Nationwide - SARE" /> 
<link rel="Search" href="http://www.sare.org/index.php/content/advancedsearch" title="Search SARE" /> 
<link rel="Shortcut icon" href="http://www.sare.org/extension/site/design/site/images/favicon.png" type="image/x-icon" /> 
<link rel="apple-touch-icon" href="http://www.sare.org/extension/site/design/site/images/favicon-iphone.png"  type="image/x-icon" /> 
<link rel="Copyright" href="http://www.sare.org/index.php/ezinfo/copyright" /> 
<link rel="Author" href="http://www.sare.org/index.php/ezinfo/about" /> 
<link rel="Alternate" type="application/rss+xml" title="RSS" href="http://www.sare.org/index.php/rss/feed/my_feed" /> 
<link rel="Alternate" href="http://www.sare.org/index.php/layout/set/print/Project-Reports" media="print" title="Printable version" /> 
<link rel="stylesheet" type="text/css" href="http://files.thinkcreative.com/reset.css" media="all" charset="utf-8" />

<link rel="stylesheet" type="text/css" href="http://www.sare.org/design/standard/stylesheets/debug.css" media="all" charset="utf-8" />

<link rel="stylesheet" type="text/css" href="http://www.sare.org/extension/ezwt/design/standard/stylesheets/websitetoolbar.css" media="all" charset="utf-8" />

<link rel="stylesheet" type="text/css" href="http://www.sare.org/extension/site/design/site/stylesheets/jquery.tools.css" media="all" charset="utf-8" />

<link rel="stylesheet" type="text/css" href="http://www.sare.org/extension/site/design/site/stylesheets/main.css" media="all" charset="utf-8" />

<link rel="stylesheet" type="text/css" href="http://www.sare.org/extension/site/design/site/stylesheets/print.css" media="print" /> 
 
 
<!--[if lte IE 7]>
<link rel="stylesheet" type="text/css" href="http://www.sare.org/extension/site/design/site/stylesheets/main-ie.css" media="screen" />
<![endif]--> 
 
<!--[if lt IE 7]>
 
<script src="http://ie7-js.googlecode.com/svn/version/2.0(beta3)/IE7.js" type="text/javascript"></script>
<script type="text/javascript" src="http://www.sare.org/extension/addedbyus/design/standard/javascript/supersleight.js"></script>
<![endif]--> 
 
 
<script type="text/javascript" src="http://code.jquery.com/jquery-1.4.2.min.js" charset="utf-8"></script>

<script type="text/javascript" src="http://files.thinkcreative.com/jquery.tools_1.2.5_all.min.js" charset="utf-8"></script>

<script type="text/javascript" src="http://files.thinkcreative.com/cufon-yui.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/ezflow/design/ezflow/javascript/insertmedia.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/phpicalendar/design/standard/javascript/phpicalendar/sessvars.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/htmlmap/design/standard/javascript/jquery.htmlmap.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/htmlmap/design/standard/javascript/htmlmap.usamap.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/site/design/site/javascript/jquery.cycle.min.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/site/design/site/javascript/main.js" charset="utf-8"></script>

<script type="text/javascript" src="http://www.sare.org/extension/site/design/site/javascript/agenda.font.js" charset="utf-8"></script>

 
      <script type="text/javascript" src="./ajax/sortable.js"></script>

      <script type="text/javascript" src="includes/tc_adapt.js" charset="utf-8"></script>
      <link rel="stylesheet" type="text/css" href="includes/tc_adapt.css" media="all" charset="utf-8" />
      
      <script language=JavaScript>     
      function printPartOfPage(elementId)
      {
       var printContent = document.getElementById(elementId);
       var printWindow = window.open('', '', 'left=50000,top=50000,width=0,height=0');
      
       printWindow.document.write(printContent.innerHTML);
       printWindow.document.close();
       printWindow.focus();
       printWindow.print();
       printWindow.close();
      }
      </script>


</head> 
 
<body class="national"> 

<!-- Google Tag Manager -->
<noscript><iframe src="//www.googletagmanager.com/ns.html?id=GTM-TCCK29"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-TCCK29');</script>
<!-- End Google Tag Manager -->

<div id='divSessionExpirationPopUp' style='position: absolute; z-index: 10000; height: 300px; width: 100%; left: 70px; top: 250px; display: none;'>
	<br />
	<table class='style' align='center' valign='middle' width='30%'>
		<tr align='center' valign='middle'>
			<td align='center' valign='top'>
				<img src='Alert1.jpg' />
				</td>
				<td align='left' valign='middle'>
					<br />
					<span>
						<b>Your Session will expire</b>
						<br />
					</span>
					<span>
						<b>in</b>
					</span>
					<span id='lblTime'></span>
					<span>
						<b>sec and you will be </b>
						<br />
					</span>
					<span>
						<b>logged out.</b>
					</span>
					<br />
					<br />
					<a href="javascript:void('0');" onclick="javascript:updateData();">
						Click here to stay
						logged in.
					</a>
					<br />
					<br />
					<a href='#' onclick='javascript:SignOut();'>Click here to Sign Out.</a>
					<br />
					<br />
				</td>
			</tr>
		</table>
		
</div>
<div id='divOpacity' style='position: absolute; top: 0; left: 0; z-index: 90; width: 100%; height: 1000px; background-color: #A3A5A9; filter: alpha(opacity=60); -moz-opacity: 0.6; opacity: 0.6; display: none'>
</div>

<div class="grad national"> 
 
<div id="webpage" class="extrainfo section_id_1 current_node_id_104 subpage mod_name_content mod_view_view full"> 
 
	
<div id="site-header"> 
	<a id="logo" href="http://www.sare.org/"><img rel="images/logo-national.gif" src="http://www.sare.org/extension/site/design/site/images/logos/sare-national.gif" alt="" /></a> 
	<img id="tagline" src="http://www.sare.org/extension/site/design/site/images/tagline.gif" alt="" /> 
	<div id="head-nav-search"> 
		<ul class="menu horizontal"> 
					<li><a href="http://www.sare.org/SARE-Webstore">Webstore</a><span class="delimiter"> |</span></li> 
					<li><a href="http://www.sare.org/Advanced-Search">Advanced Search</a><span class="delimiter"> |</span></li> 
					<li><a href="http://www.sare.org/mySARE/sare_main.aspx">MySARE Login</a><span class="delimiter"> |</span></li> 					
					<li><a href="http://www.sare.org/Contact-Us">Contact Us</a><span class="delimiter"> |</span></li> 
					<li><a href="http://www.sare.org/Learning-Center/SANET-Listserv">SANET Listserv</a><span class="delimiter"> |</span></li> 
					<li><a href="http://www.sare.org/Social-Media">Social Media</a><span class="delimiter"> |</span></li> 
					<li><a href="http://low.sare.org">Low Bandwidth</a><span class="delimiter"></span></li> 
				</ul> 
		<div id="lang-search">		<a id="site_ncsare-flag" href="http://www.sare.org/switchlanguage/to/site_ncsare/Project-Reports" title="English">English</a>		<a id="es_ncsare-flag" href="http://www.sare.org/switchlanguage/to/es_ncsare/Project-Reports" title="Espa�ol">Espa�ol</a>			<form action="http://www.sare.org/content/search" method="get" class="search-f"> 
				<input type="hidden" name="SubTreeArray" value="99,2003,4528" /> 
				<fieldset> 
					<input id="searchtext" type="text" name="SearchText" value="Search all SARE Sites" /> 
					<input class="search-btn" type="image" value="" alt="" src="http://www.sare.org/extension/site/design/site/images/search-btn.gif" /> 
					
					<a href="http://sare.org/MySare/ProjectReport.aspx?do=searchprojprofile" class="adv-search">Search MySARE Reports</a> 
				</fieldset> 
			</form> 
		</div><!-- lang-search --> 
	</div><!-- head-nav-search --> 
</div><!-- site-header --> 
 
	
	<ul id="global-menubar" class="menu horizontal"> 
			
			
												<li class="first menubar"><span><a title="Information about SARE grants"  class="nav-link" href="http://www.sare.org/Grants">Grants</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="folderfolder"><a title="Information about SARE grants "  class="subnav-link" href="http://www.sare.org/Grants/Grants-Information">Grants Information</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Grants/Grant-Summaries-by-State">Grant Summaries by State</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/Project-Reports">Project Reports</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Project-Reports/Submit-a-Report">Submit a Report</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://mysare.sare.org/mySARE/ProjectReport.aspx?do=search">Search SARE Projects</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Project-Reports/Project-Search-Tips">Project Search Tips</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Project-Reports/About-Project-Reports">About Project Reports</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Project-Reports/About-Search-Results">About Search Results</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Learning-Center/Project-Products">Project Products</a></li> 
																																						</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/Learning-Center">Learning Center</a></span> 
 
												
					<div class="subnav two-col"> 
						<div class="subnav-wrp"> 
						<ul> 
																																														
								
																
																	<li class="folderfolder"><a title="SARE-produced books based on latest research"  class="subnav-link" href="http://www.sare.org/Learning-Center/Books">Books</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Topical, how-to reports based on latest research and SARE results"  class="subnav-link" href="http://www.sare.org/Learning-Center/Bulletins">Bulletins</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Topical fact sheets on best practices and latest research"  class="subnav-link" href="http://www.sare.org/Learning-Center/Fact-Sheets">Fact Sheets</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Profiles of successful SARE projects"  class="subnav-link" href="http://www.sare.org/Learning-Center/From-the-Field">From the Field</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Learning-Center/Newsletters">Newsletters</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Videos of SARE grantees and projects, audio clips, PowerPoint presentations and more"  class="subnav-link" href="http://www.sare.org/Learning-Center/Multimedia">Multimedia</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Online and print-version courses for ag professionals."  class="subnav-link" href="http://www.sare.org/Learning-Center/Courses-and-Curricula">Courses and Curricula</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Grantee-produced curricula, manuals, fact sheets and other information products."  class="subnav-link" href="http://www.sare.org/Learning-Center/Project-Products">Project Products</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Biennial reports of SARE projects and activities."  class="subnav-link" href="http://www.sare.org/Learning-Center/SARE-Biennial-Reports">SARE Biennial Reports</a></li> 
																			</ul><ul>															
								
																
																	<li class="folderfolder"><a title="Listserv discussions covering the gamut of sustainable agriculture topics."  class="subnav-link" href="http://www.sare.org/Learning-Center/SANET-Listserv">SANET Listserv</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Materials about SARE: brochures, program overviews, displays, presentations and more."  class="subnav-link" href="http://www.sare.org/Learning-Center/SARE-Program-Materials">SARE Program Materials</a></li> 
																																		
								
																
																	<li class="folderfolder"><a title="Materials from SARE conferences, meetings and workshops."  class="subnav-link" href="http://www.sare.org/Learning-Center/Conference-Materials">Conference Materials</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/Professional-Development">Professional Development</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
					
<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Professional-Development/PDP-Overview">PDP Overview</a></li> 
																																														
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Professional-Development/Sample-PDP-Grant-Projects">Sample PDP Grant Projects</a></li> 
																																		
								
																
																											
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Professional-Development/Educator-Curriculum-Guides">Educator Curriculum Guides</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Learning-Center/Courses-and-Curricula/National-Continuing-Education-Program">National Continuing Education Program</a></li> 

<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/State-Programs/State-Coordinator-Contact-Information">State Coordinator Contact Information</a></li> 
																																
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/State-Programs">State Programs</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/State-Programs/State-Sustainable-Agriculture-Programs">State Coordinator Program Overview</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/State-Programs/State-Coordinator-Contact-Information">State Coordinator Contact Information</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/State-Programs/Grant-Summaries-by-State">Grant Summaries by State</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/Events">Events</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="multicalendarfolder"><a  class="subnav-link" href="http://www.sare.org/Events/Event-Calendar">Event Calendar</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Events/Past-Conferences">Past Conferences</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Events/Educational-Sponsorships">Educational Sponsorships</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li><span><a  class="nav-link" href="http://www.sare.org/Newsroom">Newsroom</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Newsroom/Press-Releases">Press Releases</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Newsroom/Media-Contacts">Media Contacts</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Newsroom/Newsletters">Newsletters</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Newsroom/Media-Toolkit">Media Toolkit</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/Newsroom/A-Guide-To-This-Site">A Guide To This Site</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Social-Media" target="_blank">SARE and Social Media</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
								
			
												<li class="last menubar"><span><a  class="nav-link" href="http://www.sare.org/About-SARE">About SARE</a></span> 
 
												
					<div class="subnav"> 
						<div class="subnav-wrp"> 
						<ul> 
																											
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/SARE-s-Four-Regions">SARE's Four Regions</a></li> 																																	
								
																						
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Grants">SARE Grants</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Learning-Center">Learning Center</a></li> 
																																		
								
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Professional-Development">Professional Development</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/SARE-Outreach">SARE Outreach</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/Historical-Timeline">Historical Timeline</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/Staff">Staff</a></li> 
																																		
								
																
																	<li class="folderfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/Vision-Mission">Vision &amp; Mission</a></li> 
																																		
								<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/About-SARE/Join-Our-Mailing-List" target="_blank">Join Our Mailing List</a></li> 
																
																	<li class="linkfolder"><a  class="subnav-link" href="http://www.sare.org/Learning-Center/SARE-Program-Materials/National-Program-Materials/What-is-Sustainable-Agriculture">What is Sustainable Agriculture?</a></li> 
																			</ul> 
						</div><!-- subnav-wrp --> 
					</div><!-- subnav --> 
										
			</li> 
							</ul> 
 
 
 
	
<div id="site-columns"> 
 
			
<div class="top-bar"> 
	<ul class="breadcrumbs menu horizontal"> 
						<li><a href="http://www.sare.org/">Home</a><span class="delimiter">&raquo;</span></li> 
								<li>MySARE</li> 
				</ul> 
	<div class="tools" id="printdiv"> 
		<div class="font-size"> 
			<a href="#" class="smaller-fs">-</a> 
			<a href="#" class="bigger-fs">+</a> 
			<span class="fs">Font Size</span> 
		</div> 
		<!-- <a href="#" onclick="javascript:window.print();return false;" class="print">Print</a>  -->
		
		
		
		<!-- AddThis Button BEGIN --> 
		<div class="addthis_toolbox addthis_default_style"> 
			<a href="http://www.addthis.com/bookmark.php?v=250&amp;username=ar5236" class="addthis_button_compact">Share</a> 
		</div> 
		<script type="text/javascript">var addthis_config = {"data_track_clickback":true};</script> 
		<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=ar5236"></script> 
		<!-- AddThis Button END --> 
		
		<!-- AddThis Button END --> 
 
	</div> 
</div> 
 

<div id="sidebar"> 						 
	<div class="sidenav"> 
	
	<ul class="menu vertical">
		<li class="first menubar">
			<span>
				<a  class="nav-link" href="./sare_main.aspx">My Main Page</a>
			</span> 
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=userlist">Search Users</a>
			</span>
		</li>
	</ul> 
	<!--
	<a  class="nav-link" href="./sare_main.aspx?do=adminProj"><b>Administer Reports</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;</a><br/>-->
	<ul class="menu vertical"> 
		<li class="first menubar">			
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=adminProj">Admininster Reports</a>
			</span>					
		</li> 
		<li>			
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=MyProj">My Projects</a>
			</span>					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=claimProj">Retrieve New Project</a>
			</span> 					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=claimPDP">Retrieve New State Report</a>
			</span> 					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=newgrant">Create Project</a>
			</span> 					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=newpdp">Create State Report</a>
			</span> 					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=deleteProj">Delete Project</a>
			</span> 					
		</li> 
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=MyProj">Submit a Project Report</a>
			</span>				
		</li> 
	</ul>
	<!--
	<a  class="nav-link" href="http://mysare.sare.org/mySARE/sare_main.aspx?do=searchProj"><b>Search Projects</b><img src="../images/navarrow.gif" width="14" height="8"  border="0"/>&#160;</a><br/> -->
	<ul class="menu vertical"> 
		<li class="first menubar">
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=searchProj">Search Projects</a>
			</span>					
		</li> 
		
		
		<li>
			<span>
				<a  class="nav-link" href="./sare_main.aspx?do=logout">Logout</a>
			</span>					
		</li> 	
	</ul>	
</div> 



<div id="feedback-box" class="module infobox"> 
	<div class="infobox-content"> 
		<p>Can&#39;t find something? Ask or send <a href="http://www.sare.org/Website-Help">feedback</a>.</p> 
	</div> 
</div> 
<div id="sare-mission" class="module infobox"> 
	<div class="infobox-content"> 
		<p> 
			<span>SARE&#39;s mission</span> is to advance&ndash;to the whole of American agriculture&ndash;innovations that improve profitability, stewardship and quality of life by investing in groundbreaking research and education. 
			<a href="http://www.sare.org/About-SARE/Vision-Mission" id="" title="" target="_self">SARE&#39;s vision is...</a> 
		</p> 
	</div> 
</div>			</div> 

          <div id="site-main-content">
            <div class="content-view-full class-folder">
            