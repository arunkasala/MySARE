$(document).ready(function(){

  /* Current copyright year */
  var d = new Date();
  var curr_year = d.getFullYear();
  $('#footer-menu p:first').html('Sustainable Agriculture Research &amp; Education &copy;' + curr_year);

  /* Alternating row colors */
  $('table.sortable tr td:first').each(function(){
    if ($(this).attr('bgcolor'))
    {
      $(this).parent('tr').css('background-color', $(this).attr('bgcolor'));
    }
  });
  
  /* Italicizes the current page in the sidebar */
  $('div.sidenav a').each(function()
    {
      var elem = $(this).get(0);
      if (document.location.href.toLowerCase() == elem.href.toLowerCase())
      {
        $(this).css('font-style', 'italic').css('font-weight', 'bold');
      }
      else
      {
        $(this).css('font-style', 'normal').css('font-weight', 'normal');
      }
    }
  );
  
  /* Attempts to fix the funky border and background issue on Project Overview */
  $('td.copy table[id=projoverview]').each(function()
    {
      $(this).css('width', '750px');
      $(this).css('background-color', '#DCC9D0');
      $(this).css('border', '1px solid #883760');
      $(this).css('border-collapse', 'collapse');
      $(this).css('position', 'relative');
      $(this).css('zoom', '1'); 
      $(this).find('form tr').each(function(){
        $(this).width('740px');  
      });
      $(this).find('p').each(function(){ 
        $(this).css('display', 'inline'); 
      });
      $(this).find('table.NORM').each(function(){ 
        $(this).css('cssText', 'width:735px !important;'); 
      });
      $(this).find('input[name=projectTitle]').attr('size', '60'); 
    }
  );
  
  /* Makes the page title look the same way the parent site looks */
  $('.pagetitle').addClass('cufon').addClass('cufon-canvas');
  
  $('.tooltiptext').each(function(){
    var img = $('<img src="./images/help.png" width="22" height="19"/>');
    var text = $(this).html();
    $(this).empty()
    $(this).append(img);
    img.attr('title', text);
    img.tooltip({
      effect: 'slide',
      slideOffset: 4
    });
  });
  
});