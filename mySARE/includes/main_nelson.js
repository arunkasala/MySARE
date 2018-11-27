if(typeof(console)!='undefined'){window.alert=console.log;}
// Cufon text replacement
	Cufon.replace('#global-menubar li a.nav-link', {hover:true});
	Cufon.replace('.tabs.vertical li a');
	Cufon.replace('.module.infobox h2')('.attribute-header h1')('#site-main-content h2',{fontSize:'24px'})('.attribute-long h2',{fontSize:'24px'});
	Cufon.replace('.cufon');
	Cufon.replace('.cufoned');
	Cufon.replace('#site-main-content h3')('#site-main-content h4',{fontSize:'20px'})('#site-main-content h5',{fontSize:'18px'})('#site-main-content h6',{fontSize:'16px'})('.attribute-article-index h2')('.section h2');
	Cufon.replace('.content-view-line .attribute-title h5',{fontSize:'24px'});
	Cufon.replace('#cal_outer_wrapper h1')('#cal_month_majors h2');
	
function sifr_stuff() {
	Cufon.refresh('#cal_month_majors h2');
}

$htmlmap.initialize({
//	'scheme':'usamap',
	'load':function(){
//		console.log('html initialize: callback function');
	}
});

(function($){
	
	$(".class-publication table[border='2']").css("border", "2px solid #edead9");
	
	return $AJAXSearch={
		'siteURL':'',
		'target':false,
		'ajax':function($options){
			$options.dataType='text';
			$.ajax($options);
		},
		'change':function($obj){
			var $self=this;
			this.ajax({
				'url':this.url($obj.attr('href')),
				'success':function(data){
					$self.results(data);
				}
			});
		},
		'results':function(data){
			var $self=this;
			$self.target.empty().html($(data).find('results').contents()).find('.search_results .pagenavigator a').click(function(){
				$self.change($(this));
				return false;
			});
			Cufon.refresh();
		},
		'search':function($form){
			var $self=this;
			this.ajax({
				'url':this.url($form,'form'),
				'success':function(data){
					$self.results(data);
				}
			});
		},
		'url':function($item,$source){
			var $url=($source=='form')?encodeURIComponent(this.siteURL+'/content/search?'+$item.serialize()):encodeURIComponent(this.siteURL+$item);
			return "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20html%20where%20url%3D%22"+$url+"%22%20and%20xpath%3D'%2F%2Fdiv%5B%40class%3D%22search_results%22%5D'&diagnostics=true";
		}
	}
})(jQuery);

