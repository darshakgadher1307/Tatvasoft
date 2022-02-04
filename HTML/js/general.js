$(document).ready(function(){
    $(window).scroll(function(){
        var scroll = $(window).scrollTop();
        if (scroll > 0) {
          $("header").addClass("fixed");
        }
  
        else{
            $("header").removeClass("fixed");  	
        }
    })

  $(".nav-tabs a").click(function(){
    $(this).tab('show');
  });

  $(window).resize(function(){
    if($(window).width()<1200){
      $("#upcoming-service-menu-table").addClass("flex-column");
      $("#upcoming-service-menu").removeClass("flex-column");
      $("#upcoming-service-menu").addClass("flex-row justify-content-center");
    }
    else{
      $("#upcoming-service-menu-table").removeClass("flex-column");
      $("#upcoming-service-menu").addClass("flex-column");
      $("#upcoming-service-menu").removeClass("flex-row justify-content-center");
    } 
    if($(window).width()<992){
      $("#nav-line").removeClass("line");
      $("#l1").removeClass("line");
    }
    else{
      $("#nav-line").addClass("line");
      $("#l1").addClass("line");
    }
    if($(window).width()<718){
      $("tr#service").addClass("d-flex");
      $("tr#service").addClass("flex-column");
      $("td").addClass("text-center");
      $("#table-row-number").addClass("flex-column")
    }
    else{
      $("tr,#service").removeClass("d-flex");
      $("tr,#service").removeClass("flex-column");
      $("td").removeClass("text-center");
      $("#table-row-number").removeClass("flex-column")
    }
    if($(window).width()<940){
      $("#admin-user").addClass("flex-column");
      $(".admin-menu button").addClass("show");
      $(".admin-menu button").removeClass("hide");
      $(".admin-menu .navbar").addClass("collapse");
      $(".admin-menu .navbar .nav").removeClass("flex-column");
    }
    else{
      $("#admin-user").removeClass("flex-column");
      $(".admin-menu button").removeClass("show");
      $(".admin-menu button").addClass("hide");
      $(".admin-menu .navbar").removeClass("collapse");
      $(".admin-menu .navbar .nav").addClass("flex-column");
    }
    if($(window).width()<660){
      $("tr#admin").addClass("d-flex");
      $("tr#admin").addClass("flex-column");
    }
    else{
      $("tr,#admin").removeClass("d-flex");
      $("tr,#admin").removeClass("flex-column");
    }
  });

  $('#AddAddressButton').click(function(){
    $('#AddAddressForm').removeClass('hide');
    $('#AddAddressForm').addClass('show');
    $('#AddAddressButton').addClass('hide');
  });

  $('#AddAddressCancel').click(function(){
    $('#AddAddressForm').removeClass('show');
    $('#AddAddressForm').addClass('hide');
    $('#AddAddressButton').removeClass('hide');
  });

  $('#InvoiceCheckbox').click(function(){
    if($('#InvoiceCheckbox').prop('checked')){
      $('#invoice-form').removeClass('hide');
    }
    else
    {
      $('#invoice-form').addClass('hide');
    }
  });
  
});