$(function(){


/*
$('#learningcenter-search form').submit(function(){
		$AJAXSearch.siteURL='http://sare.thinkcreative.com';
		$AJAXSearch.target=$('#ajaxcontent');
		$AJAXSearch.search($(this));
		return false;
	});
*/

	/* change 24hr clock to 12hr on create new event page */
	// this was on aggieland but apparently isn't needed on sare as i don't see any help text anyway
	//$('.ors-attribute-help-text').hide();	// '24 hour format'...not anymore!

	// add the ampm select
	var ampmSelect	=	'<div class="element">'
			+		'<label>&nbsp;</label>'
			+		'<select id="ampm" name="ampm">'
			+			'<option value="AM">AM</option>'
			+			'<option value="PM">PM</option>'
			+		'</select>'
			+	'</div>';
	$('.time').each(function(){
		$(this).append(ampmSelect);
	});

	// fix values on submit
	$('#editform').submit(function(){
		if ($('#From_Time #ampm').val() == 'PM' && (parseInt($('#From_Time .time input:first').val()) < 12))
			$('#From_Time .time input:first').val(parseInt($('#From_Time .time input:first').val()) + 12);

		if ($('#To_Time #ampm').val() == 'PM' && (parseInt($('#To_Time .time input:first').val()) < 12))
			$('#To_Time .time input:first').val(parseInt($('#To_Time .time input:first').val()) + 12);

		return true;
	});

	$('.additional-children .more-link').toggle(function(){
		$(this).text('Less').parents('.additional-children').find('.content-view-line').each(function(){
			$(this).css('min-height', 80);
		});
		$(this).text('Less').parents('.additional-children').find('.content-view-line.line-image').each(function(){
			$(this).css('min-height', 150);
		});
		$(this).text('Less').parents('.additional-children').find('.content-view-line').slideDown();
	},function(){
		$(this).text('More...').parents('.additional-children').find('.content-view-line').slideUp();
	}).css({'cursor':'pointer'});

	$('.content-view-line div.attribute-image img').each(function(){
		var item=$(this),
			parentLineItem=item.parents('.content-view-line');
		item.parents('.attribute-image').css({'left':((100-this.width)/2)+'px'});
		//if(this.height>parentLineItem.height()){
			//parentLineItem.height(this.height+10);
			parentLineItem.css('min-height', this.height+10);
		//}
	});

// print
//	$('.print').css({'display':'inline'}).click(function(){
//		window.print();
//		return false;
//	});

// text-size
	currentTxtSize = 1;
	$('.bigger-fs').click(function(){
		if(currentTxtSize < 3) {
			currentTxtSize += 0.20;
			$('p, .breadcrumbs li, .mid-col li, .sidenav li, .content-view-full td').css({fontSize: currentTxtSize+'em'});
		}
	});
//	$('.normal-txt').click(function(){
//		currentTxtSize = 1;
//		$('p, .breadcrumbs li, .mid-col li, .sidenav li').css({fontSize: '1em'});
//	});
	$('.smaller-fs').click(function(){
		if(currentTxtSize > 0) {
			currentTxtSize -= 0.20;
			$('p, .breadcrumbs li, .mid-col li, .sidenav li, .content-view-full td').css({fontSize: currentTxtSize+'em'});
		}
	});

//input field - initial value
	var inputinitial = $('#input-initial').val();
	$('#input-initial').focusin(function(){
	if ($(this).val() == inputinitial) {
		$(this).val('');
		}
	});

	$('#input-initial').focusout(function(){
	if ($(this).val() == '') {
		$(this).val(inputinitial);
		}
	});

//input field - initial value
	var searchfield = $('#searchtext').val();
	$('#searchtext').focusin(function(){
	if ($(this).val() == searchfield) {
		$(this).val('');
		}
	});

	$('#searchtext').focusout(function(){
	if ($(this).val() == '') {
		$(this).val(searchfield);
		}
	});

	var learningcenter_searchfield = $('#learningcenter-search input[name=SearchText]').val();
	$('#learningcenter-search input[name=SearchText]').focusin(function(){
	if ($(this).val() == learningcenter_searchfield) {
		$(this).val('');
		}
	});

	$('#learningcenter-search input[name=SearchText]').focusout(function(){
	if ($(this).val() == '') {
		$(this).val(learningcenter_searchfield);
		}
	});

// Scrollable initialization
if($('.scrollable .items a').length > 2) {
	$scrollables = $(".scrollable").scrollable({
		circular: true,
		easing: 'swing'
	}).autoscroll({
		autoplay: true,
		interval: 4000
	});

	$scrollables.each(function() {
		var $itemsToClone = $(this).scrollable().getItems().slice(1);
		var $wrap = $(this).scrollable().getItemWrap();
		var clonedClass = $(this).scrollable().getConf().clonedClass;
		$itemsToClone.each(function() {
			$(this).clone(true).appendTo($wrap)
				.addClass(clonedClass + ' hacked-' + clonedClass);
		});
	});
}

//subnav dropdown
	$("#global-menubar li").hover(function(){
			$(this)
				.css({zIndex: 19})
				.children(".subnav").show();
				setTimeout(function() {
					Cufon.refresh('#global-menubar li a.nav-link');
				}, 5);
	},
		function(){
			$(this)
				.css({zIndex: 20})
				.children(".subnav").hide();
				setTimeout(function() {
					Cufon.refresh('#global-menubar li a.nav-link');
				}, 5);
		}
	).css({'marginLeft':'-10000px'});


// news tabs
$("ul.tabs").tabs("div.panes > div");

// news tabs
$("ul.e-tabs").tabs("div.e-panes > div");

$("li a.current_topic").click().removeClass("current_topic");

// frontpage rotator
	if ($('.main-show-items').length>0) {
		$('.main-show-items')
		.cycle({
			fx:     'fade',
			speed:   600,
			timeout: 8000,
			pause: 1,
			pager:  '#show-nav',
			pagerAnchorBuilder: function(idx, slide) {
				return '#show-nav li:eq(' + idx + ')';
				}
		});
	}

// li:hover in ie6
	sfHover = function() {
		var sfEls = document.getElementById("global-menubar").getElementsByTagName("LI");
		for (var i=0; i<sfEls.length; i++) {
			sfEls[i].onmouseover=function() {
				this.className+=" sfhover";
			};
			sfEls[i].onmouseout=function() {
				this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
			};
		}
	};
	if (window.attachEvent) {
	window.attachEvent("onload", sfHover);
	}

	$(window).load(function(){
		// menu 100% with equal widths
		navWidth = $('#global-menubar').width();
		wBefore = 0;
		$('#global-menubar > li').each(function(){
			wBefore += $(this).width()+13;
		});
		wDelta = navWidth - wBefore;
		padd = Math.floor(wDelta / (2*$('#global-menubar > li').length));
		$('#global-menubar > li a.nav-link').css({padding: '0 '+padd+'px'});
		$('#global-menubar li').css({'marginLeft':0});
	});

	var overlayid='site-overlay';
	$('<div class="module overlay" id="'+overlayid+'"></div>').prependTo('body');
	$('body:not(.national) a[href^="http://saret.ifas.ufl.edu"]').each(function(){
		var obj=$(this);
		var href = obj.attr('href');
		obj.attr(href)
	}).overlay({
		'target':'#'+overlayid,
		'closeOnClick':true,
		'effect':'apple',
		'fixed':false,
		'onBeforeLoad':function(e){
			$('body>img').remove();
			var api=this;
			this.getOverlay().css({
				'width':'400px',
				'height':'250px'
			}).append('<div class="close"></div><div style="margin-top:20%;"><h3>You are now being directed to the SANET archives on the national SARE website</h3><strong><a href="'+this.getTrigger().attr('href')+'">Continue</a></strong></div>')
			.find('.close').click(function(){
				api.close();
			});

		},
		'onLoad':function(){
			$('body>img').remove();
			this.getOverlay().css({
				'zIndex':100000,
				'margin':'0px auto'
			});
		},
		'onClose':function(){
			this.getOverlay().empty();
		}
	});


	$('<div class="module overlay" id="'+overlayid+'"></div>').prependTo('body');
	$('body:not(.national) a[href^="http://mysare.sare.org/"]').each(function(){
		var obj=$(this);
		var href = obj.attr('href');
		obj.attr(href)
	}).overlay({
		'target':'#'+overlayid,
		'closeOnClick':true,
		'effect':'apple',
		'fixed':false,
		'onBeforeLoad':function(e){
			$('body>img').remove();
			var api=this;
			this.getOverlay().css({
				'width':'400px',
				'height':'250px'
			}).append('<div class="close"></div><div style="margin-top:20%;"><h3>You are now being directed to the national SARE projects database</h3><strong><a href="'+this.getTrigger().attr('href')+'">Continue</a></strong></div>')
			.find('.close').click(function(){
				api.close();
			});

		},
		'onLoad':function(){
			$('body>img').remove();
			this.getOverlay().css({
				'zIndex':100000,
				'margin':'0px auto'
			});
		},
		'onClose':function(){
			this.getOverlay().empty();
		}
	});



});

function customTagTabbox(id) {
	var tabbox_t = new Array();
	var tabbox_c = new Array();

	$('#' + id + ' table:first-child tbody:first-child tr:first-child th').each(function(intIndex){
		tabbox_t[intIndex] = $(this).find('p').html();
	});

	$('#' + id + ' table:first-child tbody:first-child tr:nth-child(2) > td').each(function(intIndex){
		tabbox_c[intIndex] = $(this).html();
	});

	var out = '<ul class="tabs">';

	for (var i = 0; i < tabbox_t.length; i++) {
		out += '<li><a class="tab ' + i + '" href="#">' + tabbox_t[i] + '</a></li>';
	}

	out += '</ul>';
	out += '<div class="panes">';

	for (var i = 0; i < tabbox_c.length; i++) {
		out += '<div class="pane ' + i + '">' + tabbox_c[i] + '</div>';
	}

	out += "</div>";

	$('#' + id).html(out);

// WHY ISN'T THIS WORKING. ?!
//	$('div.custom-tag-tabbox#' + id + ' ul.tabs').tabs('div.custom-tag-tabbox#' + id + ' div.panes > div');

// need to fix this

	$('div.custom-tag-tabbox#' + id + ' ul.tabs li a.0').click(function() {
		$('div.custom-tag-tabbox#' + id + ' ul.tabs li a').removeClass('current');
		$(this).addClass('current');
		$('.pane').hide();
		$('.pane.0').show();
		return false;
	});
	$('div.custom-tag-tabbox#' + id + ' ul.tabs li a.1').click(function() {
		$('div.custom-tag-tabbox#' + id + ' ul.tabs li a').removeClass('current');
		$(this).addClass('current');
		$('.pane').hide();
		$('.pane.1').show();
		return false;
	});
	$('div.custom-tag-tabbox#' + id + ' ul.tabs li a.0').click();





}
